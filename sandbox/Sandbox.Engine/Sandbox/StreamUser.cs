using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sandbox.Engine;

namespace Sandbox
{
	// Token: 0x020002D9 RID: 729
	public struct StreamUser
	{
		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x06001328 RID: 4904 RVA: 0x00027925 File Offset: 0x00025B25
		// (set) Token: 0x06001329 RID: 4905 RVA: 0x0002792D File Offset: 0x00025B2D
		public string Id { readonly get; internal set; }

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x0600132A RID: 4906 RVA: 0x00027936 File Offset: 0x00025B36
		// (set) Token: 0x0600132B RID: 4907 RVA: 0x0002793E File Offset: 0x00025B3E
		public string Login { readonly get; internal set; }

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x0600132C RID: 4908 RVA: 0x00027947 File Offset: 0x00025B47
		// (set) Token: 0x0600132D RID: 4909 RVA: 0x0002794F File Offset: 0x00025B4F
		public string DisplayName { readonly get; internal set; }

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x0600132E RID: 4910 RVA: 0x00027958 File Offset: 0x00025B58
		// (set) Token: 0x0600132F RID: 4911 RVA: 0x00027960 File Offset: 0x00025B60
		public string UserType { readonly get; internal set; }

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06001330 RID: 4912 RVA: 0x00027969 File Offset: 0x00025B69
		// (set) Token: 0x06001331 RID: 4913 RVA: 0x00027971 File Offset: 0x00025B71
		public string BroadcasterType { readonly get; internal set; }

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06001332 RID: 4914 RVA: 0x0002797A File Offset: 0x00025B7A
		// (set) Token: 0x06001333 RID: 4915 RVA: 0x00027982 File Offset: 0x00025B82
		public string Description { readonly get; internal set; }

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06001334 RID: 4916 RVA: 0x0002798B File Offset: 0x00025B8B
		// (set) Token: 0x06001335 RID: 4917 RVA: 0x00027993 File Offset: 0x00025B93
		public string ProfileImageUrl { readonly get; internal set; }

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06001336 RID: 4918 RVA: 0x0002799C File Offset: 0x00025B9C
		// (set) Token: 0x06001337 RID: 4919 RVA: 0x000279A4 File Offset: 0x00025BA4
		public string OfflineImageUrl { readonly get; internal set; }

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06001338 RID: 4920 RVA: 0x000279AD File Offset: 0x00025BAD
		// (set) Token: 0x06001339 RID: 4921 RVA: 0x000279B5 File Offset: 0x00025BB5
		public int ViewCount { readonly get; internal set; }

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x0600133A RID: 4922 RVA: 0x000279BE File Offset: 0x00025BBE
		// (set) Token: 0x0600133B RID: 4923 RVA: 0x000279C6 File Offset: 0x00025BC6
		public string Email { readonly get; internal set; }

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x0600133C RID: 4924 RVA: 0x000279CF File Offset: 0x00025BCF
		// (set) Token: 0x0600133D RID: 4925 RVA: 0x000279D7 File Offset: 0x00025BD7
		public DateTimeOffset CreatedAt { readonly get; internal set; }

		/// <summary>
		/// Get following "Who is following us"
		/// </summary>
		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x0600133E RID: 4926 RVA: 0x000279E0 File Offset: 0x00025BE0
		public Task<List<StreamUserFollow>> Following
		{
			get
			{
				IStreamService currentService = Streamer.CurrentService;
				if (currentService == null)
				{
					return null;
				}
				return currentService.GetUserFollowing(this.Id);
			}
		}

		/// <summary>
		/// Get followers "Who are we following"
		/// </summary>
		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x0600133F RID: 4927 RVA: 0x000279F8 File Offset: 0x00025BF8
		public Task<List<StreamUserFollow>> Followers
		{
			get
			{
				IStreamService currentService = Streamer.CurrentService;
				if (currentService == null)
				{
					return null;
				}
				return currentService.GetUserFollowers(this.Id);
			}
		}

		/// <summary>
		/// Ban user from your chat, the user will no longer be able to chat.
		/// Optionally specify the duration, a duration of zero means perm ban
		/// (Note: You have to be in your chat for this to work)
		/// </summary>
		// Token: 0x06001340 RID: 4928 RVA: 0x00027A10 File Offset: 0x00025C10
		public void Ban(string reason, int duration = 0)
		{
			if (duration == 0)
			{
				IStreamService currentService = Streamer.CurrentService;
				if (currentService == null)
				{
					return;
				}
				currentService.BanUser(this.Login, reason);
				return;
			}
			else
			{
				IStreamService currentService2 = Streamer.CurrentService;
				if (currentService2 == null)
				{
					return;
				}
				currentService2.TimeoutUser(this.Login, duration, reason);
				return;
			}
		}

		/// <summary>
		/// Unban user from your chat, this allows them to chat again
		/// (Note: You have to be in your chat for this to work)
		/// </summary>
		// Token: 0x06001341 RID: 4929 RVA: 0x00027A43 File Offset: 0x00025C43
		public void Unban()
		{
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return;
			}
			currentService.UnbanUser(this.Login);
		}

		/// <summary>
		/// Create a clip of our stream, if we're streaming
		/// </summary>
		// Token: 0x06001342 RID: 4930 RVA: 0x00027A5A File Offset: 0x00025C5A
		public Task<StreamClip> CreateClip(bool hasDelay = false)
		{
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.CreateClip(this.Id, hasDelay);
		}

		/// <summary>
		/// Start a poll on our channel with multiple choices, save the poll so you can end it later on
		/// </summary>
		// Token: 0x06001343 RID: 4931 RVA: 0x00027A73 File Offset: 0x00025C73
		public Task<StreamPoll> CreatePoll(string title, int duration, string[] choices)
		{
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.CreatePoll(this.Id, title, duration, choices);
		}

		/// <summary>
		/// Create a prediction on our channel to bet with channel points
		/// </summary>
		// Token: 0x06001344 RID: 4932 RVA: 0x00027A8E File Offset: 0x00025C8E
		public Task<StreamPrediction> CreatePrediction(string title, int duration, string firstOutcome, string secondOutcome)
		{
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.CreatePrediction(this.Id, title, duration, firstOutcome, secondOutcome);
		}
	}
}
