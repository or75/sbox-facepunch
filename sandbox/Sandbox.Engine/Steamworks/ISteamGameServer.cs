using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x02000025 RID: 37
	internal class ISteamGameServer : SteamInterface
	{
		// Token: 0x0600017C RID: 380 RVA: 0x00004788 File Offset: 0x00002988
		internal ISteamGameServer(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x0600017D RID: 381
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamGameServer_v014();

		// Token: 0x0600017E RID: 382 RVA: 0x00004797 File Offset: 0x00002997
		internal override IntPtr GetServerInterfacePointer()
		{
			return ISteamGameServer.SteamAPI_SteamGameServer_v014();
		}

		// Token: 0x0600017F RID: 383
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetProduct")]
		private static extern void _SetProduct(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszProduct);

		// Token: 0x06000180 RID: 384 RVA: 0x0000479E File Offset: 0x0000299E
		internal void SetProduct([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszProduct)
		{
			ISteamGameServer._SetProduct(this.Self, pszProduct);
		}

		// Token: 0x06000181 RID: 385
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetGameDescription")]
		private static extern void _SetGameDescription(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszGameDescription);

		// Token: 0x06000182 RID: 386 RVA: 0x000047AC File Offset: 0x000029AC
		internal void SetGameDescription([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszGameDescription)
		{
			ISteamGameServer._SetGameDescription(this.Self, pszGameDescription);
		}

		// Token: 0x06000183 RID: 387
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetModDir")]
		private static extern void _SetModDir(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszModDir);

		// Token: 0x06000184 RID: 388 RVA: 0x000047BA File Offset: 0x000029BA
		internal void SetModDir([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszModDir)
		{
			ISteamGameServer._SetModDir(this.Self, pszModDir);
		}

		// Token: 0x06000185 RID: 389
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetDedicatedServer")]
		private static extern void _SetDedicatedServer(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bDedicated);

		// Token: 0x06000186 RID: 390 RVA: 0x000047C8 File Offset: 0x000029C8
		internal void SetDedicatedServer([MarshalAs(UnmanagedType.U1)] bool bDedicated)
		{
			ISteamGameServer._SetDedicatedServer(this.Self, bDedicated);
		}

		// Token: 0x06000187 RID: 391
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_LogOn")]
		private static extern void _LogOn(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszToken);

		// Token: 0x06000188 RID: 392 RVA: 0x000047D6 File Offset: 0x000029D6
		internal void LogOn([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszToken)
		{
			ISteamGameServer._LogOn(this.Self, pszToken);
		}

		// Token: 0x06000189 RID: 393
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_LogOnAnonymous")]
		private static extern void _LogOnAnonymous(IntPtr self);

		// Token: 0x0600018A RID: 394 RVA: 0x000047E4 File Offset: 0x000029E4
		internal void LogOnAnonymous()
		{
			ISteamGameServer._LogOnAnonymous(this.Self);
		}

		// Token: 0x0600018B RID: 395
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_LogOff")]
		private static extern void _LogOff(IntPtr self);

		// Token: 0x0600018C RID: 396 RVA: 0x000047F1 File Offset: 0x000029F1
		internal void LogOff()
		{
			ISteamGameServer._LogOff(this.Self);
		}

		// Token: 0x0600018D RID: 397
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_BLoggedOn")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BLoggedOn(IntPtr self);

		// Token: 0x0600018E RID: 398 RVA: 0x000047FE File Offset: 0x000029FE
		internal bool BLoggedOn()
		{
			return ISteamGameServer._BLoggedOn(this.Self);
		}

		// Token: 0x0600018F RID: 399
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_BSecure")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BSecure(IntPtr self);

		// Token: 0x06000190 RID: 400 RVA: 0x0000480B File Offset: 0x00002A0B
		internal bool BSecure()
		{
			return ISteamGameServer._BSecure(this.Self);
		}

		// Token: 0x06000191 RID: 401
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_GetSteamID")]
		private static extern SteamId _GetSteamID(IntPtr self);

		// Token: 0x06000192 RID: 402 RVA: 0x00004818 File Offset: 0x00002A18
		internal SteamId GetSteamID()
		{
			return ISteamGameServer._GetSteamID(this.Self);
		}

		// Token: 0x06000193 RID: 403
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_WasRestartRequested")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _WasRestartRequested(IntPtr self);

		// Token: 0x06000194 RID: 404 RVA: 0x00004825 File Offset: 0x00002A25
		internal bool WasRestartRequested()
		{
			return ISteamGameServer._WasRestartRequested(this.Self);
		}

		// Token: 0x06000195 RID: 405
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetMaxPlayerCount")]
		private static extern void _SetMaxPlayerCount(IntPtr self, int cPlayersMax);

		// Token: 0x06000196 RID: 406 RVA: 0x00004832 File Offset: 0x00002A32
		internal void SetMaxPlayerCount(int cPlayersMax)
		{
			ISteamGameServer._SetMaxPlayerCount(this.Self, cPlayersMax);
		}

		// Token: 0x06000197 RID: 407
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetBotPlayerCount")]
		private static extern void _SetBotPlayerCount(IntPtr self, int cBotplayers);

		// Token: 0x06000198 RID: 408 RVA: 0x00004840 File Offset: 0x00002A40
		internal void SetBotPlayerCount(int cBotplayers)
		{
			ISteamGameServer._SetBotPlayerCount(this.Self, cBotplayers);
		}

		// Token: 0x06000199 RID: 409
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetServerName")]
		private static extern void _SetServerName(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszServerName);

		// Token: 0x0600019A RID: 410 RVA: 0x0000484E File Offset: 0x00002A4E
		internal void SetServerName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszServerName)
		{
			ISteamGameServer._SetServerName(this.Self, pszServerName);
		}

		// Token: 0x0600019B RID: 411
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetMapName")]
		private static extern void _SetMapName(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszMapName);

		// Token: 0x0600019C RID: 412 RVA: 0x0000485C File Offset: 0x00002A5C
		internal void SetMapName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszMapName)
		{
			ISteamGameServer._SetMapName(this.Self, pszMapName);
		}

		// Token: 0x0600019D RID: 413
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetPasswordProtected")]
		private static extern void _SetPasswordProtected(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bPasswordProtected);

		// Token: 0x0600019E RID: 414 RVA: 0x0000486A File Offset: 0x00002A6A
		internal void SetPasswordProtected([MarshalAs(UnmanagedType.U1)] bool bPasswordProtected)
		{
			ISteamGameServer._SetPasswordProtected(this.Self, bPasswordProtected);
		}

		// Token: 0x0600019F RID: 415
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetSpectatorPort")]
		private static extern void _SetSpectatorPort(IntPtr self, ushort unSpectatorPort);

		// Token: 0x060001A0 RID: 416 RVA: 0x00004878 File Offset: 0x00002A78
		internal void SetSpectatorPort(ushort unSpectatorPort)
		{
			ISteamGameServer._SetSpectatorPort(this.Self, unSpectatorPort);
		}

		// Token: 0x060001A1 RID: 417
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetSpectatorServerName")]
		private static extern void _SetSpectatorServerName(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszSpectatorServerName);

		// Token: 0x060001A2 RID: 418 RVA: 0x00004886 File Offset: 0x00002A86
		internal void SetSpectatorServerName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszSpectatorServerName)
		{
			ISteamGameServer._SetSpectatorServerName(this.Self, pszSpectatorServerName);
		}

		// Token: 0x060001A3 RID: 419
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_ClearAllKeyValues")]
		private static extern void _ClearAllKeyValues(IntPtr self);

		// Token: 0x060001A4 RID: 420 RVA: 0x00004894 File Offset: 0x00002A94
		internal void ClearAllKeyValues()
		{
			ISteamGameServer._ClearAllKeyValues(this.Self);
		}

		// Token: 0x060001A5 RID: 421
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetKeyValue")]
		private static extern void _SetKeyValue(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pValue);

		// Token: 0x060001A6 RID: 422 RVA: 0x000048A1 File Offset: 0x00002AA1
		internal void SetKeyValue([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pValue)
		{
			ISteamGameServer._SetKeyValue(this.Self, pKey, pValue);
		}

		// Token: 0x060001A7 RID: 423
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetGameTags")]
		private static extern void _SetGameTags(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchGameTags);

		// Token: 0x060001A8 RID: 424 RVA: 0x000048B0 File Offset: 0x00002AB0
		internal void SetGameTags([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchGameTags)
		{
			ISteamGameServer._SetGameTags(this.Self, pchGameTags);
		}

		// Token: 0x060001A9 RID: 425
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetGameData")]
		private static extern void _SetGameData(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchGameData);

		// Token: 0x060001AA RID: 426 RVA: 0x000048BE File Offset: 0x00002ABE
		internal void SetGameData([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchGameData)
		{
			ISteamGameServer._SetGameData(this.Self, pchGameData);
		}

		// Token: 0x060001AB RID: 427
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetRegion")]
		private static extern void _SetRegion(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszRegion);

		// Token: 0x060001AC RID: 428 RVA: 0x000048CC File Offset: 0x00002ACC
		internal void SetRegion([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszRegion)
		{
			ISteamGameServer._SetRegion(this.Self, pszRegion);
		}

		// Token: 0x060001AD RID: 429
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SetAdvertiseServerActive")]
		private static extern void _SetAdvertiseServerActive(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bActive);

		// Token: 0x060001AE RID: 430 RVA: 0x000048DA File Offset: 0x00002ADA
		internal void SetAdvertiseServerActive([MarshalAs(UnmanagedType.U1)] bool bActive)
		{
			ISteamGameServer._SetAdvertiseServerActive(this.Self, bActive);
		}

		// Token: 0x060001AF RID: 431
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_GetAuthSessionTicket")]
		private static extern HAuthTicket _GetAuthSessionTicket(IntPtr self, IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket);

		// Token: 0x060001B0 RID: 432 RVA: 0x000048E8 File Offset: 0x00002AE8
		internal HAuthTicket GetAuthSessionTicket(IntPtr pTicket, int cbMaxTicket, ref uint pcbTicket)
		{
			return ISteamGameServer._GetAuthSessionTicket(this.Self, pTicket, cbMaxTicket, ref pcbTicket);
		}

		// Token: 0x060001B1 RID: 433
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_BeginAuthSession")]
		private static extern BeginAuthResult _BeginAuthSession(IntPtr self, IntPtr pAuthTicket, int cbAuthTicket, SteamId steamID);

		// Token: 0x060001B2 RID: 434 RVA: 0x000048F8 File Offset: 0x00002AF8
		internal BeginAuthResult BeginAuthSession(IntPtr pAuthTicket, int cbAuthTicket, SteamId steamID)
		{
			return ISteamGameServer._BeginAuthSession(this.Self, pAuthTicket, cbAuthTicket, steamID);
		}

		// Token: 0x060001B3 RID: 435
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_EndAuthSession")]
		private static extern void _EndAuthSession(IntPtr self, SteamId steamID);

		// Token: 0x060001B4 RID: 436 RVA: 0x00004908 File Offset: 0x00002B08
		internal void EndAuthSession(SteamId steamID)
		{
			ISteamGameServer._EndAuthSession(this.Self, steamID);
		}

		// Token: 0x060001B5 RID: 437
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_CancelAuthTicket")]
		private static extern void _CancelAuthTicket(IntPtr self, HAuthTicket hAuthTicket);

		// Token: 0x060001B6 RID: 438 RVA: 0x00004916 File Offset: 0x00002B16
		internal void CancelAuthTicket(HAuthTicket hAuthTicket)
		{
			ISteamGameServer._CancelAuthTicket(this.Self, hAuthTicket);
		}

		// Token: 0x060001B7 RID: 439
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_UserHasLicenseForApp")]
		private static extern UserHasLicenseForAppResult _UserHasLicenseForApp(IntPtr self, SteamId steamID, AppId appID);

		// Token: 0x060001B8 RID: 440 RVA: 0x00004924 File Offset: 0x00002B24
		internal UserHasLicenseForAppResult UserHasLicenseForApp(SteamId steamID, AppId appID)
		{
			return ISteamGameServer._UserHasLicenseForApp(this.Self, steamID, appID);
		}

		// Token: 0x060001B9 RID: 441
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_RequestUserGroupStatus")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _RequestUserGroupStatus(IntPtr self, SteamId steamIDUser, SteamId steamIDGroup);

		// Token: 0x060001BA RID: 442 RVA: 0x00004933 File Offset: 0x00002B33
		internal bool RequestUserGroupStatus(SteamId steamIDUser, SteamId steamIDGroup)
		{
			return ISteamGameServer._RequestUserGroupStatus(this.Self, steamIDUser, steamIDGroup);
		}

		// Token: 0x060001BB RID: 443
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_GetGameplayStats")]
		private static extern void _GetGameplayStats(IntPtr self);

		// Token: 0x060001BC RID: 444 RVA: 0x00004942 File Offset: 0x00002B42
		internal void GetGameplayStats()
		{
			ISteamGameServer._GetGameplayStats(this.Self);
		}

		// Token: 0x060001BD RID: 445
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_GetServerReputation")]
		private static extern SteamAPICall_t _GetServerReputation(IntPtr self);

		// Token: 0x060001BE RID: 446 RVA: 0x0000494F File Offset: 0x00002B4F
		internal CallResult<GSReputation_t> GetServerReputation()
		{
			return new CallResult<GSReputation_t>(ISteamGameServer._GetServerReputation(this.Self), base.IsServer);
		}

		// Token: 0x060001BF RID: 447
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_GetPublicIP")]
		private static extern SteamIPAddress _GetPublicIP(IntPtr self);

		// Token: 0x060001C0 RID: 448 RVA: 0x00004967 File Offset: 0x00002B67
		internal SteamIPAddress GetPublicIP()
		{
			return ISteamGameServer._GetPublicIP(this.Self);
		}

		// Token: 0x060001C1 RID: 449
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_HandleIncomingPacket")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _HandleIncomingPacket(IntPtr self, IntPtr pData, int cbData, uint srcIP, ushort srcPort);

		// Token: 0x060001C2 RID: 450 RVA: 0x00004974 File Offset: 0x00002B74
		internal bool HandleIncomingPacket(IntPtr pData, int cbData, uint srcIP, ushort srcPort)
		{
			return ISteamGameServer._HandleIncomingPacket(this.Self, pData, cbData, srcIP, srcPort);
		}

		// Token: 0x060001C3 RID: 451
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_GetNextOutgoingPacket")]
		private static extern int _GetNextOutgoingPacket(IntPtr self, IntPtr pOut, int cbMaxOut, ref uint pNetAdr, ref ushort pPort);

		// Token: 0x060001C4 RID: 452 RVA: 0x00004986 File Offset: 0x00002B86
		internal int GetNextOutgoingPacket(IntPtr pOut, int cbMaxOut, ref uint pNetAdr, ref ushort pPort)
		{
			return ISteamGameServer._GetNextOutgoingPacket(this.Self, pOut, cbMaxOut, ref pNetAdr, ref pPort);
		}

		// Token: 0x060001C5 RID: 453
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_AssociateWithClan")]
		private static extern SteamAPICall_t _AssociateWithClan(IntPtr self, SteamId steamIDClan);

		// Token: 0x060001C6 RID: 454 RVA: 0x00004998 File Offset: 0x00002B98
		internal CallResult<AssociateWithClanResult_t> AssociateWithClan(SteamId steamIDClan)
		{
			return new CallResult<AssociateWithClanResult_t>(ISteamGameServer._AssociateWithClan(this.Self, steamIDClan), base.IsServer);
		}

		// Token: 0x060001C7 RID: 455
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_ComputeNewPlayerCompatibility")]
		private static extern SteamAPICall_t _ComputeNewPlayerCompatibility(IntPtr self, SteamId steamIDNewPlayer);

		// Token: 0x060001C8 RID: 456 RVA: 0x000049B1 File Offset: 0x00002BB1
		internal CallResult<ComputeNewPlayerCompatibilityResult_t> ComputeNewPlayerCompatibility(SteamId steamIDNewPlayer)
		{
			return new CallResult<ComputeNewPlayerCompatibilityResult_t>(ISteamGameServer._ComputeNewPlayerCompatibility(this.Self, steamIDNewPlayer), base.IsServer);
		}

		// Token: 0x060001C9 RID: 457
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SendUserConnectAndAuthenticate_DEPRECATED")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SendUserConnectAndAuthenticate_DEPRECATED(IntPtr self, uint unIPClient, IntPtr pvAuthBlob, uint cubAuthBlobSize, ref SteamId pSteamIDUser);

		// Token: 0x060001CA RID: 458 RVA: 0x000049CA File Offset: 0x00002BCA
		internal bool SendUserConnectAndAuthenticate_DEPRECATED(uint unIPClient, IntPtr pvAuthBlob, uint cubAuthBlobSize, ref SteamId pSteamIDUser)
		{
			return ISteamGameServer._SendUserConnectAndAuthenticate_DEPRECATED(this.Self, unIPClient, pvAuthBlob, cubAuthBlobSize, ref pSteamIDUser);
		}

		// Token: 0x060001CB RID: 459
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_CreateUnauthenticatedUserConnection")]
		private static extern SteamId _CreateUnauthenticatedUserConnection(IntPtr self);

		// Token: 0x060001CC RID: 460 RVA: 0x000049DC File Offset: 0x00002BDC
		internal SteamId CreateUnauthenticatedUserConnection()
		{
			return ISteamGameServer._CreateUnauthenticatedUserConnection(this.Self);
		}

		// Token: 0x060001CD RID: 461
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_SendUserDisconnect_DEPRECATED")]
		private static extern void _SendUserDisconnect_DEPRECATED(IntPtr self, SteamId steamIDUser);

		// Token: 0x060001CE RID: 462 RVA: 0x000049E9 File Offset: 0x00002BE9
		internal void SendUserDisconnect_DEPRECATED(SteamId steamIDUser)
		{
			ISteamGameServer._SendUserDisconnect_DEPRECATED(this.Self, steamIDUser);
		}

		// Token: 0x060001CF RID: 463
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServer_BUpdateUserData")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BUpdateUserData(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPlayerName, uint uScore);

		// Token: 0x060001D0 RID: 464 RVA: 0x000049F7 File Offset: 0x00002BF7
		internal bool BUpdateUserData(SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPlayerName, uint uScore)
		{
			return ISteamGameServer._BUpdateUserData(this.Self, steamIDUser, pchPlayerName, uScore);
		}
	}
}
