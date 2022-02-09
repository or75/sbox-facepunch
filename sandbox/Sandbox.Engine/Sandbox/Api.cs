using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Caching.Memory;
using Sandbox.Internal;
using Steamworks;

namespace Sandbox
{
	// Token: 0x02000281 RID: 641
	internal static class Api
	{
		// Token: 0x06000FAA RID: 4010 RVA: 0x0001C5F4 File Offset: 0x0001A7F4
		public static async Task UpdateActivity(string game, string map, bool initial)
		{
			try
			{
				await Api.ActivityMutex.WaitAsync();
				if (initial)
				{
					Api.SessionHash = Guid.NewGuid().ToString().Substring(0, 8);
					Api.SessionStopwatch = Stopwatch.StartNew();
					Api.ActivityCount = 0;
				}
				if (Api.SessionHash != null)
				{
					await Api.PostWithTokenAsync("sandbox-player-activity", new Dictionary<string, object>
					{
						{
							"game",
							game.Trim().ToLower()
						},
						{
							"map",
							map.Trim().ToLower()
						},
						{
							"st",
							Api.SessionTime
						},
						{
							"sh",
							Api.SessionHash
						},
						{
							"i",
							Api.ActivityCount++
						}
					});
				}
			}
			finally
			{
				Api.ActivityMutex.Release();
			}
		}

		// Token: 0x06000FAB RID: 4011 RVA: 0x0001C648 File Offset: 0x0001A848
		internal static async Task CloseActivity()
		{
			try
			{
				await Api.ActivityMutex.WaitAsync();
				if (Api.SessionHash != null)
				{
					await Api.PostAsync("sandbox-player-activity", new Dictionary<string, object>
					{
						{ "game", "" },
						{ "map", "" },
						{
							"st",
							Api.SessionTime
						},
						{
							"sh",
							Api.SessionHash
						},
						{
							"i",
							Api.ActivityCount++
						}
					}, null);
					Api.SessionHash = null;
					Api.SessionStopwatch = null;
					Api.ActivityCount = -1;
				}
			}
			finally
			{
				Api.ActivityMutex.Release();
			}
		}

