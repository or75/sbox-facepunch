using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000FE RID: 254
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LobbyKicked_t : ICallbackData
	{
		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060007FF RID: 2047 RVA: 0x0000D023 File Offset: 0x0000B223
		public int DataSize
		{
			get
			{
				return LobbyKicked_t._datasize;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x0000D02A File Offset: 0x0000B22A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LobbyKicked;
			}
		}

		// Token: 0x04000A2C RID: 2604
		internal ulong SteamIDLobby;

		// Token: 0x04000A2D RID: 2605
		internal ulong SteamIDAdmin;

		// Token: 0x04000A2E RID: 2606
		internal byte KickedDueToDisconnect;

		// Token: 0x04000A2F RID: 2607
		internal static int _datasize = Marshal.SizeOf(typeof(LobbyKicked_t));
	}
}
