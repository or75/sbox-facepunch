using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200017B RID: 379
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_StatusText_t : ICallbackData
	{
		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x0000E32B File Offset: 0x0000C52B
		public int DataSize
		{
			get
			{
				return HTML_StatusText_t._datasize;
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000983 RID: 2435 RVA: 0x0000E332 File Offset: 0x0000C532
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_StatusText;
			}
		}

		// Token: 0x04000C13 RID: 3091
		internal uint UnBrowserHandle;

		// Token: 0x04000C14 RID: 3092
		internal string PchMsg;

		// Token: 0x04000C15 RID: 3093
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_StatusText_t));
	}
}
