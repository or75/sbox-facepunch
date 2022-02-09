using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x0200018D RID: 397
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamRelayNetworkStatus_t : ICallbackData
	{
		// Token: 0x060009BB RID: 2491 RVA: 0x0000E610 File Offset: 0x0000C810
		internal string DebugMsgUTF8()
		{
			return Encoding.UTF8.GetString(this.DebugMsg, 0, Array.IndexOf<byte>(this.DebugMsg, 0));
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x060009BC RID: 2492 RVA: 0x0000E62F File Offset: 0x0000C82F
		public int DataSize
		{
			get
			{
				return SteamRelayNetworkStatus_t._datasize;
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x060009BD RID: 2493 RVA: 0x0000E636 File Offset: 0x0000C836
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamRelayNetworkStatus;
			}
		}

		// Token: 0x04000C44 RID: 3140
		internal SteamNetworkingAvailability Avail;

		// Token: 0x04000C45 RID: 3141
		internal int PingMeasurementInProgress;

		// Token: 0x04000C46 RID: 3142
		internal SteamNetworkingAvailability AvailNetworkConfig;

		// Token: 0x04000C47 RID: 3143
		internal SteamNetworkingAvailability AvailAnyRelay;

		// Token: 0x04000C48 RID: 3144
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal byte[] DebugMsg;

		// Token: 0x04000C49 RID: 3145
		internal static int _datasize = Marshal.SizeOf(typeof(SteamRelayNetworkStatus_t));
	}
}
