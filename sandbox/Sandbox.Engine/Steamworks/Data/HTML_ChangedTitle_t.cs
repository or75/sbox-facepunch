using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000170 RID: 368
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_ChangedTitle_t : ICallbackData
	{
		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000961 RID: 2401 RVA: 0x0000E19F File Offset: 0x0000C39F
		public int DataSize
		{
			get
			{
				return HTML_ChangedTitle_t._datasize;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000962 RID: 2402 RVA: 0x0000E1A6 File Offset: 0x0000C3A6
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_ChangedTitle;
			}
		}

		// Token: 0x04000BDE RID: 3038
		internal uint UnBrowserHandle;

		// Token: 0x04000BDF RID: 3039
		internal string PchTitle;

		// Token: 0x04000BE0 RID: 3040
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_ChangedTitle_t));
	}
}
