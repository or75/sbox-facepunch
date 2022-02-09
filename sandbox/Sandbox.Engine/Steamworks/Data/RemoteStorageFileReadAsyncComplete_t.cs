using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000126 RID: 294
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageFileReadAsyncComplete_t : ICallbackData
	{
		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600087F RID: 2175 RVA: 0x0000D6BB File Offset: 0x0000B8BB
		public int DataSize
		{
			get
			{
				return RemoteStorageFileReadAsyncComplete_t._datasize;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x0000D6C2 File Offset: 0x0000B8C2
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageFileReadAsyncComplete;
			}
		}

		// Token: 0x04000AE3 RID: 2787
		internal ulong FileReadAsync;

		// Token: 0x04000AE4 RID: 2788
		internal Result Result;

		// Token: 0x04000AE5 RID: 2789
		internal uint Offset;

		// Token: 0x04000AE6 RID: 2790
		internal uint Read;

		// Token: 0x04000AE7 RID: 2791
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageFileReadAsyncComplete_t));
	}
}
