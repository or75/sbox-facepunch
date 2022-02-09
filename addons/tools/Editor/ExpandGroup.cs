using Tools;

public class ExpandGroup : Widget
{
	Layout Layout;
	Widget widget;

	public string Title { get; set; } = "Untitled Group";
	public string Icon { get; set; } = "feed";

	int headerSize;

	public ExpandGroup( Widget parent ) : base( parent )
	{
		Layout = MakeTopToBottom();
		SetHeaderSize( 22 );
	}

	public void SetWidget( Widget w )
	{
		widget?.Destroy();
		widget = null;

		widget = w;
		Layout.Add( widget );
	}

	public void SetHeaderSize( int height )
	{
		headerSize = height;
		MinimumSize = height;

		Layout.SetContentMargins( 0, headerSize, 0, 0 );
	}

	protected override void OnPaint()
	{
		bool isExpanded = widget?.Visible ?? false;

		var color = Theme.White;
		if ( !isExpanded ) color = color.Desaturate( 0.2f ).Darken( 0.2f );

		var rect = new Rect( 0, Size );

		rect.height = headerSize;

		Paint.SetPen( Theme.Black.WithAlpha( 0.3f ), 1.0f );
		Paint.SetBrush( color.Darken( 0.5f ).WithAlpha( 0.1f ) );
		Paint.DrawRect( rect.Expand( 10, 0 ) );

		Paint.SetPen( Theme.White.WithAlpha( isExpanded ? 0.5f : 0.2f ) );
		var arrowRect = Paint.DrawMaterialIcon( rect, isExpanded ? "arrow_drop_down" : "arrow_right", 22, TextFlag.Left | TextFlag.VCenter );

		rect.left = 24;

		Paint.SetPen( Theme.Green );
		var iconRect = Paint.DrawMaterialIcon( rect, Icon, 13, TextFlag.Left | TextFlag.VCenter );

		rect.left = 45;

		Paint.SetDefaultFont( 7, 500 );
		Paint.SetPen( color.WithAlpha( isExpanded ? 0.8f : 0.5f ) );
		Paint.DrawText( rect, Title, TextFlag.LeftCenter );
	}

	protected override void OnMousePress( MouseEvent e )
	{
		base.OnMousePress( e );

		if ( e.LocalPosition.y < headerSize && widget != null )
		{
			widget.Visible = !widget.Visible;
		}
	}
}
