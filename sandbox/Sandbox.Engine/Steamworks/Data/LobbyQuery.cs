using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Steamworks.Data
{
	// Token: 0x020001E7 RID: 487
	internal struct LobbyQuery
	{
		/// <summary>
		/// only lobbies in the same immediate region will be returned
		/// </summary>
		// Token: 0x06000BFD RID: 3069 RVA: 0x00010F88 File Offset: 0x0000F188
		internal LobbyQuery FilterDistanceClose()
		{
			this.distance = new LobbyDistanceFilter?(LobbyDistanceFilter.Close);
			return this;
		}

		/// <summary>
		/// only lobbies in the same immediate region will be returned
		/// </summary>
		// Token: 0x06000BFE RID: 3070 RVA: 0x00010F9C File Offset: 0x0000F19C
		internal LobbyQuery FilterDistanceFar()
		{
			this.distance = new LobbyDistanceFilter?(LobbyDistanceFilter.Far);
			return this;
		}

		/// <summary>
		/// only lobbies in the same immediate region will be returned
		/// </summary>
		// Token: 0x06000BFF RID: 3071 RVA: 0x00010FB0 File Offset: 0x0000F1B0
		internal LobbyQuery FilterDistanceWorldwide()
		{
			this.distance = new LobbyDistanceFilter?(LobbyDistanceFilter.Worldwide);
			return this;
		}

		/// <summary>
		/// Filter by specified key/value pair; string parameters
		/// </summary>
		// Token: 0x06000C00 RID: 3072 RVA: 0x00010FC4 File Offset: 0x0000F1C4
		internal LobbyQuery WithKeyValue(string key, string value)
		{
			if (string.IsNullOrEmpty(key))
			{
				throw new ArgumentException("Key string provided for LobbyQuery filter is null or empty", "key");
			}
			if (key.Length > SteamMatchmaking.MaxLobbyKeyLength)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Key length is longer than ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(SteamMatchmaking.MaxLobbyKeyLength);
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear(), "key");
			}
			if (this.stringFilters == null)
			{
				this.stringFilters = new Dictionary<string, string>();
			}
			this.stringFilters.Add(key, value);
			return this;
		}

		/// <summary>
		/// Numerical filter where value is less than the value provided
		/// </summary>
		// Token: 0x06000C01 RID: 3073 RVA: 0x00011050 File Offset: 0x0000F250
		internal LobbyQuery WithLower(string key, int value)
		{
			this.AddNumericalFilter(key, value, LobbyComparison.LessThan);
			return this;
		}

		/// <summary>
		/// Numerical filter where value is greater than the value provided
		/// </summary>
		// Token: 0x06000C02 RID: 3074 RVA: 0x00011061 File Offset: 0x0000F261
		internal LobbyQuery WithHigher(string key, int value)
		{
			this.AddNumericalFilter(key, value, LobbyComparison.GreaterThan);
			return this;
		}

		/// <summary>
		/// Numerical filter where value must be equal to the value provided
		/// </summary>
		// Token: 0x06000C03 RID: 3075 RVA: 0x00011072 File Offset: 0x0000F272
		internal LobbyQuery WithEqual(string key, int value)
		{
			this.AddNumericalFilter(key, value, LobbyComparison.Equal);
			return this;
		}

		/// <summary>
		/// Numerical filter where value must not equal the value provided
		/// </summary>
		// Token: 0x06000C04 RID: 3076 RVA: 0x00011083 File Offset: 0x0000F283
		internal LobbyQuery WithNotEqual(string key, int value)
		{
			this.AddNumericalFilter(key, value, LobbyComparison.NotEqual);
			return this;
		}

		/// <summary>
		/// Test key, initialize numerical filter list if necessary, then add new numerical filter
		/// </summary>
		// Token: 0x06000C05 RID: 3077 RVA: 0x00011094 File Offset: 0x0000F294
		internal void AddNumericalFilter(string key, int value, LobbyComparison compare)
		{
			if (string.IsNullOrEmpty(key))
			{
				throw new ArgumentException("Key string provided for LobbyQuery filter is null or empty", "key");
			}
			if (key.Length > SteamMatchmaking.MaxLobbyKeyLength)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Key length is longer than ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(SteamMatchmaking.MaxLobbyKeyLength);
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear(), "key");
			}
			if (this.numericalFilters == null)
			{
				this.numericalFilters = new List<NumericalFilter>();
			}
			this.numericalFilters.Add(new NumericalFilter(key, value, compare));
		}

		/// <summary>
		/// Order filtered results according to key/values nearest the provided key/value pair.
		/// Can specify multiple near value filters; each successive filter is lower priority than the previous.
		/// </summary>
		// Token: 0x06000C06 RID: 3078 RVA: 0x00011120 File Offset: 0x0000F320
		internal LobbyQuery OrderByNear(string key, int value)
		{
			if (string.IsNullOrEmpty(key))
			{
				throw new ArgumentException("Key string provided for LobbyQuery filter is null or empty", "key");
			}
			if (key.Length > SteamMatchmaking.MaxLobbyKeyLength)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Key length is longer than ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(SteamMatchmaking.MaxLobbyKeyLength);
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear(), "key");
			}
			if (this.nearValFilters == null)
			{
				this.nearValFilters = new Dictionary<string, int>();
			}
			this.nearValFilters.Add(key, value);
			return this;
		}

		/// <summary>
		/// returns only lobbies with the specified number of slots available
		/// </summary>
		// Token: 0x06000C07 RID: 3079 RVA: 0x000111AC File Offset: 0x0000F3AC
		internal LobbyQuery WithSlotsAvailable(int minSlots)
		{
			this.slotsAvailable = new int?(minSlots);
			return this;
		}

		/// <summary>
		/// sets how many results to return, the lower the count the faster it is to download the lobby results
		/// </summary>
		// Token: 0x06000C08 RID: 3080 RVA: 0x000111C0 File Offset: 0x0000F3C0
		internal LobbyQuery WithMaxResults(int max)
		{
			this.maxResults = new int?(max);
			return this;
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x000111D4 File Offset: 0x0000F3D4
		private void ApplyFilters()
		{
			if (this.distance != null)
			{
				SteamMatchmaking.Internal.AddRequestLobbyListDistanceFilter(this.distance.Value);
			}
			if (this.slotsAvailable != null)
			{
				SteamMatchmaking.Internal.AddRequestLobbyListFilterSlotsAvailable(this.slotsAvailable.Value);
			}
			if (this.maxResults != null)
			{
				SteamMatchmaking.Internal.AddRequestLobbyListResultCountFilter(this.maxResults.Value);
			}
			if (this.stringFilters != null)
			{
				foreach (KeyValuePair<string, string> i in this.stringFilters)
				{
					SteamMatchmaking.Internal.AddRequestLobbyListStringFilter(i.Key, i.Value, LobbyComparison.Equal);
				}
			}
			if (this.numericalFilters != null)
			{
				foreach (NumericalFilter j in this.numericalFilters)
				{
					SteamMatchmaking.Internal.AddRequestLobbyListNumericalFilter(j.Key, j.Value, j.Comparer);
				}
			}
			if (this.nearValFilters != null)
			{
				foreach (KeyValuePair<string, int> v in this.nearValFilters)
				{
					SteamMatchmaking.Internal.AddRequestLobbyListNearValueFilter(v.Key, v.Value);
				}
			}
		}

		/// <summary>
		/// Run the query, get the matching lobbies
		/// </summary>
		// Token: 0x06000C0A RID: 3082 RVA: 0x00011368 File Offset: 0x0000F568
		internal async Task<Lobby[]> RequestAsync()
		{
			this.ApplyFilters();
			LobbyMatchList_t? list = await SteamMatchmaking.Internal.RequestLobbyList();
			Lobby[] result;
			if (list == null || list.Value.LobbiesMatching == 0U)
			{
				result = null;
			}
			else
			{
				Lobby[] lobbies = new Lobby[list.Value.LobbiesMatching];
				int i = 0;
				while ((long)i < (long)((ulong)list.Value.LobbiesMatching))
				{
					lobbies[i] = new Lobby
					{
						Id = SteamMatchmaking.Internal.GetLobbyByIndex(i)
					};
					i++;
				}
				result = lobbies;
			}
			return result;
		}

		// Token: 0x04000D84 RID: 3460
		internal LobbyDistanceFilter? distance;

		// Token: 0x04000D85 RID: 3461
		internal Dictionary<string, string> stringFilters;

		// Token: 0x04000D86 RID: 3462
		internal List<NumericalFilter> numericalFilters;

		// Token: 0x04000D87 RID: 3463
		internal Dictionary<string, int> nearValFilters;

		// Token: 0x04000D88 RID: 3464
		internal int? slotsAvailable;

		// Token: 0x04000D89 RID: 3465
		internal int? maxResults;
	}
}
