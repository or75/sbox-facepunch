using System;

namespace Steamworks
{
	// Token: 0x02000053 RID: 83
	internal enum UserRestriction
	{
		// Token: 0x04000356 RID: 854
		None,
		// Token: 0x04000357 RID: 855
		Unknown,
		// Token: 0x04000358 RID: 856
		AnyChat,
		// Token: 0x04000359 RID: 857
		VoiceChat = 4,
		// Token: 0x0400035A RID: 858
		GroupChat = 8,
		// Token: 0x0400035B RID: 859
		Rating = 16,
		// Token: 0x0400035C RID: 860
		GameInvites = 32,
		// Token: 0x0400035D RID: 861
		Trading = 64
	}
}
