using Tools;

[CanEdit( typeof( Color ), "color" )]
public class ColorProperty : Tools.Widget
{
	bool Invalid;

	Color _value;
	public Color Value
	{
		get => _value;
		set
		{
			if ( _value == value ) return;

			_value = value;
			PushToBinding();
		}
	}

	LineEdit LineEdit;

	public ColorProperty( Widget parent ) : base( parent )
	{
		LineEdit = new LineEdit( this );
		LineEdit.TextEdited += LineEdit_TextEdited;
		LineEdit.EditingFinished += LineEdit_EditingFinished;
		LineEdit.SetStyles( "* { background-color: transparent; border: 0px; }" );

		MinimumSize = Theme.RowHeight;
		MaximumSize = new Vector2( 4096, Theme.RowHeight );
	}

	private void LineEdit_EditingFinished()
	{
		Invalid = false;
		Update();

		// Don't fix if whatever is in there matches
		if ( Color.Parse( LineEdit.Text ) == Value )
			return;

		PullFromBinding();
	}

	private void LineEdit_TextEdited( string obj )
	{
		var c = Color.Parse( obj );

		Invalid = c == null;

		if ( !Invalid )
		{
			Value = c.Value;
		}

		Update(); // need to redraw
	}

	public override void PushToBinding()
	{
		base.PushToBinding();
		DataBinding?.SetValue( Value );
	}


	protected override void DataValueChanged( object obj )
	{
		base.DataValueChanged( obj );

		if ( obj is Color c )
		{
			Value = c;
			LineEdit.Text = Value.ToString( true, true );

			Update(); // need to redraw
		}
	}

	protected override void OnPaint()
	{
		base.OnPaint();

		Paint.Antialiasing = true;
		Paint.TextAntialiasing = true;

		var rect = new Rect( 0, Size );

		Paint.SetPenEmpty();
		Paint.SetBrush( Theme.ControlBackground );

		if ( Invalid )
			Paint.SetBrush( Color.Lerp( Theme.ControlBackground, Theme.Red, 0.1f ) );

		Paint.DrawRect( rect, Theme.ControlRadius );

		var iconRect = rect.Expand( -3 );
		iconRect.width = iconRect.height * 2;

		if ( Value.a < 1 )
		{
			Paint.SetBrush( "/image/transparent-small.png" );
			Paint.DrawRect( iconRect, Theme.ControlRadius - 1 );
		}

		Paint.SetPenEmpty();
		Paint.SetBrush( Value );

		Paint.DrawRect( iconRect, Theme.ControlRadius - 1 );

		rect.left = iconRect.right + 6;

		// We could draw the color in some parsed manner here that would be sweet
		//Paint.SetPen( Color.Red );
		//Paint.DrawText( new Rect( LineEdit.Position, LineEdit.Size ), LineEdit.Text, TextFlag.LeftCenter );
	}

	protected override void DoLayout()
	{
		base.DoLayout();

		LineEdit.Position = new Vector2( (Size.y * 2) - 6, 0 );
		LineEdit.Size = Size - LineEdit.Position;
	}
}
