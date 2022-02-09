using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000107 RID: 263
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct SubmitPlayerResultResultCallback_t : ICallbackData
	{
		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600081A RID: 2074 RVA: 0x0000D167 File Offset: 0x0000B367
		public int DataSize
		{
			get
			{
				return SubmitPlayerResultResultCallback_t._datasize;
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600081B RID: 2075 RVA: 0x0000D16E File Offset: 0x0000B36E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SubmitPlayerResultResultCallback;
			}
		}

		// Token: 0x04000A58 RID: 2648
		internal Result Result;

		// Token: 0x04000A59 RID: 2649
		internal ulong UllUniqueGameID;

		// Token: 0x04000A5A RID: 2650
		internal ulong SteamIDPlayer;

		// Token: 0x04000A5B RID: 2651
		internal static int _datasize = Marshal.SizeOf(typeof(SubmitPlayerResultResultCallback_t));
	}
}
