using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x02000021 RID: 33
	internal class ISteamApps : SteamInterface
	{
		// Token: 0x0600003C RID: 60 RVA: 0x00003C42 File Offset: 0x00001E42
		internal ISteamApps(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x0600003D RID: 61
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamApps_v008();

		// Token: 0x0600003E RID: 62 RVA: 0x00003C51 File Offset: 0x00001E51
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamApps.SteamAPI_SteamApps_v008();
		}

		// Token: 0x0600003F RID: 63
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribed")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsSubscribed(IntPtr self);

		// Token: 0x06000040 RID: 64 RVA: 0x00003C58 File Offset: 0x00001E58
		internal bool BIsSubscribed()
		{
			return ISteamApps._BIsSubscribed(this.Self);
		}

		// Token: 0x06000041 RID: 65
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_BIsLowViolence")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsLowViolence(IntPtr self);

		// Token: 0x06000042 RID: 66 RVA: 0x00003C65 File Offset: 0x00001E65
		internal bool BIsLowViolence()
		{
			return ISteamApps._BIsLowViolence(this.Self);
		}

		// Token: 0x06000043 RID: 67
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_BIsCybercafe")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsCybercafe(IntPtr self);

		// Token: 0x06000044 RID: 68 RVA: 0x00003C72 File Offset: 0x00001E72
		internal bool BIsCybercafe()
		{
			return ISteamApps._BIsCybercafe(this.Self);
		}

		// Token: 0x06000045 RID: 69
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_BIsVACBanned")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsVACBanned(IntPtr self);

		// Token: 0x06000046 RID: 70 RVA: 0x00003C7F File Offset: 0x00001E7F
		internal bool BIsVACBanned()
		{
			return ISteamApps._BIsVACBanned(this.Self);
		}

		// Token: 0x06000047 RID: 71
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_GetCurrentGameLanguage")]
		private static extern Utf8StringPointer _GetCurrentGameLanguage(IntPtr self);

		// Token: 0x06000048 RID: 72 RVA: 0x00003C8C File Offset: 0x00001E8C
		internal string GetCurrentGameLanguage()
		{
			return ISteamApps._GetCurrentGameLanguage(this.Self);
		}

		// Token: 0x06000049 RID: 73
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_GetAvailableGameLanguages")]
		private static extern Utf8StringPointer _GetAvailableGameLanguages(IntPtr self);

		// Token: 0x0600004A RID: 74 RVA: 0x00003C9E File Offset: 0x00001E9E
		internal string GetAvailableGameLanguages()
		{
			return ISteamApps._GetAvailableGameLanguages(this.Self);
		}

		// Token: 0x0600004B RID: 75
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribedApp")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsSubscribedApp(IntPtr self, AppId appID);

		// Token: 0x0600004C RID: 76 RVA: 0x00003CB0 File Offset: 0x00001EB0
		internal bool BIsSubscribedApp(AppId appID)
		{
			return ISteamApps._BIsSubscribedApp(this.Self, appID);
		}

		// Token: 0x0600004D RID: 77
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_BIsDlcInstalled")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsDlcInstalled(IntPtr self, AppId appID);

		// Token: 0x0600004E RID: 78 RVA: 0x00003CBE File Offset: 0x00001EBE
		internal bool BIsDlcInstalled(AppId appID)
		{
			return ISteamApps._BIsDlcInstalled(this.Self, appID);
		}

		// Token: 0x0600004F RID: 79
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_GetEarliestPurchaseUnixTime")]
		private static extern uint _GetEarliestPurchaseUnixTime(IntPtr self, AppId nAppID);

		// Token: 0x06000050 RID: 80 RVA: 0x00003CCC File Offset: 0x00001ECC
		internal uint GetEarliestPurchaseUnixTime(AppId nAppID)
		{
			return ISteamApps._GetEarliestPurchaseUnixTime(this.Self, nAppID);
		}

		// Token: 0x06000051 RID: 81
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribedFromFreeWeekend")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsSubscribedFromFreeWeekend(IntPtr self);

		// Token: 0x06000052 RID: 82 RVA: 0x00003CDA File Offset: 0x00001EDA
		internal bool BIsSubscribedFromFreeWeekend()
		{
			return ISteamApps._BIsSubscribedFromFreeWeekend(this.Self);
		}

		// Token: 0x06000053 RID: 83
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_GetDLCCount")]
		private static extern int _GetDLCCount(IntPtr self);

		// Token: 0x06000054 RID: 84 RVA: 0x00003CE7 File Offset: 0x00001EE7
		internal int GetDLCCount()
		{
			return ISteamApps._GetDLCCount(this.Self);
		}

		// Token: 0x06000055 RID: 85
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_BGetDLCDataByIndex")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BGetDLCDataByIndex(IntPtr self, int iDLC, ref AppId pAppID, [MarshalAs(UnmanagedType.U1)] ref bool pbAvailable, IntPtr pchName, int cchNameBufferSize);

		// Token: 0x06000056 RID: 86 RVA: 0x00003CF4 File Offset: 0x00001EF4
		internal bool BGetDLCDataByIndex(int iDLC, ref AppId pAppID, [MarshalAs(UnmanagedType.U1)] ref bool pbAvailable, out string pchName)
		{
			Helpers.Memory mempchName = Helpers.TakeMemory();
			bool result;
			try
			{
				bool flag = ISteamApps._BGetDLCDataByIndex(this.Self, iDLC, ref pAppID, ref pbAvailable, mempchName, 32768);
				pchName = Helpers.MemoryToString(mempchName);
				result = flag;
			}
			finally
			{
				((IDisposable)mempchName).Dispose();
			}
			return result;
		}

		// Token: 0x06000057 RID: 87
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_InstallDLC")]
		private static extern void _InstallDLC(IntPtr self, AppId nAppID);

		// Token: 0x06000058 RID: 88 RVA: 0x00003D54 File Offset: 0x00001F54
		internal void InstallDLC(AppId nAppID)
		{
			ISteamApps._InstallDLC(this.Self, nAppID);
		}

		// Token: 0x06000059 RID: 89
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_UninstallDLC")]
		private static extern void _UninstallDLC(IntPtr self, AppId nAppID);

		// Token: 0x0600005A RID: 90 RVA: 0x00003D62 File Offset: 0x00001F62
		internal void UninstallDLC(AppId nAppID)
		{
			ISteamApps._UninstallDLC(this.Self, nAppID);
		}

		// Token: 0x0600005B RID: 91
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_RequestAppProofOfPurchaseKey")]
		private static extern void _RequestAppProofOfPurchaseKey(IntPtr self, AppId nAppID);

		// Token: 0x0600005C RID: 92 RVA: 0x00003D70 File Offset: 0x00001F70
		internal void RequestAppProofOfPurchaseKey(AppId nAppID)
		{
			ISteamApps._RequestAppProofOfPurchaseKey(this.Self, nAppID);
		}

		// Token: 0x0600005D RID: 93
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_GetCurrentBetaName")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetCurrentBetaName(IntPtr self, IntPtr pchName, int cchNameBufferSize);

		// Token: 0x0600005E RID: 94 RVA: 0x00003D80 File Offset: 0x00001F80
		internal bool GetCurrentBetaName(out string pchName)
		{
			Helpers.Memory mempchName = Helpers.TakeMemory();
			bool result;
			try
			{
				bool flag = ISteamApps._GetCurrentBetaName(this.Self, mempchName, 32768);
				pchName = Helpers.MemoryToString(mempchName);
				result = flag;
			}
			finally
			{
				((IDisposable)mempchName).Dispose();
			}
			return result;
		}

		// Token: 0x0600005F RID: 95
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_MarkContentCorrupt")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _MarkContentCorrupt(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bMissingFilesOnly);

		// Token: 0x06000060 RID: 96 RVA: 0x00003DDC File Offset: 0x00001FDC
		internal bool MarkContentCorrupt([MarshalAs(UnmanagedType.U1)] bool bMissingFilesOnly)
		{
			return ISteamApps._MarkContentCorrupt(this.Self, bMissingFilesOnly);
		}

		// Token: 0x06000061 RID: 97
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_GetInstalledDepots")]
		private static extern uint _GetInstalledDepots(IntPtr self, AppId appID, [In] [Out] DepotId_t[] pvecDepots, uint cMaxDepots);

		// Token: 0x06000062 RID: 98 RVA: 0x00003DEA File Offset: 0x00001FEA
		internal uint GetInstalledDepots(AppId appID, [In] [Out] DepotId_t[] pvecDepots, uint cMaxDepots)
		{
			return ISteamApps._GetInstalledDepots(this.Self, appID, pvecDepots, cMaxDepots);
		}

		// Token: 0x06000063 RID: 99
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_GetAppInstallDir")]
		private static extern uint _GetAppInstallDir(IntPtr self, AppId appID, IntPtr pchFolder, uint cchFolderBufferSize);

		// Token: 0x06000064 RID: 100 RVA: 0x00003DFC File Offset: 0x00001FFC
		internal uint GetAppInstallDir(AppId appID, out string pchFolder)
		{
			Helpers.Memory mempchFolder = Helpers.TakeMemory();
			uint result;
			try
			{
				uint num = ISteamApps._GetAppInstallDir(this.Self, appID, mempchFolder, 32768U);
				pchFolder = Helpers.MemoryToString(mempchFolder);
				result = num;
			}
			finally
			{
				((IDisposable)mempchFolder).Dispose();
			}
			return result;
		}

		// Token: 0x06000065 RID: 101
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_BIsAppInstalled")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsAppInstalled(IntPtr self, AppId appID);

		// Token: 0x06000066 RID: 102 RVA: 0x00003E58 File Offset: 0x00002058
		internal bool BIsAppInstalled(AppId appID)
		{
			return ISteamApps._BIsAppInstalled(this.Self, appID);
		}

		// Token: 0x06000067 RID: 103
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_GetAppOwner")]
		private static extern SteamId _GetAppOwner(IntPtr self);

		// Token: 0x06000068 RID: 104 RVA: 0x00003E66 File Offset: 0x00002066
		internal SteamId GetAppOwner()
		{
			return ISteamApps._GetAppOwner(this.Self);
		}

		// Token: 0x06000069 RID: 105
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_GetLaunchQueryParam")]
		private static extern Utf8StringPointer _GetLaunchQueryParam(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey);

		// Token: 0x0600006A RID: 106 RVA: 0x00003E73 File Offset: 0x00002073
		internal string GetLaunchQueryParam([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey)
		{
			return ISteamApps._GetLaunchQueryParam(this.Self, pchKey);
		}

		// Token: 0x0600006B RID: 107
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_GetDlcDownloadProgress")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetDlcDownloadProgress(IntPtr self, AppId nAppID, ref ulong punBytesDownloaded, ref ulong punBytesTotal);

		// Token: 0x0600006C RID: 108 RVA: 0x00003E86 File Offset: 0x00002086
		internal bool GetDlcDownloadProgress(AppId nAppID, ref ulong punBytesDownloaded, ref ulong punBytesTotal)
		{
			return ISteamApps._GetDlcDownloadProgress(this.Self, nAppID, ref punBytesDownloaded, ref punBytesTotal);
		}

		// Token: 0x0600006D RID: 109
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_GetAppBuildId")]
		private static extern int _GetAppBuildId(IntPtr self);

		// Token: 0x0600006E RID: 110 RVA: 0x00003E96 File Offset: 0x00002096
		internal int GetAppBuildId()
		{
			return ISteamApps._GetAppBuildId(this.Self);
		}

		// Token: 0x0600006F RID: 111
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_RequestAllProofOfPurchaseKeys")]
		private static extern void _RequestAllProofOfPurchaseKeys(IntPtr self);

		// Token: 0x06000070 RID: 112 RVA: 0x00003EA3 File Offset: 0x000020A3
		internal void RequestAllProofOfPurchaseKeys()
		{
			ISteamApps._RequestAllProofOfPurchaseKeys(this.Self);
		}

		// Token: 0x06000071 RID: 113
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_GetFileDetails")]
		private static extern SteamAPICall_t _GetFileDetails(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszFileName);

		// Token: 0x06000072 RID: 114 RVA: 0x00003EB0 File Offset: 0x000020B0
		internal CallResult<FileDetailsResult_t> GetFileDetails([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszFileName)
		{
			return new CallResult<FileDetailsResult_t>(ISteamApps._GetFileDetails(this.Self, pszFileName), base.IsServer);
		}

		// Token: 0x06000073 RID: 115
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_GetLaunchCommandLine")]
		private static extern int _GetLaunchCommandLine(IntPtr self, IntPtr pszCommandLine, int cubCommandLine);

		// Token: 0x06000074 RID: 116 RVA: 0x00003ECC File Offset: 0x000020CC
		internal int GetLaunchCommandLine(out string pszCommandLine)
		{
			Helpers.Memory mempszCommandLine = Helpers.TakeMemory();
			int result;
			try
			{
				int num = ISteamApps._GetLaunchCommandLine(this.Self, mempszCommandLine, 32768);
				pszCommandLine = Helpers.MemoryToString(mempszCommandLine);
				result = num;
			}
			finally
			{
				((IDisposable)mempszCommandLine).Dispose();
			}
			return result;
		}

		// Token: 0x06000075 RID: 117
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribedFromFamilySharing")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsSubscribedFromFamilySharing(IntPtr self);

		// Token: 0x06000076 RID: 118 RVA: 0x00003F28 File Offset: 0x00002128
		internal bool BIsSubscribedFromFamilySharing()
		{
			return ISteamApps._BIsSubscribedFromFamilySharing(this.Self);
		}

		// Token: 0x06000077 RID: 119
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamApps_BIsTimedTrial")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsTimedTrial(IntPtr self, ref uint punSecondsAllowed, ref uint punSecondsPlayed);

		// Token: 0x06000078 RID: 120 RVA: 0x00003F35 File Offset: 0x00002135
		internal bool BIsTimedTrial(ref uint punSecondsAllowed, ref uint punSecondsPlayed)
		{
			return ISteamApps._BIsTimedTrial(this.Self, ref punSecondsAllowed, ref punSecondsPlayed);
		}
	}
}
