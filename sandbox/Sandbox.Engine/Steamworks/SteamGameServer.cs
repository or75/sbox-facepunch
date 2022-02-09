using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x0200001C RID: 28
	internal static class SteamGameServer
	{
		// Token: 0x0600002A RID: 42 RVA: 0x00002A25 File Offset: 0x00000C25
		internal static void RunCallbacks()
		{
			SteamGameServer.Native.SteamGameServer_RunCallbacks();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002A2C File Offset: 0x00000C2C
		internal static void Shutdown()
		{
			SteamGameServer.Native.SteamGameServer_Shutdown();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002A33 File Offset: 0x00000C33
		internal static HSteamPipe GetHSteamPipe()
		{
			return SteamGameServer.Native.SteamGameServer_GetHSteamPipe();
		}

		// Token: 0x02000317 RID: 791
		internal static class Native
		{
			// Token: 0x06001522 RID: 5410
			[DllImport("steam_api64", CallingConvention = 2)]
			internal static extern void SteamGameServer_RunCallbacks();

			// Token: 0x06001523 RID: 5411
			[DllImport("steam_api64", CallingConvention = 2)]
			internal static extern void SteamGameServer_Shutdown();

			// Token: 0x06001524 RID: 5412
			[DllImport("steam_api64", CallingConvention = 2)]
			internal static extern HSteamPipe SteamGameServer_GetHSteamPipe();
		}
	}
}
