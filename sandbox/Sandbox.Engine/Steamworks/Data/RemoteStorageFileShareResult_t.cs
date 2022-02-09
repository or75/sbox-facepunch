using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x0200010F RID: 271
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageFileShareResult_t : ICallbackData
	{
		// Token: 0x06000833 RID: 2099 RVA: 0x0000D2A6 File Offset: 0x0000B4A6
		internal string FilenameUTF8()
		{
			return Encoding.UTF8.GetString(this.Filename, 0, Array.IndexOf<byte>(this.Filename, 0));
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000834 RID: 2100 RVA: 0x0000D2C5 File Offset: 0x0000B4C5
		public int DataSize
		{
			get
			{
				return RemoteStorageFileShareResult_t._datasize;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000835 RID: 2101 RVA: 0x0000D2CC File Offset: 0x0000B4CC
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageFileShareResult;
			}
		}

		// Token: 0x04000A6E RID: 2670
		internal Result Result;

		// Token: 0x04000A6F RID: 2671
		internal ulong File;

		// Token: 0x04000A70 RID: 2672
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
		internal byte[] Filename;

		// Token: 0x04000A71 RID: 2673
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageFileShareResult_t));
	}
}
