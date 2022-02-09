using System;

namespace Steamworks
{
	// Token: 0x0200004C RID: 76
	internal enum GameSearchErrorCode_t
	{
		// Token: 0x0400031D RID: 797
		OK = 1,
		// Token: 0x0400031E RID: 798
		Failed_Search_Already_In_Progress,
		// Token: 0x0400031F RID: 799
		Failed_No_Search_In_Progress,
		// Token: 0x04000320 RID: 800
		Failed_Not_Lobby_Leader,
		// Token: 0x04000321 RID: 801
		Failed_No_Host_Available,
		// Token: 0x04000322 RID: 802
		Failed_Search_Params_Invalid,
		// Token: 0x04000323 RID: 803
		Failed_Offline,
		// Token: 0x04000324 RID: 804
		Failed_NotAuthorized,
		// Token: 0x04000325 RID: 805
		Failed_Unknown_Error
	}
}
