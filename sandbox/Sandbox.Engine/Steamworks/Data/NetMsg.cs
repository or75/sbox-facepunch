using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020001A5 RID: 421
	internal struct NetMsg
	{
		// Token: 0x06000A3F RID: 2623
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingMessage_t_Release")]
		internal unsafe static extern void InternalRelease(NetMsg* self);
	}
}
