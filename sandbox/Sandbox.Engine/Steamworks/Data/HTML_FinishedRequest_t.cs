using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200016E RID: 366
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_FinishedRequest_t : ICallbackData
	{
		// Token: 0x170001CC RID: 460
		// (get) Token: 0x0600095B RID: 2395 RVA: 0x0000E157 File Offset: 0x0000C357
		public int DataSize
		{
			get
			{
				return HTML_FinishedRequest_t._datasize;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x0000E15E File Offset: 0x0000C35E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_FinishedRequest;
			}
		}

		// Token: 0x04000BD7 RID: 3031
		internal uint UnBrowserHandle;

		// Token: 0x04000BD8 RID: 3032
		internal string PchURL;

		// Token: 0x04000BD9 RID: 3033
		internal string PchPageTitle;

		// Token: 0x04000BDA RID: 3034
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_FinishedRequest_t));
	}
}
