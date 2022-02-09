using Tools;
namespace NodeEditor;

public class PlugOut : Plug
{
	public bool Dragging { get; protected set; }

	public Vector2 HandlePosition => ToScene( new Vector2( Size.x - 10 - 5, Size.y * 0.5f ) );
	public BaseNode.OutputAttribute Attribute;

	public PlugOut( NodeUI node, System.Reflection.PropertyInfo property, BaseNode.OutputAttribute attribute ) : base( node, property )
	{
		HoverEvents = true;
		Attribute = attribute;

		HandleColor = Color.Parse( "#caffbf" ) ?? default;
		Cursor = CursorShape.Finger;
	}

	protected override void OnPaint()
	{
		var highlight = Paint.HasMouseOver;

		var rect = new Rect();
		rect.Size = Size;

		var spacex = 10;
		var handleSize = 8.0f;

		Paint.SetPenEmpty();
		Paint.SetPen( HandleColor, highlight ? 4.0f : 2.5f );
		Paint.SetBrush( HandleColor.WithAlpha( 0.2f ) );
		Paint.DrawCircle( new Rect( Size.x - handleSize - spacex, (Size.y - handleSize) * 0.5f, handleSize, handleSize ) );
		
		Paint.SetPen( highlight ? Color.White : new Color( 0.7f, 0.7f, 0.7f ) );
		Paint.DrawText( new Rect( 0, 0, rect.width - handleSize - spacex - spacex, rect.Size.y ), Title, TextFlag.LeftCenter );
	}


	protected override void OnMousePressed( GraphicsMouseEvent e )
	{
		base.OnMousePressed( e );

		if ( e.LeftMouseButton )
		{
			e.Accepted = true;
		}
	}

	protected override void OnMouseReleased( GraphicsMouseEvent e )
	{
		if ( Dragging )
		{
			Node.DroppedOutput( this, e.ScenePosition );
		}

		Dragging = false;
		Cursor = CursorShape.Finger;
		Update();
	}

	protected override void OnMouseMove( GraphicsMouseEvent e )
	{
		// TODO - minimum distance move

		Dragging = true;
		Node.DraggingOutput( this, e.ScenePosition );
		Cursor = CursorShape.DragLink;
		Update();
		e.Accepted = true;
	}
}
