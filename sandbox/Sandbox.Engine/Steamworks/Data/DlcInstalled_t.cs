using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000134 RID: 308
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct DlcInstalled_t : ICallbackData
	{
		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060008AB RID: 2219 RVA: 0x0000D8F1 File Offset: 0x0000BAF1
		public int DataSize
		{
			get
			{
				return DlcInstalled_t._datasize;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060008AC RID: 2220 RVA: 0x0000D8F8 File Offset: 0x0000BAF8
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.DlcInstalled;
			}
		}

		// Token: 0x04000B17 RID: 2839
		internal AppId AppID;

		// Token: 0x04000B18 RID: 2840
		internal static int _datasize = Marshal.SizeOf(typeof(DlcInstalled_t));
	}
}
