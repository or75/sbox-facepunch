using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x0200012A RID: 298
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct UserAchievementStored_t : ICallbackData
	{
		// Token: 0x0600088B RID: 2187 RVA: 0x0000D74B File Offset: 0x0000B94B
		internal string AchievementNameUTF8()
		{
			return Encoding.UTF8.GetString(this.AchievementName, 0, Array.IndexOf<byte>(this.AchievementName, 0));
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x0600088C RID: 2188 RVA: 0x0000D76A File Offset: 0x0000B96A
		public int DataSize
		{
			get
			{
				return UserAchievementStored_t._datasize;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x0600088D RID: 2189 RVA: 0x0000D771 File Offset: 0x0000B971
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.UserAchievementStored;
			}
		}

		// Token: 0x04000AF0 RID: 2800
		internal ulong GameID;

		// Token: 0x04000AF1 RID: 2801
		[MarshalAs(UnmanagedType.I1)]
		internal bool GroupAchievement;

		// Token: 0x04000AF2 RID: 2802
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		internal byte[] AchievementName;

		// Token: 0x04000AF3 RID: 2803
		internal uint CurProgress;

		// Token: 0x04000AF4 RID: 2804
		internal uint MaxProgress;

		// Token: 0x04000AF5 RID: 2805
		internal static int _datasize = Marshal.SizeOf(typeof(UserAchievementStored_t));
	}
}
