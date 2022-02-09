using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000178 RID: 376
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_FileOpenDialog_t : ICallbackData
	{
		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000979 RID: 2425 RVA: 0x0000E2BF File Offset: 0x0000C4BF
		public int DataSize
		{
			get
			{
				return HTML_FileOpenDialog_t._datasize;
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x0600097A RID: 2426 RVA: 0x0000E2C6 File Offset: 0x0000C4C6
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_FileOpenDialog;
			}
		}

		// Token: 0x04000C04 RID: 3076
		internal uint UnBrowserHandle;

		// Token: 0x04000C05 RID: 3077
		internal string PchTitle;

		// Token: 0x04000C06 RID: 3078
		internal string PchInitialFile;

		// Token: 0x04000C07 RID: 3079
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_FileOpenDialog_t));
	}
}
