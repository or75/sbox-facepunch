using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000CF RID: 207
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct ClientGameServerDeny_t : ICallbackData
	{
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600076C RID: 1900 RVA: 0x0000C8D6 File Offset: 0x0000AAD6
		public int DataSize
		{
			get
			{
				return ClientGameServerDeny_t._datasize;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600076D RID: 1901 RVA: 0x0000C8DD File Offset: 0x0000AADD
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.ClientGameServerDeny;
			}
		}

		// Token: 0x0400098C RID: 2444
		internal uint AppID;

		// Token: 0x0400098D RID: 2445
		internal uint GameServerIP;

		// Token: 0x0400098E RID: 2446
		internal ushort GameServerPort;

		// Token: 0x0400098F RID: 2447
		internal ushort Secure;

		// Token: 0x04000990 RID: 2448
		internal uint Reason;

		// Token: 0x04000991 RID: 2449
		internal static int _datasize = Marshal.SizeOf(typeof(ClientGameServerDeny_t));
	}
}
