using System;
using System.Linq;
using System.Threading.Tasks;
using Sandbox.Engine;
using Sandbox.Twitch;

namespace Sandbox
{
	// Token: 0x020002D6 RID: 726
	public struct StreamPoll
	{
		// Token: 0x060012EE RID: 4846 RVA: 0x0002752C File Offset: 0x0002572C
		internal StreamPoll(TwitchAPI.PollResponse poll)
		{
			this.Id = poll.BroadcasterId;
			this.BroadcasterId = poll.BroadcasterLogin;
			this.BroadcasterName = poll.BroadcasterName;
			this.BroadcasterLogin = poll.BroadcasterLogin;
			this.Title = poll.Title;
			this.BitsVotingEnabled = poll.BitsVotingEnabled;
			this.BitsPerVote = poll.BitsPerVote;
			this.ChannelPointsVotingEnabled = poll.ChannelPointsVotingEnabled;
			this.ChannelPointsPerVote = poll.ChannelPointsPerVote;
			this.Status = poll.Status;
			this.Duration = poll.Duration;
			this.StartedAt = DateTimeOffset.Parse(poll.StartedAt);
			this.EndedAt = DateTimeOffset.Parse(poll.EndedAt);
			this.Choices = poll.Choices.Select((TwitchAPI.PollResponse.Choice choice) => new StreamPoll.Choice
			{
				Id = choice.Id,
				Title = choice.Title,
				Votes = choice.Votes,
				ChannelPointsVotes = choice.ChannelPointsVotes,
				BitsVotes = choice.BitsVotes
			}).ToArray<StreamPoll.Choice>();
		}

		/// <summary>
		/// End this poll, you can optionally archive the poll, otherwise just terminate it
		/// </summary>
		// Token: 0x060012EF RID: 4847 RVA: 0x00027614 File Offset: 0x00025814
		public Task<StreamPoll> End(bool archive = true)
		{
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.EndPoll(this.BroadcasterId, this.Id, archive);
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x060012F0 RID: 4848 RVA: 0x00027633 File Offset: 0x00025833
		// (set) Token: 0x060012F1 RID: 4849 RVA: 0x0002763B File Offset: 0x0002583B
		public string Id { readonly get; internal set; }

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x060012F2 RID: 4850 RVA: 0x00027644 File Offset: 0x00025844
		// (set) Token: 0x060012F3 RID: 4851 RVA: 0x0002764C File Offset: 0x0002584C
		public string BroadcasterId { readonly get; internal set; }

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x060012F4 RID: 4852 RVA: 0x00027655 File Offset: 0x00025855
		// (set) Token: 0x060012F5 RID: 4853 RVA: 0x0002765D File Offset: 0x0002585D
		public string BroadcasterName { readonly get; internal set; }

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x060012F6 RID: 4854 RVA: 0x00027666 File Offset: 0x00025866
		// (set) Token: 0x060012F7 RID: 4855 RVA: 0x0002766E File Offset: 0x0002586E
		public string BroadcasterLogin { readonly get; internal set; }

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x060012F8 RID: 4856 RVA: 0x00027677 File Offset: 0x00025877
		// (set) Token: 0x060012F9 RID: 4857 RVA: 0x0002767F File Offset: 0x0002587F
		public string Title { readonly get; internal set; }

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x060012FA RID: 4858 RVA: 0x00027688 File Offset: 0x00025888
		// (set) Token: 0x060012FB RID: 4859 RVA: 0x00027690 File Offset: 0x00025890
		public StreamPoll.Choice[] Choices { readonly get; internal set; }

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x060012FC RID: 4860 RVA: 0x00027699 File Offset: 0x00025899
		// (set) Token: 0x060012FD RID: 4861 RVA: 0x000276A1 File Offset: 0x000258A1
		public bool BitsVotingEnabled { readonly get; internal set; }

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x060012FE RID: 4862 RVA: 0x000276AA File Offset: 0x000258AA
		// (set) Token: 0x060012FF RID: 4863 RVA: 0x000276B2 File Offset: 0x000258B2
		public int BitsPerVote { readonly get; internal set; }

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06001300 RID: 4864 RVA: 0x000276BB File Offset: 0x000258BB
		// (set) Token: 0x06001301 RID: 4865 RVA: 0x000276C3 File Offset: 0x000258C3
		public bool ChannelPointsVotingEnabled { readonly get; internal set; }

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06001302 RID: 4866 RVA: 0x000276CC File Offset: 0x000258CC
		// (set) Token: 0x06001303 RID: 4867 RVA: 0x000276D4 File Offset: 0x000258D4
		public int ChannelPointsPerVote { readonly get; internal set; }

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06001304 RID: 4868 RVA: 0x000276DD File Offset: 0x000258DD
		// (set) Token: 0x06001305 RID: 4869 RVA: 0x000276E5 File Offset: 0x000258E5
		public string Status { readonly get; internal set; }

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06001306 RID: 4870 RVA: 0x000276EE File Offset: 0x000258EE
		// (set) Token: 0x06001307 RID: 4871 RVA: 0x000276F6 File Offset: 0x000258F6
		public int Duration { readonly get; internal set; }

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06001308 RID: 4872 RVA: 0x000276FF File Offset: 0x000258FF
		// (set) Token: 0x06001309 RID: 4873 RVA: 0x00027707 File Offset: 0x00025907
		public DateTimeOffset StartedAt { readonly get; internal set; }

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x0600130A RID: 4874 RVA: 0x00027710 File Offset: 0x00025910
		// (set) Token: 0x0600130B RID: 4875 RVA: 0x00027718 File Offset: 0x00025918
		public DateTimeOffset EndedAt { readonly get; internal set; }

		// Token: 0x0200041C RID: 1052
		public struct Choice
		{
			// Token: 0x17000498 RID: 1176
			// (get) Token: 0x06001814 RID: 6164 RVA: 0x0003852A File Offset: 0x0003672A
			// (set) Token: 0x06001815 RID: 6165 RVA: 0x00038532 File Offset: 0x00036732
			public string Id { readonly get; internal set; }

			// Token: 0x17000499 RID: 1177
			// (get) Token: 0x06001816 RID: 6166 RVA: 0x0003853B File Offset: 0x0003673B
			// (set) Token: 0x06001817 RID: 6167 RVA: 0x00038543 File Offset: 0x00036743
			public string Title { readonly get; internal set; }

			// Token: 0x1700049A RID: 1178
			// (get) Token: 0x06001818 RID: 6168 RVA: 0x0003854C File Offset: 0x0003674C
			// (set) Token: 0x06001819 RID: 6169 RVA: 0x00038554 File Offset: 0x00036754
			public int Votes { readonly get; internal set; }

			// Token: 0x1700049B RID: 1179
			// (get) Token: 0x0600181A RID: 6170 RVA: 0x0003855D File Offset: 0x0003675D
			// (set) Token: 0x0600181B RID: 6171 RVA: 0x00038565 File Offset: 0x00036765
			public int ChannelPointsVotes { readonly get; internal set; }

			// Token: 0x1700049C RID: 1180
			// (get) Token: 0x0600181C RID: 6172 RVA: 0x0003856E File Offset: 0x0003676E
			// (set) Token: 0x0600181D RID: 6173 RVA: 0x00038576 File Offset: 0x00036776
			public int BitsVotes { readonly get; internal set; }
		}
	}
}
