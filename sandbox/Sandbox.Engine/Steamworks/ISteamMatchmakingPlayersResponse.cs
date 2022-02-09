using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200002D RID: 45
	internal class ISteamMatchmakingPlayersResponse : SteamInterface
	{
		// Token: 0x06000370 RID: 880 RVA: 0x00005849 File Offset: 0x00003A49
		internal ISteamMatchmakingPlayersResponse(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x06000371 RID: 881
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_AddPlayerToList")]
		private static extern void _AddPlayerToList(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, int nScore, float flTimePlayed);

		// Token: 0x06000372 RID: 882 RVA: 0x00005858 File Offset: 0x00003A58
		internal void AddPlayerToList([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, int nScore, float flTimePlayed)
		{
			ISteamMatchmakingPlayersResponse._AddPlayerToList(this.Self, pchName, nScore, flTimePlayed);
		}

		// Token: 0x06000373 RID: 883
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_PlayersFailedToRespond")]
		private static extern void _PlayersFailedToRespond(IntPtr self);

		// Token: 0x06000374 RID: 884 RVA: 0x00005868 File Offset: 0x00003A68
		internal void PlayersFailedToRespond()
		{
			ISteamMatchmakingPlayersResponse._PlayersFailedToRespond(this.Self);
		}

		// Token: 0x06000375 RID: 885
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_PlayersRefreshComplete")]
		private static extern void _PlayersRefreshComplete(IntPtr self);

		// Token: 0x06000376 RID: 886 RVA: 0x00005875 File Offset: 0x00003A75
		internal void PlayersRefreshComplete()
		{
			ISteamMatchmakingPlayersResponse._PlayersRefreshComplete(this.Self);
		}
	}
}
