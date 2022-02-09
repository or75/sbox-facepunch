using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200001D RID: 29
	internal static class SteamInternal
	{
		// Token: 0x0600002D RID: 45 RVA: 0x00002A3A File Offset: 0x00000C3A
		internal static bool GameServer_Init(uint unIP, ushort usPort, ushort usGamePort, ushort usQueryPort, int eServerMode, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersionString)
		{
			return SteamInternal.Native.SteamInternal_GameServer_Init(unIP, usPort, usGamePort, usQueryPort, eServerMode, pchVersionString);
		}

		// Token: 0x02000318 RID: 792
		internal static class Native
		{
			// Token: 0x06001525 RID: 5413
			[DllImport("steam_api64", CallingConvention = 2)]
			[return: MarshalAs(UnmanagedType.I1)]
			internal static extern bool SteamInternal_GameServer_Init(uint unIP, ushort usPort, ushort usGamePort, ushort usQueryPort, int eServerMode, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchVersionString);
		}
	}
}
