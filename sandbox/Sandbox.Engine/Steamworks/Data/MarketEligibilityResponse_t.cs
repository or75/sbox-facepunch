using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000D8 RID: 216
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct MarketEligibilityResponse_t : ICallbackData
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000789 RID: 1929 RVA: 0x0000CA4F File Offset: 0x0000AC4F
		public int DataSize
		{
			get
			{
				return MarketEligibilityResponse_t._datasize;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600078A RID: 1930 RVA: 0x0000CA56 File Offset: 0x0000AC56
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MarketEligibilityResponse;
			}
		}

		// Token: 0x040009A6 RID: 2470
		[MarshalAs(UnmanagedType.I1)]
		internal bool Allowed;

		// Token: 0x040009A7 RID: 2471
		internal MarketNotAllowedReasonFlags NotAllowedReason;

		// Token: 0x040009A8 RID: 2472
		internal uint TAllowedAtTime;

		// Token: 0x040009A9 RID: 2473
		internal int CdaySteamGuardRequiredDays;

		// Token: 0x040009AA RID: 2474
		internal int CdayNewDeviceCooldown;

		// Token: 0x040009AB RID: 2475
		internal static int _datasize = Marshal.SizeOf(typeof(MarketEligibilityResponse_t));
	}
}
