
using Sandbox;
using Sandbox.Internal;
using Sandbox.UI;
using Sandbox.UI.Construct;

public class StreamDeck : Button
{
	public StreamDeck()
	{
		Icon = "wifi";
		AddClass( "tight" );
		AddClass( "streamdeck" );
	}


	public override void Tick()
	{
		base.Tick();

		if ( !IsVisible )
			return;

		SetClass( "active", Streamer.IsActive );

		if ( !Streamer.IsActive )
		{
			DeleteText();
		}
		else
		{
			Text = $"{Streamer.ViewerCount}";
		}
	}

	protected override void OnMouseDown( MousePanelEvent e )
	{
		base.OnMouseDown( e );

		ActiveStreamPopup( this );
	}

	void ActiveStreamPopup( Panel parent )
	{
		var popup = new Popup( parent, Popup.PositionMode.BelowCenter, 32.0f );
		popup.AddClass( "medium" );

		if ( Streamer.IsActive )
		{
			popup.Title = $"Connected To {Streamer.Service}"; 
			popup.Icon = "wifi";

			popup.Add.Button( $"Disconnect", () =>
			{
				Sandbox.MenuEngine.Tools.DisconnectStream();
				popup.Delete();
			} );
		}
		else
		{
			popup.Title = "Streamer Mode";
			popup.Icon = "wifi";

			popup.Add.ButtonWithIcon( $"Connect to Twitch", "live_tv", null, () =>
			{
				Sandbox.MenuEngine.Tools.ConnectStream( StreamService.Twitch );
				popup.Delete();
			} );
		}
	}

	//
	// Tests
	//

	[Event.Streamer.ChatMessage]
	public static void OnStreamMessage( StreamChatMessage message )
	{
		Log.Trace( $"[{message.Username}] {message.Message}" );
	}

	[Event.Streamer.JoinChat]
	public static void OnStreamJoinEvent( string user )
	{
		Log.Info( $"{user} joined" );
	}

	[Event.Streamer.LeaveChat]
	public static void OnStreamLeaveEvent( string user )
	{
		Log.Info( $"{user} left" );
	}
}
