using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000108 RID: 264
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct EndGameResultCallback_t : ICallbackData
	{
		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600081D RID: 2077 RVA: 0x0000D18B File Offset: 0x0000B38B
		public int DataSize
		{
			get
			{
				return EndGameResultCallback_t._datasize;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600081E RID: 2078 RVA: 0x0000D192 File Offset: 0x0000B392
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.EndGameResultCallback;
			}
		}

		// Token: 0x04000A5C RID: 2652
		internal Result Result;

		// Token: 0x04000A5D RID: 2653
		internal ulong UllUniqueGameID;

		// Token: 0x04000A5E RID: 2654
		internal static int _datasize = Marshal.SizeOf(typeof(EndGameResultCallback_t));
	}
}
