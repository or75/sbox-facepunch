using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000183 RID: 387
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct SteamInventoryEligiblePromoItemDefIDs_t : ICallbackData
	{
		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x0600099A RID: 2458 RVA: 0x0000E44B File Offset: 0x0000C64B
		public int DataSize
		{
			get
			{
				return SteamInventoryEligiblePromoItemDefIDs_t._datasize;
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x0600099B RID: 2459 RVA: 0x0000E452 File Offset: 0x0000C652
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamInventoryEligiblePromoItemDefIDs;
			}
		}

		// Token: 0x04000C27 RID: 3111
		internal Result Result;

		// Token: 0x04000C28 RID: 3112
		internal ulong SteamID;

		// Token: 0x04000C29 RID: 3113
		internal int UmEligiblePromoItemDefs;

		// Token: 0x04000C2A RID: 3114
		[MarshalAs(UnmanagedType.I1)]
		internal bool CachedData;

		// Token: 0x04000C2B RID: 3115
		internal static int _datasize = Marshal.SizeOf(typeof(SteamInventoryEligiblePromoItemDefIDs_t));
	}
}
