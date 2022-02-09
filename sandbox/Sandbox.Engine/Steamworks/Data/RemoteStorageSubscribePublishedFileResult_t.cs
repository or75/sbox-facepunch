using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000113 RID: 275
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageSubscribePublishedFileResult_t : ICallbackData
	{
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000840 RID: 2112 RVA: 0x0000D355 File Offset: 0x0000B555
		public int DataSize
		{
			get
			{
				return RemoteStorageSubscribePublishedFileResult_t._datasize;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x0000D35C File Offset: 0x0000B55C
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageSubscribePublishedFileResult;
			}
		}

		// Token: 0x04000A7E RID: 2686
		internal Result Result;

		// Token: 0x04000A7F RID: 2687
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000A80 RID: 2688
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageSubscribePublishedFileResult_t));
	}
}
