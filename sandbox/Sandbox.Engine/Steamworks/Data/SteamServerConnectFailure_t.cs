using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000CD RID: 205
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamServerConnectFailure_t : ICallbackData
	{
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000766 RID: 1894 RVA: 0x0000C894 File Offset: 0x0000AA94
		public int DataSize
		{
			get
			{
				return SteamServerConnectFailure_t._datasize;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000767 RID: 1895 RVA: 0x0000C89B File Offset: 0x0000AA9B
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamServerConnectFailure;
			}
		}

		// Token: 0x04000987 RID: 2439
		internal Result Result;

		// Token: 0x04000988 RID: 2440
		[MarshalAs(UnmanagedType.I1)]
		internal bool StillRetrying;

		// Token: 0x04000989 RID: 2441
		internal static int _datasize = Marshal.SizeOf(typeof(SteamServerConnectFailure_t));
	}
}
