using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000146 RID: 326
	internal struct MusicPlayerWantsPlayPrevious_t : ICallbackData
	{
		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060008E2 RID: 2274 RVA: 0x0000DB98 File Offset: 0x0000BD98
		public int DataSize
		{
			get
			{
				return MusicPlayerWantsPlayPrevious_t._datasize;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060008E3 RID: 2275 RVA: 0x0000DB9F File Offset: 0x0000BD9F
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MusicPlayerWantsPlayPrevious;
			}
		}

		// Token: 0x04000B3E RID: 2878
		internal static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsPlayPrevious_t));
	}
}
