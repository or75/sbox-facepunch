using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000FC RID: 252
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LobbyGameCreated_t : ICallbackData
	{
		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060007F9 RID: 2041 RVA: 0x0000CFDB File Offset: 0x0000B1DB
		public int DataSize
		{
			get
			{
				return LobbyGameCreated_t._datasize;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060007FA RID: 2042 RVA: 0x0000CFE2 File Offset: 0x0000B1E2
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LobbyGameCreated;
			}
		}

		// Token: 0x04000A25 RID: 2597
		internal ulong SteamIDLobby;

		// Token: 0x04000A26 RID: 2598
		internal ulong SteamIDGameServer;

		// Token: 0x04000A27 RID: 2599
		internal uint IP;

		// Token: 0x04000A28 RID: 2600
		internal ushort Port;

		// Token: 0x04000A29 RID: 2601
		internal static int _datasize = Marshal.SizeOf(typeof(LobbyGameCreated_t));
	}
}
