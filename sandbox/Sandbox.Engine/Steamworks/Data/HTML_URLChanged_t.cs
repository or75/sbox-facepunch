using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200016D RID: 365
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_URLChanged_t : ICallbackData
	{
		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000958 RID: 2392 RVA: 0x0000E133 File Offset: 0x0000C333
		public int DataSize
		{
			get
			{
				return HTML_URLChanged_t._datasize;
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000959 RID: 2393 RVA: 0x0000E13A File Offset: 0x0000C33A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_URLChanged;
			}
		}

		// Token: 0x04000BD0 RID: 3024
		internal uint UnBrowserHandle;

		// Token: 0x04000BD1 RID: 3025
		internal string PchURL;

		// Token: 0x04000BD2 RID: 3026
		internal string PchPostData;

		// Token: 0x04000BD3 RID: 3027
		[MarshalAs(UnmanagedType.I1)]
		internal bool BIsRedirect;

		// Token: 0x04000BD4 RID: 3028
		internal string PchPageTitle;

		// Token: 0x04000BD5 RID: 3029
		[MarshalAs(UnmanagedType.I1)]
		internal bool BNewNavigation;

		// Token: 0x04000BD6 RID: 3030
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_URLChanged_t));
	}
}
