using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000193 RID: 403
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GSGameplayStats_t : ICallbackData
	{
		// Token: 0x17000216 RID: 534
		// (get) Token: 0x060009D0 RID: 2512 RVA: 0x0000E742 File Offset: 0x0000C942
		public int DataSize
		{
			get
			{
				return GSGameplayStats_t._datasize;
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x060009D1 RID: 2513 RVA: 0x0000E749 File Offset: 0x0000C949
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GSGameplayStats;
			}
		}

		// Token: 0x04000C5A RID: 3162
		internal Result Result;

		// Token: 0x04000C5B RID: 3163
		internal int Rank;

		// Token: 0x04000C5C RID: 3164
		internal uint TotalConnects;

		// Token: 0x04000C5D RID: 3165
		internal uint TotalMinutesPlayed;

		// Token: 0x04000C5E RID: 3166
		internal static int _datasize = Marshal.SizeOf(typeof(GSGameplayStats_t));
	}
}
