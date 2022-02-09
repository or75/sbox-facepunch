using Tools;

namespace NodeEditor;

public class Plug : Tools.GraphicsItem
{
	public NodeUI Node { get; protected set; }

	public string Title = "Unnammed Title";
	public Color HandleColor = Color.Parse( "#90dbf4" ) ?? default;
	public System.Reflection.PropertyInfo Property;

	public Plug( NodeUI node, System.Reflection.PropertyInfo property )
	{
		Size = new Vector2( 32, 32 );
		Node = node;
		Property = property;

		var display = Sandbox.DisplayInfo.ForProperty( property );
		Title = display.Name;
	}

}
