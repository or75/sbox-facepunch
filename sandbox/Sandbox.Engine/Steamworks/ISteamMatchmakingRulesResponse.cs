using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200002E RID: 46
	internal class ISteamMatchmakingRulesResponse : SteamInterface
	{
		// Token: 0x06000377 RID: 887 RVA: 0x00005882 File Offset: 0x00003A82
		internal ISteamMatchmakingRulesResponse(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x06000378 RID: 888
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesResponded")]
		private static extern void _RulesResponded(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchRule, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValue);

		// Token: 0x06000379 RID: 889 RVA: 0x00005891 File Offset: 0x00003A91
		internal void RulesResponded([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchRule, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValue)
		{
			ISteamMatchmakingRulesResponse._RulesResponded(this.Self, pchRule, pchValue);
		}

		// Token: 0x0600037A RID: 890
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesFailedToRespond")]
		private static extern void _RulesFailedToRespond(IntPtr self);

		// Token: 0x0600037B RID: 891 RVA: 0x000058A0 File Offset: 0x00003AA0
		internal void RulesFailedToRespond()
		{
			ISteamMatchmakingRulesResponse._RulesFailedToRespond(this.Self);
		}

		// Token: 0x0600037C RID: 892
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesRefreshComplete")]
		private static extern void _RulesRefreshComplete(IntPtr self);

		// Token: 0x0600037D RID: 893 RVA: 0x000058AD File Offset: 0x00003AAD
		internal void RulesRefreshComplete()
		{
			ISteamMatchmakingRulesResponse._RulesRefreshComplete(this.Self);
		}
	}
}
