
using Sandbox;
using Sandbox.UI;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sandbox.DataModel;
using System.Collections.Generic;
using Sandbox.UI.Tests;
using Sandbox.UI.Construct;
using System.Threading;

[UseTemplate, NavigatorTarget( "/game/{game_ident}/maps" ) ]
public class MapSelectPage : BaseGamePanel
{
	public VirtualScrollPanel AssetList { get; set; }

	public string SearchText { get; set; } = "";
	public string SortOrder { get; set; } = "popular";
	public int Category { get; set; } = 0;

	public MapSelectPage()
	{

	}

	protected override void PostTemplateApplied()
	{
		base.PostTemplateApplied();

		AssetList.OnCreateCell = CreateMapButton;
	}

	private void CreateMapButton( Panel cell, object obj )
	{
		if ( obj is Package package )
		{
			var ac = new GameIcon( package );
			ac.Parent = cell;
			ac.AddEventListener( "onclick", () => OnSelected( package.FullIdent ) );
		}

		if ( obj is string str )
		{
			var ac = new AssetCard( cell, str, "Local Map", "/ui/mainmenu/map_default.jpg" );
			ac.AddEventListener( "onclick", () => OnSelected( str ) );
		}
	}

	public override void Tick()
	{
		base.Tick();

		RefreshDebounced( HashCode.Combine( SortOrder, Category, Package, AssetList, SearchText ) );
	}

	int lastHash;
	CancellationTokenSource tokenSource;

	void RefreshDebounced( int hash )
	{
		if ( lastHash == hash ) return;

		lastHash = hash;

		tokenSource?.Cancel();
		tokenSource = new CancellationTokenSource();

		// TODO debounce

		_ = RefreshList( tokenSource.Token );
	}

	public async Task RefreshList( CancellationToken token )
	{
		AssetList.Clear();

		if ( SortOrder == "local" )
		{
			FillLocalMaps( SearchText );
			return;
		}

		var r = await Sandbox.MenuEngine.Packages.GetPackage( Package.Type.Map, SortOrder, Category, SearchText );
		if ( r == null )
			return;

		if ( token.IsCancellationRequested )
			return;

		r = FilterMaps( r );

		AssetList.AddItems( r );
	}

	public void AddLocalMaps( string SearchText )
	{
		foreach( var map in FileSystem.Mounted.FindFile( "/maps/", "*.vpk", true ) )
		{
			if ( map.Contains( "_bakeresourcecache" ) ) continue;
			if ( map.StartsWith( "editor/" ) ) continue;
			if ( map.StartsWith( "error.vpk" ) ) continue;

			if ( !string.IsNullOrEmpty( SearchText ) && !map.ToLower().Contains( SearchText.ToLower() ) ) continue;

			AssetList.AddItem( System.IO.Path.ChangeExtension( map, null ) );
		}
	}

	public void OnSelected( string mapName )
	{
		CreateValueEvent( "value", mapName );

		CreateEvent( "map.select", mapName );
	}

	void FillLocalMaps( string SearchText )
	{
		AddLocalMaps( SearchText );
	}

	Package[] FilterMaps( Package[] mapList )
	{
		var gameScreen = Ancestors.OfType<GameScreen>().FirstOrDefault();

		if ( gameScreen == null ) return mapList;
		if ( gameScreen.Package == null ) return mapList;

		var selectionMode = gameScreen.Package.GameConfiguration.MapSelection;

		if( selectionMode == MapSelect.Official )
		{
			var officialMaps = gameScreen.Package.GameConfiguration.MapList;
			return mapList.Where( x => officialMaps.Contains( x.FullIdent ) ).ToArray();
		}

		// todo: tagged

		return mapList;
	}
}


