using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sandbox.Engine;

namespace Sandbox.Twitch
{
	// Token: 0x020002E4 RID: 740
	internal class TwitchService : IStreamService
	{
		// Token: 0x170003CE RID: 974
		// (get) Token: 0x0600139E RID: 5022 RVA: 0x000297F7 File Offset: 0x000279F7
		public StreamService ServiceType
		{
			get
			{
				return StreamService.Twitch;
			}
		}

		// Token: 0x0600139F RID: 5023 RVA: 0x000297FA File Offset: 0x000279FA
		public TwitchService()
		{
			this._client = new TwitchClient();
			this._api = new TwitchAPI();
		}

		// Token: 0x060013A0 RID: 5024 RVA: 0x00029818 File Offset: 0x00027A18
		public async Task<StreamUser> GetUser(string username)
		{
			TwitchAPI.UserResponse user = await this._api.GetUser(username);
			return new StreamUser
			{
				Id = user.Id,
				Login = user.Login,
				DisplayName = user.DisplayName,
				UserType = user.UserType,
				BroadcasterType = user.BroadcasterType,
				Description = user.Description,
				ProfileImageUrl = user.ProfileImageUrl,
				OfflineImageUrl = user.OfflineImageUrl,
				ViewCount = user.ViewCount,
				Email = user.Email,
				CreatedAt = DateTimeOffset.Parse(user.CreatedAt)
			};
		}

		// Token: 0x060013A1 RID: 5025 RVA: 0x00029864 File Offset: 0x00027A64
		public async Task<List<StreamUserFollow>> GetUserFollowing(string userId)
		{
			return (await this._api.GetUserFollowing(userId)).UserFollows.Select((TwitchAPI.UserFollowResponse follow) => new StreamUserFollow
			{
				UserId = follow.ToId,
				Username = follow.ToLogin,
				DisplayName = follow.ToName,
				CreatedAt = DateTimeOffset.Parse(follow.FollowedAt)
			}).ToList<StreamUserFollow>();
		}

		// Token: 0x060013A2 RID: 5026 RVA: 0x000298B0 File Offset: 0x00027AB0
		public async Task<List<StreamUserFollow>> GetUserFollowers(string userId)
		{
			return (await this._api.GetUserFollowers(userId)).UserFollows.Select((TwitchAPI.UserFollowResponse follow) => new StreamUserFollow
			{
				UserId = follow.FromId,
				Username = follow.FromLogin,
				DisplayName = follow.FromName,
				CreatedAt = DateTimeOffset.Parse(follow.FollowedAt)
			}).ToList<StreamUserFollow>();
		}

		// Token: 0x060013A3 RID: 5027 RVA: 0x000298FC File Offset: 0x00027AFC
		public async Task<StreamChannel?> GetChannel()
		{
			TwitchAPI.ChannelResponse channel = await this._api.GetChannel(this._client.Username);
			StreamChannel? result;
			if (channel == null)
			{
				result = null;
			}
			else
			{
				result = new StreamChannel?(new StreamChannel
				{
					UserId = channel.BroadcasterId,
					Username = channel.BroadcasterLogin,
					DisplayName = channel.BroadcasterName,
					Language = channel.BroadcasterLanguage,
					GameId = channel.GameId,
					GameName = channel.GameName,
					Title = channel.Title,
					Delay = channel.Delay
				});
			}
			return result;
		}

		// Token: 0x060013A4 RID: 5028 RVA: 0x00029940 File Offset: 0x00027B40
		public async Task<StreamPoll> CreatePoll(string userId, string title, int duration, string[] choices)
		{
			TwitchAPI.PollResponse poll = await this._api.CreatePoll(userId, title, duration, choices);
			return new StreamPoll(poll);
		}

		// Token: 0x060013A5 RID: 5029 RVA: 0x000299A4 File Offset: 0x00027BA4
		public async Task<StreamPoll> EndPoll(string userId, string pollId, bool archive)
		{
			TwitchAPI.PollResponse poll = await this._api.EndPoll(userId, pollId, archive);
			return new StreamPoll(poll);
		}

		// Token: 0x060013A6 RID: 5030 RVA: 0x00029A00 File Offset: 0x00027C00
		public async Task<StreamPrediction> CreatePrediction(string userId, string title, int duration, string firstOutcome, string secondOutcome)
		{
			TwitchAPI.PredictionResponse prediction = await this._api.CreatePrediction(userId, title, duration, firstOutcome, secondOutcome);
			return new StreamPrediction(prediction);
		}

		// Token: 0x060013A7 RID: 5031 RVA: 0x00029A70 File Offset: 0x00027C70
		public async Task<StreamPrediction> LockPrediction(string userId, string predictionId)
		{
			TwitchAPI.PredictionResponse prediction = await this._api.LockPrediction(userId, predictionId);
			return new StreamPrediction(prediction);
		}

