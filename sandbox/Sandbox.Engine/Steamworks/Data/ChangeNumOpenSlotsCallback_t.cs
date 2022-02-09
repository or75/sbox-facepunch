using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200010C RID: 268
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct ChangeNumOpenSlotsCallback_t : ICallbackData
	{
		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600082A RID: 2090 RVA: 0x0000D23A File Offset: 0x0000B43A
		public int DataSize
		{
			get
			{
				return ChangeNumOpenSlotsCallback_t._datasize;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600082B RID: 2091 RVA: 0x0000D241 File Offset: 0x0000B441
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.ChangeNumOpenSlotsCallback;
			}
		}

		// Token: 0x04000A6A RID: 2666
		internal Result Result;

		// Token: 0x04000A6B RID: 2667
		internal static int _datasize = Marshal.SizeOf(typeof(ChangeNumOpenSlotsCallback_t));
	}
}
