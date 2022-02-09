using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x02000035 RID: 53
	internal class ISteamScreenshots : SteamInterface
	{
		// Token: 0x06000422 RID: 1058 RVA: 0x00005D60 File Offset: 0x00003F60
		internal ISteamScreenshots(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x06000423 RID: 1059
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamScreenshots_v003();

		// Token: 0x06000424 RID: 1060 RVA: 0x00005D6F File Offset: 0x00003F6F
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamScreenshots.SteamAPI_SteamScreenshots_v003();
		}

		// Token: 0x06000425 RID: 1061
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamScreenshots_WriteScreenshot")]
		private static extern ScreenshotHandle _WriteScreenshot(IntPtr self, IntPtr pubRGB, uint cubRGB, int nWidth, int nHeight);

		// Token: 0x06000426 RID: 1062 RVA: 0x00005D76 File Offset: 0x00003F76
		internal ScreenshotHandle WriteScreenshot(IntPtr pubRGB, uint cubRGB, int nWidth, int nHeight)
		{
			return ISteamScreenshots._WriteScreenshot(this.Self, pubRGB, cubRGB, nWidth, nHeight);
		}

		// Token: 0x06000427 RID: 1063
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamScreenshots_AddScreenshotToLibrary")]
		private static extern ScreenshotHandle _AddScreenshotToLibrary(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchFilename, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchThumbnailFilename, int nWidth, int nHeight);

		// Token: 0x06000428 RID: 1064 RVA: 0x00005D88 File Offset: 0x00003F88
		internal ScreenshotHandle AddScreenshotToLibrary([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchFilename, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchThumbnailFilename, int nWidth, int nHeight)
		{
			return ISteamScreenshots._AddScreenshotToLibrary(this.Self, pchFilename, pchThumbnailFilename, nWidth, nHeight);
		}

		// Token: 0x06000429 RID: 1065
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamScreenshots_TriggerScreenshot")]
		private static extern void _TriggerScreenshot(IntPtr self);

		// Token: 0x0600042A RID: 1066 RVA: 0x00005D9A File Offset: 0x00003F9A
		internal void TriggerScreenshot()
		{
			ISteamScreenshots._TriggerScreenshot(this.Self);
		}

		// Token: 0x0600042B RID: 1067
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamScreenshots_HookScreenshots")]
		private static extern void _HookScreenshots(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bHook);

		// Token: 0x0600042C RID: 1068 RVA: 0x00005DA7 File Offset: 0x00003FA7
		internal void HookScreenshots([MarshalAs(UnmanagedType.U1)] bool bHook)
		{
			ISteamScreenshots._HookScreenshots(this.Self, bHook);
		}

		// Token: 0x0600042D RID: 1069
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamScreenshots_SetLocation")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetLocation(IntPtr self, ScreenshotHandle hScreenshot, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchLocation);

		// Token: 0x0600042E RID: 1070 RVA: 0x00005DB5 File Offset: 0x00003FB5
		internal bool SetLocation(ScreenshotHandle hScreenshot, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchLocation)
		{
			return ISteamScreenshots._SetLocation(this.Self, hScreenshot, pchLocation);
		}

		// Token: 0x0600042F RID: 1071
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamScreenshots_TagUser")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _TagUser(IntPtr self, ScreenshotHandle hScreenshot, SteamId steamID);

		// Token: 0x06000430 RID: 1072 RVA: 0x00005DC4 File Offset: 0x00003FC4
		internal bool TagUser(ScreenshotHandle hScreenshot, SteamId steamID)
		{
			return ISteamScreenshots._TagUser(this.Self, hScreenshot, steamID);
		}

		// Token: 0x06000431 RID: 1073
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamScreenshots_TagPublishedFile")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _TagPublishedFile(IntPtr self, ScreenshotHandle hScreenshot, PublishedFileId unPublishedFileID);

		// Token: 0x06000432 RID: 1074 RVA: 0x00005DD3 File Offset: 0x00003FD3
		internal bool TagPublishedFile(ScreenshotHandle hScreenshot, PublishedFileId unPublishedFileID)
		{
			return ISteamScreenshots._TagPublishedFile(this.Self, hScreenshot, unPublishedFileID);
		}

		// Token: 0x06000433 RID: 1075
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamScreenshots_IsScreenshotsHooked")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsScreenshotsHooked(IntPtr self);

		// Token: 0x06000434 RID: 1076 RVA: 0x00005DE2 File Offset: 0x00003FE2
		internal bool IsScreenshotsHooked()
		{
			return ISteamScreenshots._IsScreenshotsHooked(this.Self);
		}

		// Token: 0x06000435 RID: 1077
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamScreenshots_AddVRScreenshotToLibrary")]
		private static extern ScreenshotHandle _AddVRScreenshotToLibrary(IntPtr self, VRScreenshotType eType, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchFilename, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVRFilename);

		// Token: 0x06000436 RID: 1078 RVA: 0x00005DEF File Offset: 0x00003FEF
		internal ScreenshotHandle AddVRScreenshotToLibrary(VRScreenshotType eType, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchFilename, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVRFilename)
		{
			return ISteamScreenshots._AddVRScreenshotToLibrary(this.Self, eType, pchFilename, pchVRFilename);
		}
	}
}
