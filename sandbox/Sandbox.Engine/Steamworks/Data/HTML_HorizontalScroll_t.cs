using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000173 RID: 371
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_HorizontalScroll_t : ICallbackData
	{
		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x0600096A RID: 2410 RVA: 0x0000E20B File Offset: 0x0000C40B
		public int DataSize
		{
			get
			{
				return HTML_HorizontalScroll_t._datasize;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x0600096B RID: 2411 RVA: 0x0000E212 File Offset: 0x0000C412
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_HorizontalScroll;
			}
		}

		// Token: 0x04000BE9 RID: 3049
		internal uint UnBrowserHandle;

		// Token: 0x04000BEA RID: 3050
		internal uint UnScrollMax;

		// Token: 0x04000BEB RID: 3051
		internal uint UnScrollCurrent;

		// Token: 0x04000BEC RID: 3052
		internal float FlPageScale;

		// Token: 0x04000BED RID: 3053
		[MarshalAs(UnmanagedType.I1)]
		internal bool BVisible;

		// Token: 0x04000BEE RID: 3054
		internal uint UnPageSize;

		// Token: 0x04000BEF RID: 3055
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_HorizontalScroll_t));
	}
}
