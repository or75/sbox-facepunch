using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000E3 RID: 227
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct GameConnectedChatJoin_t : ICallbackData
	{
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060007AD RID: 1965 RVA: 0x0000CC38 File Offset: 0x0000AE38
		public int DataSize
		{
			get
			{
				return GameConnectedChatJoin_t._datasize;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060007AE RID: 1966 RVA: 0x0000CC3F File Offset: 0x0000AE3F
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GameConnectedChatJoin;
			}
		}

		// Token: 0x040009D3 RID: 2515
		internal ulong SteamIDClanChat;

		// Token: 0x040009D4 RID: 2516
		internal ulong SteamIDUser;

		// Token: 0x040009D5 RID: 2517
		internal static int _datasize = Marshal.SizeOf(typeof(GameConnectedChatJoin_t));
	}
}
