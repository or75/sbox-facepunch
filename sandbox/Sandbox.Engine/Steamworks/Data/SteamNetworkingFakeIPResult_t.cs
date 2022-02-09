using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200019B RID: 411
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamNetworkingFakeIPResult_t : ICallbackData
	{
		// Token: 0x17000226 RID: 550
		// (get) Token: 0x060009E8 RID: 2536 RVA: 0x0000E862 File Offset: 0x0000CA62
		public int DataSize
		{
			get
			{
				return SteamNetworkingFakeIPResult_t._datasize;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x060009E9 RID: 2537 RVA: 0x0000E869 File Offset: 0x0000CA69
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamNetworkingFakeIPResult;
			}
		}

		// Token: 0x04000C7C RID: 3196
		internal Result Result;

		// Token: 0x04000C7D RID: 3197
		internal NetIdentity Dentity;

		// Token: 0x04000C7E RID: 3198
		internal uint IP;

		// Token: 0x04000C7F RID: 3199
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.U2)]
		internal ushort[] Ports;

		// Token: 0x04000C80 RID: 3200
		internal static int _datasize = Marshal.SizeOf(typeof(SteamNetworkingFakeIPResult_t));
	}
}
