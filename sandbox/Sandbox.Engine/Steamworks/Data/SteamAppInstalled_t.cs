using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000167 RID: 359
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamAppInstalled_t : ICallbackData
	{
		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000946 RID: 2374 RVA: 0x0000E05B File Offset: 0x0000C25B
		public int DataSize
		{
			get
			{
				return SteamAppInstalled_t._datasize;
			}
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06000947 RID: 2375 RVA: 0x0000E062 File Offset: 0x0000C262
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamAppInstalled;
			}
		}

		// Token: 0x04000BB3 RID: 2995
		internal AppId AppID;

		// Token: 0x04000BB4 RID: 2996
		internal int InstallFolderIndex;

		// Token: 0x04000BB5 RID: 2997
		internal static int _datasize = Marshal.SizeOf(typeof(SteamAppInstalled_t));
	}
}
