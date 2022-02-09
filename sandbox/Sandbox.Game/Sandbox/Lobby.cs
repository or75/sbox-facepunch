using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NativeEngine;
using Sandbox.Internal;
using Steamworks;
using Steamworks.Data;

namespace Sandbox
{
	// Token: 0x020000BE RID: 190
	public sealed class Lobby : IDisposable
	{
		// Token: 0x060011BD RID: 4541 RVA: 0x0004B2AC File Offset: 0x000494AC
		internal Lobby(Lobby lobby)
		{
			this.SteamLobby = lobby;
			SteamMatchmaking.OnLobbyMemberJoined += this.SteamMatchmaking_OnLobbyMemberJoined;
			SteamMatchmaking.OnLobbyMemberLeave += this.SteamMatchmaking_OnLobbyMemberLeave;
			SteamMatchmaking.OnLobbyMemberDisconnected += this.SteamMatchmaking_OnLobbyMemberDisconnected;
			SteamMatchmaking.OnLobbyMemberDataChanged += this.SteamMatchmaking_OnLobbyMemberDataChanged;
			SteamMatchmaking.OnLobbyMemberBanned += this.SteamMatchmaking_OnLobbyMemberBanned;
			SteamMatchmaking.OnLobbyDataChanged += this.SteamMatchmaking_OnLobbyDataChanged;
			SteamMatchmaking.OnChatMessage += this.SteamMatchmaking_OnChatMessage;
		}

		// Token: 0x060011BE RID: 4542 RVA: 0x0004B34C File Offset: 0x0004954C
		public void Dispose()
		{
			this.Leave();
			this.SteamLobby = default(Lobby);
			SteamMatchmaking.OnLobbyMemberJoined -= this.SteamMatchmaking_OnLobbyMemberJoined;
			SteamMatchmaking.OnLobbyMemberLeave -= this.SteamMatchmaking_OnLobbyMemberLeave;
			SteamMatchmaking.OnLobbyMemberDisconnected -= this.SteamMatchmaking_OnLobbyMemberDisconnected;
			SteamMatchmaking.OnLobbyMemberDataChanged -= this.SteamMatchmaking_OnLobbyMemberDataChanged;
			SteamMatchmaking.OnLobbyMemberBanned -= this.SteamMatchmaking_OnLobbyMemberBanned;
			SteamMatchmaking.OnLobbyDataChanged -= this.SteamMatchmaking_OnLobbyDataChanged;
			SteamMatchmaking.OnChatMessage -= this.SteamMatchmaking_OnChatMessage;
		}

		/// <summary>
		/// The owner of this lobby. Unlike .Owner this is accessible without join
		/// </summary>
		// Token: 0x17000255 RID: 597
		// (get) Token: 0x060011BF RID: 4543 RVA: 0x0004B3E2 File Offset: 0x000495E2
		// (set) Token: 0x060011C0 RID: 4544 RVA: 0x0004B3EF File Offset: 0x000495EF
		public string OwnerId
		{
			get
			{
				return this.GetData("ownerid");
			}
			set
			{
				this.SetData("ownerid", value);
			}
		}

		/// <summary>
		/// The title of this lobby. Think of this as the server name.
		/// </summary>
		// Token: 0x17000256 RID: 598
		// (get) Token: 0x060011C1 RID: 4545 RVA: 0x0004B3FE File Offset: 0x000495FE
		// (set) Token: 0x060011C2 RID: 4546 RVA: 0x0004B40B File Offset: 0x0004960B
		public string Title
		{
			get
			{
				return this.GetData("title");
			}
			set
			{
				this.SetData("title", value);
			}
		}

		/// <summary>
		/// The game ident of this lobby. 
		/// </summary>
		// Token: 0x17000257 RID: 599
		// (get) Token: 0x060011C3 RID: 4547 RVA: 0x0004B41A File Offset: 0x0004961A
		// (set) Token: 0x060011C4 RID: 4548 RVA: 0x0004B427 File Offset: 0x00049627
		public string Game
		{
			get
			{
				return this.GetData("game");
			}
			set
			{
				this.SetData("game", value);
			}
		}

