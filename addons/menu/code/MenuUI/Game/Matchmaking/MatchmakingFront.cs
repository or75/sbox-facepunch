
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.Internal;
using Sandbox.UI.Tests;

[UseTemplate]
public class MatchmakingFront : BaseGamePanel
{
	public VirtualScrollPanel LobbyCanvas { get; set; }

	public MatchmakingFront( BaseGamePanel gamePanel ) : base( gamePanel )
	{
		_ = Refresh();
	}

	protected override void PostTemplateApplied()
	{
		base.PostTemplateApplied();

		LobbyCanvas.OnCreateCell = CreateLobbyCell;
	}

	private void CreateLobbyCell( Panel cell, object obj )
	{
		if ( obj is not Lobby lobby ) return;

		var button = new LobbyButton( cell, lobby );
		button.AddEventListener( "onclick", () =>
		{
			CreateEvent( "joingamelobby", lobby );
		} );
	}

	public TimeSince lastRefresh;

	public override void Tick()
	{
		base.Tick();

		if ( !IsVisible )
			return;

		if ( lastRefresh < 2 )
			return;

		if ( HasHovered )
			return;

		lastRefresh = 0;
		_ = Refresh();
	}

	public async Task Refresh()
	{
		if ( Package == null )
			return;

		lastRefresh = 0;
		var result = await Lobby.GetList( Package.FullIdent );

		if ( result == null || result.Length == 0 )
		{
			LobbyCanvas.Clear();
			AddClass( "is-empty" );
			return;
		}

		LobbyCanvas.SetItems( result );
	}

	public void RefreshList()
	{
		_ = Refresh();
	}
}
