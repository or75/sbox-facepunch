using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200011B RID: 283
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStoragePublishedFileSubscribed_t : ICallbackData
	{
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x0600085E RID: 2142 RVA: 0x0000D52F File Offset: 0x0000B72F
		public int DataSize
		{
			get
			{
				return RemoteStoragePublishedFileSubscribed_t._datasize;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x0600085F RID: 2143 RVA: 0x0000D536 File Offset: 0x0000B736
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStoragePublishedFileSubscribed;
			}
		}

		// Token: 0x04000ABA RID: 2746
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000ABB RID: 2747
		internal AppId AppID;

		// Token: 0x04000ABC RID: 2748
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishedFileSubscribed_t));
	}
}
