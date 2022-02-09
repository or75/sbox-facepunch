using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000187 RID: 391
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GetOPFSettingsResult_t : ICallbackData
	{
		// Token: 0x170001FE RID: 510
		// (get) Token: 0x060009A8 RID: 2472 RVA: 0x0000E519 File Offset: 0x0000C719
		public int DataSize
		{
			get
			{
				return GetOPFSettingsResult_t._datasize;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x060009A9 RID: 2473 RVA: 0x0000E520 File Offset: 0x0000C720
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GetOPFSettingsResult;
			}
		}

		// Token: 0x04000C37 RID: 3127
		internal Result Result;

		// Token: 0x04000C38 RID: 3128
		internal AppId VideoAppID;

		// Token: 0x04000C39 RID: 3129
		internal static int _datasize = Marshal.SizeOf(typeof(GetOPFSettingsResult_t));
	}
}