		// Token: 0x06000FAC RID: 4012 RVA: 0x0001C684 File Offset: 0x0001A884
		internal static async Task<Package> GetAsset(string name)
		{
			Dictionary<string, object> o = new Dictionary<string, object> { { "id", name } };
			Api.GetResult q = await Api.GetAsync<Api.GetResult>("sandbox-asset", o, 600f);
			Package result;
			if (q == null)
			{
				result = null;
			}
			else
			{
				result = q.Asset;
			}
			return result;
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x0001C6C8 File Offset: 0x0001A8C8
		internal static Task<Package[]> QueryAssets(Package.Type type, string order = "trending", int category = 0, string searchText = null, List<string> tags = null)
		{
			Dictionary<string, object> o = new Dictionary<string, object>
			{
				{
					"type",
					type.ToString().ToLower()
				},
				{ "order", order }
			};
			if (category > 0)
			{
				o["category"] = category;
			}
			if (searchText != null)
			{
				o["search"] = searchText;
			}
			if (tags != null && tags.Count<string>() > 0)
			{
				o["tags"] = string.Join(",", tags);
			}
			return Api.GetAsync<Package[]>("sandbox-asset-list", o, 120f);
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x0001C760 File Offset: 0x0001A960
		internal static Task<Package.CategoryList> GetCategories(Package.Type type, List<string> tags = null)
		{
			Dictionary<string, object> o = new Dictionary<string, object> { 
			{
				"type",
				type.ToString().ToLower()
			} };
			if (tags != null && tags.Count<string>() > 0)
			{
				o["tags"] = string.Join(",", tags);
			}
			return Api.GetAsync<Package.CategoryList>("sandbox-asset-categories", null, 120f);
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x0001C7C4 File Offset: 0x0001A9C4
		internal static async Task<Package> RateAsset(string packageId, bool up)
		{
			Dictionary<string, object> args = new Dictionary<string, object>();
			args["id"] = packageId;
			args["rating"] = (up ? 0 : 1);
			return await Api.PostWithTokenAsync<Package>("sandbox-asset-rate", args);
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x0001C810 File Offset: 0x0001AA10
		internal static async Task<ApiUpdateResult<Package>> UpdateAsset(object data, string function = "sandbox-asset-update")
		{
			return await Api.PostWithTokenAsync<ApiUpdateResult<Package>>(function, data);
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x06000FB1 RID: 4017 RVA: 0x0001C85B File Offset: 0x0001AA5B
		public static string BaseUrl
		{
			get
			{
				return "https://apix.facepunch.com/";
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06000FB2 RID: 4018 RVA: 0x0001C862 File Offset: 0x0001AA62
		// (set) Token: 0x06000FB3 RID: 4019 RVA: 0x0001C869 File Offset: 0x0001AA69
		public static string SessionHash { get; private set; }

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000FB4 RID: 4020 RVA: 0x0001C874 File Offset: 0x0001AA74
		public static int SessionTime
		{
			get
			{
				return (int)Api.SessionStopwatch.Elapsed.TotalSeconds;
			}
		}

		// Token: 0x06000FB5 RID: 4021 RVA: 0x0001C894 File Offset: 0x0001AA94
		private static HttpClient GetHttpClient()
		{
			if (Api.httpClient == null)
			{
				if (Api.httpClient == null)
				{
					Api.httpClient = new HttpClient();
				}
				Api.httpClient.DefaultRequestHeaders.Add("X-Api-Version", 25.ToString());
			}
			return Api.httpClient;
		}

		// Token: 0x06000FB6 RID: 4022 RVA: 0x0001C8DC File Offset: 0x0001AADC
		internal static async Task<T> GetAsync<T>(string url, Dictionary<string, object> values = null, float cacheSeconds = 0f)
		{
			T cachedValue;
			T result2;
			if (cacheSeconds > 0f && Api.memoryCache.TryGetValue(url, out cachedValue))
			{
				result2 = cachedValue;
			}
			else
			{
				try
				{
					url = Api.BaseUrl + url;
					if (values != null)
					{
						string queryString = string.Join<string>('&', values.Select(delegate(KeyValuePair<string, object> x)
						{
							string key = x.Key;
							string str = "=";
							object value = x.Value;
							return key + str + HttpUtility.UrlEncode(((value != null) ? value.ToString() : null) ?? "");
						}));
						url = url + "?" + queryString;
					}
					HttpClient httpClient = Api.GetHttpClient();
					HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, url);
					T result = Api.Deserialize<T>(await(await httpClient.SendAsync(req)).Content.ReadAsStringAsync());
					if (cacheSeconds > 0f)
					{
						Api.memoryCache.Set(url, result, DateTimeOffset.Now.AddSeconds((double)cacheSeconds));
					}
					result2 = result;
				}
				catch (Exception e)
				{
					GlobalSystemNamespace.Log.Warning(e, FormattableStringFactory.Create("Api Error: \"{0}\"", new object[] { url }));
					result2 = default(T);
				}
			}
			return result2;
		}

		// Token: 0x06000FB7 RID: 4023 RVA: 0x0001C930 File Offset: 0x0001AB30
		internal static async Task<string> PostAsync(string url, object values, Dictionary<string, string> headers = null)
		{
			string result;
			try
			{
				HttpClient client = Api.GetHttpClient();
				url = Api.BaseUrl + url;
				StringContent content = new StringContent(JsonSerializer.Serialize<object>(values, null), Encoding.UTF8, "application/json");
				HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, url)
				{
					Content = content
				};
				if (headers != null)
				{
					foreach (KeyValuePair<string, string> header in headers)
					{
						req.Headers.Add(header.Key, header.Value);
					}
				}
				result = await(await client.SendAsync(req)).Content.ReadAsStringAsync();
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Warning(e, FormattableStringFactory.Create("Exception when posting to API", Array.Empty<object>()));
				result = null;
			}
			return result;
		}

		// Token: 0x06000FB8 RID: 4024 RVA: 0x0001C984 File Offset: 0x0001AB84
		internal static async Task<string> PostWithTokenAsync(string url, object data)
		{
			AuthTicket authTicket = await SteamUser.GetAuthSessionTicketAsync(10.0);
			string result;
			using (AuthTicket ticket = authTicket)
			{
				if (ticket == null)
				{
					result = null;
				}
				else
				{
					Dictionary<string, string> headers = new Dictionary<string, string>();
					headers["Authorization"] = "steam " + BitConverter.ToString(ticket.Data).Replace("-", "");
					result = await Api.PostAsync(url ?? "", data, headers);
				}
			}
			return result;
		}

		// Token: 0x06000FB9 RID: 4025 RVA: 0x0001C9D0 File Offset: 0x0001ABD0
		internal static async Task<T> PostWithTokenAsync<T>(string url, object data)
		{
			string result = await Api.PostWithTokenAsync(url, data);
			T result2;
			if (string.IsNullOrWhiteSpace(result))
			{
				result2 = default(T);
			}
			else
			{
				result2 = Api.Deserialize<T>(result);
			}
			return result2;
		}

		// Token: 0x06000FBA RID: 4026 RVA: 0x0001CA1C File Offset: 0x0001AC1C
		private static T Deserialize<T>(string result)
		{
			T result2;
			try
			{
				result2 = JsonSerializer.Deserialize<T>(result, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Warning(e, FormattableStringFactory.Create("Couldn't deserialize result to {0}\nResult:\n{1}\n", new object[]
				{
					typeof(T),
					result
				}));
				result2 = default(T);
			}
			return result2;
		}

		/// <summary>
		/// Send a game description to the backend. We can update leaderboards and shit from this.
		/// </summary>
		// Token: 0x06000FBB RID: 4027 RVA: 0x0001CA88 File Offset: 0x0001AC88
		[NullableContext(1)]
		internal static async Task<string> Commit(GameDescription game)
		{
			Dictionary<string, object> data = new Dictionary<string, object>
			{
				{
					"description",
					JsonSerializer.Serialize<GameDescription>(game, null)
				},
				{ "game", game.Game },
				{ "map", game.Map }
			};
			return await Api.PostWithTokenAsync<string>("sandbox-game-result", data);
		}

		/// <summary>
		/// Get linked service credentials, ie "twitch". Under the hood, on our server, we will
		/// probably be renewing the token with the service (assume the token is only good for 2-3 hours).
		/// </summary>
		// Token: 0x06000FBC RID: 4028 RVA: 0x0001CACC File Offset: 0x0001ACCC
		internal static async Task<AccountInformation> GetAccountInformation()
		{
			return await Api.PostWithTokenAsync<AccountInformation>("sandbox-player-login", null);
		}

		/// <summary>
		/// Get linked service credentials, ie "twitch". Under the hood, on our server, we will
		/// probably be renewing the token with the service (assume the token is only good for 2-3 hours).
		/// </summary>
		// Token: 0x06000FBD RID: 4029 RVA: 0x0001CB08 File Offset: 0x0001AD08
		internal static async Task SetFavourite(string assetident, bool on)
		{
			Dictionary<string, object> data = new Dictionary<string, object>();
			data["id"] = assetident;
			data["on"] = on;
			List<Package> favourites = await Api.PostWithTokenAsync<List<Package>>("sandbox-player-favourite", data);
			if (favourites != null)
			{
				AccountInformation.Current.Favourites = favourites;
			}
		}

		/// <summary>
		/// Send a game description to the backend. We can update leaderboards and shit from this.
		/// </summary>
		// Token: 0x06000FBE RID: 4030 RVA: 0x0001CB54 File Offset: 0x0001AD54
		[NullableContext(1)]
		internal static async Task<PlayerGameRank> GetPlayerRank(long playerId, string gameIdent)
		{
			Dictionary<string, object> data = new Dictionary<string, object>
			{
				{ "playerid", playerId },
				{ "game", gameIdent }
			};
			return await Api.GetAsync<PlayerGameRank>("sandbox-player-rank", data, 5f);
		}

		/// <summary>
		/// Get linked service credentials, ie "twitch". Under the hood, on our server, we will
		/// probably be renewing the token with the service (assume the token is only good for 2-3 hours).
		/// </summary>
		// Token: 0x06000FBF RID: 4031 RVA: 0x0001CBA0 File Offset: 0x0001ADA0
		internal static async Task<Api.ServiceToken> GetLinkedService(string serviceName)
		{
			Dictionary<string, object> data = new Dictionary<string, object> { { "service", serviceName } };
			return await Api.PostWithTokenAsync<Api.ServiceToken>("sandbox-player-services", data);
		}

		// Token: 0x04001224 RID: 4644
		private static int ActivityCount;

		// Token: 0x04001225 RID: 4645
		private static SemaphoreSlim ActivityMutex = new SemaphoreSlim(1, 1);

		// Token: 0x04001227 RID: 4647
		public static Stopwatch SessionStopwatch;

		// Token: 0x04001228 RID: 4648
		private static MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());

		// Token: 0x04001229 RID: 4649
		private static HttpClient httpClient;

		// Token: 0x020003C0 RID: 960
		internal class GetResult
		{
			// Token: 0x17000456 RID: 1110
			// (get) Token: 0x060016BC RID: 5820 RVA: 0x00033F47 File Offset: 0x00032147
			// (set) Token: 0x060016BD RID: 5821 RVA: 0x00033F4F File Offset: 0x0003214F
			public Package Asset { get; set; }
		}

		// Token: 0x020003C1 RID: 961
		internal class ServiceToken
		{
			/// <summary>
			/// The UserId returned by the service
			/// </summary>
			// Token: 0x17000457 RID: 1111
			// (get) Token: 0x060016BF RID: 5823 RVA: 0x00033F60 File Offset: 0x00032160
			// (set) Token: 0x060016C0 RID: 5824 RVA: 0x00033F68 File Offset: 0x00032168
			public string Id { get; set; }

			/// <summary>
			/// The Username returned by the service
			/// </summary>
			// Token: 0x17000458 RID: 1112
			// (get) Token: 0x060016C1 RID: 5825 RVA: 0x00033F71 File Offset: 0x00032171
			// (set) Token: 0x060016C2 RID: 5826 RVA: 0x00033F79 File Offset: 0x00032179
			public string Name { get; set; }

			/// <summary>
			/// The Token returned by the service
			/// </summary>
			// Token: 0x17000459 RID: 1113
			// (get) Token: 0x060016C3 RID: 5827 RVA: 0x00033F82 File Offset: 0x00032182
			// (set) Token: 0x060016C4 RID: 5828 RVA: 0x00033F8A File Offset: 0x0003218A
			public string Token { get; set; }

			/// <summary>
			/// The type (ie "Twitch")
			/// </summary>
			// Token: 0x1700045A RID: 1114
			// (get) Token: 0x060016C5 RID: 5829 RVA: 0x00033F93 File Offset: 0x00032193
			// (set) Token: 0x060016C6 RID: 5830 RVA: 0x00033F9B File Offset: 0x0003219B
			public string Type { get; set; }
		}
	}
}
