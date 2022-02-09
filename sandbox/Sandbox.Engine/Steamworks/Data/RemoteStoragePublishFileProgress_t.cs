using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000123 RID: 291
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStoragePublishFileProgress_t : ICallbackData
	{
		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000876 RID: 2166 RVA: 0x0000D64F File Offset: 0x0000B84F
		public int DataSize
		{
			get
			{
				return RemoteStoragePublishFileProgress_t._datasize;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000877 RID: 2167 RVA: 0x0000D656 File Offset: 0x0000B856
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStoragePublishFileProgress;
			}
		}

		// Token: 0x04000ADA RID: 2778
		internal double DPercentFile;

		// Token: 0x04000ADB RID: 2779
		[MarshalAs(UnmanagedType.I1)]
		internal bool Preview;

		// Token: 0x04000ADC RID: 2780
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishFileProgress_t));
	}
}
