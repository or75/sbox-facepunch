using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x02000034 RID: 52
	internal class ISteamRemotePlay : SteamInterface
	{
		// Token: 0x06000411 RID: 1041 RVA: 0x00005CE2 File Offset: 0x00003EE2
		internal ISteamRemotePlay(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x06000412 RID: 1042
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamRemotePlay_v001();

		// Token: 0x06000413 RID: 1043 RVA: 0x00005CF1 File Offset: 0x00003EF1
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamRemotePlay.SteamAPI_SteamRemotePlay_v001();
		}

		// Token: 0x06000414 RID: 1044
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamRemotePlay_GetSessionCount")]
		private static extern uint _GetSessionCount(IntPtr self);

		// Token: 0x06000415 RID: 1045 RVA: 0x00005CF8 File Offset: 0x00003EF8
		internal uint GetSessionCount()
		{
			return ISteamRemotePlay._GetSessionCount(this.Self);
		}

		// Token: 0x06000416 RID: 1046
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamRemotePlay_GetSessionID")]
		private static extern RemotePlaySessionID_t _GetSessionID(IntPtr self, int iSessionIndex);

		// Token: 0x06000417 RID: 1047 RVA: 0x00005D05 File Offset: 0x00003F05
		internal RemotePlaySessionID_t GetSessionID(int iSessionIndex)
		{
			return ISteamRemotePlay._GetSessionID(this.Self, iSessionIndex);
		}

		// Token: 0x06000418 RID: 1048
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamRemotePlay_GetSessionSteamID")]
		private static extern SteamId _GetSessionSteamID(IntPtr self, RemotePlaySessionID_t unSessionID);

		// Token: 0x06000419 RID: 1049 RVA: 0x00005D13 File Offset: 0x00003F13
		internal SteamId GetSessionSteamID(RemotePlaySessionID_t unSessionID)
		{
			return ISteamRemotePlay._GetSessionSteamID(this.Self, unSessionID);
		}

		// Token: 0x0600041A RID: 1050
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamRemotePlay_GetSessionClientName")]
		private static extern Utf8StringPointer _GetSessionClientName(IntPtr self, RemotePlaySessionID_t unSessionID);

		// Token: 0x0600041B RID: 1051 RVA: 0x00005D21 File Offset: 0x00003F21
		internal string GetSessionClientName(RemotePlaySessionID_t unSessionID)
		{
			return ISteamRemotePlay._GetSessionClientName(this.Self, unSessionID);
		}

		// Token: 0x0600041C RID: 1052
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamRemotePlay_GetSessionClientFormFactor")]
		private static extern SteamDeviceFormFactor _GetSessionClientFormFactor(IntPtr self, RemotePlaySessionID_t unSessionID);

		// Token: 0x0600041D RID: 1053 RVA: 0x00005D34 File Offset: 0x00003F34
		internal SteamDeviceFormFactor GetSessionClientFormFactor(RemotePlaySessionID_t unSessionID)
		{
			return ISteamRemotePlay._GetSessionClientFormFactor(this.Self, unSessionID);
		}

		// Token: 0x0600041E RID: 1054
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamRemotePlay_BGetSessionClientResolution")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BGetSessionClientResolution(IntPtr self, RemotePlaySessionID_t unSessionID, ref int pnResolutionX, ref int pnResolutionY);

		// Token: 0x0600041F RID: 1055 RVA: 0x00005D42 File Offset: 0x00003F42
		internal bool BGetSessionClientResolution(RemotePlaySessionID_t unSessionID, ref int pnResolutionX, ref int pnResolutionY)
		{
			return ISteamRemotePlay._BGetSessionClientResolution(this.Self, unSessionID, ref pnResolutionX, ref pnResolutionY);
		}

		// Token: 0x06000420 RID: 1056
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamRemotePlay_BSendRemotePlayTogetherInvite")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BSendRemotePlayTogetherInvite(IntPtr self, SteamId steamIDFriend);

		// Token: 0x06000421 RID: 1057 RVA: 0x00005D52 File Offset: 0x00003F52
		internal bool BSendRemotePlayTogetherInvite(SteamId steamIDFriend)
		{
			return ISteamRemotePlay._BSendRemotePlayTogetherInvite(this.Self, steamIDFriend);
		}
	}
}
