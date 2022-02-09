using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000E7 RID: 231
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GameConnectedFriendChatMsg_t : ICallbackData
	{
		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060007B9 RID: 1977 RVA: 0x0000CCC8 File Offset: 0x0000AEC8
		public int DataSize
		{
			get
			{
				return GameConnectedFriendChatMsg_t._datasize;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060007BA RID: 1978 RVA: 0x0000CCCF File Offset: 0x0000AECF
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GameConnectedFriendChatMsg;
			}
		}

		// Token: 0x040009E0 RID: 2528
		internal ulong SteamIDUser;

		// Token: 0x040009E1 RID: 2529
		internal int MessageID;

		// Token: 0x040009E2 RID: 2530
		internal static int _datasize = Marshal.SizeOf(typeof(GameConnectedFriendChatMsg_t));
	}
}
