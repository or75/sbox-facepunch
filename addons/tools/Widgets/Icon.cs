using Tools;

public class Icon : Label
{
	public Icon( string iconName, Widget parent = null, string name = null ) : base( iconName, parent, name )
	{
		SetProperty( "is-icon", true );
		Name = "Icon";
	}
}
