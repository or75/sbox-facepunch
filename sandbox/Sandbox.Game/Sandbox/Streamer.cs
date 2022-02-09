using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sandbox.Engine;

namespace Sandbox
{
	// Token: 0x020000F6 RID: 246
	public static class Streamer
	{
		/// <summary>
		/// Your own username
		/// </summary>
		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06001471 RID: 5233 RVA: 0x000522A2 File Offset: 0x000504A2
		public static string Username
		{
			get
			{
				Host.AssertClientOrMenu("Username");
				return Streamer.Username;
			}
		}

		/// <summary>
		/// Your own user id
		/// </summary>
		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06001472 RID: 5234 RVA: 0x000522B3 File Offset: 0x000504B3
		public static string UserId
		{
			get
			{
				Host.AssertClientOrMenu("UserId");
				return Streamer.UserId;
			}
		}

		/// <summary>
		/// The service type (ie "Twitch")
		/// </summary>
		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06001473 RID: 5235 RVA: 0x000522C4 File Offset: 0x000504C4
		public static StreamService Service
		{
			get
			{
				Host.AssertClientOrMenu("Service");
				return Streamer.ServiceType;
			}
		}

		/// <summary>
		/// Are we connected to a service
		/// </summary>
		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06001474 RID: 5236 RVA: 0x000522D5 File Offset: 0x000504D5
		public static bool IsActive
		{
			get
			{
				Host.AssertClientOrMenu("IsActive");
				return Streamer.IsActive;
			}
		}

		/// <summary>
		/// Get user infomation. If no username is specified, the user returned is ourself
		/// </summary>
		// Token: 0x06001475 RID: 5237 RVA: 0x000522E6 File Offset: 0x000504E6
		public static Task<StreamUser> GetUser(string username = null)
		{
			Host.AssertClientOrMenu("GetUser");
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.GetUser(username);
		}

		/// <summary>
		/// Get user following "Who is X following"
		/// </summary>
		// Token: 0x06001476 RID: 5238 RVA: 0x00052303 File Offset: 0x00050503
		internal static Task<List<StreamUserFollow>> GetUserFollowing(string userId)
		{
			Host.AssertClientOrMenu("GetUserFollowing");
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.GetUserFollowing(userId);
		}

		/// <summary>
		/// Get user followers "Who is following X"
		/// </summary>
		// Token: 0x06001477 RID: 5239 RVA: 0x00052320 File Offset: 0x00050520
		internal static Task<List<StreamUserFollow>> GetUserFollowers(string userId)
		{
			Host.AssertClientOrMenu("GetUserFollowers");
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.GetUserFollowers(userId);
		}

		/// <summary>
		/// Start a poll with choices, save the poll id so you can end it later on
		/// </summary>
		// Token: 0x06001478 RID: 5240 RVA: 0x0005233D File Offset: 0x0005053D
		internal static Task<StreamPoll> CreatePoll(string userId, string title, int duration, string[] choices)
		{
			Host.AssertClientOrMenu("CreatePoll");
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.CreatePoll(userId, title, duration, choices);
		}

		/// <summary>
		/// End a poll using a saved poll id, you can optionally archive the poll or just terminate it
		/// </summary>
		// Token: 0x06001479 RID: 5241 RVA: 0x0005235D File Offset: 0x0005055D
		internal static Task<StreamPoll> EndPoll(string userId, string pollId, bool archive = true)
		{
			Host.AssertClientOrMenu("EndPoll");
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.EndPoll(userId, pollId, archive);
		}

		/// <summary>
		/// Create a prediction to bet with channel points
		/// </summary>
		// Token: 0x0600147A RID: 5242 RVA: 0x0005237C File Offset: 0x0005057C
		internal static Task<StreamPrediction> CreatePrediction(string userId, string title, int duration, string firstOutcome, string secondOutcome)
		{
			Host.AssertClientOrMenu("CreatePrediction");
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.CreatePrediction(userId, title, duration, firstOutcome, secondOutcome);
		}

		/// <summary>
		/// Lock a current prediction with prediction id
		/// </summary>
		// Token: 0x0600147B RID: 5243 RVA: 0x0005239E File Offset: 0x0005059E
		internal static Task<StreamPrediction> LockPrediction(string userId, string predictionId)
		{
			Host.AssertClientOrMenu("LockPrediction");
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.LockPrediction(userId, predictionId);
		}

		/// <summary>
		/// Cancel a current prediction with prediction id
		/// </summary>
		// Token: 0x0600147C RID: 5244 RVA: 0x000523BC File Offset: 0x000505BC
		internal static Task<StreamPrediction> CancelPrediction(string userId, string predictionId)
		{
			Host.AssertClientOrMenu("CancelPrediction");
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.CancelPrediction(userId, predictionId);
		}

