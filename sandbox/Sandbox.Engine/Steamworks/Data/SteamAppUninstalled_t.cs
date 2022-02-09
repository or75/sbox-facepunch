using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000168 RID: 360
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamAppUninstalled_t : ICallbackData
	{
		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000949 RID: 2377 RVA: 0x0000E07F File Offset: 0x0000C27F
		public int DataSize
		{
			get
			{
				return SteamAppUninstalled_t._datasize;
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x0600094A RID: 2378 RVA: 0x0000E086 File Offset: 0x0000C286
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamAppUninstalled;
			}
		}

		// Token: 0x04000BB6 RID: 2998
		internal AppId AppID;

		// Token: 0x04000BB7 RID: 2999
		internal int InstallFolderIndex;

		// Token: 0x04000BB8 RID: 3000
		internal static int _datasize = Marshal.SizeOf(typeof(SteamAppUninstalled_t));
	}
}
