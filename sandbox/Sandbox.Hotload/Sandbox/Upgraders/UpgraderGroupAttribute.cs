using System;

namespace Sandbox.Upgraders
{
	// Token: 0x02000021 RID: 33
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class UpgraderGroupAttribute : Attribute
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x0000637D File Offset: 0x0000457D
		public Type UpgraderGroupType { get; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00006385 File Offset: 0x00004585
		public GroupOrder GroupOrder { get; }

		// Token: 0x060000E8 RID: 232 RVA: 0x0000638D File Offset: 0x0000458D
		public UpgraderGroupAttribute(Type upgraderGroupType, GroupOrder groupOrder = GroupOrder.Default)
		{
			this.UpgraderGroupType = upgraderGroupType;
			this.GroupOrder = groupOrder;
		}
	}
}
