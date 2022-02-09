using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200017E RID: 382
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_HideToolTip_t : ICallbackData
	{
		// Token: 0x170001EC RID: 492
		// (get) Token: 0x0600098B RID: 2443 RVA: 0x0000E397 File Offset: 0x0000C597
		public int DataSize
		{
			get
			{
				return HTML_HideToolTip_t._datasize;
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x0600098C RID: 2444 RVA: 0x0000E39E File Offset: 0x0000C59E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_HideToolTip;
			}
		}

		// Token: 0x04000C1C RID: 3100
		internal uint UnBrowserHandle;

		// Token: 0x04000C1D RID: 3101
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_HideToolTip_t));
	}
}
