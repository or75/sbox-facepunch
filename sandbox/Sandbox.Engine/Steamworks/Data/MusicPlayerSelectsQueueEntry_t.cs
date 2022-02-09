using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200014B RID: 331
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct MusicPlayerSelectsQueueEntry_t : ICallbackData
	{
		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060008F1 RID: 2289 RVA: 0x0000DC4C File Offset: 0x0000BE4C
		public int DataSize
		{
			get
			{
				return MusicPlayerSelectsQueueEntry_t._datasize;
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060008F2 RID: 2290 RVA: 0x0000DC53 File Offset: 0x0000BE53
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MusicPlayerSelectsQueueEntry;
			}
		}

		// Token: 0x04000B46 RID: 2886
		internal int NID;

		// Token: 0x04000B47 RID: 2887
		internal static int _datasize = Marshal.SizeOf(typeof(MusicPlayerSelectsQueueEntry_t));
	}
}
