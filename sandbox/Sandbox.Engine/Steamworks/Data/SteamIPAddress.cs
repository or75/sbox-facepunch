using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020001A1 RID: 417
	[StructLayout(LayoutKind.Explicit, Pack = 8)]
	internal struct SteamIPAddress
	{
		// Token: 0x06000A05 RID: 2565
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamIPAddress_t_IsSet")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalIsSet(ref SteamIPAddress self);

		// Token: 0x06000A06 RID: 2566 RVA: 0x0000EC6C File Offset: 0x0000CE6C
		public static implicit operator IPAddress(SteamIPAddress value)
		{
			if (value.Type == SteamIPType.Type4)
			{
				return Utility.Int32ToIp(value.Ip4Address);
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(97, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Oops - can't convert SteamIPAddress to System.Net.IPAddress because no-one coded support for ");
			defaultInterpolatedStringHandler.AppendFormatted<SteamIPType>(value.Type);
			defaultInterpolatedStringHandler.AppendLiteral(" yet");
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x04000CF2 RID: 3314
		[FieldOffset(0)]
		internal uint Ip4Address;

		// Token: 0x04000CF3 RID: 3315
		[FieldOffset(16)]
		internal SteamIPType Type;
	}
}
