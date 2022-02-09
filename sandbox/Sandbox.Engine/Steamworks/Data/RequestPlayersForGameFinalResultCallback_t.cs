using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000106 RID: 262
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RequestPlayersForGameFinalResultCallback_t : ICallbackData
	{
		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000817 RID: 2071 RVA: 0x0000D143 File Offset: 0x0000B343
		public int DataSize
		{
			get
			{
				return RequestPlayersForGameFinalResultCallback_t._datasize;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000818 RID: 2072 RVA: 0x0000D14A File Offset: 0x0000B34A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RequestPlayersForGameFinalResultCallback;
			}
		}

		// Token: 0x04000A54 RID: 2644
		internal Result Result;

		// Token: 0x04000A55 RID: 2645
		internal ulong LSearchID;

		// Token: 0x04000A56 RID: 2646
		internal ulong LUniqueGameID;

		// Token: 0x04000A57 RID: 2647
		internal static int _datasize = Marshal.SizeOf(typeof(RequestPlayersForGameFinalResultCallback_t));
	}
}
