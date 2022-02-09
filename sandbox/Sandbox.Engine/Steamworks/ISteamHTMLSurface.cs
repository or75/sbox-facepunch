using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x02000027 RID: 39
	internal class ISteamHTMLSurface : SteamInterface
	{
		// Token: 0x060001E8 RID: 488 RVA: 0x00004ACF File Offset: 0x00002CCF
		internal ISteamHTMLSurface(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x060001E9 RID: 489
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamHTMLSurface_v005();

		// Token: 0x060001EA RID: 490 RVA: 0x00004ADE File Offset: 0x00002CDE
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamHTMLSurface.SteamAPI_SteamHTMLSurface_v005();
		}

		// Token: 0x060001EB RID: 491
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_Init")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _Init(IntPtr self);

		// Token: 0x060001EC RID: 492 RVA: 0x00004AE5 File Offset: 0x00002CE5
		internal bool Init()
		{
			return ISteamHTMLSurface._Init(this.Self);
		}

		// Token: 0x060001ED RID: 493
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_Shutdown")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _Shutdown(IntPtr self);

		// Token: 0x060001EE RID: 494 RVA: 0x00004AF2 File Offset: 0x00002CF2
		internal bool Shutdown()
		{
			return ISteamHTMLSurface._Shutdown(this.Self);
		}

		// Token: 0x060001EF RID: 495
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_CreateBrowser")]
		private static extern SteamAPICall_t _CreateBrowser(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchUserAgent, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchUserCSS);

		// Token: 0x060001F0 RID: 496 RVA: 0x00004AFF File Offset: 0x00002CFF
		internal CallResult<HTML_BrowserReady_t> CreateBrowser([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchUserAgent, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchUserCSS)
		{
			return new CallResult<HTML_BrowserReady_t>(ISteamHTMLSurface._CreateBrowser(this.Self, pchUserAgent, pchUserCSS), base.IsServer);
		}

		// Token: 0x060001F1 RID: 497
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_RemoveBrowser")]
		private static extern void _RemoveBrowser(IntPtr self, HHTMLBrowser unBrowserHandle);

		// Token: 0x060001F2 RID: 498 RVA: 0x00004B19 File Offset: 0x00002D19
		internal void RemoveBrowser(HHTMLBrowser unBrowserHandle)
		{
			ISteamHTMLSurface._RemoveBrowser(this.Self, unBrowserHandle);
		}

		// Token: 0x060001F3 RID: 499
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_LoadURL")]
		private static extern void _LoadURL(IntPtr self, HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchURL, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPostData);

		// Token: 0x060001F4 RID: 500 RVA: 0x00004B27 File Offset: 0x00002D27
		internal void LoadURL(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchURL, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPostData)
		{
			ISteamHTMLSurface._LoadURL(this.Self, unBrowserHandle, pchURL, pchPostData);
		}

		// Token: 0x060001F5 RID: 501
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetSize")]
		private static extern void _SetSize(IntPtr self, HHTMLBrowser unBrowserHandle, uint unWidth, uint unHeight);

		// Token: 0x060001F6 RID: 502 RVA: 0x00004B37 File Offset: 0x00002D37
		internal void SetSize(HHTMLBrowser unBrowserHandle, uint unWidth, uint unHeight)
		{
			ISteamHTMLSurface._SetSize(this.Self, unBrowserHandle, unWidth, unHeight);
		}

		// Token: 0x060001F7 RID: 503
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_StopLoad")]
		private static extern void _StopLoad(IntPtr self, HHTMLBrowser unBrowserHandle);

		// Token: 0x060001F8 RID: 504 RVA: 0x00004B47 File Offset: 0x00002D47
		internal void StopLoad(HHTMLBrowser unBrowserHandle)
		{
			ISteamHTMLSurface._StopLoad(this.Self, unBrowserHandle);
		}

		// Token: 0x060001F9 RID: 505
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_Reload")]
		private static extern void _Reload(IntPtr self, HHTMLBrowser unBrowserHandle);

		// Token: 0x060001FA RID: 506 RVA: 0x00004B55 File Offset: 0x00002D55
		internal void Reload(HHTMLBrowser unBrowserHandle)
		{
			ISteamHTMLSurface._Reload(this.Self, unBrowserHandle);
		}

		// Token: 0x060001FB RID: 507
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_GoBack")]
		private static extern void _GoBack(IntPtr self, HHTMLBrowser unBrowserHandle);

		// Token: 0x060001FC RID: 508 RVA: 0x00004B63 File Offset: 0x00002D63
		internal void GoBack(HHTMLBrowser unBrowserHandle)
		{
			ISteamHTMLSurface._GoBack(this.Self, unBrowserHandle);
		}

		// Token: 0x060001FD RID: 509
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_GoForward")]
		private static extern void _GoForward(IntPtr self, HHTMLBrowser unBrowserHandle);

		// Token: 0x060001FE RID: 510 RVA: 0x00004B71 File Offset: 0x00002D71
		internal void GoForward(HHTMLBrowser unBrowserHandle)
		{
			ISteamHTMLSurface._GoForward(this.Self, unBrowserHandle);
		}

		// Token: 0x060001FF RID: 511
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_AddHeader")]
		private static extern void _AddHeader(IntPtr self, HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValue);

		// Token: 0x06000200 RID: 512 RVA: 0x00004B7F File Offset: 0x00002D7F
		internal void AddHeader(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValue)
		{
			ISteamHTMLSurface._AddHeader(this.Self, unBrowserHandle, pchKey, pchValue);
		}

		// Token: 0x06000201 RID: 513
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_ExecuteJavascript")]
		private static extern void _ExecuteJavascript(IntPtr self, HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchScript);

		// Token: 0x06000202 RID: 514 RVA: 0x00004B8F File Offset: 0x00002D8F
		internal void ExecuteJavascript(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchScript)
		{
			ISteamHTMLSurface._ExecuteJavascript(this.Self, unBrowserHandle, pchScript);
		}

		// Token: 0x06000203 RID: 515
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseUp")]
		private static extern void _MouseUp(IntPtr self, HHTMLBrowser unBrowserHandle, IntPtr eMouseButton);

		// Token: 0x06000204 RID: 516 RVA: 0x00004B9E File Offset: 0x00002D9E
		internal void MouseUp(HHTMLBrowser unBrowserHandle, IntPtr eMouseButton)
		{
			ISteamHTMLSurface._MouseUp(this.Self, unBrowserHandle, eMouseButton);
		}

		// Token: 0x06000205 RID: 517
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseDown")]
		private static extern void _MouseDown(IntPtr self, HHTMLBrowser unBrowserHandle, IntPtr eMouseButton);

		// Token: 0x06000206 RID: 518 RVA: 0x00004BAD File Offset: 0x00002DAD
		internal void MouseDown(HHTMLBrowser unBrowserHandle, IntPtr eMouseButton)
		{
			ISteamHTMLSurface._MouseDown(this.Self, unBrowserHandle, eMouseButton);
		}

		// Token: 0x06000207 RID: 519
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseDoubleClick")]
		private static extern void _MouseDoubleClick(IntPtr self, HHTMLBrowser unBrowserHandle, IntPtr eMouseButton);

		// Token: 0x06000208 RID: 520 RVA: 0x00004BBC File Offset: 0x00002DBC
		internal void MouseDoubleClick(HHTMLBrowser unBrowserHandle, IntPtr eMouseButton)
		{
			ISteamHTMLSurface._MouseDoubleClick(this.Self, unBrowserHandle, eMouseButton);
		}

		// Token: 0x06000209 RID: 521
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseMove")]
		private static extern void _MouseMove(IntPtr self, HHTMLBrowser unBrowserHandle, int x, int y);

		// Token: 0x0600020A RID: 522 RVA: 0x00004BCB File Offset: 0x00002DCB
		internal void MouseMove(HHTMLBrowser unBrowserHandle, int x, int y)
		{
			ISteamHTMLSurface._MouseMove(this.Self, unBrowserHandle, x, y);
		}

		// Token: 0x0600020B RID: 523
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseWheel")]
		private static extern void _MouseWheel(IntPtr self, HHTMLBrowser unBrowserHandle, int nDelta);

		// Token: 0x0600020C RID: 524 RVA: 0x00004BDB File Offset: 0x00002DDB
		internal void MouseWheel(HHTMLBrowser unBrowserHandle, int nDelta)
		{
			ISteamHTMLSurface._MouseWheel(this.Self, unBrowserHandle, nDelta);
		}

		// Token: 0x0600020D RID: 525
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_KeyDown")]
		private static extern void _KeyDown(IntPtr self, HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, IntPtr eHTMLKeyModifiers, [MarshalAs(UnmanagedType.U1)] bool bIsSystemKey);

		// Token: 0x0600020E RID: 526 RVA: 0x00004BEA File Offset: 0x00002DEA
		internal void KeyDown(HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, IntPtr eHTMLKeyModifiers, [MarshalAs(UnmanagedType.U1)] bool bIsSystemKey)
		{
			ISteamHTMLSurface._KeyDown(this.Self, unBrowserHandle, nNativeKeyCode, eHTMLKeyModifiers, bIsSystemKey);
		}

		// Token: 0x0600020F RID: 527
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_KeyUp")]
		private static extern void _KeyUp(IntPtr self, HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, IntPtr eHTMLKeyModifiers);

		// Token: 0x06000210 RID: 528 RVA: 0x00004BFC File Offset: 0x00002DFC
		internal void KeyUp(HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, IntPtr eHTMLKeyModifiers)
		{
			ISteamHTMLSurface._KeyUp(this.Self, unBrowserHandle, nNativeKeyCode, eHTMLKeyModifiers);
		}

		// Token: 0x06000211 RID: 529
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_KeyChar")]
		private static extern void _KeyChar(IntPtr self, HHTMLBrowser unBrowserHandle, uint cUnicodeChar, IntPtr eHTMLKeyModifiers);

		// Token: 0x06000212 RID: 530 RVA: 0x00004C0C File Offset: 0x00002E0C
		internal void KeyChar(HHTMLBrowser unBrowserHandle, uint cUnicodeChar, IntPtr eHTMLKeyModifiers)
		{
			ISteamHTMLSurface._KeyChar(this.Self, unBrowserHandle, cUnicodeChar, eHTMLKeyModifiers);
		}

		// Token: 0x06000213 RID: 531
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetHorizontalScroll")]
		private static extern void _SetHorizontalScroll(IntPtr self, HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll);

		// Token: 0x06000214 RID: 532 RVA: 0x00004C1C File Offset: 0x00002E1C
		internal void SetHorizontalScroll(HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll)
		{
			ISteamHTMLSurface._SetHorizontalScroll(this.Self, unBrowserHandle, nAbsolutePixelScroll);
		}

		// Token: 0x06000215 RID: 533
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetVerticalScroll")]
		private static extern void _SetVerticalScroll(IntPtr self, HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll);

		// Token: 0x06000216 RID: 534 RVA: 0x00004C2B File Offset: 0x00002E2B
		internal void SetVerticalScroll(HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll)
		{
			ISteamHTMLSurface._SetVerticalScroll(this.Self, unBrowserHandle, nAbsolutePixelScroll);
		}

		// Token: 0x06000217 RID: 535
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetKeyFocus")]
		private static extern void _SetKeyFocus(IntPtr self, HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.U1)] bool bHasKeyFocus);

		// Token: 0x06000218 RID: 536 RVA: 0x00004C3A File Offset: 0x00002E3A
		internal void SetKeyFocus(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.U1)] bool bHasKeyFocus)
		{
			ISteamHTMLSurface._SetKeyFocus(this.Self, unBrowserHandle, bHasKeyFocus);
		}

		// Token: 0x06000219 RID: 537
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_ViewSource")]
		private static extern void _ViewSource(IntPtr self, HHTMLBrowser unBrowserHandle);

		// Token: 0x0600021A RID: 538 RVA: 0x00004C49 File Offset: 0x00002E49
		internal void ViewSource(HHTMLBrowser unBrowserHandle)
		{
			ISteamHTMLSurface._ViewSource(this.Self, unBrowserHandle);
		}

		// Token: 0x0600021B RID: 539
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_CopyToClipboard")]
		private static extern void _CopyToClipboard(IntPtr self, HHTMLBrowser unBrowserHandle);

		// Token: 0x0600021C RID: 540 RVA: 0x00004C57 File Offset: 0x00002E57
		internal void CopyToClipboard(HHTMLBrowser unBrowserHandle)
		{
			ISteamHTMLSurface._CopyToClipboard(this.Self, unBrowserHandle);
		}

		// Token: 0x0600021D RID: 541
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_PasteFromClipboard")]
		private static extern void _PasteFromClipboard(IntPtr self, HHTMLBrowser unBrowserHandle);

		// Token: 0x0600021E RID: 542 RVA: 0x00004C65 File Offset: 0x00002E65
		internal void PasteFromClipboard(HHTMLBrowser unBrowserHandle)
		{
			ISteamHTMLSurface._PasteFromClipboard(this.Self, unBrowserHandle);
		}

		// Token: 0x0600021F RID: 543
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_Find")]
		private static extern void _Find(IntPtr self, HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchSearchStr, [MarshalAs(UnmanagedType.U1)] bool bCurrentlyInFind, [MarshalAs(UnmanagedType.U1)] bool bReverse);

		// Token: 0x06000220 RID: 544 RVA: 0x00004C73 File Offset: 0x00002E73
		internal void Find(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchSearchStr, [MarshalAs(UnmanagedType.U1)] bool bCurrentlyInFind, [MarshalAs(UnmanagedType.U1)] bool bReverse)
		{
			ISteamHTMLSurface._Find(this.Self, unBrowserHandle, pchSearchStr, bCurrentlyInFind, bReverse);
		}

		// Token: 0x06000221 RID: 545
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_StopFind")]
		private static extern void _StopFind(IntPtr self, HHTMLBrowser unBrowserHandle);

		// Token: 0x06000222 RID: 546 RVA: 0x00004C85 File Offset: 0x00002E85
		internal void StopFind(HHTMLBrowser unBrowserHandle)
		{
			ISteamHTMLSurface._StopFind(this.Self, unBrowserHandle);
		}

		// Token: 0x06000223 RID: 547
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_GetLinkAtPosition")]
		private static extern void _GetLinkAtPosition(IntPtr self, HHTMLBrowser unBrowserHandle, int x, int y);

		// Token: 0x06000224 RID: 548 RVA: 0x00004C93 File Offset: 0x00002E93
		internal void GetLinkAtPosition(HHTMLBrowser unBrowserHandle, int x, int y)
		{
			ISteamHTMLSurface._GetLinkAtPosition(this.Self, unBrowserHandle, x, y);
		}

		// Token: 0x06000225 RID: 549
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetCookie")]
		private static extern void _SetCookie(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchHostname, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPath, RTime32 nExpires, [MarshalAs(UnmanagedType.U1)] bool bSecure, [MarshalAs(UnmanagedType.U1)] bool bHTTPOnly);

		// Token: 0x06000226 RID: 550 RVA: 0x00004CA3 File Offset: 0x00002EA3
		internal void SetCookie([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchHostname, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchPath, RTime32 nExpires, [MarshalAs(UnmanagedType.U1)] bool bSecure, [MarshalAs(UnmanagedType.U1)] bool bHTTPOnly)
		{
			ISteamHTMLSurface._SetCookie(this.Self, pchHostname, pchKey, pchValue, pchPath, nExpires, bSecure, bHTTPOnly);
		}

		// Token: 0x06000227 RID: 551
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetPageScaleFactor")]
		private static extern void _SetPageScaleFactor(IntPtr self, HHTMLBrowser unBrowserHandle, float flZoom, int nPointX, int nPointY);

		// Token: 0x06000228 RID: 552 RVA: 0x00004CBB File Offset: 0x00002EBB
		internal void SetPageScaleFactor(HHTMLBrowser unBrowserHandle, float flZoom, int nPointX, int nPointY)
		{
			ISteamHTMLSurface._SetPageScaleFactor(this.Self, unBrowserHandle, flZoom, nPointX, nPointY);
		}

		// Token: 0x06000229 RID: 553
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetBackgroundMode")]
		private static extern void _SetBackgroundMode(IntPtr self, HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.U1)] bool bBackgroundMode);

		// Token: 0x0600022A RID: 554 RVA: 0x00004CCD File Offset: 0x00002ECD
		internal void SetBackgroundMode(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.U1)] bool bBackgroundMode)
		{
			ISteamHTMLSurface._SetBackgroundMode(this.Self, unBrowserHandle, bBackgroundMode);
		}

		// Token: 0x0600022B RID: 555
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetDPIScalingFactor")]
		private static extern void _SetDPIScalingFactor(IntPtr self, HHTMLBrowser unBrowserHandle, float flDPIScaling);

		// Token: 0x0600022C RID: 556 RVA: 0x00004CDC File Offset: 0x00002EDC
		internal void SetDPIScalingFactor(HHTMLBrowser unBrowserHandle, float flDPIScaling)
		{
			ISteamHTMLSurface._SetDPIScalingFactor(this.Self, unBrowserHandle, flDPIScaling);
		}

		// Token: 0x0600022D RID: 557
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_OpenDeveloperTools")]
		private static extern void _OpenDeveloperTools(IntPtr self, HHTMLBrowser unBrowserHandle);

		// Token: 0x0600022E RID: 558 RVA: 0x00004CEB File Offset: 0x00002EEB
		internal void OpenDeveloperTools(HHTMLBrowser unBrowserHandle)
		{
			ISteamHTMLSurface._OpenDeveloperTools(this.Self, unBrowserHandle);
		}

		// Token: 0x0600022F RID: 559
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_AllowStartRequest")]
		private static extern void _AllowStartRequest(IntPtr self, HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.U1)] bool bAllowed);

		// Token: 0x06000230 RID: 560 RVA: 0x00004CF9 File Offset: 0x00002EF9
		internal void AllowStartRequest(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.U1)] bool bAllowed)
		{
			ISteamHTMLSurface._AllowStartRequest(this.Self, unBrowserHandle, bAllowed);
		}

		// Token: 0x06000231 RID: 561
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_JSDialogResponse")]
		private static extern void _JSDialogResponse(IntPtr self, HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.U1)] bool bResult);

		// Token: 0x06000232 RID: 562 RVA: 0x00004D08 File Offset: 0x00002F08
		internal void JSDialogResponse(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.U1)] bool bResult)
		{
			ISteamHTMLSurface._JSDialogResponse(this.Self, unBrowserHandle, bResult);
		}

		// Token: 0x06000233 RID: 563
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTMLSurface_FileLoadDialogResponse")]
		private static extern void _FileLoadDialogResponse(IntPtr self, HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchSelectedFiles);

		// Token: 0x06000234 RID: 564 RVA: 0x00004D17 File Offset: 0x00002F17
		internal void FileLoadDialogResponse(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchSelectedFiles)
		{
			ISteamHTMLSurface._FileLoadDialogResponse(this.Self, unBrowserHandle, pchSelectedFiles);
		}
	}
}
