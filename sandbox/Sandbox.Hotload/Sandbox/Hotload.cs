using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Sandbox.Upgraders;

namespace Sandbox
{
	/// <summary>
	/// Provides methods for replacing loaded assemblies with new versions at runtime.
	/// </summary>
	// Token: 0x02000004 RID: 4
	public class Hotload
	{
		// Token: 0x06000004 RID: 4 RVA: 0x0000207F File Offset: 0x0000027F
		private void ClearFieldDefaults()
		{
			this.DefaultDelegates.Clear();
			this.LoadedAssemblyDefinitions.Clear();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002098 File Offset: 0x00000298
		private AssemblyDefinition GetAssemblyDefinition(Assembly asm)
		{
			AssemblyDefinition asmDef;
			if (this.LoadedAssemblyDefinitions.TryGetValue(asm, out asmDef))
			{
				return asmDef;
			}
			if (string.IsNullOrEmpty(asm.Location))
			{
				return null;
			}
			asmDef = AssemblyDefinition.ReadAssembly(asm.Location);
			this.LoadedAssemblyDefinitions.Add(asm, asmDef);
			return asmDef;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020E0 File Offset: 0x000002E0
		private static string GetDefaultMethodName(Type type, FieldInfo field)
		{
			return "__default__" + field.Name;
		}

		/// <summary>
		/// Attempts to get the default value for a newly created field on an
		/// existing type. Returns true if successful.
		/// </summary>
		/// <remarks>
		/// This value should not be cached, but evaluated for each instance.
		/// Works by finding the CIL that initializes the given field and
		/// generating a dynamic method, which is then cached and invoked.
		/// </remarks>
		/// <param name="field">Field to retrieve a default value for.</param>
		/// <param name="value">If successful, contains the default value.</param>
		// Token: 0x06000007 RID: 7 RVA: 0x000020F4 File Offset: 0x000002F4
		private bool TryGetDefaultValue(FieldInfo field, out object value)
		{
			value = null;
			Type type = field.DeclaringType;
			Dictionary<FieldInfo, Hotload.DefaultDelegate> fieldDict;
			if (!this.DefaultDelegates.TryGetValue(type, out fieldDict))
			{
				fieldDict = new Dictionary<FieldInfo, Hotload.DefaultDelegate>();
				this.DefaultDelegates.Add(type, fieldDict);
			}
			Hotload.DefaultDelegate deleg;
			if (fieldDict.TryGetValue(field, out deleg))
			{
				if (deleg == null)
				{
					return false;
				}
				value = deleg();
				return true;
			}
			else
			{
				deleg = this.GetDefaultDelegate(type, field);
				fieldDict.Add(field, deleg);
				if (deleg == null)
				{
					return false;
				}
				value = deleg();
				return true;
			}
		}

		/// <summary>
		/// Find the number of arguments that invoking the given method will pop.
		/// </summary>
		// Token: 0x06000008 RID: 8 RVA: 0x00002168 File Offset: 0x00000368
		private static int GetArgCount(OpCode opCode, MethodReference methodRef)
		{
			int count = 0;
			if (methodRef.HasParameters)
			{
				count += methodRef.Parameters.Count;
			}
			if (methodRef.HasThis && opCode.Code != Code.Newobj)
			{
				count++;
			}
			return count;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021A8 File Offset: 0x000003A8
		private static int GetStackDelta(MethodDefinition method, Instruction inst)
		{
			int delta = 0;
			if (inst.OpCode.StackBehaviourPop != StackBehaviour.Varpop)
			{
				delta -= Hotload.StackBehaviourValues[(int)inst.OpCode.StackBehaviourPop];
			}
			else if (inst.OpCode.FlowControl == FlowControl.Return)
			{
				if (!(method.ReturnType.FullName == "System.Void"))
				{
					return 1;
				}
				return 0;
			}
			else
			{
				MethodReference operand = inst.Operand as MethodReference;
				if (operand == null)
				{
					throw new NotImplementedException();
				}
				delta -= Hotload.GetArgCount(inst.OpCode, operand);
			}
			if (inst.OpCode.StackBehaviourPush != StackBehaviour.Varpush)
			{
				delta += Hotload.StackBehaviourValues[(int)inst.OpCode.StackBehaviourPush];
			}
			else
			{
				MethodReference operand2 = inst.Operand as MethodReference;
				if (operand2 == null)
				{
					throw new NotImplementedException();
				}
				delta += ((operand2.ReturnType.FullName == "System.Void") ? 0 : 1);
			}
			return delta;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002294 File Offset: 0x00000494
		private static bool IsLoadArg(Instruction inst)
		{
			Code code = inst.OpCode.Code;
			return code - Code.Ldarg_0 <= 3 || code - Code.Ldarg_S <= 1 || code - Code.Ldarg <= 1;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000022CC File Offset: 0x000004CC
		private static bool ReadNextInstruction(MethodDefinition method, ref Instruction inst, ref int stack, Hotload.CtorAction action)
		{
			if (inst == null)
			{
				return false;
			}
			if (Hotload.IsLoadArg(inst))
			{
				action.NeedsParameters = true;
			}
			stack += Hotload.GetStackDelta(method, inst);
			action.MaxStack = Math.Max(stack, action.MaxStack);
			if (stack < 0)
			{
				return false;
			}
			inst = inst.Next;
			return true;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002320 File Offset: 0x00000520
		private static Hotload.CtorAction ReadAction(MethodDefinition method, ref Instruction inst)
		{
			Instruction instruction = inst;
			if (instruction == null || instruction.OpCode.Code != Code.Ldarg_0)
			{
				return null;
			}
			Hotload.CtorAction action = new Hotload.CtorAction
			{
				Method = method,
				First = inst
			};
			inst = inst.Next;
			int stack = 0;
			while (Hotload.ReadNextInstruction(method, ref inst, ref stack, action))
			{
			}
			if (inst == null)
			{
				return null;
			}
			action.Last = inst;
			action.IsFieldSet = inst.OpCode.Code == Code.Stfld;
			if (action.IsFieldSet)
			{
				action.Field = inst.Operand as FieldReference;
			}
			else if (inst.OpCode.Code == Code.Call)
			{
				MethodReference operand = inst.Operand as MethodReference;
				if (operand == null)
				{
					return action;
				}
				if (operand.Name != ".ctor")
				{
					return action;
				}
				if (operand.DeclaringType == method.DeclaringType)
				{
					action.IsThisCtorCall = true;
				}
			}
			inst = inst.Next;
			return action;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002414 File Offset: 0x00000614
		private static IEnumerable<Hotload.CtorAction> GetCtorActions(MethodDefinition method)
		{
			if (!method.HasBody || method.Body.Instructions.Count == 0)
			{
				yield break;
			}
			Instruction inst = method.Body.Instructions[0];
			Hotload.CtorAction action;
			while ((action = Hotload.ReadAction(method, ref inst)) != null)
			{
				if (!action.IsFieldSet)
				{
					yield break;
				}
				yield return action;
			}
			yield break;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002424 File Offset: 0x00000624
		private static bool IsMatchingField(FieldReference a, FieldReference b)
		{
			return (a == null && b == null) || (a != null && b != null && a.FullName == b.FullName);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002448 File Offset: 0x00000648
		private Hotload.DefaultDelegate GetDefaultDelegate(Type type, FieldInfo field)
		{
			AssemblyDefinition asmDef = this.GetAssemblyDefinition(type.GetTypeInfo().Assembly);
			if (asmDef == null)
			{
				return null;
			}
			TypeDefinition typeDef = asmDef.MainModule.GetType(type.FullName);
			if (typeDef == null)
			{
				return null;
			}
			IEnumerable<MethodDefinition> constructors = typeDef.GetConstructors();
			FieldReference fieldRef = typeDef.Fields.First((FieldDefinition x) => x.Name == field.Name);
			Func<Hotload.CtorAction, bool> <>9__8;
			Hotload.CtorAction matchingAction = (from x in (from x in constructors.Select(new Func<MethodDefinition, IEnumerable<Hotload.CtorAction>>(Hotload.GetCtorActions))
					select x.ToArray<Hotload.CtorAction>() into x
					where x.Length != 0
					where x.All((Hotload.CtorAction y) => !y.IsThisCtorCall && !y.NeedsParameters)
					select x).Select(delegate(Hotload.CtorAction[] x)
				{
					Func<Hotload.CtorAction, bool> predicate;
					if ((predicate = <>9__8) == null)
					{
						predicate = (<>9__8 = (Hotload.CtorAction y) => Hotload.IsMatchingField(fieldRef, y.Field));
					}
					return x.FirstOrDefault(predicate);
				})
				where x != null
				orderby x.Method.Parameters.Count
				select x).FirstOrDefault<Hotload.CtorAction>();
			if (matchingAction == null)
			{
				return null;
			}
			DynamicMethod dynamicMethod = new DynamicMethod(Hotload.GetDefaultMethodName(type, field), typeof(object), new Type[0], type);
			ILGenerator il = dynamicMethod.GetILGenerator();
			il.Emit(type.GetTypeInfo().Module, matchingAction.First.Next, matchingAction.Last);
			if (field.FieldType.GetTypeInfo().IsValueType)
			{
				il.Emit(OpCodes.Box, field.FieldType);
			}
			il.Emit(OpCodes.Ret);
			return (Hotload.DefaultDelegate)dynamicMethod.CreateDelegate(typeof(Hotload.DefaultDelegate));
		}

		/// <summary>
		/// If true, the static field or watched object that instances are found under will be stored in <see cref="P:Sandbox.TypeTimingEntry.Roots" />.
		/// Defaults to false.
		/// </summary>
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000010 RID: 16 RVA: 0x0000262F File Offset: 0x0000082F
		// (set) Token: 0x06000011 RID: 17 RVA: 0x00002637 File Offset: 0x00000837
		public bool TraceRoots { get; set; }

		/// <summary>
		/// Default constructor that includes Sandbox.Hotload.dll and Mono.Cecil.dll to the
		/// ignored assembly list.
		/// </summary>
		// Token: 0x06000012 RID: 18 RVA: 0x00002640 File Offset: 0x00000840
		public Hotload(bool addDefaultUpgraders = true)
		{
			this.IgnoreAssembly(typeof(Hotload).GetTypeInfo().Assembly);
			this.IgnoreAssembly(typeof(AssemblyDefinition).GetTypeInfo().Assembly);
			this.AllUpgraders.Add(typeof(RootUpgraderGroup), this.RootUpgraderGroup);
			if (addDefaultUpgraders)
			{
				this.AddUpgraders(typeof(Hotload).GetTypeInfo().Assembly);
			}
		}

		/// <summary>
		/// Any fields declared on types defined in the given assembly will be skipped
		/// during future reference updates.
		/// </summary>
		/// <param name="toIgnore">Assembly to ignore the members of.</param>
		// Token: 0x06000013 RID: 19 RVA: 0x00002743 File Offset: 0x00000943
		public void IgnoreAssembly(Assembly toIgnore)
		{
			if (toIgnore == null)
			{
				throw new Exception("Ignore Assembly - but assembly is null");
			}
			this.IgnoredAssemblies.Add(toIgnore);
		}

		/// <summary>
		/// Any fields declared on types defined in the given assembly will be skipped
		/// during future reference updates.
		/// </summary>
		// Token: 0x06000014 RID: 20 RVA: 0x00002766 File Offset: 0x00000966
		public void IgnoreAssembly<T>()
		{
			this.IgnoreAssembly(typeof(T).Assembly);
		}

		/// <summary>
		/// To be called when one assembly is being replaced by another.
		///
		/// This should be called during a hotload.
		/// </summary>
		// Token: 0x06000015 RID: 21 RVA: 0x00002780 File Offset: 0x00000980
		public bool ReplacingAssembly(Assembly oldAssembly, Assembly newAssembly)
		{
			if (oldAssembly != null)
			{
				this.WatchAssembly(oldAssembly);
			}
			if (newAssembly != null)
			{
				this.WatchAssembly(newAssembly);
			}
			if (oldAssembly == null || newAssembly == null)
			{
				return false;
			}
			if (this.Swaps.ContainsKey(oldAssembly))
			{
				this.Swaps[oldAssembly] = newAssembly;
				return true;
			}
			KeyValuePair<Assembly, Assembly> match = this.Swaps.FirstOrDefault((KeyValuePair<Assembly, Assembly> x) => x.Value == oldAssembly);
			if (match.Key != null)
			{
				this.Swaps[match.Key] = newAssembly;
			}
			this.Swaps.Add(oldAssembly, newAssembly);
			return true;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002851 File Offset: 0x00000A51
		public Assembly[] GetOutgoingAssemblies()
		{
			return this.Swaps.Select((KeyValuePair<Assembly, Assembly> x) => x.Key).Distinct<Assembly>().ToArray<Assembly>();
		}

		/// <summary>
		/// Returns the queue of assemblies that will be swapped when
		/// <see cref="M:Sandbox.Hotload.UpdateReferences" /> is called. These are added using the
		/// <see cref="M:Sandbox.Hotload.ReplacingAssembly(System.Reflection.Assembly,System.Reflection.Assembly)" /> method.
		/// </summary>
		/// <returns>The mapping of assembly replacements.</returns>
		// Token: 0x06000017 RID: 23 RVA: 0x00002888 File Offset: 0x00000A88
		public IReadOnlyDictionary<Assembly, Assembly> GetQueuedAssemblyReplacements()
		{
			return this.Swaps.ToDictionary((KeyValuePair<Assembly, Assembly> kv) => kv.Key, (KeyValuePair<Assembly, Assembly> kv) => kv.Value);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000028E0 File Offset: 0x00000AE0
		public void AddUpgrader(Hotload.IInstanceUpgrader upgrader)
		{
			Type upgraderType = upgrader.GetType();
			if (this.AllUpgraders.ContainsKey(upgraderType))
			{
				throw new Exception("There is already an upgrader of type " + upgraderType.FullName + " added to this instance.");
			}
			this.AllUpgraders.Add(upgraderType, upgrader);
			this.RootUpgraderGroup.AddUpgrader(upgrader);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002936 File Offset: 0x00000B36
		public void AddUpgrader<TUpgrader>() where TUpgrader : Hotload.IInstanceUpgrader, new()
		{
			this.AddUpgrader(new TUpgrader());
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002948 File Offset: 0x00000B48
		public Hotload.IInstanceUpgrader GetUpgrader(Type upgraderType)
		{
			Hotload.IInstanceUpgrader upgrader;
			if (this.AllUpgraders.TryGetValue(upgraderType, out upgrader))
			{
				return upgrader;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Upgrader of type ");
			defaultInterpolatedStringHandler.AppendFormatted<Type>(upgraderType);
			defaultInterpolatedStringHandler.AppendLiteral(" not yet added.");
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000299D File Offset: 0x00000B9D
		public TUpgrader GetUpgrader<TUpgrader>() where TUpgrader : Hotload.IInstanceUpgrader
		{
			return (TUpgrader)((object)this.GetUpgrader(typeof(TUpgrader)));
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000029B4 File Offset: 0x00000BB4
		public bool TryGetUpgrader(Type upgraderType, out Hotload.IInstanceUpgrader upgrader)
		{
			return this.AllUpgraders.TryGetValue(upgraderType, out upgrader);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000029C4 File Offset: 0x00000BC4
		public bool TryGetUpgrader<TUpgrader>(out TUpgrader upgrader) where TUpgrader : Hotload.IInstanceUpgrader
		{
			Hotload.IInstanceUpgrader value;
			if (this.TryGetUpgrader(typeof(TUpgrader), out value))
			{
				upgrader = (TUpgrader)((object)value);
				return true;
			}
			upgrader = default(TUpgrader);
			return false;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000029FC File Offset: 0x00000BFC
		public void AddUpgraders(Assembly asm)
		{
			List<Exception> exceptions = null;
			List<Hotload.UpgraderInfo> toAdd = new List<Hotload.UpgraderInfo>();
			HashSet<Type> addedGroupTypes = new HashSet<Type> { typeof(RootUpgraderGroup) };
			foreach (Type type in asm.GetTypes())
			{
				if (!type.IsAbstract && !type.IsGenericTypeDefinition && typeof(Hotload.IInstanceUpgrader).IsAssignableFrom(type) && type.GetCustomAttribute<DisableAutoCreationAttribute>() == null)
				{
					ConstructorInfo ctor = type.GetConstructor(Array.Empty<Type>());
					if (ctor == null)
					{
						List<Exception> list;
						if ((list = exceptions) == null)
						{
							list = (exceptions = new List<Exception>());
						}
						list.Add(new Exception("Type " + type.FullName + " implements IInstanceUpgrader without a DisableAutoCreationAttribute, but doesn't have a parameterless constructor."));
					}
					else
					{
						try
						{
							Hotload.IInstanceUpgrader inst = (Hotload.IInstanceUpgrader)ctor.Invoke(Array.Empty<object>());
							toAdd.Add(new Hotload.UpgraderInfo(inst, type));
						}
						catch (Exception e)
						{
							List<Exception> list2;
							if ((list2 = exceptions) == null)
							{
								list2 = (exceptions = new List<Exception>());
							}
							list2.Add(e);
						}
					}
				}
			}
			Predicate<Hotload.UpgraderInfo> <>9__0;
			while (toAdd.Count > 0)
			{
				List<Hotload.UpgraderInfo> list3 = toAdd;
				Predicate<Hotload.UpgraderInfo> match;
				if ((match = <>9__0) == null)
				{
					match = (<>9__0 = (Hotload.UpgraderInfo x) => x.GroupType == null || addedGroupTypes.Contains(x.GroupType));
				}
				int nextIndex = Math.Max(list3.FindIndex(match), 0);
				Hotload.UpgraderInfo next = toAdd[nextIndex];
				toAdd.RemoveAt(nextIndex);
				try
				{
					this.AddUpgrader(next.Upgrader);
					if (next.Upgrader is UpgraderGroup)
					{
						addedGroupTypes.Add(next.Upgrader.GetType());
					}
				}
				catch (Exception e2)
				{
					List<Exception> list4;
					if ((list4 = exceptions) == null)
					{
						list4 = (exceptions = new List<Exception>());
					}
					list4.Add(e2);
				}
			}
			if (exceptions == null)
			{
				return;
			}
			if (exceptions.Count == 1)
			{
				throw exceptions[0];
			}
			throw new AggregateException("Exceptions thrown while attempting to add IInstanceUpgraders from assembly " + asm.FullName + ".", exceptions);
		}

		/// <summary>
		/// Cycle though all types in all watched assemblies.
		/// Find statics, iterate over all their fields recursively.
		/// Replace any instances of classes that are defined in the assemblies added using ReplacingAssembly
		/// </summary>
		// Token: 0x0600001F RID: 31 RVA: 0x00002C00 File Offset: 0x00000E00
		public HotloadResult UpdateReferences()
		{
			if (this.Swaps.Count == 0)
			{
				return HotloadResult.NoActionSingleton;
			}
			foreach (Hotload.IInstanceUpgrader upgrader in this.AllUpgraders.Values)
			{
				if (!upgrader.IsInitialized)
				{
					upgrader.Initialize(this);
				}
			}
			this.CurrentResult = new HotloadResult();
			this.TypeTimings.Clear();
			Stopwatch timer = new Stopwatch();
			timer.Start();
			DefaultUpgrader defaultUpgrader = this.GetUpgrader<DefaultUpgrader>();
			try
			{
				this.RootUpgraderGroup.HotloadStart();
				foreach (Type type in this.WatchedAssemblies.SelectMany((Assembly x) => x.GetTypes()))
				{
					this.UpdateReferencesInType(type);
				}
				foreach (object instance in this.WatchedInstances)
				{
					this.CurrentRoot = "[WatchedInstance] " + instance.GetType().ToSimpleString();
					defaultUpgrader.ProcessObjectFields(instance);
					this.CurrentRoot = null;
				}
				this.ProcessInstanceQueue();
			}
			finally
			{
				this.RootUpgraderGroup.HotloadComplete();
				AutoSkipUpgrader upgrader2;
				if (this.TryGetUpgrader<AutoSkipUpgrader>(out upgrader2))
				{
					IEnumerable<string> skippedTypes = upgrader2.SkippedTypes.Select((Type x) => x.ToSimpleString());
					if (skippedTypes != null)
					{
						this.CurrentResult.AutoSkippedTypes.AddRange(skippedTypes);
					}
				}
				this.ClearFieldDefaults();
				this.DefaultInstanceTaskQueue.Clear();
				this.LateInstanceTaskQueue.Clear();
				this.SubstituteTypeCache.Clear();
				this.RootUpgraderGroup.ClearCache();
				foreach (KeyValuePair<Assembly, Assembly> swap in this.Swaps.Where((KeyValuePair<Assembly, Assembly> kv) => this.WatchedAssemblies.Contains(kv.Key)).ToList<KeyValuePair<Assembly, Assembly>>())
				{
					this.WatchedAssemblies.Remove(swap.Key);
					this.WatchAssembly(swap.Value);
				}
				this.Swaps.Clear();
			}
			this.CurrentResult.ProcessingTime = timer.Elapsed.TotalMilliseconds;
			return this.CurrentResult;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002EB8 File Offset: 0x000010B8
		private void ScheduleInstanceTask(Hotload.IInstanceProcessor handler, object oldInstance, object newInstance)
		{
			this.DefaultInstanceTaskQueue.Enqueue(new Hotload.InstanceTask(handler, oldInstance, newInstance, this.CurrentRoot));
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002ED3 File Offset: 0x000010D3
		private void ScheduleLateInstanceTask(Hotload.IInstanceProcessor handler, object oldInstance, object newInstance)
		{
			this.LateInstanceTaskQueue.Enqueue(new Hotload.InstanceTask(handler, oldInstance, newInstance, this.CurrentRoot));
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002EF0 File Offset: 0x000010F0
		private void ProcessInstanceQueue()
		{
			Stopwatch sw = new Stopwatch();
			Hotload.InstanceTask task;
			while (this.DefaultInstanceTaskQueue.TryDequeue(out task) || this.LateInstanceTaskQueue.TryDequeue(out task))
			{
				sw.Restart();
				this.CurrentRoot = task.Root;
				int instanceCount = task.Handler.ProcessInstance(task.OldInstance, task.NewInstance);
				Type instanceType = task.OldInstance.GetType();
				this.CurrentRoot = null;
				sw.Stop();
				this.CurrentResult.InstancesProcessed += instanceCount;
				TypeTimingEntry t;
				if (!this.TypeTimings.TryGetValue(instanceType, out t))
				{
					string typeName = instanceType.ToSimpleString();
					if (!this.CurrentResult.Timings.TryGetValue(typeName, out t))
					{
						this.CurrentResult.Timings.Add(typeName, t = new TypeTimingEntry(this.TraceRoots));
					}
					this.TypeTimings.Add(instanceType, t);
				}
				t.Instances += instanceCount;
				t.Milliseconds += sw.Elapsed.TotalMilliseconds;
				if (this.TraceRoots && task.Root != null)
				{
					TimingEntry rootTiming;
					if (t.Roots.TryGetValue(task.Root, out rootTiming))
					{
						rootTiming.Instances += instanceCount;
						rootTiming.Milliseconds += sw.Elapsed.TotalMilliseconds;
					}
					else
					{
						t.Roots.Add(task.Root, new TimingEntry(instanceCount, sw.Elapsed));
					}
				}
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003084 File Offset: 0x00001284
		internal void UpdateReferencesInType(Type t)
		{
			TypeInfo typeInfo = t.GetTypeInfo();
			if (this.IgnoredAssemblies.Contains(typeInfo.Assembly))
			{
				return;
			}
			if (typeInfo.ContainsGenericParameters)
			{
				return;
			}
			if (typeInfo.GetCustomAttribute<Hotload.SkipAttribute>() != null)
			{
				return;
			}
			if (t.Name == "<PrivateImplementationDetails>")
			{
				return;
			}
			if (typeInfo.IsSealed && typeInfo.IsAbstract && DelegateUpgrader.IsCompilerGenerated(t))
			{
				return;
			}
			Type subType = this.GetNewType(t);
			foreach (FieldInfo staticField in t.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
			{
				FieldInfo newField = ((subType != null) ? this.GetOldField(subType, staticField, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) : staticField);
				if (!(newField == null) && !newField.IsLiteral && newField.GetCustomAttribute<Hotload.SkipAttribute>() == null)
				{
					object curVal = staticField.GetValue(null);
					if (curVal != null)
					{
						this.CurrentRoot = "[StaticField] " + t.ToSimpleString() + "::" + staticField.Name;
						try
						{
							if (newField.IsInitOnly)
							{
								object newVal = newField.GetValue(null);
								if (newVal != null)
								{
									this.RootUpgraderGroup.TryUpgradeInstance(curVal, newVal);
								}
							}
							else
							{
								object newVal2 = this.GetNewInstance(curVal, null);
								newField.SetValue(null, newVal2);
							}
						}
						catch (Exception e)
						{
							this.CurrentResult.AddEntry(new HotloadResultEntry(e, null, newField));
						}
						finally
						{
							this.CurrentRoot = null;
						}
					}
				}
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003208 File Offset: 0x00001408
		private FieldInfo GetOldField(Type oldType, FieldInfo field, BindingFlags flags)
		{
			while (!this.AreEquivalentTypes(oldType, field.DeclaringType))
			{
				if (oldType.GetTypeInfo().BaseType == null)
				{
					return null;
				}
				oldType = oldType.GetTypeInfo().BaseType;
			}
			return oldType.GetField(field.Name, flags);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003258 File Offset: 0x00001458
		private object GetNewInstance(object oldInstance, object context = null)
		{
			if (oldInstance == null)
			{
				return null;
			}
			object newInstance;
			if (this.RootUpgraderGroup.TryCreateNewInstance(oldInstance, context, out newInstance))
			{
				return newInstance;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003284 File Offset: 0x00001484
		private Type GetSubstituteType(Assembly asm, Type oldType)
		{
			if (oldType.FullName == null)
			{
				if (oldType.DeclaringType == null)
				{
					return null;
				}
				Type substituteType = this.GetSubstituteType(asm, oldType.DeclaringType);
				if (substituteType == null)
				{
					return null;
				}
				return substituteType.GetNestedType(oldType.Name, BindingFlags.Public | BindingFlags.NonPublic);
			}
			else
			{
				Type sub = asm.GetType(oldType.FullName);
				if (sub != null)
				{
					return sub;
				}
				bool isNested = oldType.IsNested;
				return null;
			}
		}

		/// <summary>
		/// In a swapped assembly find a replacement type for this type.
		/// Return null if no replacement is found.
		/// </summary>
		// Token: 0x06000027 RID: 39 RVA: 0x000032EC File Offset: 0x000014EC
		private Type GetNewType(Type oldType)
		{
			Type newType;
			if (this.SubstituteTypeCache.TryGetValue(oldType, out newType))
			{
				return newType;
			}
			TypeInfo typeInfo = oldType.GetTypeInfo();
			Assembly typeAssembly = typeInfo.Assembly;
			if (typeInfo.IsGenericType && !typeInfo.IsGenericTypeDefinition)
			{
				newType = this.GetNewGenericType(oldType);
			}
			else
			{
				Assembly swapAssembly;
				newType = (this.Swaps.TryGetValue(typeAssembly, out swapAssembly) ? this.GetSubstituteType(swapAssembly, oldType) : null);
			}
			this.SubstituteTypeCache.Add(oldType, newType);
			return newType;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003360 File Offset: 0x00001560
		private Type GetNewGenericType(Type oldType)
		{
			TypeInfo typeInfo = oldType.GetTypeInfo();
			Type defType = typeInfo.GetGenericTypeDefinition();
			Type newType = this.GetNewType(defType);
			bool madeSubstitution = newType != null;
			Type[] args = typeInfo.GetGenericArguments();
			for (int i = 0; i < args.Length; i++)
			{
				Type argSubType = this.GetNewType(args[i]);
				args[i] = argSubType ?? args[i];
				madeSubstitution |= argSubType != null;
			}
			newType = (newType ?? defType).MakeGenericType(args);
			if (!madeSubstitution)
			{
				return null;
			}
			return newType;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000033DC File Offset: 0x000015DC
		private bool AreEquivalentTypes(Type oldType, Type newType)
		{
			Type subType;
			if (this.SubstituteTypeCache.TryGetValue(oldType, out subType) && subType == newType)
			{
				return true;
			}
			if (oldType.Name != newType.Name)
			{
				return false;
			}
			if (oldType.Namespace != newType.Namespace)
			{
				return false;
			}
			if (!oldType.IsConstructedGenericType && !newType.IsConstructedGenericType)
			{
				return true;
			}
			if (!oldType.IsConstructedGenericType || !newType.IsConstructedGenericType)
			{
				return false;
			}
			Type[] oldArgs = oldType.GenericTypeArguments;
			Type[] newArgs = newType.GenericTypeArguments;
			if (oldArgs.Length != newArgs.Length)
			{
				return false;
			}
			for (int i = 0; i < oldArgs.Length; i++)
			{
				if (!this.AreEquivalentTypes(oldArgs[i], newArgs[i]))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Look for instances to replace in the static fields of types defined in the given assembly.
		/// </summary>
		/// <param name="a">Assembly to watch the static fields of.</param>
		// Token: 0x0600002A RID: 42 RVA: 0x0000348C File Offset: 0x0000168C
		public void WatchAssembly(Assembly a)
		{
			HashSet<Assembly> watchedAssemblies = this.WatchedAssemblies;
			lock (watchedAssemblies)
			{
				if (!this.WatchedAssemblies.Contains(a))
				{
					this.WatchedAssemblies.Add(a);
				}
			}
		}

		/// <summary>
		/// Look for instances to replace in the static fields of types defined in 
		/// the defining assembly of <typeparamref name="T" />.
		/// </summary>
		/// <typeparam name="T">Type defined in the assembly to watch the static fields of.</typeparam>
		// Token: 0x0600002B RID: 43 RVA: 0x000034E4 File Offset: 0x000016E4
		public void WatchAssembly<T>()
		{
			this.WatchAssembly(typeof(T).GetTypeInfo().Assembly);
		}

		/// <summary>
		/// Watch an assembly, by name
		/// </summary>
		// Token: 0x0600002C RID: 44 RVA: 0x00003500 File Offset: 0x00001700
		public void WatchAssembly(string assemblyName)
		{
			Assembly assembly2 = AppDomain.CurrentDomain.GetAssemblies().Single((Assembly assembly) => assembly.GetName().Name == assemblyName);
			this.WatchAssembly(assembly2);
		}

		/// <summary>
		/// Stop watching static fields of types defined in the given assembly.
		/// </summary>
		/// <param name="a">Assembly to stop watching the static fields of.</param>
		// Token: 0x0600002D RID: 45 RVA: 0x00003540 File Offset: 0x00001740
		public void UnwatchAssembly(Assembly a)
		{
			HashSet<Assembly> watchedAssemblies = this.WatchedAssemblies;
			lock (watchedAssemblies)
			{
				this.WatchedAssemblies.Remove(a);
			}
		}

		/// <summary>
		/// Look for instances to replace in the fields of the given object.
		/// </summary>
		/// <param name="obj">Object to watch the fields of.</param>
		// Token: 0x0600002E RID: 46 RVA: 0x00003588 File Offset: 0x00001788
		public void WatchInstance<T>(T obj) where T : class
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			HashSet<object> watchedInstances = this.WatchedInstances;
			lock (watchedInstances)
			{
				this.WatchedInstances.Add(obj);
			}
		}

		/// <summary>
		/// Stop looking for instances to replace in the fields of the given object.
		/// </summary>
		/// <param name="obj">Object to stop watching the fields of.</param>
		// Token: 0x0600002F RID: 47 RVA: 0x000035E8 File Offset: 0x000017E8
		public void UnwatchInstance<T>(T obj) where T : class
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			HashSet<object> watchedInstances = this.WatchedInstances;
			lock (watchedInstances)
			{
				this.WatchedInstances.Remove(obj);
			}
		}

		// Token: 0x04000002 RID: 2
		private readonly Dictionary<Type, Dictionary<FieldInfo, Hotload.DefaultDelegate>> DefaultDelegates = new Dictionary<Type, Dictionary<FieldInfo, Hotload.DefaultDelegate>>();

		// Token: 0x04000003 RID: 3
		private readonly Dictionary<Assembly, AssemblyDefinition> LoadedAssemblyDefinitions = new Dictionary<Assembly, AssemblyDefinition>();

		/// <summary>
		/// Stack size delta for each stack behaviour.
		/// </summary>
		// Token: 0x04000004 RID: 4
		private static readonly int[] StackBehaviourValues = new int[]
		{
			0, 1, 2, 1, 2, 2, 2, 3, 2, 2,
			1, 2, 2, 3, 3, 3, 3, 3, 0, 0,
			1, 2, 1, 1, 1, 1, 1, 0, 0
		};

		/// <summary>
		/// A mapping of assembles to swap with new versions.
		/// </summary>
		// Token: 0x04000005 RID: 5
		private readonly Dictionary<Assembly, Assembly> Swaps = new Dictionary<Assembly, Assembly>();

		/// <summary>
		/// A list of assemblies containing members that should be skipped during a reference update.
		/// </summary>
		// Token: 0x04000006 RID: 6
		private readonly HashSet<Assembly> IgnoredAssemblies = new HashSet<Assembly>();

		// Token: 0x04000007 RID: 7
		private readonly Dictionary<Type, Hotload.IInstanceUpgrader> AllUpgraders = new Dictionary<Type, Hotload.IInstanceUpgrader>();

		// Token: 0x04000008 RID: 8
		private readonly RootUpgraderGroup RootUpgraderGroup = new RootUpgraderGroup();

		// Token: 0x0400000A RID: 10
		private readonly Dictionary<Type, Type> SubstituteTypeCache = new Dictionary<Type, Type>();

		// Token: 0x0400000B RID: 11
		private readonly Dictionary<Type, TypeTimingEntry> TypeTimings = new Dictionary<Type, TypeTimingEntry>();

		// Token: 0x0400000C RID: 12
		private readonly Queue<Hotload.InstanceTask> DefaultInstanceTaskQueue = new Queue<Hotload.InstanceTask>();

		// Token: 0x0400000D RID: 13
		private readonly Queue<Hotload.InstanceTask> LateInstanceTaskQueue = new Queue<Hotload.InstanceTask>();

		// Token: 0x0400000E RID: 14
		private HotloadResult CurrentResult;

		// Token: 0x0400000F RID: 15
		private string CurrentRoot;

		/// <remarks>
		/// TODO: Remember to make this non-public again
		/// </remarks>
		// Token: 0x04000010 RID: 16
		public readonly HashSet<Assembly> WatchedAssemblies = new HashSet<Assembly>();

		/// <remarks>
		/// TODO: Remember to make this non-public again
		/// </remarks>
		// Token: 0x04000011 RID: 17
		public readonly HashSet<object> WatchedInstances = new HashSet<object>();

		/// <summary>
		/// Skip processing a specific field, or any fields in a type marked by this attribute. Field
		/// processing will still occur if a type marked by this attribute was defined in a swapped assembly.
		/// </summary>
		/// <remarks>
		/// This is nice for speeding up hotloading, particularly when used on types with lots of fields, or
		/// on fields that are the only path to large networks of objects that all don't need replacing during the hotload.
		/// </remarks>
		// Token: 0x0200002B RID: 43
		[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field, Inherited = false)]
		public sealed class SkipAttribute : Attribute
		{
		}

		// Token: 0x0200002C RID: 44
		// (Invoke) Token: 0x06000111 RID: 273
		private delegate object DefaultDelegate();

		// Token: 0x0200002D RID: 45
		private class CtorAction
		{
			// Token: 0x0400004E RID: 78
			public bool NeedsParameters;

			// Token: 0x0400004F RID: 79
			public bool IsThisCtorCall;

			// Token: 0x04000050 RID: 80
			public bool IsFieldSet;

			// Token: 0x04000051 RID: 81
			public Instruction First;

			// Token: 0x04000052 RID: 82
			public Instruction Last;

			// Token: 0x04000053 RID: 83
			public FieldReference Field;

			// Token: 0x04000054 RID: 84
			public MethodDefinition Method;

			// Token: 0x04000055 RID: 85
			public int MaxStack;
		}

		// Token: 0x0200002E RID: 46
		private struct UpgraderInfo
		{
			// Token: 0x06000115 RID: 277 RVA: 0x0000702C File Offset: 0x0000522C
			public UpgraderInfo(Hotload.IInstanceUpgrader upgrader, Type type)
			{
				this.Upgrader = upgrader;
				this.GroupType = UpgraderGroup.GetUpgraderGroupType(type);
			}

			// Token: 0x04000056 RID: 86
			public readonly Hotload.IInstanceUpgrader Upgrader;

			// Token: 0x04000057 RID: 87
			public readonly Type GroupType;
		}

		// Token: 0x0200002F RID: 47
		private struct InstanceTask
		{
			// Token: 0x06000116 RID: 278 RVA: 0x00007041 File Offset: 0x00005241
			public InstanceTask(Hotload.IInstanceProcessor handler, object oldInstance, object newInstance, string root)
			{
				this.Handler = handler;
				this.OldInstance = oldInstance;
				this.NewInstance = newInstance;
				this.Root = root;
			}

			// Token: 0x06000117 RID: 279 RVA: 0x00007060 File Offset: 0x00005260
			public override string ToString()
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 2);
				defaultInterpolatedStringHandler.AppendFormatted<Hotload.IInstanceProcessor>(this.Handler);
				defaultInterpolatedStringHandler.AppendLiteral(": ");
				defaultInterpolatedStringHandler.AppendFormatted<object>(this.OldInstance);
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}

			// Token: 0x04000058 RID: 88
			public readonly Hotload.IInstanceProcessor Handler;

			// Token: 0x04000059 RID: 89
			public readonly object OldInstance;

			// Token: 0x0400005A RID: 90
			public readonly object NewInstance;

			// Token: 0x0400005B RID: 91
			public readonly string Root;
		}

		// Token: 0x02000030 RID: 48
		public interface IBaseCallback
		{
		}

		/// <summary>
		/// The code for this object has changed, so we created a new version of it. 
		/// </summary>
		// Token: 0x02000031 RID: 49
		public interface IBorn : Hotload.IBaseCallback
		{
			// Token: 0x06000118 RID: 280
			void HotloadBorn(object oldObject);
		}

		/// <summary>
		/// This class has changed. We've created a new instance and copied all the members across.
		/// This is the perfect callback if you're doing something in the finalizer because 
		/// </summary>
		// Token: 0x02000032 RID: 50
		public interface IKilled : Hotload.IBaseCallback
		{
			// Token: 0x06000119 RID: 281
			void HotloadKilled(object newObject);
		}

		/// <summary>
		/// Interface to implement a custom object instance upgrade process for types that match a condition.
		/// Instances of any derived types will be created and added to a <see cref="T:Sandbox.Hotload" /> instance that uses
		/// <see cref="M:Sandbox.Hotload.AddUpgraders(System.Reflection.Assembly)" /> on the declaring assembly of the derived type, unless a
		/// <see cref="T:Sandbox.Upgraders.DisableAutoCreationAttribute" /> has been specified.
		///
		/// You can configure which order <see cref="T:Sandbox.Hotload.IInstanceUpgrader" />s are queried by using <see cref="T:Sandbox.Upgraders.UpgraderGroupAttribute" />,
		/// <see cref="T:Sandbox.Upgraders.AttemptBeforeAttribute" /> and / or <see cref="T:Sandbox.Upgraders.AttemptAfterAttribute" />.
		/// </summary>
		// Token: 0x02000033 RID: 51
		public interface IInstanceUpgrader
		{
			// Token: 0x17000021 RID: 33
			// (get) Token: 0x0600011A RID: 282
			bool IsInitialized { get; }

			// Token: 0x0600011B RID: 283
			void Initialize(Hotload hotload);

			// Token: 0x0600011C RID: 284
			void HotloadStart();

			// Token: 0x0600011D RID: 285
			void HotloadComplete();

			// Token: 0x0600011E RID: 286
			void ClearCache();

			// Token: 0x0600011F RID: 287
			bool ShouldProcessType(Type type);

			// Token: 0x06000120 RID: 288
			bool TryCreateNewInstance(object oldInstance, object context, out object newInstance);

			// Token: 0x06000121 RID: 289
			bool TryUpgradeInstance(object oldInstance, object newInstance);
		}

		// Token: 0x02000034 RID: 52
		public interface IInstanceProcessor
		{
			// Token: 0x06000122 RID: 290
			int ProcessInstance(object oldInstance, object newInstance);
		}

		// Token: 0x02000035 RID: 53
		public abstract class InstanceUpgrader : Hotload.IInstanceUpgrader, Hotload.IInstanceProcessor
		{
			// Token: 0x17000022 RID: 34
			// (get) Token: 0x06000123 RID: 291 RVA: 0x000070A3 File Offset: 0x000052A3
			// (set) Token: 0x06000124 RID: 292 RVA: 0x000070AB File Offset: 0x000052AB
			private protected DefaultUpgrader DefaultUpgrader { protected get; private set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x06000125 RID: 293 RVA: 0x000070B4 File Offset: 0x000052B4
			// (set) Token: 0x06000126 RID: 294 RVA: 0x000070BC File Offset: 0x000052BC
			private protected CachedUpgrader CachedUpgrader { protected get; private set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x06000127 RID: 295 RVA: 0x000070C5 File Offset: 0x000052C5
			public bool IsInitialized
			{
				get
				{
					return this.Hotload != null;
				}
			}

			// Token: 0x06000128 RID: 296 RVA: 0x000070D0 File Offset: 0x000052D0
			void Hotload.IInstanceUpgrader.Initialize(Hotload hotload)
			{
				this.Hotload = hotload;
				this.DefaultUpgrader = hotload.GetUpgrader<DefaultUpgrader>();
				this.CachedUpgrader = hotload.GetUpgrader<CachedUpgrader>();
				this.OnInitialize();
			}

			// Token: 0x06000129 RID: 297 RVA: 0x000070F7 File Offset: 0x000052F7
			void Hotload.IInstanceUpgrader.HotloadStart()
			{
				this.OnHotloadStart();
			}

			// Token: 0x0600012A RID: 298 RVA: 0x000070FF File Offset: 0x000052FF
			void Hotload.IInstanceUpgrader.HotloadComplete()
			{
				this.OnHotloadComplete();
			}

			// Token: 0x0600012B RID: 299 RVA: 0x00007107 File Offset: 0x00005307
			void Hotload.IInstanceUpgrader.ClearCache()
			{
				this.OnClearCache();
			}

			/// <summary>
			/// A mapping of assembles to swap with new versions.
			/// </summary>
			// Token: 0x17000025 RID: 37
			// (get) Token: 0x0600012C RID: 300 RVA: 0x0000710F File Offset: 0x0000530F
			protected IReadOnlyDictionary<Assembly, Assembly> Swaps
			{
				get
				{
					return this.Hotload.Swaps;
				}
			}

			// Token: 0x0600012D RID: 301 RVA: 0x0000711C File Offset: 0x0000531C
			protected TUpgrader GetUpgrader<TUpgrader>() where TUpgrader : Hotload.IInstanceUpgrader
			{
				return this.Hotload.GetUpgrader<TUpgrader>();
			}

			// Token: 0x0600012E RID: 302 RVA: 0x00007129 File Offset: 0x00005329
			protected bool IsAssemblyIgnored(Assembly asm)
			{
				return this.Hotload.IgnoredAssemblies.Contains(asm);
			}

			/// <summary>
			/// When hotswapping this will switch types from the old assembly into the type from the new assembly.
			/// </summary>
			/// <param name="oldType">The old type.</param>
			/// <returns>The new type, or if the assembly isn't being hotswapped, returns the old type.</returns>
			// Token: 0x0600012F RID: 303 RVA: 0x0000713C File Offset: 0x0000533C
			protected Type GetNewType(Type oldType)
			{
				return this.Hotload.GetNewType(oldType) ?? oldType;
			}

			/// <summary>
			/// If we have encountered the given <paramref name="oldType" /> before, will return true. If an
			/// upgrade was required, <paramref name="newType" /> will contain the upgraded version of <paramref name="oldType" />.
			/// Otherwise, if no upgrade was necessary, <paramref name="newType" /> will be null.
			/// </summary>
			/// <param name="oldType">Old type to look up.</param>
			/// <param name="newType">If true was returned, will contain either the upgraded version of <paramref name="oldType" />,
			/// or null if no upgrade was required.</param>
			/// <returns>True if the given <paramref name="oldType" /> has been encountered before and cached.</returns>
			// Token: 0x06000130 RID: 304 RVA: 0x0000714F File Offset: 0x0000534F
			protected bool TryGetCachedNewType(Type oldType, out Type newType)
			{
				return this.Hotload.SubstituteTypeCache.TryGetValue(oldType, out newType);
			}

			/// <summary>
			/// Sets or updates which type will be cached as the upgraded form of <paramref name="oldType" />.
			/// </summary>
			/// <param name="oldType">Type to set the upgraded version of.</param>
			/// <param name="newType">Upgraded version of <paramref name="oldType" /> to set.</param>
			/// <returns>True if this is the first time <paramref name="oldType" /> has been cached.</returns>
			// Token: 0x06000131 RID: 305 RVA: 0x00007164 File Offset: 0x00005364
			protected bool UpdateCachedNewType(Type oldType, Type newType)
			{
				Type previousSubstitution;
				if (this.Hotload.SubstituteTypeCache.TryGetValue(oldType, out previousSubstitution))
				{
					this.Hotload.SubstituteTypeCache[oldType] = newType;
					return previousSubstitution == null;
				}
				this.Hotload.SubstituteTypeCache.Add(oldType, newType);
				return true;
			}

			/// <summary>
			/// Returns an upgraded version of the given object, replacing any types from a swapped-out
			/// assembly with their new up-to-date types. The result is cached, so if you pass the same
			/// object to this method multiple times it will always return the same instance. Fields inside
			/// the new instance may not be initialized until later in the hotload.
			/// </summary>
			/// <param name="oldInstance">Object to upgrade.</param>
			/// <returns>An upgraded version of the given object.</returns>
			// Token: 0x06000132 RID: 306 RVA: 0x000071B3 File Offset: 0x000053B3
			protected object GetNewInstance(object oldInstance)
			{
				return this.Hotload.GetNewInstance(oldInstance, null);
			}

			// Token: 0x06000133 RID: 307 RVA: 0x000071C2 File Offset: 0x000053C2
			protected void AddCachedInstance(object oldInstance, object newInstance)
			{
				this.CachedUpgrader.AddCachedInstance(oldInstance, newInstance);
			}

			// Token: 0x06000134 RID: 308 RVA: 0x000071D1 File Offset: 0x000053D1
			protected void SuppressFinalize(object oldInstance, object newInstance)
			{
				if (oldInstance != newInstance)
				{
					GC.SuppressFinalize(oldInstance);
				}
			}

			// Token: 0x06000135 RID: 309 RVA: 0x000071DD File Offset: 0x000053DD
			protected object GetNewInstanceFromField(object oldInstance, object context)
			{
				return this.Hotload.GetNewInstance(oldInstance, context);
			}

			// Token: 0x06000136 RID: 310 RVA: 0x000071EC File Offset: 0x000053EC
			protected bool TryGetDefaultValue(FieldInfo field, out object value)
			{
				return this.Hotload.TryGetDefaultValue(field, out value);
			}

			// Token: 0x06000137 RID: 311 RVA: 0x000071FB File Offset: 0x000053FB
			protected bool AreEquivalentTypes(Type oldType, Type newType)
			{
				return this.Hotload.AreEquivalentTypes(oldType, newType);
			}

			// Token: 0x06000138 RID: 312 RVA: 0x0000720A File Offset: 0x0000540A
			protected FieldInfo GetOldField(Type oldType, FieldInfo field, BindingFlags flags)
			{
				return this.Hotload.GetOldField(oldType, field, flags);
			}

			/// <summary>
			/// Logs a message in the current hotload.
			/// </summary>
			// Token: 0x06000139 RID: 313 RVA: 0x0000721A File Offset: 0x0000541A
			protected void Log(HotloadEntryType type, string message, MemberInfo member = null)
			{
				this.Hotload.CurrentResult.AddEntry(new HotloadResultEntry(type, message, member));
			}

			/// <summary>
			/// Logs an exception in the current hotload.
			/// </summary>
			// Token: 0x0600013A RID: 314 RVA: 0x00007234 File Offset: 0x00005434
			protected void Log(Exception exception, string message = null, MemberInfo member = null)
			{
				this.Hotload.CurrentResult.AddEntry(new HotloadResultEntry(exception, message, member));
			}

			/// <summary>
			/// Called when this upgrader has been added to a <see cref="F:Sandbox.Hotload.InstanceUpgrader.Hotload" /> instance.
			/// </summary>
			// Token: 0x0600013B RID: 315 RVA: 0x0000724E File Offset: 0x0000544E
			protected virtual void OnInitialize()
			{
			}

			// Token: 0x0600013C RID: 316 RVA: 0x00007250 File Offset: 0x00005450
			protected virtual void OnHotloadStart()
			{
			}

			// Token: 0x0600013D RID: 317 RVA: 0x00007252 File Offset: 0x00005452
			protected virtual void OnHotloadComplete()
			{
			}

			/// <summary>
			/// Called between hotloads, should clear up any cached resources that won't be needed in future hotloads.
			/// </summary>
			// Token: 0x0600013E RID: 318 RVA: 0x00007254 File Offset: 0x00005454
			protected virtual void OnClearCache()
			{
			}

			/// <summary>
			/// Check to see if this upgrader can possibly handle the given type.
			/// </summary>
			/// <param name="type">Type to upgrade an instance of.</param>
			/// <returns>True if this upgrader should attempt to upgrade an instance of the given type.</returns>
			// Token: 0x0600013F RID: 319
			public abstract bool ShouldProcessType(Type type);

			// Token: 0x06000140 RID: 320 RVA: 0x00007256 File Offset: 0x00005456
			public bool TryCreateNewInstance(object oldInstance, object context, out object newInstance)
			{
				if (!this.OnTryCreateNewInstance(oldInstance, context, out newInstance))
				{
					return false;
				}
				this.OnTryUpgradeInstance(oldInstance, newInstance, false);
				return true;
			}

			// Token: 0x06000141 RID: 321 RVA: 0x00007271 File Offset: 0x00005471
			public bool TryUpgradeInstance(object oldInstance, object newInstance)
			{
				return this.OnTryUpgradeInstance(oldInstance, newInstance, true);
			}

			// Token: 0x06000142 RID: 322 RVA: 0x00007281 File Offset: 0x00005481
			protected void ScheduleProcessInstance(object oldInstance, object newInstance)
			{
				this.Hotload.ScheduleInstanceTask(this, oldInstance, newInstance);
			}

			// Token: 0x06000143 RID: 323 RVA: 0x00007291 File Offset: 0x00005491
			protected void ScheduleLateProcessInstance(object oldInstance, object newInstance)
			{
				this.Hotload.ScheduleLateInstanceTask(this, oldInstance, newInstance);
			}

			/// <summary>
			/// If this upgrader supports upgrading the given <paramref name="oldInstance" />, returns <value>true</value> and
			/// assigns <paramref name="newInstance" /> to be the value that should replace <paramref name="oldInstance" />. This
			/// method doesn't need to copy the inner state of the instance across, but just creates an empty instance to be
			/// populated later.
			/// </summary>
			/// <remarks>
			/// <para>
			/// It's safe to just directly assign <paramref name="newInstance" /> to <paramref name="oldInstance" /> if the type
			/// isn't declared in a replaced assembly.
			/// </para>
			/// <para>
			/// Returning true will cause <see cref="M:Sandbox.Hotload.InstanceUpgrader.OnTryUpgradeInstance(System.Object,System.Object,System.Boolean)" /> to be called immediately after this method, which
			/// schedules copying the state of the old instance to the new one.
			/// </para>
			/// </remarks>
			/// <param name="oldInstance">Instance that should be replaced / upgraded.</param>
			/// <param name="context">If the instance was found in a field, this will be the containing object.</param>
			/// <param name="newInstance">
			/// If this method returns true, this should contain the instance that replaces <paramref name="oldInstance" />,
			/// or <paramref name="oldInstance" /> itself if no replacement is necessary.
			/// </param>
			/// <returns>True if this upgrader handles the replacement of the given <paramref name="oldInstance" />.</returns>
			// Token: 0x06000144 RID: 324
			protected abstract bool OnTryCreateNewInstance(object oldInstance, object context, out object newInstance);

			/// <summary>
			/// Called immediately after <see cref="M:Sandbox.Hotload.InstanceUpgrader.OnTryCreateNewInstance(System.Object,System.Object,System.Object@)" /> if it returned true, or on instances from fields
			/// that can't be re-assigned (see <see cref="P:System.Reflection.FieldInfo.IsInitOnly" />). This method determines what kind of extra
			/// processing is required for the given replacement.
			/// </summary>
			/// <remarks>
			/// <para>
			/// In this method we can call things like <see cref="M:Sandbox.Hotload.InstanceUpgrader.ProcessInstance(System.Object,System.Object)" />, <see cref="M:Sandbox.Hotload.ScheduleInstanceTask(Sandbox.Hotload.IInstanceProcessor,System.Object,System.Object)" /> or
			/// <see cref="M:Sandbox.Hotload.ScheduleLateInstanceTask(Sandbox.Hotload.IInstanceProcessor,System.Object,System.Object)" /> to handle copying values from the old instance to the new one.
			/// </para>
			/// <para>
			/// If <paramref name="newInstance" /> should be cached as the canonical replacement for <paramref name="oldInstance" />,
			/// call <see cref="M:Sandbox.Hotload.InstanceUpgrader.AddCachedInstance(System.Object,System.Object)" /> here.
			/// </para>
			/// <para>
			/// If finalization should be suppressed, call <see cref="M:Sandbox.Hotload.InstanceUpgrader.SuppressFinalize(System.Object,System.Object)" />.
			/// </para>
			/// </remarks>
			/// <param name="oldInstance">Original instance that is being replaced / upgraded from.</param>
			/// <param name="newInstance">
			/// New instance that replaces <paramref name="oldInstance" />, or <paramref name="oldInstance" /> itself if no replacement is necessary.
			/// </param>
			/// <param name="createdElsewhere">
			/// True if <paramref name="newInstance" /> was created outside of the hotloading system, for example when the
			/// containing field has <see cref="P:System.Reflection.FieldInfo.IsInitOnly" /> set to true. Otherwise, when false, <see cref="M:Sandbox.Hotload.InstanceUpgrader.OnTryCreateNewInstance(System.Object,System.Object,System.Object@)" />
			/// will have been called just before this method.
			/// </param>
			/// <returns></returns>
			// Token: 0x06000145 RID: 325
			protected abstract bool OnTryUpgradeInstance(object oldInstance, object newInstance, bool createdElsewhere);

			// Token: 0x06000146 RID: 326 RVA: 0x000072A4 File Offset: 0x000054A4
			public int ProcessInstance(object oldInstance, object newInstance)
			{
				int result;
				try
				{
					result = this.OnProcessInstance(oldInstance, newInstance);
				}
				catch (Exception e)
				{
					this.Log(e, null, oldInstance.GetType());
					result = 1;
				}
				return result;
			}

			/// <summary>
			/// Perform extra field processing on a new instance that has previously been created by this upgrader in
			/// <see cref="M:Sandbox.Hotload.InstanceUpgrader.OnTryCreateNewInstance(System.Object,System.Object,System.Object@)" />. This is a good place to discover any other instances that should be upgraded
			/// that are stored in <paramref name="oldInstance" />, which can be upgraded by calling <see cref="M:Sandbox.Hotload.InstanceUpgrader.GetNewInstance(System.Object)" />.
			/// </summary>
			/// <param name="oldInstance">The original instance that was upgraded.</param>
			/// <param name="newInstance">Upgraded version of <paramref name="oldInstance" />, or even the same object if no upgrade
			/// was required.</param>
			/// <returns>Roughly how many instances were processed by this method. Only used for performance stats.</returns>
			// Token: 0x06000147 RID: 327 RVA: 0x000072E0 File Offset: 0x000054E0
			protected virtual int OnProcessInstance(object oldInstance, object newInstance)
			{
				return 1;
			}

			// Token: 0x0400005C RID: 92
			private Hotload Hotload;
		}
	}
}
