using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020001A2 RID: 418
	[StructLayout(LayoutKind.Explicit, Pack = 8)]
	internal struct NetKeyValue
	{
		// Token: 0x06000A07 RID: 2567
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetInt32")]
		internal static extern void InternalSetInt32(ref NetKeyValue self, NetConfig eVal, int data);

		// Token: 0x06000A08 RID: 2568
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetInt64")]
		internal static extern void InternalSetInt64(ref NetKeyValue self, NetConfig eVal, long data);

		// Token: 0x06000A09 RID: 2569
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetFloat")]
		internal static extern void InternalSetFloat(ref NetKeyValue self, NetConfig eVal, float data);

		// Token: 0x06000A0A RID: 2570
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetPtr")]
		internal static extern void InternalSetPtr(ref NetKeyValue self, NetConfig eVal, IntPtr data);

		// Token: 0x06000A0B RID: 2571
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingConfigValue_t_SetString")]
		internal static extern void InternalSetString(ref NetKeyValue self, NetConfig eVal, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string data);

		// Token: 0x04000CF4 RID: 3316
		[FieldOffset(0)]
		internal NetConfig Value;

		// Token: 0x04000CF5 RID: 3317
		[FieldOffset(4)]
		internal NetConfigType DataType;

		// Token: 0x04000CF6 RID: 3318
		[FieldOffset(8)]
		internal long Int64Value;

		// Token: 0x04000CF7 RID: 3319
		[FieldOffset(8)]
		internal int Int32Value;

		// Token: 0x04000CF8 RID: 3320
		[FieldOffset(8)]
		internal float FloatValue;

		// Token: 0x04000CF9 RID: 3321
		[FieldOffset(8)]
		internal IntPtr PointerValue;
	}
}
