using Sandbox;
using System.Reflection;
using Tools;

public class PropertyRow : Widget
{
	DisplayInfo Info;

	Layout Layout;

	int LabelWidth = 150;

	public PropertyRow( Widget parent ) : base( parent )
	{
		Layout = MakeLeftToRight();
		Layout.SetContentMargins( LabelWidth, 2, 8, 2 );
		MinimumSize = 22;
	}

	public void SetLabel( string text )
	{
		Info.Name = text;
	}	
	
	public void SetLabel( PropertyInfo info )
	{
		Info = DisplayInfo.ForProperty( info );
	}	

	public void SetWidget( Widget w )
	{
		Layout.Add( w, 1 );

		if ( Info.Placeholder != null && w is LineEdit e )
		{
			e.PlaceholderText = Info.Placeholder;
		}

	}

	protected override void OnPaint()
	{
		base.OnPaint();

		var size = new Rect( 0, Size );
		size.width = LabelWidth - 16;

		if ( size.height > 22 )
			size.height = 22;

		Paint.SetPen( Theme.White.WithAlpha( 0.5f ) );

		size.left += 16;
		size.Position += 1;
		Paint.SetPen( Theme.Black );
		Paint.DrawText( size, Info.Name, TextFlag.Left | TextFlag.VCenter );
		size.Position -= 1;
		Paint.SetPen( Theme.Grey.Lighten( 0.2f ) );
		Paint.DrawText( size, Info.Name, TextFlag.Left | TextFlag.VCenter );

	//	Paint.SetPen( Theme.Black.WithAlpha( 0.2f ) );
	//	Paint.DrawLine( new Vector2( 0, size.bottom-1 ), new Vector2( Size.x, size.bottom-1 ) );

	}
}
