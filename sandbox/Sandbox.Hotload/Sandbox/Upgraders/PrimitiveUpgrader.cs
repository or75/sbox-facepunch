using System;

namespace Sandbox.Upgraders
{
	// Token: 0x02000019 RID: 25
	[UpgraderGroup(typeof(RootUpgraderGroup), GroupOrder.First)]
	internal class PrimitiveUpgrader : Hotload.InstanceUpgrader
	{
		// Token: 0x060000C7 RID: 199 RVA: 0x00005E51 File Offset: 0x00004051
		public override bool ShouldProcessType(Type type)
		{
			return type.IsPrimitive;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00005E59 File Offset: 0x00004059
		protected override bool OnTryCreateNewInstance(object oldInstance, object context, out object newInstance)
		{
			newInstance = oldInstance;
			return true;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00005E5F File Offset: 0x0000405F
		protected override bool OnTryUpgradeInstance(object oldInstance, object newInstance, bool createdElsewhere)
		{
			return true;
		}
	}
}
