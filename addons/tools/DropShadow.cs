using Tools;

public class DropShadow : Tools.GraphicsItem
{
	public DropShadow()
	{
		ZIndex = -100;
	}

	protected override void OnPaint()
	{
		var rect = new Rect();
		rect.Size = Size - 10;

		Paint.SetPenEmpty();
		Paint.SetBrush( new Color( 0, 0, 0, 0.15f ) );
		Paint.DrawRect( rect, 10.0f );
		Paint.DrawRect( rect+5, 20.0f );
		
	}
}
