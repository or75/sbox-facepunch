using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x02000130 RID: 304
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct UserAchievementIconFetched_t : ICallbackData
	{
		// Token: 0x0600089E RID: 2206 RVA: 0x0000D842 File Offset: 0x0000BA42
		internal string AchievementNameUTF8()
		{
			return Encoding.UTF8.GetString(this.AchievementName, 0, Array.IndexOf<byte>(this.AchievementName, 0));
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x0600089F RID: 2207 RVA: 0x0000D861 File Offset: 0x0000BA61
		public int DataSize
		{
			get
			{
				return UserAchievementIconFetched_t._datasize;
			}
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060008A0 RID: 2208 RVA: 0x0000D868 File Offset: 0x0000BA68
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.UserAchievementIconFetched;
			}
		}

		// Token: 0x04000B09 RID: 2825
		internal GameId GameID;

		// Token: 0x04000B0A RID: 2826
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		internal byte[] AchievementName;

		// Token: 0x04000B0B RID: 2827
		[MarshalAs(UnmanagedType.I1)]
		internal bool Achieved;

		// Token: 0x04000B0C RID: 2828
		internal int IconHandle;

		// Token: 0x04000B0D RID: 2829
		internal static int _datasize = Marshal.SizeOf(typeof(UserAchievementIconFetched_t));
	}
}
