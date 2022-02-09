using System;
using System.Linq;
using System.Threading.Tasks;
using Sandbox.Engine;
using Sandbox.Twitch;

namespace Sandbox
{
	// Token: 0x020002D7 RID: 727
	public struct StreamPrediction
	{
		// Token: 0x0600130C RID: 4876 RVA: 0x00027724 File Offset: 0x00025924
		internal StreamPrediction(TwitchAPI.PredictionResponse prediction)
		{
			this.Id = prediction.Id;
			this.BroadcasterId = prediction.BroadcasterId;
			this.BroadcasterName = prediction.BroadcasterName;
			this.BroadcasterLogin = prediction.BroadcasterLogin;
			this.Title = prediction.Title;
			this.WinningOutcomeId = prediction.WinningOutcomeId;
			this.PredictionWindow = prediction.PredictionWindow;
			this.Status = prediction.Status;
			this.CreatedAt = DateTimeOffset.Parse(prediction.CreatedAt);
			this.EndedAt = DateTimeOffset.Parse(prediction.EndedAt);
			this.LockedAt = DateTimeOffset.Parse(prediction.LockedAt);
			this.Outcomes = prediction.Outcomes.Select((TwitchAPI.PredictionResponse.Outcome choice) => new StreamPrediction.Outcome
			{
				Id = choice.Id,
				Title = choice.Title,
				Users = choice.Users,
				ChannelPoints = choice.ChannelPoints,
				Color = choice.Color
			}).ToArray<StreamPrediction.Outcome>();
		}

		/// <summary>
		/// Lock this prediction
		/// </summary>
		// Token: 0x0600130D RID: 4877 RVA: 0x000277F9 File Offset: 0x000259F9
		public Task<StreamPrediction> Lock()
		{
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.LockPrediction(this.BroadcasterId, this.Id);
		}

		/// <summary>
		/// Cancel this prediction
		/// </summary>
		// Token: 0x0600130E RID: 4878 RVA: 0x00027817 File Offset: 0x00025A17
		public Task<StreamPrediction> Cancel()
		{
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.CancelPrediction(this.BroadcasterId, this.Id);
		}

		/// <summary>
		/// Resolve this prediction and choose winning outcome to pay out channel points
		/// </summary>
		// Token: 0x0600130F RID: 4879 RVA: 0x00027835 File Offset: 0x00025A35
		public Task<StreamPrediction> Resolve()
		{
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.ResolvePrediction(this.BroadcasterId, this.Id, this.WinningOutcomeId);
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06001310 RID: 4880 RVA: 0x00027859 File Offset: 0x00025A59
		// (set) Token: 0x06001311 RID: 4881 RVA: 0x00027861 File Offset: 0x00025A61
		public string Id { readonly get; internal set; }

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06001312 RID: 4882 RVA: 0x0002786A File Offset: 0x00025A6A
		// (set) Token: 0x06001313 RID: 4883 RVA: 0x00027872 File Offset: 0x00025A72
		public string BroadcasterId { readonly get; internal set; }

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06001314 RID: 4884 RVA: 0x0002787B File Offset: 0x00025A7B
		// (set) Token: 0x06001315 RID: 4885 RVA: 0x00027883 File Offset: 0x00025A83
		public string BroadcasterLogin { readonly get; internal set; }

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06001316 RID: 4886 RVA: 0x0002788C File Offset: 0x00025A8C
		// (set) Token: 0x06001317 RID: 4887 RVA: 0x00027894 File Offset: 0x00025A94
		public string BroadcasterName { readonly get; internal set; }

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06001318 RID: 4888 RVA: 0x0002789D File Offset: 0x00025A9D
		// (set) Token: 0x06001319 RID: 4889 RVA: 0x000278A5 File Offset: 0x00025AA5
		public string Title { readonly get; internal set; }

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x0600131A RID: 4890 RVA: 0x000278AE File Offset: 0x00025AAE
		// (set) Token: 0x0600131B RID: 4891 RVA: 0x000278B6 File Offset: 0x00025AB6
		public string WinningOutcomeId { readonly get; internal set; }

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x0600131C RID: 4892 RVA: 0x000278BF File Offset: 0x00025ABF
		// (set) Token: 0x0600131D RID: 4893 RVA: 0x000278C7 File Offset: 0x00025AC7
		public int PredictionWindow { readonly get; internal set; }

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x0600131E RID: 4894 RVA: 0x000278D0 File Offset: 0x00025AD0
		// (set) Token: 0x0600131F RID: 4895 RVA: 0x000278D8 File Offset: 0x00025AD8
		public string Status { readonly get; internal set; }

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06001320 RID: 4896 RVA: 0x000278E1 File Offset: 0x00025AE1
		// (set) Token: 0x06001321 RID: 4897 RVA: 0x000278E9 File Offset: 0x00025AE9
		public DateTimeOffset CreatedAt { readonly get; internal set; }

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06001322 RID: 4898 RVA: 0x000278F2 File Offset: 0x00025AF2
		// (set) Token: 0x06001323 RID: 4899 RVA: 0x000278FA File Offset: 0x00025AFA
		public DateTimeOffset EndedAt { readonly get; internal set; }

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06001324 RID: 4900 RVA: 0x00027903 File Offset: 0x00025B03
		// (set) Token: 0x06001325 RID: 4901 RVA: 0x0002790B File Offset: 0x00025B0B
		public DateTimeOffset LockedAt { readonly get; internal set; }

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06001326 RID: 4902 RVA: 0x00027914 File Offset: 0x00025B14
		// (set) Token: 0x06001327 RID: 4903 RVA: 0x0002791C File Offset: 0x00025B1C
		public StreamPrediction.Outcome[] Outcomes { readonly get; internal set; }

		// Token: 0x0200041E RID: 1054
		public struct Outcome
		{
			// Token: 0x1700049D RID: 1181
			// (get) Token: 0x06001821 RID: 6177 RVA: 0x000385EB File Offset: 0x000367EB
			// (set) Token: 0x06001822 RID: 6178 RVA: 0x000385F3 File Offset: 0x000367F3
			public string Id { readonly get; internal set; }

			// Token: 0x1700049E RID: 1182
			// (get) Token: 0x06001823 RID: 6179 RVA: 0x000385FC File Offset: 0x000367FC
			// (set) Token: 0x06001824 RID: 6180 RVA: 0x00038604 File Offset: 0x00036804
			public string Title { readonly get; internal set; }

			// Token: 0x1700049F RID: 1183
			// (get) Token: 0x06001825 RID: 6181 RVA: 0x0003860D File Offset: 0x0003680D
			// (set) Token: 0x06001826 RID: 6182 RVA: 0x00038615 File Offset: 0x00036815
			public int Users { readonly get; internal set; }

			// Token: 0x170004A0 RID: 1184
			// (get) Token: 0x06001827 RID: 6183 RVA: 0x0003861E File Offset: 0x0003681E
			// (set) Token: 0x06001828 RID: 6184 RVA: 0x00038626 File Offset: 0x00036826
			public int ChannelPoints { readonly get; internal set; }

			// Token: 0x170004A1 RID: 1185
			// (get) Token: 0x06001829 RID: 6185 RVA: 0x0003862F File Offset: 0x0003682F
			// (set) Token: 0x0600182A RID: 6186 RVA: 0x00038637 File Offset: 0x00036837
			public string Color { readonly get; internal set; }
		}
	}
}
