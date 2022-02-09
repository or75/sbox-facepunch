using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000138 RID: 312
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct FileDetailsResult_t : ICallbackData
	{
		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060008B8 RID: 2232 RVA: 0x0000D9A0 File Offset: 0x0000BBA0
		public int DataSize
		{
			get
			{
				return FileDetailsResult_t._datasize;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060008B9 RID: 2233 RVA: 0x0000D9A7 File Offset: 0x0000BBA7
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.FileDetailsResult;
			}
		}

		// Token: 0x04000B22 RID: 2850
		internal Result Result;

		// Token: 0x04000B23 RID: 2851
		internal ulong FileSize;

		// Token: 0x04000B24 RID: 2852
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		internal byte[] FileSHA;

		// Token: 0x04000B25 RID: 2853
		internal uint Flags;

		// Token: 0x04000B26 RID: 2854
		internal static int _datasize = Marshal.SizeOf(typeof(FileDetailsResult_t));
	}
}
