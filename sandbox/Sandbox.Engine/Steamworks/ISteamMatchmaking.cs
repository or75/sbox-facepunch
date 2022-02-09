using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x0200002B RID: 43
	internal class ISteamMatchmaking : SteamInterface
	{
		// Token: 0x0600031C RID: 796 RVA: 0x00005502 File Offset: 0x00003702
		internal ISteamMatchmaking(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x0600031D RID: 797
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamMatchmaking_v009();

		// Token: 0x0600031E RID: 798 RVA: 0x00005511 File Offset: 0x00003711
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamMatchmaking.SteamAPI_SteamMatchmaking_v009();
		}

		// Token: 0x0600031F RID: 799
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_GetFavoriteGameCount")]
		private static extern int _GetFavoriteGameCount(IntPtr self);

		// Token: 0x06000320 RID: 800 RVA: 0x00005518 File Offset: 0x00003718
		internal int GetFavoriteGameCount()
		{
			return ISteamMatchmaking._GetFavoriteGameCount(this.Self);
		}

		// Token: 0x06000321 RID: 801
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_GetFavoriteGame")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetFavoriteGame(IntPtr self, int iGame, ref AppId pnAppID, ref uint pnIP, ref ushort pnConnPort, ref ushort pnQueryPort, ref uint punFlags, ref uint pRTime32LastPlayedOnServer);

		// Token: 0x06000322 RID: 802 RVA: 0x00005525 File Offset: 0x00003725
		internal bool GetFavoriteGame(int iGame, ref AppId pnAppID, ref uint pnIP, ref ushort pnConnPort, ref ushort pnQueryPort, ref uint punFlags, ref uint pRTime32LastPlayedOnServer)
		{
			return ISteamMatchmaking._GetFavoriteGame(this.Self, iGame, ref pnAppID, ref pnIP, ref pnConnPort, ref pnQueryPort, ref punFlags, ref pRTime32LastPlayedOnServer);
		}

		// Token: 0x06000323 RID: 803
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_AddFavoriteGame")]
		private static extern int _AddFavoriteGame(IntPtr self, AppId nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags, uint rTime32LastPlayedOnServer);

		// Token: 0x06000324 RID: 804 RVA: 0x0000553D File Offset: 0x0000373D
		internal int AddFavoriteGame(AppId nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags, uint rTime32LastPlayedOnServer)
		{
			return ISteamMatchmaking._AddFavoriteGame(this.Self, nAppID, nIP, nConnPort, nQueryPort, unFlags, rTime32LastPlayedOnServer);
		}

		// Token: 0x06000325 RID: 805
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_RemoveFavoriteGame")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _RemoveFavoriteGame(IntPtr self, AppId nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags);

		// Token: 0x06000326 RID: 806 RVA: 0x00005553 File Offset: 0x00003753
		internal bool RemoveFavoriteGame(AppId nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags)
		{
			return ISteamMatchmaking._RemoveFavoriteGame(this.Self, nAppID, nIP, nConnPort, nQueryPort, unFlags);
		}

		// Token: 0x06000327 RID: 807
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_RequestLobbyList")]
		private static extern SteamAPICall_t _RequestLobbyList(IntPtr self);

		// Token: 0x06000328 RID: 808 RVA: 0x00005567 File Offset: 0x00003767
		internal CallResult<LobbyMatchList_t> RequestLobbyList()
		{
			return new CallResult<LobbyMatchList_t>(ISteamMatchmaking._RequestLobbyList(this.Self), base.IsServer);
		}

		// Token: 0x06000329 RID: 809
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListStringFilter")]
		private static extern void _AddRequestLobbyListStringFilter(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKeyToMatch, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValueToMatch, LobbyComparison eComparisonType);

		// Token: 0x0600032A RID: 810 RVA: 0x0000557F File Offset: 0x0000377F
		internal void AddRequestLobbyListStringFilter([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKeyToMatch, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValueToMatch, LobbyComparison eComparisonType)
		{
			ISteamMatchmaking._AddRequestLobbyListStringFilter(this.Self, pchKeyToMatch, pchValueToMatch, eComparisonType);
		}

		// Token: 0x0600032B RID: 811
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListNumericalFilter")]
		private static extern void _AddRequestLobbyListNumericalFilter(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKeyToMatch, int nValueToMatch, LobbyComparison eComparisonType);

		// Token: 0x0600032C RID: 812 RVA: 0x0000558F File Offset: 0x0000378F
		internal void AddRequestLobbyListNumericalFilter([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKeyToMatch, int nValueToMatch, LobbyComparison eComparisonType)
		{
			ISteamMatchmaking._AddRequestLobbyListNumericalFilter(this.Self, pchKeyToMatch, nValueToMatch, eComparisonType);
		}

		// Token: 0x0600032D RID: 813
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListNearValueFilter")]
		private static extern void _AddRequestLobbyListNearValueFilter(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKeyToMatch, int nValueToBeCloseTo);

		// Token: 0x0600032E RID: 814 RVA: 0x0000559F File Offset: 0x0000379F
		internal void AddRequestLobbyListNearValueFilter([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKeyToMatch, int nValueToBeCloseTo)
		{
			ISteamMatchmaking._AddRequestLobbyListNearValueFilter(this.Self, pchKeyToMatch, nValueToBeCloseTo);
		}

		// Token: 0x0600032F RID: 815
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable")]
		private static extern void _AddRequestLobbyListFilterSlotsAvailable(IntPtr self, int nSlotsAvailable);

		// Token: 0x06000330 RID: 816 RVA: 0x000055AE File Offset: 0x000037AE
		internal void AddRequestLobbyListFilterSlotsAvailable(int nSlotsAvailable)
		{
			ISteamMatchmaking._AddRequestLobbyListFilterSlotsAvailable(this.Self, nSlotsAvailable);
		}

		// Token: 0x06000331 RID: 817
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListDistanceFilter")]
		private static extern void _AddRequestLobbyListDistanceFilter(IntPtr self, LobbyDistanceFilter eLobbyDistanceFilter);

		// Token: 0x06000332 RID: 818 RVA: 0x000055BC File Offset: 0x000037BC
		internal void AddRequestLobbyListDistanceFilter(LobbyDistanceFilter eLobbyDistanceFilter)
		{
			ISteamMatchmaking._AddRequestLobbyListDistanceFilter(this.Self, eLobbyDistanceFilter);
		}

		// Token: 0x06000333 RID: 819
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListResultCountFilter")]
		private static extern void _AddRequestLobbyListResultCountFilter(IntPtr self, int cMaxResults);

		// Token: 0x06000334 RID: 820 RVA: 0x000055CA File Offset: 0x000037CA
		internal void AddRequestLobbyListResultCountFilter(int cMaxResults)
		{
			ISteamMatchmaking._AddRequestLobbyListResultCountFilter(this.Self, cMaxResults);
		}

		// Token: 0x06000335 RID: 821
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListCompatibleMembersFilter")]
		private static extern void _AddRequestLobbyListCompatibleMembersFilter(IntPtr self, SteamId steamIDLobby);

		// Token: 0x06000336 RID: 822 RVA: 0x000055D8 File Offset: 0x000037D8
		internal void AddRequestLobbyListCompatibleMembersFilter(SteamId steamIDLobby)
		{
			ISteamMatchmaking._AddRequestLobbyListCompatibleMembersFilter(this.Self, steamIDLobby);
		}

		// Token: 0x06000337 RID: 823
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyByIndex")]
		private static extern SteamId _GetLobbyByIndex(IntPtr self, int iLobby);

		// Token: 0x06000338 RID: 824 RVA: 0x000055E6 File Offset: 0x000037E6
		internal SteamId GetLobbyByIndex(int iLobby)
		{
			return ISteamMatchmaking._GetLobbyByIndex(this.Self, iLobby);
		}

		// Token: 0x06000339 RID: 825
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_CreateLobby")]
		private static extern SteamAPICall_t _CreateLobby(IntPtr self, LobbyType eLobbyType, int cMaxMembers);

		// Token: 0x0600033A RID: 826 RVA: 0x000055F4 File Offset: 0x000037F4
		internal CallResult<LobbyCreated_t> CreateLobby(LobbyType eLobbyType, int cMaxMembers)
		{
			return new CallResult<LobbyCreated_t>(ISteamMatchmaking._CreateLobby(this.Self, eLobbyType, cMaxMembers), base.IsServer);
		}

		// Token: 0x0600033B RID: 827
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_JoinLobby")]
		private static extern SteamAPICall_t _JoinLobby(IntPtr self, SteamId steamIDLobby);

		// Token: 0x0600033C RID: 828 RVA: 0x0000560E File Offset: 0x0000380E
		internal CallResult<LobbyEnter_t> JoinLobby(SteamId steamIDLobby)
		{
			return new CallResult<LobbyEnter_t>(ISteamMatchmaking._JoinLobby(this.Self, steamIDLobby), base.IsServer);
		}

		// Token: 0x0600033D RID: 829
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_LeaveLobby")]
		private static extern void _LeaveLobby(IntPtr self, SteamId steamIDLobby);

		// Token: 0x0600033E RID: 830 RVA: 0x00005627 File Offset: 0x00003827
		internal void LeaveLobby(SteamId steamIDLobby)
		{
			ISteamMatchmaking._LeaveLobby(this.Self, steamIDLobby);
		}

		// Token: 0x0600033F RID: 831
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_InviteUserToLobby")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _InviteUserToLobby(IntPtr self, SteamId steamIDLobby, SteamId steamIDInvitee);

		// Token: 0x06000340 RID: 832 RVA: 0x00005635 File Offset: 0x00003835
		internal bool InviteUserToLobby(SteamId steamIDLobby, SteamId steamIDInvitee)
		{
			return ISteamMatchmaking._InviteUserToLobby(this.Self, steamIDLobby, steamIDInvitee);
		}

		// Token: 0x06000341 RID: 833
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_GetNumLobbyMembers")]
		private static extern int _GetNumLobbyMembers(IntPtr self, SteamId steamIDLobby);

		// Token: 0x06000342 RID: 834 RVA: 0x00005644 File Offset: 0x00003844
		internal int GetNumLobbyMembers(SteamId steamIDLobby)
		{
			return ISteamMatchmaking._GetNumLobbyMembers(this.Self, steamIDLobby);
		}

		// Token: 0x06000343 RID: 835
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyMemberByIndex")]
		private static extern SteamId _GetLobbyMemberByIndex(IntPtr self, SteamId steamIDLobby, int iMember);

		// Token: 0x06000344 RID: 836 RVA: 0x00005652 File Offset: 0x00003852
		internal SteamId GetLobbyMemberByIndex(SteamId steamIDLobby, int iMember)
		{
			return ISteamMatchmaking._GetLobbyMemberByIndex(this.Self, steamIDLobby, iMember);
		}

		// Token: 0x06000345 RID: 837
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyData")]
		private static extern Utf8StringPointer _GetLobbyData(IntPtr self, SteamId steamIDLobby, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey);

		// Token: 0x06000346 RID: 838 RVA: 0x00005661 File Offset: 0x00003861
		internal string GetLobbyData(SteamId steamIDLobby, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey)
		{
			return ISteamMatchmaking._GetLobbyData(this.Self, steamIDLobby, pchKey);
		}

		// Token: 0x06000347 RID: 839
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyData")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetLobbyData(IntPtr self, SteamId steamIDLobby, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValue);

		// Token: 0x06000348 RID: 840 RVA: 0x00005675 File Offset: 0x00003875
		internal bool SetLobbyData(SteamId steamIDLobby, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValue)
		{
			return ISteamMatchmaking._SetLobbyData(this.Self, steamIDLobby, pchKey, pchValue);
		}

		// Token: 0x06000349 RID: 841
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyDataCount")]
		private static extern int _GetLobbyDataCount(IntPtr self, SteamId steamIDLobby);

		// Token: 0x0600034A RID: 842 RVA: 0x00005685 File Offset: 0x00003885
		internal int GetLobbyDataCount(SteamId steamIDLobby)
		{
			return ISteamMatchmaking._GetLobbyDataCount(this.Self, steamIDLobby);
		}

		// Token: 0x0600034B RID: 843
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyDataByIndex")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetLobbyDataByIndex(IntPtr self, SteamId steamIDLobby, int iLobbyData, IntPtr pchKey, int cchKeyBufferSize, IntPtr pchValue, int cchValueBufferSize);

		// Token: 0x0600034C RID: 844 RVA: 0x00005694 File Offset: 0x00003894
		internal bool GetLobbyDataByIndex(SteamId steamIDLobby, int iLobbyData, out string pchKey, out string pchValue)
		{
			Helpers.Memory mempchKey = Helpers.TakeMemory();
			bool result;
			try
			{
				Helpers.Memory mempchValue = Helpers.TakeMemory();
				try
				{
					bool flag = ISteamMatchmaking._GetLobbyDataByIndex(this.Self, steamIDLobby, iLobbyData, mempchKey, 32768, mempchValue, 32768);
					pchKey = Helpers.MemoryToString(mempchKey);
					pchValue = Helpers.MemoryToString(mempchValue);
					result = flag;
				}
				finally
				{
					((IDisposable)mempchValue).Dispose();
				}
			}
			finally
			{
				((IDisposable)mempchKey).Dispose();
			}
			return result;
		}

		// Token: 0x0600034D RID: 845
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_DeleteLobbyData")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _DeleteLobbyData(IntPtr self, SteamId steamIDLobby, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey);

		// Token: 0x0600034E RID: 846 RVA: 0x0000572C File Offset: 0x0000392C
		internal bool DeleteLobbyData(SteamId steamIDLobby, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey)
		{
			return ISteamMatchmaking._DeleteLobbyData(this.Self, steamIDLobby, pchKey);
		}

		// Token: 0x0600034F RID: 847
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyMemberData")]
		private static extern Utf8StringPointer _GetLobbyMemberData(IntPtr self, SteamId steamIDLobby, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey);

		// Token: 0x06000350 RID: 848 RVA: 0x0000573B File Offset: 0x0000393B
		internal string GetLobbyMemberData(SteamId steamIDLobby, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey)
		{
			return ISteamMatchmaking._GetLobbyMemberData(this.Self, steamIDLobby, steamIDUser, pchKey);
		}

		// Token: 0x06000351 RID: 849
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyMemberData")]
		private static extern void _SetLobbyMemberData(IntPtr self, SteamId steamIDLobby, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValue);

		// Token: 0x06000352 RID: 850 RVA: 0x00005750 File Offset: 0x00003950
		internal void SetLobbyMemberData(SteamId steamIDLobby, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValue)
		{
			ISteamMatchmaking._SetLobbyMemberData(this.Self, steamIDLobby, pchKey, pchValue);
		}

		// Token: 0x06000353 RID: 851
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_SendLobbyChatMsg")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SendLobbyChatMsg(IntPtr self, SteamId steamIDLobby, IntPtr pvMsgBody, int cubMsgBody);

		// Token: 0x06000354 RID: 852 RVA: 0x00005760 File Offset: 0x00003960
		internal bool SendLobbyChatMsg(SteamId steamIDLobby, IntPtr pvMsgBody, int cubMsgBody)
		{
			return ISteamMatchmaking._SendLobbyChatMsg(this.Self, steamIDLobby, pvMsgBody, cubMsgBody);
		}

		// Token: 0x06000355 RID: 853
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyChatEntry")]
		private static extern int _GetLobbyChatEntry(IntPtr self, SteamId steamIDLobby, int iChatID, ref SteamId pSteamIDUser, IntPtr pvData, int cubData, ref ChatEntryType peChatEntryType);

		// Token: 0x06000356 RID: 854 RVA: 0x00005770 File Offset: 0x00003970
		internal int GetLobbyChatEntry(SteamId steamIDLobby, int iChatID, ref SteamId pSteamIDUser, IntPtr pvData, int cubData, ref ChatEntryType peChatEntryType)
		{
			return ISteamMatchmaking._GetLobbyChatEntry(this.Self, steamIDLobby, iChatID, ref pSteamIDUser, pvData, cubData, ref peChatEntryType);
		}

		// Token: 0x06000357 RID: 855
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_RequestLobbyData")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _RequestLobbyData(IntPtr self, SteamId steamIDLobby);

		// Token: 0x06000358 RID: 856 RVA: 0x00005786 File Offset: 0x00003986
		internal bool RequestLobbyData(SteamId steamIDLobby)
		{
			return ISteamMatchmaking._RequestLobbyData(this.Self, steamIDLobby);
		}

		// Token: 0x06000359 RID: 857
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyGameServer")]
		private static extern void _SetLobbyGameServer(IntPtr self, SteamId steamIDLobby, uint unGameServerIP, ushort unGameServerPort, SteamId steamIDGameServer);

		// Token: 0x0600035A RID: 858 RVA: 0x00005794 File Offset: 0x00003994
		internal void SetLobbyGameServer(SteamId steamIDLobby, uint unGameServerIP, ushort unGameServerPort, SteamId steamIDGameServer)
		{
			ISteamMatchmaking._SetLobbyGameServer(this.Self, steamIDLobby, unGameServerIP, unGameServerPort, steamIDGameServer);
		}

		// Token: 0x0600035B RID: 859
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyGameServer")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetLobbyGameServer(IntPtr self, SteamId steamIDLobby, ref uint punGameServerIP, ref ushort punGameServerPort, ref SteamId psteamIDGameServer);

		// Token: 0x0600035C RID: 860 RVA: 0x000057A6 File Offset: 0x000039A6
		internal bool GetLobbyGameServer(SteamId steamIDLobby, ref uint punGameServerIP, ref ushort punGameServerPort, ref SteamId psteamIDGameServer)
		{
			return ISteamMatchmaking._GetLobbyGameServer(this.Self, steamIDLobby, ref punGameServerIP, ref punGameServerPort, ref psteamIDGameServer);
		}

		// Token: 0x0600035D RID: 861
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyMemberLimit")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetLobbyMemberLimit(IntPtr self, SteamId steamIDLobby, int cMaxMembers);

		// Token: 0x0600035E RID: 862 RVA: 0x000057B8 File Offset: 0x000039B8
		internal bool SetLobbyMemberLimit(SteamId steamIDLobby, int cMaxMembers)
		{
			return ISteamMatchmaking._SetLobbyMemberLimit(this.Self, steamIDLobby, cMaxMembers);
		}

		// Token: 0x0600035F RID: 863
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyMemberLimit")]
		private static extern int _GetLobbyMemberLimit(IntPtr self, SteamId steamIDLobby);

		// Token: 0x06000360 RID: 864 RVA: 0x000057C7 File Offset: 0x000039C7
		internal int GetLobbyMemberLimit(SteamId steamIDLobby)
		{
			return ISteamMatchmaking._GetLobbyMemberLimit(this.Self, steamIDLobby);
		}

		// Token: 0x06000361 RID: 865
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyType")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetLobbyType(IntPtr self, SteamId steamIDLobby, LobbyType eLobbyType);

		// Token: 0x06000362 RID: 866 RVA: 0x000057D5 File Offset: 0x000039D5
		internal bool SetLobbyType(SteamId steamIDLobby, LobbyType eLobbyType)
		{
			return ISteamMatchmaking._SetLobbyType(this.Self, steamIDLobby, eLobbyType);
		}

		// Token: 0x06000363 RID: 867
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyJoinable")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetLobbyJoinable(IntPtr self, SteamId steamIDLobby, [MarshalAs(UnmanagedType.U1)] bool bLobbyJoinable);

		// Token: 0x06000364 RID: 868 RVA: 0x000057E4 File Offset: 0x000039E4
		internal bool SetLobbyJoinable(SteamId steamIDLobby, [MarshalAs(UnmanagedType.U1)] bool bLobbyJoinable)
		{
			return ISteamMatchmaking._SetLobbyJoinable(this.Self, steamIDLobby, bLobbyJoinable);
		}

		// Token: 0x06000365 RID: 869
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyOwner")]
		private static extern SteamId _GetLobbyOwner(IntPtr self, SteamId steamIDLobby);

		// Token: 0x06000366 RID: 870 RVA: 0x000057F3 File Offset: 0x000039F3
		internal SteamId GetLobbyOwner(SteamId steamIDLobby)
		{
			return ISteamMatchmaking._GetLobbyOwner(this.Self, steamIDLobby);
		}

		// Token: 0x06000367 RID: 871
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyOwner")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetLobbyOwner(IntPtr self, SteamId steamIDLobby, SteamId steamIDNewOwner);

		// Token: 0x06000368 RID: 872 RVA: 0x00005801 File Offset: 0x00003A01
		internal bool SetLobbyOwner(SteamId steamIDLobby, SteamId steamIDNewOwner)
		{
			return ISteamMatchmaking._SetLobbyOwner(this.Self, steamIDLobby, steamIDNewOwner);
		}

		// Token: 0x06000369 RID: 873
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLinkedLobby")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetLinkedLobby(IntPtr self, SteamId steamIDLobby, SteamId steamIDLobbyDependent);

		// Token: 0x0600036A RID: 874 RVA: 0x00005810 File Offset: 0x00003A10
		internal bool SetLinkedLobby(SteamId steamIDLobby, SteamId steamIDLobbyDependent)
		{
			return ISteamMatchmaking._SetLinkedLobby(this.Self, steamIDLobby, steamIDLobbyDependent);
		}
	}
}
