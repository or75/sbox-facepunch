using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x020000AD RID: 173
	internal struct Friend
	{
		// Token: 0x06000698 RID: 1688 RVA: 0x0000A2F2 File Offset: 0x000084F2
		public Friend(SteamId steamid)
		{
			this.Id = steamid;
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0000A2FC File Offset: 0x000084FC
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
			defaultInterpolatedStringHandler.AppendFormatted(this.Name);
			defaultInterpolatedStringHandler.AppendLiteral(" (");
			defaultInterpolatedStringHandler.AppendFormatted<SteamId>(this.Id);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		/// <summary>
		/// Returns true if this is the local user
		/// </summary>
		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600069A RID: 1690 RVA: 0x0000A34B File Offset: 0x0000854B
		public bool IsMe
		{
			get
			{
				return this.Id == SteamClient.SteamId;
			}
		}

		/// <summary>
		/// Return true if this is a friend
		/// </summary>
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600069B RID: 1691 RVA: 0x0000A364 File Offset: 0x00008564
		public bool IsFriend
		{
			get
			{
				return this.Relationship == Relationship.Friend;
			}
		}

		/// <summary>
		/// Returns true if you have this user blocked
		/// </summary>
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600069C RID: 1692 RVA: 0x0000A36F File Offset: 0x0000856F
		public bool IsBlocked
		{
			get
			{
				return this.Relationship == Relationship.Blocked;
			}
		}

		/// <summary>
		/// Return true if this user is playing the game we're running
		/// </summary>
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x0000A37C File Offset: 0x0000857C
		public bool IsPlayingThisGame
		{
			get
			{
				Friend.FriendGameInfo? friendGameInfo;
				ulong? num = ((this.GameInfo != null) ? new ulong?(friendGameInfo.GetValueOrDefault().GameID) : null);
				ulong num2 = (ulong)SteamClient.AppId;
				return (num.GetValueOrDefault() == num2) & (num != null);
			}
		}

		/// <summary>
		/// Return true if this user is playing another game
		/// </summary>
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600069E RID: 1694 RVA: 0x0000A3D4 File Offset: 0x000085D4
		public bool IsPlaying
		{
			get
			{
				Friend.FriendGameInfo? friendGameInfo;
				return this.GameInfo != null && friendGameInfo.GetValueOrDefault().GameID > 0UL;
			}
		}

		/// <summary>
		/// Returns true if this friend is online
		/// </summary>
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600069F RID: 1695 RVA: 0x0000A403 File Offset: 0x00008603
		public bool IsOnline
		{
			get
			{
				return this.State > FriendState.Offline;
			}
		}

		/// <summary>
		/// Sometimes we don't know the user's name. This will wait until we have
		/// downloaded the information on this user.
		/// </summary>
		// Token: 0x060006A0 RID: 1696 RVA: 0x0000A410 File Offset: 0x00008610
		public async Task RequestInfoAsync()
		{
			await SteamFriends.CacheUserInformationAsync(this.Id, true);
		}

		/// <summary>
		/// Returns true if this friend is marked as away
		/// </summary>
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060006A1 RID: 1697 RVA: 0x0000A458 File Offset: 0x00008658
		public bool IsAway
		{
			get
			{
				return this.State == FriendState.Away;
			}
		}

		/// <summary>
		/// Returns true if this friend is marked as busy
		/// </summary>
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060006A2 RID: 1698 RVA: 0x0000A463 File Offset: 0x00008663
		public bool IsBusy
		{
			get
			{
				return this.State == FriendState.Busy;
			}
		}

		/// <summary>
		/// Returns true if this friend is marked as snoozing
		/// </summary>
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060006A3 RID: 1699 RVA: 0x0000A46E File Offset: 0x0000866E
		public bool IsSnoozing
		{
			get
			{
				return this.State == FriendState.Snooze;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060006A4 RID: 1700 RVA: 0x0000A479 File Offset: 0x00008679
		public Relationship Relationship
		{
			get
			{
				return SteamFriends.Internal.GetFriendRelationship(this.Id);
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060006A5 RID: 1701 RVA: 0x0000A48B File Offset: 0x0000868B
		public FriendState State
		{
			get
			{
				return SteamFriends.Internal.GetFriendPersonaState(this.Id);
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060006A6 RID: 1702 RVA: 0x0000A49D File Offset: 0x0000869D
		public string Name
		{
			get
			{
				return SteamFriends.Internal.GetFriendPersonaName(this.Id);
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x0000A4AF File Offset: 0x000086AF
		public IEnumerable<string> NameHistory
		{
			get
			{
				int num;
				for (int i = 0; i < 32; i = num + 1)
				{
					string j = SteamFriends.Internal.GetFriendPersonaNameHistory(this.Id, i);
					if (string.IsNullOrEmpty(j))
					{
						break;
					}
					yield return j;
					num = i;
				}
				yield break;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060006A8 RID: 1704 RVA: 0x0000A4C4 File Offset: 0x000086C4
		public int SteamLevel
		{
			get
			{
				return SteamFriends.Internal.GetFriendSteamLevel(this.Id);
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x0000A4D8 File Offset: 0x000086D8
		public Friend.FriendGameInfo? GameInfo
		{
			get
			{
				FriendGameInfo_t gameInfo = default(FriendGameInfo_t);
				if (!SteamFriends.Internal.GetFriendGamePlayed(this.Id, ref gameInfo))
				{
					return null;
				}
				return new Friend.FriendGameInfo?(Friend.FriendGameInfo.From(gameInfo));
			}
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x0000A516 File Offset: 0x00008716
		public bool IsIn(SteamId group_or_room)
		{
			return SteamFriends.Internal.IsUserInSource(this.Id, group_or_room);
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x0000A52C File Offset: 0x0000872C
		internal async Task<Image?> GetSmallAvatarAsync()
		{
			return await SteamFriends.GetSmallAvatarAsync(this.Id);
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x0000A574 File Offset: 0x00008774
		internal async Task<Image?> GetMediumAvatarAsync()
		{
			return await SteamFriends.GetMediumAvatarAsync(this.Id);
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x0000A5BC File Offset: 0x000087BC
		internal async Task<Image?> GetLargeAvatarAsync()
		{
			return await SteamFriends.GetLargeAvatarAsync(this.Id);
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x0000A604 File Offset: 0x00008804
		public string GetRichPresence(string key)
		{
			string val = SteamFriends.Internal.GetFriendRichPresence(this.Id, key);
			if (string.IsNullOrEmpty(val))
			{
				return null;
			}
			return val;
		}

		/// <summary>
		/// Invite this friend to the game that we are playing
		/// </summary>
		// Token: 0x060006AF RID: 1711 RVA: 0x0000A62E File Offset: 0x0000882E
		internal bool InviteToGame(string Text)
		{
			return SteamFriends.Internal.InviteUserToGame(this.Id, Text);
		}

		/// <summary>
		/// Sends a message to a Steam friend. Returns true if success
		/// </summary>
		// Token: 0x060006B0 RID: 1712 RVA: 0x0000A641 File Offset: 0x00008841
		internal bool SendMessage(string message)
		{
			return SteamFriends.Internal.ReplyToFriendMessage(this.Id, message);
		}

		/// <summary>
		/// Tries to get download the latest user stats
		/// </summary>
		/// <returns>True if successful, False if failure</returns>
		// Token: 0x060006B1 RID: 1713 RVA: 0x0000A654 File Offset: 0x00008854
		internal async Task<bool> RequestUserStatsAsync()
		{
			UserStatsReceived_t? result = await SteamUserStats.Internal.RequestUserStats(this.Id);
			return result != null && result.Value.Result == Result.OK;
		}

		/// <summary>
		/// Gets a user stat. Must call RequestUserStats first.
		/// </summary>
		/// <param name="statName">The name of the stat you want to get</param>
		/// <param name="defult">Will return this value if not available</param>
		/// <returns>The value, or defult if not available</returns>
		// Token: 0x060006B2 RID: 1714 RVA: 0x0000A69C File Offset: 0x0000889C
		internal float GetStatFloat(string statName, float defult = 0f)
		{
			float val = defult;
			if (!SteamUserStats.Internal.GetUserStat(this.Id, statName, ref val))
			{
				return defult;
			}
			return val;
		}

		/// <summary>
		/// Gets a user stat. Must call RequestUserStats first.
		/// </summary>
		/// <param name="statName">The name of the stat you want to get</param>
		/// <param name="defult">Will return this value if not available</param>
		/// <returns>The value, or defult if not available</returns>
		// Token: 0x060006B3 RID: 1715 RVA: 0x0000A6C4 File Offset: 0x000088C4
		internal int GetStatInt(string statName, int defult = 0)
		{
			int val = defult;
			if (!SteamUserStats.Internal.GetUserStat(this.Id, statName, ref val))
			{
				return defult;
			}
			return val;
		}

		/// <summary>
		/// Gets a user achievement state. Must call RequestUserStats first.
		/// </summary>
		/// <param name="statName">The name of the achievement you want to get</param>
		/// <param name="defult">Will return this value if not available</param>
		/// <returns>The value, or defult if not available</returns>
		// Token: 0x060006B4 RID: 1716 RVA: 0x0000A6EC File Offset: 0x000088EC
		internal bool GetAchievement(string statName, bool defult = false)
		{
			bool val = defult;
			if (!SteamUserStats.Internal.GetUserAchievement(this.Id, statName, ref val))
			{
				return defult;
			}
			return val;
		}

		/// <summary>
		/// Gets a the time this achievement was unlocked.
		/// </summary>
		/// <param name="statName">The name of the achievement you want to get</param>
		/// <returns>The time unlocked. If it wasn't unlocked, or you haven't downloaded the stats yet - will return DateTime.MinValue</returns>
		// Token: 0x060006B5 RID: 1717 RVA: 0x0000A714 File Offset: 0x00008914
		internal DateTime GetAchievementUnlockTime(string statName)
		{
			bool val = false;
			uint time = 0U;
			if (!SteamUserStats.Internal.GetUserAchievementAndUnlockTime(this.Id, statName, ref val, ref time) || !val)
			{
				return DateTime.MinValue;
			}
			return Epoch.ToDateTime(time);
		}

		// Token: 0x04000941 RID: 2369
		public SteamId Id;

		// Token: 0x02000353 RID: 851
		public struct FriendGameInfo
		{
			// Token: 0x17000448 RID: 1096
			// (get) Token: 0x06001618 RID: 5656 RVA: 0x00030C0A File Offset: 0x0002EE0A
			public ulong GameId
			{
				get
				{
					return this.GameID;
				}
			}

			// Token: 0x17000449 RID: 1097
			// (get) Token: 0x06001619 RID: 5657 RVA: 0x00030C12 File Offset: 0x0002EE12
			public uint IpAddressRaw
			{
				get
				{
					return this.GameIP;
				}
			}

			// Token: 0x1700044A RID: 1098
			// (get) Token: 0x0600161A RID: 5658 RVA: 0x00030C1A File Offset: 0x0002EE1A
			public IPAddress IpAddress
			{
				get
				{
					return Utility.Int32ToIp(this.GameIP);
				}
			}

			// Token: 0x0600161B RID: 5659 RVA: 0x00030C28 File Offset: 0x0002EE28
			internal static Friend.FriendGameInfo From(FriendGameInfo_t i)
			{
				return new Friend.FriendGameInfo
				{
					GameID = i.GameID,
					GameIP = i.GameIP,
					ConnectionPort = (int)i.GamePort,
					QueryPort = (int)i.QueryPort,
					SteamIDLobby = i.SteamIDLobby
				};
			}

			// Token: 0x040016D9 RID: 5849
			internal ulong GameID;

			// Token: 0x040016DA RID: 5850
			internal uint GameIP;

			// Token: 0x040016DB RID: 5851
			internal ulong SteamIDLobby;

			// Token: 0x040016DC RID: 5852
			public int ConnectionPort;

			// Token: 0x040016DD RID: 5853
			public int QueryPort;
		}
	}
}
