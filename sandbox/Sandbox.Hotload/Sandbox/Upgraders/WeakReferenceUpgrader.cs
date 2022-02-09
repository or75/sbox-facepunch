using System;
using System.Reflection;

namespace Sandbox.Upgraders
{
	// Token: 0x02000028 RID: 40
	[UpgraderGroup(typeof(ReferenceTypeUpgraderGroup), GroupOrder.Default)]
	internal class WeakReferenceUpgrader : Hotload.InstanceUpgrader
	{
		// Token: 0x06000105 RID: 261 RVA: 0x00006CDF File Offset: 0x00004EDF
		public override bool ShouldProcessType(Type type)
		{
			return type == typeof(WeakReference) || (type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(WeakReference<>));
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00006D14 File Offset: 0x00004F14
		protected override bool OnTryCreateNewInstance(object oldInstance, object context, out object newInstance)
		{
			if (oldInstance is WeakReference)
			{
				newInstance = oldInstance;
				return true;
			}
			newInstance = null;
			Type oldType = oldInstance.GetType();
			Type newType = base.GetNewType(oldType);
			if (!newType.IsConstructedGenericType || newType.GetGenericTypeDefinition() != typeof(WeakReference<>))
			{
				return false;
			}
			MethodInfo tryGetTargetMethod = oldType.GetMethod("TryGetTarget", BindingFlags.Instance | BindingFlags.Public);
			if (tryGetTargetMethod == null)
			{
				return false;
			}
			object[] args = new object[1];
			if (!(bool)tryGetTargetMethod.Invoke(oldInstance, args) || args[0] == null)
			{
				if (newType == oldType)
				{
					newInstance = oldInstance;
					return true;
				}
				args[0] = null;
				newInstance = Activator.CreateInstance(newType, args);
				return true;
			}
			else
			{
				args[0] = base.GetNewInstance(args[0]);
				if (newType == oldType)
				{
					newType.GetMethod("SetTarget", BindingFlags.Instance | BindingFlags.Public).Invoke(oldInstance, args);
					newInstance = oldInstance;
					return true;
				}
				newInstance = Activator.CreateInstance(newType, args);
				return true;
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00006DEB File Offset: 0x00004FEB
		protected override bool OnTryUpgradeInstance(object oldInstance, object newInstance, bool createdElsewhere)
		{
			base.AddCachedInstance(oldInstance, newInstance);
			if (oldInstance is WeakReference)
			{
				base.ScheduleProcessInstance(oldInstance, newInstance);
				return true;
			}
			return true;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00006E08 File Offset: 0x00005008
		protected override int OnProcessInstance(object oldInstance, object newInstance)
		{
			if (oldInstance == newInstance)
			{
				WeakReference weakRef = oldInstance as WeakReference;
				if (weakRef != null)
				{
					if (!weakRef.IsAlive)
					{
						return 1;
					}
					if (weakRef.Target == null)
					{
						return 1;
					}
					weakRef.Target = base.GetNewInstance(weakRef.Target);
					return 1;
				}
			}
			return 0;
		}
	}
}
