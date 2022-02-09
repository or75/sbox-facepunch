using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000D3 RID: 211
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct MicroTxnAuthorizationResponse_t : ICallbackData
	{
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x0000C95D File Offset: 0x0000AB5D
		public int DataSize
		{
			get
			{
				return MicroTxnAuthorizationResponse_t._datasize;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x0000C964 File Offset: 0x0000AB64
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MicroTxnAuthorizationResponse;
			}
		}

		// Token: 0x04000999 RID: 2457
		internal uint AppID;

		// Token: 0x0400099A RID: 2458
		internal ulong OrderID;

		// Token: 0x0400099B RID: 2459
		internal byte Authorized;

		// Token: 0x0400099C RID: 2460
		internal static int _datasize = Marshal.SizeOf(typeof(MicroTxnAuthorizationResponse_t));
	}
}
