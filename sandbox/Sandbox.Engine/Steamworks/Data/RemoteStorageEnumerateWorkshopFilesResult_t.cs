using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000119 RID: 281
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageEnumerateWorkshopFilesResult_t : ICallbackData
	{
		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000858 RID: 2136 RVA: 0x0000D4E7 File Offset: 0x0000B6E7
		public int DataSize
		{
			get
			{
				return RemoteStorageEnumerateWorkshopFilesResult_t._datasize;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x0000D4EE File Offset: 0x0000B6EE
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageEnumerateWorkshopFilesResult;
			}
		}

		// Token: 0x04000AAB RID: 2731
		internal Result Result;

		// Token: 0x04000AAC RID: 2732
		internal int ResultsReturned;

		// Token: 0x04000AAD RID: 2733
		internal int TotalResultCount;

		// Token: 0x04000AAE RID: 2734
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.U8)]
		internal PublishedFileId[] GPublishedFileId;

		// Token: 0x04000AAF RID: 2735
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50, ArraySubType = UnmanagedType.R4)]
		internal float[] GScore;

		// Token: 0x04000AB0 RID: 2736
		internal AppId AppId;

		// Token: 0x04000AB1 RID: 2737
		internal uint StartIndex;

		// Token: 0x04000AB2 RID: 2738
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageEnumerateWorkshopFilesResult_t));
	}
}
