
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.Internal;

[UseTemplate]
[NavigatorTarget( "/games/all" )]
public class GameList : Panel
{
	List<GameIcon> GameIcons = new List<GameIcon>();

	public string SearchText { get; set; }
	public string SortOrder { get; set; } = "newest";
	public int Category { get; set; } = 0;
	public string ControlTag { get; set; }

	public bool VR => Sandbox.VR.Enabled;

	public Panel Canvas { get; set; }
	public Panel Categories { get; set; }
	public Panel Modes { get; set; }

	public RealTimeSince TimeSinceChanged;
	public bool PendingUpdate;

	public GameList()
	{
		AddClass( "gamelist" );

		ControlTag = VR ? "vr" : "";
	}

	protected override void PostTemplateApplied()
	{
		base.PostTemplateApplied();

		_ = RefreshFromApi();
		_ = UpdateCategoriesAsync();
	}

	int CurrentHash;
	int CategoryHash;

	public override void Tick()
	{
		base.Tick();
		
		if ( !IsVisible )
			return;

		RefreshDebounced( HashCode.Combine( SortOrder, SearchText, Category, ControlTag ) );
		RefreshCategory( HashCode.Combine( ControlTag ) );

		if ( PendingUpdate && TimeSinceChanged > 0.1f )
		{
			PendingUpdate = false;
			_ = RefreshFromApi();
		}
	}

	private void RefreshDebounced( int v )
	{
		if ( CurrentHash == v ) return;

		CurrentHash = v;
		TimeSinceChanged = 0;
		PendingUpdate = true;
		AddClass( "loading" );
	}	
	
	private void RefreshCategory( int v )
	{
		if ( CategoryHash == v ) return;
		CategoryHash = v;

		_ = UpdateCategoriesAsync();
	}

	async Task RefreshFromApi()
	{
		List<string> tags = new();
		if ( ControlTag != null ) tags.Add( ControlTag );

		var hash = CurrentHash;
		var q = await Sandbox.MenuEngine.Packages.GetPackage( Package.Type.Gamemode, SortOrder, Category, SearchText, tags );

		// Abandon it, we redirected
		if ( hash != CurrentHash ) return;

		Rebuild( q );
		RemoveClass( "loading" );
		Canvas.ScrollOffset = 0;
	}

	public void Rebuild( Package[] packages = null )
	{
		//
		// At some point we're going to get this list from our api
		// but for now just use our addons
		//

		Canvas.DeleteChildren( true );
		GameIcons.Clear();

		if ( packages == null || packages.Length == 0 )
		{
			Canvas.Add.Label( "Sorry - nothing was found here", "empty" );
			return;
		}

		foreach ( var package in packages )
		{
			var gameIcon = new GameIcon( package );
			gameIcon.Parent = Canvas;

			GameIcons.Add( gameIcon );
		}
	}

	public async Task UpdateCategoriesAsync()
	{
		List<string> tags = new();
		if ( ControlTag != null ) tags.Add( ControlTag );

		var categories = await Sandbox.MenuEngine.Packages.GetCategoryList( Package.Type.Gamemode, tags );


		Categories?.DeleteChildren( true );
		Modes?.DeleteChildren( true );

		// Everything
		var all = Categories.Add.Panel( "category" );
		all.Add.Icon( "apps", "icon" );
		all.Add.Label( "All Categories", "title" );
		all.AddEventListener( "onmousedown", () => Category = 0 );
		all.BindClass( "active", () => Category == 0 );

		if ( categories == null )
			return;

		foreach ( var cat in categories.Categories?.OrderByDescending( x => x.Count ) )
		{
			if ( cat.Id == 0 )
				continue;

			var panel = Categories.Add.Panel( "category" );
			panel.Add.Icon( cat.Icon, "icon" );
			panel.Add.Label( cat.Title, "title" );
			panel.Add.Label( cat.Count.ToString( "n0" ), "count" );

			panel.AddEventListener( "onmousedown", () => Category = cat.Id );


			panel.BindClass( "active", () => Category == cat.Id );
		}

		// VR
		{
			var t = categories.Tags.FirstOrDefault( x => x.Key == "vr" );

			var panel = Modes.Add.Panel( "category" );
			panel.Add.Icon( "panorama_photosphere_select", "icon" );
			panel.Add.Label( t.Count.ToString( "n0" ), "count" );
			panel.AddEventListener( "onmousedown", () => ControlTag = (ControlTag == "vr" ) ? null : "vr" );
			panel.BindClass( "active", () => ControlTag == "vr" );
		}

		// Mouse and Keyboard
		{
			var t = categories.Tags.FirstOrDefault( x => x.Key == "mousekeyboard" );

			var panel = Modes.Add.Panel( "category" );
			panel.Add.Icon( "mouse", "icon" );
			panel.Add.Label( t.Count.ToString( "n0" ), "count" );
			panel.AddEventListener( "onmousedown", () => ControlTag = (ControlTag == "mousekeyboard") ? null : "mousekeyboard" );
			panel.BindClass( "active", () => ControlTag == "mousekeyboard" );
		}


		// Controller
		{
			var t = categories.Tags.FirstOrDefault( x => x.Key == "controller" );

			var panel = Modes.Add.Panel( "category" );
			panel.Add.Icon( "videogame_asset", "icon" );
			panel.Add.Label( t.Count.ToString( "n0" ), "count" );
			panel.AddEventListener( "onmousedown", () => ControlTag = (ControlTag == "controller") ? null : "controller" );
			panel.BindClass( "active", () => ControlTag == "controller" );
		}

	}
}

