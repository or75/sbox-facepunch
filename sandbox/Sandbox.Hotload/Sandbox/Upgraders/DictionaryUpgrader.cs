using System;
using System.Collections;
using System.Collections.Generic;

namespace Sandbox.Upgraders
{
	// Token: 0x02000017 RID: 23
	[UpgraderGroup(typeof(CollectionsUpgraderGroup), GroupOrder.Default)]
	internal class DictionaryUpgrader : Hotload.InstanceUpgrader
	{
		// Token: 0x060000BB RID: 187 RVA: 0x00005AEB File Offset: 0x00003CEB
		public override bool ShouldProcessType(Type type)
		{
			return type.IsConstructedGenericType && type.GetGenericTypeDefinition() == DictionaryUpgrader.Type;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00005B08 File Offset: 0x00003D08
		protected override bool OnTryCreateNewInstance(object oldInstance, object context, out object newInstance)
		{
			Type oldType = oldInstance.GetType();
			Type newType = base.GetNewType(oldType);
			object comparer = ComparerHelper.GetOldComparer((IDictionary)oldInstance);
			newInstance = Activator.CreateInstance(newType, new object[] { base.GetNewInstance(comparer) });
			return true;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00005B4C File Offset: 0x00003D4C
		protected override bool OnTryUpgradeInstance(object oldInstance, object newInstance, bool createdElsewhere)
		{
			base.AddCachedInstance(oldInstance, newInstance);
			base.SuppressFinalize(oldInstance, newInstance);
			foreach (object obj in ((IDictionary)oldInstance))
			{
				base.GetNewInstance(((DictionaryEntry)obj).Key);
			}
			base.ScheduleLateProcessInstance(oldInstance, newInstance);
			return true;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00005BC8 File Offset: 0x00003DC8
		protected override int OnProcessInstance(object oldInstance, object newInstance)
		{
			IDictionary dictionary = (IDictionary)oldInstance;
			IDictionary newDict = (IDictionary)newInstance;
			bool isSameInstance = oldInstance == newInstance;
			if (!isSameInstance)
			{
				newDict.Clear();
			}
			foreach (object obj in dictionary)
			{
				DictionaryEntry kvp = (DictionaryEntry)obj;
				object newKey = base.GetNewInstance(kvp.Key);
				object newValue = base.GetNewInstance(kvp.Value);
				if (isSameInstance || newDict.Contains(newKey))
				{
					newDict[newKey] = newValue;
				}
				else
				{
					newDict.Add(newKey, newValue);
				}
			}
			return 1;
		}

		// Token: 0x04000038 RID: 56
		private static readonly Type Type = typeof(Dictionary<, >);
	}
}
