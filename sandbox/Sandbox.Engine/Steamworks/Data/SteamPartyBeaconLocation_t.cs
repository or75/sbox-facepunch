using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020001A7 RID: 423
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamPartyBeaconLocation_t
	{
		// Token: 0x04000D01 RID: 3329
		internal SteamPartyBeaconLocationType Type;

		// Token: 0x04000D02 RID: 3330
		internal ulong LocationID;
	}
}
