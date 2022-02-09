using Tools;

namespace NodeEditor;

public class NodeTitlebar : Tools.GraphicsItem
{
	public string Title { get; set; } = "Node Title";

	protected override void OnPaint()
	{
		var rect = new Rect();
		rect.Size = Size;

		Paint.SetPenEmpty();
		Paint.SetBrush( new Color( 0.5f, 0.5f, 0.5f, 0.3f ) );
		Paint.DrawRect( new Rect( 0, rect.height-2, rect.width, 1.0f ) );
		
		Paint.SetPen( new Color( 0.7f, 0.7f, 0.7f ) );
		Paint.DrawText( new Rect( 10, 0, rect.width - 4 - 15, Size.y ), Title, TextFlag.LeftCenter );
	}
}
