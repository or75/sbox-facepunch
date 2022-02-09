using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000F0 RID: 240
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamAPICallCompleted_t : ICallbackData
	{
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060007D5 RID: 2005 RVA: 0x0000CE2B File Offset: 0x0000B02B
		public int DataSize
		{
			get
			{
				return SteamAPICallCompleted_t._datasize;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060007D6 RID: 2006 RVA: 0x0000CE32 File Offset: 0x0000B032
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamAPICallCompleted;
			}
		}

		// Token: 0x040009FA RID: 2554
		internal ulong AsyncCall;

		// Token: 0x040009FB RID: 2555
		internal int Callback;

		// Token: 0x040009FC RID: 2556
		internal uint ParamCount;

		// Token: 0x040009FD RID: 2557
		internal static int _datasize = Marshal.SizeOf(typeof(SteamAPICallCompleted_t));
	}
}
