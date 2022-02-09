using Tools;

namespace NodeEditor;

public class PlugIn : Plug
{
	PlugIn DropTarget => Node.Graph.DropTarget;

	public Vector2 HandlePosition => ToScene( new Vector2( 10 + 5, Size.y * 0.5f ) );
	public BaseNode.InputAttribute Attribute;

	public PlugIn( NodeUI node, System.Reflection.PropertyInfo property, BaseNode.InputAttribute attribute ) : base( node, property )
	{
		Attribute = attribute;
	}

	protected override void OnPaint()
	{
		var isTarget = DropTarget == this;

		var rect = new Rect();
		rect.Size = Size;

		var spacex = 10;
		var handleSize = 8;

		Paint.SetPenEmpty();
		Paint.SetPen( HandleColor, isTarget ? 5.0f : 3.0f );
		Paint.SetBrush( HandleColor.WithAlpha( 0.2f ) );
		Paint.DrawCircle( new Rect( spacex, (Size.y - handleSize) * 0.5f, handleSize, handleSize ) );
		
		Paint.SetPen( isTarget ? Color.White : new Color( 0.7f, 0.7f, 0.7f ) );
		Paint.DrawText( new Rect( handleSize + spacex * 2, 0, rect.width - 4 - 10, rect.Size.y ), Title, TextFlag.LeftCenter );
	}

	protected override void OnMouseMove( GraphicsMouseEvent e )
	{
		Log.Info( $"M<OVE! {e.LocalPosition}" );
	}

}
