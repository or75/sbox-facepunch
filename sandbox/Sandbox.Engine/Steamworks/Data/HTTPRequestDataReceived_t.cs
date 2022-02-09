using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000150 RID: 336
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTTPRequestDataReceived_t : ICallbackData
	{
		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x0000DD00 File Offset: 0x0000BF00
		public int DataSize
		{
			get
			{
				return HTTPRequestDataReceived_t._datasize;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000901 RID: 2305 RVA: 0x0000DD07 File Offset: 0x0000BF07
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTTPRequestDataReceived;
			}
		}

		// Token: 0x04000B55 RID: 2901
		internal uint Request;

		// Token: 0x04000B56 RID: 2902
		internal ulong ContextValue;

		// Token: 0x04000B57 RID: 2903
		internal uint COffset;

		// Token: 0x04000B58 RID: 2904
		internal uint CBytesReceived;

		// Token: 0x04000B59 RID: 2905
		internal static int _datasize = Marshal.SizeOf(typeof(HTTPRequestDataReceived_t));
	}
}
