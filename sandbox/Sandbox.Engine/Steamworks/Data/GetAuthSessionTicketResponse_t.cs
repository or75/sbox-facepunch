using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000D5 RID: 213
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GetAuthSessionTicketResponse_t : ICallbackData
	{
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600077E RID: 1918 RVA: 0x0000C9A5 File Offset: 0x0000ABA5
		public int DataSize
		{
			get
			{
				return GetAuthSessionTicketResponse_t._datasize;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x0000C9AC File Offset: 0x0000ABAC
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GetAuthSessionTicketResponse;
			}
		}

		// Token: 0x0400099F RID: 2463
		internal uint AuthTicket;

		// Token: 0x040009A0 RID: 2464
		internal Result Result;

		// Token: 0x040009A1 RID: 2465
		internal static int _datasize = Marshal.SizeOf(typeof(GetAuthSessionTicketResponse_t));
	}
}
