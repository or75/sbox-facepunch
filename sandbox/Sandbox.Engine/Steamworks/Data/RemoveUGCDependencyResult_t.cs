using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000160 RID: 352
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoveUGCDependencyResult_t : ICallbackData
	{
		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000931 RID: 2353 RVA: 0x0000DF5F File Offset: 0x0000C15F
		public int DataSize
		{
			get
			{
				return RemoveUGCDependencyResult_t._datasize;
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000932 RID: 2354 RVA: 0x0000DF66 File Offset: 0x0000C166
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoveUGCDependencyResult;
			}
		}

		// Token: 0x04000B95 RID: 2965
		internal Result Result;

		// Token: 0x04000B96 RID: 2966
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000B97 RID: 2967
		internal PublishedFileId ChildPublishedFileId;

		// Token: 0x04000B98 RID: 2968
		internal static int _datasize = Marshal.SizeOf(typeof(RemoveUGCDependencyResult_t));
	}
}
