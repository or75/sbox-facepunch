using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

[Dock( "Editor", "Icons", "insert_emoticon" )]
public class IconPicker : Widget
{
	ListView<MaterialIcon> ListView;

	public IconPicker( Widget parent ) : base( parent )
	{
		var layout = MakeTopToBottom();
		//layout.SetContentMargins( 4, 4, 4, 4 );
		layout.Spacing = 4;

		var tb = layout.Add( new ToolBar( this ) );

		var filter = new LineEdit();
		filter.PlaceholderText = "Filter..";
		filter.TextChanged += OnFilterTextChanged;
		tb.AddWidget( filter );

		ListView = new ListView<MaterialIcon>( this );

		layout.Add( ListView, 1 );

		var icons = Enum.GetValues<MaterialIcon>();

		ListView.SetItems( icons );
		ListView.ItemSize = 64;
		ListView.ItemPaint = PaintItem;
		ListView.ItemSelected = OnItemSelected;
	}

	private void OnFilterTextChanged( string filter )
	{
		ListView.SetItems( Enum.GetValues<MaterialIcon>().Where( x => string.IsNullOrEmpty( filter ) || x.ToString().Contains( filter, StringComparison.OrdinalIgnoreCase ) ) );
	}

	private void OnItemSelected( MaterialIcon obj )
	{
		Log.Info( $"{obj} \"{MaterialIconUtility.Lookup( obj )}\"" );
	}

	private void PaintItem( MaterialIcon icon, Rect rect )
	{
		var alpha = 0.5f;
		if ( Paint.HasMouseOver ) alpha = 0.7f;
		if ( Paint.HasSelected ) alpha = 1.0f;

		Paint.SetPen( Theme.White.WithAlpha( alpha ) );
		Paint.DrawMaterialIcon( rect, icon, rect.height - 4 );
	}


}
