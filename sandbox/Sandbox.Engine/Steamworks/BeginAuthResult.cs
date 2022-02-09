using System;

namespace Steamworks
{
	// Token: 0x0200003F RID: 63
	internal enum BeginAuthResult
	{
		// Token: 0x04000296 RID: 662
		OK,
		// Token: 0x04000297 RID: 663
		InvalidTicket,
		// Token: 0x04000298 RID: 664
		DuplicateRequest,
		// Token: 0x04000299 RID: 665
		InvalidVersion,
		// Token: 0x0400029A RID: 666
		GameMismatch,
		// Token: 0x0400029B RID: 667
		ExpiredTicket
	}
}
