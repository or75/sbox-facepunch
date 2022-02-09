using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000E5 RID: 229
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct DownloadClanActivityCountsResult_t : ICallbackData
	{
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060007B3 RID: 1971 RVA: 0x0000CC80 File Offset: 0x0000AE80
		public int DataSize
		{
			get
			{
				return DownloadClanActivityCountsResult_t._datasize;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060007B4 RID: 1972 RVA: 0x0000CC87 File Offset: 0x0000AE87
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.DownloadClanActivityCountsResult;
			}
		}

		// Token: 0x040009DB RID: 2523
		[MarshalAs(UnmanagedType.I1)]
		internal bool Success;

		// Token: 0x040009DC RID: 2524
		internal static int _datasize = Marshal.SizeOf(typeof(DownloadClanActivityCountsResult_t));
	}
}
