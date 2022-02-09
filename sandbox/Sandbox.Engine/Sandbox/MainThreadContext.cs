using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x020002DD RID: 733
	internal class MainThreadContext : SynchronizationContext
	{
		/// <summary>
		/// Current <see cref="T:Sandbox.MainThreadContext" />. This will be null until <see cref="M:Sandbox.MainThreadContext.Init" /> has been
		/// called for the first time.
		/// </summary>
		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06001351 RID: 4945 RVA: 0x00027B4C File Offset: 0x00025D4C
		// (set) Token: 0x06001352 RID: 4946 RVA: 0x00027B53 File Offset: 0x00025D53
		public static MainThreadContext Instance { get; private set; }

		/// <summary>
		/// Sets both <see cref="P:Sandbox.MainThreadContext.Instance" /> and <see cref="P:System.Threading.SynchronizationContext.Current" /> to be a new
		/// instance of <see cref="T:Sandbox.MainThreadContext" />. Only has an effect the first time it's called.
		/// </summary>
		// Token: 0x06001353 RID: 4947 RVA: 0x00027B5B File Offset: 0x00025D5B
		public static void Init()
		{
			if (MainThreadContext.Instance != null)
			{
				return;
			}
			MainThreadContext.Instance = new MainThreadContext();
			SynchronizationContext.SetSynchronizationContext(MainThreadContext.Instance);
		}

		/// <summary>
		/// Invalidates <see cref="P:Sandbox.MainThreadContext.Instance" />, and replaces it with a new instance.
		/// Any tasks that try to continue on the old instance will log an error, unless they
		/// are whitelisted with <see cref="M:Sandbox.MainThreadContext.AllowPersistentTaskMethod(System.Type,System.String)" />.
		/// </summary>
		// Token: 0x06001354 RID: 4948 RVA: 0x00027B7C File Offset: 0x00025D7C
		public static void Reset()
		{
			MainThreadContext oldInstance = MainThreadContext.Instance;
			MainThreadContext.Instance = new MainThreadContext();
			if (SynchronizationContext.Current == oldInstance)
			{
				SynchronizationContext.SetSynchronizationContext(MainThreadContext.Instance);
			}
			if (oldInstance != null)
			{
				oldInstance.Expire(MainThreadContext.Instance);
			}
			MainThreadContext.Instance.ProcessQueue();
		}

		// Token: 0x06001355 RID: 4949 RVA: 0x00027BC3 File Offset: 0x00025DC3
		public static void AllowPersistentTaskMethods(Assembly asm)
		{
			MainThreadContext.PersistentTaskAssemblies.Add(asm);
		}

		/// <summary>
		/// Allows any task methods declared by <paramref name="declaringType" /> to persist after
		/// calls to <see cref="M:Sandbox.MainThreadContext.Reset" />.
		/// </summary>
		// Token: 0x06001356 RID: 4950 RVA: 0x00027BD1 File Offset: 0x00025DD1
		public static void AllowPersistentTaskMethods(Type declaringType)
		{
			MainThreadContext.PersistentTaskDeclaringTypes.Add(declaringType);
		}

		/// <summary>
		/// Allows any task methods declared by <paramref name="declaringType" /> with the name
		/// <paramref name="methodName" /> to persist after calls to <see cref="M:Sandbox.MainThreadContext.Reset" />.
		/// </summary>
		// Token: 0x06001357 RID: 4951 RVA: 0x00027BE0 File Offset: 0x00025DE0
		public static void AllowPersistentTaskMethod(Type declaringType, string methodName)
		{
			HashSet<string> methodNames;
			if (!MainThreadContext.PersistentTaskMethods.TryGetValue(declaringType, out methodNames))
			{
				methodNames = new HashSet<string>();
				MainThreadContext.PersistentTaskMethods.Add(declaringType, methodNames);
			}
			methodNames.Add(methodName);
		}

		/// <summary>
		/// When true, any continuations that attempt to run on this instance will
		/// log an exception, unless whitelisted by <see cref="M:Sandbox.MainThreadContext.AllowPersistentTaskMethod(System.Type,System.String)" />.
		/// </summary>
		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06001358 RID: 4952 RVA: 0x00027C16 File Offset: 0x00025E16
		// (set) Token: 0x06001359 RID: 4953 RVA: 0x00027C1E File Offset: 0x00025E1E
		internal bool HasExpired { get; private set; }

		// Token: 0x0600135A RID: 4954 RVA: 0x00027C27 File Offset: 0x00025E27
		public MainThreadContext()
		{
			base.SetWaitNotificationRequired();
		}

		// Token: 0x0600135B RID: 4955 RVA: 0x00027C4B File Offset: 0x00025E4B
		public override SynchronizationContext CreateCopy()
		{
			return new MainThreadContext();
		}

		// Token: 0x0600135C RID: 4956 RVA: 0x00027C52 File Offset: 0x00025E52
		private static IEnumerable<Task> GetAwaitedTasks(IAsyncStateMachine stateMachine)
		{
			Type type = ((stateMachine != null) ? stateMachine.GetType() : null);
			while (type != null)
			{
				foreach (FieldInfo field in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
				{
					if (field.Name.StartsWith("<>u__"))
					{
						FieldInfo taskField;
						if (field.FieldType == typeof(TaskAwaiter))
						{
							taskField = MainThreadContext.AwaiterTaskField;
						}
						else
						{
							if (!field.FieldType.IsConstructedGenericType || !(field.FieldType.GetGenericTypeDefinition() == typeof(TaskAwaiter<>)))
							{
								goto IL_10B;
							}
							taskField = field.FieldType.GetField("m_task", BindingFlags.Instance | BindingFlags.NonPublic);
						}
						object awaiter = field.GetValue(stateMachine);
						Task task = taskField.GetValue(awaiter) as Task;
						if (task != null)
						{
							yield return task;
						}
					}
					IL_10B:;
				}
				FieldInfo[] array = null;
				type = type.BaseType;
			}
			yield break;
		}

		// Token: 0x0600135D RID: 4957 RVA: 0x00027C64 File Offset: 0x00025E64
		private static IAsyncStateMachine GetStateMachine(object obj)
		{
			while (obj != null)
			{
				Action action = obj as Action;
				if (action != null)
				{
					obj = action.Target;
				}
				else
				{
					Type type = obj.GetType();
					string fullName = type.FullName;
					if (!(fullName == "System.Threading.Tasks.SynchronizationContextAwaitTaskContinuation+<>c__DisplayClass6_0"))
					{
						if (!(fullName == "System.Runtime.CompilerServices.AsyncMethodBuilderCore+ContinuationWrapper"))
						{
							if (!(obj is Task))
							{
								return null;
							}
							FieldInfo field = type.GetField("StateMachine", BindingFlags.Instance | BindingFlags.Public);
							return ((field != null) ? field.GetValue(obj) : null) as IAsyncStateMachine;
						}
						else
						{
							obj = type.GetField("_continuation", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(obj);
						}
					}
					else
					{
						obj = type.GetField("action", BindingFlags.Instance | BindingFlags.Public).GetValue(obj);
					}
				}
			}
			return null;
		}

		// Token: 0x0600135E RID: 4958 RVA: 0x00027D0C File Offset: 0x00025F0C
		private static bool TryGetStateMachineInfo(object state, out IAsyncStateMachine stateMachine, out Type declaringType, out string methodName)
		{
			declaringType = null;
			methodName = null;
			stateMachine = MainThreadContext.GetStateMachine(state);
			if (stateMachine == null)
			{
				return false;
			}
			Type stateMachineType = stateMachine.GetType();
			declaringType = stateMachineType.DeclaringType;
			Match match = MainThreadContext.StateMachineMethodNameRegex.Match(stateMachineType.Name);
			if (match.Success)
			{
				methodName = match.Groups["name"].Value;
			}
			return true;
		}

		// Token: 0x0600135F RID: 4959 RVA: 0x00027D70 File Offset: 0x00025F70
		private static bool CanTaskMethodPersist(Type declaringType, string methodName)
		{
			if (MainThreadContext.PersistentTaskAssemblies.Contains(declaringType.Assembly))
			{
				return true;
			}
			if (declaringType.Assembly.GetCustomAttribute<TasksPersistOnContextResetAttribute>() != null)
			{
				MainThreadContext.PersistentTaskAssemblies.Add(declaringType.Assembly);
				return true;
			}
			if (MainThreadContext.PersistentTaskDeclaringTypes.Contains(declaringType))
			{
				return true;
			}
			HashSet<string> methodSet;
			if (MainThreadContext.PersistentTaskMethods.TryGetValue(declaringType, out methodSet) && methodSet.Contains(methodName))
			{
				return true;
			}
			if (declaringType.IsConstructedGenericType)
			{
				Type genericTypeDef = declaringType.GetGenericTypeDefinition();
				if (MainThreadContext.PersistentTaskDeclaringTypes.Contains(genericTypeDef))
				{
					return true;
				}
				HashSet<string> methodSet2;
				if (MainThreadContext.PersistentTaskMethods.TryGetValue(genericTypeDef, out methodSet2) && methodSet2.Contains(methodName))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001360 RID: 4960 RVA: 0x00027E14 File Offset: 0x00026014
		private static bool IsAwaitingCancelledTask(IAsyncStateMachine stateMachine)
		{
			Task[] awaited = MainThreadContext.GetAwaitedTasks(stateMachine).ToArray<Task>();
			Assert.True(awaited.Length <= 1);
			return awaited.Length == 1 && awaited[0].IsCanceled;
		}

		// Token: 0x06001361 RID: 4961 RVA: 0x00027E4B File Offset: 0x0002604B
		private bool CanHandleCancellation(IAsyncStateMachine stateMachine)
		{
			return this.CancelledStateMachines.Count < 256 && this.CancelledStateMachines.Add(stateMachine);
		}

		/// <summary>
		/// Returns true if <see cref="P:Sandbox.MainThreadContext.HasExpired" /> is false, or if <paramref name="state" /> represents
		/// a task method that is allowed to persist after context expiry. Logs an error otherwise.
		/// </summary>
		// Token: 0x06001362 RID: 4962 RVA: 0x00027E70 File Offset: 0x00026070
		private bool CheckValid(object state, out bool cancelled)
		{
			cancelled = false;
			if (!this.HasExpired)
			{
				return true;
			}
			string methodInfo = string.Empty;
			IAsyncStateMachine stateMachine;
			Type declaringType;
			string taskMethodName;
			if (MainThreadContext.TryGetStateMachineInfo(state, out stateMachine, out declaringType, out taskMethodName))
			{
				if (MainThreadContext.CanTaskMethodPersist(declaringType, taskMethodName))
				{
					return true;
				}
				if (MainThreadContext.IsAwaitingCancelledTask(stateMachine) && this.CanHandleCancellation(stateMachine))
				{
					cancelled = true;
					return true;
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 2);
				defaultInterpolatedStringHandler.AppendLiteral(" in task method ");
				defaultInterpolatedStringHandler.AppendFormatted<Type>(declaringType);
				defaultInterpolatedStringHandler.AppendLiteral(".");
				defaultInterpolatedStringHandler.AppendFormatted(taskMethodName);
				methodInfo = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			GlobalSystemNamespace.Log.Error("Attempted to use an expired MainThreadContext" + methodInfo + "\nThis is probably because a task was left running after ending a game session");
			return false;
		}

		// Token: 0x06001363 RID: 4963 RVA: 0x00027F14 File Offset: 0x00026114
		public override void Send(SendOrPostCallback d, object state)
		{
			bool flag;
			if (!this.CheckValid(state, out flag))
			{
				return;
			}
			d(state);
		}

		// Token: 0x06001364 RID: 4964 RVA: 0x00027F34 File Offset: 0x00026134
		public override void Post(SendOrPostCallback d, object state)
		{
			bool cancelled;
			if (!this.CheckValid(state, out cancelled))
			{
				return;
			}
			MainThreadContext target = (this.HasExpired ? MainThreadContext.Instance : this);
			MainThreadContext.Data data = new MainThreadContext.Data(d, state, cancelled ? this : target);
			target.m_queue.Writer.TryWrite(data);
		}

		// Token: 0x06001365 RID: 4965 RVA: 0x00027F80 File Offset: 0x00026180
		private void Expire(MainThreadContext newInstance)
		{
			this.HasExpired = true;
			MainThreadContext.Data data;
			while (this.m_queue.Reader.TryRead(out data))
			{
				bool cancelled;
				if (this.CheckValid(data.State, out cancelled))
				{
					newInstance.m_queue.Writer.TryWrite(new MainThreadContext.Data(data.Callback, data.State, cancelled ? this : newInstance));
				}
			}
		}

		// Token: 0x06001366 RID: 4966 RVA: 0x00027FE8 File Offset: 0x000261E8
		public void ProcessQueue()
		{
			if (this.HasExpired)
			{
				throw new Exception("Attempted to call ProcessQueue on an expired MainThreadContext.");
			}
			if (this.inside)
			{
				return;
			}
			if (this.m_queue.Reader.Count == 0)
			{
				return;
			}
			int maxProcess = this.m_queue.Reader.Count + 8;
			SynchronizationContext oldContext = SynchronizationContext.Current;
			SynchronizationContext.SetSynchronizationContext(this);
			this.Frame++;
			try
			{
				this.inside = true;
				MainThreadContext.Data data;
				while (this.m_queue.Reader.TryRead(out data))
				{
					if (data.Source == this)
					{
						data.Callback(data.State);
					}
					else
					{
						SynchronizationContext.SetSynchronizationContext(data.Source);
						try
						{
							data.Callback(data.State);
						}
						finally
						{
							SynchronizationContext.SetSynchronizationContext(this);
						}
					}
					maxProcess--;
					if (maxProcess <= 0)
					{
						break;
					}
				}
			}
			finally
			{
				this.inside = false;
				SynchronizationContext.SetSynchronizationContext(oldContext);
			}
		}

		// Token: 0x06001367 RID: 4967 RVA: 0x000280E8 File Offset: 0x000262E8
		public override int Wait(IntPtr[] waitHandles, bool waitAll, int millisecondsTimeout)
		{
			int totalWait = 0;
			int val;
			for (;;)
			{
				val = base.Wait(waitHandles, waitAll, 2);
				if (val != 258)
				{
					break;
				}
				totalWait += 2;
				if (millisecondsTimeout > 0 && totalWait <= millisecondsTimeout)
				{
					return val;
				}
				this.ProcessQueue();
			}
			return val;
		}

		// Token: 0x040014DE RID: 5342
		internal static MainThreadContext PhysicsThinkServer = new MainThreadContext();

		// Token: 0x040014DF RID: 5343
		internal static MainThreadContext PhysicsThinkClient = new MainThreadContext();

		// Token: 0x040014E0 RID: 5344
		private static readonly HashSet<Assembly> PersistentTaskAssemblies = new HashSet<Assembly>();

		// Token: 0x040014E1 RID: 5345
		private static readonly HashSet<Type> PersistentTaskDeclaringTypes = new HashSet<Type>();

		// Token: 0x040014E2 RID: 5346
		private static readonly Dictionary<Type, HashSet<string>> PersistentTaskMethods = new Dictionary<Type, HashSet<string>>();

		// Token: 0x040014E3 RID: 5347
		private readonly HashSet<IAsyncStateMachine> CancelledStateMachines = new HashSet<IAsyncStateMachine>();

		// Token: 0x040014E4 RID: 5348
		internal int Frame;

		// Token: 0x040014E6 RID: 5350
		private readonly Channel<MainThreadContext.Data> m_queue = Channel.CreateUnbounded<MainThreadContext.Data>();

		// Token: 0x040014E7 RID: 5351
		private static FieldInfo AwaiterTaskField = typeof(TaskAwaiter).GetField("m_task", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040014E8 RID: 5352
		private static readonly Regex StateMachineMethodNameRegex = new Regex("^<(?<name>[^>]+)>d__[0-9]+(`[0-9]+)?$");

		// Token: 0x040014E9 RID: 5353
		private const int MaxCancellationCount = 256;

		// Token: 0x040014EA RID: 5354
		private bool inside;

		// Token: 0x02000420 RID: 1056
		public struct Data : IEquatable<MainThreadContext.Data>
		{
			// Token: 0x0600182E RID: 6190 RVA: 0x000386AB File Offset: 0x000368AB
			public Data(SendOrPostCallback Callback, object State, MainThreadContext Source)
			{
				this.Callback = Callback;
				this.State = State;
				this.Source = Source;
			}

			// Token: 0x170004A2 RID: 1186
			// (get) Token: 0x0600182F RID: 6191 RVA: 0x000386C2 File Offset: 0x000368C2
			// (set) Token: 0x06001830 RID: 6192 RVA: 0x000386CA File Offset: 0x000368CA
			public SendOrPostCallback Callback { readonly get; set; }

			// Token: 0x170004A3 RID: 1187
			// (get) Token: 0x06001831 RID: 6193 RVA: 0x000386D3 File Offset: 0x000368D3
			// (set) Token: 0x06001832 RID: 6194 RVA: 0x000386DB File Offset: 0x000368DB
			public object State { readonly get; set; }

			// Token: 0x170004A4 RID: 1188
			// (get) Token: 0x06001833 RID: 6195 RVA: 0x000386E4 File Offset: 0x000368E4
			// (set) Token: 0x06001834 RID: 6196 RVA: 0x000386EC File Offset: 0x000368EC
			public MainThreadContext Source { readonly get; set; }

			// Token: 0x06001835 RID: 6197 RVA: 0x000386F8 File Offset: 0x000368F8
			public override readonly string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("Data");
				stringBuilder.Append(" { ");
				if (this.PrintMembers(stringBuilder))
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append('}');
				return stringBuilder.ToString();
			}

			// Token: 0x06001836 RID: 6198 RVA: 0x00038744 File Offset: 0x00036944
			private readonly bool PrintMembers(StringBuilder builder)
			{
				builder.Append("Callback = ");
				builder.Append(this.Callback);
				builder.Append(", State = ");
				builder.Append(this.State);
				builder.Append(", Source = ");
				builder.Append(this.Source);
				return true;
			}

			// Token: 0x06001837 RID: 6199 RVA: 0x0003879D File Offset: 0x0003699D
			public static bool operator !=(MainThreadContext.Data left, MainThreadContext.Data right)
			{
				return !(left == right);
			}

			// Token: 0x06001838 RID: 6200 RVA: 0x000387A9 File Offset: 0x000369A9
			public static bool operator ==(MainThreadContext.Data left, MainThreadContext.Data right)
			{
				return left.Equals(right);
			}

			// Token: 0x06001839 RID: 6201 RVA: 0x000387B3 File Offset: 0x000369B3
			public override readonly int GetHashCode()
			{
				return (EqualityComparer<SendOrPostCallback>.Default.GetHashCode(this.<Callback>k__BackingField) * -1521134295 + EqualityComparer<object>.Default.GetHashCode(this.<State>k__BackingField)) * -1521134295 + EqualityComparer<MainThreadContext>.Default.GetHashCode(this.<Source>k__BackingField);
			}

			// Token: 0x0600183A RID: 6202 RVA: 0x000387F3 File Offset: 0x000369F3
			public override readonly bool Equals(object obj)
			{
				return obj is MainThreadContext.Data && this.Equals((MainThreadContext.Data)obj);
			}

			// Token: 0x0600183B RID: 6203 RVA: 0x0003880C File Offset: 0x00036A0C
			public readonly bool Equals(MainThreadContext.Data other)
			{
				return EqualityComparer<SendOrPostCallback>.Default.Equals(this.<Callback>k__BackingField, other.<Callback>k__BackingField) && EqualityComparer<object>.Default.Equals(this.<State>k__BackingField, other.<State>k__BackingField) && EqualityComparer<MainThreadContext>.Default.Equals(this.<Source>k__BackingField, other.<Source>k__BackingField);
			}

			// Token: 0x0600183C RID: 6204 RVA: 0x00038861 File Offset: 0x00036A61
			public readonly void Deconstruct(out SendOrPostCallback Callback, out object State, out MainThreadContext Source)
			{
				Callback = this.Callback;
				State = this.State;
				Source = this.Source;
			}
		}
	}
}
