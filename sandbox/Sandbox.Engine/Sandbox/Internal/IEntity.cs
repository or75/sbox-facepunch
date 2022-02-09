using System;

namespace Sandbox.Internal
{
	// Token: 0x020002ED RID: 749
	public interface IEntity
	{
		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x060013E4 RID: 5092
		IEntity Parent { get; }

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x060013E5 RID: 5093
		IEntity Owner { get; }

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x060013E6 RID: 5094
		IClient Client { get; }

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x060013E7 RID: 5095
		int Id { get; }

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x060013E8 RID: 5096
		bool IsDormant { get; }

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x060013E9 RID: 5097
		bool IsOwnedByLocalClient { get; }

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x060013EA RID: 5098
		Transform Transform { get; }

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x060013EB RID: 5099
		bool IsFromMap { get; }

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x060013EC RID: 5100
		BBox WorldSpaceBounds { get; }
	}
}
