using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000139 RID: 313
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct TimedTrialStatus_t : ICallbackData
	{
		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060008BB RID: 2235 RVA: 0x0000D9C4 File Offset: 0x0000BBC4
		public int DataSize
		{
			get
			{
				return TimedTrialStatus_t._datasize;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060008BC RID: 2236 RVA: 0x0000D9CB File Offset: 0x0000BBCB
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.TimedTrialStatus;
			}
		}

		// Token: 0x04000B27 RID: 2855
		internal AppId AppID;

		// Token: 0x04000B28 RID: 2856
		[MarshalAs(UnmanagedType.I1)]
		internal bool IsOffline;

		// Token: 0x04000B29 RID: 2857
		internal uint SecondsAllowed;

		// Token: 0x04000B2A RID: 2858
		internal uint SecondsPlayed;

		// Token: 0x04000B2B RID: 2859
		internal static int _datasize = Marshal.SizeOf(typeof(TimedTrialStatus_t));
	}
}
