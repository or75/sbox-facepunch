using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x02000028 RID: 40
	internal class ISteamHTTP : SteamInterface
	{
		// Token: 0x06000235 RID: 565 RVA: 0x00004D26 File Offset: 0x00002F26
		internal ISteamHTTP(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x06000236 RID: 566
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamHTTP_v003();

		// Token: 0x06000237 RID: 567 RVA: 0x00004D35 File Offset: 0x00002F35
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamHTTP.SteamAPI_SteamHTTP_v003();
		}

		// Token: 0x06000238 RID: 568
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamGameServerHTTP_v003();

		// Token: 0x06000239 RID: 569 RVA: 0x00004D3C File Offset: 0x00002F3C
		internal override IntPtr GetServerInterfacePointer()
		{
			return ISteamHTTP.SteamAPI_SteamGameServerHTTP_v003();
		}

		// Token: 0x0600023A RID: 570
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_CreateHTTPRequest")]
		private static extern HTTPRequestHandle _CreateHTTPRequest(IntPtr self, HTTPMethod eHTTPRequestMethod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchAbsoluteURL);

		// Token: 0x0600023B RID: 571 RVA: 0x00004D43 File Offset: 0x00002F43
		internal HTTPRequestHandle CreateHTTPRequest(HTTPMethod eHTTPRequestMethod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchAbsoluteURL)
		{
			return ISteamHTTP._CreateHTTPRequest(this.Self, eHTTPRequestMethod, pchAbsoluteURL);
		}

		// Token: 0x0600023C RID: 572
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestContextValue")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetHTTPRequestContextValue(IntPtr self, HTTPRequestHandle hRequest, ulong ulContextValue);

		// Token: 0x0600023D RID: 573 RVA: 0x00004D52 File Offset: 0x00002F52
		internal bool SetHTTPRequestContextValue(HTTPRequestHandle hRequest, ulong ulContextValue)
		{
			return ISteamHTTP._SetHTTPRequestContextValue(this.Self, hRequest, ulContextValue);
		}

		// Token: 0x0600023E RID: 574
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestNetworkActivityTimeout")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetHTTPRequestNetworkActivityTimeout(IntPtr self, HTTPRequestHandle hRequest, uint unTimeoutSeconds);

		// Token: 0x0600023F RID: 575 RVA: 0x00004D61 File Offset: 0x00002F61
		internal bool SetHTTPRequestNetworkActivityTimeout(HTTPRequestHandle hRequest, uint unTimeoutSeconds)
		{
			return ISteamHTTP._SetHTTPRequestNetworkActivityTimeout(this.Self, hRequest, unTimeoutSeconds);
		}

		// Token: 0x06000240 RID: 576
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestHeaderValue")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetHTTPRequestHeaderValue(IntPtr self, HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchHeaderName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchHeaderValue);

		// Token: 0x06000241 RID: 577 RVA: 0x00004D70 File Offset: 0x00002F70
		internal bool SetHTTPRequestHeaderValue(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchHeaderName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchHeaderValue)
		{
			return ISteamHTTP._SetHTTPRequestHeaderValue(this.Self, hRequest, pchHeaderName, pchHeaderValue);
		}

		// Token: 0x06000242 RID: 578
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestGetOrPostParameter")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetHTTPRequestGetOrPostParameter(IntPtr self, HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchParamName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchParamValue);

		// Token: 0x06000243 RID: 579 RVA: 0x00004D80 File Offset: 0x00002F80
		internal bool SetHTTPRequestGetOrPostParameter(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchParamName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchParamValue)
		{
			return ISteamHTTP._SetHTTPRequestGetOrPostParameter(this.Self, hRequest, pchParamName, pchParamValue);
		}

		// Token: 0x06000244 RID: 580
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_SendHTTPRequest")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SendHTTPRequest(IntPtr self, HTTPRequestHandle hRequest, ref SteamAPICall_t pCallHandle);

		// Token: 0x06000245 RID: 581 RVA: 0x00004D90 File Offset: 0x00002F90
		internal bool SendHTTPRequest(HTTPRequestHandle hRequest, ref SteamAPICall_t pCallHandle)
		{
			return ISteamHTTP._SendHTTPRequest(this.Self, hRequest, ref pCallHandle);
		}

		// Token: 0x06000246 RID: 582
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_SendHTTPRequestAndStreamResponse")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SendHTTPRequestAndStreamResponse(IntPtr self, HTTPRequestHandle hRequest, ref SteamAPICall_t pCallHandle);

		// Token: 0x06000247 RID: 583 RVA: 0x00004D9F File Offset: 0x00002F9F
		internal bool SendHTTPRequestAndStreamResponse(HTTPRequestHandle hRequest, ref SteamAPICall_t pCallHandle)
		{
			return ISteamHTTP._SendHTTPRequestAndStreamResponse(this.Self, hRequest, ref pCallHandle);
		}

		// Token: 0x06000248 RID: 584
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_DeferHTTPRequest")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _DeferHTTPRequest(IntPtr self, HTTPRequestHandle hRequest);

		// Token: 0x06000249 RID: 585 RVA: 0x00004DAE File Offset: 0x00002FAE
		internal bool DeferHTTPRequest(HTTPRequestHandle hRequest)
		{
			return ISteamHTTP._DeferHTTPRequest(this.Self, hRequest);
		}

		// Token: 0x0600024A RID: 586
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_PrioritizeHTTPRequest")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _PrioritizeHTTPRequest(IntPtr self, HTTPRequestHandle hRequest);

		// Token: 0x0600024B RID: 587 RVA: 0x00004DBC File Offset: 0x00002FBC
		internal bool PrioritizeHTTPRequest(HTTPRequestHandle hRequest)
		{
			return ISteamHTTP._PrioritizeHTTPRequest(this.Self, hRequest);
		}

		// Token: 0x0600024C RID: 588
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseHeaderSize")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetHTTPResponseHeaderSize(IntPtr self, HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchHeaderName, ref uint unResponseHeaderSize);

		// Token: 0x0600024D RID: 589 RVA: 0x00004DCA File Offset: 0x00002FCA
		internal bool GetHTTPResponseHeaderSize(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchHeaderName, ref uint unResponseHeaderSize)
		{
			return ISteamHTTP._GetHTTPResponseHeaderSize(this.Self, hRequest, pchHeaderName, ref unResponseHeaderSize);
		}

		// Token: 0x0600024E RID: 590
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseHeaderValue")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetHTTPResponseHeaderValue(IntPtr self, HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchHeaderName, ref byte pHeaderValueBuffer, uint unBufferSize);

		// Token: 0x0600024F RID: 591 RVA: 0x00004DDA File Offset: 0x00002FDA
		internal bool GetHTTPResponseHeaderValue(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchHeaderName, ref byte pHeaderValueBuffer, uint unBufferSize)
		{
			return ISteamHTTP._GetHTTPResponseHeaderValue(this.Self, hRequest, pchHeaderName, ref pHeaderValueBuffer, unBufferSize);
		}

		// Token: 0x06000250 RID: 592
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseBodySize")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetHTTPResponseBodySize(IntPtr self, HTTPRequestHandle hRequest, ref uint unBodySize);

		// Token: 0x06000251 RID: 593 RVA: 0x00004DEC File Offset: 0x00002FEC
		internal bool GetHTTPResponseBodySize(HTTPRequestHandle hRequest, ref uint unBodySize)
		{
			return ISteamHTTP._GetHTTPResponseBodySize(this.Self, hRequest, ref unBodySize);
		}

		// Token: 0x06000252 RID: 594
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseBodyData")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetHTTPResponseBodyData(IntPtr self, HTTPRequestHandle hRequest, ref byte pBodyDataBuffer, uint unBufferSize);

		// Token: 0x06000253 RID: 595 RVA: 0x00004DFB File Offset: 0x00002FFB
		internal bool GetHTTPResponseBodyData(HTTPRequestHandle hRequest, ref byte pBodyDataBuffer, uint unBufferSize)
		{
			return ISteamHTTP._GetHTTPResponseBodyData(this.Self, hRequest, ref pBodyDataBuffer, unBufferSize);
		}

		// Token: 0x06000254 RID: 596
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPStreamingResponseBodyData")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetHTTPStreamingResponseBodyData(IntPtr self, HTTPRequestHandle hRequest, uint cOffset, ref byte pBodyDataBuffer, uint unBufferSize);

		// Token: 0x06000255 RID: 597 RVA: 0x00004E0B File Offset: 0x0000300B
		internal bool GetHTTPStreamingResponseBodyData(HTTPRequestHandle hRequest, uint cOffset, ref byte pBodyDataBuffer, uint unBufferSize)
		{
			return ISteamHTTP._GetHTTPStreamingResponseBodyData(this.Self, hRequest, cOffset, ref pBodyDataBuffer, unBufferSize);
		}

		// Token: 0x06000256 RID: 598
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_ReleaseHTTPRequest")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _ReleaseHTTPRequest(IntPtr self, HTTPRequestHandle hRequest);

		// Token: 0x06000257 RID: 599 RVA: 0x00004E1D File Offset: 0x0000301D
		internal bool ReleaseHTTPRequest(HTTPRequestHandle hRequest)
		{
			return ISteamHTTP._ReleaseHTTPRequest(this.Self, hRequest);
		}

		// Token: 0x06000258 RID: 600
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPDownloadProgressPct")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetHTTPDownloadProgressPct(IntPtr self, HTTPRequestHandle hRequest, ref float pflPercentOut);

		// Token: 0x06000259 RID: 601 RVA: 0x00004E2B File Offset: 0x0000302B
		internal bool GetHTTPDownloadProgressPct(HTTPRequestHandle hRequest, ref float pflPercentOut)
		{
			return ISteamHTTP._GetHTTPDownloadProgressPct(this.Self, hRequest, ref pflPercentOut);
		}

		// Token: 0x0600025A RID: 602
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestRawPostBody")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetHTTPRequestRawPostBody(IntPtr self, HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchContentType, [In] [Out] byte[] pubBody, uint unBodyLen);

		// Token: 0x0600025B RID: 603 RVA: 0x00004E3A File Offset: 0x0000303A
		internal bool SetHTTPRequestRawPostBody(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchContentType, [In] [Out] byte[] pubBody, uint unBodyLen)
		{
			return ISteamHTTP._SetHTTPRequestRawPostBody(this.Self, hRequest, pchContentType, pubBody, unBodyLen);
		}

		// Token: 0x0600025C RID: 604
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_CreateCookieContainer")]
		private static extern HTTPCookieContainerHandle _CreateCookieContainer(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bAllowResponsesToModify);

		// Token: 0x0600025D RID: 605 RVA: 0x00004E4C File Offset: 0x0000304C
		internal HTTPCookieContainerHandle CreateCookieContainer([MarshalAs(UnmanagedType.U1)] bool bAllowResponsesToModify)
		{
			return ISteamHTTP._CreateCookieContainer(this.Self, bAllowResponsesToModify);
		}

		// Token: 0x0600025E RID: 606
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_ReleaseCookieContainer")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _ReleaseCookieContainer(IntPtr self, HTTPCookieContainerHandle hCookieContainer);

		// Token: 0x0600025F RID: 607 RVA: 0x00004E5A File Offset: 0x0000305A
		internal bool ReleaseCookieContainer(HTTPCookieContainerHandle hCookieContainer)
		{
			return ISteamHTTP._ReleaseCookieContainer(this.Self, hCookieContainer);
		}

		// Token: 0x06000260 RID: 608
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_SetCookie")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetCookie(IntPtr self, HTTPCookieContainerHandle hCookieContainer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchHost, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchUrl, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchCookie);

		// Token: 0x06000261 RID: 609 RVA: 0x00004E68 File Offset: 0x00003068
		internal bool SetCookie(HTTPCookieContainerHandle hCookieContainer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchHost, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchUrl, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchCookie)
		{
			return ISteamHTTP._SetCookie(this.Self, hCookieContainer, pchHost, pchUrl, pchCookie);
		}

		// Token: 0x06000262 RID: 610
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestCookieContainer")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetHTTPRequestCookieContainer(IntPtr self, HTTPRequestHandle hRequest, HTTPCookieContainerHandle hCookieContainer);

		// Token: 0x06000263 RID: 611 RVA: 0x00004E7A File Offset: 0x0000307A
		internal bool SetHTTPRequestCookieContainer(HTTPRequestHandle hRequest, HTTPCookieContainerHandle hCookieContainer)
		{
			return ISteamHTTP._SetHTTPRequestCookieContainer(this.Self, hRequest, hCookieContainer);
		}

		// Token: 0x06000264 RID: 612
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestUserAgentInfo")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetHTTPRequestUserAgentInfo(IntPtr self, HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchUserAgentInfo);

		// Token: 0x06000265 RID: 613 RVA: 0x00004E89 File Offset: 0x00003089
		internal bool SetHTTPRequestUserAgentInfo(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchUserAgentInfo)
		{
			return ISteamHTTP._SetHTTPRequestUserAgentInfo(this.Self, hRequest, pchUserAgentInfo);
		}

		// Token: 0x06000266 RID: 614
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetHTTPRequestRequiresVerifiedCertificate(IntPtr self, HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.U1)] bool bRequireVerifiedCertificate);

		// Token: 0x06000267 RID: 615 RVA: 0x00004E98 File Offset: 0x00003098
		internal bool SetHTTPRequestRequiresVerifiedCertificate(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.U1)] bool bRequireVerifiedCertificate)
		{
			return ISteamHTTP._SetHTTPRequestRequiresVerifiedCertificate(this.Self, hRequest, bRequireVerifiedCertificate);
		}

		// Token: 0x06000268 RID: 616
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetHTTPRequestAbsoluteTimeoutMS(IntPtr self, HTTPRequestHandle hRequest, uint unMilliseconds);

		// Token: 0x06000269 RID: 617 RVA: 0x00004EA7 File Offset: 0x000030A7
		internal bool SetHTTPRequestAbsoluteTimeoutMS(HTTPRequestHandle hRequest, uint unMilliseconds)
		{
			return ISteamHTTP._SetHTTPRequestAbsoluteTimeoutMS(this.Self, hRequest, unMilliseconds);
		}

		// Token: 0x0600026A RID: 618
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPRequestWasTimedOut")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetHTTPRequestWasTimedOut(IntPtr self, HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.U1)] ref bool pbWasTimedOut);

		// Token: 0x0600026B RID: 619 RVA: 0x00004EB6 File Offset: 0x000030B6
		internal bool GetHTTPRequestWasTimedOut(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.U1)] ref bool pbWasTimedOut)
		{
			return ISteamHTTP._GetHTTPRequestWasTimedOut(this.Self, hRequest, ref pbWasTimedOut);
		}
	}
}
