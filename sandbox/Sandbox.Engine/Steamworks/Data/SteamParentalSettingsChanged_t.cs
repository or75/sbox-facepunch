using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000188 RID: 392
	internal struct SteamParentalSettingsChanged_t : ICallbackData
	{
		// Token: 0x17000200 RID: 512
		// (get) Token: 0x060009AB RID: 2475 RVA: 0x0000E53D File Offset: 0x0000C73D
		public int DataSize
		{
			get
			{
				return SteamParentalSettingsChanged_t._datasize;
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x060009AC RID: 2476 RVA: 0x0000E544 File Offset: 0x0000C744
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamParentalSettingsChanged;
			}
		}

		// Token: 0x04000C3A RID: 3130
		internal static int _datasize = Marshal.SizeOf(typeof(SteamParentalSettingsChanged_t));
	}
}
