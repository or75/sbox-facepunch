using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000105 RID: 261
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct RequestPlayersForGameResultCallback_t : ICallbackData
	{
		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000814 RID: 2068 RVA: 0x0000D11F File Offset: 0x0000B31F
		public int DataSize
		{
			get
			{
				return RequestPlayersForGameResultCallback_t._datasize;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000815 RID: 2069 RVA: 0x0000D126 File Offset: 0x0000B326
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RequestPlayersForGameResultCallback;
			}
		}

		// Token: 0x04000A49 RID: 2633
		internal Result Result;

		// Token: 0x04000A4A RID: 2634
		internal ulong LSearchID;

		// Token: 0x04000A4B RID: 2635
		internal ulong SteamIDPlayerFound;

		// Token: 0x04000A4C RID: 2636
		internal ulong SteamIDLobby;

		// Token: 0x04000A4D RID: 2637
		internal RequestPlayersForGameResultCallback_t.PlayerAcceptState_t PlayerAcceptState;

		// Token: 0x04000A4E RID: 2638
		internal int PlayerIndex;

		// Token: 0x04000A4F RID: 2639
		internal int TotalPlayersFound;

		// Token: 0x04000A50 RID: 2640
		internal int TotalPlayersAcceptedGame;

		// Token: 0x04000A51 RID: 2641
		internal int SuggestedTeamIndex;

		// Token: 0x04000A52 RID: 2642
		internal ulong LUniqueGameID;

		// Token: 0x04000A53 RID: 2643
		internal static int _datasize = Marshal.SizeOf(typeof(RequestPlayersForGameResultCallback_t));

		// Token: 0x0200036F RID: 879
		internal enum PlayerAcceptState_t
		{
			// Token: 0x04001755 RID: 5973
			Unknown,
			// Token: 0x04001756 RID: 5974
			PlayerAccepted,
			// Token: 0x04001757 RID: 5975
			PlayerDeclined
		}
	}
}
