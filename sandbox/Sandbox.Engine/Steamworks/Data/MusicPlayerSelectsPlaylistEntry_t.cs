using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200014C RID: 332
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct MusicPlayerSelectsPlaylistEntry_t : ICallbackData
	{
		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060008F4 RID: 2292 RVA: 0x0000DC70 File Offset: 0x0000BE70
		public int DataSize
		{
			get
			{
				return MusicPlayerSelectsPlaylistEntry_t._datasize;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060008F5 RID: 2293 RVA: 0x0000DC77 File Offset: 0x0000BE77
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MusicPlayerSelectsPlaylistEntry;
			}
		}

		// Token: 0x04000B48 RID: 2888
		internal int NID;

		// Token: 0x04000B49 RID: 2889
		internal static int _datasize = Marshal.SizeOf(typeof(MusicPlayerSelectsPlaylistEntry_t));
	}
}
