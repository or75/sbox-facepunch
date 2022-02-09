using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000145 RID: 325
	internal struct MusicPlayerWantsPause_t : ICallbackData
	{
		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060008DF RID: 2271 RVA: 0x0000DB74 File Offset: 0x0000BD74
		public int DataSize
		{
			get
			{
				return MusicPlayerWantsPause_t._datasize;
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060008E0 RID: 2272 RVA: 0x0000DB7B File Offset: 0x0000BD7B
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MusicPlayerWantsPause;
			}
		}

		// Token: 0x04000B3D RID: 2877
		internal static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsPause_t));
	}
}
