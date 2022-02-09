using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200012F RID: 303
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct UserStatsUnloaded_t : ICallbackData
	{
		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600089B RID: 2203 RVA: 0x0000D81E File Offset: 0x0000BA1E
		public int DataSize
		{
			get
			{
				return UserStatsUnloaded_t._datasize;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x0600089C RID: 2204 RVA: 0x0000D825 File Offset: 0x0000BA25
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.UserStatsUnloaded;
			}
		}

		// Token: 0x04000B07 RID: 2823
		internal ulong SteamIDUser;

		// Token: 0x04000B08 RID: 2824
		internal static int _datasize = Marshal.SizeOf(typeof(UserStatsUnloaded_t));
	}
}
