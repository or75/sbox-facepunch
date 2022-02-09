using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200001E RID: 30
	internal static class ClientEngine
	{
		// Token: 0x0600035B RID: 859 RVA: 0x00027CAC File Offset: 0x00025EAC
		internal static void ServerCmd(InputCommandSource nSlot, string szCmdString)
		{
			method engine_ServerCmd = ClientEngine.__N.engine_ServerCmd;
			calli(System.Void(System.Int64,System.IntPtr), (long)nSlot, Interop.GetPointer(szCmdString), engine_ServerCmd);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00027CD0 File Offset: 0x00025ED0
		internal static void ClientCmd(InputCommandSource nSlot, string szCmdString)
		{
			method engine_ClientCmd = ClientEngine.__N.engine_ClientCmd;
			calli(System.Void(System.Int64,System.IntPtr), (long)nSlot, Interop.GetPointer(szCmdString), engine_ClientCmd);
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00027CF1 File Offset: 0x00025EF1
		internal static int GetMaxClients()
		{
			return calli(System.Int32(), ClientEngine.__N.engine_GetMaxClients);
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00027CFD File Offset: 0x00025EFD
		internal static bool IsInGame()
		{
			return calli(System.Int32(), ClientEngine.__N.engine_IsInGame) > 0;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00027D0C File Offset: 0x00025F0C
		internal static bool IsConnected()
		{
			return calli(System.Int32(), ClientEngine.__N.engine_IsConnected) > 0;
		}

		// Token: 0x06000360 RID: 864 RVA: 0x00027D1B File Offset: 0x00025F1B
		internal static bool FlashWindow()
		{
			return calli(System.Int32(), ClientEngine.__N.engine_FlashWindow) > 0;
		}

		// Token: 0x020001A3 RID: 419
		internal static class __N
		{
			// Token: 0x040009AE RID: 2478
			internal static method engine_ServerCmd;

			// Token: 0x040009AF RID: 2479
			internal static method engine_ClientCmd;

			// Token: 0x040009B0 RID: 2480
			internal static method engine_GetMaxClients;

			// Token: 0x040009B1 RID: 2481
			internal static method engine_IsInGame;

			// Token: 0x040009B2 RID: 2482
			internal static method engine_IsConnected;

			// Token: 0x040009B3 RID: 2483
			internal static method engine_FlashWindow;
		}
	}
}
