
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;

public class FriendList : Panel
{
	public static FriendList Instance;

	public Label Title;
	public Panel Canvas;
	bool needsSort;

	Button ParentButton;

	public FriendList( Panel parent )
	{
		Parent = parent;

		StyleSheet.Load( "/MenuUI/FriendList.scss" );

		Title = Add.Label( "Friends", "title" );
		Canvas = Add.Panel( "canvas" );

		Instance = this;

		FullRefresh();
	}

	public override void OnDeleted()
	{
		base.OnDeleted();

		ParentButton?.SetClass( "active", false );
	}

	public void FullRefresh()
	{
		Canvas.DeleteChildren();

		foreach( var friend in Friend.GetAll() )
		{
			if ( !friend.IsOnline ) continue;
			if ( friend.IsMe ) continue;
			if ( !friend.IsPlayingThisGame ) continue;

			var friendPanel = Canvas.AddChild<FriendPanel>();
			friendPanel.Update( friend );
		}
	}

	[Event( "friend.change" )]
	public void SteamFriends_OnPersonaStateChange( Friend friend )
	{
		Log.Info( "Friend State Change: " + friend );

		if ( friend.IsMe ) return;

		foreach ( var child in Canvas.Children )
		{
			if ( child is FriendPanel fp && fp.Friend.Id == friend.Id )
			{
				if ( friend.IsPlayingThisGame ) fp.Update( friend );
				else fp.Delete();

				return;
			}
		}

		if ( !friend.IsPlayingThisGame )
			return;

		var friendPanel = Canvas.AddChild<FriendPanel>();
		friendPanel.Update( friend );
	}

	internal static void Toggle( MainMenuPanel mainMenuPanel, Button button )
	{
		if ( Instance != null )
		{
			Close();
			return;
		}

		Instance = new FriendList( mainMenuPanel );
		Instance.ParentButton = button;
		button.SetClass( "active", true );
	}

	internal static void Close()
	{
		Instance?.Delete();
		Instance = null;		
	}


	public override void Tick()
	{
		base.Tick();

		if ( needsSort )
		{
			Canvas.SortChildren<FriendPanel>( ( x ) => x.Order );
		}
	}

	public void FriendUpdatedEvent()
	{
		needsSort = true;
	}
}


