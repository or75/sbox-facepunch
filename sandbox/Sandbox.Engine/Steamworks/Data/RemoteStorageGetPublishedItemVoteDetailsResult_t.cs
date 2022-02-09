using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200011A RID: 282
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageGetPublishedItemVoteDetailsResult_t : ICallbackData
	{
		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600085B RID: 2139 RVA: 0x0000D50B File Offset: 0x0000B70B
		public int DataSize
		{
			get
			{
				return RemoteStorageGetPublishedItemVoteDetailsResult_t._datasize;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600085C RID: 2140 RVA: 0x0000D512 File Offset: 0x0000B712
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageGetPublishedItemVoteDetailsResult;
			}
		}

		// Token: 0x04000AB3 RID: 2739
		internal Result Result;

		// Token: 0x04000AB4 RID: 2740
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000AB5 RID: 2741
		internal int VotesFor;

		// Token: 0x04000AB6 RID: 2742
		internal int VotesAgainst;

		// Token: 0x04000AB7 RID: 2743
		internal int Reports;

		// Token: 0x04000AB8 RID: 2744
		internal float FScore;

		// Token: 0x04000AB9 RID: 2745
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageGetPublishedItemVoteDetailsResult_t));
	}
}
