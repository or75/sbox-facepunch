using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000F2 RID: 242
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct CheckFileSignature_t : ICallbackData
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060007DB RID: 2011 RVA: 0x0000CE73 File Offset: 0x0000B073
		public int DataSize
		{
			get
			{
				return CheckFileSignature_t._datasize;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060007DC RID: 2012 RVA: 0x0000CE7A File Offset: 0x0000B07A
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.CheckFileSignature;
			}
		}

		// Token: 0x040009FF RID: 2559
		internal CheckFileSignature CheckFileSignature;

		// Token: 0x04000A00 RID: 2560
		internal static int _datasize = Marshal.SizeOf(typeof(CheckFileSignature_t));
	}
}
