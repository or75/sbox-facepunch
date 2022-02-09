using System;

namespace Steamworks
{
	// Token: 0x02000048 RID: 72
	internal enum MarketNotAllowedReasonFlags
	{
		// Token: 0x040002F6 RID: 758
		None,
		// Token: 0x040002F7 RID: 759
		TemporaryFailure,
		// Token: 0x040002F8 RID: 760
		AccountDisabled,
		// Token: 0x040002F9 RID: 761
		AccountLockedDown = 4,
		// Token: 0x040002FA RID: 762
		AccountLimited = 8,
		// Token: 0x040002FB RID: 763
		TradeBanned = 16,
		// Token: 0x040002FC RID: 764
		AccountNotTrusted = 32,
		// Token: 0x040002FD RID: 765
		SteamGuardNotEnabled = 64,
		// Token: 0x040002FE RID: 766
		SteamGuardOnlyRecentlyEnabled = 128,
		// Token: 0x040002FF RID: 767
		RecentPasswordReset = 256,
		// Token: 0x04000300 RID: 768
		NewPaymentMethod = 512,
		// Token: 0x04000301 RID: 769
		InvalidCookie = 1024,
		// Token: 0x04000302 RID: 770
		UsingNewDevice = 2048,
		// Token: 0x04000303 RID: 771
		RecentSelfRefund = 4096,
		// Token: 0x04000304 RID: 772
		NewPaymentMethodCannotBeVerified = 8192,
		// Token: 0x04000305 RID: 773
		NoRecentPurchases = 16384,
		// Token: 0x04000306 RID: 774
		AcceptedWalletGift = 32768
	}
}
