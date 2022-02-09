using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000F6 RID: 246
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct FavoritesListChanged_t : ICallbackData
	{
		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060007E7 RID: 2023 RVA: 0x0000CF03 File Offset: 0x0000B103
		public int DataSize
		{
			get
			{
				return FavoritesListChanged_t._datasize;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060007E8 RID: 2024 RVA: 0x0000CF0A File Offset: 0x0000B10A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.FavoritesListChanged;
			}
		}

		// Token: 0x04000A06 RID: 2566
		internal uint IP;

		// Token: 0x04000A07 RID: 2567
		internal uint QueryPort;

		// Token: 0x04000A08 RID: 2568
		internal uint ConnPort;

		// Token: 0x04000A09 RID: 2569
		internal uint AppID;

		// Token: 0x04000A0A RID: 2570
		internal uint Flags;

		// Token: 0x04000A0B RID: 2571
		[MarshalAs(UnmanagedType.I1)]
		internal bool Add;

		// Token: 0x04000A0C RID: 2572
		internal uint AccountId;

		// Token: 0x04000A0D RID: 2573
		internal static int _datasize = Marshal.SizeOf(typeof(FavoritesListChanged_t));
	}
}
