using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000112 RID: 274
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageEnumerateUserPublishedFilesResult_t : ICallbackData
	{
		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600083D RID: 2109 RVA: 0x0000D331 File Offset: 0x0000B531
		public int DataSize
		{
			get
			{
				return RemoteStorageEnumerateUserPublishedFilesResult_t._datasize;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600083E RID: 2110 RVA: 0x0000D338 File Offset: 0x0000B538
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageEnumerateUserPublishedFilesResult;
			}
		}

		// Token: 0x04000A79 RID: 2681
		internal Result Result;

		// Token: 0x04000A7A RID: 2682
		internal int ResultsReturned;

		// Token: 0x04000A7B RID: 2683
		internal int TotalResultCount;

		// Token: 0x04000A7C RID: 2684
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
		internal PublishedFileId[] GPublishedFileId;

		// Token: 0x04000A7D RID: 2685
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageEnumerateUserPublishedFilesResult_t));
	}
}
