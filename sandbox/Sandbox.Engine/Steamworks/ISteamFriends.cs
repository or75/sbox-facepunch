using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x02000023 RID: 35
	internal class ISteamFriends : SteamInterface
	{
		// Token: 0x060000C2 RID: 194 RVA: 0x00004180 File Offset: 0x00002380
		internal ISteamFriends(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x060000C3 RID: 195
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamFriends_v017();

		// Token: 0x060000C4 RID: 196 RVA: 0x0000418F File Offset: 0x0000238F
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamFriends.SteamAPI_SteamFriends_v017();
		}

		// Token: 0x060000C5 RID: 197
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetPersonaName")]
		private static extern Utf8StringPointer _GetPersonaName(IntPtr self);

		// Token: 0x060000C6 RID: 198 RVA: 0x00004196 File Offset: 0x00002396
		internal string GetPersonaName()
		{
			return ISteamFriends._GetPersonaName(this.Self);
		}

		// Token: 0x060000C7 RID: 199
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_SetPersonaName")]
		private static extern SteamAPICall_t _SetPersonaName(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPersonaName);

		// Token: 0x060000C8 RID: 200 RVA: 0x000041A8 File Offset: 0x000023A8
		internal CallResult<SetPersonaNameResponse_t> SetPersonaName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPersonaName)
		{
			return new CallResult<SetPersonaNameResponse_t>(ISteamFriends._SetPersonaName(this.Self, pchPersonaName), base.IsServer);
		}

		// Token: 0x060000C9 RID: 201
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetPersonaState")]
		private static extern FriendState _GetPersonaState(IntPtr self);

		// Token: 0x060000CA RID: 202 RVA: 0x000041C1 File Offset: 0x000023C1
		internal FriendState GetPersonaState()
		{
			return ISteamFriends._GetPersonaState(this.Self);
		}

		// Token: 0x060000CB RID: 203
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCount")]
		private static extern int _GetFriendCount(IntPtr self, int iFriendFlags);

		// Token: 0x060000CC RID: 204 RVA: 0x000041CE File Offset: 0x000023CE
		internal int GetFriendCount(int iFriendFlags)
		{
			return ISteamFriends._GetFriendCount(this.Self, iFriendFlags);
		}

		// Token: 0x060000CD RID: 205
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendByIndex")]
		private static extern SteamId _GetFriendByIndex(IntPtr self, int iFriend, int iFriendFlags);

		// Token: 0x060000CE RID: 206 RVA: 0x000041DC File Offset: 0x000023DC
		internal SteamId GetFriendByIndex(int iFriend, int iFriendFlags)
		{
			return ISteamFriends._GetFriendByIndex(this.Self, iFriend, iFriendFlags);
		}

		// Token: 0x060000CF RID: 207
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRelationship")]
		private static extern Relationship _GetFriendRelationship(IntPtr self, SteamId steamIDFriend);

		// Token: 0x060000D0 RID: 208 RVA: 0x000041EB File Offset: 0x000023EB
		internal Relationship GetFriendRelationship(SteamId steamIDFriend)
		{
			return ISteamFriends._GetFriendRelationship(this.Self, steamIDFriend);
		}

		// Token: 0x060000D1 RID: 209
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaState")]
		private static extern FriendState _GetFriendPersonaState(IntPtr self, SteamId steamIDFriend);

		// Token: 0x060000D2 RID: 210 RVA: 0x000041F9 File Offset: 0x000023F9
		internal FriendState GetFriendPersonaState(SteamId steamIDFriend)
		{
			return ISteamFriends._GetFriendPersonaState(this.Self, steamIDFriend);
		}

		// Token: 0x060000D3 RID: 211
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaName")]
		private static extern Utf8StringPointer _GetFriendPersonaName(IntPtr self, SteamId steamIDFriend);

		// Token: 0x060000D4 RID: 212 RVA: 0x00004207 File Offset: 0x00002407
		internal string GetFriendPersonaName(SteamId steamIDFriend)
		{
			return ISteamFriends._GetFriendPersonaName(this.Self, steamIDFriend);
		}

		// Token: 0x060000D5 RID: 213
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendGamePlayed")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetFriendGamePlayed(IntPtr self, SteamId steamIDFriend, ref FriendGameInfo_t pFriendGameInfo);

		// Token: 0x060000D6 RID: 214 RVA: 0x0000421A File Offset: 0x0000241A
		internal bool GetFriendGamePlayed(SteamId steamIDFriend, ref FriendGameInfo_t pFriendGameInfo)
		{
			return ISteamFriends._GetFriendGamePlayed(this.Self, steamIDFriend, ref pFriendGameInfo);
		}

		// Token: 0x060000D7 RID: 215
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaNameHistory")]
		private static extern Utf8StringPointer _GetFriendPersonaNameHistory(IntPtr self, SteamId steamIDFriend, int iPersonaName);

		// Token: 0x060000D8 RID: 216 RVA: 0x00004229 File Offset: 0x00002429
		internal string GetFriendPersonaNameHistory(SteamId steamIDFriend, int iPersonaName)
		{
			return ISteamFriends._GetFriendPersonaNameHistory(this.Self, steamIDFriend, iPersonaName);
		}

		// Token: 0x060000D9 RID: 217
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendSteamLevel")]
		private static extern int _GetFriendSteamLevel(IntPtr self, SteamId steamIDFriend);

		// Token: 0x060000DA RID: 218 RVA: 0x0000423D File Offset: 0x0000243D
		internal int GetFriendSteamLevel(SteamId steamIDFriend)
		{
			return ISteamFriends._GetFriendSteamLevel(this.Self, steamIDFriend);
		}

		// Token: 0x060000DB RID: 219
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetPlayerNickname")]
		private static extern Utf8StringPointer _GetPlayerNickname(IntPtr self, SteamId steamIDPlayer);

		// Token: 0x060000DC RID: 220 RVA: 0x0000424B File Offset: 0x0000244B
		internal string GetPlayerNickname(SteamId steamIDPlayer)
		{
			return ISteamFriends._GetPlayerNickname(this.Self, steamIDPlayer);
		}

		// Token: 0x060000DD RID: 221
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupCount")]
		private static extern int _GetFriendsGroupCount(IntPtr self);

		// Token: 0x060000DE RID: 222 RVA: 0x0000425E File Offset: 0x0000245E
		internal int GetFriendsGroupCount()
		{
			return ISteamFriends._GetFriendsGroupCount(this.Self);
		}

		// Token: 0x060000DF RID: 223
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupIDByIndex")]
		private static extern FriendsGroupID_t _GetFriendsGroupIDByIndex(IntPtr self, int iFG);

		// Token: 0x060000E0 RID: 224 RVA: 0x0000426B File Offset: 0x0000246B
		internal FriendsGroupID_t GetFriendsGroupIDByIndex(int iFG)
		{
			return ISteamFriends._GetFriendsGroupIDByIndex(this.Self, iFG);
		}

		// Token: 0x060000E1 RID: 225
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupName")]
		private static extern Utf8StringPointer _GetFriendsGroupName(IntPtr self, FriendsGroupID_t friendsGroupID);

		// Token: 0x060000E2 RID: 226 RVA: 0x00004279 File Offset: 0x00002479
		internal string GetFriendsGroupName(FriendsGroupID_t friendsGroupID)
		{
			return ISteamFriends._GetFriendsGroupName(this.Self, friendsGroupID);
		}

		// Token: 0x060000E3 RID: 227
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupMembersCount")]
		private static extern int _GetFriendsGroupMembersCount(IntPtr self, FriendsGroupID_t friendsGroupID);

		// Token: 0x060000E4 RID: 228 RVA: 0x0000428C File Offset: 0x0000248C
		internal int GetFriendsGroupMembersCount(FriendsGroupID_t friendsGroupID)
		{
			return ISteamFriends._GetFriendsGroupMembersCount(this.Self, friendsGroupID);
		}

		// Token: 0x060000E5 RID: 229
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupMembersList")]
		private static extern void _GetFriendsGroupMembersList(IntPtr self, FriendsGroupID_t friendsGroupID, [In] [Out] SteamId[] pOutSteamIDMembers, int nMembersCount);

		// Token: 0x060000E6 RID: 230 RVA: 0x0000429A File Offset: 0x0000249A
		internal void GetFriendsGroupMembersList(FriendsGroupID_t friendsGroupID, [In] [Out] SteamId[] pOutSteamIDMembers, int nMembersCount)
		{
			ISteamFriends._GetFriendsGroupMembersList(this.Self, friendsGroupID, pOutSteamIDMembers, nMembersCount);
		}

		// Token: 0x060000E7 RID: 231
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_HasFriend")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _HasFriend(IntPtr self, SteamId steamIDFriend, int iFriendFlags);

		// Token: 0x060000E8 RID: 232 RVA: 0x000042AA File Offset: 0x000024AA
		internal bool HasFriend(SteamId steamIDFriend, int iFriendFlags)
		{
			return ISteamFriends._HasFriend(this.Self, steamIDFriend, iFriendFlags);
		}

		// Token: 0x060000E9 RID: 233
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetClanCount")]
		private static extern int _GetClanCount(IntPtr self);

		// Token: 0x060000EA RID: 234 RVA: 0x000042B9 File Offset: 0x000024B9
		internal int GetClanCount()
		{
			return ISteamFriends._GetClanCount(this.Self);
		}

		// Token: 0x060000EB RID: 235
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetClanByIndex")]
		private static extern SteamId _GetClanByIndex(IntPtr self, int iClan);

		// Token: 0x060000EC RID: 236 RVA: 0x000042C6 File Offset: 0x000024C6
		internal SteamId GetClanByIndex(int iClan)
		{
			return ISteamFriends._GetClanByIndex(this.Self, iClan);
		}

		// Token: 0x060000ED RID: 237
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetClanName")]
		private static extern Utf8StringPointer _GetClanName(IntPtr self, SteamId steamIDClan);

		// Token: 0x060000EE RID: 238 RVA: 0x000042D4 File Offset: 0x000024D4
		internal string GetClanName(SteamId steamIDClan)
		{
			return ISteamFriends._GetClanName(this.Self, steamIDClan);
		}

		// Token: 0x060000EF RID: 239
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetClanTag")]
		private static extern Utf8StringPointer _GetClanTag(IntPtr self, SteamId steamIDClan);

		// Token: 0x060000F0 RID: 240 RVA: 0x000042E7 File Offset: 0x000024E7
		internal string GetClanTag(SteamId steamIDClan)
		{
			return ISteamFriends._GetClanTag(this.Self, steamIDClan);
		}

		// Token: 0x060000F1 RID: 241
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetClanActivityCounts")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetClanActivityCounts(IntPtr self, SteamId steamIDClan, ref int pnOnline, ref int pnInGame, ref int pnChatting);

		// Token: 0x060000F2 RID: 242 RVA: 0x000042FA File Offset: 0x000024FA
		internal bool GetClanActivityCounts(SteamId steamIDClan, ref int pnOnline, ref int pnInGame, ref int pnChatting)
		{
			return ISteamFriends._GetClanActivityCounts(this.Self, steamIDClan, ref pnOnline, ref pnInGame, ref pnChatting);
		}

		// Token: 0x060000F3 RID: 243
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_DownloadClanActivityCounts")]
		private static extern SteamAPICall_t _DownloadClanActivityCounts(IntPtr self, [In] [Out] SteamId[] psteamIDClans, int cClansToRequest);

		// Token: 0x060000F4 RID: 244 RVA: 0x0000430C File Offset: 0x0000250C
		internal CallResult<DownloadClanActivityCountsResult_t> DownloadClanActivityCounts([In] [Out] SteamId[] psteamIDClans, int cClansToRequest)
		{
			return new CallResult<DownloadClanActivityCountsResult_t>(ISteamFriends._DownloadClanActivityCounts(this.Self, psteamIDClans, cClansToRequest), base.IsServer);
		}

		// Token: 0x060000F5 RID: 245
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCountFromSource")]
		private static extern int _GetFriendCountFromSource(IntPtr self, SteamId steamIDSource);

		// Token: 0x060000F6 RID: 246 RVA: 0x00004326 File Offset: 0x00002526
		internal int GetFriendCountFromSource(SteamId steamIDSource)
		{
			return ISteamFriends._GetFriendCountFromSource(this.Self, steamIDSource);
		}

		// Token: 0x060000F7 RID: 247
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendFromSourceByIndex")]
		private static extern SteamId _GetFriendFromSourceByIndex(IntPtr self, SteamId steamIDSource, int iFriend);

		// Token: 0x060000F8 RID: 248 RVA: 0x00004334 File Offset: 0x00002534
		internal SteamId GetFriendFromSourceByIndex(SteamId steamIDSource, int iFriend)
		{
			return ISteamFriends._GetFriendFromSourceByIndex(this.Self, steamIDSource, iFriend);
		}

		// Token: 0x060000F9 RID: 249
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_IsUserInSource")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsUserInSource(IntPtr self, SteamId steamIDUser, SteamId steamIDSource);

		// Token: 0x060000FA RID: 250 RVA: 0x00004343 File Offset: 0x00002543
		internal bool IsUserInSource(SteamId steamIDUser, SteamId steamIDSource)
		{
			return ISteamFriends._IsUserInSource(this.Self, steamIDUser, steamIDSource);
		}

		// Token: 0x060000FB RID: 251
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_SetInGameVoiceSpeaking")]
		private static extern void _SetInGameVoiceSpeaking(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.U1)] bool bSpeaking);

		// Token: 0x060000FC RID: 252 RVA: 0x00004352 File Offset: 0x00002552
		internal void SetInGameVoiceSpeaking(SteamId steamIDUser, [MarshalAs(UnmanagedType.U1)] bool bSpeaking)
		{
			ISteamFriends._SetInGameVoiceSpeaking(this.Self, steamIDUser, bSpeaking);
		}

		// Token: 0x060000FD RID: 253
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlay")]
		private static extern void _ActivateGameOverlay(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchDialog);

		// Token: 0x060000FE RID: 254 RVA: 0x00004361 File Offset: 0x00002561
		internal void ActivateGameOverlay([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchDialog)
		{
			ISteamFriends._ActivateGameOverlay(this.Self, pchDialog);
		}

		// Token: 0x060000FF RID: 255
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToUser")]
		private static extern void _ActivateGameOverlayToUser(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchDialog, SteamId steamID);

		// Token: 0x06000100 RID: 256 RVA: 0x0000436F File Offset: 0x0000256F
		internal void ActivateGameOverlayToUser([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchDialog, SteamId steamID)
		{
			ISteamFriends._ActivateGameOverlayToUser(this.Self, pchDialog, steamID);
		}

		// Token: 0x06000101 RID: 257
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToWebPage")]
		private static extern void _ActivateGameOverlayToWebPage(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchURL, ActivateGameOverlayToWebPageMode eMode);

		// Token: 0x06000102 RID: 258 RVA: 0x0000437E File Offset: 0x0000257E
		internal void ActivateGameOverlayToWebPage([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchURL, ActivateGameOverlayToWebPageMode eMode)
		{
			ISteamFriends._ActivateGameOverlayToWebPage(this.Self, pchURL, eMode);
		}

		// Token: 0x06000103 RID: 259
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToStore")]
		private static extern void _ActivateGameOverlayToStore(IntPtr self, AppId nAppID, OverlayToStoreFlag eFlag);

		// Token: 0x06000104 RID: 260 RVA: 0x0000438D File Offset: 0x0000258D
		internal void ActivateGameOverlayToStore(AppId nAppID, OverlayToStoreFlag eFlag)
		{
			ISteamFriends._ActivateGameOverlayToStore(this.Self, nAppID, eFlag);
		}

		// Token: 0x06000105 RID: 261
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_SetPlayedWith")]
		private static extern void _SetPlayedWith(IntPtr self, SteamId steamIDUserPlayedWith);

		// Token: 0x06000106 RID: 262 RVA: 0x0000439C File Offset: 0x0000259C
		internal void SetPlayedWith(SteamId steamIDUserPlayedWith)
		{
			ISteamFriends._SetPlayedWith(this.Self, steamIDUserPlayedWith);
		}

		// Token: 0x06000107 RID: 263
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialog")]
		private static extern void _ActivateGameOverlayInviteDialog(IntPtr self, SteamId steamIDLobby);

		// Token: 0x06000108 RID: 264 RVA: 0x000043AA File Offset: 0x000025AA
		internal void ActivateGameOverlayInviteDialog(SteamId steamIDLobby)
		{
			ISteamFriends._ActivateGameOverlayInviteDialog(this.Self, steamIDLobby);
		}

		// Token: 0x06000109 RID: 265
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetSmallFriendAvatar")]
		private static extern int _GetSmallFriendAvatar(IntPtr self, SteamId steamIDFriend);

		// Token: 0x0600010A RID: 266 RVA: 0x000043B8 File Offset: 0x000025B8
		internal int GetSmallFriendAvatar(SteamId steamIDFriend)
		{
			return ISteamFriends._GetSmallFriendAvatar(this.Self, steamIDFriend);
		}

		// Token: 0x0600010B RID: 267
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetMediumFriendAvatar")]
		private static extern int _GetMediumFriendAvatar(IntPtr self, SteamId steamIDFriend);

		// Token: 0x0600010C RID: 268 RVA: 0x000043C6 File Offset: 0x000025C6
		internal int GetMediumFriendAvatar(SteamId steamIDFriend)
		{
			return ISteamFriends._GetMediumFriendAvatar(this.Self, steamIDFriend);
		}

		// Token: 0x0600010D RID: 269
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetLargeFriendAvatar")]
		private static extern int _GetLargeFriendAvatar(IntPtr self, SteamId steamIDFriend);

		// Token: 0x0600010E RID: 270 RVA: 0x000043D4 File Offset: 0x000025D4
		internal int GetLargeFriendAvatar(SteamId steamIDFriend)
		{
			return ISteamFriends._GetLargeFriendAvatar(this.Self, steamIDFriend);
		}

		// Token: 0x0600010F RID: 271
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_RequestUserInformation")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _RequestUserInformation(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.U1)] bool bRequireNameOnly);

		// Token: 0x06000110 RID: 272 RVA: 0x000043E2 File Offset: 0x000025E2
		internal bool RequestUserInformation(SteamId steamIDUser, [MarshalAs(UnmanagedType.U1)] bool bRequireNameOnly)
		{
			return ISteamFriends._RequestUserInformation(this.Self, steamIDUser, bRequireNameOnly);
		}

		// Token: 0x06000111 RID: 273
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_RequestClanOfficerList")]
		private static extern SteamAPICall_t _RequestClanOfficerList(IntPtr self, SteamId steamIDClan);

		// Token: 0x06000112 RID: 274 RVA: 0x000043F1 File Offset: 0x000025F1
		internal CallResult<ClanOfficerListResponse_t> RequestClanOfficerList(SteamId steamIDClan)
		{
			return new CallResult<ClanOfficerListResponse_t>(ISteamFriends._RequestClanOfficerList(this.Self, steamIDClan), base.IsServer);
		}

		// Token: 0x06000113 RID: 275
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetClanOwner")]
		private static extern SteamId _GetClanOwner(IntPtr self, SteamId steamIDClan);

		// Token: 0x06000114 RID: 276 RVA: 0x0000440A File Offset: 0x0000260A
		internal SteamId GetClanOwner(SteamId steamIDClan)
		{
			return ISteamFriends._GetClanOwner(this.Self, steamIDClan);
		}

		// Token: 0x06000115 RID: 277
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetClanOfficerCount")]
		private static extern int _GetClanOfficerCount(IntPtr self, SteamId steamIDClan);

		// Token: 0x06000116 RID: 278 RVA: 0x00004418 File Offset: 0x00002618
		internal int GetClanOfficerCount(SteamId steamIDClan)
		{
			return ISteamFriends._GetClanOfficerCount(this.Self, steamIDClan);
		}

		// Token: 0x06000117 RID: 279
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetClanOfficerByIndex")]
		private static extern SteamId _GetClanOfficerByIndex(IntPtr self, SteamId steamIDClan, int iOfficer);

		// Token: 0x06000118 RID: 280 RVA: 0x00004426 File Offset: 0x00002626
		internal SteamId GetClanOfficerByIndex(SteamId steamIDClan, int iOfficer)
		{
			return ISteamFriends._GetClanOfficerByIndex(this.Self, steamIDClan, iOfficer);
		}

		// Token: 0x06000119 RID: 281
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetUserRestrictions")]
		private static extern uint _GetUserRestrictions(IntPtr self);

		// Token: 0x0600011A RID: 282 RVA: 0x00004435 File Offset: 0x00002635
		internal uint GetUserRestrictions()
		{
			return ISteamFriends._GetUserRestrictions(this.Self);
		}

		// Token: 0x0600011B RID: 283
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_SetRichPresence")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetRichPresence(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValue);

		// Token: 0x0600011C RID: 284 RVA: 0x00004442 File Offset: 0x00002642
		internal bool SetRichPresence([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValue)
		{
			return ISteamFriends._SetRichPresence(this.Self, pchKey, pchValue);
		}

		// Token: 0x0600011D RID: 285
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_ClearRichPresence")]
		private static extern void _ClearRichPresence(IntPtr self);

		// Token: 0x0600011E RID: 286 RVA: 0x00004451 File Offset: 0x00002651
		internal void ClearRichPresence()
		{
			ISteamFriends._ClearRichPresence(this.Self);
		}

		// Token: 0x0600011F RID: 287
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresence")]
		private static extern Utf8StringPointer _GetFriendRichPresence(IntPtr self, SteamId steamIDFriend, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey);

		// Token: 0x06000120 RID: 288 RVA: 0x0000445E File Offset: 0x0000265E
		internal string GetFriendRichPresence(SteamId steamIDFriend, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey)
		{
			return ISteamFriends._GetFriendRichPresence(this.Self, steamIDFriend, pchKey);
		}

		// Token: 0x06000121 RID: 289
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresenceKeyCount")]
		private static extern int _GetFriendRichPresenceKeyCount(IntPtr self, SteamId steamIDFriend);

		// Token: 0x06000122 RID: 290 RVA: 0x00004472 File Offset: 0x00002672
		internal int GetFriendRichPresenceKeyCount(SteamId steamIDFriend)
		{
			return ISteamFriends._GetFriendRichPresenceKeyCount(this.Self, steamIDFriend);
		}

		// Token: 0x06000123 RID: 291
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresenceKeyByIndex")]
		private static extern Utf8StringPointer _GetFriendRichPresenceKeyByIndex(IntPtr self, SteamId steamIDFriend, int iKey);

		// Token: 0x06000124 RID: 292 RVA: 0x00004480 File Offset: 0x00002680
		internal string GetFriendRichPresenceKeyByIndex(SteamId steamIDFriend, int iKey)
		{
			return ISteamFriends._GetFriendRichPresenceKeyByIndex(this.Self, steamIDFriend, iKey);
		}

		// Token: 0x06000125 RID: 293
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_RequestFriendRichPresence")]
		private static extern void _RequestFriendRichPresence(IntPtr self, SteamId steamIDFriend);

		// Token: 0x06000126 RID: 294 RVA: 0x00004494 File Offset: 0x00002694
		internal void RequestFriendRichPresence(SteamId steamIDFriend)
		{
			ISteamFriends._RequestFriendRichPresence(this.Self, steamIDFriend);
		}

		// Token: 0x06000127 RID: 295
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_InviteUserToGame")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _InviteUserToGame(IntPtr self, SteamId steamIDFriend, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchConnectString);

		// Token: 0x06000128 RID: 296 RVA: 0x000044A2 File Offset: 0x000026A2
		internal bool InviteUserToGame(SteamId steamIDFriend, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchConnectString)
		{
			return ISteamFriends._InviteUserToGame(this.Self, steamIDFriend, pchConnectString);
		}

		// Token: 0x06000129 RID: 297
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetCoplayFriendCount")]
		private static extern int _GetCoplayFriendCount(IntPtr self);

		// Token: 0x0600012A RID: 298 RVA: 0x000044B1 File Offset: 0x000026B1
		internal int GetCoplayFriendCount()
		{
			return ISteamFriends._GetCoplayFriendCount(this.Self);
		}

		// Token: 0x0600012B RID: 299
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetCoplayFriend")]
		private static extern SteamId _GetCoplayFriend(IntPtr self, int iCoplayFriend);

		// Token: 0x0600012C RID: 300 RVA: 0x000044BE File Offset: 0x000026BE
		internal SteamId GetCoplayFriend(int iCoplayFriend)
		{
			return ISteamFriends._GetCoplayFriend(this.Self, iCoplayFriend);
		}

		// Token: 0x0600012D RID: 301
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCoplayTime")]
		private static extern int _GetFriendCoplayTime(IntPtr self, SteamId steamIDFriend);

		// Token: 0x0600012E RID: 302 RVA: 0x000044CC File Offset: 0x000026CC
		internal int GetFriendCoplayTime(SteamId steamIDFriend)
		{
			return ISteamFriends._GetFriendCoplayTime(this.Self, steamIDFriend);
		}

		// Token: 0x0600012F RID: 303
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCoplayGame")]
		private static extern AppId _GetFriendCoplayGame(IntPtr self, SteamId steamIDFriend);

		// Token: 0x06000130 RID: 304 RVA: 0x000044DA File Offset: 0x000026DA
		internal AppId GetFriendCoplayGame(SteamId steamIDFriend)
		{
			return ISteamFriends._GetFriendCoplayGame(this.Self, steamIDFriend);
		}

		// Token: 0x06000131 RID: 305
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_JoinClanChatRoom")]
		private static extern SteamAPICall_t _JoinClanChatRoom(IntPtr self, SteamId steamIDClan);

		// Token: 0x06000132 RID: 306 RVA: 0x000044E8 File Offset: 0x000026E8
		internal CallResult<JoinClanChatRoomCompletionResult_t> JoinClanChatRoom(SteamId steamIDClan)
		{
			return new CallResult<JoinClanChatRoomCompletionResult_t>(ISteamFriends._JoinClanChatRoom(this.Self, steamIDClan), base.IsServer);
		}

		// Token: 0x06000133 RID: 307
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_LeaveClanChatRoom")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _LeaveClanChatRoom(IntPtr self, SteamId steamIDClan);

		// Token: 0x06000134 RID: 308 RVA: 0x00004501 File Offset: 0x00002701
		internal bool LeaveClanChatRoom(SteamId steamIDClan)
		{
			return ISteamFriends._LeaveClanChatRoom(this.Self, steamIDClan);
		}

		// Token: 0x06000135 RID: 309
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetClanChatMemberCount")]
		private static extern int _GetClanChatMemberCount(IntPtr self, SteamId steamIDClan);

		// Token: 0x06000136 RID: 310 RVA: 0x0000450F File Offset: 0x0000270F
		internal int GetClanChatMemberCount(SteamId steamIDClan)
		{
			return ISteamFriends._GetClanChatMemberCount(this.Self, steamIDClan);
		}

		// Token: 0x06000137 RID: 311
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetChatMemberByIndex")]
		private static extern SteamId _GetChatMemberByIndex(IntPtr self, SteamId steamIDClan, int iUser);

		// Token: 0x06000138 RID: 312 RVA: 0x0000451D File Offset: 0x0000271D
		internal SteamId GetChatMemberByIndex(SteamId steamIDClan, int iUser)
		{
			return ISteamFriends._GetChatMemberByIndex(this.Self, steamIDClan, iUser);
		}

		// Token: 0x06000139 RID: 313
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_SendClanChatMessage")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SendClanChatMessage(IntPtr self, SteamId steamIDClanChat, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchText);

		// Token: 0x0600013A RID: 314 RVA: 0x0000452C File Offset: 0x0000272C
		internal bool SendClanChatMessage(SteamId steamIDClanChat, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchText)
		{
			return ISteamFriends._SendClanChatMessage(this.Self, steamIDClanChat, pchText);
		}

		// Token: 0x0600013B RID: 315
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetClanChatMessage")]
		private static extern int _GetClanChatMessage(IntPtr self, SteamId steamIDClanChat, int iMessage, IntPtr prgchText, int cchTextMax, ref ChatEntryType peChatEntryType, ref SteamId psteamidChatter);

		// Token: 0x0600013C RID: 316 RVA: 0x0000453B File Offset: 0x0000273B
		internal int GetClanChatMessage(SteamId steamIDClanChat, int iMessage, IntPtr prgchText, int cchTextMax, ref ChatEntryType peChatEntryType, ref SteamId psteamidChatter)
		{
			return ISteamFriends._GetClanChatMessage(this.Self, steamIDClanChat, iMessage, prgchText, cchTextMax, ref peChatEntryType, ref psteamidChatter);
		}

		// Token: 0x0600013D RID: 317
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_IsClanChatAdmin")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsClanChatAdmin(IntPtr self, SteamId steamIDClanChat, SteamId steamIDUser);

		// Token: 0x0600013E RID: 318 RVA: 0x00004551 File Offset: 0x00002751
		internal bool IsClanChatAdmin(SteamId steamIDClanChat, SteamId steamIDUser)
		{
			return ISteamFriends._IsClanChatAdmin(this.Self, steamIDClanChat, steamIDUser);
		}

		// Token: 0x0600013F RID: 319
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_IsClanChatWindowOpenInSteam")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsClanChatWindowOpenInSteam(IntPtr self, SteamId steamIDClanChat);

		// Token: 0x06000140 RID: 320 RVA: 0x00004560 File Offset: 0x00002760
		internal bool IsClanChatWindowOpenInSteam(SteamId steamIDClanChat)
		{
			return ISteamFriends._IsClanChatWindowOpenInSteam(this.Self, steamIDClanChat);
		}

		// Token: 0x06000141 RID: 321
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_OpenClanChatWindowInSteam")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _OpenClanChatWindowInSteam(IntPtr self, SteamId steamIDClanChat);

		// Token: 0x06000142 RID: 322 RVA: 0x0000456E File Offset: 0x0000276E
		internal bool OpenClanChatWindowInSteam(SteamId steamIDClanChat)
		{
			return ISteamFriends._OpenClanChatWindowInSteam(this.Self, steamIDClanChat);
		}

		// Token: 0x06000143 RID: 323
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_CloseClanChatWindowInSteam")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _CloseClanChatWindowInSteam(IntPtr self, SteamId steamIDClanChat);

		// Token: 0x06000144 RID: 324 RVA: 0x0000457C File Offset: 0x0000277C
		internal bool CloseClanChatWindowInSteam(SteamId steamIDClanChat)
		{
			return ISteamFriends._CloseClanChatWindowInSteam(this.Self, steamIDClanChat);
		}

		// Token: 0x06000145 RID: 325
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_SetListenForFriendsMessages")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetListenForFriendsMessages(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bInterceptEnabled);

		// Token: 0x06000146 RID: 326 RVA: 0x0000458A File Offset: 0x0000278A
		internal bool SetListenForFriendsMessages([MarshalAs(UnmanagedType.U1)] bool bInterceptEnabled)
		{
			return ISteamFriends._SetListenForFriendsMessages(this.Self, bInterceptEnabled);
		}

		// Token: 0x06000147 RID: 327
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_ReplyToFriendMessage")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _ReplyToFriendMessage(IntPtr self, SteamId steamIDFriend, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchMsgToSend);

		// Token: 0x06000148 RID: 328 RVA: 0x00004598 File Offset: 0x00002798
		internal bool ReplyToFriendMessage(SteamId steamIDFriend, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchMsgToSend)
		{
			return ISteamFriends._ReplyToFriendMessage(this.Self, steamIDFriend, pchMsgToSend);
		}

		// Token: 0x06000149 RID: 329
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFriendMessage")]
		private static extern int _GetFriendMessage(IntPtr self, SteamId steamIDFriend, int iMessageID, IntPtr pvData, int cubData, ref ChatEntryType peChatEntryType);

		// Token: 0x0600014A RID: 330 RVA: 0x000045A7 File Offset: 0x000027A7
		internal int GetFriendMessage(SteamId steamIDFriend, int iMessageID, IntPtr pvData, int cubData, ref ChatEntryType peChatEntryType)
		{
			return ISteamFriends._GetFriendMessage(this.Self, steamIDFriend, iMessageID, pvData, cubData, ref peChatEntryType);
		}

		// Token: 0x0600014B RID: 331
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetFollowerCount")]
		private static extern SteamAPICall_t _GetFollowerCount(IntPtr self, SteamId steamID);

		// Token: 0x0600014C RID: 332 RVA: 0x000045BB File Offset: 0x000027BB
		internal CallResult<FriendsGetFollowerCount_t> GetFollowerCount(SteamId steamID)
		{
			return new CallResult<FriendsGetFollowerCount_t>(ISteamFriends._GetFollowerCount(this.Self, steamID), base.IsServer);
		}

		// Token: 0x0600014D RID: 333
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_IsFollowing")]
		private static extern SteamAPICall_t _IsFollowing(IntPtr self, SteamId steamID);

		// Token: 0x0600014E RID: 334 RVA: 0x000045D4 File Offset: 0x000027D4
		internal CallResult<FriendsIsFollowing_t> IsFollowing(SteamId steamID)
		{
			return new CallResult<FriendsIsFollowing_t>(ISteamFriends._IsFollowing(this.Self, steamID), base.IsServer);
		}

		// Token: 0x0600014F RID: 335
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_EnumerateFollowingList")]
		private static extern SteamAPICall_t _EnumerateFollowingList(IntPtr self, uint unStartIndex);

		// Token: 0x06000150 RID: 336 RVA: 0x000045ED File Offset: 0x000027ED
		internal CallResult<FriendsEnumerateFollowingList_t> EnumerateFollowingList(uint unStartIndex)
		{
			return new CallResult<FriendsEnumerateFollowingList_t>(ISteamFriends._EnumerateFollowingList(this.Self, unStartIndex), base.IsServer);
		}

		// Token: 0x06000151 RID: 337
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_IsClanPublic")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsClanPublic(IntPtr self, SteamId steamIDClan);

		// Token: 0x06000152 RID: 338 RVA: 0x00004606 File Offset: 0x00002806
		internal bool IsClanPublic(SteamId steamIDClan)
		{
			return ISteamFriends._IsClanPublic(this.Self, steamIDClan);
		}

		// Token: 0x06000153 RID: 339
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_IsClanOfficialGameGroup")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsClanOfficialGameGroup(IntPtr self, SteamId steamIDClan);

		// Token: 0x06000154 RID: 340 RVA: 0x00004614 File Offset: 0x00002814
		internal bool IsClanOfficialGameGroup(SteamId steamIDClan)
		{
			return ISteamFriends._IsClanOfficialGameGroup(this.Self, steamIDClan);
		}

		// Token: 0x06000155 RID: 341
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_GetNumChatsWithUnreadPriorityMessages")]
		private static extern int _GetNumChatsWithUnreadPriorityMessages(IntPtr self);

		// Token: 0x06000156 RID: 342 RVA: 0x00004622 File Offset: 0x00002822
		internal int GetNumChatsWithUnreadPriorityMessages()
		{
			return ISteamFriends._GetNumChatsWithUnreadPriorityMessages(this.Self);
		}

		// Token: 0x06000157 RID: 343
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayRemotePlayTogetherInviteDialog")]
		private static extern void _ActivateGameOverlayRemotePlayTogetherInviteDialog(IntPtr self, SteamId steamIDLobby);

		// Token: 0x06000158 RID: 344 RVA: 0x0000462F File Offset: 0x0000282F
		internal void ActivateGameOverlayRemotePlayTogetherInviteDialog(SteamId steamIDLobby)
		{
			ISteamFriends._ActivateGameOverlayRemotePlayTogetherInviteDialog(this.Self, steamIDLobby);
		}

		// Token: 0x06000159 RID: 345
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_RegisterProtocolInOverlayBrowser")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _RegisterProtocolInOverlayBrowser(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchProtocol);

		// Token: 0x0600015A RID: 346 RVA: 0x0000463D File Offset: 0x0000283D
		internal bool RegisterProtocolInOverlayBrowser([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchProtocol)
		{
			return ISteamFriends._RegisterProtocolInOverlayBrowser(this.Self, pchProtocol);
		}

		// Token: 0x0600015B RID: 347
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialogConnectString")]
		private static extern void _ActivateGameOverlayInviteDialogConnectString(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchConnectString);

		// Token: 0x0600015C RID: 348 RVA: 0x0000464B File Offset: 0x0000284B
		internal void ActivateGameOverlayInviteDialogConnectString([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchConnectString)
		{
			ISteamFriends._ActivateGameOverlayInviteDialogConnectString(this.Self, pchConnectString);
		}
	}
}
