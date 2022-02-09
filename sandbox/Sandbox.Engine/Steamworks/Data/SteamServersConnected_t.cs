using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000CC RID: 204
	internal struct SteamServersConnected_t : ICallbackData
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x0000C873 File Offset: 0x0000AA73
		public int DataSize
		{
			get
			{
				return SteamServersConnected_t._datasize;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000764 RID: 1892 RVA: 0x0000C87A File Offset: 0x0000AA7A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamServersConnected;
			}
		}

		// Token: 0x04000986 RID: 2438
		internal static int _datasize = Marshal.SizeOf(typeof(SteamServersConnected_t));
	}
}
