using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000143 RID: 323
	internal struct MusicPlayerWillQuit_t : ICallbackData
	{
		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060008D9 RID: 2265 RVA: 0x0000DB2C File Offset: 0x0000BD2C
		public int DataSize
		{
			get
			{
				return MusicPlayerWillQuit_t._datasize;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060008DA RID: 2266 RVA: 0x0000DB33 File Offset: 0x0000BD33
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MusicPlayerWillQuit;
			}
		}

		// Token: 0x04000B3B RID: 2875
		internal static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWillQuit_t));
	}
}
