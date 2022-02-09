using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020001A6 RID: 422
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct FriendGameInfo_t
	{
		// Token: 0x04000CFC RID: 3324
		internal GameId GameID;

		// Token: 0x04000CFD RID: 3325
		internal uint GameIP;

		// Token: 0x04000CFE RID: 3326
		internal ushort GamePort;

		// Token: 0x04000CFF RID: 3327
		internal ushort QueryPort;

		// Token: 0x04000D00 RID: 3328
		internal ulong SteamIDLobby;
	}
}
