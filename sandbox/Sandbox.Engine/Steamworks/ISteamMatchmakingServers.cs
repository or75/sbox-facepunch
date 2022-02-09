using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x02000030 RID: 48
	internal class ISteamMatchmakingServers : SteamInterface
	{
		// Token: 0x06000385 RID: 901 RVA: 0x000058F6 File Offset: 0x00003AF6
		internal ISteamMatchmakingServers(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x06000386 RID: 902
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamMatchmakingServers_v002();

		// Token: 0x06000387 RID: 903 RVA: 0x00005905 File Offset: 0x00003B05
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamMatchmakingServers.SteamAPI_SteamMatchmakingServers_v002();
		}

		// Token: 0x06000388 RID: 904
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestInternetServerList")]
		private static extern HServerListRequest _RequestInternetServerList(IntPtr self, AppId iApp, [In] [Out] ref MatchMakingKeyValuePair[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse);

		// Token: 0x06000389 RID: 905 RVA: 0x0000590C File Offset: 0x00003B0C
		internal HServerListRequest RequestInternetServerList(AppId iApp, [In] [Out] ref MatchMakingKeyValuePair[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse)
		{
			return ISteamMatchmakingServers._RequestInternetServerList(this.Self, iApp, ref ppchFilters, nFilters, pRequestServersResponse);
		}

		// Token: 0x0600038A RID: 906
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestLANServerList")]
		private static extern HServerListRequest _RequestLANServerList(IntPtr self, AppId iApp, IntPtr pRequestServersResponse);

		// Token: 0x0600038B RID: 907 RVA: 0x0000591E File Offset: 0x00003B1E
		internal HServerListRequest RequestLANServerList(AppId iApp, IntPtr pRequestServersResponse)
		{
			return ISteamMatchmakingServers._RequestLANServerList(this.Self, iApp, pRequestServersResponse);
		}

		// Token: 0x0600038C RID: 908
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestFriendsServerList")]
		private static extern HServerListRequest _RequestFriendsServerList(IntPtr self, AppId iApp, [In] [Out] ref MatchMakingKeyValuePair[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse);

		// Token: 0x0600038D RID: 909 RVA: 0x0000592D File Offset: 0x00003B2D
		internal HServerListRequest RequestFriendsServerList(AppId iApp, [In] [Out] ref MatchMakingKeyValuePair[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse)
		{
			return ISteamMatchmakingServers._RequestFriendsServerList(this.Self, iApp, ref ppchFilters, nFilters, pRequestServersResponse);
		}

		// Token: 0x0600038E RID: 910
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestFavoritesServerList")]
		private static extern HServerListRequest _RequestFavoritesServerList(IntPtr self, AppId iApp, [In] [Out] ref MatchMakingKeyValuePair[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse);

		// Token: 0x0600038F RID: 911 RVA: 0x0000593F File Offset: 0x00003B3F
		internal HServerListRequest RequestFavoritesServerList(AppId iApp, [In] [Out] ref MatchMakingKeyValuePair[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse)
		{
			return ISteamMatchmakingServers._RequestFavoritesServerList(this.Self, iApp, ref ppchFilters, nFilters, pRequestServersResponse);
		}

		// Token: 0x06000390 RID: 912
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestHistoryServerList")]
		private static extern HServerListRequest _RequestHistoryServerList(IntPtr self, AppId iApp, [In] [Out] ref MatchMakingKeyValuePair[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse);

		// Token: 0x06000391 RID: 913 RVA: 0x00005951 File Offset: 0x00003B51
		internal HServerListRequest RequestHistoryServerList(AppId iApp, [In] [Out] ref MatchMakingKeyValuePair[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse)
		{
			return ISteamMatchmakingServers._RequestHistoryServerList(this.Self, iApp, ref ppchFilters, nFilters, pRequestServersResponse);
		}

		// Token: 0x06000392 RID: 914
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestSpectatorServerList")]
		private static extern HServerListRequest _RequestSpectatorServerList(IntPtr self, AppId iApp, [In] [Out] ref MatchMakingKeyValuePair[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse);

		// Token: 0x06000393 RID: 915 RVA: 0x00005963 File Offset: 0x00003B63
		internal HServerListRequest RequestSpectatorServerList(AppId iApp, [In] [Out] ref MatchMakingKeyValuePair[] ppchFilters, uint nFilters, IntPtr pRequestServersResponse)
		{
			return ISteamMatchmakingServers._RequestSpectatorServerList(this.Self, iApp, ref ppchFilters, nFilters, pRequestServersResponse);
		}

		// Token: 0x06000394 RID: 916
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_ReleaseRequest")]
		private static extern void _ReleaseRequest(IntPtr self, HServerListRequest hServerListRequest);

		// Token: 0x06000395 RID: 917 RVA: 0x00005975 File Offset: 0x00003B75
		internal void ReleaseRequest(HServerListRequest hServerListRequest)
		{
			ISteamMatchmakingServers._ReleaseRequest(this.Self, hServerListRequest);
		}

		// Token: 0x06000396 RID: 918
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_GetServerDetails")]
		private static extern IntPtr _GetServerDetails(IntPtr self, HServerListRequest hRequest, int iServer);

		// Token: 0x06000397 RID: 919 RVA: 0x00005983 File Offset: 0x00003B83
		internal gameserveritem_t GetServerDetails(HServerListRequest hRequest, int iServer)
		{
			return ISteamMatchmakingServers._GetServerDetails(this.Self, hRequest, iServer).ToType<gameserveritem_t>();
		}

		// Token: 0x06000398 RID: 920
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_CancelQuery")]
		private static extern void _CancelQuery(IntPtr self, HServerListRequest hRequest);

		// Token: 0x06000399 RID: 921 RVA: 0x00005997 File Offset: 0x00003B97
		internal void CancelQuery(HServerListRequest hRequest)
		{
			ISteamMatchmakingServers._CancelQuery(this.Self, hRequest);
		}

		// Token: 0x0600039A RID: 922
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RefreshQuery")]
		private static extern void _RefreshQuery(IntPtr self, HServerListRequest hRequest);

		// Token: 0x0600039B RID: 923 RVA: 0x000059A5 File Offset: 0x00003BA5
		internal void RefreshQuery(HServerListRequest hRequest)
		{
			ISteamMatchmakingServers._RefreshQuery(this.Self, hRequest);
		}

		// Token: 0x0600039C RID: 924
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_IsRefreshing")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsRefreshing(IntPtr self, HServerListRequest hRequest);

		// Token: 0x0600039D RID: 925 RVA: 0x000059B3 File Offset: 0x00003BB3
		internal bool IsRefreshing(HServerListRequest hRequest)
		{
			return ISteamMatchmakingServers._IsRefreshing(this.Self, hRequest);
		}

		// Token: 0x0600039E RID: 926
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_GetServerCount")]
		private static extern int _GetServerCount(IntPtr self, HServerListRequest hRequest);

		// Token: 0x0600039F RID: 927 RVA: 0x000059C1 File Offset: 0x00003BC1
		internal int GetServerCount(HServerListRequest hRequest)
		{
			return ISteamMatchmakingServers._GetServerCount(this.Self, hRequest);
		}

		// Token: 0x060003A0 RID: 928
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RefreshServer")]
		private static extern void _RefreshServer(IntPtr self, HServerListRequest hRequest, int iServer);

		// Token: 0x060003A1 RID: 929 RVA: 0x000059CF File Offset: 0x00003BCF
		internal void RefreshServer(HServerListRequest hRequest, int iServer)
		{
			ISteamMatchmakingServers._RefreshServer(this.Self, hRequest, iServer);
		}

		// Token: 0x060003A2 RID: 930
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_PingServer")]
		private static extern HServerQuery _PingServer(IntPtr self, uint unIP, ushort usPort, IntPtr pRequestServersResponse);

		// Token: 0x060003A3 RID: 931 RVA: 0x000059DE File Offset: 0x00003BDE
		internal HServerQuery PingServer(uint unIP, ushort usPort, IntPtr pRequestServersResponse)
		{
			return ISteamMatchmakingServers._PingServer(this.Self, unIP, usPort, pRequestServersResponse);
		}

		// Token: 0x060003A4 RID: 932
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_PlayerDetails")]
		private static extern HServerQuery _PlayerDetails(IntPtr self, uint unIP, ushort usPort, IntPtr pRequestServersResponse);

		// Token: 0x060003A5 RID: 933 RVA: 0x000059EE File Offset: 0x00003BEE
		internal HServerQuery PlayerDetails(uint unIP, ushort usPort, IntPtr pRequestServersResponse)
		{
			return ISteamMatchmakingServers._PlayerDetails(this.Self, unIP, usPort, pRequestServersResponse);
		}

		// Token: 0x060003A6 RID: 934
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_ServerRules")]
		private static extern HServerQuery _ServerRules(IntPtr self, uint unIP, ushort usPort, IntPtr pRequestServersResponse);

		// Token: 0x060003A7 RID: 935 RVA: 0x000059FE File Offset: 0x00003BFE
		internal HServerQuery ServerRules(uint unIP, ushort usPort, IntPtr pRequestServersResponse)
		{
			return ISteamMatchmakingServers._ServerRules(this.Self, unIP, usPort, pRequestServersResponse);
		}

		// Token: 0x060003A8 RID: 936
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingServers_CancelServerQuery")]
		private static extern void _CancelServerQuery(IntPtr self, HServerQuery hServerQuery);

		// Token: 0x060003A9 RID: 937 RVA: 0x00005A0E File Offset: 0x00003C0E
		internal void CancelServerQuery(HServerQuery hServerQuery)
		{
			ISteamMatchmakingServers._CancelServerQuery(this.Self, hServerQuery);
		}
	}
}
