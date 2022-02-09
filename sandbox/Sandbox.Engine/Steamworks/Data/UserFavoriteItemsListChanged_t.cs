using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200015A RID: 346
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct UserFavoriteItemsListChanged_t : ICallbackData
	{
		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x0600091F RID: 2335 RVA: 0x0000DE87 File Offset: 0x0000C087
		public int DataSize
		{
			get
			{
				return UserFavoriteItemsListChanged_t._datasize;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000920 RID: 2336 RVA: 0x0000DE8E File Offset: 0x0000C08E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.UserFavoriteItemsListChanged;
			}
		}

		// Token: 0x04000B7F RID: 2943
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000B80 RID: 2944
		internal Result Result;

		// Token: 0x04000B81 RID: 2945
		[MarshalAs(UnmanagedType.I1)]
		internal bool WasAddRequest;

		// Token: 0x04000B82 RID: 2946
		internal static int _datasize = Marshal.SizeOf(typeof(UserFavoriteItemsListChanged_t));
	}
}
