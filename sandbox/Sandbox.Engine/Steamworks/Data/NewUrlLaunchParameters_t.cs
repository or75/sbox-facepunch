using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000136 RID: 310
	internal struct NewUrlLaunchParameters_t : ICallbackData
	{
		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060008B1 RID: 2225 RVA: 0x0000D939 File Offset: 0x0000BB39
		public int DataSize
		{
			get
			{
				return NewUrlLaunchParameters_t._datasize;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x0000D940 File Offset: 0x0000BB40
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.NewUrlLaunchParameters;
			}
		}

		// Token: 0x04000B1C RID: 2844
		internal static int _datasize = Marshal.SizeOf(typeof(NewUrlLaunchParameters_t));
	}
}
