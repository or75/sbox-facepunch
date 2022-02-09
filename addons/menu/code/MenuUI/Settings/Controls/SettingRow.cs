
using Sandbox;
using Sandbox.Html;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Library( "setting-row" )]
public class SettingRow : Panel
{
	public string Name { get; set; }
	public string ConVar { get; set; }

	[Property]
	public string Value { get; set; }

	public SettingRow()
	{
		AddClass( "row" );
	}

	public override bool OnTemplateElement( INode node )
	{
		Name = node.GetAttribute( "name", "none" );
		ConVar = node.GetAttribute( "convar", null );
		var type = node.GetAttribute( "type", "text" );

		var left = Add.Panel( "left" );
		var right = Add.Panel( "right" );

		left.Add.Label( node.Children.FirstOrDefault( x => x.Name == "title" )?.InnerHtml ?? node.InnerHtml );

		switch (type)
		{
			case "slider":
				{
					var control = right.Add.SliderWithEntry( node.GetAttributeFloat( "min", 1.0f ), node.GetAttributeFloat( "max", 1.0f ), node.GetAttributeFloat( "step", 1.0f ) );
					control.Format = node.GetAttribute( "format", control.Format );
					control.Bind( "value", this, "Value" );
					control.AddEventListener( "value.changed", () => CreateValueEvent( "value", control.Value ) );
					control.AddEventListener( "value.changed", () => CreateEvent( "setting-changed" ) );
					break;
				}

			case "resolution":
				{
					var control = right.AddChild<ResolutionSelector>();
					control.Bind( "value", this, "Value" );
					control.AddEventListener( "value.changed", () => CreateValueEvent( "value", control.Selected?.Value ) );
					control.AddEventListener( "value.changed", () => CreateEvent( "setting-changed" ) );
					break;
				}

			case "switch":
				{
					var control = right.AddChild<Switch>();
					control.Bind( "checked", this, "Value" );
					control.AddEventListener( "checked.changed", () => CreateValueEvent( "value", control.Checked ) );
					control.AddEventListener( "checked.changed", () => CreateEvent( "setting-changed" ) );
					break;
				}

			case "dropdown":
				{
					var control = right.AddChild<DropDown>();
					control.OnTemplateElement( node );
					control.Bind( "value", this, "Value" );
					control.AddEventListener( "value.changed", () => CreateValueEvent( "value", control.Selected?.Value ) );
					control.AddEventListener( "value.changed", () => CreateEvent( "setting-changed" ) );
					break;
				}

			default:
				{
					var control = right.Add.TextEntry( "empty" );
					control.Bind( "value", this, "Value" );
					control.AddEventListener( "value.changed", () => CreateValueEvent( "value", control.Text ) );
					break;
				}
		}

		UpdateValueFromConvar();

		return false;
	}

	public void UpdateValueFromConvar()
	{
		if ( ConVar == null ) return;

		var value = ConsoleSystem.GetValue( ConVar, null );

		if ( value != null )
		{
			Value = value;
			CreateValueEvent( "value", Value );
		}
	}

	public void ApplySetting()
	{
		if ( ConVar != null )
		{
			ConsoleSystem.Run( ConVar, Value );
		}
	}
}
