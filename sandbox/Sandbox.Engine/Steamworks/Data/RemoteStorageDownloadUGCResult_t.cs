using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x02000117 RID: 279
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageDownloadUGCResult_t : ICallbackData
	{
		// Token: 0x0600084C RID: 2124 RVA: 0x0000D3E5 File Offset: 0x0000B5E5
		internal string PchFileNameUTF8()
		{
			return Encoding.UTF8.GetString(this.PchFileName, 0, Array.IndexOf<byte>(this.PchFileName, 0));
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x0000D404 File Offset: 0x0000B604
		public int DataSize
		{
			get
			{
				return RemoteStorageDownloadUGCResult_t._datasize;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x0000D40B File Offset: 0x0000B60B
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageDownloadUGCResult;
			}
		}

		// Token: 0x04000A8E RID: 2702
		internal Result Result;

		// Token: 0x04000A8F RID: 2703
		internal ulong File;

		// Token: 0x04000A90 RID: 2704
		internal AppId AppID;

		// Token: 0x04000A91 RID: 2705
		internal int SizeInBytes;

		// Token: 0x04000A92 RID: 2706
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
		internal byte[] PchFileName;

		// Token: 0x04000A93 RID: 2707
		internal ulong SteamIDOwner;

		// Token: 0x04000A94 RID: 2708
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageDownloadUGCResult_t));
	}
}
