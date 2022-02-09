using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000135 RID: 309
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RegisterActivationCodeResponse_t : ICallbackData
	{
		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060008AE RID: 2222 RVA: 0x0000D915 File Offset: 0x0000BB15
		public int DataSize
		{
			get
			{
				return RegisterActivationCodeResponse_t._datasize;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060008AF RID: 2223 RVA: 0x0000D91C File Offset: 0x0000BB1C
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RegisterActivationCodeResponse;
			}
		}

		// Token: 0x04000B19 RID: 2841
		internal RegisterActivationCodeResult Result;

		// Token: 0x04000B1A RID: 2842
		internal uint PackageRegistered;

		// Token: 0x04000B1B RID: 2843
		internal static int _datasize = Marshal.SizeOf(typeof(RegisterActivationCodeResponse_t));
	}
}
