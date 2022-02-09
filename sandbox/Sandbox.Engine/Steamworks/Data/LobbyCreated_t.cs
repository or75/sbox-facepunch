using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000FF RID: 255
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LobbyCreated_t : ICallbackData
	{
		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000802 RID: 2050 RVA: 0x0000D047 File Offset: 0x0000B247
		public int DataSize
		{
			get
			{
				return LobbyCreated_t._datasize;
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x0000D04E File Offset: 0x0000B24E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LobbyCreated;
			}
		}

		// Token: 0x04000A30 RID: 2608
		internal Result Result;

		// Token: 0x04000A31 RID: 2609
		internal ulong SteamIDLobby;

		// Token: 0x04000A32 RID: 2610
		internal static int _datasize = Marshal.SizeOf(typeof(LobbyCreated_t));
	}
}
