using Sandbox;
using Tools;

[CanEdit( typeof( Model ), "model" )]
public class ModelProperty : Tools.Widget
{
	Model Value;

	public ModelProperty( Widget parent ) : base( parent )
	{
		MinimumSize = Theme.RowHeight * 2;
	}

	public override void PushToBinding()
	{
		base.PushToBinding();

		DataBinding?.SetValue( Value );
	}


	protected override void DataValueChanged( object obj )
	{
		base.DataValueChanged( obj );

		if ( obj is Model v )
		{
			Value = v;
		}
	}

	protected override void OnPaint()
	{
		base.OnPaint();

		var rect = new Rect( 0, Size );
		Paint.SetPenEmpty();
		Paint.SetBrush( Theme.ControlBackground );

		var iconRect = rect;
		iconRect.width = iconRect.height;
		Paint.DrawRect( iconRect, Theme.ControlRadius );

		rect.left = iconRect.right;
		rect = rect.Expand( -8, -4 );

		Paint.SetPen( Theme.White );
		Paint.DrawText( rect, Value?.Name, TextFlag.LeftTop );

	//	var pixmap = Utility.GetAssetThumb( Value?.Name );
	//	if ( pixmap != null )
		//{
		//	Paint.Draw( iconRect, pixmap );
		//}

	}
}
