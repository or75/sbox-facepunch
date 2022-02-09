using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x02000185 RID: 389
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamInventoryRequestPricesResult_t : ICallbackData
	{
		// Token: 0x060009A0 RID: 2464 RVA: 0x0000E493 File Offset: 0x0000C693
		internal string CurrencyUTF8()
		{
			return Encoding.UTF8.GetString(this.Currency, 0, Array.IndexOf<byte>(this.Currency, 0));
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x060009A1 RID: 2465 RVA: 0x0000E4B2 File Offset: 0x0000C6B2
		public int DataSize
		{
			get
			{
				return SteamInventoryRequestPricesResult_t._datasize;
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x060009A2 RID: 2466 RVA: 0x0000E4B9 File Offset: 0x0000C6B9
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamInventoryRequestPricesResult;
			}
		}

		// Token: 0x04000C30 RID: 3120
		internal Result Result;

		// Token: 0x04000C31 RID: 3121
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		internal byte[] Currency;

		// Token: 0x04000C32 RID: 3122
		internal static int _datasize = Marshal.SizeOf(typeof(SteamInventoryRequestPricesResult_t));
	}
}
