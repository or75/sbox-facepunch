using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000165 RID: 357
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct UserSubscribedItemsListChanged_t : ICallbackData
	{
		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x0000E013 File Offset: 0x0000C213
		public int DataSize
		{
			get
			{
				return UserSubscribedItemsListChanged_t._datasize;
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000941 RID: 2369 RVA: 0x0000E01A File Offset: 0x0000C21A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.UserSubscribedItemsListChanged;
			}
		}

		// Token: 0x04000BAA RID: 2986
		internal AppId AppID;

		// Token: 0x04000BAB RID: 2987
		internal static int _datasize = Marshal.SizeOf(typeof(UserSubscribedItemsListChanged_t));
	}
}
