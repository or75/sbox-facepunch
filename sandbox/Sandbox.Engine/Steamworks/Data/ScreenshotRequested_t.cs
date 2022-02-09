using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200013D RID: 317
	internal struct ScreenshotRequested_t : ICallbackData
	{
		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060008C7 RID: 2247 RVA: 0x0000DA54 File Offset: 0x0000BC54
		public int DataSize
		{
			get
			{
				return ScreenshotRequested_t._datasize;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060008C8 RID: 2248 RVA: 0x0000DA5B File Offset: 0x0000BC5B
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.ScreenshotRequested;
			}
		}

		// Token: 0x04000B34 RID: 2868
		internal static int _datasize = Marshal.SizeOf(typeof(ScreenshotRequested_t));
	}
}
