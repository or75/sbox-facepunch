using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000162 RID: 354
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoveAppDependencyResult_t : ICallbackData
	{
		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000937 RID: 2359 RVA: 0x0000DFA7 File Offset: 0x0000C1A7
		public int DataSize
		{
			get
			{
				return RemoveAppDependencyResult_t._datasize;
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000938 RID: 2360 RVA: 0x0000DFAE File Offset: 0x0000C1AE
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoveAppDependencyResult;
			}
		}

		// Token: 0x04000B9D RID: 2973
		internal Result Result;

		// Token: 0x04000B9E RID: 2974
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000B9F RID: 2975
		internal AppId AppID;

		// Token: 0x04000BA0 RID: 2976
		internal static int _datasize = Marshal.SizeOf(typeof(RemoveAppDependencyResult_t));
	}
}
