using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000F1 RID: 241
	internal struct SteamShutdown_t : ICallbackData
	{
		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060007D8 RID: 2008 RVA: 0x0000CE4F File Offset: 0x0000B04F
		public int DataSize
		{
			get
			{
				return SteamShutdown_t._datasize;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060007D9 RID: 2009 RVA: 0x0000CE56 File Offset: 0x0000B056
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamShutdown;
			}
		}

		// Token: 0x040009FE RID: 2558
		internal static int _datasize = Marshal.SizeOf(typeof(SteamShutdown_t));
	}
}
