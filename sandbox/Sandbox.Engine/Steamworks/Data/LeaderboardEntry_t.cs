using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020001A9 RID: 425
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LeaderboardEntry_t
	{
		// Token: 0x04000D05 RID: 3333
		internal ulong SteamIDUser;

		// Token: 0x04000D06 RID: 3334
		internal int GlobalRank;

		// Token: 0x04000D07 RID: 3335
		internal int Score;

		// Token: 0x04000D08 RID: 3336
		internal int CDetails;

		// Token: 0x04000D09 RID: 3337
		internal ulong UGC;
	}
}
