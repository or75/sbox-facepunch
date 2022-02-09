using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Steamworks.Data
{
	// Token: 0x020001EB RID: 491
	internal struct ServerInfo : IEquatable<ServerInfo>
	{
		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000C1E RID: 3102 RVA: 0x000114D8 File Offset: 0x0000F6D8
		// (set) Token: 0x06000C1F RID: 3103 RVA: 0x000114E0 File Offset: 0x0000F6E0
		internal string Name { readonly get; set; }

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000C20 RID: 3104 RVA: 0x000114E9 File Offset: 0x0000F6E9
		// (set) Token: 0x06000C21 RID: 3105 RVA: 0x000114F1 File Offset: 0x0000F6F1
		internal int Ping { readonly get; set; }

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000C22 RID: 3106 RVA: 0x000114FA File Offset: 0x0000F6FA
		// (set) Token: 0x06000C23 RID: 3107 RVA: 0x00011502 File Offset: 0x0000F702
		internal string GameDir { readonly get; set; }

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000C24 RID: 3108 RVA: 0x0001150B File Offset: 0x0000F70B
		// (set) Token: 0x06000C25 RID: 3109 RVA: 0x00011513 File Offset: 0x0000F713
		internal string Map { readonly get; set; }

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000C26 RID: 3110 RVA: 0x0001151C File Offset: 0x0000F71C
		// (set) Token: 0x06000C27 RID: 3111 RVA: 0x00011524 File Offset: 0x0000F724
		internal string Description { readonly get; set; }

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000C28 RID: 3112 RVA: 0x0001152D File Offset: 0x0000F72D
		// (set) Token: 0x06000C29 RID: 3113 RVA: 0x00011535 File Offset: 0x0000F735
		internal uint AppId { readonly get; set; }

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000C2A RID: 3114 RVA: 0x0001153E File Offset: 0x0000F73E
		// (set) Token: 0x06000C2B RID: 3115 RVA: 0x00011546 File Offset: 0x0000F746
		internal int Players { readonly get; set; }

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000C2C RID: 3116 RVA: 0x0001154F File Offset: 0x0000F74F
		// (set) Token: 0x06000C2D RID: 3117 RVA: 0x00011557 File Offset: 0x0000F757
		internal int MaxPlayers { readonly get; set; }

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000C2E RID: 3118 RVA: 0x00011560 File Offset: 0x0000F760
		// (set) Token: 0x06000C2F RID: 3119 RVA: 0x00011568 File Offset: 0x0000F768
		internal int BotPlayers { readonly get; set; }

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000C30 RID: 3120 RVA: 0x00011571 File Offset: 0x0000F771
		// (set) Token: 0x06000C31 RID: 3121 RVA: 0x00011579 File Offset: 0x0000F779
		internal bool Passworded { readonly get; set; }

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000C32 RID: 3122 RVA: 0x00011582 File Offset: 0x0000F782
		// (set) Token: 0x06000C33 RID: 3123 RVA: 0x0001158A File Offset: 0x0000F78A
		internal bool Secure { readonly get; set; }

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000C34 RID: 3124 RVA: 0x00011593 File Offset: 0x0000F793
		// (set) Token: 0x06000C35 RID: 3125 RVA: 0x0001159B File Offset: 0x0000F79B
		internal uint LastTimePlayed { readonly get; set; }

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000C36 RID: 3126 RVA: 0x000115A4 File Offset: 0x0000F7A4
		// (set) Token: 0x06000C37 RID: 3127 RVA: 0x000115AC File Offset: 0x0000F7AC
		internal int Version { readonly get; set; }

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000C38 RID: 3128 RVA: 0x000115B5 File Offset: 0x0000F7B5
		// (set) Token: 0x06000C39 RID: 3129 RVA: 0x000115BD File Offset: 0x0000F7BD
		internal string TagString { readonly get; set; }

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000C3A RID: 3130 RVA: 0x000115C6 File Offset: 0x0000F7C6
		// (set) Token: 0x06000C3B RID: 3131 RVA: 0x000115CE File Offset: 0x0000F7CE
		internal ulong SteamId { readonly get; set; }

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000C3C RID: 3132 RVA: 0x000115D7 File Offset: 0x0000F7D7
		// (set) Token: 0x06000C3D RID: 3133 RVA: 0x000115DF File Offset: 0x0000F7DF
		internal uint AddressRaw { readonly get; set; }

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000C3E RID: 3134 RVA: 0x000115E8 File Offset: 0x0000F7E8
		// (set) Token: 0x06000C3F RID: 3135 RVA: 0x000115F0 File Offset: 0x0000F7F0
		internal IPAddress Address { readonly get; set; }

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000C40 RID: 3136 RVA: 0x000115F9 File Offset: 0x0000F7F9
		// (set) Token: 0x06000C41 RID: 3137 RVA: 0x00011601 File Offset: 0x0000F801
		internal int ConnectionPort { readonly get; set; }

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000C42 RID: 3138 RVA: 0x0001160A File Offset: 0x0000F80A
		// (set) Token: 0x06000C43 RID: 3139 RVA: 0x00011612 File Offset: 0x0000F812
		internal int QueryPort { readonly get; set; }

		/// <summary>
		/// Gets the individual tags for this server
		/// </summary>
		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000C44 RID: 3140 RVA: 0x0001161B File Offset: 0x0000F81B
		internal string[] Tags
		{
			get
			{
				if (this._tags == null && !string.IsNullOrEmpty(this.TagString))
				{
					this._tags = this.TagString.Split(',', StringSplitOptions.None);
				}
				return this._tags;
			}
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x0001164C File Offset: 0x0000F84C
		internal static ServerInfo From(gameserveritem_t item)
		{
			return new ServerInfo
			{
				AddressRaw = item.NetAdr.IP,
				Address = Utility.Int32ToIp(item.NetAdr.IP),
				ConnectionPort = (int)item.NetAdr.ConnectionPort,
				QueryPort = (int)item.NetAdr.QueryPort,
				Name = item.ServerNameUTF8(),
				Ping = item.Ping,
				GameDir = item.GameDirUTF8(),
				Map = item.MapUTF8(),
				Description = item.GameDescriptionUTF8(),
				AppId = item.AppID,
				Players = item.Players,
				MaxPlayers = item.MaxPlayers,
				BotPlayers = item.BotPlayers,
				Passworded = item.Password,
				Secure = item.Secure,
				LastTimePlayed = item.TimeLastPlayed,
				Version = item.ServerVersion,
				TagString = item.GameTagsUTF8(),
				SteamId = item.SteamID
			};
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x00011777 File Offset: 0x0000F977
		internal ServerInfo(uint ip, ushort cport, ushort qport, uint timeplayed)
		{
			this = default(ServerInfo);
			this.AddressRaw = ip;
			this.Address = Utility.Int32ToIp(ip);
			this.ConnectionPort = (int)cport;
			this.QueryPort = (int)qport;
			this.LastTimePlayed = timeplayed;
		}

		/// <summary>
		/// Add this server to our history list
		/// If we're already in the history list, weill set the last played time to now
		/// </summary>
		// Token: 0x06000C47 RID: 3143 RVA: 0x000117A9 File Offset: 0x0000F9A9
		internal void AddToHistory()
		{
			SteamMatchmaking.Internal.AddFavoriteGame(SteamClient.AppId, this.AddressRaw, (ushort)this.ConnectionPort, (ushort)this.QueryPort, 2U, (uint)Epoch.Current);
		}

		/// <summary>
		/// If this server responds to source engine style queries, we'll be able to get a list of rules here
		/// </summary>
		// Token: 0x06000C48 RID: 3144 RVA: 0x000117D8 File Offset: 0x0000F9D8
		internal async Task<Dictionary<string, string>> QueryRulesAsync()
		{
			return await SourceServerQuery.GetRules(ref this);
		}

		/// <summary>
		/// Remove this server from our history list
		/// </summary>
		// Token: 0x06000C49 RID: 3145 RVA: 0x00011820 File Offset: 0x0000FA20
		internal void RemoveFromHistory()
		{
			SteamMatchmaking.Internal.RemoveFavoriteGame(SteamClient.AppId, this.AddressRaw, (ushort)this.ConnectionPort, (ushort)this.QueryPort, 2U);
		}

		/// <summary>
		/// Add this server to our favourite list
		/// </summary>
		// Token: 0x06000C4A RID: 3146 RVA: 0x00011847 File Offset: 0x0000FA47
		internal void AddToFavourites()
		{
			SteamMatchmaking.Internal.AddFavoriteGame(SteamClient.AppId, this.AddressRaw, (ushort)this.ConnectionPort, (ushort)this.QueryPort, 1U, (uint)Epoch.Current);
		}

		/// <summary>
		/// Remove this server from our favourite list
		/// </summary>
		// Token: 0x06000C4B RID: 3147 RVA: 0x00011873 File Offset: 0x0000FA73
		internal void RemoveFromFavourites()
		{
			SteamMatchmaking.Internal.RemoveFavoriteGame(SteamClient.AppId, this.AddressRaw, (ushort)this.ConnectionPort, (ushort)this.QueryPort, 1U);
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x0001189A File Offset: 0x0000FA9A
		public bool Equals(ServerInfo other)
		{
			return this.GetHashCode() == other.GetHashCode();
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x000118B8 File Offset: 0x0000FAB8
		public override int GetHashCode()
		{
			return this.Address.GetHashCode() + this.SteamId.GetHashCode() + this.ConnectionPort.GetHashCode() + this.QueryPort.GetHashCode();
		}

		// Token: 0x04000DA2 RID: 3490
		private string[] _tags;

		// Token: 0x04000DA3 RID: 3491
		internal const uint k_unFavoriteFlagNone = 0U;

		// Token: 0x04000DA4 RID: 3492
		internal const uint k_unFavoriteFlagFavorite = 1U;

		// Token: 0x04000DA5 RID: 3493
		internal const uint k_unFavoriteFlagHistory = 2U;
	}
}
