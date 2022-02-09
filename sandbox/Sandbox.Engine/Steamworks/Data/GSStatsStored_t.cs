using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000199 RID: 409
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct GSStatsStored_t : ICallbackData
	{
		// Token: 0x17000222 RID: 546
		// (get) Token: 0x060009E2 RID: 2530 RVA: 0x0000E81A File Offset: 0x0000CA1A
		public int DataSize
		{
			get
			{
				return GSStatsStored_t._datasize;
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x060009E3 RID: 2531 RVA: 0x0000E821 File Offset: 0x0000CA21
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GSStatsStored;
			}
		}

		// Token: 0x04000C77 RID: 3191
		internal Result Result;

		// Token: 0x04000C78 RID: 3192
		internal ulong SteamIDUser;

		// Token: 0x04000C79 RID: 3193
		internal static int _datasize = Marshal.SizeOf(typeof(GSStatsStored_t));
	}
}
