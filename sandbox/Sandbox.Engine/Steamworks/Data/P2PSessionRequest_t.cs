using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200013A RID: 314
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct P2PSessionRequest_t : ICallbackData
	{
		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060008BE RID: 2238 RVA: 0x0000D9E8 File Offset: 0x0000BBE8
		public int DataSize
		{
			get
			{
				return P2PSessionRequest_t._datasize;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060008BF RID: 2239 RVA: 0x0000D9EF File Offset: 0x0000BBEF
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.P2PSessionRequest;
			}
		}

		// Token: 0x04000B2C RID: 2860
		internal ulong SteamIDRemote;

		// Token: 0x04000B2D RID: 2861
		internal static int _datasize = Marshal.SizeOf(typeof(P2PSessionRequest_t));
	}
}
