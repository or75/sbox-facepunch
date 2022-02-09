using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200017A RID: 378
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_SetCursor_t : ICallbackData
	{
		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x0600097F RID: 2431 RVA: 0x0000E307 File Offset: 0x0000C507
		public int DataSize
		{
			get
			{
				return HTML_SetCursor_t._datasize;
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x0000E30E File Offset: 0x0000C50E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_SetCursor;
			}
		}

		// Token: 0x04000C10 RID: 3088
		internal uint UnBrowserHandle;

		// Token: 0x04000C11 RID: 3089
		internal uint EMouseCursor;

		// Token: 0x04000C12 RID: 3090
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_SetCursor_t));
	}
}
