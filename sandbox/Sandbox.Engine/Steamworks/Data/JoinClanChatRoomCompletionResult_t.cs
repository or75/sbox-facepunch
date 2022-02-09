using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000E6 RID: 230
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct JoinClanChatRoomCompletionResult_t : ICallbackData
	{
		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060007B6 RID: 1974 RVA: 0x0000CCA4 File Offset: 0x0000AEA4
		public int DataSize
		{
			get
			{
				return JoinClanChatRoomCompletionResult_t._datasize;
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060007B7 RID: 1975 RVA: 0x0000CCAB File Offset: 0x0000AEAB
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.JoinClanChatRoomCompletionResult;
			}
		}

		// Token: 0x040009DD RID: 2525
		internal ulong SteamIDClanChat;

		// Token: 0x040009DE RID: 2526
		internal RoomEnter ChatRoomEnterResponse;

		// Token: 0x040009DF RID: 2527
		internal static int _datasize = Marshal.SizeOf(typeof(JoinClanChatRoomCompletionResult_t));
	}
}
