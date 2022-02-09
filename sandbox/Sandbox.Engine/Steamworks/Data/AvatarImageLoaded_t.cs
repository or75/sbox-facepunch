using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000DE RID: 222
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct AvatarImageLoaded_t : ICallbackData
	{
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600079D RID: 1949 RVA: 0x0000CB65 File Offset: 0x0000AD65
		public int DataSize
		{
			get
			{
				return AvatarImageLoaded_t._datasize;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600079E RID: 1950 RVA: 0x0000CB6C File Offset: 0x0000AD6C
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.AvatarImageLoaded;
			}
		}

		// Token: 0x040009C0 RID: 2496
		internal ulong SteamID;

		// Token: 0x040009C1 RID: 2497
		internal int Image;

		// Token: 0x040009C2 RID: 2498
		internal int Wide;

		// Token: 0x040009C3 RID: 2499
		internal int Tall;

		// Token: 0x040009C4 RID: 2500
		internal static int _datasize = Marshal.SizeOf(typeof(AvatarImageLoaded_t));
	}
}
