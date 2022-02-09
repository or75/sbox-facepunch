using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using NativeEngine;
using Sandbox.Engine;
using Sandbox.Internal;
using Sandbox.Internal.Globals;
using Steamworks;
using Steamworks.Data;

namespace Sandbox
{
	// Token: 0x020000A6 RID: 166
	[Hotload.SkipAttribute]
	internal static class GameLobby
	{
		/// <summary>
		/// This is the server's LobbyId.
		/// </summary>
		// Token: 0x17000225 RID: 549
		// (get) Token: 0x060010F2 RID: 4338 RVA: 0x00048F6D File Offset: 0x0004716D
		// (set) Token: 0x060010F3 RID: 4339 RVA: 0x00048F74 File Offset: 0x00047174
		[ConVar.ReplicatedAttribute("sv_lobby")]
		public static ulong Id
		{
			get
			{
				return GameLobby.lobbyid;
			}
			set
			{
				if (GameLobby.lobbyid == value)
				{
					return;
				}
				GameLobby.lobbyid = value;
				if (Host.IsClient && GameLobby.lobbyid > 0UL)
				{
					GameLobby.JoinServerLobby(GameLobby.lobbyid);
				}
			}
		}

		/// <summary>
		/// Called from the menu when someone is in a lobby and they want to turn it into a game.
		/// </summary>
		// Token: 0x060010F4 RID: 4340 RVA: 0x00048FA0 File Offset: 0x000471A0
		[ServerCmd(null)]
		internal static void StartLobby(ulong lobbyId)
		{
			if (GlobalGameNamespace.Global.Lobby == null || lobbyId != GlobalGameNamespace.Global.Lobby.Id)
			{
				Lobby lobby = GlobalGameNamespace.Global.Lobby;
				if (lobby != null)
				{
					lobby.Dispose();
				}
				GlobalGameNamespace.Global.Lobby = null;
				GlobalGameNamespace.Global.Lobby = new Lobby(new Lobby(lobbyId));
			}
			GlobalGameNamespace.Global.Lobby.SetData("state", "loading");
			InputService.InsertCommand(InputCommandSource.ICS_SERVER, "gamemode " + GlobalGameNamespace.Global.Lobby.Game + "\n", 0, 0);
			InputService.InsertCommand(InputCommandSource.ICS_SERVER, "host_timescale 1\n", 0, 0);
			InputCommandSource nSource = InputCommandSource.ICS_SERVER;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
			defaultInterpolatedStringHandler.AppendLiteral("maxplayers ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(GlobalGameNamespace.Global.Lobby.MaxMembers);
			defaultInterpolatedStringHandler.AppendLiteral("\n");
			InputService.InsertCommand(nSource, defaultInterpolatedStringHandler.ToStringAndClear(), 0, 0);
			InputService.InsertCommand(InputCommandSource.ICS_SERVER, "changelevel " + GlobalGameNamespace.Global.Lobby.Map + "\n", 0, 0);
		}

		/// <summary>
		/// We're stating a new game. Make sure we have a lobby!
		/// </summary>
		// Token: 0x060010F5 RID: 4341 RVA: 0x000490C0 File Offset: 0x000472C0
		internal static async Task FindOrCreateAsync(string gamemode, string map)
		{
			Host.AssertServer("FindOrCreateAsync");
			try
			{
				if (GlobalGameNamespace.Global.IsDedicatedServer)
				{
					GlobalGameNamespace.Log.Warning("Not creating GameLobby on dedicated server (todo)!");
				}
				else
				{
					if (GlobalGameNamespace.Global.Lobby == null)
					{
						Global global = GlobalGameNamespace.Global;
						Lobby lobby = await Lobby.CreateInternal(ConsoleSystem.GetValue("maxplayers", null).ToInt(1), gamemode, "active");
						global.Lobby = lobby;
						global = null;
					}
					if (GlobalGameNamespace.Global.Lobby != null)
					{
						GlobalGameNamespace.Global.Lobby.GameServer = SteamClient.SteamId.Value;
						GlobalGameNamespace.Global.Lobby.Game = gamemode;
						GlobalGameNamespace.Global.Lobby.Map = map;
						GlobalGameNamespace.Global.Lobby.State = "active";
						ConsoleSystem.Run("sv_lobby", new object[] { GlobalGameNamespace.Global.Lobby.Id.ToString() });
					}
					else
					{
						GlobalGameNamespace.Log.Warning("Failed to create a lobby for game server!");
					}
				}
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Error(e);
			}
		}

		/// <summary>
		/// Called from client when joining a server to join the game lobby too.
		/// </summary>
		// Token: 0x060010F6 RID: 4342 RVA: 0x0004910C File Offset: 0x0004730C
		internal static async Task JoinServerLobby(ulong serverLobby)
		{
			Host.AssertClient("JoinServerLobby");
			try
			{
				if (GlobalGameNamespace.Global.Lobby != null)
				{
					Lobby lobby = GlobalGameNamespace.Global.Lobby;
					if (lobby != null)
					{
						lobby.Dispose();
					}
					GlobalGameNamespace.Global.Lobby = null;
				}
				Global global = GlobalGameNamespace.Global;
				Lobby lobby2 = await Lobby.TryJoinLobbyInternal(serverLobby);
				global.Lobby = lobby2;
				global = null;
				if (GlobalGameNamespace.Global.Lobby != null)
				{
					GlobalGameNamespace.Log.Info(FormattableStringFactory.Create("Joined Server Lobby {0}", new object[] { GlobalGameNamespace.Global.Lobby.Id }));
					string key = "lobby";
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<ulong>(GlobalGameNamespace.Global.Lobby.Id);
					SteamFriends.SetRichPresence(key, defaultInterpolatedStringHandler.ToStringAndClear());
					IMenuDll menuDll = IMenuDll.Current;
					if (menuDll != null)
					{
						menuDll.RunEvent("game.lobby.join", GlobalGameNamespace.Global.Lobby.Id);
					}
				}
				Lobby lobby3 = GlobalGameNamespace.Global.Lobby;
				if (lobby3 != null)
				{
					lobby3.SetLocalMemberData("status", "active");
				}
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Error(e);
			}
		}

		/// <summary>
		/// Leave the game lobby, called on game end, disconnect
		/// </summary>
		// Token: 0x060010F7 RID: 4343 RVA: 0x00049150 File Offset: 0x00047350
		internal static void Leave()
		{
			if (GlobalGameNamespace.Global.Lobby != null)
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Leaving lobby {0}", new object[] { GlobalGameNamespace.Global.Lobby.Id }));
				Lobby lobby = GlobalGameNamespace.Global.Lobby;
				if (lobby != null)
				{
					lobby.Dispose();
				}
				GlobalGameNamespace.Global.Lobby = null;
			}
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll != null)
			{
				menuDll.RunEvent("game.lobby.leave");
			}
			if (Host.IsClient)
			{
				SteamFriends.SetRichPresence("lobby", "");
			}
		}

		// Token: 0x040002E9 RID: 745
		private static ulong lobbyid;
	}
}
