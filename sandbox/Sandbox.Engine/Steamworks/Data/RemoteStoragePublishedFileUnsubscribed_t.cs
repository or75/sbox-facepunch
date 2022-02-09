using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200011C RID: 284
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStoragePublishedFileUnsubscribed_t : ICallbackData
	{
		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000861 RID: 2145 RVA: 0x0000D553 File Offset: 0x0000B753
		public int DataSize
		{
			get
			{
				return RemoteStoragePublishedFileUnsubscribed_t._datasize;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000862 RID: 2146 RVA: 0x0000D55A File Offset: 0x0000B75A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStoragePublishedFileUnsubscribed;
			}
		}

		// Token: 0x04000ABD RID: 2749
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000ABE RID: 2750
		internal AppId AppID;

		// Token: 0x04000ABF RID: 2751
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishedFileUnsubscribed_t));
	}
}
