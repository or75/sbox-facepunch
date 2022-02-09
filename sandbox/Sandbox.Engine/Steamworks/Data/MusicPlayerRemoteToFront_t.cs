using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000142 RID: 322
	internal struct MusicPlayerRemoteToFront_t : ICallbackData
	{
		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060008D6 RID: 2262 RVA: 0x0000DB08 File Offset: 0x0000BD08
		public int DataSize
		{
			get
			{
				return MusicPlayerRemoteToFront_t._datasize;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060008D7 RID: 2263 RVA: 0x0000DB0F File Offset: 0x0000BD0F
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MusicPlayerRemoteToFront;
			}
		}

		// Token: 0x04000B3A RID: 2874
		internal static int _datasize = Marshal.SizeOf(typeof(MusicPlayerRemoteToFront_t));
	}
}
