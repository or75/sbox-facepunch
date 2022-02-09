using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000189 RID: 393
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamRemotePlaySessionConnected_t : ICallbackData
	{
		// Token: 0x17000202 RID: 514
		// (get) Token: 0x060009AE RID: 2478 RVA: 0x0000E561 File Offset: 0x0000C761
		public int DataSize
		{
			get
			{
				return SteamRemotePlaySessionConnected_t._datasize;
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x060009AF RID: 2479 RVA: 0x0000E568 File Offset: 0x0000C768
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamRemotePlaySessionConnected;
			}
		}

		// Token: 0x04000C3B RID: 3131
		internal uint SessionID;

		// Token: 0x04000C3C RID: 3132
		internal static int _datasize = Marshal.SizeOf(typeof(SteamRemotePlaySessionConnected_t));
	}
}
