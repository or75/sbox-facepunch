using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000197 RID: 407
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct ComputeNewPlayerCompatibilityResult_t : ICallbackData
	{
		// Token: 0x1700021E RID: 542
		// (get) Token: 0x060009DC RID: 2524 RVA: 0x0000E7D2 File Offset: 0x0000C9D2
		public int DataSize
		{
			get
			{
				return ComputeNewPlayerCompatibilityResult_t._datasize;
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x060009DD RID: 2525 RVA: 0x0000E7D9 File Offset: 0x0000C9D9
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.ComputeNewPlayerCompatibilityResult;
			}
		}

		// Token: 0x04000C6E RID: 3182
		internal Result Result;

		// Token: 0x04000C6F RID: 3183
		internal int CPlayersThatDontLikeCandidate;

		// Token: 0x04000C70 RID: 3184
		internal int CPlayersThatCandidateDoesntLike;

		// Token: 0x04000C71 RID: 3185
		internal int CClanPlayersThatDontLikeCandidate;

		// Token: 0x04000C72 RID: 3186
		internal ulong SteamIDCandidate;

		// Token: 0x04000C73 RID: 3187
		internal static int _datasize = Marshal.SizeOf(typeof(ComputeNewPlayerCompatibilityResult_t));
	}
}
