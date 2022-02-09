using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000114 RID: 276
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageEnumerateUserSubscribedFilesResult_t : ICallbackData
	{
		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000843 RID: 2115 RVA: 0x0000D379 File Offset: 0x0000B579
		public int DataSize
		{
			get
			{
				return RemoteStorageEnumerateUserSubscribedFilesResult_t._datasize;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000844 RID: 2116 RVA: 0x0000D380 File Offset: 0x0000B580
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageEnumerateUserSubscribedFilesResult;
			}
		}

		// Token: 0x04000A81 RID: 2689
		internal Result Result;

		// Token: 0x04000A82 RID: 2690
		internal int ResultsReturned;

		// Token: 0x04000A83 RID: 2691
		internal int TotalResultCount;

		// Token: 0x04000A84 RID: 2692
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
		internal PublishedFileId[] GPublishedFileId;

		// Token: 0x04000A85 RID: 2693
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U4)]
		internal uint[] GRTimeSubscribed;

		// Token: 0x04000A86 RID: 2694
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageEnumerateUserSubscribedFilesResult_t));
	}
}
