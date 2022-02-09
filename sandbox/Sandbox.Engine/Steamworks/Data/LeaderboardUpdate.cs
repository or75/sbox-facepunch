using System;

namespace Steamworks.Data
{
	// Token: 0x020001E5 RID: 485
	internal struct LeaderboardUpdate
	{
		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000BDB RID: 3035 RVA: 0x00010B5E File Offset: 0x0000ED5E
		internal int RankChange
		{
			get
			{
				return this.NewGlobalRank - this.OldGlobalRank;
			}
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x00010B70 File Offset: 0x0000ED70
		internal static LeaderboardUpdate From(LeaderboardScoreUploaded_t e)
		{
			return new LeaderboardUpdate
			{
				Score = e.Score,
				Changed = (e.ScoreChanged == 1),
				NewGlobalRank = e.GlobalRankNew,
				OldGlobalRank = e.GlobalRankPrevious
			};
		}

		// Token: 0x04000D7F RID: 3455
		internal int Score;

		// Token: 0x04000D80 RID: 3456
		internal bool Changed;

		// Token: 0x04000D81 RID: 3457
		internal int NewGlobalRank;

		// Token: 0x04000D82 RID: 3458
		internal int OldGlobalRank;
	}
}
