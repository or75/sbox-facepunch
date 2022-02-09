using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000158 RID: 344
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct ItemInstalled_t : ICallbackData
	{
		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000919 RID: 2329 RVA: 0x0000DE3F File Offset: 0x0000C03F
		public int DataSize
		{
			get
			{
				return ItemInstalled_t._datasize;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x0600091A RID: 2330 RVA: 0x0000DE46 File Offset: 0x0000C046
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.ItemInstalled;
			}
		}

		// Token: 0x04000B78 RID: 2936
		internal AppId AppID;

		// Token: 0x04000B79 RID: 2937
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000B7A RID: 2938
		internal static int _datasize = Marshal.SizeOf(typeof(ItemInstalled_t));
	}
}
