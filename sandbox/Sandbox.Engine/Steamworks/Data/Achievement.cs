using System;
using System.Threading.Tasks;

namespace Steamworks.Data
{
	// Token: 0x020001D9 RID: 473
	internal struct Achievement
	{
		// Token: 0x06000BAE RID: 2990 RVA: 0x00010460 File Offset: 0x0000E660
		internal Achievement(string name)
		{
			this.Value = name;
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x00010469 File Offset: 0x0000E669
		public override string ToString()
		{
			return this.Value;
		}

		/// <summary>
		/// True if unlocked
		/// </summary>
		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000BB0 RID: 2992 RVA: 0x00010474 File Offset: 0x0000E674
		internal bool State
		{
			get
			{
				bool state = false;
				SteamUserStats.Internal.GetAchievement(this.Value, ref state);
				return state;
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000BB1 RID: 2993 RVA: 0x00010497 File Offset: 0x0000E697
		internal string Identifier
		{
			get
			{
				return this.Value;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000BB2 RID: 2994 RVA: 0x0001049F File Offset: 0x0000E69F
		internal string Name
		{
			get
			{
				return SteamUserStats.Internal.GetAchievementDisplayAttribute(this.Value, "name");
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000BB3 RID: 2995 RVA: 0x000104B6 File Offset: 0x0000E6B6
		internal string Description
		{
			get
			{
				return SteamUserStats.Internal.GetAchievementDisplayAttribute(this.Value, "desc");
			}
		}

		/// <summary>
		/// Should hold the unlock time if State is true
		/// </summary>
		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000BB4 RID: 2996 RVA: 0x000104D0 File Offset: 0x0000E6D0
		internal DateTime? UnlockTime
		{
			get
			{
				bool state = false;
				uint time = 0U;
				if (!SteamUserStats.Internal.GetAchievementAndUnlockTime(this.Value, ref state, ref time) || !state)
				{
					return null;
				}
				return new DateTime?(Epoch.ToDateTime(time));
			}
		}

		/// <summary>
		/// Gets the icon of the achievement. This can return a null image even though the image exists if the image
		/// hasn't been downloaded by Steam yet. You can use GetIconAsync if you want to wait for the image to be downloaded.
		/// </summary>
		// Token: 0x06000BB5 RID: 2997 RVA: 0x00010514 File Offset: 0x0000E714
		internal Image? GetIcon()
		{
			return SteamUtils.GetImage(SteamUserStats.Internal.GetAchievementIcon(this.Value));
		}

		/// <summary>
		/// Gets the icon of the achievement, waits for it to load if we have to
		/// </summary>
		// Token: 0x06000BB6 RID: 2998 RVA: 0x0001052C File Offset: 0x0000E72C
		internal async Task<Image?> GetIconAsync(int timeout = 5000)
		{
			Achievement.<>c__DisplayClass14_0 CS$<>8__locals1 = new Achievement.<>c__DisplayClass14_0();
			CS$<>8__locals1.i = SteamUserStats.Internal.GetAchievementIcon(this.Value);
			Image? result;
			if (CS$<>8__locals1.i != 0)
			{
				result = SteamUtils.GetImage(CS$<>8__locals1.i);
			}
			else
			{
				CS$<>8__locals1.ident = this.Identifier;
				CS$<>8__locals1.gotCallback = false;
				try
				{
					SteamUserStats.OnAchievementIconFetched += CS$<>8__locals1.<GetIconAsync>g__f|0;
					int waited = 0;
					while (!CS$<>8__locals1.gotCallback)
					{
						await Task.Delay(10);
						waited += 10;
						if (waited > timeout)
						{
							return null;
						}
					}
					if (CS$<>8__locals1.i == 0)
					{
						result = null;
					}
					else
					{
						result = SteamUtils.GetImage(CS$<>8__locals1.i);
					}
				}
				finally
				{
					SteamUserStats.OnAchievementIconFetched -= CS$<>8__locals1.<GetIconAsync>g__f|0;
				}
			}
			return result;
		}

		/// <summary>
		/// Returns the fraction (0-1) of users who have unlocked the specified achievement, or -1 if no data available.
		/// </summary>
		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000BB7 RID: 2999 RVA: 0x0001057C File Offset: 0x0000E77C
		internal float GlobalUnlocked
		{
			get
			{
				float pct = 0f;
				if (!SteamUserStats.Internal.GetAchievementAchievedPercent(this.Value, ref pct))
				{
					return -1f;
				}
				return pct / 100f;
			}
		}

		/// <summary>
		/// Make this achievement earned
		/// </summary>
		// Token: 0x06000BB8 RID: 3000 RVA: 0x000105B0 File Offset: 0x0000E7B0
		internal bool Trigger(bool apply = true)
		{
			bool r = SteamUserStats.Internal.SetAchievement(this.Value);
			if (apply && r)
			{
				SteamUserStats.Internal.StoreStats();
			}
			return r;
		}

		/// <summary>
		/// Reset this achievement to not achieved
		/// </summary>
		// Token: 0x06000BB9 RID: 3001 RVA: 0x000105DF File Offset: 0x0000E7DF
		internal bool Clear()
		{
			return SteamUserStats.Internal.ClearAchievement(this.Value);
		}

		// Token: 0x04000D61 RID: 3425
		internal string Value;
	}
}
