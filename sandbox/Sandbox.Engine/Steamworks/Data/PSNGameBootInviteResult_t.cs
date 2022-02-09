using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000100 RID: 256
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct PSNGameBootInviteResult_t : ICallbackData
	{
		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000805 RID: 2053 RVA: 0x0000D06B File Offset: 0x0000B26B
		public int DataSize
		{
			get
			{
				return PSNGameBootInviteResult_t._datasize;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000806 RID: 2054 RVA: 0x0000D072 File Offset: 0x0000B272
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.PSNGameBootInviteResult;
			}
		}

		// Token: 0x04000A33 RID: 2611
		[MarshalAs(UnmanagedType.I1)]
		internal bool GameBootInviteExists;

		// Token: 0x04000A34 RID: 2612
		internal ulong SteamIDLobby;

		// Token: 0x04000A35 RID: 2613
		internal static int _datasize = Marshal.SizeOf(typeof(PSNGameBootInviteResult_t));
	}
}
