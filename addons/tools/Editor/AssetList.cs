using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools;

[Dock( "Editor", "Assets Browser", "snippet_folder" )]
public class AssetList : Widget
{
	ListView<Asset> ListView;

	LineEdit Filter;

	public AssetList( Widget parent ) : base( parent )
	{
		var layout = MakeTopToBottom();
		layout.Spacing = 4;

		ListView = new ListView<Asset>( this );

		var toolbar = new ToolBar( this );
		layout.Add( toolbar );

		Filter = new LineEdit( this );
		Filter.PlaceholderText = "Filter.. \"brick\" \"t:model\"";
		Filter.TextEdited += OnTextEdited;
		toolbar.AddWidget( Filter );

		layout.Add( ListView, 1 );

		ListView.ItemPaint = PaintItem;
		ListView.ItemGetStatusTip = ( a ) => a.Path;
		ListView.ItemGetToolTip = ( a ) => a.Path;
		ListView.ItemSelected = ( a ) => Utility.Inspect( a );
		ListView.ItemSize = 80;
		ListView.ItemContext = ItemContextMenu;
		// double click open, enter open

		UpdateDataSet();
	}

	private void ItemContextMenu( List<Asset> selected, Vector2 screenPos )
	{
		if ( selected.Count == 1)
		{
			var asset = selected.First();
			var menu = new Menu( this );
			menu.AddOption( "Copy Path", action: () => Log.Info( $"{asset.Path}" ) ); // todo copy shit
			menu.AddOption( "Open In Editor", action: () => asset.OpenInEditor() ); // todo - editor name etc?
			menu.OpenAt( screenPos );
		}
	}

	private void OnTextEdited( string obj )
	{
		UpdateDataSet();
	}

	void UpdateDataSet()
	{
		var items = AssetSystem.All.AsEnumerable();

		if ( !string.IsNullOrEmpty( Filter.Text ) )
		{
			var filterText = Filter.Text.Split( ' ' );
			items = items.Where( x => PassesFilter( x, filterText ) );
		}

		ListView.SetItems( items.OrderBy( x => x.Name ) );
	}

	/// <summary>
	/// Evenr called when a thumb is re-rendered
	/// </summary>
	[Event( "asset.thumb.changed" )]
	void AssetThumbChanged( Asset x )
	{
		ListView.TellItemChanged( x );
	}

	private bool PassesFilter( Asset x, string[] filters )
	{
		var path = x.Path;

		foreach( var f in filters )
		{
			//
			// TODO - we can do better than this
			//
			if ( f.Length > 3 && f[1] == ':' )
			{
				if ( f[0] == 't' )
				{
					var typesearch = f[2..];

					if ( typesearch.StartsWith( "mo", StringComparison.OrdinalIgnoreCase ) )
					{
						if ( path.EndsWith( ".vmdl", StringComparison.OrdinalIgnoreCase ) )
							continue;
					}

					if ( typesearch.StartsWith( "ma", StringComparison.OrdinalIgnoreCase ) )
					{
						if ( path.EndsWith( ".vmat", StringComparison.OrdinalIgnoreCase ) )
							continue;
					}

					if ( typesearch.StartsWith( "tex", StringComparison.OrdinalIgnoreCase ) )
					{
						if ( path.EndsWith( ".vtex", StringComparison.OrdinalIgnoreCase ) )
							continue;
					}

					return path.EndsWith( typesearch, StringComparison.OrdinalIgnoreCase );
				}

				continue;
			}

			if ( !path.Contains( f, StringComparison.OrdinalIgnoreCase ) )
				return false;
		}

		return true;
	}

	private void PaintItem( Asset icon, Rect rect )
	{
		if ( Paint.HasSelected )
		{
			Paint.SetPen( Theme.Blue.Saturate( 0.3f ).WithAlpha( 0.4f ), 1.0f );
			Paint.SetBrush( Theme.Blue.Darken( 0.7f ).Desaturate( 0.3f ) );
			Paint.DrawRect( rect.Expand( -2.0f ), Theme.ControlRadius );
			Paint.SetPen( Theme.Blue.Saturate( 0.3f ) );
		}
		else
		{
			Paint.SetPen( Theme.White.Darken( 0.4f ) );
		}

		var thumb = icon.GetAssetThumb( Paint.HasSelected );

		var iconRect = rect;
		iconRect.height -= 20;
		iconRect.left += 10;
		iconRect.right -= 10;
		iconRect.top += 5;

		if ( thumb.Width < rect.width ) rect.width = thumb.Width;
		if ( thumb.Height < rect.height ) rect.height = thumb.Height;

		Paint.Draw( iconRect, thumb );

		var name = System.IO.Path.GetFileName( icon.Path ).Truncate( 16, ".." );

		Paint.SetDefaultFont( 8 );
		Paint.DrawText( rect.Expand( -4, -4 ), name, TextFlag.Bottom | TextFlag.HCenter | TextFlag.SingleLine | TextFlag.ShowMnemonic );
	}
}
