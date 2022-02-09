using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000190 RID: 400
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GSClientKick_t : ICallbackData
	{
		// Token: 0x17000210 RID: 528
		// (get) Token: 0x060009C6 RID: 2502 RVA: 0x0000E6BA File Offset: 0x0000C8BA
		public int DataSize
		{
			get
			{
				return GSClientKick_t._datasize;
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x060009C7 RID: 2503 RVA: 0x0000E6C1 File Offset: 0x0000C8C1
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GSClientKick;
			}
		}

		// Token: 0x04000C51 RID: 3153
		internal ulong SteamID;

		// Token: 0x04000C52 RID: 3154
		internal DenyReason DenyReason;

		// Token: 0x04000C53 RID: 3155
		internal static int _datasize = Marshal.SizeOf(typeof(GSClientKick_t));
	}
}
