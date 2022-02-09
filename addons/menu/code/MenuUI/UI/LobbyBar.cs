using Sandbox.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sandbox.UI.Construct;

namespace Sandbox.UI
{
	public class LobbyIcon : NavigatorButton
	{
		public string Ident { get; set; }
		public Button PlayerCount { get; set; }

		public async ValueTask Init( string ident )
		{
			Ident = ident;
			HRef = $"/game/{Ident}";
			PlayerCount = Add.ButtonWithIcon( "0", "person", "player_count" );

			var package = await Package.Fetch( Ident, true );

			if ( package == null )
			{
				Delete();
				return;
			}

			Style.SetBackgroundImage( package.Thumb );
		}

		public override void Tick()
		{
			base.Tick();

			if ( HasNoPlayers && TimeSinceNoPlayers > 60 )
			{
				Delete();
			}
		}

		bool HasNoPlayers;
		TimeSince TimeSinceNoPlayers;

		internal void SetLobbyInformation( int num_lobbies, int num_players )
		{
			if ( num_players == 0 && !HasNoPlayers )
			{
				HasNoPlayers = true;
				TimeSinceNoPlayers = 0;
			}

			SetClass( "no-players", num_players == 0 );
			PlayerCount.Text = $"{num_players:n0}";
		}
	}

	public class LobbyBar : Panel
	{
		public override void Tick()
		{
			base.Tick();

			if ( !IsVisible )
				return;

			_ = TickStagingLobbies();
		}

		RealTimeSince timeSinceUpdate = 60;

		public async ValueTask TickStagingLobbies()
		{
			if ( timeSinceUpdate < 3 ) return;
			timeSinceUpdate = 0;

			var lobbies = await Lobby.GetList( null, "staging" );
			var existing = ChildrenOfType<LobbyIcon>().ToList();

			if ( lobbies?.Count() > 0 )
			{
				foreach ( var group in lobbies.GroupBy( x => x.GetData( "game" ) ) )
				{
					if ( group.Key.StartsWith( "local." ) )
						continue;

					var lobby = group.FirstOrDefault();
					var num_lobbies = group.Count();
					var num_players = group.Sum( x => x.MemberCount );

					var game = AddGame( group.Key );
					game.SetLobbyInformation( num_lobbies, num_players );

					existing.Remove( game );
				}
			}

			foreach ( var e in existing )
			{
				e.SetLobbyInformation( 0, 0 );
			}

			//Sort();
		}

		public LobbyIcon AddGame( string ident )
		{
			var gameIcon = ChildrenOfType<LobbyIcon>().FirstOrDefault( x => x.Ident == ident );

			if ( gameIcon == null )
			{
				gameIcon = new LobbyIcon();
				_ = gameIcon.Init( ident );
				AddChild( gameIcon );
			}

			return gameIcon;
		}
	}
}
