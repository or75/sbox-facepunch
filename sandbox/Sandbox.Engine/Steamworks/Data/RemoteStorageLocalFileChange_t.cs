using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000127 RID: 295
	internal struct RemoteStorageLocalFileChange_t : ICallbackData
	{
		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000882 RID: 2178 RVA: 0x0000D6DF File Offset: 0x0000B8DF
		public int DataSize
		{
			get
			{
				return RemoteStorageLocalFileChange_t._datasize;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000883 RID: 2179 RVA: 0x0000D6E6 File Offset: 0x0000B8E6
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageLocalFileChange;
			}
		}

		// Token: 0x04000AE8 RID: 2792
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageLocalFileChange_t));
	}
}
