using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200018B RID: 395
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamNetworkingMessagesSessionRequest_t : ICallbackData
	{
		// Token: 0x17000206 RID: 518
		// (get) Token: 0x060009B4 RID: 2484 RVA: 0x0000E5A9 File Offset: 0x0000C7A9
		public int DataSize
		{
			get
			{
				return SteamNetworkingMessagesSessionRequest_t._datasize;
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x060009B5 RID: 2485 RVA: 0x0000E5B0 File Offset: 0x0000C7B0
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamNetworkingMessagesSessionRequest;
			}
		}

		// Token: 0x04000C3F RID: 3135
		internal NetIdentity DentityRemote;

		// Token: 0x04000C40 RID: 3136
		internal static int _datasize = Marshal.SizeOf(typeof(SteamNetworkingMessagesSessionRequest_t));
	}
}
