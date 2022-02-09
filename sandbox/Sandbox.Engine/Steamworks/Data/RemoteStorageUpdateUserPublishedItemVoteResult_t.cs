using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200011E RID: 286
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageUpdateUserPublishedItemVoteResult_t : ICallbackData
	{
		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000867 RID: 2151 RVA: 0x0000D59B File Offset: 0x0000B79B
		public int DataSize
		{
			get
			{
				return RemoteStorageUpdateUserPublishedItemVoteResult_t._datasize;
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000868 RID: 2152 RVA: 0x0000D5A2 File Offset: 0x0000B7A2
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageUpdateUserPublishedItemVoteResult;
			}
		}

		// Token: 0x04000AC3 RID: 2755
		internal Result Result;

		// Token: 0x04000AC4 RID: 2756
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000AC5 RID: 2757
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageUpdateUserPublishedItemVoteResult_t));
	}
}
