using System;

namespace Steamworks
{
	// Token: 0x02000090 RID: 144
	internal enum SteamNetworkingAvailability
	{
		// Token: 0x04000848 RID: 2120
		CannotTry = -102,
		// Token: 0x04000849 RID: 2121
		Failed,
		// Token: 0x0400084A RID: 2122
		Previously,
		// Token: 0x0400084B RID: 2123
		Retrying = -10,
		// Token: 0x0400084C RID: 2124
		NeverTried = 1,
		// Token: 0x0400084D RID: 2125
		Waiting,
		// Token: 0x0400084E RID: 2126
		Attempting,
		// Token: 0x0400084F RID: 2127
		Current = 100,
		// Token: 0x04000850 RID: 2128
		Unknown = 0,
		// Token: 0x04000851 RID: 2129
		Force32bit = 2147483647
	}
}
