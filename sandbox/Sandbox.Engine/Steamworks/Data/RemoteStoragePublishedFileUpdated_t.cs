using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000124 RID: 292
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStoragePublishedFileUpdated_t : ICallbackData
	{
		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000879 RID: 2169 RVA: 0x0000D673 File Offset: 0x0000B873
		public int DataSize
		{
			get
			{
				return RemoteStoragePublishedFileUpdated_t._datasize;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600087A RID: 2170 RVA: 0x0000D67A File Offset: 0x0000B87A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStoragePublishedFileUpdated;
			}
		}

		// Token: 0x04000ADD RID: 2781
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000ADE RID: 2782
		internal AppId AppID;

		// Token: 0x04000ADF RID: 2783
		internal ulong Unused;

		// Token: 0x04000AE0 RID: 2784
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishedFileUpdated_t));
	}
}
