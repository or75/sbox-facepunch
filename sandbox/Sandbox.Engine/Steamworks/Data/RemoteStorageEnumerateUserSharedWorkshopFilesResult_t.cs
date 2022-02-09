using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000120 RID: 288
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageEnumerateUserSharedWorkshopFilesResult_t : ICallbackData
	{
		// Token: 0x17000130 RID: 304
		// (get) Token: 0x0600086D RID: 2157 RVA: 0x0000D5E3 File Offset: 0x0000B7E3
		public int DataSize
		{
			get
			{
				return RemoteStorageEnumerateUserSharedWorkshopFilesResult_t._datasize;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x0600086E RID: 2158 RVA: 0x0000D5EA File Offset: 0x0000B7EA
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageEnumerateUserSharedWorkshopFilesResult;
			}
		}

		// Token: 0x04000ACA RID: 2762
		internal Result Result;

		// Token: 0x04000ACB RID: 2763
		internal int ResultsReturned;

		// Token: 0x04000ACC RID: 2764
		internal int TotalResultCount;

		// Token: 0x04000ACD RID: 2765
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
		internal PublishedFileId[] GPublishedFileId;

		// Token: 0x04000ACE RID: 2766
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageEnumerateUserSharedWorkshopFilesResult_t));
	}
}
