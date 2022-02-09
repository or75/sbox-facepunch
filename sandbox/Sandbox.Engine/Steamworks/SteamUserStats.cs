using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x020000A6 RID: 166
	internal class SteamUserStats : SteamClientClass<SteamUserStats>
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x00009706 File Offset: 0x00007906
		internal static ISteamUserStats Internal
		{
			get
			{
				return SteamClientClass<SteamUserStats>.Interface as ISteamUserStats;
			}
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x00009712 File Offset: 0x00007912
		internal override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamUserStats(server));
			SteamUserStats.InstallEvents();
			SteamUserStats.RequestCurrentStats();
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x0000972C File Offset: 0x0000792C
		// (set) Token: 0x06000641 RID: 1601 RVA: 0x00009733 File Offset: 0x00007933
		internal static bool StatsRecieved { get; set; }

		// Token: 0x06000642 RID: 1602 RVA: 0x0000973C File Offset: 0x0000793C
		internal static void InstallEvents()
		{
			Dispatch.Install<UserStatsReceived_t>(delegate(UserStatsReceived_t x)
			{
				if (x.SteamIDUser == SteamClient.SteamId)
				{
					SteamUserStats.StatsRecieved = true;
				}
				Action<SteamId, Result> onUserStatsReceived = SteamUserStats.OnUserStatsReceived;
				if (onUserStatsReceived == null)
				{
					return;
				}
				onUserStatsReceived(x.SteamIDUser, x.Result);
			}, false);
			Dispatch.Install<UserStatsStored_t>(delegate(UserStatsStored_t x)
			{
				Action<Result> onUserStatsStored = SteamUserStats.OnUserStatsStored;
				if (onUserStatsStored == null)
				{
					return;
				}
				onUserStatsStored(x.Result);
			}, false);
			Dispatch.Install<UserAchievementStored_t>(delegate(UserAchievementStored_t x)
			{
				Action<Achievement, int, int> onAchievementProgress = SteamUserStats.OnAchievementProgress;
				if (onAchievementProgress == null)
				{
					return;
				}
				onAchievementProgress(new Achievement(x.AchievementNameUTF8()), (int)x.CurProgress, (int)x.MaxProgress);
			}, false);
			Dispatch.Install<UserStatsUnloaded_t>(delegate(UserStatsUnloaded_t x)
			{
				Action<SteamId> onUserStatsUnloaded = SteamUserStats.OnUserStatsUnloaded;
				if (onUserStatsUnloaded == null)
				{
					return;
				}
				onUserStatsUnloaded(x.SteamIDUser);
			}, false);
			Dispatch.Install<UserAchievementIconFetched_t>(delegate(UserAchievementIconFetched_t x)
			{
				Action<string, int> onAchievementIconFetched = SteamUserStats.OnAchievementIconFetched;
				if (onAchievementIconFetched == null)
				{
					return;
				}
				onAchievementIconFetched(x.AchievementNameUTF8(), x.IconHandle);
			}, false);
		}

		/// <summary>
		/// called when the achivement icon is loaded
		/// </summary>
		// Token: 0x1400002D RID: 45
		// (add) Token: 0x06000643 RID: 1603 RVA: 0x00009804 File Offset: 0x00007A04
		// (remove) Token: 0x06000644 RID: 1604 RVA: 0x00009838 File Offset: 0x00007A38
		internal static event Action<string, int> OnAchievementIconFetched;

		/// <summary>
		/// called when the latests stats and achievements have been received
		/// from the server
		/// </summary>
		// Token: 0x1400002E RID: 46
		// (add) Token: 0x06000645 RID: 1605 RVA: 0x0000986C File Offset: 0x00007A6C
		// (remove) Token: 0x06000646 RID: 1606 RVA: 0x000098A0 File Offset: 0x00007AA0
		internal static event Action<SteamId, Result> OnUserStatsReceived;

		/// <summary>
		/// result of a request to store the user stats for a game
		/// </summary>
		// Token: 0x1400002F RID: 47
		// (add) Token: 0x06000647 RID: 1607 RVA: 0x000098D4 File Offset: 0x00007AD4
		// (remove) Token: 0x06000648 RID: 1608 RVA: 0x00009908 File Offset: 0x00007B08
		internal static event Action<Result> OnUserStatsStored;

		/// <summary>
		/// result of a request to store the achievements for a game, or an 
		/// "indicate progress" call. If both m_nCurProgress and m_nMaxProgress
		/// are zero, that means the achievement has been fully unlocked
		/// </summary>
		// Token: 0x14000030 RID: 48
		// (add) Token: 0x06000649 RID: 1609 RVA: 0x0000993C File Offset: 0x00007B3C
		// (remove) Token: 0x0600064A RID: 1610 RVA: 0x00009970 File Offset: 0x00007B70
		internal static event Action<Achievement, int, int> OnAchievementProgress;

		/// <summary>
		/// Callback indicating that a user's stats have been unloaded
		/// </summary>
		// Token: 0x14000031 RID: 49
		// (add) Token: 0x0600064B RID: 1611 RVA: 0x000099A4 File Offset: 0x00007BA4
		// (remove) Token: 0x0600064C RID: 1612 RVA: 0x000099D8 File Offset: 0x00007BD8
		internal static event Action<SteamId> OnUserStatsUnloaded;

		/// <summary>
		/// Get the available achievements
		/// </summary>
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x00009A0B File Offset: 0x00007C0B
		internal static IEnumerable<Achievement> Achievements
		{
			get
			{
				int i = 0;
				while ((long)i < (long)((ulong)SteamUserStats.Internal.GetNumAchievements()))
				{
					yield return new Achievement(SteamUserStats.Internal.GetAchievementName((uint)i));
					int num = i;
					i = num + 1;
				}
				yield break;
			}
		}

		/// <summary>
		/// Show the user a pop-up notification with the current progress toward an achievement.
		/// Will return false if RequestCurrentStats has not completed and successfully returned 
		/// its callback, if the achievement doesn't exist/has unpublished changes in the app's 
		/// Steamworks Admin page, or if the achievement is unlocked. 
		/// </summary>
		// Token: 0x0600064E RID: 1614 RVA: 0x00009A14 File Offset: 0x00007C14
		internal static bool IndicateAchievementProgress(string achName, int curProg, int maxProg)
		{
			if (string.IsNullOrEmpty(achName))
			{
				throw new ArgumentNullException("Achievement string is null or empty");
			}
			if (curProg >= maxProg)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(81, 2);
				defaultInterpolatedStringHandler.AppendLiteral(" Current progress [");
				defaultInterpolatedStringHandler.AppendFormatted<int>(curProg);
				defaultInterpolatedStringHandler.AppendLiteral("] arguement toward achievement greater than or equal to max [");
				defaultInterpolatedStringHandler.AppendFormatted<int>(maxProg);
				defaultInterpolatedStringHandler.AppendLiteral("]");
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return SteamUserStats.Internal.IndicateAchievementProgress(achName, (uint)curProg, (uint)maxProg);
		}

		/// <summary>
		/// Tries to get the number of players currently playing this game.
		/// Or -1 if failed.
		/// </summary>
		// Token: 0x0600064F RID: 1615 RVA: 0x00009A90 File Offset: 0x00007C90
		internal static async Task<int> PlayerCountAsync()
		{
			NumberOfCurrentPlayers_t? result = await SteamUserStats.Internal.GetNumberOfCurrentPlayers();
			int result2;
			if (result == null || result.Value.Success == 0)
			{
				result2 = -1;
			}
			else
			{
				result2 = result.Value.CPlayers;
			}
			return result2;
		}

		/// <summary>
		/// Send the changed stats and achievements data to the server for permanent storage.
		/// If this fails then nothing is sent to the server. It's advisable to keep trying until the call is successful.
		/// This call can be rate limited. Call frequency should be on the order of minutes, rather than seconds.You should only be calling this during major state changes such as the end of a round, the map changing, or the user leaving a server. This call is required to display the achievement unlock notification dialog though, so if you have called SetAchievement then it's advisable to call this soon after that.
		/// If you have stats or achievements that you have saved locally but haven't uploaded with this function when your application process ends then this function will automatically be called.
		/// You can find additional debug information written to the %steam_install%\logs\stats_log.txt file.
		/// This function returns true upon success if :
		/// RequestCurrentStats has completed and successfully returned its callback AND
		/// the current game has stats associated with it in the Steamworks Partner backend, and those stats are published.
		/// </summary>
		// Token: 0x06000650 RID: 1616 RVA: 0x00009ACB File Offset: 0x00007CCB
		internal static bool StoreStats()
		{
			return SteamUserStats.Internal.StoreStats();
		}

		/// <summary>
		/// Asynchronously request the user's current stats and achievements from the server.
		/// You must always call this first to get the initial status of stats and achievements.
		/// Only after the resulting callback comes back can you start calling the rest of the stats 
		/// and achievement functions for the current user.
		/// </summary>
		// Token: 0x06000651 RID: 1617 RVA: 0x00009AD7 File Offset: 0x00007CD7
		internal static bool RequestCurrentStats()
		{
			return SteamUserStats.Internal.RequestCurrentStats();
		}

		/// <summary>
		/// Asynchronously fetches global stats data, which is available for stats marked as 
		/// "aggregated" in the App Admin panel of the Steamworks website.
		/// You must have called RequestCurrentStats and it needs to return successfully via 
		/// its callback prior to calling this.
		/// </summary>
		/// <param name="days">How many days of day-by-day history to retrieve in addition to the overall totals. The limit is 60.</param>
		/// <returns>OK indicates success, InvalidState means you need to call RequestCurrentStats first, Fail means the remote call failed</returns>
		// Token: 0x06000652 RID: 1618 RVA: 0x00009AE4 File Offset: 0x00007CE4
		internal static async Task<Result> RequestGlobalStatsAsync(int days)
		{
			GlobalStatsReceived_t? result = await SteamUserStats.Internal.RequestGlobalStats(days);
			Result result2;
			if (result == null)
			{
				result2 = Result.Fail;
			}
			else
			{
				result2 = result.Value.Result;
			}
			return result2;
		}

		/// <summary>
		/// Gets a leaderboard by name, it will create it if it's not yet created.
		/// Leaderboards created with this function will not automatically show up in the Steam Community.
		/// You must manually set the Community Name field in the App Admin panel of the Steamworks website. 
		/// As such it's generally recommended to prefer creating the leaderboards in the App Admin panel on 
		/// the Steamworks website and using FindLeaderboard unless you're expected to have a large amount of
		/// dynamically created leaderboards.
		/// </summary>
		// Token: 0x06000653 RID: 1619 RVA: 0x00009B28 File Offset: 0x00007D28
		internal static async Task<Leaderboard?> FindOrCreateLeaderboardAsync(string name, LeaderboardSort sort, LeaderboardDisplay display)
		{
			LeaderboardFindResult_t? result = await SteamUserStats.Internal.FindOrCreateLeaderboard(name, sort, display);
			Leaderboard? result2;
			if (result == null || result.Value.LeaderboardFound == 0)
			{
				result2 = null;
			}
			else
			{
				result2 = new Leaderboard?(new Leaderboard
				{
					Id = result.Value.SteamLeaderboard
				});
			}
			return result2;
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x00009B7C File Offset: 0x00007D7C
		internal static async Task<Leaderboard?> FindLeaderboardAsync(string name)
		{
			LeaderboardFindResult_t? result = await SteamUserStats.Internal.FindLeaderboard(name);
			Leaderboard? result2;
			if (result == null || result.Value.LeaderboardFound == 0)
			{
				result2 = null;
			}
			else
			{
				result2 = new Leaderboard?(new Leaderboard
				{
					Id = result.Value.SteamLeaderboard
				});
			}
			return result2;
		}

		/// <summary>
		/// Adds this amount to the named stat. Internally this calls Get() and adds 
		/// to that value. Steam doesn't provide a mechanism for atomically increasing
		/// stats like this, this functionality is added here as a convenience.
		/// </summary>
		// Token: 0x06000655 RID: 1621 RVA: 0x00009BC0 File Offset: 0x00007DC0
		internal static bool AddStat(string name, int amount = 1)
		{
			int val = SteamUserStats.GetStatInt(name);
			val += amount;
			return SteamUserStats.SetStat(name, val);
		}

		/// <summary>
		/// Adds this amount to the named stat. Internally this calls Get() and adds 
		/// to that value. Steam doesn't provide a mechanism for atomically increasing
		/// stats like this, this functionality is added here as a convenience.
		/// </summary>
		// Token: 0x06000656 RID: 1622 RVA: 0x00009BE0 File Offset: 0x00007DE0
		internal static bool AddStat(string name, float amount = 1f)
		{
			float val = SteamUserStats.GetStatFloat(name);
			val += amount;
			return SteamUserStats.SetStat(name, val);
		}

		/// <summary>
		/// Set a stat value. This will automatically call StoreStats() after a successful call
		/// unless you pass false as the last argument.
		/// </summary>
		// Token: 0x06000657 RID: 1623 RVA: 0x00009BFF File Offset: 0x00007DFF
		internal static bool SetStat(string name, int value)
		{
			return SteamUserStats.Internal.SetStat(name, value);
		}

		/// <summary>
		/// Set a stat value. This will automatically call StoreStats() after a successful call
		/// unless you pass false as the last argument.
		/// </summary>
		// Token: 0x06000658 RID: 1624 RVA: 0x00009C0D File Offset: 0x00007E0D
		internal static bool SetStat(string name, float value)
		{
			return SteamUserStats.Internal.SetStat(name, value);
		}

		/// <summary>
		/// Get a Int stat value
		/// </summary>
		// Token: 0x06000659 RID: 1625 RVA: 0x00009C1C File Offset: 0x00007E1C
		internal static int GetStatInt(string name)
		{
			int data = 0;
			SteamUserStats.Internal.GetStat(name, ref data);
			return data;
		}

		/// <summary>
		/// Get a float stat value
		/// </summary>
		// Token: 0x0600065A RID: 1626 RVA: 0x00009C3C File Offset: 0x00007E3C
		internal static float GetStatFloat(string name)
		{
			float data = 0f;
			SteamUserStats.Internal.GetStat(name, ref data);
			return data;
		}

		/// <summary>
		/// Practically wipes the slate clean for this user. If includeAchievements is true, will wipe
		/// any achievements too.
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600065B RID: 1627 RVA: 0x00009C5E File Offset: 0x00007E5E
		internal static bool ResetAll(bool includeAchievements)
		{
			return SteamUserStats.Internal.ResetAllStats(includeAchievements);
		}
	}
}
