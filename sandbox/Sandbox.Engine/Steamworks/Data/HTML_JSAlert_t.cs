using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000176 RID: 374
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_JSAlert_t : ICallbackData
	{
		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000973 RID: 2419 RVA: 0x0000E277 File Offset: 0x0000C477
		public int DataSize
		{
			get
			{
				return HTML_JSAlert_t._datasize;
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x0000E27E File Offset: 0x0000C47E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_JSAlert;
			}
		}

		// Token: 0x04000BFE RID: 3070
		internal uint UnBrowserHandle;

		// Token: 0x04000BFF RID: 3071
		internal string PchMessage;

		// Token: 0x04000C00 RID: 3072
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_JSAlert_t));
	}
}
