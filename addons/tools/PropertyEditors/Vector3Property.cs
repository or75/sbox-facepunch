using Tools;

[CanEdit( typeof( Vector3 ), "vector3" )]
public class Vector3Property : Tools.Widget
{
	FloatProperty X;
	FloatProperty Y;
	FloatProperty Z;

	public Vector3Property( Widget parent ) : base( parent )
	{
		var layout = MakeLeftToRight();

		{
			X = layout.Add( new FloatProperty( "X", this ) { HighlightColor = Theme.Red,  }, 1 );
			X.OnValueEdited += PushToBinding;
		}

		layout.AddSpacingCell( 8 );

		{
			Y = layout.Add( new FloatProperty( "Y", this ) { HighlightColor = Theme.Green }, 1 );
			Y.OnValueEdited += PushToBinding;
		}

		layout.AddSpacingCell( 8 );

		{
			Z = layout.Add( new FloatProperty( "Z", this ) { HighlightColor = Theme.Blue }, 1 );
			Z.OnValueEdited += PushToBinding;
		}
	}

	public override void PushToBinding()
	{
		base.PushToBinding();

		Vector3 var = new Vector3( X.Value, Y.Value, Z.Value );
		DataBinding?.SetValue( var );
	}


	protected override void DataValueChanged( object obj )
	{
		base.DataValueChanged( obj );

		if ( obj is Vector3 v )
		{
			X.Value = v.x;
			Y.Value = v.y;
			Z.Value = v.z;
		}
	}
}
