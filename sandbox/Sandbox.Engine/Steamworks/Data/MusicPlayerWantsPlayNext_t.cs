using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000147 RID: 327
	internal struct MusicPlayerWantsPlayNext_t : ICallbackData
	{
		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060008E5 RID: 2277 RVA: 0x0000DBBC File Offset: 0x0000BDBC
		public int DataSize
		{
			get
			{
				return MusicPlayerWantsPlayNext_t._datasize;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060008E6 RID: 2278 RVA: 0x0000DBC3 File Offset: 0x0000BDC3
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.MusicPlayerWantsPlayNext;
			}
		}

		// Token: 0x04000B3F RID: 2879
		internal static int _datasize = Marshal.SizeOf(typeof(MusicPlayerWantsPlayNext_t));
	}
}
