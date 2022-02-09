using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000EB RID: 235
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SetPersonaNameResponse_t : ICallbackData
	{
		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060007C5 RID: 1989 RVA: 0x0000CD58 File Offset: 0x0000AF58
		public int DataSize
		{
			get
			{
				return SetPersonaNameResponse_t._datasize;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060007C6 RID: 1990 RVA: 0x0000CD5F File Offset: 0x0000AF5F
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SetPersonaNameResponse;
			}
		}

		// Token: 0x040009F0 RID: 2544
		[MarshalAs(UnmanagedType.I1)]
		internal bool Success;

		// Token: 0x040009F1 RID: 2545
		[MarshalAs(UnmanagedType.I1)]
		internal bool LocalSuccess;

		// Token: 0x040009F2 RID: 2546
		internal Result Result;

		// Token: 0x040009F3 RID: 2547
		internal static int _datasize = Marshal.SizeOf(typeof(SetPersonaNameResponse_t));
	}
}
