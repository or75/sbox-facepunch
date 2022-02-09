using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200010B RID: 267
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct ReservationNotificationCallback_t : ICallbackData
	{
		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000827 RID: 2087 RVA: 0x0000D216 File Offset: 0x0000B416
		public int DataSize
		{
			get
			{
				return ReservationNotificationCallback_t._datasize;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000828 RID: 2088 RVA: 0x0000D21D File Offset: 0x0000B41D
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.ReservationNotificationCallback;
			}
		}

		// Token: 0x04000A67 RID: 2663
		internal ulong BeaconID;

		// Token: 0x04000A68 RID: 2664
		internal ulong SteamIDJoiner;

		// Token: 0x04000A69 RID: 2665
		internal static int _datasize = Marshal.SizeOf(typeof(ReservationNotificationCallback_t));
	}
}
