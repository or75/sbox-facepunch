using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000180 RID: 384
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamInventoryResultReady_t : ICallbackData
	{
		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000991 RID: 2449 RVA: 0x0000E3DF File Offset: 0x0000C5DF
		public int DataSize
		{
			get
			{
				return SteamInventoryResultReady_t._datasize;
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000992 RID: 2450 RVA: 0x0000E3E6 File Offset: 0x0000C5E6
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamInventoryResultReady;
			}
		}

		// Token: 0x04000C21 RID: 3105
		internal int Handle;

		// Token: 0x04000C22 RID: 3106
		internal Result Result;

		// Token: 0x04000C23 RID: 3107
		internal static int _datasize = Marshal.SizeOf(typeof(SteamInventoryResultReady_t));
	}
}
