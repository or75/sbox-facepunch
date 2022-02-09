using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x02000022 RID: 34
	internal class ISteamClient : SteamInterface
	{
		// Token: 0x06000079 RID: 121 RVA: 0x00003F44 File Offset: 0x00002144
		internal ISteamClient(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x0600007A RID: 122
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_CreateSteamPipe")]
		private static extern HSteamPipe _CreateSteamPipe(IntPtr self);

		// Token: 0x0600007B RID: 123 RVA: 0x00003F53 File Offset: 0x00002153
		internal HSteamPipe CreateSteamPipe()
		{
			return ISteamClient._CreateSteamPipe(this.Self);
		}

		// Token: 0x0600007C RID: 124
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_BReleaseSteamPipe")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BReleaseSteamPipe(IntPtr self, HSteamPipe hSteamPipe);

		// Token: 0x0600007D RID: 125 RVA: 0x00003F60 File Offset: 0x00002160
		internal bool BReleaseSteamPipe(HSteamPipe hSteamPipe)
		{
			return ISteamClient._BReleaseSteamPipe(this.Self, hSteamPipe);
		}

		// Token: 0x0600007E RID: 126
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_ConnectToGlobalUser")]
		private static extern HSteamUser _ConnectToGlobalUser(IntPtr self, HSteamPipe hSteamPipe);

		// Token: 0x0600007F RID: 127 RVA: 0x00003F6E File Offset: 0x0000216E
		internal HSteamUser ConnectToGlobalUser(HSteamPipe hSteamPipe)
		{
			return ISteamClient._ConnectToGlobalUser(this.Self, hSteamPipe);
		}

		// Token: 0x06000080 RID: 128
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_CreateLocalUser")]
		private static extern HSteamUser _CreateLocalUser(IntPtr self, ref HSteamPipe phSteamPipe, AccountType eAccountType);

		// Token: 0x06000081 RID: 129 RVA: 0x00003F7C File Offset: 0x0000217C
		internal HSteamUser CreateLocalUser(ref HSteamPipe phSteamPipe, AccountType eAccountType)
		{
			return ISteamClient._CreateLocalUser(this.Self, ref phSteamPipe, eAccountType);
		}

		// Token: 0x06000082 RID: 130
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_ReleaseUser")]
		private static extern void _ReleaseUser(IntPtr self, HSteamPipe hSteamPipe, HSteamUser hUser);

		// Token: 0x06000083 RID: 131 RVA: 0x00003F8B File Offset: 0x0000218B
		internal void ReleaseUser(HSteamPipe hSteamPipe, HSteamUser hUser)
		{
			ISteamClient._ReleaseUser(this.Self, hSteamPipe, hUser);
		}

		// Token: 0x06000084 RID: 132
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamUser")]
		private static extern IntPtr _GetISteamUser(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x06000085 RID: 133 RVA: 0x00003F9A File Offset: 0x0000219A
		internal IntPtr GetISteamUser(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamUser(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000086 RID: 134
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamGameServer")]
		private static extern IntPtr _GetISteamGameServer(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x06000087 RID: 135 RVA: 0x00003FAA File Offset: 0x000021AA
		internal IntPtr GetISteamGameServer(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamGameServer(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000088 RID: 136
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_SetLocalIPBinding")]
		private static extern void _SetLocalIPBinding(IntPtr self, ref SteamIPAddress unIP, ushort usPort);

		// Token: 0x06000089 RID: 137 RVA: 0x00003FBA File Offset: 0x000021BA
		internal void SetLocalIPBinding(ref SteamIPAddress unIP, ushort usPort)
		{
			ISteamClient._SetLocalIPBinding(this.Self, ref unIP, usPort);
		}

		// Token: 0x0600008A RID: 138
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamFriends")]
		private static extern IntPtr _GetISteamFriends(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x0600008B RID: 139 RVA: 0x00003FC9 File Offset: 0x000021C9
		internal IntPtr GetISteamFriends(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamFriends(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x0600008C RID: 140
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamUtils")]
		private static extern IntPtr _GetISteamUtils(IntPtr self, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x0600008D RID: 141 RVA: 0x00003FD9 File Offset: 0x000021D9
		internal IntPtr GetISteamUtils(HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamUtils(this.Self, hSteamPipe, pchVersion);
		}

		// Token: 0x0600008E RID: 142
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamMatchmaking")]
		private static extern IntPtr _GetISteamMatchmaking(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x0600008F RID: 143 RVA: 0x00003FE8 File Offset: 0x000021E8
		internal IntPtr GetISteamMatchmaking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamMatchmaking(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000090 RID: 144
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamMatchmakingServers")]
		private static extern IntPtr _GetISteamMatchmakingServers(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x06000091 RID: 145 RVA: 0x00003FF8 File Offset: 0x000021F8
		internal IntPtr GetISteamMatchmakingServers(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamMatchmakingServers(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000092 RID: 146
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamGenericInterface")]
		private static extern IntPtr _GetISteamGenericInterface(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x06000093 RID: 147 RVA: 0x00004008 File Offset: 0x00002208
		internal IntPtr GetISteamGenericInterface(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamGenericInterface(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000094 RID: 148
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamUserStats")]
		private static extern IntPtr _GetISteamUserStats(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x06000095 RID: 149 RVA: 0x00004018 File Offset: 0x00002218
		internal IntPtr GetISteamUserStats(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamUserStats(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000096 RID: 150
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamGameServerStats")]
		private static extern IntPtr _GetISteamGameServerStats(IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x06000097 RID: 151 RVA: 0x00004028 File Offset: 0x00002228
		internal IntPtr GetISteamGameServerStats(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamGameServerStats(this.Self, hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000098 RID: 152
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamApps")]
		private static extern IntPtr _GetISteamApps(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x06000099 RID: 153 RVA: 0x00004038 File Offset: 0x00002238
		internal IntPtr GetISteamApps(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamApps(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x0600009A RID: 154
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamNetworking")]
		private static extern IntPtr _GetISteamNetworking(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x0600009B RID: 155 RVA: 0x00004048 File Offset: 0x00002248
		internal IntPtr GetISteamNetworking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamNetworking(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x0600009C RID: 156
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamRemoteStorage")]
		private static extern IntPtr _GetISteamRemoteStorage(IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x0600009D RID: 157 RVA: 0x00004058 File Offset: 0x00002258
		internal IntPtr GetISteamRemoteStorage(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamRemoteStorage(this.Self, hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x0600009E RID: 158
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamScreenshots")]
		private static extern IntPtr _GetISteamScreenshots(IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x0600009F RID: 159 RVA: 0x00004068 File Offset: 0x00002268
		internal IntPtr GetISteamScreenshots(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamScreenshots(this.Self, hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x060000A0 RID: 160
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamGameSearch")]
		private static extern IntPtr _GetISteamGameSearch(IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x060000A1 RID: 161 RVA: 0x00004078 File Offset: 0x00002278
		internal IntPtr GetISteamGameSearch(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamGameSearch(this.Self, hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x060000A2 RID: 162
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetIPCCallCount")]
		private static extern uint _GetIPCCallCount(IntPtr self);

		// Token: 0x060000A3 RID: 163 RVA: 0x00004088 File Offset: 0x00002288
		internal uint GetIPCCallCount()
		{
			return ISteamClient._GetIPCCallCount(this.Self);
		}

		// Token: 0x060000A4 RID: 164
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_SetWarningMessageHook")]
		private static extern void _SetWarningMessageHook(IntPtr self, IntPtr pFunction);

		// Token: 0x060000A5 RID: 165 RVA: 0x00004095 File Offset: 0x00002295
		internal void SetWarningMessageHook(IntPtr pFunction)
		{
			ISteamClient._SetWarningMessageHook(this.Self, pFunction);
		}

		// Token: 0x060000A6 RID: 166
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_BShutdownIfAllPipesClosed")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BShutdownIfAllPipesClosed(IntPtr self);

		// Token: 0x060000A7 RID: 167 RVA: 0x000040A3 File Offset: 0x000022A3
		internal bool BShutdownIfAllPipesClosed()
		{
			return ISteamClient._BShutdownIfAllPipesClosed(this.Self);
		}

		// Token: 0x060000A8 RID: 168
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamHTTP")]
		private static extern IntPtr _GetISteamHTTP(IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x060000A9 RID: 169 RVA: 0x000040B0 File Offset: 0x000022B0
		internal IntPtr GetISteamHTTP(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamHTTP(this.Self, hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x060000AA RID: 170
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamController")]
		private static extern IntPtr _GetISteamController(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x060000AB RID: 171 RVA: 0x000040C0 File Offset: 0x000022C0
		internal IntPtr GetISteamController(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamController(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x060000AC RID: 172
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamUGC")]
		private static extern IntPtr _GetISteamUGC(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x060000AD RID: 173 RVA: 0x000040D0 File Offset: 0x000022D0
		internal IntPtr GetISteamUGC(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamUGC(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x060000AE RID: 174
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamAppList")]
		private static extern IntPtr _GetISteamAppList(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x060000AF RID: 175 RVA: 0x000040E0 File Offset: 0x000022E0
		internal IntPtr GetISteamAppList(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamAppList(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x060000B0 RID: 176
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamMusic")]
		private static extern IntPtr _GetISteamMusic(IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x060000B1 RID: 177 RVA: 0x000040F0 File Offset: 0x000022F0
		internal IntPtr GetISteamMusic(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamMusic(this.Self, hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x060000B2 RID: 178
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamMusicRemote")]
		private static extern IntPtr _GetISteamMusicRemote(IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x060000B3 RID: 179 RVA: 0x00004100 File Offset: 0x00002300
		internal IntPtr GetISteamMusicRemote(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamMusicRemote(this.Self, hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x060000B4 RID: 180
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamHTMLSurface")]
		private static extern IntPtr _GetISteamHTMLSurface(IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x060000B5 RID: 181 RVA: 0x00004110 File Offset: 0x00002310
		internal IntPtr GetISteamHTMLSurface(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamHTMLSurface(this.Self, hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x060000B6 RID: 182
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamInventory")]
		private static extern IntPtr _GetISteamInventory(IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x060000B7 RID: 183 RVA: 0x00004120 File Offset: 0x00002320
		internal IntPtr GetISteamInventory(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamInventory(this.Self, hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x060000B8 RID: 184
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamVideo")]
		private static extern IntPtr _GetISteamVideo(IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x060000B9 RID: 185 RVA: 0x00004130 File Offset: 0x00002330
		internal IntPtr GetISteamVideo(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamVideo(this.Self, hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x060000BA RID: 186
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamParentalSettings")]
		private static extern IntPtr _GetISteamParentalSettings(IntPtr self, HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x060000BB RID: 187 RVA: 0x00004140 File Offset: 0x00002340
		internal IntPtr GetISteamParentalSettings(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamParentalSettings(this.Self, hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x060000BC RID: 188
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamInput")]
		private static extern IntPtr _GetISteamInput(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x060000BD RID: 189 RVA: 0x00004150 File Offset: 0x00002350
		internal IntPtr GetISteamInput(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamInput(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x060000BE RID: 190
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamParties")]
		private static extern IntPtr _GetISteamParties(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x060000BF RID: 191 RVA: 0x00004160 File Offset: 0x00002360
		internal IntPtr GetISteamParties(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamParties(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x060000C0 RID: 192
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamClient_GetISteamRemotePlay")]
		private static extern IntPtr _GetISteamRemotePlay(IntPtr self, HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion);

		// Token: 0x060000C1 RID: 193 RVA: 0x00004170 File Offset: 0x00002370
		internal IntPtr GetISteamRemotePlay(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersion)
		{
			return ISteamClient._GetISteamRemotePlay(this.Self, hSteamUser, hSteamPipe, pchVersion);
		}
	}
}
