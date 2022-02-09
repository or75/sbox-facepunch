using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200015C RID: 348
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GetUserItemVoteResult_t : ICallbackData
	{
		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x0000DECF File Offset: 0x0000C0CF
		public int DataSize
		{
			get
			{
				return GetUserItemVoteResult_t._datasize;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000926 RID: 2342 RVA: 0x0000DED6 File Offset: 0x0000C0D6
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GetUserItemVoteResult;
			}
		}

		// Token: 0x04000B87 RID: 2951
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000B88 RID: 2952
		internal Result Result;

		// Token: 0x04000B89 RID: 2953
		[MarshalAs(UnmanagedType.I1)]
		internal bool VotedUp;

		// Token: 0x04000B8A RID: 2954
		[MarshalAs(UnmanagedType.I1)]
		internal bool VotedDown;

		// Token: 0x04000B8B RID: 2955
		[MarshalAs(UnmanagedType.I1)]
		internal bool VoteSkipped;

		// Token: 0x04000B8C RID: 2956
		internal static int _datasize = Marshal.SizeOf(typeof(GetUserItemVoteResult_t));
	}
}
