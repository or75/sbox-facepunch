using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x020000E1 RID: 225
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GameRichPresenceJoinRequested_t : ICallbackData
	{
		// Token: 0x060007A6 RID: 1958 RVA: 0x0000CBD1 File Offset: 0x0000ADD1
		internal string ConnectUTF8()
		{
			return Encoding.UTF8.GetString(this.Connect, 0, Array.IndexOf<byte>(this.Connect, 0));
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060007A7 RID: 1959 RVA: 0x0000CBF0 File Offset: 0x0000ADF0
		public int DataSize
		{
			get
			{
				return GameRichPresenceJoinRequested_t._datasize;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060007A8 RID: 1960 RVA: 0x0000CBF7 File Offset: 0x0000ADF7
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GameRichPresenceJoinRequested;
			}
		}

		// Token: 0x040009CC RID: 2508
		internal ulong SteamIDFriend;

		// Token: 0x040009CD RID: 2509
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal byte[] Connect;

		// Token: 0x040009CE RID: 2510
		internal static int _datasize = Marshal.SizeOf(typeof(GameRichPresenceJoinRequested_t));
	}
}
