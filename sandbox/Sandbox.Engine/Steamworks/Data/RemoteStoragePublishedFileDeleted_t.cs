using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200011D RID: 285
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStoragePublishedFileDeleted_t : ICallbackData
	{
		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000864 RID: 2148 RVA: 0x0000D577 File Offset: 0x0000B777
		public int DataSize
		{
			get
			{
				return RemoteStoragePublishedFileDeleted_t._datasize;
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000865 RID: 2149 RVA: 0x0000D57E File Offset: 0x0000B77E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStoragePublishedFileDeleted;
			}
		}

		// Token: 0x04000AC0 RID: 2752
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000AC1 RID: 2753
		internal AppId AppID;

		// Token: 0x04000AC2 RID: 2754
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishedFileDeleted_t));
	}
}
