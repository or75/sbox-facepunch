using Sandbox;
using System.Collections.Generic;
using Sandbox.UI;
using System.Numerics;
using Sandbox.UI.Dev;
using Sandbox.Internal;

[Library]
public partial class MenuSystem : Sandbox.IMenuAddon
{
	public static MenuSystem Instance;

	MainMenuPanel Menu;
	DevLayer Dev;
	LoadingScreen Loading;

	VROverlayPanel VRMenu;
	VROverlayPanel VRLoading;

	public override void Init()
	{
		Instance = this;

		// Creation order is important
		// Panel created first will be on top

		Dev = new DevLayer();
		MenuOverlay.Init();
		Loading = new LoadingScreen();
		Menu = new MainMenuPanel();

		// Make a seperate instance of the menu for VR, lets you still use dev stuff on desktop
		// Let's us whack up the resolution / scale too so it looks good

		if ( VR.Enabled )
		{
			VRMenu = new VROverlayPanel( new MainMenuPanel() )
			{
				Transform = new Transform( Vector3.Forward * 38.0f + Vector3.Up * 58.0f ),
				Width = 40.0f,
				Curvature = 0.2f,
			};

			VRLoading = new VROverlayPanel( new LoadingScreen() )
			{
				Transform = new Transform( Vector3.Forward * 38.0f + Vector3.Up * 58.0f ),
				Width = 40.0f,
				Curvature = 0.2f,
				SortOrder = 1,
				Visible = false,
			};
		}

		Sandbox.MenuEngine.Tools.SetDevLayer( Dev );
	}

	public override void Shutdown()
	{
		MenuOverlay.Shutdown();

		VRMenu?.Dispose();
		VRMenu = null;

		VRLoading?.Dispose();
		VRLoading = null;

		Menu?.Delete();
		Menu = null;

		Loading?.Delete();
		Loading = null;

		Dev?.Delete();
		Dev = null;
	}

	public override void SetMenuScreen( bool show )
	{
		Menu.SetClass( "hidden", !show );

		if ( show )
		{
			Menu.Focus();
		}
		else
		{
			Menu.Blur();
		}

		if ( VRMenu != null )
		{
			VRMenu.Visible = show;
		}
	}

	public override bool IsMenuScreenVisible()
	{
		return Menu.IsVisible;
	}

	public override void SetLoading( bool show )
	{
		Loading.SetClass( "hidden", !show );

		if ( VRLoading != null )
		{
			VRLoading.Visible = show;
			VRLoading.RootPanel.SetClass( "hidden", !show );
		}
	}

	public override void OnLoadProgress( float progress, string title, string subtitle, string statistic )
	{
		Loading.UpdateProgress( progress, title, subtitle, statistic );
	}

	public override void OnDownloadProgress( long got, long total )
	{
		Loading.UpdateDownloadProgress( got, total );
	}

	public override void DevNotice( string category, string icon, string title, int seconds, string type, string information )
	{
		DevLayer.DevNoticeAdd( category, type, icon, title, seconds, information );
	}

	public override void Popup( string type, string title, string subtitle )
	{
		Menu?.ShowPopup( type, title, subtitle );
	}
}
