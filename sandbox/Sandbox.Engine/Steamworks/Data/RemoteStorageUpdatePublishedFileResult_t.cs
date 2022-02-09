using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000116 RID: 278
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageUpdatePublishedFileResult_t : ICallbackData
	{
		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000849 RID: 2121 RVA: 0x0000D3C1 File Offset: 0x0000B5C1
		public int DataSize
		{
			get
			{
				return RemoteStorageUpdatePublishedFileResult_t._datasize;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x0000D3C8 File Offset: 0x0000B5C8
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageUpdatePublishedFileResult;
			}
		}

		// Token: 0x04000A8A RID: 2698
		internal Result Result;

		// Token: 0x04000A8B RID: 2699
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000A8C RID: 2700
		[MarshalAs(UnmanagedType.I1)]
		internal bool UserNeedsToAcceptWorkshopLegalAgreement;

		// Token: 0x04000A8D RID: 2701
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageUpdatePublishedFileResult_t));
	}
}
