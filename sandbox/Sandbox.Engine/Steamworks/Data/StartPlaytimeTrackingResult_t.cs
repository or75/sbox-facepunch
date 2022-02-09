using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200015D RID: 349
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct StartPlaytimeTrackingResult_t : ICallbackData
	{
		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000928 RID: 2344 RVA: 0x0000DEF3 File Offset: 0x0000C0F3
		public int DataSize
		{
			get
			{
				return StartPlaytimeTrackingResult_t._datasize;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000929 RID: 2345 RVA: 0x0000DEFA File Offset: 0x0000C0FA
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.StartPlaytimeTrackingResult;
			}
		}

		// Token: 0x04000B8D RID: 2957
		internal Result Result;

		// Token: 0x04000B8E RID: 2958
		internal static int _datasize = Marshal.SizeOf(typeof(StartPlaytimeTrackingResult_t));
	}
}
