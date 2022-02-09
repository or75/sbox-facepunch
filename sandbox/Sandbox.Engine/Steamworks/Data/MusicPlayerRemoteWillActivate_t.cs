using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000140 RID: 320
	internal struct MusicPlayerRemoteWillActivate_t : ICallbackData
	{
		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060008D0 RID: 2256 RVA: 0x0000DAC0 File Offset: 0x0000BCC0
		public int DataSize
		{
			get
			{
				return MusicPlayerRemoteWillActivate_t._datasize;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060008D1 RID: 2257 RVA: 0x0000DAC7 File Offset: 0x0000BCC7
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MusicPlayerRemoteWillActivate;
			}
		}

		// Token: 0x04000B38 RID: 2872
		internal static int _datasize = Marshal.SizeOf(typeof(MusicPlayerRemoteWillActivate_t));
	}
}
