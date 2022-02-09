using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000FD RID: 253
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LobbyMatchList_t : ICallbackData
	{
		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060007FC RID: 2044 RVA: 0x0000CFFF File Offset: 0x0000B1FF
		public int DataSize
		{
			get
			{
				return LobbyMatchList_t._datasize;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060007FD RID: 2045 RVA: 0x0000D006 File Offset: 0x0000B206
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LobbyMatchList;
			}
		}

		// Token: 0x04000A2A RID: 2602
		internal uint LobbiesMatching;

		// Token: 0x04000A2B RID: 2603
		internal static int _datasize = Marshal.SizeOf(typeof(LobbyMatchList_t));
	}
}
