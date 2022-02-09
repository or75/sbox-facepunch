using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200015B RID: 347
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SetUserItemVoteResult_t : ICallbackData
	{
		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000922 RID: 2338 RVA: 0x0000DEAB File Offset: 0x0000C0AB
		public int DataSize
		{
			get
			{
				return SetUserItemVoteResult_t._datasize;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000923 RID: 2339 RVA: 0x0000DEB2 File Offset: 0x0000C0B2
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SetUserItemVoteResult;
			}
		}

		// Token: 0x04000B83 RID: 2947
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000B84 RID: 2948
		internal Result Result;

		// Token: 0x04000B85 RID: 2949
		[MarshalAs(UnmanagedType.I1)]
		internal bool VoteUp;

		// Token: 0x04000B86 RID: 2950
		internal static int _datasize = Marshal.SizeOf(typeof(SetUserItemVoteResult_t));
	}
}
