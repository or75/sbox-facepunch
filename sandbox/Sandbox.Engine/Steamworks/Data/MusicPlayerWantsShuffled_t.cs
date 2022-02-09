using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000148 RID: 328
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct MusicPlayerWantsShuffled_t : ICallbackData
	{
		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060008E8 RID: 2280 RVA: 0x0000DBE0 File Offset: 0x0000BDE0
		public int DataSize
		{
			get
			{
				return MusicPlayerWantsShuffled_t._datasize;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060008E9 RID: 2281 RVA: 0x0000DBE7 File Offset: 0x0000BDE7
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MusicPlayerWantsShuffled;
			}
		}

		// Token: 0x04000B40 RID: 2880
		[MarshalAs(UnmanagedType.I1)]
		internal bool Shuffled;

		// Token: 0x04000B41 RID: 2881
		internal static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsShuffled_t));
	}
}
