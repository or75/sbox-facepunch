using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x0200002F RID: 47
	internal class ISteamMatchmakingServerListResponse : SteamInterface
	{
		// Token: 0x0600037E RID: 894 RVA: 0x000058BA File Offset: 0x00003ABA
		internal ISteamMatchmakingServerListResponse(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x0600037F RID: 895
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServerListResponse_ServerResponded")]
		private static extern void _ServerResponded(IntPtr self, HServerListRequest hRequest, int iServer);

		// Token: 0x06000380 RID: 896 RVA: 0x000058C9 File Offset: 0x00003AC9
		internal void ServerResponded(HServerListRequest hRequest, int iServer)
		{
			ISteamMatchmakingServerListResponse._ServerResponded(this.Self, hRequest, iServer);
		}

		// Token: 0x06000381 RID: 897
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServerListResponse_ServerFailedToRespond")]
		private static extern void _ServerFailedToRespond(IntPtr self, HServerListRequest hRequest, int iServer);

		// Token: 0x06000382 RID: 898 RVA: 0x000058D8 File Offset: 0x00003AD8
		internal void ServerFailedToRespond(HServerListRequest hRequest, int iServer)
		{
			ISteamMatchmakingServerListResponse._ServerFailedToRespond(this.Self, hRequest, iServer);
		}

		// Token: 0x06000383 RID: 899
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServerListResponse_RefreshComplete")]
		private static extern void _RefreshComplete(IntPtr self, HServerListRequest hRequest, MatchMakingServerResponse response);

		// Token: 0x06000384 RID: 900 RVA: 0x000058E7 File Offset: 0x00003AE7
		internal void RefreshComplete(HServerListRequest hRequest, MatchMakingServerResponse response)
		{
			ISteamMatchmakingServerListResponse._RefreshComplete(this.Self, hRequest, response);
		}
	}
}
