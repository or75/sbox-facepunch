using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000D9 RID: 217
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct DurationControl_t : ICallbackData
	{
		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600078C RID: 1932 RVA: 0x0000CA73 File Offset: 0x0000AC73
		public int DataSize
		{
			get
			{
				return DurationControl_t._datasize;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600078D RID: 1933 RVA: 0x0000CA7A File Offset: 0x0000AC7A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.DurationControl;
			}
		}

		// Token: 0x040009AC RID: 2476
		internal Result Result;

		// Token: 0x040009AD RID: 2477
		internal AppId Appid;

		// Token: 0x040009AE RID: 2478
		[MarshalAs(UnmanagedType.I1)]
		internal bool Applicable;

		// Token: 0x040009AF RID: 2479
		internal int CsecsLast5h;

		// Token: 0x040009B0 RID: 2480
		internal DurationControlProgress Progress;

		// Token: 0x040009B1 RID: 2481
		internal DurationControlNotification Otification;

		// Token: 0x040009B2 RID: 2482
		internal int CsecsToday;

		// Token: 0x040009B3 RID: 2483
		internal int CsecsRemaining;

		// Token: 0x040009B4 RID: 2484
		internal static int _datasize = Marshal.SizeOf(typeof(DurationControl_t));
	}
}
