using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000149 RID: 329
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct MusicPlayerWantsLooped_t : ICallbackData
	{
		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060008EB RID: 2283 RVA: 0x0000DC04 File Offset: 0x0000BE04
		public int DataSize
		{
			get
			{
				return MusicPlayerWantsLooped_t._datasize;
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060008EC RID: 2284 RVA: 0x0000DC0B File Offset: 0x0000BE0B
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MusicPlayerWantsLooped;
			}
		}

		// Token: 0x04000B42 RID: 2882
		[MarshalAs(UnmanagedType.I1)]
		internal bool Looped;

		// Token: 0x04000B43 RID: 2883
		internal static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsLooped_t));
	}
}
