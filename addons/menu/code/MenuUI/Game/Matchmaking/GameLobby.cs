
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.DataModel;

[UseTemplate]
public class GameLobby : BaseGamePanel
{
	public Lobby Lobby { get; set; }
	public LobbyChat LobbyChat { get; set; }
	public Panel PlayerList { get; set; }
	public Button StartGame { get; set; }

	public string MemberListText => $"Members [{Lobby.MemberCount}/{Lobby.MaxMembers}]";

	public GameLobby( Lobby lobby, BaseGamePanel gamePanel ) : base( gamePanel )
	{
		Lobby = lobby;
		Lobby.OnMemberJoined += ( f ) => Rebuild();
		Lobby.OnMemberLeave += ( f ) => Rebuild();

		LobbyChat.Init( Lobby );

		Lobby.Map = Package.GameConfiguration.MapList.First();

		LoadConfig();
		Tick();
	}

	int hashCode;
	bool joinedGame;

	public override void Tick()
	{
		if ( !IsVisible ) return;
		if ( Lobby == null ) return;

		if ( !Lobby.Members.Any( x => x.IsMe ) )
		{
			LeaveLobby();
			return;
		}

		int playersNeeded = Package.GameConfiguration.MinPlayers - Lobby.MemberCount;
		bool CanPlayGame = false;

		if ( playersNeeded > 0 )
		{
			StartGame.Text = $"Waiting for {playersNeeded:n0} more {playersNeeded.Plural( "player", "players" )}";
		}
		else if ( !Lobby.Owner.IsMe )
		{
			if ( Lobby.State == "active" )
			{
				StartGame.Text = $"Join The Game";
				CanPlayGame = true;
			}
			else
			{
				StartGame.Text = $"Waiting for lobby owner";
			}
		}
		else
		{
			StartGame.Text = $"Start The Game";

			if ( Package.GameConfiguration.MapSelection == MapSelect.Hidden )
			{
				StartGame.Subtitle = $"Max {Lobby.MaxMembers} players";
			}
			else
			{
				StartGame.Subtitle = $"{Package.GetCachedTitle( Lobby.Map )}, max {Lobby.MaxMembers} players";
			}
			
			CanPlayGame = true;
		}

		var hc = HashCode.Combine( Lobby.MaxMembers, Package.GameConfiguration.MinPlayers );
		if ( hc != hashCode )
		{
			hashCode = hc;
			Rebuild();
		}

		StartGame.SetClass( "disabled", !CanPlayGame );

		if ( !joinedGame && Lobby.GameServer > 0 && Lobby.State == "active" && !Lobby.Owner.IsMe )
		{
			joinedGame = true;
		//	Lobby.JoinGame();
		}

		SetClass( "is-owner", Lobby.Owner.IsMe );
		SetClass( "map-select", Package.GameConfiguration.MapSelection != MapSelect.Hidden );
	}

	/// <summary>
	/// Lobby owner starts the game
	/// </summary>
	public void OnStartGame()
	{
		if ( !Lobby.Owner.IsMe )
		{
			OnJoinGame();
			return;
		}

		SaveConfig();
		Lobby.StartGame();
	}

	internal void SetMap( string value )
	{
		// No map changing!
		if ( Package.GameConfiguration.MapSelection == MapSelect.Hidden )
			return;

		if ( Lobby == null )
			return;

		Lobby.Map = value;
	}

	/// <summary>
	/// Lobby member joins the game
	/// </summary>
	public void OnJoinGame()
	{
		Lobby.JoinGame();
	}

	void Rebuild()
	{
		PlayerList?.DeleteChildren( true );
		var members = Lobby.Members.ToArray();

		for ( int i = 0; i< Package.GameConfiguration.MaxPlayers; i++ )
		{
			var cell = PlayerList.Add.Panel( "cell" );
			if ( members.Length <= i )
			{
				cell.Add.Label( "Unoccupied" );
				cell.AddClass( "unoccupied" );
				continue;
			}

			AddPlayer( cell, i, members[i] );
		}
	}

	private void AddPlayer( Panel cell, int index, Friend f )
	{
		new LobbyFriend( cell, Lobby, f );
	}

	public void LeaveLobby()
	{
		Lobby?.Dispose();
		Lobby = null;

		CreateEvent( "onleavelobby" );
	}


	void SaveConfig()
	{
		var configs = Lobby.Data.ToDictionary( x => x.Key, x => x.Value );

		configs["access"] = $"{(int)Lobby.Access}";
		configs["joinable"] = $"{(Lobby.IsJoinable?1:0)}";
		configs["maxmembers"] = $"{Lobby.MaxMembers}";

		Cookie.Set( $"{GameIdent}.config", configs );
	}

	void LoadConfig()
	{
		var config = Cookie.Get<Dictionary<string, string>>( $"{GameIdent}.config", null );
		if ( config == null ) return;

		foreach( var entry in config )
		{
			if ( entry.Key == "state" )
				continue;			
			
			if ( entry.Key == "game" )
				continue;

			if ( entry.Key == "access" )
			{
				Lobby.Access = (Lobby.AccessMode)entry.Value.ToInt();
				continue;
			}

			if ( entry.Key == "joinable" )
			{
				Lobby.IsJoinable = entry.Value.ToBool();
				continue;
			}

			if ( entry.Key == "maxmembers" )
			{
				Lobby.MaxMembers = entry.Value.ToInt();
				continue;
			}

			Lobby.SetData( entry.Key, entry.Value );
		}
	}

	public class LobbyFriend : Panel
	{
		private Lobby Lobby;
		private Friend Friend;

		public Panel Avatar;
		public Label Name;
		public Label Status;
		public IconPanel Ready;

		public LobbyFriend( Panel parent, Lobby lobby, Friend friend ) : base( parent )
		{
			AddClass( "lobbyfriend" );

			Lobby = lobby;
			Friend = friend;

			Avatar = Add.Panel( "avatar" );
			Avatar.Style.SetBackgroundImage( $"avatar:{friend.Id}" );

			var p = Add.Panel( "columns grow" );
			Name = p.Add.Label( friend.Name, "name" );
			Status = p.Add.Label( "", "status" );

			if ( friend.IsMe )
			{
				Ready = Add.Icon( "thumb_up", "ready" );
				Ready.AddEventListener( "onmousedown", ReadyToggle );
			}
		}

		void ReadyToggle()
		{
			var status = Lobby.GetMemberData( Friend, "status" );

			if ( status == "staging" )
			{
				Lobby.SetLocalMemberData( "status", "ready" );
			}
			else if ( status == "ready" )
			{
				Lobby.SetLocalMemberData( "status", "staging" );
			}
		}

		public override void Tick()
		{
			if ( !IsVisible )
				return;

			var status = Lobby.GetMemberData( Friend, "status" );

			SetClass( "is-ready", status == "ready" );
			SetClass( "is-staging", status == "staging" );
			SetClass( "is-active", status == "active" );

			switch (status)
			{
				case "active":
					{
						Status.Text = "In Game";
						break;
					}

				case "afk":
					{
						Status.Text = "Idle / Away From Keyboard";
						break;
					}

				case "loading":
					{
						Status.Text = "Loading Game";
						break;
					}

				case "staging":
					{
						Status.Text = "Not Ready";
						break;
					}

				case "ready":
					{
						Status.Text = "Ready & Waiting";
						break;
					}

				default:
					{
						Status.Text = "Unknown Status";
						break;
					}
			}
		}
	}
}
