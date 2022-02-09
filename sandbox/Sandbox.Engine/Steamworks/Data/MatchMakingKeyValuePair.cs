using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200019E RID: 414
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct MatchMakingKeyValuePair
	{
		// Token: 0x060009F4 RID: 2548
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_MatchMakingKeyValuePair_t_Construct")]
		internal static extern void InternalConstruct(ref MatchMakingKeyValuePair self);

		// Token: 0x04000CEB RID: 3307
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		internal string Key;

		// Token: 0x04000CEC RID: 3308
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		internal string Value;
	}
}
