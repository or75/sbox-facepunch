using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000103 RID: 259
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct SearchForGameResultCallback_t : ICallbackData
	{
		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600080E RID: 2062 RVA: 0x0000D0D7 File Offset: 0x0000B2D7
		public int DataSize
		{
			get
			{
				return SearchForGameResultCallback_t._datasize;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600080F RID: 2063 RVA: 0x0000D0DE File Offset: 0x0000B2DE
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SearchForGameResultCallback;
			}
		}

		// Token: 0x04000A3F RID: 2623
		internal ulong LSearchID;

		// Token: 0x04000A40 RID: 2624
		internal Result Result;

		// Token: 0x04000A41 RID: 2625
		internal int CountPlayersInGame;

		// Token: 0x04000A42 RID: 2626
		internal int CountAcceptedGame;

		// Token: 0x04000A43 RID: 2627
		internal ulong SteamIDHost;

		// Token: 0x04000A44 RID: 2628
		[MarshalAs(UnmanagedType.I1)]
		internal bool FinalCallback;

		// Token: 0x04000A45 RID: 2629
		internal static int _datasize = Marshal.SizeOf(typeof(SearchForGameResultCallback_t));
	}
}
