using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000131 RID: 305
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GlobalAchievementPercentagesReady_t : ICallbackData
	{
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060008A2 RID: 2210 RVA: 0x0000D885 File Offset: 0x0000BA85
		public int DataSize
		{
			get
			{
				return GlobalAchievementPercentagesReady_t._datasize;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060008A3 RID: 2211 RVA: 0x0000D88C File Offset: 0x0000BA8C
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GlobalAchievementPercentagesReady;
			}
		}

		// Token: 0x04000B0E RID: 2830
		internal ulong GameID;

		// Token: 0x04000B0F RID: 2831
		internal Result Result;

		// Token: 0x04000B10 RID: 2832
		internal static int _datasize = Marshal.SizeOf(typeof(GlobalAchievementPercentagesReady_t));
	}
}
