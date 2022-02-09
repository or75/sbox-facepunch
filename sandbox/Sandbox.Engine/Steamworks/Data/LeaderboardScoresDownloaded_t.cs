using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200012C RID: 300
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LeaderboardScoresDownloaded_t : ICallbackData
	{
		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000892 RID: 2194 RVA: 0x0000D7B2 File Offset: 0x0000B9B2
		public int DataSize
		{
			get
			{
				return LeaderboardScoresDownloaded_t._datasize;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000893 RID: 2195 RVA: 0x0000D7B9 File Offset: 0x0000B9B9
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LeaderboardScoresDownloaded;
			}
		}

		// Token: 0x04000AF9 RID: 2809
		internal ulong SteamLeaderboard;

		// Token: 0x04000AFA RID: 2810
		internal ulong SteamLeaderboardEntries;

		// Token: 0x04000AFB RID: 2811
		internal int CEntryCount;

		// Token: 0x04000AFC RID: 2812
		internal static int _datasize = Marshal.SizeOf(typeof(LeaderboardScoresDownloaded_t));
	}
}
