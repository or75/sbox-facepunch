
using Party;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using Sandbox.UI.Dev;
using Sandbox.Internal;
using System;
using System.Linq;
using System.Threading.Tasks;

[UseTemplate]
public class PartyDeck : Panel
{
	public Button Avatar { get; set; }
	public Panel InviteButtons { get; set; }
	public Panel FriendButtons { get; set; }

	Lobby _lobby;

	Lobby Lobby
	{
		get => _lobby;

		set
		{
			if ( _lobby == value ) 
				return;

			_lobby?.Dispose();

			_lobby = value;

			if ( _lobby == null )
			{
				MenuOverlay.Message( $"You have left the party", "airport_shuttle" );
				UpdateFriends();
				return;
			}

			_lobby.OnMemberJoined = OnJoin;
			_lobby.OnMemberLeave = OnLeave;
			_lobby.OnMemberChanged = OnChanged;
			_lobby.OnLobbyChanged = OnLobbyChanged;

			OnLobbyChanged();
		}
	}

	public void AddInviteButton()
	{
		var button = InviteButtons.Add.Button( null, "tight active" );
		button.Icon = "add_circle_outline";
		button.AddEventListener( "onmousedown", ( e ) => InviteFriendPopup( button ) );
	}

	protected override void PostTemplateApplied()
	{
		base.PostTemplateApplied();

		Avatar?.Style.SetBackgroundImage( $"avatar:{Local.PlayerId}" );
		Avatar?.AddEventListener( "onmousedown", ( e ) => SelfPopup( Avatar ) );

		UpdateFriends();
	}

	void UpdateFriends()
	{
		if ( Lobby == null )
		{
			RebuildInviteButtons( 3 );
			Avatar?.SetClass( "owner", false );
			FriendButtons?.DeleteChildren( true );
			return;
		}

		var friendPanels = FriendButtons.ChildrenOfType<PartyFriend>().ToList();
		var friends = Lobby.Members.Where( x => !x.IsMe ).ToList();

		foreach ( var friend in friends )
		{
			if ( friendPanels.Any( x => x.Friend.Id == friend.Id ) )
				continue;

			var friendButton = new PartyFriend( friend, FriendButtons );
			friendButton.AddEventListener( "onmousedown", ( e ) => PartyMemberPopup( friendButton, friend ) );
			friendPanels.Add( friendButton );
		}

		foreach( var button in friendPanels )
		{
			button?.SetClass( "owner", button.Friend.Id == Lobby.Owner.Id );
		}

		foreach( var button in friendPanels.Where( x => !friends.Contains( x.Friend ) ).ToArray() )
		{
			button.Delete( true );
		}

		RebuildInviteButtons( Math.Max( 1, 3 - friends.Count() ) );
		Avatar?.SetClass( "owner", Lobby.Owner.IsMe );
	}

	void RebuildInviteButtons( int count )
	{
		InviteButtons?.DeleteChildren( true );

		for ( int i = 0; i < count; i++ )
		{
			AddInviteButton();
		}
	}

	private void SelfPopup( Panel parent )
	{
		var popup = new Popup( parent, Popup.PositionMode.BelowCenter, 32.0f );
		popup.AddClass( "medium" );
		popup.Title = "The Party";
		popup.Icon = "cake";

		if ( Lobby == null )
		{
			popup.Add.ButtonWithIcon( "Create New Party", "add", null, () =>
			{
				_ = TryCreateLobby();
				popup.Success();
			} );
		}
		else
		{
			var isOwner = Lobby.Owner.IsMe;

			popup.Add.ButtonWithIcon( "Leave The Party", "time_to_leave", null, () =>
			{
				Lobby = null;
				popup.Success();
			} );
		}
	}

	private void PartyMemberPopup( Panel parent, Friend friend )
	{
		var isOwner = Lobby?.Owner.IsMe ?? false;

		var popup = new Popup( parent, Popup.PositionMode.BelowCenter, 32.0f );
		popup.AddClass( "medium" );
		popup.Title = friend.Name;
		popup.Icon = "account_circle";

		popup.Add.ButtonWithIcon( "Make Party Owner", "local_police", isOwner ? null : "disabled", () =>
		{
			Lobby.Owner = friend;
			popup.Success();
		} );

		popup.Add.ButtonWithIcon( "View Steam Profile", "account_circle", null, () =>
		{
			popup.Success();
		} );
	}

