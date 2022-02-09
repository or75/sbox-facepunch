using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200015E RID: 350
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct StopPlaytimeTrackingResult_t : ICallbackData
	{
		// Token: 0x170001AC RID: 428
		// (get) Token: 0x0600092B RID: 2347 RVA: 0x0000DF17 File Offset: 0x0000C117
		public int DataSize
		{
			get
			{
				return StopPlaytimeTrackingResult_t._datasize;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600092C RID: 2348 RVA: 0x0000DF1E File Offset: 0x0000C11E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.StopPlaytimeTrackingResult;
			}
		}

		// Token: 0x04000B8F RID: 2959
		internal Result Result;

		// Token: 0x04000B90 RID: 2960
		internal static int _datasize = Marshal.SizeOf(typeof(StopPlaytimeTrackingResult_t));
	}
}
