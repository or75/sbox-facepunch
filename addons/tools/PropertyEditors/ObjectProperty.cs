using Sandbox;
using System;
using Tools;

public class ObjectProperty : Widget
{
	public object Value { get; set; }
	public Type TargetType { get; set; }


	public ObjectProperty( Widget parent, Type type ) : base( parent )
	{
		TargetType = type;
		Cursor = CursorShape.Finger;

		MinimumSize = Theme.RowHeight;
		MaximumSize = new Vector2( 4096, Theme.RowHeight );
	}

	protected override void OnPaint()
	{
		base.OnPaint();

		Paint.Antialiasing = true;
		Paint.TextAntialiasing = true;

		bool isNull = Value == null;
		var rect = new Rect( 0, Size );
		var display = DisplayInfo.ForType( TargetType );

		Paint.SetPenEmpty();
		Paint.SetBrush( Theme.ControlBackground );
		Paint.DrawRect( rect, Theme.ControlRadius );

		Paint.SetPenEmpty();
		Paint.SetBrush( Theme.Blue.Darken( 0.5f ).WithAlpha( isNull ? 0.4f : 1.0f ) );
		var iconRect = rect.Expand( -3 );
		iconRect.width = iconRect.height;
		Paint.DrawRect( iconRect, Theme.ControlRadius - 1 );

		Paint.SetPen( Theme.Blue.WithAlpha( isNull ? 0.4f : 1.0f ) );
		Paint.DrawMaterialIcon( iconRect, display.Icon ?? "question_mark", rect.height - 8, TextFlag.AlignCenter );

		rect.left = iconRect.right + 6;

		//
		// The object name
		//
		if ( !isNull )
		{
			Paint.SetDefaultFont();
			Paint.SetPen( Theme.White.WithAlpha( 0.8f ) );
			var textRect = Paint.DrawText( rect, $"{Value}", TextFlag.LeftCenter );
			rect.left = textRect.right + 5;
		}

		//
		// The object type
		//
		Paint.SetDefaultFont();
		Paint.SetPen( Theme.White.WithAlpha( 0.2f ) );
		Paint.DrawText( rect, $"({TargetType})", TextFlag.LeftCenter );
	}

	protected override void OnMouseClick( MouseEvent e )
	{
		Utility.Inspect( Value );
	}

	public void SetValue( object value )
	{
		Value = null;
		PushToBinding();
	}

	protected override void OnMousePress( MouseEvent e )
	{
		base.OnMousePress( e );

		if ( e.RightMouseButton )
		{
			var menu = new Menu();
			menu.AddOption( new Option( menu, $"Go To {Value}", "manage_search", () => Utility.Inspect( Value ) ) );
			menu.AddOption( new Option( menu, "Open in New Inspector", "find_in_page", () => Utility.Inspect( Value ) ) );
			menu.AddSeparator();
			menu.AddOption( new Option( menu, "Clear Value", "clear", () => SetValue( null ) ) );

			menu.OpenAt( e.ScreenPosition );
		}
	}

	public static bool IsApplicable( Type type )
	{
		if ( type == null ) return false;
		if ( !type.IsClass ) return false;

		return true;
	}

	protected override void DataValueChanged( object obj )
	{
		base.DataValueChanged( obj );

		Value = obj;
		Update();
	}

	public override void PushToBinding()
	{
		base.PushToBinding();
		DataBinding?.SetValue( Value );
	}
}
