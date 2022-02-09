using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000104 RID: 260
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RequestPlayersForGameProgressCallback_t : ICallbackData
	{
		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000811 RID: 2065 RVA: 0x0000D0FB File Offset: 0x0000B2FB
		public int DataSize
		{
			get
			{
				return RequestPlayersForGameProgressCallback_t._datasize;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000812 RID: 2066 RVA: 0x0000D102 File Offset: 0x0000B302
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RequestPlayersForGameProgressCallback;
			}
		}

		// Token: 0x04000A46 RID: 2630
		internal Result Result;

		// Token: 0x04000A47 RID: 2631
		internal ulong LSearchID;

		// Token: 0x04000A48 RID: 2632
		internal static int _datasize = Marshal.SizeOf(typeof(RequestPlayersForGameProgressCallback_t));
	}
}
