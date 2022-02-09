using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x020001A0 RID: 416
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamDatagramHostedAddress
	{
		// Token: 0x06000A01 RID: 2561
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamDatagramHostedAddress_Clear")]
		internal static extern void InternalClear(ref SteamDatagramHostedAddress self);

		// Token: 0x06000A02 RID: 2562
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamDatagramHostedAddress_GetPopID")]
		internal static extern SteamNetworkingPOPID InternalGetPopID(ref SteamDatagramHostedAddress self);

		// Token: 0x06000A03 RID: 2563
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamDatagramHostedAddress_SetDevAddress")]
		internal static extern void InternalSetDevAddress(ref SteamDatagramHostedAddress self, uint nIP, ushort nPort, SteamNetworkingPOPID popid);

		// Token: 0x06000A04 RID: 2564 RVA: 0x0000EC4D File Offset: 0x0000CE4D
		internal string DataUTF8()
		{
			return Encoding.UTF8.GetString(this.Data, 0, Array.IndexOf<byte>(this.Data, 0));
		}

		// Token: 0x04000CF0 RID: 3312
		internal int CbSize;

		// Token: 0x04000CF1 RID: 3313
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		internal byte[] Data;
	}
}
