using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000144 RID: 324
	internal struct MusicPlayerWantsPlay_t : ICallbackData
	{
		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060008DC RID: 2268 RVA: 0x0000DB50 File Offset: 0x0000BD50
		public int DataSize
		{
			get
			{
				return MusicPlayerWantsPlay_t._datasize;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060008DD RID: 2269 RVA: 0x0000DB57 File Offset: 0x0000BD57
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MusicPlayerWantsPlay;
			}
		}

		// Token: 0x04000B3C RID: 2876
		internal static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsPlay_t));
	}
}
