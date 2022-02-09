using Tools;

[CanEdit( typeof( Angles ), "angles" )]
public class AnglesProperty : Tools.Widget
{
	FloatProperty X;
	FloatProperty Y;
	FloatProperty Z;

	public AnglesProperty( Widget parent ) : base( parent )
	{
		MinimumSize = Theme.RowHeight;
		MaximumSize = new Vector2( 4096, Theme.RowHeight );

		var layout = MakeLeftToRight();

		{
			X = layout.Add( new FloatProperty( this ) { HighlightColor = Theme.Red, Icon = "height", ToolTip = "Pitch (Bow To The Queen)" }, 1 );
			X.OnValueEdited += PushToBinding;
		}

		layout.AddSpacingCell( 8 );

		{
			Y = layout.Add( new FloatProperty( this ) { HighlightColor = Theme.Green, Icon = "360", ToolTip = "Yaw (Like A Microwave Plate)" }, 1 );
			Y.OnValueEdited += PushToBinding;
		}

		layout.AddSpacingCell( 8 );

		{
			Z = layout.Add( new FloatProperty( this ) { HighlightColor = Theme.Blue, Icon = "sync", ToolTip = "Roll (Like A Door Knob)" }, 1 );
			Z.OnValueEdited += PushToBinding;
		}
	}

	public override void PushToBinding()
	{
		base.PushToBinding();

		var var = new Angles( X.Value, Y.Value, Z.Value );
		DataBinding?.SetValue( var );
	}


	protected override void DataValueChanged( object obj )
	{
		base.DataValueChanged( obj );

		if ( obj is Angles v )
		{
			X.Value = v.pitch;
			Y.Value = v.yaw;
			Z.Value = v.roll;
		}
	}
}
