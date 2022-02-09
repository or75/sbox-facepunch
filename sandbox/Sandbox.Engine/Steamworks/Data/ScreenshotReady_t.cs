using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200013C RID: 316
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct ScreenshotReady_t : ICallbackData
	{
		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060008C4 RID: 2244 RVA: 0x0000DA30 File Offset: 0x0000BC30
		public int DataSize
		{
			get
			{
				return ScreenshotReady_t._datasize;
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060008C5 RID: 2245 RVA: 0x0000DA37 File Offset: 0x0000BC37
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.ScreenshotReady;
			}
		}

		// Token: 0x04000B31 RID: 2865
		internal uint Local;

		// Token: 0x04000B32 RID: 2866
		internal Result Result;

		// Token: 0x04000B33 RID: 2867
		internal static int _datasize = Marshal.SizeOf(typeof(ScreenshotReady_t));
	}
}
