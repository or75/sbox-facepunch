using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x02000191 RID: 401
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GSClientAchievementStatus_t : ICallbackData
	{
		// Token: 0x060009C9 RID: 2505 RVA: 0x0000E6DE File Offset: 0x0000C8DE
		internal string PchAchievementUTF8()
		{
			return Encoding.UTF8.GetString(this.PchAchievement, 0, Array.IndexOf<byte>(this.PchAchievement, 0));
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x060009CA RID: 2506 RVA: 0x0000E6FD File Offset: 0x0000C8FD
		public int DataSize
		{
			get
			{
				return GSClientAchievementStatus_t._datasize;
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x060009CB RID: 2507 RVA: 0x0000E704 File Offset: 0x0000C904
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GSClientAchievementStatus;
			}
		}

		// Token: 0x04000C54 RID: 3156
		internal ulong SteamID;

		// Token: 0x04000C55 RID: 3157
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		internal byte[] PchAchievement;

		// Token: 0x04000C56 RID: 3158
		[MarshalAs(UnmanagedType.I1)]
		internal bool Unlocked;

		// Token: 0x04000C57 RID: 3159
		internal static int _datasize = Marshal.SizeOf(typeof(GSClientAchievementStatus_t));
	}
}
