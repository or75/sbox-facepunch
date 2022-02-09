using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200012E RID: 302
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct NumberOfCurrentPlayers_t : ICallbackData
	{
		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000898 RID: 2200 RVA: 0x0000D7FA File Offset: 0x0000B9FA
		public int DataSize
		{
			get
			{
				return NumberOfCurrentPlayers_t._datasize;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000899 RID: 2201 RVA: 0x0000D801 File Offset: 0x0000BA01
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.NumberOfCurrentPlayers;
			}
		}

		// Token: 0x04000B04 RID: 2820
		internal byte Success;

		// Token: 0x04000B05 RID: 2821
		internal int CPlayers;

		// Token: 0x04000B06 RID: 2822
		internal static int _datasize = Marshal.SizeOf(typeof(NumberOfCurrentPlayers_t));
	}
}