		/// <summary>
		/// The current state of this lobby, ie "staging", "active"
		/// </summary>
		// Token: 0x17000258 RID: 600
		// (get) Token: 0x060011C5 RID: 4549 RVA: 0x0004B436 File Offset: 0x00049636
		// (set) Token: 0x060011C6 RID: 4550 RVA: 0x0004B443 File Offset: 0x00049643
		public string State
		{
			get
			{
				return this.GetData("state");
			}
			set
			{
				this.SetData("state", value);
			}
		}

		/// <summary>
		/// The current map for this lobby
		/// </summary>
		// Token: 0x17000259 RID: 601
		// (get) Token: 0x060011C7 RID: 4551 RVA: 0x0004B452 File Offset: 0x00049652
		// (set) Token: 0x060011C8 RID: 4552 RVA: 0x0004B45F File Offset: 0x0004965F
		public string Map
		{
			get
			{
				return this.GetData("config.map");
			}
			set
			{
				this.SetData("config.map", value);
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x060011C9 RID: 4553 RVA: 0x0004B46E File Offset: 0x0004966E
		public ulong Id
		{
			get
			{
				return this.SteamLobby.Id;
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x060011CA RID: 4554 RVA: 0x0004B480 File Offset: 0x00049680
		public bool IsMember
		{
			get
			{
				return this.Members.Any((Friend x) => x.IsMe);
			}
		}

		// Token: 0x060011CB RID: 4555 RVA: 0x0004B4AC File Offset: 0x000496AC
		public void InviteFriend(Friend friend)
		{
			Host.AssertMenu("InviteFriend");
			this.SteamLobby.InviteFriend((ulong)friend.Id);
		}

		// Token: 0x060011CC RID: 4556 RVA: 0x0004B4D0 File Offset: 0x000496D0
		public void InviteUsingOverlay()
		{
			Host.AssertMenu("InviteUsingOverlay");
			SteamFriends.OpenGameInviteOverlay(this.SteamLobby.Id);
		}

		// Token: 0x060011CD RID: 4557 RVA: 0x0004B4EC File Offset: 0x000496EC
		public async Task<bool> TryJoin()
		{
			Host.AssertMenu("TryJoin");
			RoomEnter reason = await this.SteamLobby.Join();
			bool result;
			if (reason != RoomEnter.Success)
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't join lobby ({0}", new object[] { reason }));
				result = false;
			}
			else
			{
				Lobby._active.Add(this);
				result = true;
			}
			return result;
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x060011CE RID: 4558 RVA: 0x0004B52F File Offset: 0x0004972F
		public IEnumerable<Friend> Members
		{
			get
			{
				return this.SteamLobby.Members.Select((Friend x) => x.ToSandbox());
			}
		}

		// Token: 0x060011CF RID: 4559 RVA: 0x0004B560 File Offset: 0x00049760
		public string GetData(string key)
		{
			return this.SteamLobby.GetData(key);
		}

		// Token: 0x060011D0 RID: 4560 RVA: 0x0004B56E File Offset: 0x0004976E
		public bool SetData(string key, string value)
		{
			return this.SteamLobby.SetData(key, value);
		}

		// Token: 0x060011D1 RID: 4561 RVA: 0x0004B57D File Offset: 0x0004977D
		public bool DeleteData(string key)
		{
			return this.SteamLobby.DeleteData(key);
		}

		// Token: 0x060011D2 RID: 4562 RVA: 0x0004B58B File Offset: 0x0004978B
		public string GetMemberData(Friend member, string key)
		{
			return this.SteamLobby.GetMemberData(member.Internal, key);
		}

		// Token: 0x060011D3 RID: 4563 RVA: 0x0004B59F File Offset: 0x0004979F
		public void SetLocalMemberData(string key, string value)
		{
			this.SteamLobby.SetMemberData(key, value);
		}

		/// <summary>
		/// Allows iteration of all data fields
		/// </summary>
		// Token: 0x1700025D RID: 605
		// (get) Token: 0x060011D4 RID: 4564 RVA: 0x0004B5AE File Offset: 0x000497AE
		public IEnumerable<KeyValuePair<string, string>> Data
		{
			get
			{
				return this.SteamLobby.Data;
			}
		}

		/// <summary>
		/// Send chat message to the lobby
		/// </summary>
		// Token: 0x060011D5 RID: 4565 RVA: 0x0004B5BC File Offset: 0x000497BC
		public unsafe bool SendChat(string message)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(message);
			byte[] array;
			byte* ptr;
			if ((array = bytes) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			return SteamMatchmaking.Internal.SendLobbyChatMsg(this.Id, (IntPtr)((void*)ptr), bytes.Length);
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x060011D6 RID: 4566 RVA: 0x0004B60B File Offset: 0x0004980B
		// (set) Token: 0x060011D7 RID: 4567 RVA: 0x0004B61D File Offset: 0x0004981D
		public ulong GameServer
		{
			get
			{
				return this.SteamLobby.GameServerSteamId;
			}
			set
			{
				this.SteamLobby.SetGameServer(value);
			}
		}

		// Token: 0x060011D8 RID: 4568 RVA: 0x0004B630 File Offset: 0x00049830
		public void Leave()
		{
			Lobby._active.Remove(this);
			this.SteamLobby.Leave();
		}

		// Token: 0x060011D9 RID: 4569 RVA: 0x0004B649 File Offset: 0x00049849
		public bool Refresh()
		{
			return this.SteamLobby.Refresh();
		}

		/// <summary>
		/// Maximum number of people allowed in the lobby
		/// </summary>
		// Token: 0x1700025F RID: 607
		// (get) Token: 0x060011DA RID: 4570 RVA: 0x0004B656 File Offset: 0x00049856
		// (set) Token: 0x060011DB RID: 4571 RVA: 0x0004B663 File Offset: 0x00049863
		public int MaxMembers
		{
			get
			{
				return this.SteamLobby.MaxMembers;
			}
			set
			{
				this.SteamLobby.MaxMembers = value;
			}
		}

		/// <summary>
		/// Number of people in the lobby
		/// </summary>
		// Token: 0x17000260 RID: 608
		// (get) Token: 0x060011DC RID: 4572 RVA: 0x0004B671 File Offset: 0x00049871
		public int MemberCount
		{
			get
			{
				return this.SteamLobby.MemberCount;
			}
		}

		/// <summary>
		/// Get the owner of the lobby. Only the owner of the lobby can change the owner.
		/// </summary>
		// Token: 0x17000261 RID: 609
		// (get) Token: 0x060011DD RID: 4573 RVA: 0x0004B67E File Offset: 0x0004987E
		// (set) Token: 0x060011DE RID: 4574 RVA: 0x0004B690 File Offset: 0x00049890
		public Friend Owner
		{
			get
			{
				return this.SteamLobby.Owner.ToSandbox();
			}
			set
			{
				this.SteamLobby.Owner = value.Internal;
			}
		}

		// Token: 0x060011DF RID: 4575 RVA: 0x0004B6A3 File Offset: 0x000498A3
		private void SteamMatchmaking_OnLobbyMemberLeave(Lobby lobby, Friend friend)
		{
			if (lobby.Id != this.SteamLobby.Id)
			{
				return;
			}
			Action<Friend> onMemberLeave = this.OnMemberLeave;
			if (onMemberLeave == null)
			{
				return;
			}
			onMemberLeave(friend.ToSandbox());
		}

		// Token: 0x060011E0 RID: 4576 RVA: 0x0004B6DA File Offset: 0x000498DA
		private void SteamMatchmaking_OnLobbyMemberJoined(Lobby lobby, Friend friend)
		{
			if (lobby.Id != this.SteamLobby.Id)
			{
				return;
			}
			Action<Friend> onMemberJoined = this.OnMemberJoined;
			if (onMemberJoined == null)
			{
				return;
			}
			onMemberJoined(friend.ToSandbox());
		}

		// Token: 0x060011E1 RID: 4577 RVA: 0x0004B711 File Offset: 0x00049911
		private void SteamMatchmaking_OnLobbyMemberBanned(Lobby arg1, Friend arg2, Friend arg3)
		{
			if (arg1.Id != this.SteamLobby.Id)
			{
				return;
			}
			GlobalGameNamespace.Log.Info("SteamMatchmaking_OnLobbyMemberBanned");
		}

		// Token: 0x060011E2 RID: 4578 RVA: 0x0004B741 File Offset: 0x00049941
		private void SteamMatchmaking_OnLobbyMemberDataChanged(Lobby lobby, Friend friend)
		{
			if (lobby.Id != this.SteamLobby.Id)
			{
				return;
			}
			Action<Friend> onMemberChanged = this.OnMemberChanged;
			if (onMemberChanged == null)
			{
				return;
			}
			onMemberChanged(friend.ToSandbox());
		}

		// Token: 0x060011E3 RID: 4579 RVA: 0x0004B778 File Offset: 0x00049978
		private void SteamMatchmaking_OnLobbyMemberDisconnected(Lobby arg1, Friend arg2)
		{
			if (arg1.Id != this.SteamLobby.Id)
			{
				return;
			}
			GlobalGameNamespace.Log.Info("SteamMatchmaking_OnLobbyMemberDisconnected");
		}

		// Token: 0x060011E4 RID: 4580 RVA: 0x0004B7A8 File Offset: 0x000499A8
		private void SteamMatchmaking_OnLobbyMemberKicked(Lobby arg1, Friend arg2, Friend arg3)
		{
			if (arg1.Id != this.SteamLobby.Id)
			{
				return;
			}
			GlobalGameNamespace.Log.Info("SteamMatchmaking_OnLobbyMemberKicked");
		}

		// Token: 0x060011E5 RID: 4581 RVA: 0x0004B7D8 File Offset: 0x000499D8
		private void SteamMatchmaking_OnLobbyDataChanged(Lobby lobby)
		{
			if (lobby.Id != this.SteamLobby.Id)
			{
				return;
			}
			Action onLobbyChanged = this.OnLobbyChanged;
			if (onLobbyChanged == null)
			{
				return;
			}
			onLobbyChanged();
		}

		// Token: 0x060011E6 RID: 4582 RVA: 0x0004B80C File Offset: 0x00049A0C
		private void SteamMatchmaking_OnChatMessage(Lobby lobby, Friend friend, string message)
		{
			if (lobby.Id != this.SteamLobby.Id)
			{
				return;
			}
			Action<Friend, string> onMemberChat = this.OnMemberChat;
			if (onMemberChat != null)
			{
				onMemberChat(friend.ToSandbox(), message);
			}
			Event.Run<Friend, string>("lobby.chat", friend.ToSandbox(), message);
		}

		// Token: 0x060011E7 RID: 4583 RVA: 0x0004B864 File Offset: 0x00049A64
		public bool JoinGame()
		{
			SteamId gameServer = this.SteamLobby.GameServerSteamId;
			if (!gameServer.IsValid)
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("JoinGame: Server Address Was Not Valid: {0}", new object[] { gameServer }));
				return false;
			}
			this.SetLocalMemberData("status", "connect");
			string command = "connect";
			object[] array = new object[1];
			int num = 0;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
			defaultInterpolatedStringHandler.AppendLiteral("[");
			defaultInterpolatedStringHandler.AppendFormatted<ulong>(gameServer.Value);
			defaultInterpolatedStringHandler.AppendLiteral("]");
			array[num] = defaultInterpolatedStringHandler.ToStringAndClear();
			ConsoleSystem.Run(command, array);
			return true;
		}

		// Token: 0x060011E8 RID: 4584 RVA: 0x0004B904 File Offset: 0x00049B04
		public static async Task<Lobby[]> GetList(string ident = null, string state = null)
		{
			Host.AssertMenu("GetList");
			await Lobby.slimSemaphore.WaitAsync();
			Lobby[] result;
			try
			{
				LobbyQuery q = SteamMatchmaking.LobbyList.FilterDistanceWorldwide();
				if (ident != null)
				{
					q = q.WithKeyValue("game", ident);
				}
				if (state != null)
				{
					q = q.WithKeyValue("state", state);
				}
				Lobby[] lobbies = await q.WithMaxResults(2000).RequestAsync();
				if (lobbies == null)
				{
					result = null;
				}
				else
				{
					result = lobbies.Select((Lobby x) => new Lobby(x)).ToArray<Lobby>();
				}
			}
			finally
			{
				Lobby.slimSemaphore.Release();
			}
			return result;
		}

		// Token: 0x060011E9 RID: 4585 RVA: 0x0004B950 File Offset: 0x00049B50
		public void StartGame()
		{
			Host.AssertMenu("StartGame");
			if (!this.Owner.IsMe)
			{
				GlobalGameNamespace.Log.Warning("You can't start the game - you're not the lobby owner!");
				return;
			}
			this.SetLocalMemberData("status", "loading");
			InputCommandSource nSource = InputCommandSource.ICS_SERVER;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
			defaultInterpolatedStringHandler.AppendLiteral("startlobby ");
			defaultInterpolatedStringHandler.AppendFormatted<ulong>(this.Id);
			defaultInterpolatedStringHandler.AppendLiteral("\n");
			InputService.InsertCommand(nSource, defaultInterpolatedStringHandler.ToStringAndClear(), 0, 0);
			GlobalGameNamespace.Log.Info("menu.home.rebuild");
			Event.Run("menu.home.rebuild");
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x060011EA RID: 4586 RVA: 0x0004B9EE File Offset: 0x00049BEE
		// (set) Token: 0x060011EB RID: 4587 RVA: 0x0004B9F6 File Offset: 0x00049BF6
		public bool IsJoinable
		{
			get
			{
				return this.joinable;
			}
			set
			{
				this.joinable = value;
				SteamMatchmaking.Internal.SetLobbyJoinable(this.Id, value);
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x060011EC RID: 4588 RVA: 0x0004BA16 File Offset: 0x00049C16
		// (set) Token: 0x060011ED RID: 4589 RVA: 0x0004BA1E File Offset: 0x00049C1E
		public Lobby.AccessMode Access
		{
			get
			{
				return this._accessMode;
			}
			set
			{
				this._accessMode = value;
				SteamMatchmaking.Internal.SetLobbyType(this.Id, (LobbyType)this._accessMode);
			}
		}

		// Token: 0x060011EE RID: 4590 RVA: 0x0004BA44 File Offset: 0x00049C44
		internal static void InitSteamCallbacks()
		{
			SteamMatchmaking.OnLobbyInvite += Lobby.SteamMatchmaking_OnLobbyInvite;
			SteamFriends.OnGameLobbyJoinRequested += Lobby.SteamFriends_OnGameLobbyJoinRequested;
			SteamFriends.OnPersonaStateChange += Lobby.SteamFriends_OnPersonaStateChange;
			SteamFriends.OnFriendRichPresenceUpdate += Lobby.SteamFriends_OnPersonaStateChange;
		}

		// Token: 0x060011EF RID: 4591 RVA: 0x0004BA95 File Offset: 0x00049C95
		private static void SteamFriends_OnGameLobbyJoinRequested(Lobby lobby, SteamId friend)
		{
			Event.Run<Lobby, Friend>("lobby.acceptinvite", new Lobby(lobby), new Friend(friend));
		}

		// Token: 0x060011F0 RID: 4592 RVA: 0x0004BAAD File Offset: 0x00049CAD
		private static void SteamMatchmaking_OnLobbyInvite(Friend friend, Lobby lobby)
		{
			Event.Run<Lobby, Friend>("lobby.invite", new Lobby(lobby), friend.ToSandbox());
		}

		// Token: 0x060011F1 RID: 4593 RVA: 0x0004BAC5 File Offset: 0x00049CC5
		private static void SteamFriends_OnPersonaStateChange(Friend obj)
		{
			Event.Run<Friend>("friend.change", obj.ToSandbox());
		}

		/// <summary>
		/// A of lobbies we're active in
		/// </summary>
		// Token: 0x17000264 RID: 612
		// (get) Token: 0x060011F2 RID: 4594 RVA: 0x0004BAD7 File Offset: 0x00049CD7
		public static IEnumerable<Lobby> Active
		{
			get
			{
				Host.AssertMenu("Active");
				return Lobby._active;
			}
		}

		// Token: 0x060011F3 RID: 4595 RVA: 0x0004BAE8 File Offset: 0x00049CE8
		public static async Task<Lobby> TryJoinLobby(ulong lobbyId)
		{
			Host.AssertMenu("TryJoinLobby");
			return await Lobby.TryJoinLobbyInternal(lobbyId);
		}

		// Token: 0x060011F4 RID: 4596 RVA: 0x0004BB2C File Offset: 0x00049D2C
		internal static async Task<Lobby> TryJoinLobbyInternal(ulong lobbyId)
		{
			Lobby? lobby = await SteamMatchmaking.JoinLobbyAsync(lobbyId);
			Lobby result;
			if (lobby == null)
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't join lobby!", Array.Empty<object>()));
				result = null;
			}
			else
			{
				Lobby i = new Lobby(lobby.Value);
				Lobby._active.Add(i);
				result = i;
			}
			return result;
		}

		// Token: 0x060011F5 RID: 4597 RVA: 0x0004BB70 File Offset: 0x00049D70
		public static async Task<Lobby> Create(int max_members, string gameident, string state)
		{
			Host.AssertMenu("Create");
			return await Lobby.CreateInternal(max_members, gameident, state);
		}

		// Token: 0x060011F6 RID: 4598 RVA: 0x0004BBC4 File Offset: 0x00049DC4
		internal static async Task<Lobby> CreateInternal(int max_members, string gameident, string state)
		{
			Lobby? steamlobby = await SteamMatchmaking.CreateLobbyAsync(max_members);
			Lobby result;
			if (steamlobby == null)
			{
				GlobalGameNamespace.Log.Warning("Error creating lobby!");
				result = null;
			}
			else
			{
				Lobby lobby = new Lobby(steamlobby.Value);
				lobby.Game = gameident;
				lobby.State = state;
				lobby.OwnerId = Local.PlayerId.ToString();
				lobby.Title = Local.DisplayName + "'s lobby";
				Lobby._active.Add(lobby);
				result = lobby;
			}
			return result;
		}

		// Token: 0x04000386 RID: 902
		private Lobby SteamLobby;

		// Token: 0x04000387 RID: 903
		public Action<Friend> OnMemberJoined;

		// Token: 0x04000388 RID: 904
		public Action<Friend> OnMemberLeave;

		// Token: 0x04000389 RID: 905
		public Action OnLobbyChanged;

		// Token: 0x0400038A RID: 906
		public Action<Friend> OnMemberChanged;

		// Token: 0x0400038B RID: 907
		public Action<Friend, string> OnMemberChat;

		// Token: 0x0400038C RID: 908
		private static SemaphoreSlim slimSemaphore = new SemaphoreSlim(1);

		// Token: 0x0400038D RID: 909
		private bool joinable = true;

		// Token: 0x0400038E RID: 910
		private Lobby.AccessMode _accessMode = Lobby.AccessMode.Invisible;

		/// <summary>
		/// Party invite has been created
		/// </summary>
		// Token: 0x0400038F RID: 911
		public static Action<Lobby, Friend> OnPartyInvite;

		// Token: 0x04000390 RID: 912
		private static List<Lobby> _active = new List<Lobby>();

		/// <summary>
		/// TODO: These names make no sense, Valve fucked us
		/// </summary>
		// Token: 0x0200023B RID: 571
		public enum AccessMode
		{
			// Token: 0x0400118F RID: 4495
			Private,
			// Token: 0x04001190 RID: 4496
			FriendsOnly,
			// Token: 0x04001191 RID: 4497
			Public,
			// Token: 0x04001192 RID: 4498
			Invisible
		}
	}
}
