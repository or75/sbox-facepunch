using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200016B RID: 363
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_StartRequest_t : ICallbackData
	{
		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x0000E0EB File Offset: 0x0000C2EB
		public int DataSize
		{
			get
			{
				return HTML_StartRequest_t._datasize;
			}
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000953 RID: 2387 RVA: 0x0000E0F2 File Offset: 0x0000C2F2
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_StartRequest;
			}
		}

		// Token: 0x04000BC8 RID: 3016
		internal uint UnBrowserHandle;

		// Token: 0x04000BC9 RID: 3017
		internal string PchURL;

		// Token: 0x04000BCA RID: 3018
		internal string PchTarget;

		// Token: 0x04000BCB RID: 3019
		internal string PchPostData;

		// Token: 0x04000BCC RID: 3020
		[MarshalAs(UnmanagedType.I1)]
		internal bool BIsRedirect;

		// Token: 0x04000BCD RID: 3021
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_StartRequest_t));
	}
}
