using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000129 RID: 297
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct UserStatsStored_t : ICallbackData
	{
		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000888 RID: 2184 RVA: 0x0000D727 File Offset: 0x0000B927
		public int DataSize
		{
			get
			{
				return UserStatsStored_t._datasize;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000889 RID: 2185 RVA: 0x0000D72E File Offset: 0x0000B92E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.UserStatsStored;
			}
		}

		// Token: 0x04000AED RID: 2797
		internal ulong GameID;

		// Token: 0x04000AEE RID: 2798
		internal Result Result;

		// Token: 0x04000AEF RID: 2799
		internal static int _datasize = Marshal.SizeOf(typeof(UserStatsStored_t));
	}
}
