
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Linq;
using System.Threading.Tasks;

[UseTemplate]
public class MainMenuPanel : RootPanel
{
	public Panel Background { get; protected set; }
	public Panel Overlay { get; protected set; }
	public Button FriendsButton { get; protected set; }
	public Button QuitButton { get; protected set; }


	public Panel Popup { get; protected set; }
	public Label PopupTitle { get; protected set; }
	public Label PopupMessage { get; protected set; }

	public NavigatorPanel Navigator { get; protected set; }

	public MainMenuPanel()
	{
		AcceptsFocus = true;

		Popup = Add.Panel( "popup" );
		{
			var inner = Popup.Add.Panel( "inner" );
			PopupTitle = inner.Add.Label( "...", "title" );
			PopupMessage = inner.Add.Label( "...", "message" );
			inner.Add.Button( "Close", () => SetClass( "popup-active", false ) );
		}

		BindClass( "is-vr", () => IsVR );
	}

	/// <summary>
	/// This is called right after SetTemplate has loaded the template (or it's hotloaded)
	/// </summary>
	protected override void PostTemplateApplied()
	{
		UpdatePlayingFriendCount();
	}
	protected override void UpdateBounds( Rect rect )
	{
		if ( IsVR )
		{
			PanelBounds = new Rect( 0, 0, 3840, 2400 );
			return;
		}

		base.UpdateBounds( rect );
	}

	protected override void UpdateScale( Rect screenSize )
	{
		if ( IsVR )
		{
			Scale = 2.33f;
			return;
		}

		base.UpdateScale( screenSize );
	}

	internal void ShowPopup( string type, string title, string subtitle )
	{
		AddClass( "popup-active" );

		PopupTitle.Text = title;
		PopupMessage.Text = subtitle;
	}

	[Event( "friend.change" )]
	public void UpdatePlayingFriendCount()
	{
		var c = Friend.GetAll().Count( x => x.IsPlayingThisGame && x.IsFriend );
		FriendsButton?.SetText( $"{c:n0}" );
	}

	bool wasInGame = false;

	public override void Tick()
	{
		base.Tick();

		if ( wasInGame != Global.InGame )
		{
			if ( Global.InGame ) OnEnterGame();
			else OnLeaveGame();

			SetClass( "ingame", Global.InGame );
			wasInGame = Global.InGame;
		}

		if ( !IsVisible ) return;

		SetClass( "has-streamer-account", Sandbox.MenuEngine.Account.HasLinkedStreamerServices );
		SetClass( "has-tools", Global.IsToolsMode );
	}

	void OnEnterGame()
	{
		Navigator.Navigate( "/activegame" );
	}

	void OnLeaveGame()
	{
		if ( Navigator.CurrentUrl.StartsWith( "/activegame" ) )
		{
			Navigator.Navigate( "/home" );
		}

		Navigator.RemoveUrls( x => x.StartsWith( "/activegame" ) );
	}


	public override void OnButtonEvent( ButtonEvent e )
	{
		if ( e.Pressed && e.Button == "escape" && Global.InGame )
		{
			MenuSystem.Instance.SetMenuScreen( false );
		}

		base.OnButtonEvent( e );
	}

	public void SetOverlay( Panel newOverlay )
	{
		Overlay?.Delete();
		Overlay = newOverlay;

		SetClass( "has-overlay", Overlay != null );
	}

	public void OverlayClosed( Panel overlay )
	{
		if ( overlay != Overlay ) return;

		Overlay?.Delete();
		Overlay = null;

		SetClass( "has-overlay", false );
	}

	public void ToggleFriendList()
	{
		FriendList.Toggle( this, FriendsButton );
	}

	public void OpenUITest()
	{
		AddChild<UITests>();
	}
}
