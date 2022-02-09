using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000CE RID: 206
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamServersDisconnected_t : ICallbackData
	{
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000769 RID: 1897 RVA: 0x0000C8B5 File Offset: 0x0000AAB5
		public int DataSize
		{
			get
			{
				return SteamServersDisconnected_t._datasize;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600076A RID: 1898 RVA: 0x0000C8BC File Offset: 0x0000AABC
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamServersDisconnected;
			}
		}

		// Token: 0x0400098A RID: 2442
		internal Result Result;

		// Token: 0x0400098B RID: 2443
		internal static int _datasize = Marshal.SizeOf(typeof(SteamServersDisconnected_t));
	}
}
