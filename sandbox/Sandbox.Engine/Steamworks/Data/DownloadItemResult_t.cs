using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000159 RID: 345
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct DownloadItemResult_t : ICallbackData
	{
		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x0600091C RID: 2332 RVA: 0x0000DE63 File Offset: 0x0000C063
		public int DataSize
		{
			get
			{
				return DownloadItemResult_t._datasize;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600091D RID: 2333 RVA: 0x0000DE6A File Offset: 0x0000C06A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.DownloadItemResult;
			}
		}

		// Token: 0x04000B7B RID: 2939
		internal AppId AppID;

		// Token: 0x04000B7C RID: 2940
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000B7D RID: 2941
		internal Result Result;

		// Token: 0x04000B7E RID: 2942
		internal static int _datasize = Marshal.SizeOf(typeof(DownloadItemResult_t));
	}
}
