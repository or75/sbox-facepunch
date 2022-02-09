using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200019F RID: 415
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct servernetadr_t
	{
		// Token: 0x060009F5 RID: 2549
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_servernetadr_t_Construct")]
		internal static extern void InternalConstruct(ref servernetadr_t self);

		// Token: 0x060009F6 RID: 2550
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_servernetadr_t_Init")]
		internal static extern void InternalInit(ref servernetadr_t self, uint ip, ushort usQueryPort, ushort usConnectionPort);

		// Token: 0x060009F7 RID: 2551
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_servernetadr_t_GetQueryPort")]
		internal static extern ushort InternalGetQueryPort(ref servernetadr_t self);

		// Token: 0x060009F8 RID: 2552
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_servernetadr_t_SetQueryPort")]
		internal static extern void InternalSetQueryPort(ref servernetadr_t self, ushort usPort);

		// Token: 0x060009F9 RID: 2553
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_servernetadr_t_GetConnectionPort")]
		internal static extern ushort InternalGetConnectionPort(ref servernetadr_t self);

		// Token: 0x060009FA RID: 2554
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_servernetadr_t_SetConnectionPort")]
		internal static extern void InternalSetConnectionPort(ref servernetadr_t self, ushort usPort);

		// Token: 0x060009FB RID: 2555
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_servernetadr_t_GetIP")]
		internal static extern uint InternalGetIP(ref servernetadr_t self);

		// Token: 0x060009FC RID: 2556
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_servernetadr_t_SetIP")]
		internal static extern void InternalSetIP(ref servernetadr_t self, uint unIP);

		// Token: 0x060009FD RID: 2557
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_servernetadr_t_GetConnectionAddressString")]
		internal static extern Utf8StringPointer InternalGetConnectionAddressString(ref servernetadr_t self);

		// Token: 0x060009FE RID: 2558
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_servernetadr_t_GetQueryAddressString")]
		internal static extern Utf8StringPointer InternalGetQueryAddressString(ref servernetadr_t self);

		// Token: 0x060009FF RID: 2559
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_servernetadr_t_IsLessThan")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalIsLessThan(ref servernetadr_t self, ref servernetadr_t netadr);

		// Token: 0x06000A00 RID: 2560
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_servernetadr_t_Assign")]
		internal static extern void InternalAssign(ref servernetadr_t self, ref servernetadr_t that);

		// Token: 0x04000CED RID: 3309
		internal ushort ConnectionPort;

		// Token: 0x04000CEE RID: 3310
		internal ushort QueryPort;

		// Token: 0x04000CEF RID: 3311
		internal uint IP;
	}
}
