using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Sandbox.Upgraders
{
	// Token: 0x02000018 RID: 24
	[UpgraderGroup(typeof(CollectionsUpgraderGroup), GroupOrder.Default)]
	internal class HashSetUpgrader : Hotload.InstanceUpgrader
	{
		// Token: 0x060000C1 RID: 193 RVA: 0x00005C8D File Offset: 0x00003E8D
		public override bool ShouldProcessType(Type type)
		{
			return type.IsConstructedGenericType && type.GetGenericTypeDefinition() == HashSetUpgrader.Type;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00005CAC File Offset: 0x00003EAC
		protected override bool OnTryCreateNewInstance(object oldInstance, object context, out object newInstance)
		{
			Type newType = base.GetNewType(oldInstance.GetType());
			object comparer = ComparerHelper.GetOldComparer(oldInstance);
			newInstance = Activator.CreateInstance(newType, new object[] { base.GetNewInstance(comparer) });
			return true;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00005CE8 File Offset: 0x00003EE8
		protected override bool OnTryUpgradeInstance(object oldInstance, object newInstance, bool createdElsewhere)
		{
			base.AddCachedInstance(oldInstance, newInstance);
			base.SuppressFinalize(oldInstance, newInstance);
			foreach (object oldItem in ((IEnumerable)oldInstance))
			{
				base.GetNewInstance(oldItem);
			}
			base.ScheduleLateProcessInstance(oldInstance, newInstance);
			return true;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00005D58 File Offset: 0x00003F58
		protected override int OnProcessInstance(object oldInstance, object newInstance)
		{
			Type newType = newInstance.GetType();
			Type elementType = newType.GetGenericArguments()[0];
			Type[] paramTypes = new Type[] { elementType };
			MethodInfo addMethod = newType.GetMethod("Add", paramTypes);
			object[] args = new object[1];
			foreach (object oldItem in ((IEnumerable)oldInstance))
			{
				object newItem = base.GetNewInstance(oldItem);
				args[0] = newItem;
				if (!(bool)addMethod.Invoke(newInstance, args))
				{
					HotloadEntryType type = HotloadEntryType.Error;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(51, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Duplicate value (");
					defaultInterpolatedStringHandler.AppendFormatted<object>(newItem);
					defaultInterpolatedStringHandler.AppendLiteral(") skipped during hash set upgrade.");
					base.Log(type, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				}
			}
			return 1;
		}

		// Token: 0x04000039 RID: 57
		private static readonly Type Type = typeof(HashSet<>);
	}
}
