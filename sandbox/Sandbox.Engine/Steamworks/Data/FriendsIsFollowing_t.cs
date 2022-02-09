using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000E9 RID: 233
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct FriendsIsFollowing_t : ICallbackData
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060007BF RID: 1983 RVA: 0x0000CD10 File Offset: 0x0000AF10
		public int DataSize
		{
			get
			{
				return FriendsIsFollowing_t._datasize;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060007C0 RID: 1984 RVA: 0x0000CD17 File Offset: 0x0000AF17
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.FriendsIsFollowing;
			}
		}

		// Token: 0x040009E7 RID: 2535
		internal Result Result;

		// Token: 0x040009E8 RID: 2536
		internal ulong SteamID;

		// Token: 0x040009E9 RID: 2537
		[MarshalAs(UnmanagedType.I1)]
		internal bool IsFollowing;

		// Token: 0x040009EA RID: 2538
		internal static int _datasize = Marshal.SizeOf(typeof(FriendsIsFollowing_t));
	}
}
