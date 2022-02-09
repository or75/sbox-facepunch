
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.Internal;

public class LobbyButton : Panel
{
	Lobby Lobby;
	Label PlayerCount;
	Panel Avatar;
	Label Text;
	Label DetailText;

	public LobbyButton( Panel parent, Lobby lobby )
	{
		Lobby = lobby;
		AddClass( "button-lobby" );

		Parent = parent;
		AddClass( $"state-{lobby.State}" );

		Avatar = Add.Panel( "icon" );
		Avatar.Style.SetBackgroundImage( $"avatar:{lobby.OwnerId}" );

		var textPanel = Add.Panel( "grow columns" );
		Text = textPanel.Add.Label( lobby.Title.Trim(), "label" );
		DetailText = textPanel.Add.Label( lobby.Map, "detail" );
		PlayerCount = Add.Label( $"{lobby.MemberCount}/{lobby.MaxMembers}", "player-count" );

		_ = Update();
	}

	RealTimeSince TimeSinceUpdate;

	public override void Tick()
	{
		base.Tick();

		if ( !IsVisible )
			return;

		if ( TimeSinceUpdate < 5 )
			return;

		_ = Update();
	}

	public async Task Update()
	{
		TimeSinceUpdate = Rand.Float( -0.5f, 0.5f );
		SetClass( "is-waiting", Lobby.State == "staging" );
		Lobby.Refresh();

		var text = "";

		switch ( Lobby.State )
		{
			case "active":
				{
					text = "in game";
					break;
				}

			case "staging":
				{
					text = "waiting for players";
					break;
				}

			case "loading":
				{
					text = "loading";
					break;
				}
		}

		var title = Lobby.Title.RemoveBadCharacters().Trim();
		if ( title.Length < 1 ) title = "Untitled Lobby";
		Text.Text = title;

		var mapInfo = await Package.Fetch( Lobby.Map, true );
		if ( mapInfo != null )
		{
			text = $"{mapInfo.Title} - {text}";
		}
		else
		{
			text = $"{Lobby.Map} - {text}";
		}

		DetailText.Text = text;
		PlayerCount.Text = $"{Lobby.MemberCount}/{Lobby.MaxMembers}";
	}
}
