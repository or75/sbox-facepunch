using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000151 RID: 337
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamInputDeviceConnected_t : ICallbackData
	{
		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000903 RID: 2307 RVA: 0x0000DD24 File Offset: 0x0000BF24
		public int DataSize
		{
			get
			{
				return SteamInputDeviceConnected_t._datasize;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x0000DD2B File Offset: 0x0000BF2B
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamInputDeviceConnected;
			}
		}

		// Token: 0x04000B5A RID: 2906
		internal ulong ConnectedDeviceHandle;

		// Token: 0x04000B5B RID: 2907
		internal static int _datasize = Marshal.SizeOf(typeof(SteamInputDeviceConnected_t));
	}
}
