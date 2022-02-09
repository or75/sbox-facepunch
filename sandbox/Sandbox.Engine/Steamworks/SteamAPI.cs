using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x0200001B RID: 27
	internal static class SteamAPI
	{
		// Token: 0x06000026 RID: 38 RVA: 0x00002A08 File Offset: 0x00000C08
		internal static bool Init()
		{
			return SteamAPI.Native.SteamAPI_Init();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002A0F File Offset: 0x00000C0F
		internal static void Shutdown()
		{
			SteamAPI.Native.SteamAPI_Shutdown();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002A16 File Offset: 0x00000C16
		internal static HSteamPipe GetHSteamPipe()
		{
			return SteamAPI.Native.SteamAPI_GetHSteamPipe();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002A1D File Offset: 0x00000C1D
		internal static bool RestartAppIfNecessary(uint unOwnAppID)
		{
			return SteamAPI.Native.SteamAPI_RestartAppIfNecessary(unOwnAppID);
		}

		// Token: 0x02000316 RID: 790
		internal static class Native
		{
			// Token: 0x0600151E RID: 5406
			[DllImport("steam_api64", CallingConvention = 2)]
			[return: MarshalAs(UnmanagedType.I1)]
			internal static extern bool SteamAPI_Init();

			// Token: 0x0600151F RID: 5407
			[DllImport("steam_api64", CallingConvention = 2)]
			internal static extern void SteamAPI_Shutdown();

			// Token: 0x06001520 RID: 5408
			[DllImport("steam_api64", CallingConvention = 2)]
			internal static extern HSteamPipe SteamAPI_GetHSteamPipe();

			// Token: 0x06001521 RID: 5409
			[DllImport("steam_api64", CallingConvention = 2)]
			[return: MarshalAs(UnmanagedType.I1)]
			internal static extern bool SteamAPI_RestartAppIfNecessary(uint unOwnAppID);
		}
	}
}
