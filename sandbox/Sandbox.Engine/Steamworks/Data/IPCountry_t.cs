using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000EE RID: 238
	internal struct IPCountry_t : ICallbackData
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060007CF RID: 1999 RVA: 0x0000CDE3 File Offset: 0x0000AFE3
		public int DataSize
		{
			get
			{
				return IPCountry_t._datasize;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060007D0 RID: 2000 RVA: 0x0000CDEA File Offset: 0x0000AFEA
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.IPCountry;
			}
		}

		// Token: 0x040009F7 RID: 2551
		internal static int _datasize = Marshal.SizeOf(typeof(IPCountry_t));
	}
}
