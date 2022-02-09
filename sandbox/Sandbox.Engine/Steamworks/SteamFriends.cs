using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks
{
	/// <summary>
	/// Undocumented Parental Settings
	/// </summary>
	// Token: 0x0200009D RID: 157
	internal class SteamFriends : SteamClientClass<SteamFriends>
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x00006D49 File Offset: 0x00004F49
		internal static ISteamFriends Internal
		{
			get
			{
				return SteamClientClass<SteamFriends>.Interface as ISteamFriends;
			}
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x00006D55 File Offset: 0x00004F55
		internal override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamFriends(server));
			SteamFriends.richPresence = new Dictionary<string, string>();
			this.InstallEvents();
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00006D74 File Offset: 0x00004F74
		internal void InstallEvents()
		{
			Dispatch.Install<PersonaStateChange_t>(delegate(PersonaStateChange_t x)
			{
				Action<Friend> onPersonaStateChange = SteamFriends.OnPersonaStateChange;
				if (onPersonaStateChange == null)
				{
					return;
				}
				onPersonaStateChange(new Friend(x.SteamID));
			}, false);
			Dispatch.Install<GameRichPresenceJoinRequested_t>(delegate(GameRichPresenceJoinRequested_t x)
			{
				Action<Friend, string> onGameRichPresenceJoinRequested = SteamFriends.OnGameRichPresenceJoinRequested;
				if (onGameRichPresenceJoinRequested == null)
				{
					return;
				}
				onGameRichPresenceJoinRequested(new Friend(x.SteamIDFriend), x.ConnectUTF8());
			}, false);
			Dispatch.Install<GameConnectedFriendChatMsg_t>(new Action<GameConnectedFriendChatMsg_t>(SteamFriends.OnFriendChatMessage), false);
			Dispatch.Install<GameConnectedClanChatMsg_t>(new Action<GameConnectedClanChatMsg_t>(SteamFriends.OnGameConnectedClanChatMessage), false);
			Dispatch.Install<GameOverlayActivated_t>(delegate(GameOverlayActivated_t x)
			{
				Action<bool> onGameOverlayActivated = SteamFriends.OnGameOverlayActivated;
				if (onGameOverlayActivated == null)
				{
					return;
				}
				onGameOverlayActivated(x.Active > 0);
			}, false);
			Dispatch.Install<GameServerChangeRequested_t>(delegate(GameServerChangeRequested_t x)
			{
				Action<string, string> onGameServerChangeRequested = SteamFriends.OnGameServerChangeRequested;
				if (onGameServerChangeRequested == null)
				{
					return;
				}
				onGameServerChangeRequested(x.ServerUTF8(), x.PasswordUTF8());
			}, false);
			Dispatch.Install<GameLobbyJoinRequested_t>(delegate(GameLobbyJoinRequested_t x)
			{
				Action<Lobby, SteamId> onGameLobbyJoinRequested = SteamFriends.OnGameLobbyJoinRequested;
				if (onGameLobbyJoinRequested == null)
				{
					return;
				}
				onGameLobbyJoinRequested(new Lobby(x.SteamIDLobby), x.SteamIDFriend);
			}, false);
			Dispatch.Install<FriendRichPresenceUpdate_t>(delegate(FriendRichPresenceUpdate_t x)
			{
				Action<Friend> onFriendRichPresenceUpdate = SteamFriends.OnFriendRichPresenceUpdate;
				if (onFriendRichPresenceUpdate == null)
				{
					return;
				}
				onFriendRichPresenceUpdate(new Friend(x.SteamIDFriend));
			}, false);
			Dispatch.Install<OverlayBrowserProtocolNavigation_t>(delegate(OverlayBrowserProtocolNavigation_t x)
			{
				Action<string> onOverlayBrowserProtocol = SteamFriends.OnOverlayBrowserProtocol;
				if (onOverlayBrowserProtocol == null)
				{
					return;
				}
				onOverlayBrowserProtocol(x.RgchURIUTF8());
			}, false);
		}

		/// <summary>
		/// Called when chat message has been received from a friend. You'll need to turn on
		/// ListenForFriendsMessages to recieve this. (friend, msgtype, message)
		/// </summary>
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600055F RID: 1375 RVA: 0x00006EA8 File Offset: 0x000050A8
		// (remove) Token: 0x06000560 RID: 1376 RVA: 0x00006EDC File Offset: 0x000050DC
		internal static event Action<Friend, string, string> OnChatMessage;

		/// <summary>
		/// Called when a chat message has been received in a Steam group chat that we are in. Associated Functions: JoinClanChatRoom. (friend, msgtype, message)
		/// </summary>
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000561 RID: 1377 RVA: 0x00006F10 File Offset: 0x00005110
		// (remove) Token: 0x06000562 RID: 1378 RVA: 0x00006F44 File Offset: 0x00005144
		internal static event Action<Friend, string, string> OnClanChatMessage;

		/// <summary>
		/// called when a friends' status changes
		/// </summary>
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000563 RID: 1379 RVA: 0x00006F78 File Offset: 0x00005178
		// (remove) Token: 0x06000564 RID: 1380 RVA: 0x00006FAC File Offset: 0x000051AC
		public static event Action<Friend> OnPersonaStateChange;

		/// <summary>
		/// Called when the user tries to join a game from their friends list
		/// rich presence will have been set with the "connect" key which is set here
		/// </summary>
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000565 RID: 1381 RVA: 0x00006FE0 File Offset: 0x000051E0
		// (remove) Token: 0x06000566 RID: 1382 RVA: 0x00007014 File Offset: 0x00005214
		internal static event Action<Friend, string> OnGameRichPresenceJoinRequested;

		/// <summary>
		/// Posted when game overlay activates or deactivates
		/// the game can use this to be pause or resume single player games
		/// </summary>
		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000567 RID: 1383 RVA: 0x00007048 File Offset: 0x00005248
		// (remove) Token: 0x06000568 RID: 1384 RVA: 0x0000707C File Offset: 0x0000527C
		internal static event Action<bool> OnGameOverlayActivated;

		/// <summary>
		/// Called when the user tries to join a different game server from their friends list
		/// game client should attempt to connect to specified server when this is received
		/// </summary>
		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000569 RID: 1385 RVA: 0x000070B0 File Offset: 0x000052B0
		// (remove) Token: 0x0600056A RID: 1386 RVA: 0x000070E4 File Offset: 0x000052E4
		internal static event Action<string, string> OnGameServerChangeRequested;

		/// <summary>
		/// Called when the user tries to join a lobby from their friends list
		/// game client should attempt to connect to specified lobby when this is received
		/// </summary>
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x0600056B RID: 1387 RVA: 0x00007118 File Offset: 0x00005318
		// (remove) Token: 0x0600056C RID: 1388 RVA: 0x0000714C File Offset: 0x0000534C
		internal static event Action<Lobby, SteamId> OnGameLobbyJoinRequested;

		/// <summary>
		/// Callback indicating updated data about friends rich presence information
		/// </summary>
		// Token: 0x1400000A RID: 10
		// (add) Token: 0x0600056D RID: 1389 RVA: 0x00007180 File Offset: 0x00005380
		// (remove) Token: 0x0600056E RID: 1390 RVA: 0x000071B4 File Offset: 0x000053B4
		public static event Action<Friend> OnFriendRichPresenceUpdate;

		/// <summary>
		/// Dispatched when an overlay browser instance is navigated to a
		/// protocol/scheme registered by RegisterProtocolInOverlayBrowser()
		/// </summary>
		// Token: 0x1400000B RID: 11
		// (add) Token: 0x0600056F RID: 1391 RVA: 0x000071E8 File Offset: 0x000053E8
		// (remove) Token: 0x06000570 RID: 1392 RVA: 0x0000721C File Offset: 0x0000541C
		internal static event Action<string> OnOverlayBrowserProtocol;

		// Token: 0x06000571 RID: 1393 RVA: 0x00007250 File Offset: 0x00005450
		private static void OnFriendChatMessage(GameConnectedFriendChatMsg_t data)
		{
			if (SteamFriends.OnChatMessage == null)
			{
				return;
			}
			Friend friend = new Friend(data.SteamIDUser);
			Helpers.Memory buffer = Helpers.TakeMemory();
			ChatEntryType type = ChatEntryType.ChatMsg;
			if (SteamFriends.Internal.GetFriendMessage(data.SteamIDUser, data.MessageID, buffer, 32768, ref type) == 0 && type == ChatEntryType.Invalid)
			{
				return;
			}
			string typeName = type.ToString();
			string message = Helpers.MemoryToString(buffer);
			SteamFriends.OnChatMessage(friend, typeName, message);
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x000072D8 File Offset: 0x000054D8
		private static void OnGameConnectedClanChatMessage(GameConnectedClanChatMsg_t data)
		{
			if (SteamFriends.OnClanChatMessage == null)
			{
				return;
			}
			Friend friend = new Friend(data.SteamIDUser);
			Helpers.Memory buffer = Helpers.TakeMemory();
			ChatEntryType type = ChatEntryType.ChatMsg;
			SteamId chatter = data.SteamIDUser;
			if (SteamFriends.Internal.GetClanChatMessage(data.SteamIDClanChat, data.MessageID, buffer, 32768, ref type, ref chatter) == 0 && type == ChatEntryType.Invalid)
			{
				return;
			}
			string typeName = type.ToString();
			string message = Helpers.MemoryToString(buffer);
			SteamFriends.OnClanChatMessage(friend, typeName, message);
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x00007370 File Offset: 0x00005570
		private static IEnumerable<Friend> GetFriendsWithFlag(FriendFlags flag)
		{
			int num;
			for (int i = 0; i < SteamFriends.Internal.GetFriendCount((int)flag); i = num + 1)
			{
				yield return new Friend(SteamFriends.Internal.GetFriendByIndex(i, (int)flag));
				num = i;
			}
			yield break;
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x00007380 File Offset: 0x00005580
		public static IEnumerable<Friend> GetFriends()
		{
			return SteamFriends.GetFriendsWithFlag(FriendFlags.Immediate);
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x00007388 File Offset: 0x00005588
		internal static IEnumerable<Friend> GetBlocked()
		{
			return SteamFriends.GetFriendsWithFlag(FriendFlags.Blocked);
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x00007390 File Offset: 0x00005590
		internal static IEnumerable<Friend> GetFriendsRequested()
		{
			return SteamFriends.GetFriendsWithFlag(FriendFlags.FriendshipRequested);
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x00007398 File Offset: 0x00005598
		internal static IEnumerable<Friend> GetFriendsClanMembers()
		{
			return SteamFriends.GetFriendsWithFlag(FriendFlags.ClanMember);
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x000073A0 File Offset: 0x000055A0
		internal static IEnumerable<Friend> GetFriendsOnGameServer()
		{
			return SteamFriends.GetFriendsWithFlag(FriendFlags.OnGameServer);
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x000073A9 File Offset: 0x000055A9
		internal static IEnumerable<Friend> GetFriendsRequestingFriendship()
		{
			return SteamFriends.GetFriendsWithFlag(FriendFlags.RequestingFriendship);
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x000073B5 File Offset: 0x000055B5
		internal static IEnumerable<Friend> GetPlayedWith()
		{
			int num;
			for (int i = 0; i < SteamFriends.Internal.GetCoplayFriendCount(); i = num + 1)
			{
				yield return new Friend(SteamFriends.Internal.GetCoplayFriend(i));
				num = i;
			}
			yield break;
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x000073BE File Offset: 0x000055BE
		internal static IEnumerable<Friend> GetFromSource(SteamId steamid)
		{
			int num;
			for (int i = 0; i < SteamFriends.Internal.GetFriendCountFromSource(steamid); i = num + 1)
			{
				yield return new Friend(SteamFriends.Internal.GetFriendFromSourceByIndex(steamid, i));
				num = i;
			}
			yield break;
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x000073CE File Offset: 0x000055CE
		internal static IEnumerable<Clan> GetClans()
		{
			int num;
			for (int i = 0; i < SteamFriends.Internal.GetClanCount(); i = num + 1)
			{
				yield return new Clan(SteamFriends.Internal.GetClanByIndex(i));
				num = i;
			}
			yield break;
		}

		/// <summary>
		/// The dialog to open. Valid options are: 
		/// "friends", 
		/// "community", 
		/// "players", 
		/// "settings", 
		/// "officialgamegroup", 
		/// "stats", 
		/// "achievements".
		/// </summary>
		// Token: 0x0600057D RID: 1405 RVA: 0x000073D7 File Offset: 0x000055D7
		internal static void OpenOverlay(string type)
		{
			SteamFriends.Internal.ActivateGameOverlay(type);
		}

		/// <summary>
		/// "steamid" - Opens the overlay web browser to the specified user or groups profile.
		/// "chat" - Opens a chat window to the specified user, or joins the group chat.
		/// "jointrade" - Opens a window to a Steam Trading session that was started with the ISteamEconomy/StartTrade Web API.
		/// "stats" - Opens the overlay web browser to the specified user's stats.
		/// "achievements" - Opens the overlay web browser to the specified user's achievements.
		/// "friendadd" - Opens the overlay in minimal mode prompting the user to add the target user as a friend.
		/// "friendremove" - Opens the overlay in minimal mode prompting the user to remove the target friend.
		/// "friendrequestaccept" - Opens the overlay in minimal mode prompting the user to accept an incoming friend invite.
		/// "friendrequestignore" - Opens the overlay in minimal mode prompting the user to ignore an incoming friend invite.
		/// </summary>
		// Token: 0x0600057E RID: 1406 RVA: 0x000073E4 File Offset: 0x000055E4
		internal static void OpenUserOverlay(SteamId id, string type)
		{
			SteamFriends.Internal.ActivateGameOverlayToUser(type, id);
		}

		/// <summary>
		/// Activates the Steam Overlay to the Steam store page for the provided app.
		/// </summary>
		// Token: 0x0600057F RID: 1407 RVA: 0x000073F2 File Offset: 0x000055F2
		internal static void OpenStoreOverlay(AppId id, OverlayToStoreFlag overlayToStoreFlag = OverlayToStoreFlag.None)
		{
			SteamFriends.Internal.ActivateGameOverlayToStore(id.Value, overlayToStoreFlag);
		}

		/// <summary>
		/// Activates Steam Overlay web browser directly to the specified URL.
		/// </summary>
		// Token: 0x06000580 RID: 1408 RVA: 0x0000740A File Offset: 0x0000560A
		internal static void OpenWebOverlay(string url, bool modal = false)
		{
			SteamFriends.Internal.ActivateGameOverlayToWebPage(url, modal ? ActivateGameOverlayToWebPageMode.Modal : ActivateGameOverlayToWebPageMode.Default);
		}

		/// <summary>
		/// Activates the Steam Overlay to open the invite dialog. Invitations sent from this dialog will be for the provided lobby.
		/// </summary>
		// Token: 0x06000581 RID: 1409 RVA: 0x0000741E File Offset: 0x0000561E
		internal static void OpenGameInviteOverlay(SteamId lobby)
		{
			SteamFriends.Internal.ActivateGameOverlayInviteDialog(lobby);
		}

		/// <summary>
		/// Mark a target user as 'played with'.
		/// NOTE: The current user must be in game with the other player for the association to work.
		/// </summary>
		// Token: 0x06000582 RID: 1410 RVA: 0x0000742B File Offset: 0x0000562B
		internal static void SetPlayedWith(SteamId steamid)
		{
			SteamFriends.Internal.SetPlayedWith(steamid);
		}

		/// <summary>
		/// Requests the persona name and optionally the avatar of a specified user.
		/// NOTE: It's a lot slower to download avatars and churns the local cache, so if you don't need avatars, don't request them.
		/// returns true if we're fetching the data, false if we already have it
		/// </summary>
		// Token: 0x06000583 RID: 1411 RVA: 0x00007438 File Offset: 0x00005638
		internal static bool RequestUserInformation(SteamId steamid, bool nameonly = true)
		{
			return SteamFriends.Internal.RequestUserInformation(steamid, nameonly);
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00007448 File Offset: 0x00005648
		internal static async Task CacheUserInformationAsync(SteamId steamid, bool nameonly)
		{
			if (SteamFriends.RequestUserInformation(steamid, nameonly))
			{
				await Task.Delay(100);
				while (SteamFriends.RequestUserInformation(steamid, nameonly))
				{
					await Task.Delay(50);
				}
				await Task.Delay(500);
			}
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00007494 File Offset: 0x00005694
		internal static async Task<Image?> GetSmallAvatarAsync(SteamId steamid)
		{
			await SteamFriends.CacheUserInformationAsync(steamid, false);
			return SteamUtils.GetImage(SteamFriends.Internal.GetSmallFriendAvatar(steamid));
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x000074D8 File Offset: 0x000056D8
		internal static async Task<Image?> GetMediumAvatarAsync(SteamId steamid)
		{
			await SteamFriends.CacheUserInformationAsync(steamid, false);
			return SteamUtils.GetImage(SteamFriends.Internal.GetMediumFriendAvatar(steamid));
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x0000751C File Offset: 0x0000571C
		internal static async Task<Image?> GetLargeAvatarAsync(SteamId steamid)
		{
			await SteamFriends.CacheUserInformationAsync(steamid, false);
			int imageid;
			for (imageid = SteamFriends.Internal.GetLargeFriendAvatar(steamid); imageid == -1; imageid = SteamFriends.Internal.GetLargeFriendAvatar(steamid))
			{
				await Task.Delay(50);
			}
			return SteamUtils.GetImage(imageid);
		}

		/// <summary>
		/// Find a rich presence value by key for current user. Will be null if not found.
		/// </summary>
		// Token: 0x06000588 RID: 1416 RVA: 0x00007560 File Offset: 0x00005760
		internal static string GetRichPresence(string key)
		{
			string val;
			if (SteamFriends.richPresence.TryGetValue(key, out val))
			{
				return val;
			}
			return null;
		}

		/// <summary>
		/// Sets a rich presence value by key for current user.
		/// </summary>
		// Token: 0x06000589 RID: 1417 RVA: 0x0000757F File Offset: 0x0000577F
		internal static bool SetRichPresence(string key, string value)
		{
			bool flag = SteamFriends.Internal.SetRichPresence(key, value);
			if (flag)
			{
				SteamFriends.richPresence[key] = value;
			}
			return flag;
		}

		/// <summary>
		/// Clears all of the current user's rich presence data.
		/// </summary>
		// Token: 0x0600058A RID: 1418 RVA: 0x0000759C File Offset: 0x0000579C
		internal static void ClearRichPresence()
		{
			SteamFriends.richPresence.Clear();
			SteamFriends.Internal.ClearRichPresence();
		}

		/// <summary>
		/// Listens for Steam friends chat messages.
		/// You can then show these chats inline in the game. For example with a Blizzard style chat message system or the chat system in Dota 2.
		/// After enabling this you will receive callbacks when ever the user receives a chat message.
		/// </summary>
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x000075B2 File Offset: 0x000057B2
		// (set) Token: 0x0600058C RID: 1420 RVA: 0x000075B9 File Offset: 0x000057B9
		internal static bool ListenForFriendsMessages
		{
			get
			{
				return SteamFriends._listenForFriendsMessages;
			}
			set
			{
				SteamFriends._listenForFriendsMessages = value;
				SteamFriends.Internal.SetListenForFriendsMessages(value);
			}
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x000075D0 File Offset: 0x000057D0
		internal static async Task<bool> IsFollowing(SteamId steamID)
		{
			CallResult<FriendsIsFollowing_t> callResult = SteamFriends.Internal.IsFollowing(steamID).GetAwaiter();
			if (!callResult.IsCompleted)
			{
				await callResult;
				CallResult<FriendsIsFollowing_t> callResult2;
				callResult = callResult2;
				callResult2 = default(CallResult<FriendsIsFollowing_t>);
			}
			return callResult.GetResult().Value.IsFollowing;
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00007614 File Offset: 0x00005814
		internal static async Task<int> GetFollowerCount(SteamId steamID)
		{
			CallResult<FriendsGetFollowerCount_t> callResult = SteamFriends.Internal.GetFollowerCount(steamID).GetAwaiter();
			if (!callResult.IsCompleted)
			{
				await callResult;
				CallResult<FriendsGetFollowerCount_t> callResult2;
				callResult = callResult2;
				callResult2 = default(CallResult<FriendsGetFollowerCount_t>);
			}
			return callResult.GetResult().Value.Count;
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00007658 File Offset: 0x00005858
		internal static async Task<SteamId[]> GetFollowingList()
		{
			int resultCount = 0;
			List<SteamId> steamIds = new List<SteamId>();
			FriendsEnumerateFollowingList_t? result;
			do
			{
				FriendsEnumerateFollowingList_t? friendsEnumerateFollowingList_t = await SteamFriends.Internal.EnumerateFollowingList((uint)resultCount);
				FriendsEnumerateFollowingList_t? friendsEnumerateFollowingList_t2;
				result = (friendsEnumerateFollowingList_t2 = friendsEnumerateFollowingList_t);
				if (friendsEnumerateFollowingList_t2 != null)
				{
					resultCount += result.Value.ResultsReturned;
					Array.ForEach<ulong>(result.Value.GSteamID, delegate(ulong id)
					{
						if (id > 0UL)
						{
							steamIds.Add(id);
						}
					});
				}
			}
			while (result != null && resultCount < result.Value.TotalResultCount);
			return steamIds.ToArray();
		}

		/// <summary>
		/// Call this before calling ActivateGameOverlayToWebPage() to have the Steam Overlay Browser block navigations
		///  to your specified protocol (scheme) uris and instead dispatch a OverlayBrowserProtocolNavigation callback to your game.
		/// </summary>
		// Token: 0x06000590 RID: 1424 RVA: 0x00007693 File Offset: 0x00005893
		internal static bool RegisterProtocolInOverlayBrowser(string protocol)
		{
			return SteamFriends.Internal.RegisterProtocolInOverlayBrowser(protocol);
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x000076A0 File Offset: 0x000058A0
		internal static async Task<bool> JoinClanChatRoom(SteamId chatId)
		{
			JoinClanChatRoomCompletionResult_t? result = await SteamFriends.Internal.JoinClanChatRoom(chatId);
			bool result2;
			if (result == null)
			{
				result2 = false;
			}
			else
			{
				result2 = result.Value.ChatRoomEnterResponse == RoomEnter.Success;
			}
			return result2;
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x000076E3 File Offset: 0x000058E3
		internal static bool SendClanChatRoomMessage(SteamId chatId, string message)
		{
			return SteamFriends.Internal.SendClanChatMessage(chatId, message);
		}

		// Token: 0x040008EE RID: 2286
		private static Dictionary<string, string> richPresence;

		// Token: 0x040008F8 RID: 2296
		private static bool _listenForFriendsMessages;
	}
}
