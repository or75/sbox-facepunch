using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000125 RID: 293
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageFileWriteAsyncComplete_t : ICallbackData
	{
		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600087C RID: 2172 RVA: 0x0000D697 File Offset: 0x0000B897
		public int DataSize
		{
			get
			{
				return RemoteStorageFileWriteAsyncComplete_t._datasize;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600087D RID: 2173 RVA: 0x0000D69E File Offset: 0x0000B89E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageFileWriteAsyncComplete;
			}
		}

		// Token: 0x04000AE1 RID: 2785
		internal Result Result;

		// Token: 0x04000AE2 RID: 2786
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageFileWriteAsyncComplete_t));
	}
}
