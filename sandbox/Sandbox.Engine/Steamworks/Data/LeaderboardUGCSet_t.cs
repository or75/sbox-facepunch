using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000132 RID: 306
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LeaderboardUGCSet_t : ICallbackData
	{
		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060008A5 RID: 2213 RVA: 0x0000D8A9 File Offset: 0x0000BAA9
		public int DataSize
		{
			get
			{
				return LeaderboardUGCSet_t._datasize;
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060008A6 RID: 2214 RVA: 0x0000D8B0 File Offset: 0x0000BAB0
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LeaderboardUGCSet;
			}
		}

		// Token: 0x04000B11 RID: 2833
		internal Result Result;

		// Token: 0x04000B12 RID: 2834
		internal ulong SteamLeaderboard;

		// Token: 0x04000B13 RID: 2835
		internal static int _datasize = Marshal.SizeOf(typeof(LeaderboardUGCSet_t));
	}
}
