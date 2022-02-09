using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000E8 RID: 232
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct FriendsGetFollowerCount_t : ICallbackData
	{
		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060007BC RID: 1980 RVA: 0x0000CCEC File Offset: 0x0000AEEC
		public int DataSize
		{
			get
			{
				return FriendsGetFollowerCount_t._datasize;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060007BD RID: 1981 RVA: 0x0000CCF3 File Offset: 0x0000AEF3
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.FriendsGetFollowerCount;
			}
		}

		// Token: 0x040009E3 RID: 2531
		internal Result Result;

		// Token: 0x040009E4 RID: 2532
		internal ulong SteamID;

		// Token: 0x040009E5 RID: 2533
		internal int Count;

		// Token: 0x040009E6 RID: 2534
		internal static int _datasize = Marshal.SizeOf(typeof(FriendsGetFollowerCount_t));
	}
}
