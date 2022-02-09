using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x0200018C RID: 396
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamNetAuthenticationStatus_t : ICallbackData
	{
		// Token: 0x060009B7 RID: 2487 RVA: 0x0000E5CD File Offset: 0x0000C7CD
		internal string DebugMsgUTF8()
		{
			return Encoding.UTF8.GetString(this.DebugMsg, 0, Array.IndexOf<byte>(this.DebugMsg, 0));
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x060009B8 RID: 2488 RVA: 0x0000E5EC File Offset: 0x0000C7EC
		public int DataSize
		{
			get
			{
				return SteamNetAuthenticationStatus_t._datasize;
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x060009B9 RID: 2489 RVA: 0x0000E5F3 File Offset: 0x0000C7F3
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamNetAuthenticationStatus;
			}
		}

		// Token: 0x04000C41 RID: 3137
		internal SteamNetworkingAvailability Avail;

		// Token: 0x04000C42 RID: 3138
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal byte[] DebugMsg;

		// Token: 0x04000C43 RID: 3139
		internal static int _datasize = Marshal.SizeOf(typeof(SteamNetAuthenticationStatus_t));
	}
}
