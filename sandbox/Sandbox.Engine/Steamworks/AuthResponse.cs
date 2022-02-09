using System;

namespace Steamworks
{
	// Token: 0x02000040 RID: 64
	internal enum AuthResponse
	{
		// Token: 0x0400029D RID: 669
		OK,
		// Token: 0x0400029E RID: 670
		UserNotConnectedToSteam,
		// Token: 0x0400029F RID: 671
		NoLicenseOrExpired,
		// Token: 0x040002A0 RID: 672
		VACBanned,
		// Token: 0x040002A1 RID: 673
		LoggedInElseWhere,
		// Token: 0x040002A2 RID: 674
		VACCheckTimedOut,
		// Token: 0x040002A3 RID: 675
		AuthTicketCanceled,
		// Token: 0x040002A4 RID: 676
		AuthTicketInvalidAlreadyUsed,
		// Token: 0x040002A5 RID: 677
		AuthTicketInvalid,
		// Token: 0x040002A6 RID: 678
		PublisherIssuedBan
	}
}
