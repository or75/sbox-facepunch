using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x02000154 RID: 340
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamUGCQueryCompleted_t : ICallbackData
	{
		// Token: 0x0600090C RID: 2316 RVA: 0x0000DD90 File Offset: 0x0000BF90
		internal string NextCursorUTF8()
		{
			return Encoding.UTF8.GetString(this.NextCursor, 0, Array.IndexOf<byte>(this.NextCursor, 0));
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x0600090D RID: 2317 RVA: 0x0000DDAF File Offset: 0x0000BFAF
		public int DataSize
		{
			get
			{
				return SteamUGCQueryCompleted_t._datasize;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x0600090E RID: 2318 RVA: 0x0000DDB6 File Offset: 0x0000BFB6
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamUGCQueryCompleted;
			}
		}

		// Token: 0x04000B66 RID: 2918
		internal ulong Handle;

		// Token: 0x04000B67 RID: 2919
		internal Result Result;

		// Token: 0x04000B68 RID: 2920
		internal uint NumResultsReturned;

		// Token: 0x04000B69 RID: 2921
		internal uint TotalMatchingResults;

		// Token: 0x04000B6A RID: 2922
		[MarshalAs(UnmanagedType.I1)]
		internal bool CachedData;

		// Token: 0x04000B6B RID: 2923
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal byte[] NextCursor;

		// Token: 0x04000B6C RID: 2924
		internal static int _datasize = Marshal.SizeOf(typeof(SteamUGCQueryCompleted_t));
	}
}
