using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000DF RID: 223
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct ClanOfficerListResponse_t : ICallbackData
	{
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060007A0 RID: 1952 RVA: 0x0000CB89 File Offset: 0x0000AD89
		public int DataSize
		{
			get
			{
				return ClanOfficerListResponse_t._datasize;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060007A1 RID: 1953 RVA: 0x0000CB90 File Offset: 0x0000AD90
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.ClanOfficerListResponse;
			}
		}

		// Token: 0x040009C5 RID: 2501
		internal ulong SteamIDClan;

		// Token: 0x040009C6 RID: 2502
		internal int COfficers;

		// Token: 0x040009C7 RID: 2503
		internal byte Success;

		// Token: 0x040009C8 RID: 2504
		internal static int _datasize = Marshal.SizeOf(typeof(ClanOfficerListResponse_t));
	}
}
