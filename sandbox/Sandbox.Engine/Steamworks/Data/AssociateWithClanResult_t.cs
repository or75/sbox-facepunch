using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000196 RID: 406
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct AssociateWithClanResult_t : ICallbackData
	{
		// Token: 0x1700021C RID: 540
		// (get) Token: 0x060009D9 RID: 2521 RVA: 0x0000E7AE File Offset: 0x0000C9AE
		public int DataSize
		{
			get
			{
				return AssociateWithClanResult_t._datasize;
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x060009DA RID: 2522 RVA: 0x0000E7B5 File Offset: 0x0000C9B5
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.AssociateWithClanResult;
			}
		}

		// Token: 0x04000C6C RID: 3180
		internal Result Result;

		// Token: 0x04000C6D RID: 3181
		internal static int _datasize = Marshal.SizeOf(typeof(AssociateWithClanResult_t));
	}
}
