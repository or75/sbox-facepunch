using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Sandbox.Upgraders
{
	// Token: 0x02000029 RID: 41
	[UpgraderGroup(typeof(ReferenceTypeUpgraderGroup), GroupOrder.Default)]
	internal class ConditionalWeakTableUpgrader : Hotload.InstanceUpgrader
	{
		// Token: 0x0600010A RID: 266 RVA: 0x00006E54 File Offset: 0x00005054
		public override bool ShouldProcessType(Type type)
		{
			return type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof(ConditionalWeakTable<, >);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00006E78 File Offset: 0x00005078
		protected override bool OnTryCreateNewInstance(object oldInstance, object context, out object newInstance)
		{
			Type oldType = oldInstance.GetType();
			Type newType = base.GetNewType(oldType);
			newInstance = Activator.CreateInstance(newType);
			return true;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00006E9D File Offset: 0x0000509D
		protected override bool OnTryUpgradeInstance(object oldInstance, object newInstance, bool createdElsewhere)
		{
			base.AddCachedInstance(oldInstance, newInstance);
			base.ScheduleProcessInstance(oldInstance, newInstance);
			return true;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00006EB0 File Offset: 0x000050B0
		protected override int OnProcessInstance(object oldInstance, object newInstance)
		{
			Type type = oldInstance.GetType();
			Type newType = newInstance.GetType();
			Type oldKeyType = type.GetGenericArguments()[0];
			Type oldValueType = type.GetGenericArguments()[1];
			Type type2 = typeof(KeyValuePair<, >).MakeGenericType(new Type[] { oldKeyType, oldValueType });
			PropertyInfo oldKeyProperty = type2.GetProperty("Key", BindingFlags.Instance | BindingFlags.Public);
			PropertyInfo oldValueProperty = type2.GetProperty("Value", BindingFlags.Instance | BindingFlags.Public);
			MethodInfo tryGetValueMethod = newType.GetMethod("TryGetValue", BindingFlags.Instance | BindingFlags.Public);
			MethodInfo addMethod = newType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
			IEnumerable enumerable = (IEnumerable)oldInstance;
			object[] args = new object[2];
			foreach (object element in enumerable)
			{
				object oldKey = oldKeyProperty.GetValue(element);
				object oldValue = oldValueProperty.GetValue(element);
				object newKey = base.GetNewInstance(oldKey);
				args[0] = newKey;
				if ((bool)tryGetValueMethod.Invoke(newInstance, args))
				{
					HotloadEntryType type3 = HotloadEntryType.Error;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(62, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Duplicate key (");
					defaultInterpolatedStringHandler.AppendFormatted<object>(newKey);
					defaultInterpolatedStringHandler.AppendLiteral(") skipped during conditional weak table upgrade");
					base.Log(type3, defaultInterpolatedStringHandler.ToStringAndClear(), null);
				}
				else
				{
					args[1] = base.GetNewInstance(oldValue);
					addMethod.Invoke(newInstance, args);
				}
			}
			return 1;
		}
	}
}
