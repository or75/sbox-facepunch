using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000D1 RID: 209
	internal struct LicensesUpdated_t : ICallbackData
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x0000C918 File Offset: 0x0000AB18
		public int DataSize
		{
			get
			{
				return LicensesUpdated_t._datasize;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000773 RID: 1907 RVA: 0x0000C91F File Offset: 0x0000AB1F
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LicensesUpdated;
			}
		}

		// Token: 0x04000994 RID: 2452
		internal static int _datasize = Marshal.SizeOf(typeof(LicensesUpdated_t));
	}
}
