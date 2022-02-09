using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Sandbox.Engine;

namespace Sandbox.Twitch
{
	// Token: 0x020002E2 RID: 738
	internal class TwitchAPI
	{
		// Token: 0x06001372 RID: 4978 RVA: 0x00028C4C File Offset: 0x00026E4C
		public async Task<TwitchAPI.ChannelResponse> GetChannel(string userId)
		{
			TwitchAPI.ChannelsResponse channelsResponse = await this.Get<TwitchAPI.ChannelsResponse>("/channels?broadcaster_id=" + userId);
			return (channelsResponse != null) ? channelsResponse.FirstOrDefault() : null;
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x00028C98 File Offset: 0x00026E98
		public async void SetChannelGame(string userId, string gameId)
		{
			await this.Patch("/channels?broadcaster_id=" + userId, "{\"game_id\":\"" + gameId + "\"}");
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x00028CE0 File Offset: 0x00026EE0
		public async void SetChannelLanguage(string userId, string language)
		{
			await this.Patch("/channels?broadcaster_id=" + userId, "{\"broadcaster_language\":\"" + language + "\"}");
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x00028D28 File Offset: 0x00026F28
		public async void SetChannelTitle(string userId, string title)
		{
			await this.Patch("/channels?broadcaster_id=" + userId, "{\"title\":\"" + title + "\"}");
		}

		// Token: 0x06001376 RID: 4982 RVA: 0x00028D70 File Offset: 0x00026F70
		public async void SetChannelDelay(string userId, int delay)
		{
			string request = "/channels?broadcaster_id=" + userId;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
			defaultInterpolatedStringHandler.AppendLiteral("{\"delay\":");
			defaultInterpolatedStringHandler.AppendFormatted<int>(delay);
			defaultInterpolatedStringHandler.AppendLiteral("}");
			await this.Patch(request, defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x00028DB8 File Offset: 0x00026FB8
		public async Task<TwitchAPI.CreateClipResponse> CreateClip(string userId, bool hasDelay)
		{
			return JsonSerializer.Deserialize<TwitchAPI.CreateClipsResponse>(await(await this.Post("/clips?broadcaster_id=" + userId, JsonSerializer.Serialize<TwitchAPI.CreateClipRequest>(new TwitchAPI.CreateClipRequest
			{
				BroadcasterId = userId,
				HasDelay = hasDelay
			}, null))).Content.ReadAsStringAsync(), null).FirstOrDefault();
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06001378 RID: 4984 RVA: 0x00028E0C File Offset: 0x0002700C
		internal HttpClient Http
		{
			get
			{
				Api.ServiceToken token = Streamer.ServiceToken;
				return new HttpClient
				{
					DefaultRequestHeaders = 
					{
						{ "Client-ID", "lyo7ge5md65toi0f3bjpkbn4u8hwol" },
						{
							"Authorization",
							"Bearer " + token.Token
						}
					}
				};
			}
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x00028E5C File Offset: 0x0002705C
		internal Task<T> Get<T>(string request)
		{
			string url = "https://api.twitch.tv/helix" + request;
			Task<T> result;
			try
			{
				result = this.Http.GetFromJsonAsync(url, default(CancellationToken));
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x00028EA4 File Offset: 0x000270A4
		internal Task<HttpResponseMessage> Post(string request, string json)
		{
			string url = "https://api.twitch.tv/helix" + request;
			Task<HttpResponseMessage> result;
			try
			{
				result = this.Http.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x00028EF4 File Offset: 0x000270F4
		internal Task<HttpResponseMessage> Put(string request, string json)
		{
			string url = "https://api.twitch.tv/helix" + request;
			Task<HttpResponseMessage> result;
			try
			{
				result = this.Http.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x00028F44 File Offset: 0x00027144
		internal Task<HttpResponseMessage> Patch(string request, string json)
		{
			string url = "https://api.twitch.tv/helix" + request;
			Task<HttpResponseMessage> result;
			try
			{
				result = this.Http.PatchAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600137D RID: 4989 RVA: 0x00028F94 File Offset: 0x00027194
		public async Task<TwitchAPI.PollResponse> CreatePoll(string userId, string title, int duration, string[] choices)
		{
			string request = "/polls";
			TwitchAPI.CreatePollRequest createPollRequest = new TwitchAPI.CreatePollRequest();
			createPollRequest.BroadcasterId = userId;
			createPollRequest.Title = title;
			createPollRequest.Duration = duration;
			createPollRequest.Choices = choices.Select((string x) => new TwitchAPI.CreatePollRequest.Choice
			{
				Title = x
			}).ToArray<TwitchAPI.CreatePollRequest.Choice>();
			return JsonSerializer.Deserialize<TwitchAPI.PollResponse>(await(await this.Post(request, JsonSerializer.Serialize<TwitchAPI.CreatePollRequest>(createPollRequest, null))).Content.ReadAsStringAsync(), null);
		}

		// Token: 0x0600137E RID: 4990 RVA: 0x00028FF8 File Offset: 0x000271F8
		public async Task<TwitchAPI.PollResponse> EndPoll(string userId, string pollId, bool archive = false)
		{
			return JsonSerializer.Deserialize<TwitchAPI.PollResponse>(await(await this.Post("/polls", JsonSerializer.Serialize<TwitchAPI.EndPollRequest>(new TwitchAPI.EndPollRequest
			{
				BroadcasterId = userId,
				Id = pollId,
				Status = (archive ? "ARCHIVED" : "TERMINATED")
			}, null))).Content.ReadAsStringAsync(), null);
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x00029054 File Offset: 0x00027254
		public async Task<TwitchAPI.PredictionResponse> CreatePrediction(string userId, string title, int duration, string firstOutcome, string secondOutcome)
		{
			return JsonSerializer.Deserialize<TwitchAPI.PredictionResponse>(await(await this.Post("/predictions", JsonSerializer.Serialize<TwitchAPI.CreatePredictionRequest>(new TwitchAPI.CreatePredictionRequest
			{
				BroadcasterId = userId,
				Title = title,
				Duration = duration,
				Outcomes = new TwitchAPI.CreatePredictionRequest.Outcome[]
				{
					new TwitchAPI.CreatePredictionRequest.Outcome
					{
						Title = firstOutcome
					},
					new TwitchAPI.CreatePredictionRequest.Outcome
					{
						Title = secondOutcome
					}
				}
			}, null))).Content.ReadAsStringAsync(), null);
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x000290C4 File Offset: 0x000272C4
		public async Task<TwitchAPI.PredictionResponse> LockPrediction(string userId, string predictionId)
		{
			return JsonSerializer.Deserialize<TwitchAPI.PredictionResponse>(await(await this.Post("/predictions", JsonSerializer.Serialize<TwitchAPI.EndPredictionRequest>(new TwitchAPI.EndPredictionRequest
			{
				BroadcasterId = userId,
				Id = predictionId,
				Status = "LOCKED"
			}, null))).Content.ReadAsStringAsync(), null);
		}

		// Token: 0x06001381 RID: 4993 RVA: 0x00029118 File Offset: 0x00027318
		public async Task<TwitchAPI.PredictionResponse> CancelPrediction(string userId, string predictionId)
		{
			return JsonSerializer.Deserialize<TwitchAPI.PredictionResponse>(await(await this.Post("/predictions", JsonSerializer.Serialize<TwitchAPI.EndPredictionRequest>(new TwitchAPI.EndPredictionRequest
			{
				BroadcasterId = userId,
				Id = predictionId,
				Status = "CANCELED"
			}, null))).Content.ReadAsStringAsync(), null);
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x0002916C File Offset: 0x0002736C
		public async Task<TwitchAPI.PredictionResponse> ResolvePrediction(string userId, string predictionId, string winningOutcomeId)
		{
			return JsonSerializer.Deserialize<TwitchAPI.PredictionResponse>(await(await this.Post("/predictions", JsonSerializer.Serialize<TwitchAPI.EndPredictionRequest>(new TwitchAPI.EndPredictionRequest
			{
				BroadcasterId = userId,
				Id = predictionId,
				Status = "RESOLVED",
				WinningOutcomeId = winningOutcomeId
			}, null))).Content.ReadAsStringAsync(), null);
		}

		// Token: 0x06001383 RID: 4995 RVA: 0x000291C8 File Offset: 0x000273C8
		public async Task<TwitchAPI.StreamResponse> GetStream(string userId)
		{
			return (await this.Get<TwitchAPI.StreamsResponse>("/streams?user_id=" + userId)).FirstOrDefault();
		}

		// Token: 0x06001384 RID: 4996 RVA: 0x00029213 File Offset: 0x00027413
		public Task<TwitchAPI.StreamsResponse> GetStreams(string gameId)
		{
			return this.Get<TwitchAPI.StreamsResponse>("/streams?game_id=" + gameId);
		}

		// Token: 0x06001385 RID: 4997 RVA: 0x00029228 File Offset: 0x00027428
		public async Task<TwitchAPI.UserResponse> GetUser(string username = null)
		{
			return (await this.Get<TwitchAPI.UsersResponse>(string.IsNullOrEmpty(username) ? "/users" : ("/users?login=" + username))).FirstOrDefault();
		}

		// Token: 0x06001386 RID: 4998 RVA: 0x00029273 File Offset: 0x00027473
		public Task<TwitchAPI.UserFollowsResponse> GetUserFollowing(string userId)
		{
			return this.Get<TwitchAPI.UserFollowsResponse>("/users/follows?from_id=" + userId);
		}

		// Token: 0x06001387 RID: 4999 RVA: 0x00029286 File Offset: 0x00027486
		public Task<TwitchAPI.UserFollowsResponse> GetUserFollowers(string userId)
		{
			return this.Get<TwitchAPI.UserFollowsResponse>("/users/follows?to_id=" + userId);
		}

		// Token: 0x0400150F RID: 5391
		internal const string ApiUrl = "https://api.twitch.tv/helix";

		// Token: 0x04001510 RID: 5392
		internal const string ClientId = "lyo7ge5md65toi0f3bjpkbn4u8hwol";

		// Token: 0x02000423 RID: 1059
		public class ChannelResponse
		{
			// Token: 0x170004A7 RID: 1191
			// (get) Token: 0x06001845 RID: 6213 RVA: 0x00038A5F File Offset: 0x00036C5F
			// (set) Token: 0x06001846 RID: 6214 RVA: 0x00038A67 File Offset: 0x00036C67
			[JsonPropertyName("broadcaster_id")]
			public string BroadcasterId { get; set; }

			// Token: 0x170004A8 RID: 1192
			// (get) Token: 0x06001847 RID: 6215 RVA: 0x00038A70 File Offset: 0x00036C70
			// (set) Token: 0x06001848 RID: 6216 RVA: 0x00038A78 File Offset: 0x00036C78
			[JsonPropertyName("broadcaster_login")]
			public string BroadcasterLogin { get; set; }

			// Token: 0x170004A9 RID: 1193
			// (get) Token: 0x06001849 RID: 6217 RVA: 0x00038A81 File Offset: 0x00036C81
			// (set) Token: 0x0600184A RID: 6218 RVA: 0x00038A89 File Offset: 0x00036C89
			[JsonPropertyName("broadcaster_name")]
			public string BroadcasterName { get; set; }

			// Token: 0x170004AA RID: 1194
			// (get) Token: 0x0600184B RID: 6219 RVA: 0x00038A92 File Offset: 0x00036C92
			// (set) Token: 0x0600184C RID: 6220 RVA: 0x00038A9A File Offset: 0x00036C9A
			[JsonPropertyName("broadcaster_language")]
			public string BroadcasterLanguage { get; set; }

			// Token: 0x170004AB RID: 1195
			// (get) Token: 0x0600184D RID: 6221 RVA: 0x00038AA3 File Offset: 0x00036CA3
			// (set) Token: 0x0600184E RID: 6222 RVA: 0x00038AAB File Offset: 0x00036CAB
			[JsonPropertyName("game_id")]
			public string GameId { get; set; }

			// Token: 0x170004AC RID: 1196
			// (get) Token: 0x0600184F RID: 6223 RVA: 0x00038AB4 File Offset: 0x00036CB4
			// (set) Token: 0x06001850 RID: 6224 RVA: 0x00038ABC File Offset: 0x00036CBC
			[JsonPropertyName("game_name")]
			public string GameName { get; set; }

			// Token: 0x170004AD RID: 1197
			// (get) Token: 0x06001851 RID: 6225 RVA: 0x00038AC5 File Offset: 0x00036CC5
			// (set) Token: 0x06001852 RID: 6226 RVA: 0x00038ACD File Offset: 0x00036CCD
			[JsonPropertyName("title")]
			public string Title { get; set; }

			// Token: 0x170004AE RID: 1198
			// (get) Token: 0x06001853 RID: 6227 RVA: 0x00038AD6 File Offset: 0x00036CD6
			// (set) Token: 0x06001854 RID: 6228 RVA: 0x00038ADE File Offset: 0x00036CDE
			[JsonPropertyName("delay")]
			public int Delay { get; set; }
		}

		// Token: 0x02000424 RID: 1060
		public class ChannelsResponse
		{
			// Token: 0x170004AF RID: 1199
			// (get) Token: 0x06001856 RID: 6230 RVA: 0x00038AEF File Offset: 0x00036CEF
			// (set) Token: 0x06001857 RID: 6231 RVA: 0x00038AF7 File Offset: 0x00036CF7
			[JsonPropertyName("data")]
			public TwitchAPI.ChannelResponse[] Channels { get; set; }

			// Token: 0x06001858 RID: 6232 RVA: 0x00038B00 File Offset: 0x00036D00
			public TwitchAPI.ChannelResponse FirstOrDefault()
			{
				if (this.Channels == null || this.Channels.Length == 0)
				{
					return null;
				}
				return this.Channels.FirstOrDefault<TwitchAPI.ChannelResponse>();
			}
		}

		// Token: 0x02000425 RID: 1061
		internal class CreateClipRequest
		{
			// Token: 0x170004B0 RID: 1200
			// (get) Token: 0x0600185A RID: 6234 RVA: 0x00038B28 File Offset: 0x00036D28
			// (set) Token: 0x0600185B RID: 6235 RVA: 0x00038B30 File Offset: 0x00036D30
			[JsonPropertyName("broadcaster_id")]
			public string BroadcasterId { get; set; }

			// Token: 0x170004B1 RID: 1201
			// (get) Token: 0x0600185C RID: 6236 RVA: 0x00038B39 File Offset: 0x00036D39
			// (set) Token: 0x0600185D RID: 6237 RVA: 0x00038B41 File Offset: 0x00036D41
			[JsonPropertyName("has_delay")]
			public bool HasDelay { get; set; }
		}

		// Token: 0x02000426 RID: 1062
		internal class CreateClipResponse
		{
			// Token: 0x170004B2 RID: 1202
			// (get) Token: 0x0600185F RID: 6239 RVA: 0x00038B52 File Offset: 0x00036D52
			// (set) Token: 0x06001860 RID: 6240 RVA: 0x00038B5A File Offset: 0x00036D5A
			[JsonPropertyName("edit_url")]
			public string EditUrl { get; set; }

			// Token: 0x170004B3 RID: 1203
			// (get) Token: 0x06001861 RID: 6241 RVA: 0x00038B63 File Offset: 0x00036D63
			// (set) Token: 0x06001862 RID: 6242 RVA: 0x00038B6B File Offset: 0x00036D6B
			[JsonPropertyName("id")]
			public string Id { get; set; }
		}

		// Token: 0x02000427 RID: 1063
		public class CreateClipsResponse
		{
			// Token: 0x170004B4 RID: 1204
			// (get) Token: 0x06001864 RID: 6244 RVA: 0x00038B7C File Offset: 0x00036D7C
			// (set) Token: 0x06001865 RID: 6245 RVA: 0x00038B84 File Offset: 0x00036D84
			[JsonPropertyName("data")]
			public TwitchAPI.CreateClipResponse[] Clips { get; set; }

			// Token: 0x06001866 RID: 6246 RVA: 0x00038B8D File Offset: 0x00036D8D
			public TwitchAPI.CreateClipResponse FirstOrDefault()
			{
				if (this.Clips == null || this.Clips.Length == 0)
				{
					return null;
				}
				return this.Clips.FirstOrDefault<TwitchAPI.CreateClipResponse>();
			}
		}

		// Token: 0x02000428 RID: 1064
		internal class CreatePollRequest
		{
			// Token: 0x170004B5 RID: 1205
			// (get) Token: 0x06001868 RID: 6248 RVA: 0x00038BB5 File Offset: 0x00036DB5
			// (set) Token: 0x06001869 RID: 6249 RVA: 0x00038BBD File Offset: 0x00036DBD
			[JsonPropertyName("broadcaster_id")]
			public string BroadcasterId { get; set; }

			// Token: 0x170004B6 RID: 1206
			// (get) Token: 0x0600186A RID: 6250 RVA: 0x00038BC6 File Offset: 0x00036DC6
			// (set) Token: 0x0600186B RID: 6251 RVA: 0x00038BCE File Offset: 0x00036DCE
			[JsonPropertyName("title")]
			public string Title { get; set; }

			// Token: 0x170004B7 RID: 1207
			// (get) Token: 0x0600186C RID: 6252 RVA: 0x00038BD7 File Offset: 0x00036DD7
			// (set) Token: 0x0600186D RID: 6253 RVA: 0x00038BDF File Offset: 0x00036DDF
			[JsonPropertyName("choices")]
			public TwitchAPI.CreatePollRequest.Choice[] Choices { get; set; }

			// Token: 0x170004B8 RID: 1208
			// (get) Token: 0x0600186E RID: 6254 RVA: 0x00038BE8 File Offset: 0x00036DE8
			// (set) Token: 0x0600186F RID: 6255 RVA: 0x00038BF0 File Offset: 0x00036DF0
			[JsonPropertyName("duration")]
			public int Duration { get; set; }

			// Token: 0x0200048D RID: 1165
			internal class Choice
			{
				// Token: 0x17000501 RID: 1281
				// (get) Token: 0x060019E6 RID: 6630 RVA: 0x0003E77A File Offset: 0x0003C97A
				// (set) Token: 0x060019E7 RID: 6631 RVA: 0x0003E782 File Offset: 0x0003C982
				[JsonPropertyName("title")]
				public string Title { get; set; }
			}
		}

		// Token: 0x02000429 RID: 1065
		internal class EndPollRequest
		{
			// Token: 0x170004B9 RID: 1209
			// (get) Token: 0x06001871 RID: 6257 RVA: 0x00038C01 File Offset: 0x00036E01
			// (set) Token: 0x06001872 RID: 6258 RVA: 0x00038C09 File Offset: 0x00036E09
			[JsonPropertyName("broadcaster_id")]
			public string BroadcasterId { get; set; }

			// Token: 0x170004BA RID: 1210
			// (get) Token: 0x06001873 RID: 6259 RVA: 0x00038C12 File Offset: 0x00036E12
			// (set) Token: 0x06001874 RID: 6260 RVA: 0x00038C1A File Offset: 0x00036E1A
			[JsonPropertyName("id")]
			public string Id { get; set; }

			// Token: 0x170004BB RID: 1211
			// (get) Token: 0x06001875 RID: 6261 RVA: 0x00038C23 File Offset: 0x00036E23
			// (set) Token: 0x06001876 RID: 6262 RVA: 0x00038C2B File Offset: 0x00036E2B
			[JsonPropertyName("status")]
			public string Status { get; set; }
		}

		// Token: 0x0200042A RID: 1066
		internal class PollResponse
		{
			// Token: 0x170004BC RID: 1212
			// (get) Token: 0x06001878 RID: 6264 RVA: 0x00038C3C File Offset: 0x00036E3C
			// (set) Token: 0x06001879 RID: 6265 RVA: 0x00038C44 File Offset: 0x00036E44
			[JsonPropertyName("id")]
			public string Id { get; set; }

			// Token: 0x170004BD RID: 1213
			// (get) Token: 0x0600187A RID: 6266 RVA: 0x00038C4D File Offset: 0x00036E4D
			// (set) Token: 0x0600187B RID: 6267 RVA: 0x00038C55 File Offset: 0x00036E55
			[JsonPropertyName("broadcaster_id")]
			public string BroadcasterId { get; set; }

			// Token: 0x170004BE RID: 1214
			// (get) Token: 0x0600187C RID: 6268 RVA: 0x00038C5E File Offset: 0x00036E5E
			// (set) Token: 0x0600187D RID: 6269 RVA: 0x00038C66 File Offset: 0x00036E66
			[JsonPropertyName("broadcaster_name")]
			public string BroadcasterName { get; set; }

			// Token: 0x170004BF RID: 1215
			// (get) Token: 0x0600187E RID: 6270 RVA: 0x00038C6F File Offset: 0x00036E6F
			// (set) Token: 0x0600187F RID: 6271 RVA: 0x00038C77 File Offset: 0x00036E77
			[JsonPropertyName("broadcaster_login")]
			public string BroadcasterLogin { get; set; }

			// Token: 0x170004C0 RID: 1216
			// (get) Token: 0x06001880 RID: 6272 RVA: 0x00038C80 File Offset: 0x00036E80
			// (set) Token: 0x06001881 RID: 6273 RVA: 0x00038C88 File Offset: 0x00036E88
			[JsonPropertyName("title")]
			public string Title { get; set; }

			// Token: 0x170004C1 RID: 1217
			// (get) Token: 0x06001882 RID: 6274 RVA: 0x00038C91 File Offset: 0x00036E91
			// (set) Token: 0x06001883 RID: 6275 RVA: 0x00038C99 File Offset: 0x00036E99
			[JsonPropertyName("choices")]
			public TwitchAPI.PollResponse.Choice[] Choices { get; set; }

			// Token: 0x170004C2 RID: 1218
			// (get) Token: 0x06001884 RID: 6276 RVA: 0x00038CA2 File Offset: 0x00036EA2
			// (set) Token: 0x06001885 RID: 6277 RVA: 0x00038CAA File Offset: 0x00036EAA
			[JsonPropertyName("bits_voting_enabled")]
			public bool BitsVotingEnabled { get; set; }

			// Token: 0x170004C3 RID: 1219
			// (get) Token: 0x06001886 RID: 6278 RVA: 0x00038CB3 File Offset: 0x00036EB3
			// (set) Token: 0x06001887 RID: 6279 RVA: 0x00038CBB File Offset: 0x00036EBB
			[JsonPropertyName("bits_per_vote")]
			public int BitsPerVote { get; set; }

			// Token: 0x170004C4 RID: 1220
			// (get) Token: 0x06001888 RID: 6280 RVA: 0x00038CC4 File Offset: 0x00036EC4
			// (set) Token: 0x06001889 RID: 6281 RVA: 0x00038CCC File Offset: 0x00036ECC
			[JsonPropertyName("channel_points_voting_enabled")]
			public bool ChannelPointsVotingEnabled { get; set; }

			// Token: 0x170004C5 RID: 1221
			// (get) Token: 0x0600188A RID: 6282 RVA: 0x00038CD5 File Offset: 0x00036ED5
			// (set) Token: 0x0600188B RID: 6283 RVA: 0x00038CDD File Offset: 0x00036EDD
			[JsonPropertyName("channel_points_per_vote")]
			public int ChannelPointsPerVote { get; set; }

			// Token: 0x170004C6 RID: 1222
			// (get) Token: 0x0600188C RID: 6284 RVA: 0x00038CE6 File Offset: 0x00036EE6
			// (set) Token: 0x0600188D RID: 6285 RVA: 0x00038CEE File Offset: 0x00036EEE
			[JsonPropertyName("status")]
			public string Status { get; set; }

			// Token: 0x170004C7 RID: 1223
			// (get) Token: 0x0600188E RID: 6286 RVA: 0x00038CF7 File Offset: 0x00036EF7
			// (set) Token: 0x0600188F RID: 6287 RVA: 0x00038CFF File Offset: 0x00036EFF
			[JsonPropertyName("duration")]
			public int Duration { get; set; }

			// Token: 0x170004C8 RID: 1224
			// (get) Token: 0x06001890 RID: 6288 RVA: 0x00038D08 File Offset: 0x00036F08
			// (set) Token: 0x06001891 RID: 6289 RVA: 0x00038D10 File Offset: 0x00036F10
			[JsonPropertyName("started_at")]
			public string StartedAt { get; set; }

			// Token: 0x170004C9 RID: 1225
			// (get) Token: 0x06001892 RID: 6290 RVA: 0x00038D19 File Offset: 0x00036F19
			// (set) Token: 0x06001893 RID: 6291 RVA: 0x00038D21 File Offset: 0x00036F21
			[JsonPropertyName("ended_at")]
			public string EndedAt { get; set; }

			// Token: 0x0200048E RID: 1166
			internal class Choice
			{
				// Token: 0x17000502 RID: 1282
				// (get) Token: 0x060019E9 RID: 6633 RVA: 0x0003E793 File Offset: 0x0003C993
				// (set) Token: 0x060019EA RID: 6634 RVA: 0x0003E79B File Offset: 0x0003C99B
				[JsonPropertyName("id")]
				public string Id { get; set; }

				// Token: 0x17000503 RID: 1283
				// (get) Token: 0x060019EB RID: 6635 RVA: 0x0003E7A4 File Offset: 0x0003C9A4
				// (set) Token: 0x060019EC RID: 6636 RVA: 0x0003E7AC File Offset: 0x0003C9AC
				[JsonPropertyName("title")]
				public string Title { get; set; }

				// Token: 0x17000504 RID: 1284
				// (get) Token: 0x060019ED RID: 6637 RVA: 0x0003E7B5 File Offset: 0x0003C9B5
				// (set) Token: 0x060019EE RID: 6638 RVA: 0x0003E7BD File Offset: 0x0003C9BD
				[JsonPropertyName("votes")]
				public int Votes { get; set; }

				// Token: 0x17000505 RID: 1285
				// (get) Token: 0x060019EF RID: 6639 RVA: 0x0003E7C6 File Offset: 0x0003C9C6
				// (set) Token: 0x060019F0 RID: 6640 RVA: 0x0003E7CE File Offset: 0x0003C9CE
				[JsonPropertyName("channel_points_votes")]
				public int ChannelPointsVotes { get; set; }

				// Token: 0x17000506 RID: 1286
				// (get) Token: 0x060019F1 RID: 6641 RVA: 0x0003E7D7 File Offset: 0x0003C9D7
				// (set) Token: 0x060019F2 RID: 6642 RVA: 0x0003E7DF File Offset: 0x0003C9DF
				[JsonPropertyName("bits_votes")]
				public int BitsVotes { get; set; }
			}
		}

		// Token: 0x0200042B RID: 1067
		internal class CreatePredictionRequest
		{
			// Token: 0x170004CA RID: 1226
			// (get) Token: 0x06001895 RID: 6293 RVA: 0x00038D32 File Offset: 0x00036F32
			// (set) Token: 0x06001896 RID: 6294 RVA: 0x00038D3A File Offset: 0x00036F3A
			[JsonPropertyName("broadcaster_id")]
			public string BroadcasterId { get; set; }

			// Token: 0x170004CB RID: 1227
			// (get) Token: 0x06001897 RID: 6295 RVA: 0x00038D43 File Offset: 0x00036F43
			// (set) Token: 0x06001898 RID: 6296 RVA: 0x00038D4B File Offset: 0x00036F4B
			[JsonPropertyName("title")]
			public string Title { get; set; }

			// Token: 0x170004CC RID: 1228
			// (get) Token: 0x06001899 RID: 6297 RVA: 0x00038D54 File Offset: 0x00036F54
			// (set) Token: 0x0600189A RID: 6298 RVA: 0x00038D5C File Offset: 0x00036F5C
			[JsonPropertyName("outcomes")]
			public TwitchAPI.CreatePredictionRequest.Outcome[] Outcomes { get; set; }

			// Token: 0x170004CD RID: 1229
			// (get) Token: 0x0600189B RID: 6299 RVA: 0x00038D65 File Offset: 0x00036F65
			// (set) Token: 0x0600189C RID: 6300 RVA: 0x00038D6D File Offset: 0x00036F6D
			[JsonPropertyName("prediction_window")]
			public int Duration { get; set; }

			// Token: 0x0200048F RID: 1167
			internal class Outcome
			{
				// Token: 0x17000507 RID: 1287
				// (get) Token: 0x060019F4 RID: 6644 RVA: 0x0003E7F0 File Offset: 0x0003C9F0
				// (set) Token: 0x060019F5 RID: 6645 RVA: 0x0003E7F8 File Offset: 0x0003C9F8
				[JsonPropertyName("title")]
				public string Title { get; set; }
			}
		}

		// Token: 0x0200042C RID: 1068
		internal class EndPredictionRequest
		{
			// Token: 0x170004CE RID: 1230
			// (get) Token: 0x0600189E RID: 6302 RVA: 0x00038D7E File Offset: 0x00036F7E
			// (set) Token: 0x0600189F RID: 6303 RVA: 0x00038D86 File Offset: 0x00036F86
			[JsonPropertyName("broadcaster_id")]
			public string BroadcasterId { get; set; }

			// Token: 0x170004CF RID: 1231
			// (get) Token: 0x060018A0 RID: 6304 RVA: 0x00038D8F File Offset: 0x00036F8F
			// (set) Token: 0x060018A1 RID: 6305 RVA: 0x00038D97 File Offset: 0x00036F97
			[JsonPropertyName("id")]
			public string Id { get; set; }

			// Token: 0x170004D0 RID: 1232
			// (get) Token: 0x060018A2 RID: 6306 RVA: 0x00038DA0 File Offset: 0x00036FA0
			// (set) Token: 0x060018A3 RID: 6307 RVA: 0x00038DA8 File Offset: 0x00036FA8
			[JsonPropertyName("status")]
			public string Status { get; set; }

			// Token: 0x170004D1 RID: 1233
			// (get) Token: 0x060018A4 RID: 6308 RVA: 0x00038DB1 File Offset: 0x00036FB1
			// (set) Token: 0x060018A5 RID: 6309 RVA: 0x00038DB9 File Offset: 0x00036FB9
			[JsonPropertyName("winning_outcome_id")]
			public string WinningOutcomeId { get; set; }
		}

		// Token: 0x0200042D RID: 1069
		internal class PredictionResponse
		{
			// Token: 0x170004D2 RID: 1234
			// (get) Token: 0x060018A7 RID: 6311 RVA: 0x00038DCA File Offset: 0x00036FCA
			// (set) Token: 0x060018A8 RID: 6312 RVA: 0x00038DD2 File Offset: 0x00036FD2
			[JsonPropertyName("id")]
			public string Id { get; set; }

			// Token: 0x170004D3 RID: 1235
			// (get) Token: 0x060018A9 RID: 6313 RVA: 0x00038DDB File Offset: 0x00036FDB
			// (set) Token: 0x060018AA RID: 6314 RVA: 0x00038DE3 File Offset: 0x00036FE3
			[JsonPropertyName("broadcaster_id")]
			public string BroadcasterId { get; set; }

			// Token: 0x170004D4 RID: 1236
			// (get) Token: 0x060018AB RID: 6315 RVA: 0x00038DEC File Offset: 0x00036FEC
			// (set) Token: 0x060018AC RID: 6316 RVA: 0x00038DF4 File Offset: 0x00036FF4
			[JsonPropertyName("broadcaster_login")]
			public string BroadcasterLogin { get; set; }

			// Token: 0x170004D5 RID: 1237
			// (get) Token: 0x060018AD RID: 6317 RVA: 0x00038DFD File Offset: 0x00036FFD
			// (set) Token: 0x060018AE RID: 6318 RVA: 0x00038E05 File Offset: 0x00037005
			[JsonPropertyName("broadcaster_name")]
			public string BroadcasterName { get; set; }

			// Token: 0x170004D6 RID: 1238
			// (get) Token: 0x060018AF RID: 6319 RVA: 0x00038E0E File Offset: 0x0003700E
			// (set) Token: 0x060018B0 RID: 6320 RVA: 0x00038E16 File Offset: 0x00037016
			[JsonPropertyName("title")]
			public string Title { get; set; }

			// Token: 0x170004D7 RID: 1239
			// (get) Token: 0x060018B1 RID: 6321 RVA: 0x00038E1F File Offset: 0x0003701F
			// (set) Token: 0x060018B2 RID: 6322 RVA: 0x00038E27 File Offset: 0x00037027
			[JsonPropertyName("winning_outcome_id")]
			public string WinningOutcomeId { get; set; }

			// Token: 0x170004D8 RID: 1240
			// (get) Token: 0x060018B3 RID: 6323 RVA: 0x00038E30 File Offset: 0x00037030
			// (set) Token: 0x060018B4 RID: 6324 RVA: 0x00038E38 File Offset: 0x00037038
			[JsonPropertyName("prediction_window")]
			public int PredictionWindow { get; set; }

			// Token: 0x170004D9 RID: 1241
			// (get) Token: 0x060018B5 RID: 6325 RVA: 0x00038E41 File Offset: 0x00037041
			// (set) Token: 0x060018B6 RID: 6326 RVA: 0x00038E49 File Offset: 0x00037049
			[JsonPropertyName("status")]
			public string Status { get; set; }

			// Token: 0x170004DA RID: 1242
			// (get) Token: 0x060018B7 RID: 6327 RVA: 0x00038E52 File Offset: 0x00037052
			// (set) Token: 0x060018B8 RID: 6328 RVA: 0x00038E5A File Offset: 0x0003705A
			[JsonPropertyName("created_at")]
			public string CreatedAt { get; set; }

			// Token: 0x170004DB RID: 1243
			// (get) Token: 0x060018B9 RID: 6329 RVA: 0x00038E63 File Offset: 0x00037063
			// (set) Token: 0x060018BA RID: 6330 RVA: 0x00038E6B File Offset: 0x0003706B
			[JsonPropertyName("ended_at")]
			public string EndedAt { get; set; }

			// Token: 0x170004DC RID: 1244
			// (get) Token: 0x060018BB RID: 6331 RVA: 0x00038E74 File Offset: 0x00037074
			// (set) Token: 0x060018BC RID: 6332 RVA: 0x00038E7C File Offset: 0x0003707C
			[JsonPropertyName("locked_at")]
			public string LockedAt { get; set; }

			// Token: 0x170004DD RID: 1245
			// (get) Token: 0x060018BD RID: 6333 RVA: 0x00038E85 File Offset: 0x00037085
			// (set) Token: 0x060018BE RID: 6334 RVA: 0x00038E8D File Offset: 0x0003708D
			[JsonPropertyName("outcomes")]
			public TwitchAPI.PredictionResponse.Outcome[] Outcomes { get; set; }

			// Token: 0x02000490 RID: 1168
			internal class Outcome
			{
				// Token: 0x17000508 RID: 1288
				// (get) Token: 0x060019F7 RID: 6647 RVA: 0x0003E809 File Offset: 0x0003CA09
				// (set) Token: 0x060019F8 RID: 6648 RVA: 0x0003E811 File Offset: 0x0003CA11
				[JsonPropertyName("id")]
				public string Id { get; set; }

				// Token: 0x17000509 RID: 1289
				// (get) Token: 0x060019F9 RID: 6649 RVA: 0x0003E81A File Offset: 0x0003CA1A
				// (set) Token: 0x060019FA RID: 6650 RVA: 0x0003E822 File Offset: 0x0003CA22
				[JsonPropertyName("title")]
				public string Title { get; set; }

				// Token: 0x1700050A RID: 1290
				// (get) Token: 0x060019FB RID: 6651 RVA: 0x0003E82B File Offset: 0x0003CA2B
				// (set) Token: 0x060019FC RID: 6652 RVA: 0x0003E833 File Offset: 0x0003CA33
				[JsonPropertyName("users")]
				public int Users { get; set; }

				// Token: 0x1700050B RID: 1291
				// (get) Token: 0x060019FD RID: 6653 RVA: 0x0003E83C File Offset: 0x0003CA3C
				// (set) Token: 0x060019FE RID: 6654 RVA: 0x0003E844 File Offset: 0x0003CA44
				[JsonPropertyName("channel_points")]
				public int ChannelPoints { get; set; }

				// Token: 0x1700050C RID: 1292
				// (get) Token: 0x060019FF RID: 6655 RVA: 0x0003E84D File Offset: 0x0003CA4D
				// (set) Token: 0x06001A00 RID: 6656 RVA: 0x0003E855 File Offset: 0x0003CA55
				[JsonPropertyName("color")]
				public string Color { get; set; }
			}
		}

		// Token: 0x0200042E RID: 1070
		public class StreamResponse
		{
			// Token: 0x170004DE RID: 1246
			// (get) Token: 0x060018C0 RID: 6336 RVA: 0x00038E9E File Offset: 0x0003709E
			// (set) Token: 0x060018C1 RID: 6337 RVA: 0x00038EA6 File Offset: 0x000370A6
			[JsonPropertyName("id")]
			public string Id { get; set; }

			// Token: 0x170004DF RID: 1247
			// (get) Token: 0x060018C2 RID: 6338 RVA: 0x00038EAF File Offset: 0x000370AF
			// (set) Token: 0x060018C3 RID: 6339 RVA: 0x00038EB7 File Offset: 0x000370B7
			[JsonPropertyName("user_id")]
			public string UserId { get; set; }

			// Token: 0x170004E0 RID: 1248
			// (get) Token: 0x060018C4 RID: 6340 RVA: 0x00038EC0 File Offset: 0x000370C0
			// (set) Token: 0x060018C5 RID: 6341 RVA: 0x00038EC8 File Offset: 0x000370C8
			[JsonPropertyName("user_login")]
			public string UserLogin { get; set; }

			// Token: 0x170004E1 RID: 1249
			// (get) Token: 0x060018C6 RID: 6342 RVA: 0x00038ED1 File Offset: 0x000370D1
			// (set) Token: 0x060018C7 RID: 6343 RVA: 0x00038ED9 File Offset: 0x000370D9
			[JsonPropertyName("user_name")]
			public string UserName { get; set; }

			// Token: 0x170004E2 RID: 1250
			// (get) Token: 0x060018C8 RID: 6344 RVA: 0x00038EE2 File Offset: 0x000370E2
			// (set) Token: 0x060018C9 RID: 6345 RVA: 0x00038EEA File Offset: 0x000370EA
			[JsonPropertyName("game_id")]
			public string GameId { get; set; }

			// Token: 0x170004E3 RID: 1251
			// (get) Token: 0x060018CA RID: 6346 RVA: 0x00038EF3 File Offset: 0x000370F3
			// (set) Token: 0x060018CB RID: 6347 RVA: 0x00038EFB File Offset: 0x000370FB
			[JsonPropertyName("game_name")]
			public string GameName { get; set; }

			// Token: 0x170004E4 RID: 1252
			// (get) Token: 0x060018CC RID: 6348 RVA: 0x00038F04 File Offset: 0x00037104
			// (set) Token: 0x060018CD RID: 6349 RVA: 0x00038F0C File Offset: 0x0003710C
			[JsonPropertyName("type")]
			public string Type { get; set; }

			// Token: 0x170004E5 RID: 1253
			// (get) Token: 0x060018CE RID: 6350 RVA: 0x00038F15 File Offset: 0x00037115
			// (set) Token: 0x060018CF RID: 6351 RVA: 0x00038F1D File Offset: 0x0003711D
			[JsonPropertyName("title")]
			public string Title { get; set; }

			// Token: 0x170004E6 RID: 1254
			// (get) Token: 0x060018D0 RID: 6352 RVA: 0x00038F26 File Offset: 0x00037126
			// (set) Token: 0x060018D1 RID: 6353 RVA: 0x00038F2E File Offset: 0x0003712E
			[JsonPropertyName("viewer_count")]
			public int ViewerCount { get; set; }

			// Token: 0x170004E7 RID: 1255
			// (get) Token: 0x060018D2 RID: 6354 RVA: 0x00038F37 File Offset: 0x00037137
			// (set) Token: 0x060018D3 RID: 6355 RVA: 0x00038F3F File Offset: 0x0003713F
			[JsonPropertyName("started_at")]
			public string StartedAt { get; set; }

			// Token: 0x170004E8 RID: 1256
			// (get) Token: 0x060018D4 RID: 6356 RVA: 0x00038F48 File Offset: 0x00037148
			// (set) Token: 0x060018D5 RID: 6357 RVA: 0x00038F50 File Offset: 0x00037150
			[JsonPropertyName("language")]
			public string Language { get; set; }

			// Token: 0x170004E9 RID: 1257
			// (get) Token: 0x060018D6 RID: 6358 RVA: 0x00038F59 File Offset: 0x00037159
			// (set) Token: 0x060018D7 RID: 6359 RVA: 0x00038F61 File Offset: 0x00037161
			[JsonPropertyName("thumbnail_url")]
			public string ThumbnailUrl { get; set; }

			// Token: 0x170004EA RID: 1258
			// (get) Token: 0x060018D8 RID: 6360 RVA: 0x00038F6A File Offset: 0x0003716A
			// (set) Token: 0x060018D9 RID: 6361 RVA: 0x00038F72 File Offset: 0x00037172
			[JsonPropertyName("tag_ids")]
			public string[] TagIds { get; set; }

			// Token: 0x170004EB RID: 1259
			// (get) Token: 0x060018DA RID: 6362 RVA: 0x00038F7B File Offset: 0x0003717B
			// (set) Token: 0x060018DB RID: 6363 RVA: 0x00038F83 File Offset: 0x00037183
			[JsonPropertyName("is_mature")]
			public bool IsMature { get; set; }
		}

		// Token: 0x0200042F RID: 1071
		public class StreamsResponse
		{
			// Token: 0x170004EC RID: 1260
			// (get) Token: 0x060018DD RID: 6365 RVA: 0x00038F94 File Offset: 0x00037194
			// (set) Token: 0x060018DE RID: 6366 RVA: 0x00038F9C File Offset: 0x0003719C
			[JsonPropertyName("data")]
			public TwitchAPI.StreamResponse[] Streams { get; set; }

			// Token: 0x060018DF RID: 6367 RVA: 0x00038FA5 File Offset: 0x000371A5
			public TwitchAPI.StreamResponse FirstOrDefault()
			{
				if (this.Streams == null || this.Streams.Length == 0)
				{
					return null;
				}
				return this.Streams.FirstOrDefault<TwitchAPI.StreamResponse>();
			}
		}

		// Token: 0x02000430 RID: 1072
		public class UserResponse
		{
			// Token: 0x170004ED RID: 1261
			// (get) Token: 0x060018E1 RID: 6369 RVA: 0x00038FCD File Offset: 0x000371CD
			// (set) Token: 0x060018E2 RID: 6370 RVA: 0x00038FD5 File Offset: 0x000371D5
			[JsonPropertyName("id")]
			public string Id { get; set; }

			// Token: 0x170004EE RID: 1262
			// (get) Token: 0x060018E3 RID: 6371 RVA: 0x00038FDE File Offset: 0x000371DE
			// (set) Token: 0x060018E4 RID: 6372 RVA: 0x00038FE6 File Offset: 0x000371E6
			[JsonPropertyName("login")]
			public string Login { get; set; }

			// Token: 0x170004EF RID: 1263
			// (get) Token: 0x060018E5 RID: 6373 RVA: 0x00038FEF File Offset: 0x000371EF
			// (set) Token: 0x060018E6 RID: 6374 RVA: 0x00038FF7 File Offset: 0x000371F7
			[JsonPropertyName("display_name")]
			public string DisplayName { get; set; }

			// Token: 0x170004F0 RID: 1264
			// (get) Token: 0x060018E7 RID: 6375 RVA: 0x00039000 File Offset: 0x00037200
			// (set) Token: 0x060018E8 RID: 6376 RVA: 0x00039008 File Offset: 0x00037208
			[JsonPropertyName("type")]
			public string UserType { get; set; }

			// Token: 0x170004F1 RID: 1265
			// (get) Token: 0x060018E9 RID: 6377 RVA: 0x00039011 File Offset: 0x00037211
			// (set) Token: 0x060018EA RID: 6378 RVA: 0x00039019 File Offset: 0x00037219
			[JsonPropertyName("broadcaster_type")]
			public string BroadcasterType { get; set; }

			// Token: 0x170004F2 RID: 1266
			// (get) Token: 0x060018EB RID: 6379 RVA: 0x00039022 File Offset: 0x00037222
			// (set) Token: 0x060018EC RID: 6380 RVA: 0x0003902A File Offset: 0x0003722A
			[JsonPropertyName("description")]
			public string Description { get; set; }

			// Token: 0x170004F3 RID: 1267
			// (get) Token: 0x060018ED RID: 6381 RVA: 0x00039033 File Offset: 0x00037233
			// (set) Token: 0x060018EE RID: 6382 RVA: 0x0003903B File Offset: 0x0003723B
			[JsonPropertyName("profile_image_url")]
			public string ProfileImageUrl { get; set; }

			// Token: 0x170004F4 RID: 1268
			// (get) Token: 0x060018EF RID: 6383 RVA: 0x00039044 File Offset: 0x00037244
			// (set) Token: 0x060018F0 RID: 6384 RVA: 0x0003904C File Offset: 0x0003724C
			[JsonPropertyName("offline_image_url")]
			public string OfflineImageUrl { get; set; }

			// Token: 0x170004F5 RID: 1269
			// (get) Token: 0x060018F1 RID: 6385 RVA: 0x00039055 File Offset: 0x00037255
			// (set) Token: 0x060018F2 RID: 6386 RVA: 0x0003905D File Offset: 0x0003725D
			[JsonPropertyName("view_count")]
			public int ViewCount { get; set; }

			// Token: 0x170004F6 RID: 1270
			// (get) Token: 0x060018F3 RID: 6387 RVA: 0x00039066 File Offset: 0x00037266
			// (set) Token: 0x060018F4 RID: 6388 RVA: 0x0003906E File Offset: 0x0003726E
			[JsonPropertyName("email")]
			public string Email { get; set; }

			// Token: 0x170004F7 RID: 1271
			// (get) Token: 0x060018F5 RID: 6389 RVA: 0x00039077 File Offset: 0x00037277
			// (set) Token: 0x060018F6 RID: 6390 RVA: 0x0003907F File Offset: 0x0003727F
			[JsonPropertyName("created_at")]
			public string CreatedAt { get; set; }
		}

		// Token: 0x02000431 RID: 1073
		public class UsersResponse
		{
			// Token: 0x170004F8 RID: 1272
			// (get) Token: 0x060018F8 RID: 6392 RVA: 0x00039090 File Offset: 0x00037290
			// (set) Token: 0x060018F9 RID: 6393 RVA: 0x00039098 File Offset: 0x00037298
			[JsonPropertyName("data")]
			public TwitchAPI.UserResponse[] Users { get; set; }

			// Token: 0x060018FA RID: 6394 RVA: 0x000390A1 File Offset: 0x000372A1
			public TwitchAPI.UserResponse FirstOrDefault()
			{
				if (this.Users == null || this.Users.Length == 0)
				{
					return null;
				}
				return this.Users.FirstOrDefault<TwitchAPI.UserResponse>();
			}
		}

		// Token: 0x02000432 RID: 1074
		public class UserFollowResponse
		{
			// Token: 0x170004F9 RID: 1273
			// (get) Token: 0x060018FC RID: 6396 RVA: 0x000390C9 File Offset: 0x000372C9
			// (set) Token: 0x060018FD RID: 6397 RVA: 0x000390D1 File Offset: 0x000372D1
			[JsonPropertyName("from_id")]
			public string FromId { get; set; }

			// Token: 0x170004FA RID: 1274
			// (get) Token: 0x060018FE RID: 6398 RVA: 0x000390DA File Offset: 0x000372DA
			// (set) Token: 0x060018FF RID: 6399 RVA: 0x000390E2 File Offset: 0x000372E2
			[JsonPropertyName("from_login")]
			public string FromLogin { get; set; }

			// Token: 0x170004FB RID: 1275
			// (get) Token: 0x06001900 RID: 6400 RVA: 0x000390EB File Offset: 0x000372EB
			// (set) Token: 0x06001901 RID: 6401 RVA: 0x000390F3 File Offset: 0x000372F3
			[JsonPropertyName("from_name")]
			public string FromName { get; set; }

			// Token: 0x170004FC RID: 1276
			// (get) Token: 0x06001902 RID: 6402 RVA: 0x000390FC File Offset: 0x000372FC
			// (set) Token: 0x06001903 RID: 6403 RVA: 0x00039104 File Offset: 0x00037304
			[JsonPropertyName("to_id")]
			public string ToId { get; set; }

			// Token: 0x170004FD RID: 1277
			// (get) Token: 0x06001904 RID: 6404 RVA: 0x0003910D File Offset: 0x0003730D
			// (set) Token: 0x06001905 RID: 6405 RVA: 0x00039115 File Offset: 0x00037315
			[JsonPropertyName("to_login")]
			public string ToLogin { get; set; }

			// Token: 0x170004FE RID: 1278
			// (get) Token: 0x06001906 RID: 6406 RVA: 0x0003911E File Offset: 0x0003731E
			// (set) Token: 0x06001907 RID: 6407 RVA: 0x00039126 File Offset: 0x00037326
			[JsonPropertyName("to_name")]
			public string ToName { get; set; }

			// Token: 0x170004FF RID: 1279
			// (get) Token: 0x06001908 RID: 6408 RVA: 0x0003912F File Offset: 0x0003732F
			// (set) Token: 0x06001909 RID: 6409 RVA: 0x00039137 File Offset: 0x00037337
			[JsonPropertyName("followed_at")]
			public string FollowedAt { get; set; }
		}

		// Token: 0x02000433 RID: 1075
		public class UserFollowsResponse
		{
			// Token: 0x17000500 RID: 1280
			// (get) Token: 0x0600190B RID: 6411 RVA: 0x00039148 File Offset: 0x00037348
			// (set) Token: 0x0600190C RID: 6412 RVA: 0x00039150 File Offset: 0x00037350
			[JsonPropertyName("data")]
			public TwitchAPI.UserFollowResponse[] UserFollows { get; set; }
		}
	}
}
