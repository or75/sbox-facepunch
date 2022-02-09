using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000F7 RID: 247
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LobbyInvite_t : ICallbackData
	{
		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060007EA RID: 2026 RVA: 0x0000CF27 File Offset: 0x0000B127
		public int DataSize
		{
			get
			{
				return LobbyInvite_t._datasize;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060007EB RID: 2027 RVA: 0x0000CF2E File Offset: 0x0000B12E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LobbyInvite;
			}
		}

		// Token: 0x04000A0E RID: 2574
		internal ulong SteamIDUser;

		// Token: 0x04000A0F RID: 2575
		internal ulong SteamIDLobby;

		// Token: 0x04000A10 RID: 2576
		internal ulong GameID;

		// Token: 0x04000A11 RID: 2577
		internal static int _datasize = Marshal.SizeOf(typeof(LobbyInvite_t));
	}
}
