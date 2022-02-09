using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x02000026 RID: 38
	internal class ISteamGameServerStats : SteamInterface
	{
		// Token: 0x060001D1 RID: 465 RVA: 0x00004A07 File Offset: 0x00002C07
		internal ISteamGameServerStats(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x060001D2 RID: 466
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamGameServerStats_v001();

		// Token: 0x060001D3 RID: 467 RVA: 0x00004A16 File Offset: 0x00002C16
		internal override IntPtr GetServerInterfacePointer()
		{
			return ISteamGameServerStats.SteamAPI_SteamGameServerStats_v001();
		}

		// Token: 0x060001D4 RID: 468
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServerStats_RequestUserStats")]
		private static extern SteamAPICall_t _RequestUserStats(IntPtr self, SteamId steamIDUser);

		// Token: 0x060001D5 RID: 469 RVA: 0x00004A1D File Offset: 0x00002C1D
		internal CallResult<GSStatsReceived_t> RequestUserStats(SteamId steamIDUser)
		{
			return new CallResult<GSStatsReceived_t>(ISteamGameServerStats._RequestUserStats(this.Self, steamIDUser), base.IsServer);
		}

		// Token: 0x060001D6 RID: 470
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServerStats_GetUserStatInt32")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetUserStat(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref int pData);

		// Token: 0x060001D7 RID: 471 RVA: 0x00004A36 File Offset: 0x00002C36
		internal bool GetUserStat(SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref int pData)
		{
			return ISteamGameServerStats._GetUserStat(this.Self, steamIDUser, pchName, ref pData);
		}

		// Token: 0x060001D8 RID: 472
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServerStats_GetUserStatFloat")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetUserStat(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref float pData);

		// Token: 0x060001D9 RID: 473 RVA: 0x00004A46 File Offset: 0x00002C46
		internal bool GetUserStat(SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, ref float pData)
		{
			return ISteamGameServerStats._GetUserStat(this.Self, steamIDUser, pchName, ref pData);
		}

		// Token: 0x060001DA RID: 474
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServerStats_GetUserAchievement")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetUserAchievement(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, [MarshalAs(UnmanagedType.U1)] ref bool pbAchieved);

		// Token: 0x060001DB RID: 475 RVA: 0x00004A56 File Offset: 0x00002C56
		internal bool GetUserAchievement(SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, [MarshalAs(UnmanagedType.U1)] ref bool pbAchieved)
		{
			return ISteamGameServerStats._GetUserAchievement(this.Self, steamIDUser, pchName, ref pbAchieved);
		}

		// Token: 0x060001DC RID: 476
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServerStats_SetUserStatInt32")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetUserStat(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, int nData);

		// Token: 0x060001DD RID: 477 RVA: 0x00004A66 File Offset: 0x00002C66
		internal bool SetUserStat(SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, int nData)
		{
			return ISteamGameServerStats._SetUserStat(this.Self, steamIDUser, pchName, nData);
		}

		// Token: 0x060001DE RID: 478
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServerStats_SetUserStatFloat")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetUserStat(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, float fData);

		// Token: 0x060001DF RID: 479 RVA: 0x00004A76 File Offset: 0x00002C76
		internal bool SetUserStat(SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, float fData)
		{
			return ISteamGameServerStats._SetUserStat(this.Self, steamIDUser, pchName, fData);
		}

		// Token: 0x060001E0 RID: 480
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServerStats_UpdateUserAvgRateStat")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _UpdateUserAvgRateStat(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, float flCountThisSession, double dSessionLength);

		// Token: 0x060001E1 RID: 481 RVA: 0x00004A86 File Offset: 0x00002C86
		internal bool UpdateUserAvgRateStat(SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName, float flCountThisSession, double dSessionLength)
		{
			return ISteamGameServerStats._UpdateUserAvgRateStat(this.Self, steamIDUser, pchName, flCountThisSession, dSessionLength);
		}

		// Token: 0x060001E2 RID: 482
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServerStats_SetUserAchievement")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetUserAchievement(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName);

		// Token: 0x060001E3 RID: 483 RVA: 0x00004A98 File Offset: 0x00002C98
		internal bool SetUserAchievement(SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName)
		{
			return ISteamGameServerStats._SetUserAchievement(this.Self, steamIDUser, pchName);
		}

		// Token: 0x060001E4 RID: 484
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServerStats_ClearUserAchievement")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _ClearUserAchievement(IntPtr self, SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName);

		// Token: 0x060001E5 RID: 485 RVA: 0x00004AA7 File Offset: 0x00002CA7
		internal bool ClearUserAchievement(SteamId steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName)
		{
			return ISteamGameServerStats._ClearUserAchievement(this.Self, steamIDUser, pchName);
		}

		// Token: 0x060001E6 RID: 486
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameServerStats_StoreUserStats")]
		private static extern SteamAPICall_t _StoreUserStats(IntPtr self, SteamId steamIDUser);

		// Token: 0x060001E7 RID: 487 RVA: 0x00004AB6 File Offset: 0x00002CB6
		internal CallResult<GSStatsStored_t> StoreUserStats(SteamId steamIDUser)
		{
			return new CallResult<GSStatsStored_t>(ISteamGameServerStats._StoreUserStats(this.Self, steamIDUser), base.IsServer);
		}
	}
}
