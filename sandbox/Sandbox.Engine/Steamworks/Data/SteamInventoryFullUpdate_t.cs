using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000181 RID: 385
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamInventoryFullUpdate_t : ICallbackData
	{
		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000994 RID: 2452 RVA: 0x0000E403 File Offset: 0x0000C603
		public int DataSize
		{
			get
			{
				return SteamInventoryFullUpdate_t._datasize;
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000995 RID: 2453 RVA: 0x0000E40A File Offset: 0x0000C60A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamInventoryFullUpdate;
			}
		}

		// Token: 0x04000C24 RID: 3108
		internal int Handle;

		// Token: 0x04000C25 RID: 3109
		internal static int _datasize = Marshal.SizeOf(typeof(SteamInventoryFullUpdate_t));
	}
}
