using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000D0 RID: 208
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct IPCFailure_t : ICallbackData
	{
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600076F RID: 1903 RVA: 0x0000C8F7 File Offset: 0x0000AAF7
		public int DataSize
		{
			get
			{
				return IPCFailure_t._datasize;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x0000C8FE File Offset: 0x0000AAFE
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.IPCFailure;
			}
		}

		// Token: 0x04000992 RID: 2450
		internal byte FailureType;

		// Token: 0x04000993 RID: 2451
		internal static int _datasize = Marshal.SizeOf(typeof(IPCFailure_t));

		// Token: 0x0200036E RID: 878
		internal enum EFailureType
		{
			// Token: 0x04001752 RID: 5970
			FlushedCallbackQueue,
			// Token: 0x04001753 RID: 5971
			PipeFail
		}
	}
}
