using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200019A RID: 410
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GSStatsUnloaded_t : ICallbackData
	{
		// Token: 0x17000224 RID: 548
		// (get) Token: 0x060009E5 RID: 2533 RVA: 0x0000E83E File Offset: 0x0000CA3E
		public int DataSize
		{
			get
			{
				return GSStatsUnloaded_t._datasize;
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x060009E6 RID: 2534 RVA: 0x0000E845 File Offset: 0x0000CA45
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.UserStatsUnloaded;
			}
		}

		// Token: 0x04000C7A RID: 3194
		internal ulong SteamIDUser;

		// Token: 0x04000C7B RID: 3195
		internal static int _datasize = Marshal.SizeOf(typeof(GSStatsUnloaded_t));
	}
}
