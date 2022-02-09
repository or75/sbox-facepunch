using System;

namespace Sandbox.Upgraders
{
	// Token: 0x02000026 RID: 38
	[UpgraderGroup(typeof(RootUpgraderGroup), GroupOrder.Default)]
	public sealed class ReferenceTypeUpgraderGroup : UpgraderGroup
	{
		// Token: 0x06000102 RID: 258 RVA: 0x00006CBC File Offset: 0x00004EBC
		public override bool ShouldProcessType(Type type)
		{
			return !type.IsValueType && base.ShouldProcessType(type);
		}
	}
}
