using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000DD RID: 221
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct GameLobbyJoinRequested_t : ICallbackData
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600079A RID: 1946 RVA: 0x0000CB41 File Offset: 0x0000AD41
		public int DataSize
		{
			get
			{
				return GameLobbyJoinRequested_t._datasize;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x0000CB48 File Offset: 0x0000AD48
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GameLobbyJoinRequested;
			}
		}

		// Token: 0x040009BD RID: 2493
		internal ulong SteamIDLobby;

		// Token: 0x040009BE RID: 2494
		internal ulong SteamIDFriend;

		// Token: 0x040009BF RID: 2495
		internal static int _datasize = Marshal.SizeOf(typeof(GameLobbyJoinRequested_t));
	}
}
