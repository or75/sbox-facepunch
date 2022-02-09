using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000E0 RID: 224
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct FriendRichPresenceUpdate_t : ICallbackData
	{
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x0000CBAD File Offset: 0x0000ADAD
		public int DataSize
		{
			get
			{
				return FriendRichPresenceUpdate_t._datasize;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060007A4 RID: 1956 RVA: 0x0000CBB4 File Offset: 0x0000ADB4
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.FriendRichPresenceUpdate;
			}
		}

		// Token: 0x040009C9 RID: 2505
		internal ulong SteamIDFriend;

		// Token: 0x040009CA RID: 2506
		internal AppId AppID;

		// Token: 0x040009CB RID: 2507
		internal static int _datasize = Marshal.SizeOf(typeof(FriendRichPresenceUpdate_t));
	}
}
