using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x02000038 RID: 56
	internal class ISteamUtils : SteamInterface
	{
		// Token: 0x060004D7 RID: 1239 RVA: 0x0000645A File Offset: 0x0000465A
		internal ISteamUtils(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x060004D8 RID: 1240
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamUtils_v010();

		// Token: 0x060004D9 RID: 1241 RVA: 0x00006469 File Offset: 0x00004669
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamUtils.SteamAPI_SteamUtils_v010();
		}

		// Token: 0x060004DA RID: 1242
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamGameServerUtils_v010();

		// Token: 0x060004DB RID: 1243 RVA: 0x00006470 File Offset: 0x00004670
		internal override IntPtr GetServerInterfacePointer()
		{
			return ISteamUtils.SteamAPI_SteamGameServerUtils_v010();
		}

		// Token: 0x060004DC RID: 1244
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetSecondsSinceAppActive")]
		private static extern uint _GetSecondsSinceAppActive(IntPtr self);

		// Token: 0x060004DD RID: 1245 RVA: 0x00006477 File Offset: 0x00004677
		internal uint GetSecondsSinceAppActive()
		{
			return ISteamUtils._GetSecondsSinceAppActive(this.Self);
		}

		// Token: 0x060004DE RID: 1246
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetSecondsSinceComputerActive")]
		private static extern uint _GetSecondsSinceComputerActive(IntPtr self);

		// Token: 0x060004DF RID: 1247 RVA: 0x00006484 File Offset: 0x00004684
		internal uint GetSecondsSinceComputerActive()
		{
			return ISteamUtils._GetSecondsSinceComputerActive(this.Self);
		}

		// Token: 0x060004E0 RID: 1248
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetConnectedUniverse")]
		private static extern Universe _GetConnectedUniverse(IntPtr self);

		// Token: 0x060004E1 RID: 1249 RVA: 0x00006491 File Offset: 0x00004691
		internal Universe GetConnectedUniverse()
		{
			return ISteamUtils._GetConnectedUniverse(this.Self);
		}

		// Token: 0x060004E2 RID: 1250
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetServerRealTime")]
		private static extern uint _GetServerRealTime(IntPtr self);

		// Token: 0x060004E3 RID: 1251 RVA: 0x0000649E File Offset: 0x0000469E
		internal uint GetServerRealTime()
		{
			return ISteamUtils._GetServerRealTime(this.Self);
		}

		// Token: 0x060004E4 RID: 1252
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetIPCountry")]
		private static extern Utf8StringPointer _GetIPCountry(IntPtr self);

		// Token: 0x060004E5 RID: 1253 RVA: 0x000064AB File Offset: 0x000046AB
		internal string GetIPCountry()
		{
			return ISteamUtils._GetIPCountry(this.Self);
		}

		// Token: 0x060004E6 RID: 1254
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetImageSize")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetImageSize(IntPtr self, int iImage, ref uint pnWidth, ref uint pnHeight);

		// Token: 0x060004E7 RID: 1255 RVA: 0x000064BD File Offset: 0x000046BD
		internal bool GetImageSize(int iImage, ref uint pnWidth, ref uint pnHeight)
		{
			return ISteamUtils._GetImageSize(this.Self, iImage, ref pnWidth, ref pnHeight);
		}

		// Token: 0x060004E8 RID: 1256
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetImageRGBA")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetImageRGBA(IntPtr self, int iImage, [In] [Out] byte[] pubDest, int nDestBufferSize);

		// Token: 0x060004E9 RID: 1257 RVA: 0x000064CD File Offset: 0x000046CD
		internal bool GetImageRGBA(int iImage, [In] [Out] byte[] pubDest, int nDestBufferSize)
		{
			return ISteamUtils._GetImageRGBA(this.Self, iImage, pubDest, nDestBufferSize);
		}

		// Token: 0x060004EA RID: 1258
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetCurrentBatteryPower")]
		private static extern byte _GetCurrentBatteryPower(IntPtr self);

		// Token: 0x060004EB RID: 1259 RVA: 0x000064DD File Offset: 0x000046DD
		internal byte GetCurrentBatteryPower()
		{
			return ISteamUtils._GetCurrentBatteryPower(this.Self);
		}

		// Token: 0x060004EC RID: 1260
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetAppID")]
		private static extern uint _GetAppID(IntPtr self);

		// Token: 0x060004ED RID: 1261 RVA: 0x000064EA File Offset: 0x000046EA
		internal uint GetAppID()
		{
			return ISteamUtils._GetAppID(this.Self);
		}

		// Token: 0x060004EE RID: 1262
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_SetOverlayNotificationPosition")]
		private static extern void _SetOverlayNotificationPosition(IntPtr self, NotificationPosition eNotificationPosition);

		// Token: 0x060004EF RID: 1263 RVA: 0x000064F7 File Offset: 0x000046F7
		internal void SetOverlayNotificationPosition(NotificationPosition eNotificationPosition)
		{
			ISteamUtils._SetOverlayNotificationPosition(this.Self, eNotificationPosition);
		}

		// Token: 0x060004F0 RID: 1264
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_IsAPICallCompleted")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsAPICallCompleted(IntPtr self, SteamAPICall_t hSteamAPICall, [MarshalAs(UnmanagedType.U1)] ref bool pbFailed);

		// Token: 0x060004F1 RID: 1265 RVA: 0x00006505 File Offset: 0x00004705
		internal bool IsAPICallCompleted(SteamAPICall_t hSteamAPICall, [MarshalAs(UnmanagedType.U1)] ref bool pbFailed)
		{
			return ISteamUtils._IsAPICallCompleted(this.Self, hSteamAPICall, ref pbFailed);
		}

		// Token: 0x060004F2 RID: 1266
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetAPICallFailureReason")]
		private static extern SteamAPICallFailure _GetAPICallFailureReason(IntPtr self, SteamAPICall_t hSteamAPICall);

		// Token: 0x060004F3 RID: 1267 RVA: 0x00006514 File Offset: 0x00004714
		internal SteamAPICallFailure GetAPICallFailureReason(SteamAPICall_t hSteamAPICall)
		{
			return ISteamUtils._GetAPICallFailureReason(this.Self, hSteamAPICall);
		}

		// Token: 0x060004F4 RID: 1268
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetAPICallResult")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetAPICallResult(IntPtr self, SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, [MarshalAs(UnmanagedType.U1)] ref bool pbFailed);

		// Token: 0x060004F5 RID: 1269 RVA: 0x00006522 File Offset: 0x00004722
		internal bool GetAPICallResult(SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, [MarshalAs(UnmanagedType.U1)] ref bool pbFailed)
		{
			return ISteamUtils._GetAPICallResult(this.Self, hSteamAPICall, pCallback, cubCallback, iCallbackExpected, ref pbFailed);
		}

		// Token: 0x060004F6 RID: 1270
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetIPCCallCount")]
		private static extern uint _GetIPCCallCount(IntPtr self);

		// Token: 0x060004F7 RID: 1271 RVA: 0x00006536 File Offset: 0x00004736
		internal uint GetIPCCallCount()
		{
			return ISteamUtils._GetIPCCallCount(this.Self);
		}

		// Token: 0x060004F8 RID: 1272
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_SetWarningMessageHook")]
		private static extern void _SetWarningMessageHook(IntPtr self, IntPtr pFunction);

		// Token: 0x060004F9 RID: 1273 RVA: 0x00006543 File Offset: 0x00004743
		internal void SetWarningMessageHook(IntPtr pFunction)
		{
			ISteamUtils._SetWarningMessageHook(this.Self, pFunction);
		}

		// Token: 0x060004FA RID: 1274
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_IsOverlayEnabled")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsOverlayEnabled(IntPtr self);

		// Token: 0x060004FB RID: 1275 RVA: 0x00006551 File Offset: 0x00004751
		internal bool IsOverlayEnabled()
		{
			return ISteamUtils._IsOverlayEnabled(this.Self);
		}

		// Token: 0x060004FC RID: 1276
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_BOverlayNeedsPresent")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BOverlayNeedsPresent(IntPtr self);

		// Token: 0x060004FD RID: 1277 RVA: 0x0000655E File Offset: 0x0000475E
		internal bool BOverlayNeedsPresent()
		{
			return ISteamUtils._BOverlayNeedsPresent(this.Self);
		}

		// Token: 0x060004FE RID: 1278
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_CheckFileSignature")]
		private static extern SteamAPICall_t _CheckFileSignature(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string szFileName);

		// Token: 0x060004FF RID: 1279 RVA: 0x0000656B File Offset: 0x0000476B
		internal CallResult<CheckFileSignature_t> CheckFileSignature([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string szFileName)
		{
			return new CallResult<CheckFileSignature_t>(ISteamUtils._CheckFileSignature(this.Self, szFileName), base.IsServer);
		}

		// Token: 0x06000500 RID: 1280
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_ShowGamepadTextInput")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _ShowGamepadTextInput(IntPtr self, GamepadTextInputMode eInputMode, GamepadTextInputLineMode eLineInputMode, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchDescription, uint unCharMax, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchExistingText);

		// Token: 0x06000501 RID: 1281 RVA: 0x00006584 File Offset: 0x00004784
		internal bool ShowGamepadTextInput(GamepadTextInputMode eInputMode, GamepadTextInputLineMode eLineInputMode, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchDescription, uint unCharMax, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchExistingText)
		{
			return ISteamUtils._ShowGamepadTextInput(this.Self, eInputMode, eLineInputMode, pchDescription, unCharMax, pchExistingText);
		}

		// Token: 0x06000502 RID: 1282
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetEnteredGamepadTextLength")]
		private static extern uint _GetEnteredGamepadTextLength(IntPtr self);

		// Token: 0x06000503 RID: 1283 RVA: 0x00006598 File Offset: 0x00004798
		internal uint GetEnteredGamepadTextLength()
		{
			return ISteamUtils._GetEnteredGamepadTextLength(this.Self);
		}

		// Token: 0x06000504 RID: 1284
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetEnteredGamepadTextInput")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetEnteredGamepadTextInput(IntPtr self, IntPtr pchText, uint cchText);

		// Token: 0x06000505 RID: 1285 RVA: 0x000065A8 File Offset: 0x000047A8
		internal bool GetEnteredGamepadTextInput(out string pchText)
		{
			Helpers.Memory mempchText = Helpers.TakeMemory();
			bool result;
			try
			{
				bool flag = ISteamUtils._GetEnteredGamepadTextInput(this.Self, mempchText, 32768U);
				pchText = Helpers.MemoryToString(mempchText);
				result = flag;
			}
			finally
			{
				((IDisposable)mempchText).Dispose();
			}
			return result;
		}

		// Token: 0x06000506 RID: 1286
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetSteamUILanguage")]
		private static extern Utf8StringPointer _GetSteamUILanguage(IntPtr self);

		// Token: 0x06000507 RID: 1287 RVA: 0x00006604 File Offset: 0x00004804
		internal string GetSteamUILanguage()
		{
			return ISteamUtils._GetSteamUILanguage(this.Self);
		}

		// Token: 0x06000508 RID: 1288
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_IsSteamRunningInVR")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsSteamRunningInVR(IntPtr self);

		// Token: 0x06000509 RID: 1289 RVA: 0x00006616 File Offset: 0x00004816
		internal bool IsSteamRunningInVR()
		{
			return ISteamUtils._IsSteamRunningInVR(this.Self);
		}

		// Token: 0x0600050A RID: 1290
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_SetOverlayNotificationInset")]
		private static extern void _SetOverlayNotificationInset(IntPtr self, int nHorizontalInset, int nVerticalInset);

		// Token: 0x0600050B RID: 1291 RVA: 0x00006623 File Offset: 0x00004823
		internal void SetOverlayNotificationInset(int nHorizontalInset, int nVerticalInset)
		{
			ISteamUtils._SetOverlayNotificationInset(this.Self, nHorizontalInset, nVerticalInset);
		}

		// Token: 0x0600050C RID: 1292
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_IsSteamInBigPictureMode")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsSteamInBigPictureMode(IntPtr self);

		// Token: 0x0600050D RID: 1293 RVA: 0x00006632 File Offset: 0x00004832
		internal bool IsSteamInBigPictureMode()
		{
			return ISteamUtils._IsSteamInBigPictureMode(this.Self);
		}

		// Token: 0x0600050E RID: 1294
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_StartVRDashboard")]
		private static extern void _StartVRDashboard(IntPtr self);

		// Token: 0x0600050F RID: 1295 RVA: 0x0000663F File Offset: 0x0000483F
		internal void StartVRDashboard()
		{
			ISteamUtils._StartVRDashboard(this.Self);
		}

		// Token: 0x06000510 RID: 1296
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_IsVRHeadsetStreamingEnabled")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsVRHeadsetStreamingEnabled(IntPtr self);

		// Token: 0x06000511 RID: 1297 RVA: 0x0000664C File Offset: 0x0000484C
		internal bool IsVRHeadsetStreamingEnabled()
		{
			return ISteamUtils._IsVRHeadsetStreamingEnabled(this.Self);
		}

		// Token: 0x06000512 RID: 1298
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_SetVRHeadsetStreamingEnabled")]
		private static extern void _SetVRHeadsetStreamingEnabled(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bEnabled);

		// Token: 0x06000513 RID: 1299 RVA: 0x00006659 File Offset: 0x00004859
		internal void SetVRHeadsetStreamingEnabled([MarshalAs(UnmanagedType.U1)] bool bEnabled)
		{
			ISteamUtils._SetVRHeadsetStreamingEnabled(this.Self, bEnabled);
		}

		// Token: 0x06000514 RID: 1300
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_IsSteamChinaLauncher")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsSteamChinaLauncher(IntPtr self);

		// Token: 0x06000515 RID: 1301 RVA: 0x00006667 File Offset: 0x00004867
		internal bool IsSteamChinaLauncher()
		{
			return ISteamUtils._IsSteamChinaLauncher(this.Self);
		}

		// Token: 0x06000516 RID: 1302
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_InitFilterText")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _InitFilterText(IntPtr self, uint unFilterOptions);

		// Token: 0x06000517 RID: 1303 RVA: 0x00006674 File Offset: 0x00004874
		internal bool InitFilterText(uint unFilterOptions)
		{
			return ISteamUtils._InitFilterText(this.Self, unFilterOptions);
		}

		// Token: 0x06000518 RID: 1304
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_FilterText")]
		private static extern int _FilterText(IntPtr self, TextFilteringContext eContext, SteamId sourceSteamID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchInputMessage, IntPtr pchOutFilteredText, uint nByteSizeOutFilteredText);

		// Token: 0x06000519 RID: 1305 RVA: 0x00006684 File Offset: 0x00004884
		internal int FilterText(TextFilteringContext eContext, SteamId sourceSteamID, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchInputMessage, out string pchOutFilteredText)
		{
			Helpers.Memory mempchOutFilteredText = Helpers.TakeMemory();
			int result;
			try
			{
				int num = ISteamUtils._FilterText(this.Self, eContext, sourceSteamID, pchInputMessage, mempchOutFilteredText, 32768U);
				pchOutFilteredText = Helpers.MemoryToString(mempchOutFilteredText);
				result = num;
			}
			finally
			{
				((IDisposable)mempchOutFilteredText).Dispose();
			}
			return result;
		}

		// Token: 0x0600051A RID: 1306
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_GetIPv6ConnectivityState")]
		private static extern SteamIPv6ConnectivityState _GetIPv6ConnectivityState(IntPtr self, SteamIPv6ConnectivityProtocol eProtocol);

		// Token: 0x0600051B RID: 1307 RVA: 0x000066E4 File Offset: 0x000048E4
		internal SteamIPv6ConnectivityState GetIPv6ConnectivityState(SteamIPv6ConnectivityProtocol eProtocol)
		{
			return ISteamUtils._GetIPv6ConnectivityState(this.Self, eProtocol);
		}

		// Token: 0x0600051C RID: 1308
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_IsSteamRunningOnSteamDeck")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsSteamRunningOnSteamDeck(IntPtr self);

		// Token: 0x0600051D RID: 1309 RVA: 0x000066F2 File Offset: 0x000048F2
		internal bool IsSteamRunningOnSteamDeck()
		{
			return ISteamUtils._IsSteamRunningOnSteamDeck(this.Self);
		}

		// Token: 0x0600051E RID: 1310
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_ShowFloatingGamepadTextInput")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _ShowFloatingGamepadTextInput(IntPtr self, TextInputMode eKeyboardMode, int nTextFieldXPosition, int nTextFieldYPosition, int nTextFieldWidth, int nTextFieldHeight);

		// Token: 0x0600051F RID: 1311 RVA: 0x000066FF File Offset: 0x000048FF
		internal bool ShowFloatingGamepadTextInput(TextInputMode eKeyboardMode, int nTextFieldXPosition, int nTextFieldYPosition, int nTextFieldWidth, int nTextFieldHeight)
		{
			return ISteamUtils._ShowFloatingGamepadTextInput(this.Self, eKeyboardMode, nTextFieldXPosition, nTextFieldYPosition, nTextFieldWidth, nTextFieldHeight);
		}

		// Token: 0x06000520 RID: 1312
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_SetGameLauncherMode")]
		private static extern void _SetGameLauncherMode(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bLauncherMode);

		// Token: 0x06000521 RID: 1313 RVA: 0x00006713 File Offset: 0x00004913
		internal void SetGameLauncherMode([MarshalAs(UnmanagedType.U1)] bool bLauncherMode)
		{
			ISteamUtils._SetGameLauncherMode(this.Self, bLauncherMode);
		}

		// Token: 0x06000522 RID: 1314
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamUtils_DismissFloatingGamepadTextInput")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _DismissFloatingGamepadTextInput(IntPtr self);

		// Token: 0x06000523 RID: 1315 RVA: 0x00006721 File Offset: 0x00004921
		internal bool DismissFloatingGamepadTextInput()
		{
			return ISteamUtils._DismissFloatingGamepadTextInput(this.Self);
		}
	}
}
