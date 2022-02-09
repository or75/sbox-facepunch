using Sandbox;
using System;
using System.Linq;
using Tools;

public class AddonSwitcher : Widget
{
	LineEdit Filter;
	ScrollArea AddonList;


	[Menu( "Editor", "Addons//Add From Disk..", "folder" )]
	public static void AddFromFile()
	{
		var fd = new FileDialog( null );
		fd.Title = "Find addon file";
		fd.SetNameFilter( ".addon" );

		if ( fd.Execute() )
		{
			try
			{
				var addon = Utility.Addons.TryAddFromFile( fd.SelectedFile );
				AddonManager.Singleton?.SwitchToAddon( addon );
			}
			catch ( Exception ex )
			{
				Log.Warning( ex, $"Couldn't add addon from disk: { ex.Message }" );
			}
		}
	}

	public static bool IsAcceptableAddonPath( string path )
	{
		if ( !path.EndsWith( ".addon" ) )
			path = System.IO.Path.Combine( path, ".addon" );

		return System.IO.File.Exists( path );
	}

	public AddonSwitcher( Widget parent ) : base( parent )
	{
		var layout = MakeTopToBottom();
		layout.Spacing = 4;

		AddonList = new ScrollArea( this );

		var toolbar = new ToolBar( this );
		layout.Add( toolbar );

		Filter = new LineEdit( this );
		Filter.PlaceholderText = "Filter..";
		Filter.TextEdited += OnTextEdited;
		toolbar.AddWidget( Filter );

		var addButton = new Button( "Add", "add", this );
		addButton.Clicked += () =>
		{
			var menu = new Menu( addButton );
			menu.AddOption( "Add From Disk..", "folder", AddFromFile );
			menu.AddOption( "Create New..", "create_new_folder", () => AddonCreator.AddNewAddon() );

			menu.OpenAt( addButton.ScreenPosition + new Vector2( 0, addButton.Size.y ) );
		};

		toolbar.AddWidget( addButton );

		layout.Add( AddonList, 1 );

		UpdateAddonList();
	}

	private void OnTextEdited( string obj )
	{
		UpdateAddonList();
	}

	[Event( "localaddons.changed") ]
	public void UpdateAddonList()
	{
		AddonList.Canvas = new Widget( AddonList );
		AddonList.Canvas.SetStyles( "background-color: transparent;" );

		var topDown = AddonList.Canvas.MakeTopToBottom();

		foreach ( var group in Utility.Addons.GetAll().GroupBy( x => x.Active ).OrderByDescending( x => x.Key ) )
		{
			var header = topDown.Add( new Label( group.Key ? "Active" : "Disabled" ) );
			header.SetStyles( "padding: 5px; margin-top: 10px; font-weight: bold; color: rgba( 255, 255, 255, 0.3 );" );

			foreach ( var addon in group.OrderBy( x => x.Config.Title ) )
			{
				var button = new AddonButton( addon, AddonList.Canvas );
				button.MouseClick = () => SelectAddon( addon );

				topDown.Add( button );
			}
		}

		topDown.AddStretchCell( -1 );
	}

	public Action<LocalAddon> OnAddonChosen;

	private void SelectAddon( LocalAddon addon )
	{
		OnAddonChosen?.Invoke( addon );
	}

	class AddonButton : Widget
	{
		public LocalAddon Addon { get; }
		public CheckBox AddonEnabled { get; set; }

		public AddonButton( LocalAddon addon, Widget parent ) : base( parent )
		{
			Addon = addon;
			MinimumSize = 32;
			Cursor = CursorShape.Finger;
			MouseTracking = true;
		}

		protected override void OnMouseEnter()
		{
			base.OnMouseEnter();
			Update();
		}

		protected override void OnMouseLeave()
		{
			base.OnMouseLeave();
			Update();
		}


		protected override void OnPaint()
		{
			var rect = new Rect( 0, Size );
			rect.height -= 1;

			var fg = IsUnderMouse ? Theme.Blue : Theme.White;

			if ( Addon.Broken )
				fg = Color.Lerp( fg, Theme.Red, 0.5f );

			if ( !Addon.Active )
				fg = Color.Lerp( fg, Theme.Grey, 0.8f );

			if ( IsUnderMouse )
			{
				Paint.ClearPen();
				Paint.SetBrush( Theme.Blue.Darken( 0.5f ).Desaturate( 0.3f ).WithAlpha( 0.2f ) );
				Paint.DrawRect( rect );
			}

			Paint.SetPen( fg.WithAlpha( 0.7f ) );

			switch ( Addon.Config.Type )
			{
				case "map":
					{
						Paint.DrawMaterialIcon( rect.Expand( -8, 0 ), MaterialIcon.Public, 16, TextFlag.LeftCenter );
						break;
					}

				default:
					{
						Paint.DrawMaterialIcon( rect.Expand( -8, 0 ), MaterialIcon.Gamepad, 16, TextFlag.LeftCenter );
						break;
					}
			}

			Paint.SetDefaultFont();
			Paint.SetPen( fg );
			var titlerect = Paint.DrawText( rect.Expand( -36, 0 ), Addon.Config.Title ?? Addon.Config.FullIdent, TextFlag.LeftCenter );		
		}

		protected override void OnMousePress( MouseEvent e )
		{
			if ( e.Button == MouseButtons.Right )
			{
				var menu = new Menu();

				if ( Addon.Active )
				{
					menu.AddOption( "Enabled", "check", () =>
					{
						Addon.Active = false;
						Utility.Addons.Updated( Addon, true );
					} );
				}
				else
				{
					menu.AddOption( "Enabled", null, () =>
					{
						Addon.Active = true;
						Utility.Addons.Updated( Addon, true );
					} );
				}

				if ( Addon.Config.Directory != null )
				{
					menu.AddOption( "Open Folder..", "folder", () => Utility.OpenFolder( Addon.Config.Directory.FullName ) );
				}

				menu.AddSeparator();

				menu.AddOption( "Remove Addon", "delete", () => Utility.Addons.Remove( Addon ) );
				menu.AddSeparator();
				menu.OpenAt( e.ScreenPosition );

				e.Accepted = true;
				return;
			}

			base.OnMousePress( e );

		}
	}

}
