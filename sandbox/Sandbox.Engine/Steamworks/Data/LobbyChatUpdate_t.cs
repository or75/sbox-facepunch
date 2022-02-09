using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000FA RID: 250
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LobbyChatUpdate_t : ICallbackData
	{
		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060007F3 RID: 2035 RVA: 0x0000CF93 File Offset: 0x0000B193
		public int DataSize
		{
			get
			{
				return LobbyChatUpdate_t._datasize;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060007F4 RID: 2036 RVA: 0x0000CF9A File Offset: 0x0000B19A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LobbyChatUpdate;
			}
		}

		// Token: 0x04000A1B RID: 2587
		internal ulong SteamIDLobby;

		// Token: 0x04000A1C RID: 2588
		internal ulong SteamIDUserChanged;

		// Token: 0x04000A1D RID: 2589
		internal ulong SteamIDMakingChange;

		// Token: 0x04000A1E RID: 2590
		internal uint GfChatMemberStateChange;

		// Token: 0x04000A1F RID: 2591
		internal static int _datasize = Marshal.SizeOf(typeof(LobbyChatUpdate_t));
	}
}
