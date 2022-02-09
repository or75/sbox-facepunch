using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200017C RID: 380
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_ShowToolTip_t : ICallbackData
	{
		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000985 RID: 2437 RVA: 0x0000E34F File Offset: 0x0000C54F
		public int DataSize
		{
			get
			{
				return HTML_ShowToolTip_t._datasize;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x0000E356 File Offset: 0x0000C556
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_ShowToolTip;
			}
		}

		// Token: 0x04000C16 RID: 3094
		internal uint UnBrowserHandle;

		// Token: 0x04000C17 RID: 3095
		internal string PchMsg;

		// Token: 0x04000C18 RID: 3096
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_ShowToolTip_t));
	}
}
