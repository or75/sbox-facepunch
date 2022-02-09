using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200015F RID: 351
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct AddUGCDependencyResult_t : ICallbackData
	{
		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600092E RID: 2350 RVA: 0x0000DF3B File Offset: 0x0000C13B
		public int DataSize
		{
			get
			{
				return AddUGCDependencyResult_t._datasize;
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x0600092F RID: 2351 RVA: 0x0000DF42 File Offset: 0x0000C142
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.AddUGCDependencyResult;
			}
		}

		// Token: 0x04000B91 RID: 2961
		internal Result Result;

		// Token: 0x04000B92 RID: 2962
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000B93 RID: 2963
		internal PublishedFileId ChildPublishedFileId;

		// Token: 0x04000B94 RID: 2964
		internal static int _datasize = Marshal.SizeOf(typeof(AddUGCDependencyResult_t));
	}
}
