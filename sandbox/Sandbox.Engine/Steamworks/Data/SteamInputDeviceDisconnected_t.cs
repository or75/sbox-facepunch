using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000152 RID: 338
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamInputDeviceDisconnected_t : ICallbackData
	{
		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x0000DD48 File Offset: 0x0000BF48
		public int DataSize
		{
			get
			{
				return SteamInputDeviceDisconnected_t._datasize;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000907 RID: 2311 RVA: 0x0000DD4F File Offset: 0x0000BF4F
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamInputDeviceDisconnected;
			}
		}

		// Token: 0x04000B5C RID: 2908
		internal ulong DisconnectedDeviceHandle;

		// Token: 0x04000B5D RID: 2909
		internal static int _datasize = Marshal.SizeOf(typeof(SteamInputDeviceDisconnected_t));
	}
}