		/// <summary>
		/// Resolve a current prediction with prediction id and choose winning outcome to pay out channel points
		/// </summary>
		// Token: 0x0600147D RID: 5245 RVA: 0x000523DA File Offset: 0x000505DA
		internal static Task<StreamPrediction> ResolvePrediction(string userId, string predictionId, string winningOutcomeId)
		{
			Host.AssertClientOrMenu("ResolvePrediction");
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.ResolvePrediction(userId, predictionId, winningOutcomeId);
		}

		// Token: 0x0600147E RID: 5246 RVA: 0x000523F9 File Offset: 0x000505F9
		internal static Task<StreamClip> CreateClip(string userId, bool hasDelay = false)
		{
			Host.AssertClientOrMenu("CreateClip");
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return null;
			}
			return currentService.CreateClip(userId, hasDelay);
		}

		/// <summary>
		/// Send a message to chat, optionally specifiy channel you want to send the message, otherwise it is sent to your own chat
		/// </summary>
		// Token: 0x0600147F RID: 5247 RVA: 0x00052417 File Offset: 0x00050617
		public static void SendMessage(string message)
		{
			Host.AssertClientOrMenu("SendMessage");
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return;
			}
			currentService.SendMessage(message);
		}

		/// <summary>
		/// Clear your own chat
		/// </summary>
		// Token: 0x06001480 RID: 5248 RVA: 0x00052433 File Offset: 0x00050633
		public static void ClearChat()
		{
			Host.AssertClientOrMenu("ClearChat");
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return;
			}
			currentService.ClearChat();
		}

		/// <summary>
		/// Ban user from your chat by username, the user will no longer be able to chat.
		/// Optionally specify the duration, a duration of zero means perm ban
		/// (Note: You have to be in your chat for this to work)
		/// </summary>
		// Token: 0x06001481 RID: 5249 RVA: 0x0005244E File Offset: 0x0005064E
		public static void BanUser(string username, string reason, int duration = 0)
		{
			Host.AssertClientOrMenu("BanUser");
			if (duration == 0)
			{
				IStreamService currentService = Streamer.CurrentService;
				if (currentService == null)
				{
					return;
				}
				currentService.BanUser(username, reason);
				return;
			}
			else
			{
				IStreamService currentService2 = Streamer.CurrentService;
				if (currentService2 == null)
				{
					return;
				}
				currentService2.TimeoutUser(username, duration, reason);
				return;
			}
		}

		/// <summary>
		/// Unban user from your chat by username
		/// (Note: You have to be in your chat for this to work)
		/// </summary>
		// Token: 0x06001482 RID: 5250 RVA: 0x00052481 File Offset: 0x00050681
		public static void UnbanUser(string username)
		{
			Host.AssertClientOrMenu("UnbanUser");
			IStreamService currentService = Streamer.CurrentService;
			if (currentService == null)
			{
				return;
			}
			currentService.UnbanUser(username);
		}

		/// <summary>
		/// Set the game you're playing by game id
		/// </summary>
		// Token: 0x1700030A RID: 778
		// (set) Token: 0x06001483 RID: 5251 RVA: 0x0005249D File Offset: 0x0005069D
		public static string Game
		{
			set
			{
				Host.AssertClientOrMenu("Game");
				IStreamService currentService = Streamer.CurrentService;
				if (currentService == null)
				{
					return;
				}
				currentService.SetChannelGame(value);
			}
		}

		/// <summary>
		/// Set the language of your stream
		/// </summary>
		// Token: 0x1700030B RID: 779
		// (set) Token: 0x06001484 RID: 5252 RVA: 0x000524B9 File Offset: 0x000506B9
		public static string Language
		{
			set
			{
				Host.AssertClientOrMenu("Language");
				IStreamService currentService = Streamer.CurrentService;
				if (currentService == null)
				{
					return;
				}
				currentService.SetChannelLanguage(value);
			}
		}

		/// <summary>
		/// Set the title of your stream
		/// </summary>
		// Token: 0x1700030C RID: 780
		// (set) Token: 0x06001485 RID: 5253 RVA: 0x000524D5 File Offset: 0x000506D5
		public static string Title
		{
			set
			{
				Host.AssertClientOrMenu("Title");
				IStreamService currentService = Streamer.CurrentService;
				if (currentService == null)
				{
					return;
				}
				currentService.SetChannelTitle(value);
			}
		}

		/// <summary>
		/// Set the delay of your stream
		/// </summary>
		// Token: 0x1700030D RID: 781
		// (set) Token: 0x06001486 RID: 5254 RVA: 0x000524F1 File Offset: 0x000506F1
		public static int Delay
		{
			set
			{
				Host.AssertClientOrMenu("Delay");
				IStreamService currentService = Streamer.CurrentService;
				if (currentService == null)
				{
					return;
				}
				currentService.SetChannelDelay(value);
			}
		}

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06001487 RID: 5255 RVA: 0x0005250D File Offset: 0x0005070D
		public static int ViewerCount
		{
			get
			{
				Host.AssertClientOrMenu("ViewerCount");
				return Streamer.CurrentBroadcast.ViewerCount;
			}
		}
	}
}
