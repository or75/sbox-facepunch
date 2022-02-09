using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000184 RID: 388
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamInventoryStartPurchaseResult_t : ICallbackData
	{
		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x0600099D RID: 2461 RVA: 0x0000E46F File Offset: 0x0000C66F
		public int DataSize
		{
			get
			{
				return SteamInventoryStartPurchaseResult_t._datasize;
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x0600099E RID: 2462 RVA: 0x0000E476 File Offset: 0x0000C676
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamInventoryStartPurchaseResult;
			}
		}

		// Token: 0x04000C2C RID: 3116
		internal Result Result;

		// Token: 0x04000C2D RID: 3117
		internal ulong OrderID;

		// Token: 0x04000C2E RID: 3118
		internal ulong TransID;

		// Token: 0x04000C2F RID: 3119
		internal static int _datasize = Marshal.SizeOf(typeof(SteamInventoryStartPurchaseResult_t));
	}
}
