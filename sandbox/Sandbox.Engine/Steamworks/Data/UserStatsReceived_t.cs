using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000128 RID: 296
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct UserStatsReceived_t : ICallbackData
	{
		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000885 RID: 2181 RVA: 0x0000D703 File Offset: 0x0000B903
		public int DataSize
		{
			get
			{
				return UserStatsReceived_t._datasize;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000886 RID: 2182 RVA: 0x0000D70A File Offset: 0x0000B90A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.UserStatsReceived;
			}
		}

		// Token: 0x04000AE9 RID: 2793
		internal ulong GameID;

		// Token: 0x04000AEA RID: 2794
		internal Result Result;

		// Token: 0x04000AEB RID: 2795
		internal ulong SteamIDUser;

		// Token: 0x04000AEC RID: 2796
		internal static int _datasize = Marshal.SizeOf(typeof(UserStatsReceived_t));
	}
}
