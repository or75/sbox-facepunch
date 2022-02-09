using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000111 RID: 273
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageDeletePublishedFileResult_t : ICallbackData
	{
		// Token: 0x17000112 RID: 274
		// (get) Token: 0x0600083A RID: 2106 RVA: 0x0000D30D File Offset: 0x0000B50D
		public int DataSize
		{
			get
			{
				return RemoteStorageDeletePublishedFileResult_t._datasize;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600083B RID: 2107 RVA: 0x0000D314 File Offset: 0x0000B514
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageDeletePublishedFileResult;
			}
		}

		// Token: 0x04000A76 RID: 2678
		internal Result Result;

		// Token: 0x04000A77 RID: 2679
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000A78 RID: 2680
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageDeletePublishedFileResult_t));
	}
}
