using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000133 RID: 307
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GlobalStatsReceived_t : ICallbackData
	{
		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060008A8 RID: 2216 RVA: 0x0000D8CD File Offset: 0x0000BACD
		public int DataSize
		{
			get
			{
				return GlobalStatsReceived_t._datasize;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060008A9 RID: 2217 RVA: 0x0000D8D4 File Offset: 0x0000BAD4
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GlobalStatsReceived;
			}
		}

		// Token: 0x04000B14 RID: 2836
		internal ulong GameID;

		// Token: 0x04000B15 RID: 2837
		internal Result Result;

		// Token: 0x04000B16 RID: 2838
		internal static int _datasize = Marshal.SizeOf(typeof(GlobalStatsReceived_t));
	}
}
