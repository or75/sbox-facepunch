using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000101 RID: 257
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct FavoritesListAccountsUpdated_t : ICallbackData
	{
		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x0000D08F File Offset: 0x0000B28F
		public int DataSize
		{
			get
			{
				return FavoritesListAccountsUpdated_t._datasize;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x0000D096 File Offset: 0x0000B296
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.FavoritesListAccountsUpdated;
			}
		}

		// Token: 0x04000A36 RID: 2614
		internal Result Result;

		// Token: 0x04000A37 RID: 2615
		internal static int _datasize = Marshal.SizeOf(typeof(FavoritesListAccountsUpdated_t));
	}
}
