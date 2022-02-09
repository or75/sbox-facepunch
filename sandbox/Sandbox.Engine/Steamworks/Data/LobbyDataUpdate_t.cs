using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000F9 RID: 249
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LobbyDataUpdate_t : ICallbackData
	{
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060007F0 RID: 2032 RVA: 0x0000CF6F File Offset: 0x0000B16F
		public int DataSize
		{
			get
			{
				return LobbyDataUpdate_t._datasize;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x0000CF76 File Offset: 0x0000B176
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LobbyDataUpdate;
			}
		}

		// Token: 0x04000A17 RID: 2583
		internal ulong SteamIDLobby;

		// Token: 0x04000A18 RID: 2584
		internal ulong SteamIDMember;

		// Token: 0x04000A19 RID: 2585
		internal byte Success;

		// Token: 0x04000A1A RID: 2586
		internal static int _datasize = Marshal.SizeOf(typeof(LobbyDataUpdate_t));
	}
}
