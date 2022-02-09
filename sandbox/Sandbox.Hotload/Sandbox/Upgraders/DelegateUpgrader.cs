using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Sandbox.Upgraders
{
	// Token: 0x02000015 RID: 21
	[UpgraderGroup(typeof(ReferenceTypeUpgraderGroup), GroupOrder.Default)]
	internal class DelegateUpgrader : Hotload.InstanceUpgrader
	{
		// Token: 0x060000AE RID: 174 RVA: 0x00005588 File Offset: 0x00003788
		public override bool ShouldProcessType(Type type)
		{
			return typeof(Delegate).IsAssignableFrom(type);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000559A File Offset: 0x0000379A
		public static bool IsCompilerGenerated(MethodInfo method)
		{
			return DelegateUpgrader._sMethodNameRegex.IsMatch(method.Name);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000055AC File Offset: 0x000037AC
		public static bool IsCompilerGenerated(Type type)
		{
			return type.GetTypeInfo().GetCustomAttribute<CompilerGeneratedAttribute>() != null;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000055BC File Offset: 0x000037BC
		private static bool GetLambdaMethodInfo(MethodInfo lambda, out string contextName, out int index)
		{
			contextName = null;
			index = -1;
			Match match = DelegateUpgrader._sMethodNameRegex.Match(lambda.Name);
			if (!match.Success)
			{
				return false;
			}
			contextName = match.Groups["methodName"].Value;
			int x = int.Parse(match.Groups["x"].Value);
			index = (match.Groups["index"].Success ? int.Parse(match.Groups["index"].Value) : x);
			return true;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00005654 File Offset: 0x00003854
		private MethodInfo FindMatchingLambdaMethod(Type newType, string contextName, int index)
		{
			foreach (MethodInfo method in newType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				string nestedContextName;
				int nestedIndex;
				if (DelegateUpgrader.GetLambdaMethodInfo(method, out nestedContextName, out nestedIndex) && !(nestedContextName != contextName) && nestedIndex == index)
				{
					return method;
				}
			}
			return null;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000569C File Offset: 0x0000389C
		private void FindUncapturedValues(MethodInfo oldMethod, MethodInfo newMethod)
		{
			if (!DelegateUpgrader.IsCompilerGenerated(newMethod.DeclaringType))
			{
				return;
			}
			foreach (FieldInfo fieldInfo in newMethod.DeclaringType.GetFields(BindingFlags.Instance | BindingFlags.Public))
			{
				if (!(oldMethod.DeclaringType.GetField(fieldInfo.Name) != null))
				{
					base.Log(HotloadEntryType.Warning, "Unable to retroactively capture value used by closure.", fieldInfo);
				}
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00005700 File Offset: 0x00003900
		private MethodInfo FindMatchingLambdaMethod(MethodInfo old)
		{
			object cached;
			if (base.CachedUpgrader.TryGetCachedInstance(old, out cached))
			{
				return (MethodInfo)cached;
			}
			string contextName;
			int index;
			if (!DelegateUpgrader.GetLambdaMethodInfo(old, out contextName, out index))
			{
				return null;
			}
			Type oldDeclaringType = old.DeclaringType;
			while (!(oldDeclaringType == null))
			{
				if (DelegateUpgrader.IsCompilerGenerated(oldDeclaringType))
				{
					oldDeclaringType = oldDeclaringType.DeclaringType;
				}
				else
				{
					Type newDelaringType = base.GetNewType(oldDeclaringType);
					if (newDelaringType == oldDeclaringType)
					{
						return null;
					}
					Type subType;
					if (!base.TryGetCachedNewType(old.DeclaringType, out subType) || !(subType != null))
					{
						foreach (Type nestedType in newDelaringType.GetNestedTypes(BindingFlags.NonPublic).Concat(new Type[] { newDelaringType }))
						{
							MethodInfo method = this.FindMatchingLambdaMethod(nestedType, contextName, index);
							if (!(method == null))
							{
								Type oldSubType;
								if (base.TryGetCachedNewType(old.DeclaringType, out oldSubType) && oldSubType != null)
								{
									base.Log(HotloadEntryType.Error, "Multiple substitutions found for the same lambda capture type.", null);
								}
								base.UpdateCachedNewType(old.DeclaringType, method.DeclaringType);
								this.FindUncapturedValues(old, method);
								base.CachedUpgrader.AddCachedInstance(old, method);
								return method;
							}
						}
						base.CachedUpgrader.AddCachedInstance(old, null);
						return null;
					}
					MethodInfo method2 = this.FindMatchingLambdaMethod(subType, contextName, index);
					if (method2 == null)
					{
						base.Log(HotloadEntryType.Error, "Lambda capture type was substituted incorrectly.", null);
						return null;
					}
					this.FindUncapturedValues(old, method2);
					base.CachedUpgrader.AddCachedInstance(old, method2);
					return method2;
				}
			}
			return null;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00005894 File Offset: 0x00003A94
		public bool DeclaringAssemblyHasChanged(MethodInfo method, object target)
		{
			return base.Swaps.ContainsKey(method.DeclaringType.GetTypeInfo().Assembly) || (target != null && base.Swaps.ContainsKey(target.GetType().GetTypeInfo().Assembly));
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000058E0 File Offset: 0x00003AE0
		protected override bool OnTryCreateNewInstance(object oldInstance, object context, out object newInstance)
		{
			newInstance = null;
			Delegate oldInst = oldInstance as Delegate;
			if (oldInst == null)
			{
				return false;
			}
			Delegate[] invocList = oldInst.GetInvocationList();
			if (invocList.Length > 1)
			{
				Delegate[] newInvocList = invocList.Select(new Func<Delegate, object>(base.GetNewInstance)).Cast<Delegate>().ToArray<Delegate>();
				newInstance = Delegate.Combine(newInvocList);
				return true;
			}
			MethodInfo oldMethod = oldInst.GetMethodInfo();
			if (((oldMethod != null) ? oldMethod.DeclaringType : null) == null)
			{
				return false;
			}
			object oldTarget = oldInst.Target;
			MethodInfo newMethod;
			object newTarget;
			if (oldTarget != null && DelegateUpgrader.IsCompilerGenerated(oldMethod) && this.DeclaringAssemblyHasChanged(oldMethod, oldTarget))
			{
				newMethod = this.FindMatchingLambdaMethod(oldMethod);
				if (newMethod == null)
				{
					base.Log(HotloadEntryType.Error, "Unable to find matching substitution for a lambda method.", oldMethod);
					return true;
				}
				Type oldType = oldTarget.GetType();
				Type newType = base.GetNewType(oldType);
				if (newType == oldType)
				{
					newType = newMethod.DeclaringType;
				}
				Type substituteType = ((oldType.FullName != newType.FullName) ? newType : null);
				object srcTarget = ((context != null && context.GetType().FullName == newType.FullName) ? context : oldTarget);
				if (substituteType == null || !base.DefaultUpgrader.TryCreateNewInstance(srcTarget, substituteType, out newTarget))
				{
					newTarget = base.GetNewInstance(srcTarget);
				}
			}
			else
			{
				newTarget = base.GetNewInstance(oldInst.Target);
				newMethod = (MethodInfo)base.GetNewInstance(oldMethod);
			}
			if (newMethod == oldMethod && newTarget == oldTarget)
			{
				newInstance = oldInstance;
				return true;
			}
			Type delegType = base.GetNewType(oldInst.GetType());
			try
			{
				newInstance = ((newTarget == null) ? newMethod.CreateDelegate(delegType) : newMethod.CreateDelegate(delegType, newTarget));
			}
			catch (Exception e)
			{
				base.Log(e, "Could not bind method to type " + delegType.AssemblyQualifiedName, newMethod);
			}
			return true;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00005AAC File Offset: 0x00003CAC
		protected override bool OnTryUpgradeInstance(object oldInstance, object newInstance, bool createdElsewhere)
		{
			base.AddCachedInstance(oldInstance, newInstance);
			return true;
		}

		// Token: 0x04000037 RID: 55
		private static readonly Regex _sMethodNameRegex = new Regex("^<(?<methodName>[^>]+)>b__(?<x>[0-9]+)(_(?<index>[0-9]+))?$", RegexOptions.Compiled);
	}
}
