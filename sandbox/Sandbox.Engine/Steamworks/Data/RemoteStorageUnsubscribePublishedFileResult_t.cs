using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000115 RID: 277
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageUnsubscribePublishedFileResult_t : ICallbackData
	{
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x0000D39D File Offset: 0x0000B59D
		public int DataSize
		{
			get
			{
				return RemoteStorageUnsubscribePublishedFileResult_t._datasize;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000847 RID: 2119 RVA: 0x0000D3A4 File Offset: 0x0000B5A4
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageUnsubscribePublishedFileResult;
			}
		}

		// Token: 0x04000A87 RID: 2695
		internal Result Result;

		// Token: 0x04000A88 RID: 2696
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000A89 RID: 2697
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageUnsubscribePublishedFileResult_t));
	}
}
