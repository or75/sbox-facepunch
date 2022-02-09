using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000171 RID: 369
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_SearchResults_t : ICallbackData
	{
		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x0000E1C3 File Offset: 0x0000C3C3
		public int DataSize
		{
			get
			{
				return HTML_SearchResults_t._datasize;
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000965 RID: 2405 RVA: 0x0000E1CA File Offset: 0x0000C3CA
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_SearchResults;
			}
		}

		// Token: 0x04000BE1 RID: 3041
		internal uint UnBrowserHandle;

		// Token: 0x04000BE2 RID: 3042
		internal uint UnResults;

		// Token: 0x04000BE3 RID: 3043
		internal uint UnCurrentMatch;

		// Token: 0x04000BE4 RID: 3044
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_SearchResults_t));
	}
}
