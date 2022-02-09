using System;
using System.Collections.Generic;

namespace Sandbox.Upgraders
{
	// Token: 0x02000013 RID: 19
	[UpgraderGroup(typeof(ReferenceTypeUpgraderGroup), GroupOrder.First)]
	public class CachedUpgrader : Hotload.InstanceUpgrader
	{
		// Token: 0x0600009A RID: 154 RVA: 0x00005226 File Offset: 0x00003426
		protected override void OnClearCache()
		{
			this.ReplaceCache.Clear();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00005234 File Offset: 0x00003434
		public bool TryGetCachedInstance(object inst, out object cached)
		{
			Type oldType = inst.GetType();
			cached = null;
			Dictionary<object, object> replaced;
			return this.ReplaceCache.TryGetValue(oldType, out replaced) && replaced.TryGetValue(inst, out cached);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00005268 File Offset: 0x00003468
		public new void AddCachedInstance(object inst, object cached)
		{
			Type oldType = inst.GetType();
			Dictionary<object, object> replaced;
			if (!this.ReplaceCache.TryGetValue(oldType, out replaced))
			{
				replaced = new Dictionary<object, object>(ReferenceComparer.Singleton);
				this.ReplaceCache.Add(oldType, replaced);
			}
			replaced.Add(inst, cached);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000052AC File Offset: 0x000034AC
		public override bool ShouldProcessType(Type type)
		{
			return !type.IsValueType;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000052B7 File Offset: 0x000034B7
		protected override bool OnTryCreateNewInstance(object oldInstance, object context, out object newInstance)
		{
			return this.TryGetCachedInstance(oldInstance, out newInstance);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000052C1 File Offset: 0x000034C1
		protected override bool OnTryUpgradeInstance(object oldInstance, object newInstance, bool createdElsewhere)
		{
			return false;
		}

		// Token: 0x04000034 RID: 52
		private readonly Dictionary<Type, Dictionary<object, object>> ReplaceCache = new Dictionary<Type, Dictionary<object, object>>();
	}
}
