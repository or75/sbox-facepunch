using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200011F RID: 287
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageUserVoteDetails_t : ICallbackData
	{
		// Token: 0x1700012E RID: 302
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x0000D5BF File Offset: 0x0000B7BF
		public int DataSize
		{
			get
			{
				return RemoteStorageUserVoteDetails_t._datasize;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x0600086B RID: 2155 RVA: 0x0000D5C6 File Offset: 0x0000B7C6
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageUserVoteDetails;
			}
		}

		// Token: 0x04000AC6 RID: 2758
		internal Result Result;

		// Token: 0x04000AC7 RID: 2759
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000AC8 RID: 2760
		internal WorkshopVote Vote;

		// Token: 0x04000AC9 RID: 2761
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageUserVoteDetails_t));
	}
}
