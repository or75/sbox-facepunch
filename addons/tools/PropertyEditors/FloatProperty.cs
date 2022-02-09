using Sandbox;
using System;
using Tools;

/// <summary>
/// A text box with a draggable icon on the left.
/// Dragging the icon left and right will change the value
/// Dragging the icon up and down will change the rate at which the value changes
/// So dragging down, then left and right will change in 100s, dragging up and then left and right will change in 0.01s
/// </summary>
[CanEdit( typeof( float ), "float" )]
public class FloatProperty : Widget
{
	public string Label { get; set; }
	public string Icon { get; set; } = "edit";
	public Color HighlightColor = Color.Yellow;

	public event Action OnValueEdited;

	public float Value 
	{
		get => LineEdit.Text.ToFloat();

		set
		{
			LineEdit.Text = value.ToString();
		}
	}

	public LineEdit LineEdit { get; private set; }

	public FloatProperty( Widget parent ) : base( parent )
	{
		LineEdit = new LineEdit( this );
		LineEdit.TextEdited += LineEdit_TextEdited;
		LineEdit.MinimumSize = Theme.RowHeight;
		LineEdit.NoSystemBackground = true;
		LineEdit.TranslucentBackground = true;
		Cursor = CursorShape.SizeH;

		MinimumSize = Theme.RowHeight;
		MaximumSize = new Vector2( 4096, Theme.RowHeight );
	}

	public FloatProperty( string label, Widget parent ) : this( parent )
	{
		Label = label;
	}

	protected override void OnMouseEnter()
	{
		base.OnMouseEnter();
		Update();
	}

	protected override void OnMouseLeave()
	{
		base.OnMouseLeave();
		Update();
	}

	protected override void OnPaint()
	{
		base.OnPaint();
		
		var h = Size.y;
		bool hovered = IsUnderMouse;
		if ( !Enabled ) hovered = false;

		Paint.Antialiasing = true;
		Paint.TextAntialiasing = true;

		Paint.SetPenEmpty();
		Paint.SetBrush( Theme.ControlBackground );
		Paint.DrawRect( new Rect( 0, Size ), Theme.ControlRadius );

		// icon box
		Paint.SetPenEmpty();
		Paint.SetBrush( HighlightColor.Darken( hovered ? 0.7f : 0.8f ).Desaturate( 0.8f ) );
		Paint.DrawRect( new Rect( 0, 0, h, h ).Expand( -1 ), Theme.ControlRadius - 1.0f );

		// flatten right (we need a DrawRect with uneven corners)
		Paint.DrawRect( new Rect( h - Theme.ControlRadius, 0, Theme.ControlRadius, h ).Expand( -1 ) );

		Paint.SetPen( HighlightColor.Darken( hovered ? 0.0f : 0.1f ).Desaturate( hovered ? 0.0f : 0.2f ) );

		if ( string.IsNullOrEmpty( Label ) )
		{
			Paint.DrawMaterialIcon( new Rect( 0, h ), Icon, h - 6, TextFlag.AlignCenter );
		}
		else
		{
			Paint.SetFont( "Poppins", 9, 450 );
			Paint.DrawText( new Rect( 1, h-1 ), Label, TextFlag.AlignCenter );
		}
	}

	protected override void DoLayout()
	{
		base.DoLayout();
		var h = Size.y;
		LineEdit.Position = new Vector2( h, 0 );
		LineEdit.Size = Size - new Vector2( h, 0 );
	}

	protected override void DataValueChanged( object obj )
	{
		base.DataValueChanged( obj );

		if ( obj is float f )
		{
			Value = f;
		}

		if ( obj is double d )
		{
			Value = (float)d;
		}		
		
		if ( obj is int i )
		{
			Value = (float)i;
		}
	}

	public override void PushToBinding()
	{
		DataBinding?.SetValue( Value );
		OnValueEdited?.Invoke();
	}

	private void LineEdit_TextEdited( string obj )
	{
		PushToBinding();
	}

	float dragSpeed = 1.0f;
	Vector2 lastDragPosition;

	protected override void OnMousePress( MouseEvent e )
	{
		base.OnMousePress( e );

		if ( e.LeftMouseButton )
		{
			lastDragPosition = e.LocalPosition;
			dragSpeed = 1;
		}
	}

	protected override void OnMouseMove( MouseEvent e )
	{
		base.OnMouseMove( e );

		if (  e.ButtonState.HasFlag( MouseButtons.Left ) )
		{
			var delta = e.LocalPosition - lastDragPosition;
			lastDragPosition = e.LocalPosition;

			dragSpeed = (e.LocalPosition.y + 100.0f) / 100.0f;
			dragSpeed = dragSpeed.Clamp( 0.001f, 1000.0f );

			Value += delta.x * 0.1f * dragSpeed;
			PushToBinding();
		}

		
	}

}
