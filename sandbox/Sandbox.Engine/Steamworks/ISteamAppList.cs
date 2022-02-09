using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000020 RID: 32
	internal class ISteamAppList : SteamInterface
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00003B49 File Offset: 0x00001D49
		internal ISteamAppList(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x06000030 RID: 48
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamAppList_v001();

		// Token: 0x06000031 RID: 49 RVA: 0x00003B58 File Offset: 0x00001D58
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamAppList.SteamAPI_SteamAppList_v001();
		}

		// Token: 0x06000032 RID: 50
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamAppList_GetNumInstalledApps")]
		private static extern uint _GetNumInstalledApps(IntPtr self);

		// Token: 0x06000033 RID: 51 RVA: 0x00003B5F File Offset: 0x00001D5F
		internal uint GetNumInstalledApps()
		{
			return ISteamAppList._GetNumInstalledApps(this.Self);
		}

		// Token: 0x06000034 RID: 52
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamAppList_GetInstalledApps")]
		private static extern uint _GetInstalledApps(IntPtr self, [In] [Out] AppId[] pvecAppID, uint unMaxAppIDs);

		// Token: 0x06000035 RID: 53 RVA: 0x00003B6C File Offset: 0x00001D6C
		internal uint GetInstalledApps([In] [Out] AppId[] pvecAppID, uint unMaxAppIDs)
		{
			return ISteamAppList._GetInstalledApps(this.Self, pvecAppID, unMaxAppIDs);
		}

		// Token: 0x06000036 RID: 54
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamAppList_GetAppName")]
		private static extern int _GetAppName(IntPtr self, AppId nAppID, IntPtr pchName, int cchNameMax);

		// Token: 0x06000037 RID: 55 RVA: 0x00003B7C File Offset: 0x00001D7C
		internal int GetAppName(AppId nAppID, out string pchName)
		{
			Helpers.Memory mempchName = Helpers.TakeMemory();
			int result;
			try
			{
				int num = ISteamAppList._GetAppName(this.Self, nAppID, mempchName, 32768);
				pchName = Helpers.MemoryToString(mempchName);
				result = num;
			}
			finally
			{
				((IDisposable)mempchName).Dispose();
			}
			return result;
		}

		// Token: 0x06000038 RID: 56
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamAppList_GetAppInstallDir")]
		private static extern int _GetAppInstallDir(IntPtr self, AppId nAppID, IntPtr pchDirectory, int cchNameMax);

		// Token: 0x06000039 RID: 57 RVA: 0x00003BD8 File Offset: 0x00001DD8
		internal int GetAppInstallDir(AppId nAppID, out string pchDirectory)
		{
			Helpers.Memory mempchDirectory = Helpers.TakeMemory();
			int result;
			try
			{
				int num = ISteamAppList._GetAppInstallDir(this.Self, nAppID, mempchDirectory, 32768);
				pchDirectory = Helpers.MemoryToString(mempchDirectory);
				result = num;
			}
			finally
			{
				((IDisposable)mempchDirectory).Dispose();
			}
			return result;
		}

		// Token: 0x0600003A RID: 58
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamAppList_GetAppBuildId")]
		private static extern int _GetAppBuildId(IntPtr self, AppId nAppID);

		// Token: 0x0600003B RID: 59 RVA: 0x00003C34 File Offset: 0x00001E34
		internal int GetAppBuildId(AppId nAppID)
		{
			return ISteamAppList._GetAppBuildId(this.Self, nAppID);
		}
	}
}
