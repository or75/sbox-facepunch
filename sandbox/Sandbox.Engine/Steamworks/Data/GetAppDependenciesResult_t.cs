using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000163 RID: 355
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GetAppDependenciesResult_t : ICallbackData
	{
		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600093A RID: 2362 RVA: 0x0000DFCB File Offset: 0x0000C1CB
		public int DataSize
		{
			get
			{
				return GetAppDependenciesResult_t._datasize;
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x0600093B RID: 2363 RVA: 0x0000DFD2 File Offset: 0x0000C1D2
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GetAppDependenciesResult;
			}
		}

		// Token: 0x04000BA1 RID: 2977
		internal Result Result;

		// Token: 0x04000BA2 RID: 2978
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000BA3 RID: 2979
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.U4)]
		internal AppId[] GAppIDs;

		// Token: 0x04000BA4 RID: 2980
		internal uint NumAppDependencies;

		// Token: 0x04000BA5 RID: 2981
		internal uint TotalNumAppDependencies;

		// Token: 0x04000BA6 RID: 2982
		internal static int _datasize = Marshal.SizeOf(typeof(GetAppDependenciesResult_t));
	}
}
