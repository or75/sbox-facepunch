using System;

namespace Steamworks
{
	// Token: 0x02000052 RID: 82
	internal enum FriendFlags
	{
		// Token: 0x04000349 RID: 841
		None,
		// Token: 0x0400034A RID: 842
		Blocked,
		// Token: 0x0400034B RID: 843
		FriendshipRequested,
		// Token: 0x0400034C RID: 844
		Immediate = 4,
		// Token: 0x0400034D RID: 845
		ClanMember = 8,
		// Token: 0x0400034E RID: 846
		OnGameServer = 16,
		// Token: 0x0400034F RID: 847
		RequestingFriendship = 128,
		// Token: 0x04000350 RID: 848
		RequestingInfo = 256,
		// Token: 0x04000351 RID: 849
		Ignored = 512,
		// Token: 0x04000352 RID: 850
		IgnoredFriend = 1024,
		// Token: 0x04000353 RID: 851
		ChatMember = 4096,
		// Token: 0x04000354 RID: 852
		All = 65535
	}
}
