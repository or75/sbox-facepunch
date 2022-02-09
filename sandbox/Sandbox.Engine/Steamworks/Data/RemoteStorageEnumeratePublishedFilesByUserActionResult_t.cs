using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000122 RID: 290
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageEnumeratePublishedFilesByUserActionResult_t : ICallbackData
	{
		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000873 RID: 2163 RVA: 0x0000D62B File Offset: 0x0000B82B
		public int DataSize
		{
			get
			{
				return RemoteStorageEnumeratePublishedFilesByUserActionResult_t._datasize;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000874 RID: 2164 RVA: 0x0000D632 File Offset: 0x0000B832
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageEnumeratePublishedFilesByUserActionResult;
			}
		}

		// Token: 0x04000AD3 RID: 2771
		internal Result Result;

		// Token: 0x04000AD4 RID: 2772
		internal WorkshopFileAction Action;

		// Token: 0x04000AD5 RID: 2773
		internal int ResultsReturned;

		// Token: 0x04000AD6 RID: 2774
		internal int TotalResultCount;

		// Token: 0x04000AD7 RID: 2775
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
		internal PublishedFileId[] GPublishedFileId;

		// Token: 0x04000AD8 RID: 2776
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U4)]
		internal uint[] GRTimeUpdated;

		// Token: 0x04000AD9 RID: 2777
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageEnumeratePublishedFilesByUserActionResult_t));
	}
}
