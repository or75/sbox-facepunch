using System;
using Sandbox.Twitch;

namespace Sandbox
{
	// Token: 0x020002D2 RID: 722
	internal struct StreamBroadcast
	{
		// Token: 0x060012B0 RID: 4784 RVA: 0x00027258 File Offset: 0x00025458
		internal StreamBroadcast(TwitchAPI.StreamResponse stream)
		{
			this.Id = stream.Id;
			this.UserId = stream.UserId;
			this.Username = stream.UserLogin;
			this.DisplayName = stream.UserName;
			this.GameId = stream.GameId;
			this.GameName = stream.GameName;
			this.Type = stream.Type;
			this.Title = stream.Title;
			this.ViewerCount = stream.ViewerCount;
			this.StartedAt = DateTimeOffset.Parse(stream.StartedAt);
			this.Language = stream.Language;
			this.ThumbnailUrl = stream.ThumbnailUrl;
			this.TagIds = stream.TagIds;
			this.IsMature = stream.IsMature;
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x060012B1 RID: 4785 RVA: 0x00027312 File Offset: 0x00025512
		// (set) Token: 0x060012B2 RID: 4786 RVA: 0x0002731A File Offset: 0x0002551A
		public string Id { readonly get; internal set; }

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x060012B3 RID: 4787 RVA: 0x00027323 File Offset: 0x00025523
		// (set) Token: 0x060012B4 RID: 4788 RVA: 0x0002732B File Offset: 0x0002552B
		public string UserId { readonly get; internal set; }

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x060012B5 RID: 4789 RVA: 0x00027334 File Offset: 0x00025534
		// (set) Token: 0x060012B6 RID: 4790 RVA: 0x0002733C File Offset: 0x0002553C
		public string Username { readonly get; internal set; }

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x060012B7 RID: 4791 RVA: 0x00027345 File Offset: 0x00025545
		// (set) Token: 0x060012B8 RID: 4792 RVA: 0x0002734D File Offset: 0x0002554D
		public string DisplayName { readonly get; internal set; }

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x060012B9 RID: 4793 RVA: 0x00027356 File Offset: 0x00025556
		// (set) Token: 0x060012BA RID: 4794 RVA: 0x0002735E File Offset: 0x0002555E
		public string GameId { readonly get; internal set; }

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x060012BB RID: 4795 RVA: 0x00027367 File Offset: 0x00025567
		// (set) Token: 0x060012BC RID: 4796 RVA: 0x0002736F File Offset: 0x0002556F
		public string GameName { readonly get; internal set; }

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x060012BD RID: 4797 RVA: 0x00027378 File Offset: 0x00025578
		// (set) Token: 0x060012BE RID: 4798 RVA: 0x00027380 File Offset: 0x00025580
		public string Type { readonly get; internal set; }

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x060012BF RID: 4799 RVA: 0x00027389 File Offset: 0x00025589
		// (set) Token: 0x060012C0 RID: 4800 RVA: 0x00027391 File Offset: 0x00025591
		public string Title { readonly get; internal set; }

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x060012C1 RID: 4801 RVA: 0x0002739A File Offset: 0x0002559A
		// (set) Token: 0x060012C2 RID: 4802 RVA: 0x000273A2 File Offset: 0x000255A2
		public int ViewerCount { readonly get; internal set; }

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x060012C3 RID: 4803 RVA: 0x000273AB File Offset: 0x000255AB
		// (set) Token: 0x060012C4 RID: 4804 RVA: 0x000273B3 File Offset: 0x000255B3
		public DateTimeOffset StartedAt { readonly get; internal set; }

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x060012C5 RID: 4805 RVA: 0x000273BC File Offset: 0x000255BC
		// (set) Token: 0x060012C6 RID: 4806 RVA: 0x000273C4 File Offset: 0x000255C4
		public string Language { readonly get; internal set; }

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x060012C7 RID: 4807 RVA: 0x000273CD File Offset: 0x000255CD
		// (set) Token: 0x060012C8 RID: 4808 RVA: 0x000273D5 File Offset: 0x000255D5
		public string ThumbnailUrl { readonly get; internal set; }

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x060012C9 RID: 4809 RVA: 0x000273DE File Offset: 0x000255DE
		// (set) Token: 0x060012CA RID: 4810 RVA: 0x000273E6 File Offset: 0x000255E6
		public string[] TagIds { readonly get; internal set; }

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x060012CB RID: 4811 RVA: 0x000273EF File Offset: 0x000255EF
		// (set) Token: 0x060012CC RID: 4812 RVA: 0x000273F7 File Offset: 0x000255F7
		public bool IsMature { readonly get; internal set; }
	}
}
