using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000194 RID: 404
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct GSClientGroupStatus_t : ICallbackData
	{
		// Token: 0x17000218 RID: 536
		// (get) Token: 0x060009D3 RID: 2515 RVA: 0x0000E766 File Offset: 0x0000C966
		public int DataSize
		{
			get
			{
				return GSClientGroupStatus_t._datasize;
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x060009D4 RID: 2516 RVA: 0x0000E76D File Offset: 0x0000C96D
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GSClientGroupStatus;
			}
		}

		// Token: 0x04000C5F RID: 3167
		internal ulong SteamIDUser;

		// Token: 0x04000C60 RID: 3168
		internal ulong SteamIDGroup;

		// Token: 0x04000C61 RID: 3169
		[MarshalAs(UnmanagedType.I1)]
		internal bool Member;

		// Token: 0x04000C62 RID: 3170
		[MarshalAs(UnmanagedType.I1)]
		internal bool Officer;

		// Token: 0x04000C63 RID: 3171
		internal static int _datasize = Marshal.SizeOf(typeof(GSClientGroupStatus_t));
	}
}
