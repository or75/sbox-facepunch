using System;

namespace Steamworks
{
	// Token: 0x02000056 RID: 86
	internal enum PersonaChange
	{
		// Token: 0x04000366 RID: 870
		Name = 1,
		// Token: 0x04000367 RID: 871
		Status,
		// Token: 0x04000368 RID: 872
		ComeOnline = 4,
		// Token: 0x04000369 RID: 873
		GoneOffline = 8,
		// Token: 0x0400036A RID: 874
		GamePlayed = 16,
		// Token: 0x0400036B RID: 875
		GameServer = 32,
		// Token: 0x0400036C RID: 876
		Avatar = 64,
		// Token: 0x0400036D RID: 877
		JoinedSource = 128,
		// Token: 0x0400036E RID: 878
		LeftSource = 256,
		// Token: 0x0400036F RID: 879
		RelationshipChanged = 512,
		// Token: 0x04000370 RID: 880
		NameFirstSet = 1024,
		// Token: 0x04000371 RID: 881
		Broadcast = 2048,
		// Token: 0x04000372 RID: 882
		Nickname = 4096,
		// Token: 0x04000373 RID: 883
		SteamLevel = 8192,
		// Token: 0x04000374 RID: 884
		RichPresence = 16384
	}
}
