using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200017D RID: 381
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_UpdateToolTip_t : ICallbackData
	{
		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x0000E373 File Offset: 0x0000C573
		public int DataSize
		{
			get
			{
				return HTML_UpdateToolTip_t._datasize;
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000989 RID: 2441 RVA: 0x0000E37A File Offset: 0x0000C57A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_UpdateToolTip;
			}
		}

		// Token: 0x04000C19 RID: 3097
		internal uint UnBrowserHandle;

		// Token: 0x04000C1A RID: 3098
		internal string PchMsg;

		// Token: 0x04000C1B RID: 3099
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_UpdateToolTip_t));
	}
}
