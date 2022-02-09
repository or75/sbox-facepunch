using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020001A3 RID: 419
	internal struct NetIdentity
	{
		// Token: 0x06000A0C RID: 2572
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_Clear")]
		internal static extern void InternalClear(ref NetIdentity self);

		// Token: 0x06000A0D RID: 2573
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsInvalid")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalIsInvalid(ref NetIdentity self);

		// Token: 0x06000A0E RID: 2574
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetSteamID")]
		internal static extern void InternalSetSteamID(ref NetIdentity self, SteamId steamID);

		// Token: 0x06000A0F RID: 2575
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetSteamID")]
		internal static extern SteamId InternalGetSteamID(ref NetIdentity self);

		// Token: 0x06000A10 RID: 2576
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetSteamID64")]
		internal static extern void InternalSetSteamID64(ref NetIdentity self, ulong steamID);

		// Token: 0x06000A11 RID: 2577
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetSteamID64")]
		internal static extern ulong InternalGetSteamID64(ref NetIdentity self);

		// Token: 0x06000A12 RID: 2578
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetXboxPairwiseID")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalSetXboxPairwiseID(ref NetIdentity self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszString);

		// Token: 0x06000A13 RID: 2579
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetXboxPairwiseID")]
		internal static extern Utf8StringPointer InternalGetXboxPairwiseID(ref NetIdentity self);

		// Token: 0x06000A14 RID: 2580
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetPSNID")]
		internal static extern void InternalSetPSNID(ref NetIdentity self, ulong id);

		// Token: 0x06000A15 RID: 2581
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetPSNID")]
		internal static extern ulong InternalGetPSNID(ref NetIdentity self);

		// Token: 0x06000A16 RID: 2582
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetStadiaID")]
		internal static extern void InternalSetStadiaID(ref NetIdentity self, ulong id);

		// Token: 0x06000A17 RID: 2583
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetStadiaID")]
		internal static extern ulong InternalGetStadiaID(ref NetIdentity self);

		// Token: 0x06000A18 RID: 2584
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetIPAddr")]
		internal static extern void InternalSetIPAddr(ref NetIdentity self, ref NetAddress addr);

		// Token: 0x06000A19 RID: 2585
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetIPAddr")]
		internal static extern IntPtr InternalGetIPAddr(ref NetIdentity self);

		// Token: 0x06000A1A RID: 2586
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetIPv4Addr")]
		internal static extern void InternalSetIPv4Addr(ref NetIdentity self, uint nIPv4, ushort nPort);

		// Token: 0x06000A1B RID: 2587
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetIPv4")]
		internal static extern uint InternalGetIPv4(ref NetIdentity self);

		// Token: 0x06000A1C RID: 2588
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetFakeIPType")]
		internal static extern SteamNetworkingFakeIPType InternalGetFakeIPType(ref NetIdentity self);

		// Token: 0x06000A1D RID: 2589
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsFakeIP")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalIsFakeIP(ref NetIdentity self);

		// Token: 0x06000A1E RID: 2590
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetLocalHost")]
		internal static extern void InternalSetLocalHost(ref NetIdentity self);

		// Token: 0x06000A1F RID: 2591
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsLocalHost")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalIsLocalHost(ref NetIdentity self);

		// Token: 0x06000A20 RID: 2592
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetGenericString")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalSetGenericString(ref NetIdentity self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszString);

		// Token: 0x06000A21 RID: 2593
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetGenericString")]
		internal static extern Utf8StringPointer InternalGetGenericString(ref NetIdentity self);

		// Token: 0x06000A22 RID: 2594
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_SetGenericBytes")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalSetGenericBytes(ref NetIdentity self, IntPtr data, uint cbLen);

		// Token: 0x06000A23 RID: 2595
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_GetGenericBytes")]
		internal static extern byte InternalGetGenericBytes(ref NetIdentity self, ref int cbLen);

		// Token: 0x06000A24 RID: 2596
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_IsEqualTo")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalIsEqualTo(ref NetIdentity self, ref NetIdentity x);

		// Token: 0x06000A25 RID: 2597
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_ToString")]
		internal static extern void InternalToString(ref NetIdentity self, IntPtr buf, uint cbBuf);

		// Token: 0x06000A26 RID: 2598
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIdentity_ParseString")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalParseString(ref NetIdentity self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszStr);
	}
}
