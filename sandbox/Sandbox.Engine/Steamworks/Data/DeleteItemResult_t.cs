using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000164 RID: 356
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct DeleteItemResult_t : ICallbackData
	{
		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x0000DFEF File Offset: 0x0000C1EF
		public int DataSize
		{
			get
			{
				return DeleteItemResult_t._datasize;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x0600093E RID: 2366 RVA: 0x0000DFF6 File Offset: 0x0000C1F6
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.DeleteItemResult;
			}
		}

		// Token: 0x04000BA7 RID: 2983
		internal Result Result;

		// Token: 0x04000BA8 RID: 2984
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000BA9 RID: 2985
		internal static int _datasize = Marshal.SizeOf(typeof(DeleteItemResult_t));
	}
}
