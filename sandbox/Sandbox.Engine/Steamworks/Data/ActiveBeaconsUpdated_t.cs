using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200010E RID: 270
	internal struct ActiveBeaconsUpdated_t : ICallbackData
	{
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000830 RID: 2096 RVA: 0x0000D282 File Offset: 0x0000B482
		public int DataSize
		{
			get
			{
				return ActiveBeaconsUpdated_t._datasize;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000831 RID: 2097 RVA: 0x0000D289 File Offset: 0x0000B489
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.ActiveBeaconsUpdated;
			}
		}

		// Token: 0x04000A6D RID: 2669
		internal static int _datasize = Marshal.SizeOf(typeof(ActiveBeaconsUpdated_t));
	}
}
