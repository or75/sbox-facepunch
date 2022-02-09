using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000E4 RID: 228
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct GameConnectedChatLeave_t : ICallbackData
	{
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060007B0 RID: 1968 RVA: 0x0000CC5C File Offset: 0x0000AE5C
		public int DataSize
		{
			get
			{
				return GameConnectedChatLeave_t._datasize;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060007B1 RID: 1969 RVA: 0x0000CC63 File Offset: 0x0000AE63
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GameConnectedChatLeave;
			}
		}

		// Token: 0x040009D6 RID: 2518
		internal ulong SteamIDClanChat;

		// Token: 0x040009D7 RID: 2519
		internal ulong SteamIDUser;

		// Token: 0x040009D8 RID: 2520
		[MarshalAs(UnmanagedType.I1)]
		internal bool Kicked;

		// Token: 0x040009D9 RID: 2521
		[MarshalAs(UnmanagedType.I1)]
		internal bool Dropped;

		// Token: 0x040009DA RID: 2522
		internal static int _datasize = Marshal.SizeOf(typeof(GameConnectedChatLeave_t));
	}
}
