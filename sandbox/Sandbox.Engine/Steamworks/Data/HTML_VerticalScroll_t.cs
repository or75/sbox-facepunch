using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000174 RID: 372
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTML_VerticalScroll_t : ICallbackData
	{
		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x0600096D RID: 2413 RVA: 0x0000E22F File Offset: 0x0000C42F
		public int DataSize
		{
			get
			{
				return HTML_VerticalScroll_t._datasize;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x0600096E RID: 2414 RVA: 0x0000E236 File Offset: 0x0000C436
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTML_VerticalScroll;
			}
		}

		// Token: 0x04000BF0 RID: 3056
		internal uint UnBrowserHandle;

		// Token: 0x04000BF1 RID: 3057
		internal uint UnScrollMax;

		// Token: 0x04000BF2 RID: 3058
		internal uint UnScrollCurrent;

		// Token: 0x04000BF3 RID: 3059
		internal float FlPageScale;

		// Token: 0x04000BF4 RID: 3060
		[MarshalAs(UnmanagedType.I1)]
		internal bool BVisible;

		// Token: 0x04000BF5 RID: 3061
		internal uint UnPageSize;

		// Token: 0x04000BF6 RID: 3062
		internal static int _datasize = Marshal.SizeOf(typeof(HTML_VerticalScroll_t));
	}
}
