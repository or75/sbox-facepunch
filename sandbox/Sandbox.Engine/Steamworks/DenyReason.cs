using System;

namespace Steamworks
{
	// Token: 0x0200003E RID: 62
	internal enum DenyReason
	{
		// Token: 0x04000285 RID: 645
		Invalid,
		// Token: 0x04000286 RID: 646
		InvalidVersion,
		// Token: 0x04000287 RID: 647
		Generic,
		// Token: 0x04000288 RID: 648
		NotLoggedOn,
		// Token: 0x04000289 RID: 649
		NoLicense,
		// Token: 0x0400028A RID: 650
		Cheater,
		// Token: 0x0400028B RID: 651
		LoggedInElseWhere,
		// Token: 0x0400028C RID: 652
		UnknownText,
		// Token: 0x0400028D RID: 653
		IncompatibleAnticheat,
		// Token: 0x0400028E RID: 654
		MemoryCorruption,
		// Token: 0x0400028F RID: 655
		IncompatibleSoftware,
		// Token: 0x04000290 RID: 656
		SteamConnectionLost,
		// Token: 0x04000291 RID: 657
		SteamConnectionError,
		// Token: 0x04000292 RID: 658
		SteamResponseTimedOut,
		// Token: 0x04000293 RID: 659
		SteamValidationStalled,
		// Token: 0x04000294 RID: 660
		SteamOwnerLeftGuestUser
	}
}
