using System;

namespace Steamworks
{
	// Token: 0x02000091 RID: 145
	internal enum NetIdentityType
	{
		// Token: 0x04000853 RID: 2131
		Invalid,
		// Token: 0x04000854 RID: 2132
		SteamID = 16,
		// Token: 0x04000855 RID: 2133
		XboxPairwiseID,
		// Token: 0x04000856 RID: 2134
		SonyPSN,
		// Token: 0x04000857 RID: 2135
		GoogleStadia,
		// Token: 0x04000858 RID: 2136
		IPAddress = 1,
		// Token: 0x04000859 RID: 2137
		GenericString,
		// Token: 0x0400085A RID: 2138
		GenericBytes,
		// Token: 0x0400085B RID: 2139
		UnknownType,
		// Token: 0x0400085C RID: 2140
		Force32bit = 2147483647
	}
}
