using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000172 RID: 370
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_CanGoBackAndForward_t : ICallbackData
	{
		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000967 RID: 2407 RVA: 0x0000E1E7 File Offset: 0x0000C3E7
		public int DataSize
		{
			get
			{
				return HTML_CanGoBackAndForward_t._datasize;
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000968 RID: 2408 RVA: 0x0000E1EE File Offset: 0x0000C3EE
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_CanGoBackAndForward;
			}
		}

		// Token: 0x04000BE5 RID: 3045
		internal uint UnBrowserHandle;

		// Token: 0x04000BE6 RID: 3046
		[MarshalAs(UnmanagedType.I1)]
		internal bool BCanGoBack;

		// Token: 0x04000BE7 RID: 3047
		[MarshalAs(UnmanagedType.I1)]
		internal bool BCanGoForward;

		// Token: 0x04000BE8 RID: 3048
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_CanGoBackAndForward_t));
	}
}