		// Token: 0x060013A8 RID: 5032 RVA: 0x00029AC4 File Offset: 0x00027CC4
		public async Task<StreamPrediction> CancelPrediction(string userId, string predictionId)
		{
			TwitchAPI.PredictionResponse prediction = await this._api.CancelPrediction(userId, predictionId);
			return new StreamPrediction(prediction);
		}

		// Token: 0x060013A9 RID: 5033 RVA: 0x00029B18 File Offset: 0x00027D18
		public async Task<StreamPrediction> ResolvePrediction(string userId, string predictionId, string winningOutcomeId)
		{
			TwitchAPI.PredictionResponse prediction = await this._api.ResolvePrediction(userId, predictionId, winningOutcomeId);
			return new StreamPrediction(prediction);
		}

		// Token: 0x060013AA RID: 5034 RVA: 0x00029B74 File Offset: 0x00027D74
		public async Task<StreamClip> CreateClip(string userId, bool hasDelay)
		{
			TwitchAPI.CreateClipResponse clip = await this._api.CreateClip(userId, hasDelay);
			return new StreamClip(clip);
		}

		// Token: 0x060013AB RID: 5035 RVA: 0x00029BC7 File Offset: 0x00027DC7
		public void BanUser(string username, string reason)
		{
			this._client.BanUser(username, reason);
		}

		// Token: 0x060013AC RID: 5036 RVA: 0x00029BD6 File Offset: 0x00027DD6
		public void ClearChat()
		{
			this._client.ClearChat();
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x00029BE4 File Offset: 0x00027DE4
		public async Task<bool> Connect()
		{
			return await this._client.Connect();
		}

		// Token: 0x060013AE RID: 5038 RVA: 0x00029C27 File Offset: 0x00027E27
		public void Disconnect()
		{
			this._client.Disconnect();
		}

		// Token: 0x060013AF RID: 5039 RVA: 0x00029C34 File Offset: 0x00027E34
		public void JoinChannel(string channel)
		{
			this._client.JoinChannel(channel);
		}

		// Token: 0x060013B0 RID: 5040 RVA: 0x00029C42 File Offset: 0x00027E42
		public void LeaveChannel(string channel)
		{
			this._client.LeaveChannel(channel);
		}

		// Token: 0x060013B1 RID: 5041 RVA: 0x00029C50 File Offset: 0x00027E50
		public void SendMessage(string message)
		{
			this._client.SendMessage(message);
		}

		// Token: 0x060013B2 RID: 5042 RVA: 0x00029C5E File Offset: 0x00027E5E
		public void SetChannelDelay(int delay)
		{
			this._api.SetChannelDelay(Streamer.UserId, delay);
		}

		// Token: 0x060013B3 RID: 5043 RVA: 0x00029C71 File Offset: 0x00027E71
		public void SetChannelGame(string gameId)
		{
			this._api.SetChannelGame(Streamer.UserId, gameId);
		}

		// Token: 0x060013B4 RID: 5044 RVA: 0x00029C84 File Offset: 0x00027E84
		public void SetChannelLanguage(string language)
		{
			this._api.SetChannelLanguage(Streamer.UserId, language);
		}

		// Token: 0x060013B5 RID: 5045 RVA: 0x00029C97 File Offset: 0x00027E97
		public void SetChannelTitle(string title)
		{
			this._api.SetChannelTitle(Streamer.UserId, title);
		}

		// Token: 0x060013B6 RID: 5046 RVA: 0x00029CAA File Offset: 0x00027EAA
		public void TimeoutUser(string username, int duration, string reason)
		{
			this._client.TimeoutUser(username, duration, reason);
		}

		// Token: 0x060013B7 RID: 5047 RVA: 0x00029CBA File Offset: 0x00027EBA
		public void UnbanUser(string username)
		{
			this._client.UnbanUser(username);
		}

		// Token: 0x060013B8 RID: 5048 RVA: 0x00029CC8 File Offset: 0x00027EC8
		void IStreamService.Tick()
		{
			if (this.timeUntilUpdateBroadcast <= 0f)
			{
				this.timeUntilUpdateBroadcast = 30f;
				this.UpdateBroadcast();
			}
		}

		// Token: 0x060013B9 RID: 5049 RVA: 0x00029CF4 File Offset: 0x00027EF4
		private async void UpdateBroadcast()
		{
			int viewers = Streamer.CurrentBroadcast.ViewerCount;
			TwitchAPI.StreamResponse broadcast = await this._api.GetStream(this._client.UserId);
			if (broadcast != null)
			{
				Streamer.CurrentBroadcast = new StreamBroadcast(broadcast);
				if (viewers != Streamer.CurrentBroadcast.ViewerCount)
				{
					this.timeUntilUpdateBroadcast = 10f;
				}
			}
			else
			{
				Streamer.CurrentBroadcast = default(StreamBroadcast);
			}
		}

		// Token: 0x04001518 RID: 5400
		private readonly TwitchClient _client;

		// Token: 0x04001519 RID: 5401
		private readonly TwitchAPI _api;

		// Token: 0x0400151A RID: 5402
		private RealTimeUntil timeUntilUpdateBroadcast;
	}
}
