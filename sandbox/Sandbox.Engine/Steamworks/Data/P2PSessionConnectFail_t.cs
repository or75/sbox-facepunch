using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200013B RID: 315
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct P2PSessionConnectFail_t : ICallbackData
	{
		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060008C1 RID: 2241 RVA: 0x0000DA0C File Offset: 0x0000BC0C
		public int DataSize
		{
			get
			{
				return P2PSessionConnectFail_t._datasize;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060008C2 RID: 2242 RVA: 0x0000DA13 File Offset: 0x0000BC13
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.P2PSessionConnectFail;
			}
		}

		// Token: 0x04000B2E RID: 2862
		internal ulong SteamIDRemote;

		// Token: 0x04000B2F RID: 2863
		internal byte P2PSessionError;

		// Token: 0x04000B30 RID: 2864
		internal static int _datasize = Marshal.SizeOf(typeof(P2PSessionConnectFail_t));
	}
}
