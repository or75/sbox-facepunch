using System;
using System.Threading.Tasks;

namespace Steamworks.Data
{
	// Token: 0x020001E3 RID: 483
	internal struct Leaderboard
	{
		/// <summary>
		/// the name of a leaderboard
		/// </summary>
		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000BCD RID: 3021 RVA: 0x000107FF File Offset: 0x0000E9FF
		internal string Name
		{
			get
			{
				return SteamUserStats.Internal.GetLeaderboardName(this.Id);
			}
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000BCE RID: 3022 RVA: 0x00010811 File Offset: 0x0000EA11
		internal LeaderboardSort Sort
		{
			get
			{
				return SteamUserStats.Internal.GetLeaderboardSortMethod(this.Id);
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000BCF RID: 3023 RVA: 0x00010823 File Offset: 0x0000EA23
		internal LeaderboardDisplay Display
		{
			get
			{
				return SteamUserStats.Internal.GetLeaderboardDisplayType(this.Id);
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x00010835 File Offset: 0x0000EA35
		internal int EntryCount
		{
			get
			{
				return SteamUserStats.Internal.GetLeaderboardEntryCount(this.Id);
			}
		}

		/// <summary>
		/// Submit your score and replace your old score even if it was better
		/// </summary>
		// Token: 0x06000BD1 RID: 3025 RVA: 0x00010848 File Offset: 0x0000EA48
		internal async Task<LeaderboardUpdate?> ReplaceScore(int score, int[] details = null)
		{
			if (details == null)
			{
				details = Leaderboard.noDetails;
			}
			LeaderboardScoreUploaded_t? r = await SteamUserStats.Internal.UploadLeaderboardScore(this.Id, LeaderboardUploadScoreMethod.ForceUpdate, score, details, details.Length);
			LeaderboardUpdate? result;
			if (r == null)
			{
				result = null;
			}
			else
			{
				result = new LeaderboardUpdate?(LeaderboardUpdate.From(r.Value));
			}
			return result;
		}

		/// <summary>
		/// Submit your new score, but won't replace your high score if it's lower
		/// </summary>
		// Token: 0x06000BD2 RID: 3026 RVA: 0x000108A0 File Offset: 0x0000EAA0
		internal async Task<LeaderboardUpdate?> SubmitScoreAsync(int score, int[] details = null)
		{
			if (details == null)
			{
				details = Leaderboard.noDetails;
			}
			LeaderboardScoreUploaded_t? r = await SteamUserStats.Internal.UploadLeaderboardScore(this.Id, LeaderboardUploadScoreMethod.KeepBest, score, details, details.Length);
			LeaderboardUpdate? result;
			if (r == null)
			{
				result = null;
			}
			else
			{
				result = new LeaderboardUpdate?(LeaderboardUpdate.From(r.Value));
			}
			return result;
		}

		/// <summary>
		/// Fetches leaderboard entries for an arbitrary set of users on a specified leaderboard.
		/// </summary>
		// Token: 0x06000BD3 RID: 3027 RVA: 0x000108F8 File Offset: 0x0000EAF8
		internal async Task<LeaderboardEntry[]> GetScoresForUsersAsync(SteamId[] users)
		{
			LeaderboardEntry[] result;
			if (users == null || users.Length == 0)
			{
				result = null;
			}
			else
			{
				LeaderboardScoresDownloaded_t? r = await SteamUserStats.Internal.DownloadLeaderboardEntriesForUsers(this.Id, users, users.Length);
				if (r == null)
				{
					result = null;
				}
				else
				{
					result = await this.LeaderboardResultToEntries(r.Value);
				}
			}
			return result;
		}

		/// <summary>
		/// Used to query for a sequential range of leaderboard entries by leaderboard Sort.
		/// </summary>
		// Token: 0x06000BD4 RID: 3028 RVA: 0x00010948 File Offset: 0x0000EB48
		internal async Task<LeaderboardEntry[]> GetScoresAsync(int count, int offset = 1)
		{
			if (offset <= 0)
			{
				throw new ArgumentException("Should be 1+", "offset");
			}
			LeaderboardScoresDownloaded_t? r = await SteamUserStats.Internal.DownloadLeaderboardEntries(this.Id, LeaderboardDataRequest.Global, offset, offset + count - 1);
			LeaderboardEntry[] result;
			if (r == null)
			{
				result = null;
			}
			else
			{
				result = await this.LeaderboardResultToEntries(r.Value);
			}
			return result;
		}

		/// <summary>
		/// Used to retrieve leaderboard entries relative a user's entry. If there are not enough entries in the leaderboard 
		/// before or after the user's entry, Steam will adjust the range to try to return the number of entries requested.
		/// For example, if the user is #1 on the leaderboard and start is set to -2, end is set to 2, Steam will return the first 
		/// 5 entries in the leaderboard. If The current user has no entry, this will return null.
		/// </summary>
		// Token: 0x06000BD5 RID: 3029 RVA: 0x000109A0 File Offset: 0x0000EBA0
		internal async Task<LeaderboardEntry[]> GetScoresAroundUserAsync(int start = -10, int end = 10)
		{
			LeaderboardScoresDownloaded_t? r = await SteamUserStats.Internal.DownloadLeaderboardEntries(this.Id, LeaderboardDataRequest.GlobalAroundUser, start, end);
			LeaderboardEntry[] result;
			if (r == null)
			{
				result = null;
			}
			else
			{
				result = await this.LeaderboardResultToEntries(r.Value);
			}
			return result;
		}

		/// <summary>
		/// Used to retrieve all leaderboard entries for friends of the current user
		/// </summary>
		// Token: 0x06000BD6 RID: 3030 RVA: 0x000109F8 File Offset: 0x0000EBF8
		internal async Task<LeaderboardEntry[]> GetScoresFromFriendsAsync()
		{
			LeaderboardScoresDownloaded_t? r = await SteamUserStats.Internal.DownloadLeaderboardEntries(this.Id, LeaderboardDataRequest.Friends, 0, 0);
			LeaderboardEntry[] result;
			if (r == null)
			{
				result = null;
			}
			else
			{
				result = await this.LeaderboardResultToEntries(r.Value);
			}
			return result;
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x00010A40 File Offset: 0x0000EC40
		internal async Task<LeaderboardEntry[]> LeaderboardResultToEntries(LeaderboardScoresDownloaded_t r)
		{
			LeaderboardEntry[] result;
			if (r.CEntryCount <= 0)
			{
				result = null;
			}
			else
			{
				LeaderboardEntry[] output = new LeaderboardEntry[r.CEntryCount];
				LeaderboardEntry_t e = default(LeaderboardEntry_t);
				for (int i = 0; i < output.Length; i++)
				{
					if (SteamUserStats.Internal.GetDownloadedLeaderboardEntry(r.SteamLeaderboardEntries, i, ref e, Leaderboard.detailsBuffer, Leaderboard.detailsBuffer.Length))
					{
						output[i] = LeaderboardEntry.From(e, Leaderboard.detailsBuffer);
					}
				}
				await Leaderboard.WaitForUserNames(output);
				result = output;
			}
			return result;
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x00010A90 File Offset: 0x0000EC90
		internal static async Task WaitForUserNames(LeaderboardEntry[] entries)
		{
			bool gotAll = false;
			while (!gotAll)
			{
				gotAll = true;
				foreach (LeaderboardEntry entry in entries)
				{
					if (entry.User.Id != 0UL && SteamFriends.Internal.RequestUserInformation(entry.User.Id, true))
					{
						gotAll = false;
					}
				}
				await Task.Delay(1);
			}
		}

		// Token: 0x04000D78 RID: 3448
		internal SteamLeaderboard_t Id;

		// Token: 0x04000D79 RID: 3449
		private static int[] detailsBuffer = new int[64];

		// Token: 0x04000D7A RID: 3450
		private static int[] noDetails = Array.Empty<int>();
	}
}
