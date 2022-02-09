
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.Internal;

public class LobbyChat : Panel
{
	Lobby Lobby;
	public Panel Canvas { get; set; }
	public TextEntry TextEntry { get; set; }

	public LobbyChat()
	{
		AddClass( "lobbychat" );

		Canvas = Add.Panel( "canvas" );

		TextEntry = Add.TextEntry( "" );
		TextEntry.Placeholder = "Type to chat..";
		TextEntry.AddEventListener( "onsubmit", () =>
			{
				Lobby.SendChat( TextEntry.Text );
				TextEntry.Text = "";
				TextEntry.Focus();
			} );
	}

	protected override void PostTemplateApplied()
	{
		base.PostTemplateApplied();

		Canvas.AllowChildSelection = true;
		Canvas.PreferScrollToBottom = true;
	}

	internal void Init( Lobby lobby )
	{
		Lobby = lobby;
		Lobby.OnMemberChat += OnChat;
	}

	void OnChat( Friend friend, string message )
	{
		var status = Lobby.GetMemberData( friend, "status" );

		var p = Canvas.Add.Panel( "entry" );
		p.Add.Label( friend.Name, "name" );
		p.Add.Label( message, "message" );

		if ( status == "active" ) p.AddClass( "in-game" );
		if ( status == "staging" ) p.AddClass( "not-ready" );

		Canvas.TryScrollToBottom();

		CreateEvent( "onchat" );
	}

	public void PostChat( string text )
	{
		Lobby.SendChat( text );
		TextEntry.Text = "";
		TextEntry.Focus();
	}
}
