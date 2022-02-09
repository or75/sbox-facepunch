using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200018E RID: 398
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct GSClientApprove_t : ICallbackData
	{
		// Token: 0x1700020C RID: 524
		// (get) Token: 0x060009BF RID: 2495 RVA: 0x0000E653 File Offset: 0x0000C853
		public int DataSize
		{
			get
			{
				return GSClientApprove_t._datasize;
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x0000E65A File Offset: 0x0000C85A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GSClientApprove;
			}
		}

		// Token: 0x04000C4A RID: 3146
		internal ulong SteamID;

		// Token: 0x04000C4B RID: 3147
		internal ulong OwnerSteamID;

		// Token: 0x04000C4C RID: 3148
		internal static int _datasize = Marshal.SizeOf(typeof(GSClientApprove_t));
	}
}
