using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000175 RID: 373
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_LinkAtPosition_t : ICallbackData
	{
		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000970 RID: 2416 RVA: 0x0000E253 File Offset: 0x0000C453
		public int DataSize
		{
			get
			{
				return HTML_LinkAtPosition_t._datasize;
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000971 RID: 2417 RVA: 0x0000E25A File Offset: 0x0000C45A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_LinkAtPosition;
			}
		}

		// Token: 0x04000BF7 RID: 3063
		internal uint UnBrowserHandle;

		// Token: 0x04000BF8 RID: 3064
		internal uint X;

		// Token: 0x04000BF9 RID: 3065
		internal uint Y;

		// Token: 0x04000BFA RID: 3066
		internal string PchURL;

		// Token: 0x04000BFB RID: 3067
		[MarshalAs(UnmanagedType.I1)]
		internal bool BInput;

		// Token: 0x04000BFC RID: 3068
		[MarshalAs(UnmanagedType.I1)]
		internal bool BLiveLink;

		// Token: 0x04000BFD RID: 3069
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_LinkAtPosition_t));
	}
}
