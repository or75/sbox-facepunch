using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000F8 RID: 248
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LobbyEnter_t : ICallbackData
	{
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060007ED RID: 2029 RVA: 0x0000CF4B File Offset: 0x0000B14B
		public int DataSize
		{
			get
			{
				return LobbyEnter_t._datasize;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060007EE RID: 2030 RVA: 0x0000CF52 File Offset: 0x0000B152
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LobbyEnter;
			}
		}

		// Token: 0x04000A12 RID: 2578
		internal ulong SteamIDLobby;

		// Token: 0x04000A13 RID: 2579
		internal uint GfChatPermissions;

		// Token: 0x04000A14 RID: 2580
		[MarshalAs(UnmanagedType.I1)]
		internal bool Locked;

		// Token: 0x04000A15 RID: 2581
		internal uint EChatRoomEnterResponse;

		// Token: 0x04000A16 RID: 2582
		internal static int _datasize = Marshal.SizeOf(typeof(LobbyEnter_t));
	}
}
