using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000D2 RID: 210
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct ValidateAuthTicketResponse_t : ICallbackData
	{
		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x0000C939 File Offset: 0x0000AB39
		public int DataSize
		{
			get
			{
				return ValidateAuthTicketResponse_t._datasize;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000776 RID: 1910 RVA: 0x0000C940 File Offset: 0x0000AB40
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.ValidateAuthTicketResponse;
			}
		}

		// Token: 0x04000995 RID: 2453
		internal ulong SteamID;

		// Token: 0x04000996 RID: 2454
		internal AuthResponse AuthSessionResponse;

		// Token: 0x04000997 RID: 2455
		internal ulong OwnerSteamID;

		// Token: 0x04000998 RID: 2456
		internal static int _datasize = Marshal.SizeOf(typeof(ValidateAuthTicketResponse_t));
	}
}
