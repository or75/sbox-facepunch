using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000177 RID: 375
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_JSConfirm_t : ICallbackData
	{
		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x0000E29B File Offset: 0x0000C49B
		public int DataSize
		{
			get
			{
				return HTML_JSConfirm_t._datasize;
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000977 RID: 2423 RVA: 0x0000E2A2 File Offset: 0x0000C4A2
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_JSConfirm;
			}
		}

		// Token: 0x04000C01 RID: 3073
		internal uint UnBrowserHandle;

		// Token: 0x04000C02 RID: 3074
		internal string PchMessage;

		// Token: 0x04000C03 RID: 3075
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_JSConfirm_t));
	}
}
