using System;

namespace Steamworks
{
	// Token: 0x02000043 RID: 67
	internal enum ChatEntryType
	{
		// Token: 0x040002B9 RID: 697
		Invalid,
		// Token: 0x040002BA RID: 698
		ChatMsg,
		// Token: 0x040002BB RID: 699
		Typing,
		// Token: 0x040002BC RID: 700
		InviteGame,
		// Token: 0x040002BD RID: 701
		Emote,
		// Token: 0x040002BE RID: 702
		LeftConversation = 6,
		// Token: 0x040002BF RID: 703
		Entered,
		// Token: 0x040002C0 RID: 704
		WasKicked,
		// Token: 0x040002C1 RID: 705
		WasBanned,
		// Token: 0x040002C2 RID: 706
		Disconnected,
		// Token: 0x040002C3 RID: 707
		HistoricalChat,
		// Token: 0x040002C4 RID: 708
		LinkBlocked = 14
	}
}
