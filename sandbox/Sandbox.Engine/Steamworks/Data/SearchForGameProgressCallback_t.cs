using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000102 RID: 258
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct SearchForGameProgressCallback_t : ICallbackData
	{
		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600080B RID: 2059 RVA: 0x0000D0B3 File Offset: 0x0000B2B3
		public int DataSize
		{
			get
			{
				return SearchForGameProgressCallback_t._datasize;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600080C RID: 2060 RVA: 0x0000D0BA File Offset: 0x0000B2BA
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SearchForGameProgressCallback;
			}
		}

		// Token: 0x04000A38 RID: 2616
		internal ulong LSearchID;

		// Token: 0x04000A39 RID: 2617
		internal Result Result;

		// Token: 0x04000A3A RID: 2618
		internal ulong LobbyID;

		// Token: 0x04000A3B RID: 2619
		internal ulong SteamIDEndedSearch;

		// Token: 0x04000A3C RID: 2620
		internal int SecondsRemainingEstimate;

		// Token: 0x04000A3D RID: 2621
		internal int CPlayersSearching;

		// Token: 0x04000A3E RID: 2622
		internal static int _datasize = Marshal.SizeOf(typeof(SearchForGameProgressCallback_t));
	}
}
