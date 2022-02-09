
using Sandbox;
using Sandbox.Internal;
using Sandbox.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[UseTemplate, NavigatorTarget( "/home" )]
public partial class Home : Panel
{
	public Panel MainCell { get; set; }
	public Panel TileCanvas { get; set; }
	public Panel Favourites { get; set; }

	public Home()
	{

	}

	protected override void PostTemplateApplied() => Rebuild();

	[Event( "menu.home.rebuild" )]
	public void Rebuild()
	{
		AddFavourites();
		RefreshAvatar();
	}

	void AddFavourites()
	{
		Favourites?.DeleteChildren( true );

		var favourites = Sandbox.MenuEngine.Account.Favourites;
		if ( favourites?.Count() == 0 ) return;

		var history = Sandbox.Internal.GameCreateHistory.GetHistory();

		foreach ( var item in favourites )
		{
			var game = AddGame( item, Favourites );

			var config = history.FirstOrDefault( x => x.Package.FullIdent == item.FullIdent );
			if ( config != null )
			{
				game.SetRecent( config.Config );
			}
		}
	}

	public override void Tick()
	{
		base.Tick();

		if ( !IsVisible )
			return;

		TickAvatar();
		_ = TickStagingLobbies();
	}

	RealTimeSince timeSinceUpdate = 60;

	public async ValueTask TickStagingLobbies()
	{
		if ( timeSinceUpdate < 3 ) return;
		timeSinceUpdate = 0;

		var existing = TileCanvas.ChildrenOfType<GameIcon>().ToList();

		var lobbies = await Lobby.GetList( null, null );

		if ( lobbies != null && lobbies.Count() > 0 )
		{
			foreach ( var group in lobbies.GroupBy( x => x.GetData( "game" ) ) )
			{
				if ( group.Key.StartsWith( "local." ) || string.IsNullOrEmpty( group.Key ) )
					continue;

				var lobby = group.FirstOrDefault();
				var num_lobbies = group.Count();

				var num_playing = group.Where( x => x.State != "staging" ).Sum( x => x.MemberCount );
				var num_waiting = group.Where( x => x.State == "staging" ).Sum( x => x.MemberCount );

				var game = AddGame( group.Key );
				game.SetLobbyInformation( num_playing, num_waiting );

				existing.Remove( game );
			}
		}

		foreach( var e in existing )
		{
			e.SetLobbyInformation( 0, 0 );
		}

		Sort();
	}

	public GameIcon AddGame( string ident )
	{
		var gameIcon = TileCanvas.ChildrenOfType<GameIcon>().FirstOrDefault( x => x.Ident == ident );

		if ( gameIcon == null )
		{
			gameIcon = new GameIcon( ident );
			TileCanvas?.AddChild( gameIcon );
		}

		return gameIcon;
	}

	public GameIcon AddGame( Package package, Panel parent )
	{
		var gameIcon = parent.ChildrenOfType<GameIcon>().FirstOrDefault( x => x.Ident == package.FullIdent );

		if ( gameIcon == null )
		{
			gameIcon = new GameIcon( package );
			parent.AddChild( gameIcon );
		}

		return gameIcon;
	}

	void Sort()
	{
		TileCanvas.SortChildren<GameIcon>( x => -x.Order );
	}
}

