using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000198 RID: 408
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct GSStatsReceived_t : ICallbackData
	{
		// Token: 0x17000220 RID: 544
		// (get) Token: 0x060009DF RID: 2527 RVA: 0x0000E7F6 File Offset: 0x0000C9F6
		public int DataSize
		{
			get
			{
				return GSStatsReceived_t._datasize;
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x060009E0 RID: 2528 RVA: 0x0000E7FD File Offset: 0x0000C9FD
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GSStatsReceived;
			}
		}

		// Token: 0x04000C74 RID: 3188
		internal Result Result;

		// Token: 0x04000C75 RID: 3189
		internal ulong SteamIDUser;

		// Token: 0x04000C76 RID: 3190
		internal static int _datasize = Marshal.SizeOf(typeof(GSStatsReceived_t));
	}
}
