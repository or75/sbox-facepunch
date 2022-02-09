using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200016C RID: 364
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_CloseBrowser_t : ICallbackData
	{
		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000955 RID: 2389 RVA: 0x0000E10F File Offset: 0x0000C30F
		public int DataSize
		{
			get
			{
				return HTML_CloseBrowser_t._datasize;
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x0000E116 File Offset: 0x0000C316
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_CloseBrowser;
			}
		}

		// Token: 0x04000BCE RID: 3022
		internal uint UnBrowserHandle;

		// Token: 0x04000BCF RID: 3023
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_CloseBrowser_t));
	}
}
