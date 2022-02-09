using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200012B RID: 299
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LeaderboardFindResult_t : ICallbackData
	{
		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600088F RID: 2191 RVA: 0x0000D78E File Offset: 0x0000B98E
		public int DataSize
		{
			get
			{
				return LeaderboardFindResult_t._datasize;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000890 RID: 2192 RVA: 0x0000D795 File Offset: 0x0000B995
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LeaderboardFindResult;
			}
		}

		// Token: 0x04000AF6 RID: 2806
		internal ulong SteamLeaderboard;

		// Token: 0x04000AF7 RID: 2807
		internal byte LeaderboardFound;

		// Token: 0x04000AF8 RID: 2808
		internal static int _datasize = Marshal.SizeOf(typeof(LeaderboardFindResult_t));
	}
}
