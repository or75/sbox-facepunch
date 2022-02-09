
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[UseTemplate]
public class GameIcon : Panel
{
	public string Ident { get; protected set; }
	Label Players;

	public Panel Icon { get; set; }
	public Panel AuthorIcon{ get; set; }

	public Package Package { get; private set; }

	public GameIcon( Package package )
	{
		Ident = package.FullIdent;

		if ( !string.IsNullOrEmpty( package.Thumb ) )
		{
			Icon.Style.SetBackgroundImage( package.Thumb );
		}

		if ( !string.IsNullOrEmpty( package.Org.Thumb ) )
		{
			AuthorIcon.Style.SetBackgroundImage( package.Org.Thumb );
		}

		Package = package;
		Players = Add.Label( package.UsersNow.ToString( "n0" ), "players" );

		if ( package.UsersNow == 0 )
			AddClass( "no-players" );
	}

	public GameIcon( string package_ident )
	{
		Ident = package_ident;
		Players = Add.Label( "0", "players" );

		AddClass( "no-players" );

		_ = UpdatePackage( package_ident );
	}

	public async ValueTask UpdatePackage( string package_ident )
	{
		GameTitleFallbackeString = "Loading...";
		GameAuthorFallbackString = "Loading...";

		Package = await Package.Fetch( package_ident, true );
		if ( Package == null )
		{
			GameTitleFallbackeString = package_ident;
			GameAuthorFallbackString = "Failed to fetch game data";
			Log.Warning( $"No package found for {package_ident}" );
			return;
		}

		if ( !string.IsNullOrEmpty( Package.Thumb ) )
		{
			Icon.Style.SetBackgroundImage( Package.Thumb );
		}

		if ( !string.IsNullOrEmpty( Package.Org.Thumb ) )
		{
			AuthorIcon.Style.SetBackgroundImage( Package.Org.Thumb );
		}
	}

	string LobbyString;
	public string MetaString
	{
		get
		{
			if ( LobbyString != null )
				return LobbyString;

			return $"{Package.UsersTotal:n0} users";
		}
	}

	string GameTitleFallbackeString;
	public string GameTitleString
	{
		get
		{
			if ( Package != null )
				return Package.Title;

			return GameTitleFallbackeString;
		}
	}

	string GameAuthorFallbackString;
	public string GameAuthorString
	{
		get
		{
			if ( Package != null )
				return Package.Org.Title;

			return GameAuthorFallbackString;
		}
	}

	protected override void OnClick( MousePanelEvent e )
	{
		if ( Package == null ) return;
		if ( Package.PackageType != Package.Type.Gamemode ) return;

		CreateEvent( "navigate", $"/game/{Package.FullIdent}" );
	}

	int CurrentPlayers;
	int CurrentWaiting;

	internal void SetLobbyInformation( int num_players, int num_waiting )
	{
		CurrentPlayers = num_players;
		CurrentWaiting = num_waiting;

		SetClass( "has-lobby", num_waiting > 0 );

		if ( num_waiting == 0 )
		{
			LobbyString = $"{num_players:n0} playing";
			return;
		}

		if ( num_players > 0 )
			LobbyString = $"{num_players:n0} playing, {num_waiting:n0} {num_waiting.Plural( "player", "players" )} waiting to play";
		else
			LobbyString = $"{num_waiting:n0} waiting to play";
	}

	Dictionary<string, string> RecentConfig;

	internal void SetRecent( Dictionary<string, string> config )
	{
		if ( RecentConfig != null )
		{
			RecentConfig = config;
			return;
		}

		RecentConfig = config;
		var b = Add.ButtonWithIcon( null, "fast_forward", "quick-resume", () => Sandbox.MenuEngine.Tools.CreateGame( Package, RecentConfig ) );
		var remove = b.Add.ButtonWithIcon( null, "remove_circle", "remove" );
		remove.AddEventListener( "onclick", ( e ) =>
		{
			e.StopPropagation();
			Sandbox.Internal.GameCreateHistory.Remove( Package.FullIdent );
			RecentConfig = null;
			b?.Delete();
		} );
	}

	public int Order
	{
		get
		{
			var priority = 0;

			priority += 10 * CurrentPlayers;
			priority += 100 * CurrentWaiting;

			if ( RecentConfig != null )
				priority += 10000;

			return priority;
		}
	}
}


