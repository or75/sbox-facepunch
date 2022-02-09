using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000155 RID: 341
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamUGCRequestUGCDetailsResult_t : ICallbackData
	{
		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x0000DDD3 File Offset: 0x0000BFD3
		public int DataSize
		{
			get
			{
				return SteamUGCRequestUGCDetailsResult_t._datasize;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000911 RID: 2321 RVA: 0x0000DDDA File Offset: 0x0000BFDA
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamUGCRequestUGCDetailsResult;
			}
		}

		// Token: 0x04000B6D RID: 2925
		internal SteamUGCDetails_t Details;

		// Token: 0x04000B6E RID: 2926
		[MarshalAs(UnmanagedType.I1)]
		internal bool CachedData;

		// Token: 0x04000B6F RID: 2927
		internal static int _datasize = Marshal.SizeOf(typeof(SteamUGCRequestUGCDetailsResult_t));
	}
}
