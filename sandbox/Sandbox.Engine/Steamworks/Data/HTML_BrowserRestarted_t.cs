using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200017F RID: 383
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_BrowserRestarted_t : ICallbackData
	{
		// Token: 0x170001EE RID: 494
		// (get) Token: 0x0600098E RID: 2446 RVA: 0x0000E3BB File Offset: 0x0000C5BB
		public int DataSize
		{
			get
			{
				return HTML_BrowserRestarted_t._datasize;
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x0600098F RID: 2447 RVA: 0x0000E3C2 File Offset: 0x0000C5C2
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_BrowserRestarted;
			}
		}

		// Token: 0x04000C1E RID: 3102
		internal uint UnBrowserHandle;

		// Token: 0x04000C1F RID: 3103
		internal uint UnOldBrowserHandle;

		// Token: 0x04000C20 RID: 3104
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_BrowserRestarted_t));
	}
}
