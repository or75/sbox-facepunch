using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000121 RID: 289
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageSetUserPublishedFileActionResult_t : ICallbackData
	{
		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000870 RID: 2160 RVA: 0x0000D607 File Offset: 0x0000B807
		public int DataSize
		{
			get
			{
				return RemoteStorageSetUserPublishedFileActionResult_t._datasize;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000871 RID: 2161 RVA: 0x0000D60E File Offset: 0x0000B80E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageSetUserPublishedFileActionResult;
			}
		}

		// Token: 0x04000ACF RID: 2767
		internal Result Result;

		// Token: 0x04000AD0 RID: 2768
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000AD1 RID: 2769
		internal WorkshopFileAction Action;

		// Token: 0x04000AD2 RID: 2770
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageSetUserPublishedFileActionResult_t));
	}
}
