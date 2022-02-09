using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200012D RID: 301
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LeaderboardScoreUploaded_t : ICallbackData
	{
		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000895 RID: 2197 RVA: 0x0000D7D6 File Offset: 0x0000B9D6
		public int DataSize
		{
			get
			{
				return LeaderboardScoreUploaded_t._datasize;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000896 RID: 2198 RVA: 0x0000D7DD File Offset: 0x0000B9DD
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LeaderboardScoreUploaded;
			}
		}

		// Token: 0x04000AFD RID: 2813
		internal byte Success;

		// Token: 0x04000AFE RID: 2814
		internal ulong SteamLeaderboard;

		// Token: 0x04000AFF RID: 2815
		internal int Score;

		// Token: 0x04000B00 RID: 2816
		internal byte ScoreChanged;

		// Token: 0x04000B01 RID: 2817
		internal int GlobalRankNew;

		// Token: 0x04000B02 RID: 2818
		internal int GlobalRankPrevious;

		// Token: 0x04000B03 RID: 2819
		internal static int _datasize = Marshal.SizeOf(typeof(LeaderboardScoreUploaded_t));
	}
}
