using System;

namespace Steamworks
{
	// Token: 0x02000044 RID: 68
	internal enum RoomEnter
	{
		// Token: 0x040002C6 RID: 710
		Success = 1,
		// Token: 0x040002C7 RID: 711
		DoesntExist,
		// Token: 0x040002C8 RID: 712
		NotAllowed,
		// Token: 0x040002C9 RID: 713
		Full,
		// Token: 0x040002CA RID: 714
		Error,
		// Token: 0x040002CB RID: 715
		Banned,
		// Token: 0x040002CC RID: 716
		Limited,
		// Token: 0x040002CD RID: 717
		ClanDisabled,
		// Token: 0x040002CE RID: 718
		CommunityBan,
		// Token: 0x040002CF RID: 719
		MemberBlockedYou,
		// Token: 0x040002D0 RID: 720
		YouBlockedMember,
		// Token: 0x040002D1 RID: 721
		RatelimitExceeded = 15
	}
}
