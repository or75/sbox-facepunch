
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Linq;
using System.Threading.Tasks;

[UseTemplate, NavigatorTarget( "/settings/input" )]
public class InputSettings : SettingsPanel
{
	public Panel Controllers { get; set; }

	public InputSettings()
	{

	}

	public override void Tick()
	{
		base.Tick();

		//
		// This sucks ass, just wanted to get something in to let people configure controllers at the minimum though.
		//

		var controllers = Sandbox.Internal.ControllerSettings.ConnectedControllers.ToList();

		// Remove disconnected controllers
		foreach ( var panel in Controllers.Children.OfType<ControllerPanel>() )
		{
			var controller = controllers.Where( c => c.GetHashCode() == panel.Controller.GetHashCode() ).FirstOrDefault();
			if ( controller != null )
			{
				controllers.Remove( controller );
				continue;
			}

			if ( !panel.IsDeleting ) panel.Delete();
		}

		foreach( var controller in controllers )
		{
			Controllers.AddChild(new ControllerPanel( controller ));
		}
	}
}


