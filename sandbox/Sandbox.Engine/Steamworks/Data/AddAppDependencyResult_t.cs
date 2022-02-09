using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000161 RID: 353
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct AddAppDependencyResult_t : ICallbackData
	{
		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000934 RID: 2356 RVA: 0x0000DF83 File Offset: 0x0000C183
		public int DataSize
		{
			get
			{
				return AddAppDependencyResult_t._datasize;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000935 RID: 2357 RVA: 0x0000DF8A File Offset: 0x0000C18A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.AddAppDependencyResult;
			}
		}

		// Token: 0x04000B99 RID: 2969
		internal Result Result;

		// Token: 0x04000B9A RID: 2970
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000B9B RID: 2971
		internal AppId AppID;

		// Token: 0x04000B9C RID: 2972
		internal static int _datasize = Marshal.SizeOf(typeof(AddAppDependencyResult_t));
	}
}
