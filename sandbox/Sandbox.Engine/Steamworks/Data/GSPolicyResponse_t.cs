using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000192 RID: 402
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GSPolicyResponse_t : ICallbackData
	{
		// Token: 0x17000214 RID: 532
		// (get) Token: 0x060009CD RID: 2509 RVA: 0x0000E721 File Offset: 0x0000C921
		public int DataSize
		{
			get
			{
				return GSPolicyResponse_t._datasize;
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x060009CE RID: 2510 RVA: 0x0000E728 File Offset: 0x0000C928
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GSPolicyResponse;
			}
		}

		// Token: 0x04000C58 RID: 3160
		internal byte Secure;

		// Token: 0x04000C59 RID: 3161
		internal static int _datasize = Marshal.SizeOf(typeof(GSPolicyResponse_t));
	}
}
