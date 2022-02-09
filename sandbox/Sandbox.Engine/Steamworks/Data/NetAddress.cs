using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020001A4 RID: 420
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 18)]
	internal struct NetAddress
	{
		// Token: 0x06000A27 RID: 2599
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_Clear")]
		internal static extern void InternalClear(ref NetAddress self);

		// Token: 0x06000A28 RID: 2600
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsIPv6AllZeros")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalIsIPv6AllZeros(ref NetAddress self);

		// Token: 0x06000A29 RID: 2601
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_SetIPv6")]
		internal static extern void InternalSetIPv6(ref NetAddress self, ref byte ipv6, ushort nPort);

		// Token: 0x06000A2A RID: 2602
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_SetIPv4")]
		internal static extern void InternalSetIPv4(ref NetAddress self, uint nIP, ushort nPort);

		// Token: 0x06000A2B RID: 2603
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsIPv4")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalIsIPv4(ref NetAddress self);

		// Token: 0x06000A2C RID: 2604
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_GetIPv4")]
		internal static extern uint InternalGetIPv4(ref NetAddress self);

		// Token: 0x06000A2D RID: 2605
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_SetIPv6LocalHost")]
		internal static extern void InternalSetIPv6LocalHost(ref NetAddress self, ushort nPort);

		// Token: 0x06000A2E RID: 2606
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsLocalHost")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalIsLocalHost(ref NetAddress self);

		// Token: 0x06000A2F RID: 2607
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_ToString")]
		internal static extern void InternalToString(ref NetAddress self, IntPtr buf, uint cbBuf, [MarshalAs(UnmanagedType.U1)] bool bWithPort);

		// Token: 0x06000A30 RID: 2608
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_ParseString")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalParseString(ref NetAddress self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pszStr);

		// Token: 0x06000A31 RID: 2609
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsEqualTo")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalIsEqualTo(ref NetAddress self, ref NetAddress x);

		// Token: 0x06000A32 RID: 2610
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_GetFakeIPType")]
		internal static extern SteamNetworkingFakeIPType InternalGetFakeIPType(ref NetAddress self);

		// Token: 0x06000A33 RID: 2611
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_SteamNetworkingIPAddr_IsFakeIP")]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool InternalIsFakeIP(ref NetAddress self);

		/// <summary>
		/// The Port. This is redundant documentation.
		/// </summary>
		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000A34 RID: 2612 RVA: 0x0000ECC8 File Offset: 0x0000CEC8
		internal ushort Port
		{
			get
			{
				return this.port;
			}
		}

		/// <summary>
		/// Any IP, specific port
		/// </summary>
		// Token: 0x06000A35 RID: 2613 RVA: 0x0000ECD0 File Offset: 0x0000CED0
		internal static NetAddress AnyIp(ushort port)
		{
			NetAddress addr = NetAddress.Cleared;
			addr.port = port;
			return addr;
		}

		/// <summary>
		/// Localhost IP, specific port
		/// </summary>
		// Token: 0x06000A36 RID: 2614 RVA: 0x0000ECEC File Offset: 0x0000CEEC
		internal static NetAddress LocalHost(ushort port)
		{
			NetAddress local = NetAddress.Cleared;
			NetAddress.InternalSetIPv6LocalHost(ref local, port);
			return local;
		}

		/// <summary>
		/// Specific IP, specific port
		/// </summary>
		// Token: 0x06000A37 RID: 2615 RVA: 0x0000ED08 File Offset: 0x0000CF08
		internal static NetAddress From(string addrStr, ushort port)
		{
			return NetAddress.From(IPAddress.Parse(addrStr), port);
		}

		/// <summary>
		/// Specific IP, specific port
		/// </summary>
		// Token: 0x06000A38 RID: 2616 RVA: 0x0000ED18 File Offset: 0x0000CF18
		internal static NetAddress From(IPAddress address, ushort port)
		{
			address.GetAddressBytes();
			if (address.AddressFamily == AddressFamily.InterNetwork)
			{
				NetAddress local = NetAddress.Cleared;
				NetAddress.InternalSetIPv4(ref local, address.IpToInt32(), port);
				return local;
			}
			throw new NotImplementedException("Oops - no IPV6 support yet?");
		}

		/// <summary>
		/// Set everything to zero
		/// </summary>
		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000A39 RID: 2617 RVA: 0x0000ED58 File Offset: 0x0000CF58
		internal static NetAddress Cleared
		{
			get
			{
				NetAddress self = default(NetAddress);
				NetAddress.InternalClear(ref self);
				return self;
			}
		}

		/// <summary>
		/// Return true if the IP is ::0.  (Doesn't check port.)
		/// </summary>
		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000A3A RID: 2618 RVA: 0x0000ED78 File Offset: 0x0000CF78
		internal bool IsIPv6AllZeros
		{
			get
			{
				NetAddress self = this;
				return NetAddress.InternalIsIPv6AllZeros(ref self);
			}
		}

		/// <summary>
		/// Return true if IP is mapped IPv4
		/// </summary>
		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000A3B RID: 2619 RVA: 0x0000ED94 File Offset: 0x0000CF94
		internal bool IsIPv4
		{
			get
			{
				NetAddress self = this;
				return NetAddress.InternalIsIPv4(ref self);
			}
		}

		/// <summary>
		/// Return true if this identity is localhost.  (Either IPv6 ::1, or IPv4 127.0.0.1)
		/// </summary>
		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000A3C RID: 2620 RVA: 0x0000EDB0 File Offset: 0x0000CFB0
		internal bool IsLocalHost
		{
			get
			{
				NetAddress self = this;
				return NetAddress.InternalIsLocalHost(ref self);
			}
		}

		/// <summary>
		/// Get the Address section
		/// </summary>
		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000A3D RID: 2621 RVA: 0x0000EDCC File Offset: 0x0000CFCC
		internal IPAddress Address
		{
			get
			{
				if (this.IsIPv4)
				{
					NetAddress self = this;
					return Utility.Int32ToIp(NetAddress.InternalGetIPv4(ref self));
				}
				if (this.IsIPv6AllZeros)
				{
					return IPAddress.IPv6Loopback;
				}
				throw new NotImplementedException("Oops - no IPV6 support yet?");
			}
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x0000EE10 File Offset: 0x0000D010
		public override string ToString()
		{
			Helpers.Memory ptr = Helpers.TakeMemory();
			NetAddress self = this;
			NetAddress.InternalToString(ref self, ptr, 32768U, true);
			return Helpers.MemoryToString(ptr);
		}

		// Token: 0x04000CFA RID: 3322
		[FieldOffset(0)]
		internal NetAddress.IPV4 ip;

		// Token: 0x04000CFB RID: 3323
		[FieldOffset(16)]
		internal ushort port;

		// Token: 0x02000370 RID: 880
		internal struct IPV4
		{
			// Token: 0x04001758 RID: 5976
			internal ulong m_8zeros;

			// Token: 0x04001759 RID: 5977
			internal ushort m_0000;

			// Token: 0x0400175A RID: 5978
			internal ushort m_ffff;

			// Token: 0x0400175B RID: 5979
			internal byte ip0;

			// Token: 0x0400175C RID: 5980
			internal byte ip1;

			// Token: 0x0400175D RID: 5981
			internal byte ip2;

			// Token: 0x0400175E RID: 5982
			internal byte ip3;
		}
	}
}
