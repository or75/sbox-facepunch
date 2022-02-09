using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000179 RID: 377
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_NewWindow_t : ICallbackData
	{
		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x0000E2E3 File Offset: 0x0000C4E3
		public int DataSize
		{
			get
			{
				return HTML_NewWindow_t._datasize;
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x0600097D RID: 2429 RVA: 0x0000E2EA File Offset: 0x0000C4EA
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_NewWindow;
			}
		}

		// Token: 0x04000C08 RID: 3080
		internal uint UnBrowserHandle;

		// Token: 0x04000C09 RID: 3081
		internal string PchURL;

		// Token: 0x04000C0A RID: 3082
		internal uint UnX;

		// Token: 0x04000C0B RID: 3083
		internal uint UnY;

		// Token: 0x04000C0C RID: 3084
		internal uint UnWide;

		// Token: 0x04000C0D RID: 3085
		internal uint UnTall;

		// Token: 0x04000C0E RID: 3086
		internal uint UnNewWindow_BrowserHandle_IGNORE;

		// Token: 0x04000C0F RID: 3087
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_NewWindow_t));
	}
}
