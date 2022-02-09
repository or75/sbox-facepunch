using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000156 RID: 342
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct CreateItemResult_t : ICallbackData
	{
		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000913 RID: 2323 RVA: 0x0000DDF7 File Offset: 0x0000BFF7
		public int DataSize
		{
			get
			{
				return CreateItemResult_t._datasize;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000914 RID: 2324 RVA: 0x0000DDFE File Offset: 0x0000BFFE
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.CreateItemResult;
			}
		}

		// Token: 0x04000B70 RID: 2928
		internal Result Result;

		// Token: 0x04000B71 RID: 2929
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000B72 RID: 2930
		[MarshalAs(UnmanagedType.I1)]
		internal bool UserNeedsToAcceptWorkshopLegalAgreement;

		// Token: 0x04000B73 RID: 2931
		internal static int _datasize = Marshal.SizeOf(typeof(CreateItemResult_t));
	}
}
