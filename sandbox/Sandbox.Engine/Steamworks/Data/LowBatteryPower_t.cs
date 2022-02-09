using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000EF RID: 239
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct LowBatteryPower_t : ICallbackData
	{
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060007D2 RID: 2002 RVA: 0x0000CE07 File Offset: 0x0000B007
		public int DataSize
		{
			get
			{
				return LowBatteryPower_t._datasize;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060007D3 RID: 2003 RVA: 0x0000CE0E File Offset: 0x0000B00E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.LowBatteryPower;
			}
		}

		// Token: 0x040009F8 RID: 2552
		internal byte MinutesBatteryLeft;

		// Token: 0x040009F9 RID: 2553
		internal static int _datasize = Marshal.SizeOf(typeof(LowBatteryPower_t));
	}
}
