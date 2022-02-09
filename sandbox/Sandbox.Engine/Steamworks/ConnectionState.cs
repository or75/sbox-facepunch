using System;

namespace Steamworks
{
	// Token: 0x02000093 RID: 147
	internal enum ConnectionState
	{
		// Token: 0x04000863 RID: 2147
		None,
		// Token: 0x04000864 RID: 2148
		Connecting,
		// Token: 0x04000865 RID: 2149
		FindingRoute,
		// Token: 0x04000866 RID: 2150
		Connected,
		// Token: 0x04000867 RID: 2151
		ClosedByPeer,
		// Token: 0x04000868 RID: 2152
		ProblemDetectedLocally,
		// Token: 0x04000869 RID: 2153
		FinWait = -1,
		// Token: 0x0400086A RID: 2154
		Linger = -2,
		// Token: 0x0400086B RID: 2155
		Dead = -3
	}
}
