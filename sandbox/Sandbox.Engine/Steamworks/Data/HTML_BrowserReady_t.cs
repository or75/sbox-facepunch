using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000169 RID: 361
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_BrowserReady_t : ICallbackData
	{
		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x0000E0A3 File Offset: 0x0000C2A3
		public int DataSize
		{
			get
			{
				return HTML_BrowserReady_t._datasize;
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x0600094D RID: 2381 RVA: 0x0000E0AA File Offset: 0x0000C2AA
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_BrowserReady;
			}
		}

		// Token: 0x04000BB9 RID: 3001
		internal uint UnBrowserHandle;

		// Token: 0x04000BBA RID: 3002
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_BrowserReady_t));
	}
}
