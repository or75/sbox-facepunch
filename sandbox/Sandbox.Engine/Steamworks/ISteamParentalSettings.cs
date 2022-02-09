using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000033 RID: 51
	internal class ISteamParentalSettings : SteamInterface
	{
		// Token: 0x06000402 RID: 1026 RVA: 0x00005C7A File Offset: 0x00003E7A
		internal ISteamParentalSettings(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x06000403 RID: 1027
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamParentalSettings_v001();

		// Token: 0x06000404 RID: 1028 RVA: 0x00005C89 File Offset: 0x00003E89
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamParentalSettings.SteamAPI_SteamParentalSettings_v001();
		}

		// Token: 0x06000405 RID: 1029
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsParentalLockEnabled")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsParentalLockEnabled(IntPtr self);

		// Token: 0x06000406 RID: 1030 RVA: 0x00005C90 File Offset: 0x00003E90
		internal bool BIsParentalLockEnabled()
		{
			return ISteamParentalSettings._BIsParentalLockEnabled(this.Self);
		}

		// Token: 0x06000407 RID: 1031
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsParentalLockLocked")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsParentalLockLocked(IntPtr self);

		// Token: 0x06000408 RID: 1032 RVA: 0x00005C9D File Offset: 0x00003E9D
		internal bool BIsParentalLockLocked()
		{
			return ISteamParentalSettings._BIsParentalLockLocked(this.Self);
		}

		// Token: 0x06000409 RID: 1033
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsAppBlocked")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsAppBlocked(IntPtr self, AppId nAppID);

		// Token: 0x0600040A RID: 1034 RVA: 0x00005CAA File Offset: 0x00003EAA
		internal bool BIsAppBlocked(AppId nAppID)
		{
			return ISteamParentalSettings._BIsAppBlocked(this.Self, nAppID);
		}

		// Token: 0x0600040B RID: 1035
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsAppInBlockList")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsAppInBlockList(IntPtr self, AppId nAppID);

		// Token: 0x0600040C RID: 1036 RVA: 0x00005CB8 File Offset: 0x00003EB8
		internal bool BIsAppInBlockList(AppId nAppID)
		{
			return ISteamParentalSettings._BIsAppInBlockList(this.Self, nAppID);
		}

		// Token: 0x0600040D RID: 1037
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsFeatureBlocked")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsFeatureBlocked(IntPtr self, ParentalFeature eFeature);

		// Token: 0x0600040E RID: 1038 RVA: 0x00005CC6 File Offset: 0x00003EC6
		internal bool BIsFeatureBlocked(ParentalFeature eFeature)
		{
			return ISteamParentalSettings._BIsFeatureBlocked(this.Self, eFeature);
		}

		// Token: 0x0600040F RID: 1039
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamParentalSettings_BIsFeatureInBlockList")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsFeatureInBlockList(IntPtr self, ParentalFeature eFeature);

		// Token: 0x06000410 RID: 1040 RVA: 0x00005CD4 File Offset: 0x00003ED4
		internal bool BIsFeatureInBlockList(ParentalFeature eFeature)
		{
			return ISteamParentalSettings._BIsFeatureInBlockList(this.Self, eFeature);
		}
	}
}
