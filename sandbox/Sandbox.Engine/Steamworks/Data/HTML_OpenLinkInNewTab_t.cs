using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200016F RID: 367
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_OpenLinkInNewTab_t : ICallbackData
	{
		// Token: 0x170001CE RID: 462
		// (get) Token: 0x0600095E RID: 2398 RVA: 0x0000E17B File Offset: 0x0000C37B
		public int DataSize
		{
			get
			{
				return HTML_OpenLinkInNewTab_t._datasize;
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x0600095F RID: 2399 RVA: 0x0000E182 File Offset: 0x0000C382
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_OpenLinkInNewTab;
			}
		}

		// Token: 0x04000BDB RID: 3035
		internal uint UnBrowserHandle;

		// Token: 0x04000BDC RID: 3036
		internal string PchURL;

		// Token: 0x04000BDD RID: 3037
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_OpenLinkInNewTab_t));
	}
}
