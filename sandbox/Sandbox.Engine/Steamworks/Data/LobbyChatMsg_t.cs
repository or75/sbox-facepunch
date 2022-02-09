using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000FB RID: 251
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LobbyChatMsg_t : ICallbackData
	{
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060007F6 RID: 2038 RVA: 0x0000CFB7 File Offset: 0x0000B1B7
		public int DataSize
		{
			get
			{
				return LobbyChatMsg_t._datasize;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060007F7 RID: 2039 RVA: 0x0000CFBE File Offset: 0x0000B1BE
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LobbyChatMsg;
			}
		}

		// Token: 0x04000A20 RID: 2592
		internal ulong SteamIDLobby;

		// Token: 0x04000A21 RID: 2593
		internal ulong SteamIDUser;

		// Token: 0x04000A22 RID: 2594
		internal byte ChatEntryType;

		// Token: 0x04000A23 RID: 2595
		internal uint ChatID;

		// Token: 0x04000A24 RID: 2596
		internal static int _datasize = Marshal.SizeOf(typeof(LobbyChatMsg_t));
	}
}
