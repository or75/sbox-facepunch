using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000195 RID: 405
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GSReputation_t : ICallbackData
	{
		// Token: 0x1700021A RID: 538
		// (get) Token: 0x060009D6 RID: 2518 RVA: 0x0000E78A File Offset: 0x0000C98A
		public int DataSize
		{
			get
			{
				return GSReputation_t._datasize;
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x060009D7 RID: 2519 RVA: 0x0000E791 File Offset: 0x0000C991
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GSReputation;
			}
		}

		// Token: 0x04000C64 RID: 3172
		internal Result Result;

		// Token: 0x04000C65 RID: 3173
		internal uint ReputationScore;

		// Token: 0x04000C66 RID: 3174
		[MarshalAs(UnmanagedType.I1)]
		internal bool Banned;

		// Token: 0x04000C67 RID: 3175
		internal uint BannedIP;

		// Token: 0x04000C68 RID: 3176
		internal ushort BannedPort;

		// Token: 0x04000C69 RID: 3177
		internal ulong BannedGameID;

		// Token: 0x04000C6A RID: 3178
		internal uint BanExpires;

		// Token: 0x04000C6B RID: 3179
		internal static int _datasize = Marshal.SizeOf(typeof(GSReputation_t));
	}
}
