using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x02000037 RID: 55
	internal class ISteamUserStats : SteamInterface
	{
		// Token: 0x0600047A RID: 1146 RVA: 0x0000607F File Offset: 0x0000427F
		internal ISteamUserStats(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x0600047B RID: 1147
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamUserStats_v012();

		// Token: 0x0600047C RID: 1148 RVA: 0x0000608E File Offset: 0x0000428E
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamUserStats.SteamAPI_SteamUserStats_v012();
		}

		// Token: 0x0600047D RID: 1149
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_RequestCurrentStats")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _RequestCurrentStats(IntPtr self);

		// Token: 0x0600047E RID: 1150 RVA: 0x00006095 File Offset: 0x00004295
		internal bool RequestCurrentStats()
		{
			return ISteamUserStats._RequestCurrentStats(this.Self);
		}

		// Token: 0x0600047F RID: 1151
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetStatInt32")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetStat(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref int pData);

		// Token: 0x06000480 RID: 1152 RVA: 0x000060A2 File Offset: 0x000042A2
		internal bool GetStat([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref int pData)
		{
			return ISteamUserStats._GetStat(this.Self, pchName, ref pData);
		}

		// Token: 0x06000481 RID: 1153
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetStatFloat")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetStat(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref float pData);

		// Token: 0x06000482 RID: 1154 RVA: 0x000060B1 File Offset: 0x000042B1
		internal bool GetStat([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref float pData)
		{
			return ISteamUserStats._GetStat(this.Self, pchName, ref pData);
		}

		// Token: 0x06000483 RID: 1155
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_SetStatInt32")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetStat(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, int nData);

		// Token: 0x06000484 RID: 1156 RVA: 0x000060C0 File Offset: 0x000042C0
		internal bool SetStat([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, int nData)
		{
			return ISteamUserStats._SetStat(this.Self, pchName, nData);
		}

		// Token: 0x06000485 RID: 1157
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_SetStatFloat")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetStat(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, float fData);

		// Token: 0x06000486 RID: 1158 RVA: 0x000060CF File Offset: 0x000042CF
		internal bool SetStat([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, float fData)
		{
			return ISteamUserStats._SetStat(this.Self, pchName, fData);
		}

		// Token: 0x06000487 RID: 1159
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_UpdateAvgRateStat")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _UpdateAvgRateStat(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, float flCountThisSession, double dSessionLength);

		// Token: 0x06000488 RID: 1160 RVA: 0x000060DE File Offset: 0x000042DE
		internal bool UpdateAvgRateStat([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, float flCountThisSession, double dSessionLength)
		{
			return ISteamUserStats._UpdateAvgRateStat(this.Self, pchName, flCountThisSession, dSessionLength);
		}

		// Token: 0x06000489 RID: 1161
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievement")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetAchievement(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, [MarshalAs(UnmanagedType.U1)] ref bool pbAchieved);

		// Token: 0x0600048A RID: 1162 RVA: 0x000060EE File Offset: 0x000042EE
		internal bool GetAchievement([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, [MarshalAs(UnmanagedType.U1)] ref bool pbAchieved)
		{
			return ISteamUserStats._GetAchievement(this.Self, pchName, ref pbAchieved);
		}

		// Token: 0x0600048B RID: 1163
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_SetAchievement")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetAchievement(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName);

		// Token: 0x0600048C RID: 1164 RVA: 0x000060FD File Offset: 0x000042FD
		internal bool SetAchievement([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName)
		{
			return ISteamUserStats._SetAchievement(this.Self, pchName);
		}

		// Token: 0x0600048D RID: 1165
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_ClearAchievement")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _ClearAchievement(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName);

		// Token: 0x0600048E RID: 1166 RVA: 0x0000610B File Offset: 0x0000430B
		internal bool ClearAchievement([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName)
		{
			return ISteamUserStats._ClearAchievement(this.Self, pchName);
		}

		// Token: 0x0600048F RID: 1167
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementAndUnlockTime")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetAchievementAndUnlockTime(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, [MarshalAs(UnmanagedType.U1)] ref bool pbAchieved, ref uint punUnlockTime);

		// Token: 0x06000490 RID: 1168 RVA: 0x00006119 File Offset: 0x00004319
		internal bool GetAchievementAndUnlockTime([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, [MarshalAs(UnmanagedType.U1)] ref bool pbAchieved, ref uint punUnlockTime)
		{
			return ISteamUserStats._GetAchievementAndUnlockTime(this.Self, pchName, ref pbAchieved, ref punUnlockTime);
		}

		// Token: 0x06000491 RID: 1169
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_StoreStats")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _StoreStats(IntPtr self);

		// Token: 0x06000492 RID: 1170 RVA: 0x00006129 File Offset: 0x00004329
		internal bool StoreStats()
		{
			return ISteamUserStats._StoreStats(this.Self);
		}

		// Token: 0x06000493 RID: 1171
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementIcon")]
		private static extern int _GetAchievementIcon(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName);

		// Token: 0x06000494 RID: 1172 RVA: 0x00006136 File Offset: 0x00004336
		internal int GetAchievementIcon([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName)
		{
			return ISteamUserStats._GetAchievementIcon(this.Self, pchName);
		}

		// Token: 0x06000495 RID: 1173
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementDisplayAttribute")]
		private static extern Utf8StringPointer _GetAchievementDisplayAttribute(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey);

		// Token: 0x06000496 RID: 1174 RVA: 0x00006144 File Offset: 0x00004344
		internal string GetAchievementDisplayAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey)
		{
			return ISteamUserStats._GetAchievementDisplayAttribute(this.Self, pchName, pchKey);
		}

		// Token: 0x06000497 RID: 1175
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_IndicateAchievementProgress")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IndicateAchievementProgress(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, uint nCurProgress, uint nMaxProgress);

		// Token: 0x06000498 RID: 1176 RVA: 0x00006158 File Offset: 0x00004358
		internal bool IndicateAchievementProgress([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, uint nCurProgress, uint nMaxProgress)
		{
			return ISteamUserStats._IndicateAchievementProgress(this.Self, pchName, nCurProgress, nMaxProgress);
		}

		// Token: 0x06000499 RID: 1177
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetNumAchievements")]
		private static extern uint _GetNumAchievements(IntPtr self);

		// Token: 0x0600049A RID: 1178 RVA: 0x00006168 File Offset: 0x00004368
		internal uint GetNumAchievements()
		{
			return ISteamUserStats._GetNumAchievements(this.Self);
		}

		// Token: 0x0600049B RID: 1179
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementName")]
		private static extern Utf8StringPointer _GetAchievementName(IntPtr self, uint iAchievement);

		// Token: 0x0600049C RID: 1180 RVA: 0x00006175 File Offset: 0x00004375
		internal string GetAchievementName(uint iAchievement)
		{
			return ISteamUserStats._GetAchievementName(this.Self, iAchievement);
		}

		// Token: 0x0600049D RID: 1181
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_RequestUserStats")]
		private static extern SteamAPICall_t _RequestUserStats(IntPtr self, SteamId steamIDUser);

		// Token: 0x0600049E RID: 1182 RVA: 0x00006188 File Offset: 0x00004388
		internal CallResult<UserStatsReceived_t> RequestUserStats(SteamId steamIDUser)
		{
			return new CallResult<UserStatsReceived_t>(ISteamUserStats._RequestUserStats(this.Self, steamIDUser), base.IsServer);
		}

		// Token: 0x0600049F RID: 1183
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetUserStatInt32")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetUserStat(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref int pData);

		// Token: 0x060004A0 RID: 1184 RVA: 0x000061A1 File Offset: 0x000043A1
		internal bool GetUserStat(SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref int pData)
		{
			return ISteamUserStats._GetUserStat(this.Self, steamIDUser, pchName, ref pData);
		}

		// Token: 0x060004A1 RID: 1185
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetUserStatFloat")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetUserStat(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref float pData);

		// Token: 0x060004A2 RID: 1186 RVA: 0x000061B1 File Offset: 0x000043B1
		internal bool GetUserStat(SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref float pData)
		{
			return ISteamUserStats._GetUserStat(this.Self, steamIDUser, pchName, ref pData);
		}

		// Token: 0x060004A3 RID: 1187
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetUserAchievement")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetUserAchievement(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, [MarshalAs(UnmanagedType.U1)] ref bool pbAchieved);

		// Token: 0x060004A4 RID: 1188 RVA: 0x000061C1 File Offset: 0x000043C1
		internal bool GetUserAchievement(SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, [MarshalAs(UnmanagedType.U1)] ref bool pbAchieved)
		{
			return ISteamUserStats._GetUserAchievement(this.Self, steamIDUser, pchName, ref pbAchieved);
		}

		// Token: 0x060004A5 RID: 1189
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetUserAchievementAndUnlockTime")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetUserAchievementAndUnlockTime(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, [MarshalAs(UnmanagedType.U1)] ref bool pbAchieved, ref uint punUnlockTime);

		// Token: 0x060004A6 RID: 1190 RVA: 0x000061D1 File Offset: 0x000043D1
		internal bool GetUserAchievementAndUnlockTime(SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, [MarshalAs(UnmanagedType.U1)] ref bool pbAchieved, ref uint punUnlockTime)
		{
			return ISteamUserStats._GetUserAchievementAndUnlockTime(this.Self, steamIDUser, pchName, ref pbAchieved, ref punUnlockTime);
		}

		// Token: 0x060004A7 RID: 1191
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_ResetAllStats")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _ResetAllStats(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bAchievementsToo);

		// Token: 0x060004A8 RID: 1192 RVA: 0x000061E3 File Offset: 0x000043E3
		internal bool ResetAllStats([MarshalAs(UnmanagedType.U1)] bool bAchievementsToo)
		{
			return ISteamUserStats._ResetAllStats(this.Self, bAchievementsToo);
		}

		// Token: 0x060004A9 RID: 1193
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_FindOrCreateLeaderboard")]
		private static extern SteamAPICall_t _FindOrCreateLeaderboard(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchLeaderboardName, LeaderboardSort eLeaderboardSortMethod, LeaderboardDisplay eLeaderboardDisplayType);

		// Token: 0x060004AA RID: 1194 RVA: 0x000061F1 File Offset: 0x000043F1
		internal CallResult<LeaderboardFindResult_t> FindOrCreateLeaderboard([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchLeaderboardName, LeaderboardSort eLeaderboardSortMethod, LeaderboardDisplay eLeaderboardDisplayType)
		{
			return new CallResult<LeaderboardFindResult_t>(ISteamUserStats._FindOrCreateLeaderboard(this.Self, pchLeaderboardName, eLeaderboardSortMethod, eLeaderboardDisplayType), base.IsServer);
		}

		// Token: 0x060004AB RID: 1195
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_FindLeaderboard")]
		private static extern SteamAPICall_t _FindLeaderboard(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchLeaderboardName);

		// Token: 0x060004AC RID: 1196 RVA: 0x0000620C File Offset: 0x0000440C
		internal CallResult<LeaderboardFindResult_t> FindLeaderboard([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchLeaderboardName)
		{
			return new CallResult<LeaderboardFindResult_t>(ISteamUserStats._FindLeaderboard(this.Self, pchLeaderboardName), base.IsServer);
		}

		// Token: 0x060004AD RID: 1197
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardName")]
		private static extern Utf8StringPointer _GetLeaderboardName(IntPtr self, SteamLeaderboard_t hSteamLeaderboard);

		// Token: 0x060004AE RID: 1198 RVA: 0x00006225 File Offset: 0x00004425
		internal string GetLeaderboardName(SteamLeaderboard_t hSteamLeaderboard)
		{
			return ISteamUserStats._GetLeaderboardName(this.Self, hSteamLeaderboard);
		}

		// Token: 0x060004AF RID: 1199
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardEntryCount")]
		private static extern int _GetLeaderboardEntryCount(IntPtr self, SteamLeaderboard_t hSteamLeaderboard);

		// Token: 0x060004B0 RID: 1200 RVA: 0x00006238 File Offset: 0x00004438
		internal int GetLeaderboardEntryCount(SteamLeaderboard_t hSteamLeaderboard)
		{
			return ISteamUserStats._GetLeaderboardEntryCount(this.Self, hSteamLeaderboard);
		}

		// Token: 0x060004B1 RID: 1201
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardSortMethod")]
		private static extern LeaderboardSort _GetLeaderboardSortMethod(IntPtr self, SteamLeaderboard_t hSteamLeaderboard);

		// Token: 0x060004B2 RID: 1202 RVA: 0x00006246 File Offset: 0x00004446
		internal LeaderboardSort GetLeaderboardSortMethod(SteamLeaderboard_t hSteamLeaderboard)
		{
			return ISteamUserStats._GetLeaderboardSortMethod(this.Self, hSteamLeaderboard);
		}

		// Token: 0x060004B3 RID: 1203
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardDisplayType")]
		private static extern LeaderboardDisplay _GetLeaderboardDisplayType(IntPtr self, SteamLeaderboard_t hSteamLeaderboard);

		// Token: 0x060004B4 RID: 1204 RVA: 0x00006254 File Offset: 0x00004454
		internal LeaderboardDisplay GetLeaderboardDisplayType(SteamLeaderboard_t hSteamLeaderboard)
		{
			return ISteamUserStats._GetLeaderboardDisplayType(this.Self, hSteamLeaderboard);
		}

		// Token: 0x060004B5 RID: 1205
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_DownloadLeaderboardEntries")]
		private static extern SteamAPICall_t _DownloadLeaderboardEntries(IntPtr self, SteamLeaderboard_t hSteamLeaderboard, LeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart, int nRangeEnd);

		// Token: 0x060004B6 RID: 1206 RVA: 0x00006262 File Offset: 0x00004462
		internal CallResult<LeaderboardScoresDownloaded_t> DownloadLeaderboardEntries(SteamLeaderboard_t hSteamLeaderboard, LeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart, int nRangeEnd)
		{
			return new CallResult<LeaderboardScoresDownloaded_t>(ISteamUserStats._DownloadLeaderboardEntries(this.Self, hSteamLeaderboard, eLeaderboardDataRequest, nRangeStart, nRangeEnd), base.IsServer);
		}

		// Token: 0x060004B7 RID: 1207
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_DownloadLeaderboardEntriesForUsers")]
		private static extern SteamAPICall_t _DownloadLeaderboardEntriesForUsers(IntPtr self, SteamLeaderboard_t hSteamLeaderboard, [In] [Out] SteamId[] prgUsers, int cUsers);

		// Token: 0x060004B8 RID: 1208 RVA: 0x0000627F File Offset: 0x0000447F
		internal CallResult<LeaderboardScoresDownloaded_t> DownloadLeaderboardEntriesForUsers(SteamLeaderboard_t hSteamLeaderboard, [In] [Out] SteamId[] prgUsers, int cUsers)
		{
			return new CallResult<LeaderboardScoresDownloaded_t>(ISteamUserStats._DownloadLeaderboardEntriesForUsers(this.Self, hSteamLeaderboard, prgUsers, cUsers), base.IsServer);
		}

		// Token: 0x060004B9 RID: 1209
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetDownloadedLeaderboardEntry")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetDownloadedLeaderboardEntry(IntPtr self, SteamLeaderboardEntries_t hSteamLeaderboardEntries, int index, ref LeaderboardEntry_t pLeaderboardEntry, [In] [Out] int[] pDetails, int cDetailsMax);

		// Token: 0x060004BA RID: 1210 RVA: 0x0000629A File Offset: 0x0000449A
		internal bool GetDownloadedLeaderboardEntry(SteamLeaderboardEntries_t hSteamLeaderboardEntries, int index, ref LeaderboardEntry_t pLeaderboardEntry, [In] [Out] int[] pDetails, int cDetailsMax)
		{
			return ISteamUserStats._GetDownloadedLeaderboardEntry(this.Self, hSteamLeaderboardEntries, index, ref pLeaderboardEntry, pDetails, cDetailsMax);
		}

		// Token: 0x060004BB RID: 1211
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_UploadLeaderboardScore")]
		private static extern SteamAPICall_t _UploadLeaderboardScore(IntPtr self, SteamLeaderboard_t hSteamLeaderboard, LeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int nScore, [In] [Out] int[] pScoreDetails, int cScoreDetailsCount);

		// Token: 0x060004BC RID: 1212 RVA: 0x000062AE File Offset: 0x000044AE
		internal CallResult<LeaderboardScoreUploaded_t> UploadLeaderboardScore(SteamLeaderboard_t hSteamLeaderboard, LeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int nScore, [In] [Out] int[] pScoreDetails, int cScoreDetailsCount)
		{
			return new CallResult<LeaderboardScoreUploaded_t>(ISteamUserStats._UploadLeaderboardScore(this.Self, hSteamLeaderboard, eLeaderboardUploadScoreMethod, nScore, pScoreDetails, cScoreDetailsCount), base.IsServer);
		}

		// Token: 0x060004BD RID: 1213
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_AttachLeaderboardUGC")]
		private static extern SteamAPICall_t _AttachLeaderboardUGC(IntPtr self, SteamLeaderboard_t hSteamLeaderboard, UGCHandle_t hUGC);

		// Token: 0x060004BE RID: 1214 RVA: 0x000062CD File Offset: 0x000044CD
		internal CallResult<LeaderboardUGCSet_t> AttachLeaderboardUGC(SteamLeaderboard_t hSteamLeaderboard, UGCHandle_t hUGC)
		{
			return new CallResult<LeaderboardUGCSet_t>(ISteamUserStats._AttachLeaderboardUGC(this.Self, hSteamLeaderboard, hUGC), base.IsServer);
		}

		// Token: 0x060004BF RID: 1215
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetNumberOfCurrentPlayers")]
		private static extern SteamAPICall_t _GetNumberOfCurrentPlayers(IntPtr self);

		// Token: 0x060004C0 RID: 1216 RVA: 0x000062E7 File Offset: 0x000044E7
		internal CallResult<NumberOfCurrentPlayers_t> GetNumberOfCurrentPlayers()
		{
			return new CallResult<NumberOfCurrentPlayers_t>(ISteamUserStats._GetNumberOfCurrentPlayers(this.Self), base.IsServer);
		}

		// Token: 0x060004C1 RID: 1217
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_RequestGlobalAchievementPercentages")]
		private static extern SteamAPICall_t _RequestGlobalAchievementPercentages(IntPtr self);

		// Token: 0x060004C2 RID: 1218 RVA: 0x000062FF File Offset: 0x000044FF
		internal CallResult<GlobalAchievementPercentagesReady_t> RequestGlobalAchievementPercentages()
		{
			return new CallResult<GlobalAchievementPercentagesReady_t>(ISteamUserStats._RequestGlobalAchievementPercentages(this.Self), base.IsServer);
		}

		// Token: 0x060004C3 RID: 1219
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetMostAchievedAchievementInfo")]
		private static extern int _GetMostAchievedAchievementInfo(IntPtr self, IntPtr pchName, uint unNameBufLen, ref float pflPercent, [MarshalAs(UnmanagedType.U1)] ref bool pbAchieved);

		// Token: 0x060004C4 RID: 1220 RVA: 0x00006318 File Offset: 0x00004518
		internal int GetMostAchievedAchievementInfo(out string pchName, ref float pflPercent, [MarshalAs(UnmanagedType.U1)] ref bool pbAchieved)
		{
			Helpers.Memory mempchName = Helpers.TakeMemory();
			int result;
			try
			{
				int num = ISteamUserStats._GetMostAchievedAchievementInfo(this.Self, mempchName, 32768U, ref pflPercent, ref pbAchieved);
				pchName = Helpers.MemoryToString(mempchName);
				result = num;
			}
			finally
			{
				((IDisposable)mempchName).Dispose();
			}
			return result;
		}

		// Token: 0x060004C5 RID: 1221
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetNextMostAchievedAchievementInfo")]
		private static extern int _GetNextMostAchievedAchievementInfo(IntPtr self, int iIteratorPrevious, IntPtr pchName, uint unNameBufLen, ref float pflPercent, [MarshalAs(UnmanagedType.U1)] ref bool pbAchieved);

		// Token: 0x060004C6 RID: 1222 RVA: 0x00006374 File Offset: 0x00004574
		internal int GetNextMostAchievedAchievementInfo(int iIteratorPrevious, out string pchName, ref float pflPercent, [MarshalAs(UnmanagedType.U1)] ref bool pbAchieved)
		{
			Helpers.Memory mempchName = Helpers.TakeMemory();
			int result;
			try
			{
				int num = ISteamUserStats._GetNextMostAchievedAchievementInfo(this.Self, iIteratorPrevious, mempchName, 32768U, ref pflPercent, ref pbAchieved);
				pchName = Helpers.MemoryToString(mempchName);
				result = num;
			}
			finally
			{
				((IDisposable)mempchName).Dispose();
			}
			return result;
		}

		// Token: 0x060004C7 RID: 1223
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementAchievedPercent")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetAchievementAchievedPercent(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref float pflPercent);

		// Token: 0x060004C8 RID: 1224 RVA: 0x000063D4 File Offset: 0x000045D4
		internal bool GetAchievementAchievedPercent([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref float pflPercent)
		{
			return ISteamUserStats._GetAchievementAchievedPercent(this.Self, pchName, ref pflPercent);
		}

		// Token: 0x060004C9 RID: 1225
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_RequestGlobalStats")]
		private static extern SteamAPICall_t _RequestGlobalStats(IntPtr self, int nHistoryDays);

		// Token: 0x060004CA RID: 1226 RVA: 0x000063E3 File Offset: 0x000045E3
		internal CallResult<GlobalStatsReceived_t> RequestGlobalStats(int nHistoryDays)
		{
			return new CallResult<GlobalStatsReceived_t>(ISteamUserStats._RequestGlobalStats(this.Self, nHistoryDays), base.IsServer);
		}

		// Token: 0x060004CB RID: 1227
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatInt64")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetGlobalStat(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchStatName, ref long pData);

		// Token: 0x060004CC RID: 1228 RVA: 0x000063FC File Offset: 0x000045FC
		internal bool GetGlobalStat([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchStatName, ref long pData)
		{
			return ISteamUserStats._GetGlobalStat(this.Self, pchStatName, ref pData);
		}

		// Token: 0x060004CD RID: 1229
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatDouble")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetGlobalStat(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchStatName, ref double pData);

		// Token: 0x060004CE RID: 1230 RVA: 0x0000640B File Offset: 0x0000460B
		internal bool GetGlobalStat([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchStatName, ref double pData)
		{
			return ISteamUserStats._GetGlobalStat(this.Self, pchStatName, ref pData);
		}

		// Token: 0x060004CF RID: 1231
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatHistoryInt64")]
		private static extern int _GetGlobalStatHistory(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchStatName, [In] [Out] long[] pData, uint cubData);

		// Token: 0x060004D0 RID: 1232 RVA: 0x0000641A File Offset: 0x0000461A
		internal int GetGlobalStatHistory([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchStatName, [In] [Out] long[] pData, uint cubData)
		{
			return ISteamUserStats._GetGlobalStatHistory(this.Self, pchStatName, pData, cubData);
		}

		// Token: 0x060004D1 RID: 1233
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatHistoryDouble")]
		private static extern int _GetGlobalStatHistory(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchStatName, [In] [Out] double[] pData, uint cubData);

		// Token: 0x060004D2 RID: 1234 RVA: 0x0000642A File Offset: 0x0000462A
		internal int GetGlobalStatHistory([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchStatName, [In] [Out] double[] pData, uint cubData)
		{
			return ISteamUserStats._GetGlobalStatHistory(this.Self, pchStatName, pData, cubData);
		}

		// Token: 0x060004D3 RID: 1235
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementProgressLimitsInt32")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetAchievementProgressLimits(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref int pnMinProgress, ref int pnMaxProgress);

		// Token: 0x060004D4 RID: 1236 RVA: 0x0000643A File Offset: 0x0000463A
		internal bool GetAchievementProgressLimits([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref int pnMinProgress, ref int pnMaxProgress)
		{
			return ISteamUserStats._GetAchievementProgressLimits(this.Self, pchName, ref pnMinProgress, ref pnMaxProgress);
		}

		// Token: 0x060004D5 RID: 1237
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementProgressLimitsFloat")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetAchievementProgressLimits(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref float pfMinProgress, ref float pfMaxProgress);

		// Token: 0x060004D6 RID: 1238 RVA: 0x0000644A File Offset: 0x0000464A
		internal bool GetAchievementProgressLimits([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref float pfMinProgress, ref float pfMaxProgress)
		{
			return ISteamUserStats._GetAchievementProgressLimits(this.Self, pchName, ref pfMinProgress, ref pfMaxProgress);
		}
	}
}
