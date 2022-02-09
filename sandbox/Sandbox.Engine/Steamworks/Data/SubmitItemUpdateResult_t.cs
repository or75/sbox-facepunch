using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000157 RID: 343
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SubmitItemUpdateResult_t : ICallbackData
	{
		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000916 RID: 2326 RVA: 0x0000DE1B File Offset: 0x0000C01B
		public int DataSize
		{
			get
			{
				return SubmitItemUpdateResult_t._datasize;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000917 RID: 2327 RVA: 0x0000DE22 File Offset: 0x0000C022
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SubmitItemUpdateResult;
			}
		}

		// Token: 0x04000B74 RID: 2932
		internal Result Result;

		// Token: 0x04000B75 RID: 2933
		[MarshalAs(UnmanagedType.I1)]
		internal bool UserNeedsToAcceptWorkshopLegalAgreement;

		// Token: 0x04000B76 RID: 2934
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000B77 RID: 2935
		internal static int _datasize = Marshal.SizeOf(typeof(SubmitItemUpdateResult_t));
	}
}
