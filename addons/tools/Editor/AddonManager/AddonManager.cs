using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools;
using Sandbox;

[Dock( "Editor", "Addon Manager", "snippet_folder" )]
public class AddonManager : Widget
{
	public static AddonManager Singleton;

	AddonSwitcher Switcher;
	BaseAddonEditor Editor;
	ScrollArea EditorArea;
	BoxLayout Layout;
	AddonHelpPage HelpPage;

	public AddonManager( Widget parent ) : base( parent )
	{
		Singleton = this;

		AcceptDrops = true;

		Layout = MakeTopToBottom();
		Layout.SetContentMargins( 4, 4, 4, 4 );
		Layout.Spacing = 4;

		var header = new Widget( this );
		header.MinimumSize = 64;
		header.MousePress = OnHeaderPressed;
		Layout.Add( header );

		Switcher = new AddonSwitcher( this );
		Switcher.OnAddonChosen += SwitchToAddon;
		Layout.Add( Switcher, 1 );
		Switcher.Visible = false;

		HelpPage = new AddonHelpPage( this );
		Layout.Add( HelpPage, 1 );

		//
		// Restore to last selected addon, if available
		//
		var defaultAddon = Cookie.GetString( "addonmanager.addon", null );
		if ( defaultAddon != null )
		{
			var addon = Utility.Addons.GetAll().FirstOrDefault( x => x.Path == defaultAddon );
			if ( addon != null ) SwitchToAddon( addon );
		}
	}

	protected override void OnPaint()
	{
		base.OnPaint();

		var rect = new Rect( 0, Size );
		var header_rect = rect;
		header_rect.height = 64;
		var addon = Editor?.Addon;
		var open = Switcher.Visible;

		if ( open )
		{
			Paint.SetBrush( Theme.Black.WithAlpha( 0.2f ) );
			Paint.SetPen( Theme.Blue.WithAlpha( 0.8f ) );
			Paint.DrawRect( rect.Expand( -1.0f ) );
		}
		
		{
			Paint.SetPen( Theme.Black.WithAlpha( open ? 0.1f : 0.3f ), 1 );
			Paint.DrawLine( header_rect.BottomLeft, header_rect.BottomRight );
		}

		Paint.SetDefaultFont( 8, 400 );
		Paint.SetPen( Theme.White.WithAlpha( 0.4f ) );
		Paint.DrawText( header_rect.Expand( -64, -16 ), "Current Addon", TextFlag.LeftTop );

		Paint.DrawMaterialIcon( header_rect.Expand( -20, 0 ), addon == null ? MaterialIcon.PostAdd : MaterialIcon.FactCheck, 24, TextFlag.LeftCenter );
		Paint.SetDefaultFont( 10, 450 );

		if ( addon == null )
		{
			Paint.SetPen( Theme.White.WithAlpha( 0.6f ) );
			Paint.DrawText( header_rect.Expand( -64, -16 ), "Select or add an addon", TextFlag.LeftBottom );
		}
		else
		{
			Paint.SetPen( Theme.White );
			Paint.DrawText( header_rect.Expand( -64, -16 ), addon.Config?.Title ?? addon.Config?.FullIdent, TextFlag.LeftBottom );
		}

		Paint.SetPen( Theme.White );
		Paint.DrawMaterialIcon( header_rect.Expand( -16, 0 ), open ? MaterialIcon.ArrowDropUp : MaterialIcon.ArrowDropDown, 18, TextFlag.Right | TextFlag.VCenter );
	}

	private void OnHeaderPressed()
	{
		Switcher.Visible = !Switcher.Visible;

		if ( EditorArea != null )
		{
			EditorArea.Visible = !Switcher.Visible;
		}

		if ( Switcher.Visible )
		{
			Switcher.UpdateAddonList();

			HelpPage.Visible = false;
		}
		else
		{
			HelpPage.Visible = !(EditorArea?.Visible ?? false);
		}

		Update();
	}

	public void SwitchToAddon( LocalAddon addon )
	{
		EditorArea?.Destroy();

		Editor?.Destroy();
		Editor = BaseAddonEditor.CreateFor( this, addon );

		EditorArea = new ScrollArea( this );
		EditorArea.Canvas = Editor;

		Layout.Add( EditorArea, 1 );

		Switcher.Visible = false;
		HelpPage.Visible = false;

		Update();

		//
		// Save last addon
		//
		Cookie.SetString( "addonmanager.addon", addon.Path );
	}

	public override DropAction OnDragEnter( DragData data )
	{
		if ( !data.HasFileOrFolder )
			return DropAction.Ignore;

		if ( !AddonSwitcher.IsAcceptableAddonPath( data.FileOrFolder ) )
			return DropAction.Ignore;

		return DropAction.Link;
	}

	public override DropAction OnDropEvent( DragData data )
	{
		if ( !data.HasFileOrFolder )
			return DropAction.Ignore;

		if ( !AddonSwitcher.IsAcceptableAddonPath( data.FileOrFolder ) )
			return DropAction.Ignore;

		try
		{
			var addon = Utility.Addons.TryAddFromFile( data.FileOrFolder );
			SwitchToAddon( addon );
		}
		catch ( Exception ex )
		{
			Log.Warning( ex, $"Couldn't add addon from disk: { ex.Message }" );
		}

		return DropAction.Link;
	}

	class AddonHelpPage : Widget
	{
		public AddonHelpPage( Widget parent ) : base( parent )
		{
		}

		protected override void OnPaint()
		{
			base.OnPaint();

			var rect = LocalRect;

			Paint.SetPen( Color.White.WithAlpha( 0.3f ) );
			Paint.DrawText( rect.Contract( 16.0f ), "To switch between addons click the header of this panel.\n\nIf you want to create a new addon or add an existing one you can also click the header and press the \"add\" button. You can also use the Addons menu for this.", TextFlag.LeftTop | TextFlag.WordWrap );
		}
	}
}
