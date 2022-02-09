using Tools;

[CanEdit( typeof( Vector2 ), "vector2" )]
public class Vector2Property : Tools.Widget
{
	FloatProperty X;
	FloatProperty Y;

	public Vector2Property( Widget parent ) : base( parent )
	{
		var layout = MakeLeftToRight();


		{
			X = layout.Add( new FloatProperty( "X", this ) { HighlightColor = Theme.Red }, 1 );
			X.OnValueEdited += PushToBinding;
		}

		layout.AddSpacingCell( 8 );

		{
			Y = layout.Add( new FloatProperty( "Y", this ) { HighlightColor = Theme.Green }, 1 );
			Y.OnValueEdited += PushToBinding;
		}
	}

	public override void PushToBinding()
	{
		base.PushToBinding();

		Vector2 var = new Vector2( X.Value, Y.Value );
		DataBinding?.SetValue( var );
	}

	protected override void DataValueChanged( object obj )
	{
		base.DataValueChanged( obj );

		if ( obj is Vector3 v )
		{
			X.Value = v.x;
			Y.Value = v.y;
		}

		if ( obj is Vector2 v2 )
		{
			X.Value = v2.x;
			Y.Value = v2.y;
		}
	}
}
