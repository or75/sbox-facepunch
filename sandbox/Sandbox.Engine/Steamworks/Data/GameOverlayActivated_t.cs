using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000DB RID: 219
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GameOverlayActivated_t : ICallbackData
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000792 RID: 1938 RVA: 0x0000CABB File Offset: 0x0000ACBB
		public int DataSize
		{
			get
			{
				return GameOverlayActivated_t._datasize;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000793 RID: 1939 RVA: 0x0000CAC2 File Offset: 0x0000ACC2
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GameOverlayActivated;
			}
		}

		// Token: 0x040009B8 RID: 2488
		internal byte Active;

		// Token: 0x040009B9 RID: 2489
		internal static int _datasize = Marshal.SizeOf(typeof(GameOverlayActivated_t));
	}
}
