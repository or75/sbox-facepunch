using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000F4 RID: 244
	internal struct AppResumingFromSuspend_t : ICallbackData
	{
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060007E1 RID: 2017 RVA: 0x0000CEBB File Offset: 0x0000B0BB
		public int DataSize
		{
			get
			{
				return AppResumingFromSuspend_t._datasize;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060007E2 RID: 2018 RVA: 0x0000CEC2 File Offset: 0x0000B0C2
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.AppResumingFromSuspend;
			}
		}

		// Token: 0x04000A04 RID: 2564
		internal static int _datasize = Marshal.SizeOf(typeof(AppResumingFromSuspend_t));
	}
}
