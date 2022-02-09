using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000EC RID: 236
	internal struct UnreadChatMessagesChanged_t : ICallbackData
	{
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060007C8 RID: 1992 RVA: 0x0000CD7C File Offset: 0x0000AF7C
		public int DataSize
		{
			get
			{
				return UnreadChatMessagesChanged_t._datasize;
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060007C9 RID: 1993 RVA: 0x0000CD83 File Offset: 0x0000AF83
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.UnreadChatMessagesChanged;
			}
		}

		// Token: 0x040009F4 RID: 2548
		internal static int _datasize = Marshal.SizeOf(typeof(UnreadChatMessagesChanged_t));
	}
}