	void InviteFriendPopup( Panel parent )
	{
		var popup = new Popup( parent, Popup.PositionMode.BelowCenter, 32.0f );
		popup.AddClass( "medium" );
		popup.Title = "Invite To Party";
		popup.Icon = "celebration";

		var friends = Friend.GetAll().Where( x => x.IsOnline && x.IsPlayingThisGame ).ToList();

		foreach ( var friend in friends )
		{
			var panel = new FriendLine( popup, friend ); 
			panel.AddEventListener( "onmousedown", ( e ) => 
			{ 
				_ = InviteFriend( friend );
				popup.Success();
			} );
		}

		if ( friends.Count == 0 )
		{
			popup.Add.Label( "None of your friends are in game right now. Ask them to start the game so you can invite them to your party", "information" );
		}

		popup.Add.ButtonWithIcon( "Invite Someone Else...", "person_search", null, () =>
		{
			_ = InviteFriend();
			popup.Success();
		} );
	}

	private async Task TryCreateLobby()
	{
		if ( Lobby != null )
			return;

		Lobby = await Lobby.Create( 16, null, null );

		if ( Lobby == null )
		{
			Log.Warning( "Problem creating lobby - couldn't invite anyone" );
			return;
		}
	}

	private async Task InviteFriend()
	{
		await TryCreateLobby();
		Lobby.InviteUsingOverlay();
	}

	private async Task InviteFriend( Friend friend )
	{
		await TryCreateLobby();
		Lobby.InviteFriend( friend );
	}

	[Event( "lobby.invite" )]
	public void OnPartyInvite( Lobby invitedLobby, Friend friend )
	{
		MenuOverlay.Question( $"{friend.Name} invited you to their party", "sports_kabaddi", () => _ = OnPartyAcceptInvite( invitedLobby, friend ), null );
	}

	[Event( "lobby.acceptinvite" )]
	public async Task OnPartyAcceptInvite( Lobby invitedLobby, Friend friend )
	{
		if ( Lobby != null && Lobby.Id == invitedLobby.Id )
		{
			Log.Warning( "Already in this lobby" );
			return;
		}

		Lobby?.Dispose();
		Lobby = null;

		UpdateFriends();

		if ( await invitedLobby.TryJoin() )
		{
			Lobby = invitedLobby;
			UpdateFriends();
		}
	}

	void OnJoin( Friend friend )
	{
		UpdateFriends();

		MenuOverlay.Message( $"{friend.Name}", "joined the party", Texture.LoadAvatar( friend.Id ) );
	}

	void OnLeave( Friend friend )
	{
		UpdateFriends();
		MenuOverlay.Message( $"{friend.Name}", "left the party", Texture.LoadAvatar( friend.Id ) );
	}

	void OnChanged( Friend friend )
	{
		UpdateFriends();
		Log.Info( $"Party Member {friend} changed" );
	}

	void OnLobbyChanged()
	{
		UpdateFriends();
		UpdateLobbyData();
	}

	[Event( "game.lobby.join" )]
	public void OnJoinedGameLobby( ulong id )
	{
		if ( Lobby == null ) return;

		if ( Lobby.Owner.IsMe )
		{
			Lobby?.SetData( "game_lobby", id.ToString() );
			return;
		}
	}

	[Event( "game.lobby.leave" )]
	public void OnJoinedGameLeave()
	{
		if ( Lobby == null ) return;

		if ( Lobby.Owner.IsMe )
		{
			Lobby?.SetData( "game_lobby", "" );
			return;
		}
	}

	void UpdateLobbyData()
	{
		if ( Lobby == null ) return;

		CurrentGameLobby = Lobby.GetData( "game_lobby" ) ?? "";
	}


	string _currentGameLobby;

	public string CurrentGameLobby
	{
		set
		{
			if ( string.IsNullOrEmpty( _currentGameLobby ) && string.IsNullOrEmpty( value ) ) return;

			_currentGameLobby = value;
			Log.Info( $"Looks like the game lobby changed to {_currentGameLobby}" );

			// We call the shots, don't follow them
			if ( Lobby.Owner.IsMe )
				return;

			if ( string.IsNullOrEmpty( _currentGameLobby ) )
			{
				ConsoleSystem.Run( "disconnect" );
				return;
			}

			_ = JoinGame( ulong.Parse( _currentGameLobby ) );
		}
	}

	private async Task JoinGame( ulong lobbyId )
	{
		// Lets join this game lobby
		var gameLobby = await Lobby.TryJoinLobby( lobbyId );
		if ( gameLobby == null )
		{
			Log.Error( "Oh oh - couldn't join game lobby!?" );
			return;
		}

		gameLobby.JoinGame();
	}
}
