using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200014E RID: 334
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct HTTPRequestCompleted_t : ICallbackData
	{
		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060008FA RID: 2298 RVA: 0x0000DCB8 File Offset: 0x0000BEB8
		public int DataSize
		{
			get
			{
				return HTTPRequestCompleted_t._datasize;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060008FB RID: 2299 RVA: 0x0000DCBF File Offset: 0x0000BEBF
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.HTTPRequestCompleted;
			}
		}

		// Token: 0x04000B4C RID: 2892
		internal uint Request;

		// Token: 0x04000B4D RID: 2893
		internal ulong ContextValue;

		// Token: 0x04000B4E RID: 2894
		[MarshalAs(UnmanagedType.I1)]
		internal bool RequestSuccessful;

		// Token: 0x04000B4F RID: 2895
		internal HTTPStatusCode StatusCode;

		// Token: 0x04000B50 RID: 2896
		internal uint BodySize;

		// Token: 0x04000B51 RID: 2897
		internal static int _datasize = Marshal.SizeOf(typeof(HTTPRequestCompleted_t));
	}
}
