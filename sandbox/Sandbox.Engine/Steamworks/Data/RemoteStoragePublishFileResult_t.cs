using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000110 RID: 272
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStoragePublishFileResult_t : ICallbackData
	{
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000837 RID: 2103 RVA: 0x0000D2E9 File Offset: 0x0000B4E9
		public int DataSize
		{
			get
			{
				return RemoteStoragePublishFileResult_t._datasize;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x0000D2F0 File Offset: 0x0000B4F0
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStoragePublishFileResult;
			}
		}

		// Token: 0x04000A72 RID: 2674
		internal Result Result;

		// Token: 0x04000A73 RID: 2675
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000A74 RID: 2676
		[MarshalAs(UnmanagedType.I1)]
		internal bool UserNeedsToAcceptWorkshopLegalAgreement;

		// Token: 0x04000A75 RID: 2677
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStoragePublishFileResult_t));
	}
}
