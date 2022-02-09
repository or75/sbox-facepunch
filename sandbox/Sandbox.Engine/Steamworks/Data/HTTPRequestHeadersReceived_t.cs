using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200014F RID: 335
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTTPRequestHeadersReceived_t : ICallbackData
	{
		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060008FD RID: 2301 RVA: 0x0000DCDC File Offset: 0x0000BEDC
		public int DataSize
		{
			get
			{
				return HTTPRequestHeadersReceived_t._datasize;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x0000DCE3 File Offset: 0x0000BEE3
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTTPRequestHeadersReceived;
			}
		}

		// Token: 0x04000B52 RID: 2898
		internal uint Request;

		// Token: 0x04000B53 RID: 2899
		internal ulong ContextValue;

		// Token: 0x04000B54 RID: 2900
		internal static int _datasize = Marshal.SizeOf(typeof(HTTPRequestHeadersReceived_t));
	}
}
