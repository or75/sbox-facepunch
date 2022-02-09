using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020001AD RID: 429
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamItemDetails_t
	{
		// Token: 0x04000D2E RID: 3374
		internal InventoryItemId ItemId;

		// Token: 0x04000D2F RID: 3375
		internal InventoryDefId Definition;

		// Token: 0x04000D30 RID: 3376
		internal ushort Quantity;

		// Token: 0x04000D31 RID: 3377
		internal ushort Flags;
	}
}
