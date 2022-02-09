using System;
using System.Linq;

namespace Steamworks.Data
{
	// Token: 0x020001E4 RID: 484
	internal struct LeaderboardEntry
	{
		// Token: 0x06000BDA RID: 3034 RVA: 0x00010AEC File Offset: 0x0000ECEC
		internal static LeaderboardEntry From(LeaderboardEntry_t e, int[] detailsBuffer)
		{
			LeaderboardEntry r = new LeaderboardEntry
			{
				User = new Friend(e.SteamIDUser),
				GlobalRank = e.GlobalRank,
				Score = e.Score,
				Details = null
			};
			if (e.CDetails > 0)
			{
				r.Details = detailsBuffer.Take(e.CDetails).ToArray<int>();
			}
			return r;
		}

		// Token: 0x04000D7B RID: 3451
		internal Friend User;

		// Token: 0x04000D7C RID: 3452
		internal int GlobalRank;

		// Token: 0x04000D7D RID: 3453
		internal int Score;

		// Token: 0x04000D7E RID: 3454
		internal int[] Details;
	}
}
