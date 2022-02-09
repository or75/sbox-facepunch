using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200014A RID: 330
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct MusicPlayerWantsVolume_t : ICallbackData
	{
		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060008EE RID: 2286 RVA: 0x0000DC28 File Offset: 0x0000BE28
		public int DataSize
		{
			get
			{
				return MusicPlayerWantsVolume_t._datasize;
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060008EF RID: 2287 RVA: 0x0000DC2F File Offset: 0x0000BE2F
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MusicPlayerWantsVolume;
			}
		}

		// Token: 0x04000B44 RID: 2884
		internal float NewVolume;

		// Token: 0x04000B45 RID: 2885
		internal static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsVolume_t));
	}
}
