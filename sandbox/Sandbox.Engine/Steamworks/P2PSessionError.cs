using System;

namespace Steamworks
{
	// Token: 0x02000071 RID: 113
	internal enum P2PSessionError
	{
		// Token: 0x04000408 RID: 1032
		None,
		// Token: 0x04000409 RID: 1033
		NoRightsToApp = 2,
		// Token: 0x0400040A RID: 1034
		Timeout = 4,
		// Token: 0x0400040B RID: 1035
		NotRunningApp_DELETED = 1,
		// Token: 0x0400040C RID: 1036
		DestinationNotLoggedIn_DELETED = 3,
		// Token: 0x0400040D RID: 1037
		Max = 5
	}
}
