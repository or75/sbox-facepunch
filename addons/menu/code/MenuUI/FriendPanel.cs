
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Threading.Tasks;

public class FriendPanel : Panel
{
	public Friend Friend;

	public int Order;

	Label Name;
	Label Status;
	Image Avatar;

	Button JoinGameButton;

	public FriendPanel(  )
	{
		Name = Add.Label( "...", "name" );
		Status = Add.Label( "...", "status" );
		Avatar = Add.Image( "", "avatar" );

		JoinGameButton = Add.Button( "JOIN", () => _ = JoinGame() );
		JoinGameButton.AddClass( "join" );
	}

	public void Update( Friend friend )
	{
		Friend = friend;
		SetClass( "offline", !friend.IsOnline );

		if ( !friend.IsOnline ) return;

		Name.Text = Friend.Name;
		Avatar.SetTexture( $"avatar:{friend.Id}" );
		var order = (int) char.ToLower( Name.Text[0] );

		var playingThisGame = friend.IsPlayingThisGame;
		var playingAnyGame = friend.IsPlayingAGame;
		var joinable = false;

		SetClass( "isplayingthisgame", playingThisGame );
		SetClass( "isplaying", playingAnyGame );
		SetClass( "away", friend.IsAway );

		if ( friend.IsAway )
		{
			Status.Text = "Away";
			order += 500;
		}

		if ( playingThisGame )
		{
			var game = Friend.GetRichPresence( "gametitle" );
			var map = Friend.GetRichPresence( "map" );

			if ( string.IsNullOrEmpty( game ) ) Status.Text = "[Unknown State]";
			else if ( game == "menu" ) Status.Text = "In the main menu";
			else Status.Text = $"{game} - {map}";

			var lobbyId = Friend.GetRichPresence( "lobby" );
			if ( !string.IsNullOrEmpty( lobbyId ) )
			{
				joinable = true;
			}
		}
		else if ( playingAnyGame )
		{
			Status.Text = "Playing something else";
			order += 10000;
		}
		else
		{
			Status.Text = "Online";
			order += 100000;
		}

		if ( order != Order )
		{
			Order = order;
			Parent.Parent.CreateEvent( "friendupdated" );
		}

		SetClass( "joinable", joinable );
	}

	async Task JoinGame()
	{
		var lobbyId = Friend.GetRichPresence( "lobby" );
		if ( !ulong.TryParse( lobbyId, out ulong lobbySteamId ) )
		{
			Log.Warning( $"Couldn't join player - the lobby is '{lobbyId}'" );
			return;
		}

		var gameLobby = await Lobby.TryJoinLobby( lobbySteamId );
		if ( gameLobby == null )
		{
			Log.Warning( "Oh oh - couldn't join game lobby!?" );
			return;
		}

		gameLobby.JoinGame();
	}
}
