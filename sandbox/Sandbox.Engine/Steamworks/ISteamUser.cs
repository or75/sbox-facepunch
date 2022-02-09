using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x02000036 RID: 54
	internal class ISteamUser : SteamInterface
	{
		// Token: 0x06000437 RID: 1079 RVA: 0x00005DFF File Offset: 0x00003FFF
		internal ISteamUser(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x06000438 RID: 1080
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamUser_v021();

		// Token: 0x06000439 RID: 1081 RVA: 0x00005E0E File Offset: 0x0000400E
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamUser.SteamAPI_SteamUser_v021();
		}

		// Token: 0x0600043A RID: 1082
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_GetHSteamUser")]
		private static extern HSteamUser _GetHSteamUser(IntPtr self);

		// Token: 0x0600043B RID: 1083 RVA: 0x00005E15 File Offset: 0x00004015
		internal HSteamUser GetHSteamUser()
		{
			return ISteamUser._GetHSteamUser(this.Self);
		}

		// Token: 0x0600043C RID: 1084
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_BLoggedOn")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BLoggedOn(IntPtr self);

		// Token: 0x0600043D RID: 1085 RVA: 0x00005E22 File Offset: 0x00004022
		internal bool BLoggedOn()
		{
			return ISteamUser._BLoggedOn(this.Self);
		}

		// Token: 0x0600043E RID: 1086
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_GetSteamID")]
		private static extern SteamId _GetSteamID(IntPtr self);

		// Token: 0x0600043F RID: 1087 RVA: 0x00005E2F File Offset: 0x0000402F
		internal SteamId GetSteamID()
		{
			return ISteamUser._GetSteamID(this.Self);
		}

		// Token: 0x06000440 RID: 1088
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_InitiateGameConnection_DEPRECATED")]
		private static extern int _InitiateGameConnection_DEPRECATED(IntPtr self, IntPtr pAuthBlob, int cbMaxAuthBlob, SteamId steamIDGameServer, uint unIPServer, ushort usPortServer, [MarshalAs(UnmanagedType.U1)] bool bSecure);

		// Token: 0x06000441 RID: 1089 RVA: 0x00005E3C File Offset: 0x0000403C
		internal int InitiateGameConnection_DEPRECATED(IntPtr pAuthBlob, int cbMaxAuthBlob, SteamId steamIDGameServer, uint unIPServer, ushort usPortServer, [MarshalAs(UnmanagedType.U1)] bool bSecure)
		{
			return ISteamUser._InitiateGameConnection_DEPRECATED(this.Self, pAuthBlob, cbMaxAuthBlob, steamIDGameServer, unIPServer, usPortServer, bSecure);
		}

		// Token: 0x06000442 RID: 1090
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_TerminateGameConnection_DEPRECATED")]
		private static extern void _TerminateGameConnection_DEPRECATED(IntPtr self, uint unIPServer, ushort usPortServer);

		// Token: 0x06000443 RID: 1091 RVA: 0x00005E52 File Offset: 0x00004052
		internal void TerminateGameConnection_DEPRECATED(uint unIPServer, ushort usPortServer)
		{
			ISteamUser._TerminateGameConnection_DEPRECATED(this.Self, unIPServer, usPortServer);
		}

		// Token: 0x06000444 RID: 1092
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_TrackAppUsageEvent")]
		private static extern void _TrackAppUsageEvent(IntPtr self, GameId gameID, int eAppUsageEvent, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchExtraInfo);

		// Token: 0x06000445 RID: 1093 RVA: 0x00005E61 File Offset: 0x00004061
		internal void TrackAppUsageEvent(GameId gameID, int eAppUsageEvent, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchExtraInfo)
		{
			ISteamUser._TrackAppUsageEvent(this.Self, gameID, eAppUsageEvent, pchExtraInfo);
		}

		// Token: 0x06000446 RID: 1094
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_GetUserDataFolder")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetUserDataFolder(IntPtr self, IntPtr pchBuffer, int cubBuffer);

		// Token: 0x06000447 RID: 1095 RVA: 0x00005E74 File Offset: 0x00004074
		internal bool GetUserDataFolder(out string pchBuffer)
		{
			Helpers.Memory mempchBuffer = Helpers.TakeMemory();
			bool result;
			try
			{
				bool flag = ISteamUser._GetUserDataFolder(this.Self, mempchBuffer, 32768);
				pchBuffer = Helpers.MemoryToString(mempchBuffer);
				result = flag;
			}
			finally
			{
				((IDisposable)mempchBuffer).Dispose();
			}
			return result;
		}

		// Token: 0x06000448 RID: 1096
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_StartVoiceRecording")]
		private static extern void _StartVoiceRecording(IntPtr self);

		// Token: 0x06000449 RID: 1097 RVA: 0x00005ED0 File Offset: 0x000040D0
		internal void StartVoiceRecording()
		{
			ISteamUser._StartVoiceRecording(this.Self);
		}

		// Token: 0x0600044A RID: 1098
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_StopVoiceRecording")]
		private static extern void _StopVoiceRecording(IntPtr self);

		// Token: 0x0600044B RID: 1099 RVA: 0x00005EDD File Offset: 0x000040DD
		internal void StopVoiceRecording()
		{
			ISteamUser._StopVoiceRecording(this.Self);
		}

		// Token: 0x0600044C RID: 1100
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_GetAvailableVoice")]
		private static extern VoiceResult _GetAvailableVoice(IntPtr self, ref uint pcbCompressed, ref uint pcbUncompressed_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated);

		// Token: 0x0600044D RID: 1101 RVA: 0x00005EEA File Offset: 0x000040EA
		internal VoiceResult GetAvailableVoice(ref uint pcbCompressed, ref uint pcbUncompressed_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated)
		{
			return ISteamUser._GetAvailableVoice(this.Self, ref pcbCompressed, ref pcbUncompressed_Deprecated, nUncompressedVoiceDesiredSampleRate_Deprecated);
		}

		// Token: 0x0600044E RID: 1102
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_GetVoice")]
		private static extern VoiceResult _GetVoice(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bWantCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, ref uint nBytesWritten, [MarshalAs(UnmanagedType.U1)] bool bWantUncompressed_Deprecated, IntPtr pUncompressedDestBuffer_Deprecated, uint cbUncompressedDestBufferSize_Deprecated, ref uint nUncompressBytesWritten_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated);

		// Token: 0x0600044F RID: 1103 RVA: 0x00005EFC File Offset: 0x000040FC
		internal VoiceResult GetVoice([MarshalAs(UnmanagedType.U1)] bool bWantCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, ref uint nBytesWritten, [MarshalAs(UnmanagedType.U1)] bool bWantUncompressed_Deprecated, IntPtr pUncompressedDestBuffer_Deprecated, uint cbUncompressedDestBufferSize_Deprecated, ref uint nUncompressBytesWritten_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated)
		{
			return ISteamUser._GetVoice(this.Self, bWantCompressed, pDestBuffer, cbDestBufferSize, ref nBytesWritten, bWantUncompressed_Deprecated, pUncompressedDestBuffer_Deprecated, cbUncompressedDestBufferSize_Deprecated, ref nUncompressBytesWritten_Deprecated, nUncompressedVoiceDesiredSampleRate_Deprecated);
		}

		// Token: 0x06000450 RID: 1104
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_DecompressVoice")]
		private static extern VoiceResult _DecompressVoice(IntPtr self, IntPtr pCompressed, uint cbCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, ref uint nBytesWritten, uint nDesiredSampleRate);

		// Token: 0x06000451 RID: 1105 RVA: 0x00005F23 File Offset: 0x00004123
		internal VoiceResult DecompressVoice(IntPtr pCompressed, uint cbCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, ref uint nBytesWritten, uint nDesiredSampleRate)
		{
			return ISteamUser._DecompressVoice(this.Self, pCompressed, cbCompressed, pDestBuffer, cbDestBufferSize, ref nBytesWritten, nDesiredSampleRate);
		}

		// Token: 0x06000452 RID: 1106
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_GetVoiceOptimalSampleRate")]
		private static extern uint _GetVoiceOptimalSampleRate(IntPtr self);

		// Token: 0x06000453 RID: 1107 RVA: 0x00005F39 File Offset: 0x00004139
		internal uint GetVoiceOptimalSampleRate()
		{
			return ISteamUser._GetVoiceOptimalSampleRate(this.Self);
		}

		// Token: 0x06000454 RID: 1108
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_GetAuthSessionTicket")]
		private static extern HAuthTicket _GetAuthSessionTicket(IntPtr self, IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket);

		// Token: 0x06000455 RID: 1109 RVA: 0x00005F46 File Offset: 0x00004146
		internal HAuthTicket GetAuthSessionTicket(IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket)
		{
			return ISteamUser._GetAuthSessionTicket(this.Self, pTicket, cbMaxTicket, ref pcbTicket);
		}

		// Token: 0x06000456 RID: 1110
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_BeginAuthSession")]
		private static extern BeginAuthResult _BeginAuthSession(IntPtr self, IntPtr pAuthTicket, int cbAuthTicket, SteamId steamID);

		// Token: 0x06000457 RID: 1111 RVA: 0x00005F56 File Offset: 0x00004156
		internal BeginAuthResult BeginAuthSession(IntPtr pAuthTicket, int cbAuthTicket, SteamId steamID)
		{
			return ISteamUser._BeginAuthSession(this.Self, pAuthTicket, cbAuthTicket, steamID);
		}

		// Token: 0x06000458 RID: 1112
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_EndAuthSession")]
		private static extern void _EndAuthSession(IntPtr self, SteamId steamID);

		// Token: 0x06000459 RID: 1113 RVA: 0x00005F66 File Offset: 0x00004166
		internal void EndAuthSession(SteamId steamID)
		{
			ISteamUser._EndAuthSession(this.Self, steamID);
		}

		// Token: 0x0600045A RID: 1114
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_CancelAuthTicket")]
		private static extern void _CancelAuthTicket(IntPtr self, HAuthTicket hAuthTicket);

		// Token: 0x0600045B RID: 1115 RVA: 0x00005F74 File Offset: 0x00004174
		internal void CancelAuthTicket(HAuthTicket hAuthTicket)
		{
			ISteamUser._CancelAuthTicket(this.Self, hAuthTicket);
		}

		// Token: 0x0600045C RID: 1116
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_UserHasLicenseForApp")]
		private static extern UserHasLicenseForAppResult _UserHasLicenseForApp(IntPtr self, SteamId steamID, AppId appID);

		// Token: 0x0600045D RID: 1117 RVA: 0x00005F82 File Offset: 0x00004182
		internal UserHasLicenseForAppResult UserHasLicenseForApp(SteamId steamID, AppId appID)
		{
			return ISteamUser._UserHasLicenseForApp(this.Self, steamID, appID);
		}

		// Token: 0x0600045E RID: 1118
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_BIsBehindNAT")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsBehindNAT(IntPtr self);

		// Token: 0x0600045F RID: 1119 RVA: 0x00005F91 File Offset: 0x00004191
		internal bool BIsBehindNAT()
		{
			return ISteamUser._BIsBehindNAT(this.Self);
		}

		// Token: 0x06000460 RID: 1120
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_AdvertiseGame")]
		private static extern void _AdvertiseGame(IntPtr self, SteamId steamIDGameServer, uint unIPServer, ushort usPortServer);

		// Token: 0x06000461 RID: 1121 RVA: 0x00005F9E File Offset: 0x0000419E
		internal void AdvertiseGame(SteamId steamIDGameServer, uint unIPServer, ushort usPortServer)
		{
			ISteamUser._AdvertiseGame(this.Self, steamIDGameServer, unIPServer, usPortServer);
		}

		// Token: 0x06000462 RID: 1122
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_RequestEncryptedAppTicket")]
		private static extern SteamAPICall_t _RequestEncryptedAppTicket(IntPtr self, IntPtr pDataToInclude, int cbDataToInclude);

		// Token: 0x06000463 RID: 1123 RVA: 0x00005FAE File Offset: 0x000041AE
		internal CallResult<EncryptedAppTicketResponse_t> RequestEncryptedAppTicket(IntPtr pDataToInclude, int cbDataToInclude)
		{
			return new CallResult<EncryptedAppTicketResponse_t>(ISteamUser._RequestEncryptedAppTicket(this.Self, pDataToInclude, cbDataToInclude), base.IsServer);
		}

		// Token: 0x06000464 RID: 1124
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_GetEncryptedAppTicket")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetEncryptedAppTicket(IntPtr self, IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket);

		// Token: 0x06000465 RID: 1125 RVA: 0x00005FC8 File Offset: 0x000041C8
		internal bool GetEncryptedAppTicket(IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket)
		{
			return ISteamUser._GetEncryptedAppTicket(this.Self, pTicket, cbMaxTicket, ref pcbTicket);
		}

		// Token: 0x06000466 RID: 1126
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_GetGameBadgeLevel")]
		private static extern int _GetGameBadgeLevel(IntPtr self, int nSeries, [MarshalAs(UnmanagedType.U1)] bool bFoil);

		// Token: 0x06000467 RID: 1127 RVA: 0x00005FD8 File Offset: 0x000041D8
		internal int GetGameBadgeLevel(int nSeries, [MarshalAs(UnmanagedType.U1)] bool bFoil)
		{
			return ISteamUser._GetGameBadgeLevel(this.Self, nSeries, bFoil);
		}

		// Token: 0x06000468 RID: 1128
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_GetPlayerSteamLevel")]
		private static extern int _GetPlayerSteamLevel(IntPtr self);

		// Token: 0x06000469 RID: 1129 RVA: 0x00005FE7 File Offset: 0x000041E7
		internal int GetPlayerSteamLevel()
		{
			return ISteamUser._GetPlayerSteamLevel(this.Self);
		}

		// Token: 0x0600046A RID: 1130
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_RequestStoreAuthURL")]
		private static extern SteamAPICall_t _RequestStoreAuthURL(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchRedirectURL);

		// Token: 0x0600046B RID: 1131 RVA: 0x00005FF4 File Offset: 0x000041F4
		internal CallResult<StoreAuthURLResponse_t> RequestStoreAuthURL([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchRedirectURL)
		{
			return new CallResult<StoreAuthURLResponse_t>(ISteamUser._RequestStoreAuthURL(this.Self, pchRedirectURL), base.IsServer);
		}

		// Token: 0x0600046C RID: 1132
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneVerified")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsPhoneVerified(IntPtr self);

		// Token: 0x0600046D RID: 1133 RVA: 0x0000600D File Offset: 0x0000420D
		internal bool BIsPhoneVerified()
		{
			return ISteamUser._BIsPhoneVerified(this.Self);
		}

		// Token: 0x0600046E RID: 1134
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_BIsTwoFactorEnabled")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsTwoFactorEnabled(IntPtr self);

		// Token: 0x0600046F RID: 1135 RVA: 0x0000601A File Offset: 0x0000421A
		internal bool BIsTwoFactorEnabled()
		{
			return ISteamUser._BIsTwoFactorEnabled(this.Self);
		}

		// Token: 0x06000470 RID: 1136
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneIdentifying")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsPhoneIdentifying(IntPtr self);

		// Token: 0x06000471 RID: 1137 RVA: 0x00006027 File Offset: 0x00004227
		internal bool BIsPhoneIdentifying()
		{
			return ISteamUser._BIsPhoneIdentifying(this.Self);
		}

		// Token: 0x06000472 RID: 1138
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneRequiringVerification")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsPhoneRequiringVerification(IntPtr self);

		// Token: 0x06000473 RID: 1139 RVA: 0x00006034 File Offset: 0x00004234
		internal bool BIsPhoneRequiringVerification()
		{
			return ISteamUser._BIsPhoneRequiringVerification(this.Self);
		}

		// Token: 0x06000474 RID: 1140
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_GetMarketEligibility")]
		private static extern SteamAPICall_t _GetMarketEligibility(IntPtr self);

		// Token: 0x06000475 RID: 1141 RVA: 0x00006041 File Offset: 0x00004241
		internal CallResult<MarketEligibilityResponse_t> GetMarketEligibility()
		{
			return new CallResult<MarketEligibilityResponse_t>(ISteamUser._GetMarketEligibility(this.Self), base.IsServer);
		}

		// Token: 0x06000476 RID: 1142
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_GetDurationControl")]
		private static extern SteamAPICall_t _GetDurationControl(IntPtr self);

		// Token: 0x06000477 RID: 1143 RVA: 0x00006059 File Offset: 0x00004259
		internal CallResult<DurationControl_t> GetDurationControl()
		{
			return new CallResult<DurationControl_t>(ISteamUser._GetDurationControl(this.Self), base.IsServer);
		}

		// Token: 0x06000478 RID: 1144
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUser_BSetDurationControlOnlineState")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BSetDurationControlOnlineState(IntPtr self, DurationControlOnlineState eNewState);

		// Token: 0x06000479 RID: 1145 RVA: 0x00006071 File Offset: 0x00004271
		internal bool BSetDurationControlOnlineState(DurationControlOnlineState eNewState)
		{
			return ISteamUser._BSetDurationControlOnlineState(this.Self, eNewState);
		}
	}
}
