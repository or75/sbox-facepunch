using System;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x0200002C RID: 44
	internal class ISteamMatchmakingPingResponse : SteamInterface
	{
		// Token: 0x0600036B RID: 875 RVA: 0x0000581F File Offset: 0x00003A1F
		internal ISteamMatchmakingPingResponse(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x0600036C RID: 876
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingPingResponse_ServerResponded")]
		private static extern void _ServerResponded(IntPtr self, ref gameserveritem_t server);

		// Token: 0x0600036D RID: 877 RVA: 0x0000582E File Offset: 0x00003A2E
		internal void ServerResponded(ref gameserveritem_t server)
		{
			ISteamMatchmakingPingResponse._ServerResponded(this.Self, ref server);
		}

		// Token: 0x0600036E RID: 878
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingPingResponse_ServerFailedToRespond")]
		private static extern void _ServerFailedToRespond(IntPtr self);

		// Token: 0x0600036F RID: 879 RVA: 0x0000583C File Offset: 0x00003A3C
		internal void ServerFailedToRespond()
		{
			ISteamMatchmakingPingResponse._ServerFailedToRespond(this.Self);
		}
	}
}
