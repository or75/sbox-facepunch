using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks
{
	/// <summary>
	/// Functions for clients to access matchmaking services, favorites, and to operate on game lobbies
	/// </summary>
	// Token: 0x020000A0 RID: 160
	internal class SteamMatchmaking : SteamClientClass<SteamMatchmaking>
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x00007F07 File Offset: 0x00006107
		internal static ISteamMatchmaking Internal
		{
			get
			{
				return SteamClientClass<SteamMatchmaking>.Interface as ISteamMatchmaking;
			}
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x00007F13 File Offset: 0x00006113
		internal override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamMatchmaking(server));
			SteamMatchmaking.InstallEvents();
		}

		/// <summary>
		/// Maximum number of characters a lobby metadata key can be
		/// </summary>
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060005C2 RID: 1474 RVA: 0x00007F27 File Offset: 0x00006127
		internal static int MaxLobbyKeyLength
		{
			get
			{
				return 255;
			}
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x00007F30 File Offset: 0x00006130
		internal static void InstallEvents()
		{
			Dispatch.Install<LobbyInvite_t>(delegate(LobbyInvite_t x)
			{
				Action<Friend, Lobby> onLobbyInvite = SteamMatchmaking.OnLobbyInvite;
				if (onLobbyInvite == null)
				{
					return;
				}
				onLobbyInvite(new Friend(x.SteamIDUser), new Lobby(x.SteamIDLobby));
			}, false);
			Dispatch.Install<LobbyEnter_t>(delegate(LobbyEnter_t x)
			{
				Action<Lobby> onLobbyEntered = SteamMatchmaking.OnLobbyEntered;
				if (onLobbyEntered == null)
				{
					return;
				}
				onLobbyEntered(new Lobby(x.SteamIDLobby));
			}, false);
			Dispatch.Install<LobbyCreated_t>(delegate(LobbyCreated_t x)
			{
				Action<Result, Lobby> onLobbyCreated = SteamMatchmaking.OnLobbyCreated;
				if (onLobbyCreated == null)
				{
					return;
				}
				onLobbyCreated(x.Result, new Lobby(x.SteamIDLobby));
			}, false);
			Dispatch.Install<LobbyGameCreated_t>(delegate(LobbyGameCreated_t x)
			{
				Action<Lobby, uint, ushort, SteamId> onLobbyGameCreated = SteamMatchmaking.OnLobbyGameCreated;
				if (onLobbyGameCreated == null)
				{
					return;
				}
				onLobbyGameCreated(new Lobby(x.SteamIDLobby), x.IP, x.Port, x.SteamIDGameServer);
			}, false);
			Dispatch.Install<LobbyDataUpdate_t>(delegate(LobbyDataUpdate_t x)
			{
				if (x.Success == 0)
				{
					return;
				}
				if (x.SteamIDLobby == x.SteamIDMember)
				{
					Action<Lobby> onLobbyDataChanged = SteamMatchmaking.OnLobbyDataChanged;
					if (onLobbyDataChanged == null)
					{
						return;
					}
					onLobbyDataChanged(new Lobby(x.SteamIDLobby));
					return;
				}
				else
				{
					Action<Lobby, Friend> onLobbyMemberDataChanged = SteamMatchmaking.OnLobbyMemberDataChanged;
					if (onLobbyMemberDataChanged == null)
					{
						return;
					}
					onLobbyMemberDataChanged(new Lobby(x.SteamIDLobby), new Friend(x.SteamIDMember));
					return;
				}
			}, false);
			Dispatch.Install<LobbyChatUpdate_t>(delegate(LobbyChatUpdate_t x)
			{
				if ((x.GfChatMemberStateChange & 1U) != 0U)
				{
					Action<Lobby, Friend> onLobbyMemberJoined = SteamMatchmaking.OnLobbyMemberJoined;
					if (onLobbyMemberJoined != null)
					{
						onLobbyMemberJoined(new Lobby(x.SteamIDLobby), new Friend(x.SteamIDUserChanged));
					}
				}
				if ((x.GfChatMemberStateChange & 2U) != 0U)
				{
					Action<Lobby, Friend> onLobbyMemberLeave = SteamMatchmaking.OnLobbyMemberLeave;
					if (onLobbyMemberLeave != null)
					{
						onLobbyMemberLeave(new Lobby(x.SteamIDLobby), new Friend(x.SteamIDUserChanged));
					}
				}
				if ((x.GfChatMemberStateChange & 4U) != 0U)
				{
					Action<Lobby, Friend> onLobbyMemberDisconnected = SteamMatchmaking.OnLobbyMemberDisconnected;
					if (onLobbyMemberDisconnected != null)
					{
						onLobbyMemberDisconnected(new Lobby(x.SteamIDLobby), new Friend(x.SteamIDUserChanged));
					}
				}
				if ((x.GfChatMemberStateChange & 8U) != 0U)
				{
					Action<Lobby, Friend, Friend> onLobbyMemberKicked = SteamMatchmaking.OnLobbyMemberKicked;
					if (onLobbyMemberKicked != null)
					{
						onLobbyMemberKicked(new Lobby(x.SteamIDLobby), new Friend(x.SteamIDUserChanged), new Friend(x.SteamIDMakingChange));
					}
				}
				if ((x.GfChatMemberStateChange & 16U) != 0U)
				{
					Action<Lobby, Friend, Friend> onLobbyMemberBanned = SteamMatchmaking.OnLobbyMemberBanned;
					if (onLobbyMemberBanned == null)
					{
						return;
					}
					onLobbyMemberBanned(new Lobby(x.SteamIDLobby), new Friend(x.SteamIDUserChanged), new Friend(x.SteamIDMakingChange));
				}
			}, false);
			Dispatch.Install<LobbyChatMsg_t>(new Action<LobbyChatMsg_t>(SteamMatchmaking.OnLobbyChatMessageRecievedAPI), false);
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x00008030 File Offset: 0x00006230
		private static void OnLobbyChatMessageRecievedAPI(LobbyChatMsg_t callback)
		{
			SteamId steamid = default(SteamId);
			ChatEntryType chatEntryType = ChatEntryType.Invalid;
			Helpers.Memory buffer = Helpers.TakeMemory();
			try
			{
				int readData = SteamMatchmaking.Internal.GetLobbyChatEntry(callback.SteamIDLobby, (int)callback.ChatID, ref steamid, buffer, 32768, ref chatEntryType);
				if (readData > 0)
				{
					Action<Lobby, Friend, string> onChatMessage = SteamMatchmaking.OnChatMessage;
					if (onChatMessage != null)
					{
						onChatMessage(new Lobby(callback.SteamIDLobby), new Friend(steamid), Helpers.MemoryToString(buffer, readData));
					}
				}
			}
			finally
			{
				((IDisposable)buffer).Dispose();
			}
		}

		/// <summary>
		/// Someone invited you to a lobby
		/// </summary>
		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060005C5 RID: 1477 RVA: 0x000080D0 File Offset: 0x000062D0
		// (remove) Token: 0x060005C6 RID: 1478 RVA: 0x00008104 File Offset: 0x00006304
		internal static event Action<Friend, Lobby> OnLobbyInvite;

		/// <summary>
		/// You joined a lobby
		/// </summary>
		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060005C7 RID: 1479 RVA: 0x00008138 File Offset: 0x00006338
		// (remove) Token: 0x060005C8 RID: 1480 RVA: 0x0000816C File Offset: 0x0000636C
		internal static event Action<Lobby> OnLobbyEntered;

		/// <summary>
		/// You created a lobby
		/// </summary>
		// Token: 0x14000013 RID: 19
		// (add) Token: 0x060005C9 RID: 1481 RVA: 0x000081A0 File Offset: 0x000063A0
		// (remove) Token: 0x060005CA RID: 1482 RVA: 0x000081D4 File Offset: 0x000063D4
		internal static event Action<Result, Lobby> OnLobbyCreated;

		/// <summary>
		/// A game server has been associated with the lobby
		/// </summary>
		// Token: 0x14000014 RID: 20
		// (add) Token: 0x060005CB RID: 1483 RVA: 0x00008208 File Offset: 0x00006408
		// (remove) Token: 0x060005CC RID: 1484 RVA: 0x0000823C File Offset: 0x0000643C
		internal static event Action<Lobby, uint, ushort, SteamId> OnLobbyGameCreated;

		/// <summary>
		/// The lobby metadata has changed
		/// </summary>
		// Token: 0x14000015 RID: 21
		// (add) Token: 0x060005CD RID: 1485 RVA: 0x00008270 File Offset: 0x00006470
		// (remove) Token: 0x060005CE RID: 1486 RVA: 0x000082A4 File Offset: 0x000064A4
		internal static event Action<Lobby> OnLobbyDataChanged;

		/// <summary>
		/// The lobby member metadata has changed
		/// </summary>
		// Token: 0x14000016 RID: 22
		// (add) Token: 0x060005CF RID: 1487 RVA: 0x000082D8 File Offset: 0x000064D8
		// (remove) Token: 0x060005D0 RID: 1488 RVA: 0x0000830C File Offset: 0x0000650C
		internal static event Action<Lobby, Friend> OnLobbyMemberDataChanged;

		/// <summary>
		/// The lobby member joined
		/// </summary>
		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060005D1 RID: 1489 RVA: 0x00008340 File Offset: 0x00006540
		// (remove) Token: 0x060005D2 RID: 1490 RVA: 0x00008374 File Offset: 0x00006574
		internal static event Action<Lobby, Friend> OnLobbyMemberJoined;

		/// <summary>
		/// The lobby member left the room
		/// </summary>
		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060005D3 RID: 1491 RVA: 0x000083A8 File Offset: 0x000065A8
		// (remove) Token: 0x060005D4 RID: 1492 RVA: 0x000083DC File Offset: 0x000065DC
		internal static event Action<Lobby, Friend> OnLobbyMemberLeave;

		/// <summary>
		/// The lobby member left the room
		/// </summary>
		// Token: 0x14000019 RID: 25
		// (add) Token: 0x060005D5 RID: 1493 RVA: 0x00008410 File Offset: 0x00006610
		// (remove) Token: 0x060005D6 RID: 1494 RVA: 0x00008444 File Offset: 0x00006644
		internal static event Action<Lobby, Friend> OnLobbyMemberDisconnected;

		/// <summary>
		/// The lobby member was kicked. The 3rd param is the user that kicked them.
		/// </summary>
		// Token: 0x1400001A RID: 26
		// (add) Token: 0x060005D7 RID: 1495 RVA: 0x00008478 File Offset: 0x00006678
		// (remove) Token: 0x060005D8 RID: 1496 RVA: 0x000084AC File Offset: 0x000066AC
		internal static event Action<Lobby, Friend, Friend> OnLobbyMemberKicked;

		/// <summary>
		/// The lobby member was banned. The 3rd param is the user that banned them.
		/// </summary>
		// Token: 0x1400001B RID: 27
		// (add) Token: 0x060005D9 RID: 1497 RVA: 0x000084E0 File Offset: 0x000066E0
		// (remove) Token: 0x060005DA RID: 1498 RVA: 0x00008514 File Offset: 0x00006714
		internal static event Action<Lobby, Friend, Friend> OnLobbyMemberBanned;

		/// <summary>
		/// A chat message was recieved from a member of a lobby
		/// </summary>
		// Token: 0x1400001C RID: 28
		// (add) Token: 0x060005DB RID: 1499 RVA: 0x00008548 File Offset: 0x00006748
		// (remove) Token: 0x060005DC RID: 1500 RVA: 0x0000857C File Offset: 0x0000677C
		internal static event Action<Lobby, Friend, string> OnChatMessage;

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060005DD RID: 1501 RVA: 0x000085B0 File Offset: 0x000067B0
		internal static LobbyQuery LobbyList
		{
			get
			{
				return default(LobbyQuery);
			}
		}

		/// <summary>
		/// Creates a new invisible lobby. Call lobby.SetPublic to take it online.
		/// </summary>
		// Token: 0x060005DE RID: 1502 RVA: 0x000085C8 File Offset: 0x000067C8
		internal static async Task<Lobby?> CreateLobbyAsync(int maxMembers = 100)
		{
			LobbyCreated_t? lobby = await SteamMatchmaking.Internal.CreateLobby(LobbyType.Invisible, maxMembers);
			Lobby? result;
			if (lobby == null || lobby.Value.Result != Result.OK)
			{
				result = null;
			}
			else
			{
				result = new Lobby?(new Lobby
				{
					Id = lobby.Value.SteamIDLobby
				});
			}
			return result;
		}

		/// <summary>
		/// Attempts to directly join the specified lobby
		/// </summary>
		// Token: 0x060005DF RID: 1503 RVA: 0x0000860C File Offset: 0x0000680C
		internal static async Task<Lobby?> JoinLobbyAsync(SteamId lobbyId)
		{
			LobbyEnter_t? lobby = await SteamMatchmaking.Internal.JoinLobby(lobbyId);
			Lobby? result;
			if (lobby == null)
			{
				result = null;
			}
			else
			{
				result = new Lobby?(new Lobby
				{
					Id = lobby.Value.SteamIDLobby
				});
			}
			return result;
		}

		/// <summary>
		/// Get a list of servers that are on your favorites list
		/// </summary>
		// Token: 0x060005E0 RID: 1504 RVA: 0x0000864F File Offset: 0x0000684F
		internal static IEnumerable<ServerInfo> GetFavoriteServers()
		{
			int count = SteamMatchmaking.Internal.GetFavoriteGameCount();
			int num;
			for (int i = 0; i < count; i = num + 1)
			{
				uint timeplayed = 0U;
				uint flags = 0U;
				ushort qport = 0;
				ushort cport = 0;
				uint ip = 0U;
				AppId appid = default(AppId);
				if (SteamMatchmaking.Internal.GetFavoriteGame(i, ref appid, ref ip, ref cport, ref qport, ref flags, ref timeplayed) && (flags & 1U) != 0U)
				{
					yield return new ServerInfo(ip, cport, qport, timeplayed);
				}
				num = i;
			}
			yield break;
		}

		/// <summary>
		/// Get a list of servers that you have added to your play history
		/// </summary>
		// Token: 0x060005E1 RID: 1505 RVA: 0x00008658 File Offset: 0x00006858
		internal static IEnumerable<ServerInfo> GetHistoryServers()
		{
			int count = SteamMatchmaking.Internal.GetFavoriteGameCount();
			int num;
			for (int i = 0; i < count; i = num + 1)
			{
				uint timeplayed = 0U;
				uint flags = 0U;
				ushort qport = 0;
				ushort cport = 0;
				uint ip = 0U;
				AppId appid = default(AppId);
				if (SteamMatchmaking.Internal.GetFavoriteGame(i, ref appid, ref ip, ref cport, ref qport, ref flags, ref timeplayed) && (flags & 2U) != 0U)
				{
					yield return new ServerInfo(ip, cport, qport, timeplayed);
				}
				num = i;
			}
			yield break;
		}
	}
}
