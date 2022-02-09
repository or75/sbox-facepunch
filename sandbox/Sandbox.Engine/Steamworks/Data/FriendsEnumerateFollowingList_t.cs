using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000EA RID: 234
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct FriendsEnumerateFollowingList_t : ICallbackData
	{
		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060007C2 RID: 1986 RVA: 0x0000CD34 File Offset: 0x0000AF34
		public int DataSize
		{
			get
			{
				return FriendsEnumerateFollowingList_t._datasize;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060007C3 RID: 1987 RVA: 0x0000CD3B File Offset: 0x0000AF3B
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.FriendsEnumerateFollowingList;
			}
		}

		// Token: 0x040009EB RID: 2539
		internal Result Result;

		// Token: 0x040009EC RID: 2540
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
		internal ulong[] GSteamID;

		// Token: 0x040009ED RID: 2541
		internal int ResultsReturned;

		// Token: 0x040009EE RID: 2542
		internal int TotalResultCount;

		// Token: 0x040009EF RID: 2543
		internal static int _datasize = Marshal.SizeOf(typeof(FriendsEnumerateFollowingList_t));
	}
}
