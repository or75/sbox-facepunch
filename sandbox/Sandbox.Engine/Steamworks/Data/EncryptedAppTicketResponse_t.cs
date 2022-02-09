using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000D4 RID: 212
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct EncryptedAppTicketResponse_t : ICallbackData
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600077B RID: 1915 RVA: 0x0000C981 File Offset: 0x0000AB81
		public int DataSize
		{
			get
			{
				return EncryptedAppTicketResponse_t._datasize;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600077C RID: 1916 RVA: 0x0000C988 File Offset: 0x0000AB88
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.EncryptedAppTicketResponse;
			}
		}

		// Token: 0x0400099D RID: 2461
		internal Result Result;

		// Token: 0x0400099E RID: 2462
		internal static int _datasize = Marshal.SizeOf(typeof(EncryptedAppTicketResponse_t));
	}
}
