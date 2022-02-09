using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandbox
{
	// Token: 0x020002D1 RID: 721
	internal interface IStreamService
	{
		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06001298 RID: 4760
		StreamService ServiceType { get; }

		// Token: 0x06001299 RID: 4761
		Task<bool> Connect();

		// Token: 0x0600129A RID: 4762
		void Disconnect();

		// Token: 0x0600129B RID: 4763
		void SendMessage(string message);

		// Token: 0x0600129C RID: 4764
		void ClearChat();

		// Token: 0x0600129D RID: 4765
		void BanUser(string username, string reason);

		// Token: 0x0600129E RID: 4766
		void UnbanUser(string username);

		// Token: 0x0600129F RID: 4767
		void TimeoutUser(string username, int duration, string reason);

		// Token: 0x060012A0 RID: 4768
		void SetChannelGame(string gameId);

		// Token: 0x060012A1 RID: 4769
		void SetChannelLanguage(string language);

		// Token: 0x060012A2 RID: 4770
		void SetChannelTitle(string title);

		// Token: 0x060012A3 RID: 4771
		void SetChannelDelay(int delay);

		// Token: 0x060012A4 RID: 4772
		Task<StreamUser> GetUser(string username);

		// Token: 0x060012A5 RID: 4773
		Task<List<StreamUserFollow>> GetUserFollowing(string userId);

		// Token: 0x060012A6 RID: 4774
		Task<List<StreamUserFollow>> GetUserFollowers(string userId);

		// Token: 0x060012A7 RID: 4775
		Task<StreamChannel?> GetChannel();

		// Token: 0x060012A8 RID: 4776
		Task<StreamPoll> CreatePoll(string userId, string title, int duration, string[] choices);

		// Token: 0x060012A9 RID: 4777
		Task<StreamPoll> EndPoll(string userId, string pollId, bool archive = false);

		// Token: 0x060012AA RID: 4778
		Task<StreamPrediction> CreatePrediction(string userId, string title, int duration, string firstOutcome, string secondOutcome);

		// Token: 0x060012AB RID: 4779
		Task<StreamPrediction> LockPrediction(string userId, string predictionId);

		// Token: 0x060012AC RID: 4780
		Task<StreamPrediction> CancelPrediction(string userId, string predictionId);

		// Token: 0x060012AD RID: 4781
		Task<StreamPrediction> ResolvePrediction(string userId, string predictionId, string winningOutcomeId);

		// Token: 0x060012AE RID: 4782
		Task<StreamClip> CreateClip(string userId, bool hasDelay);

		// Token: 0x060012AF RID: 4783
		void Tick();
	}
}
