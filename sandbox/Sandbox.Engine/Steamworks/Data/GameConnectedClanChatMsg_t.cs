using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000E2 RID: 226
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct GameConnectedClanChatMsg_t : ICallbackData
	{
		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060007AA RID: 1962 RVA: 0x0000CC14 File Offset: 0x0000AE14
		public int DataSize
		{
			get
			{
				return GameConnectedClanChatMsg_t._datasize;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060007AB RID: 1963 RVA: 0x0000CC1B File Offset: 0x0000AE1B
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GameConnectedClanChatMsg;
			}
		}

		// Token: 0x040009CF RID: 2511
		internal ulong SteamIDClanChat;

		// Token: 0x040009D0 RID: 2512
		internal ulong SteamIDUser;

		// Token: 0x040009D1 RID: 2513
		internal int MessageID;

		// Token: 0x040009D2 RID: 2514
		internal static int _datasize = Marshal.SizeOf(typeof(GameConnectedClanChatMsg_t));
	}
}
