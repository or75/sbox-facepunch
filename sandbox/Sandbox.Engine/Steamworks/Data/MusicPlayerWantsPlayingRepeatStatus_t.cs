using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200014D RID: 333
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct MusicPlayerWantsPlayingRepeatStatus_t : ICallbackData
	{
		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060008F7 RID: 2295 RVA: 0x0000DC94 File Offset: 0x0000BE94
		public int DataSize
		{
			get
			{
				return MusicPlayerWantsPlayingRepeatStatus_t._datasize;
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060008F8 RID: 2296 RVA: 0x0000DC9B File Offset: 0x0000BE9B
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MusicPlayerWantsPlayingRepeatStatus;
			}
		}

		// Token: 0x04000B4A RID: 2890
		internal int PlayingRepeatStatus;

		// Token: 0x04000B4B RID: 2891
		internal static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsPlayingRepeatStatus_t));
	}
}
