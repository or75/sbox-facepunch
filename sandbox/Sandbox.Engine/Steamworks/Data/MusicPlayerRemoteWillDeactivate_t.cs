using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000141 RID: 321
	internal struct MusicPlayerRemoteWillDeactivate_t : ICallbackData
	{
		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060008D3 RID: 2259 RVA: 0x0000DAE4 File Offset: 0x0000BCE4
		public int DataSize
		{
			get
			{
				return MusicPlayerRemoteWillDeactivate_t._datasize;
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060008D4 RID: 2260 RVA: 0x0000DAEB File Offset: 0x0000BCEB
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MusicPlayerRemoteWillDeactivate;
			}
		}

		// Token: 0x04000B39 RID: 2873
		internal static int _datasize = Marshal.SizeOf(typeof(MusicPlayerRemoteWillDeactivate_t));
	}
}
