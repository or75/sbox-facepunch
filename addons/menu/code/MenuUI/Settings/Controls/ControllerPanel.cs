using Sandbox.Internal;
using Sandbox.UI;
using Sandbox.UI.Construct;

public class ControllerPanel : Panel
{
	internal ControllerSettings Controller { get; init; }

	// Ask Valve nicely to add these to Steam Input API
	internal string IconFileName => Controller.Type switch
	{
		"SteamController" => "steamcontroller",
		"SteamDeckController" => "steamcontroller",
		"XBox360Controller" => "xbox_360",
		"XBoxOneController" => "xbox_one",
		"PS3Controller" => "ps3",
		"PS4Controller" => "ps4",
		"PS5Controller" => "ps5",
		"SwitchProController" => "switch_pro",
		_ => "xbox_360", // 360 is a generic enough gamepad
	};

	Image Icon { get; init; }
	Button Button { get; init; }

	public ControllerPanel( ControllerSettings controllerSettings )
	{
		Controller = controllerSettings;

		Icon = Add.Image( $"/ui/input/controllers/controller_icon_{ IconFileName }.png" );
		Button = Add.Button( "Configure", () => Controller.OpenBindingPanel() );
	}

	public override void Tick()
	{
		// Can take a few ms to detect type properly
		Button.SetText( $"Configure { Controller.Type }" );
		Icon.SetTexture( $"/ui/input/controllers/controller_icon_{ IconFileName }.png" );
	}
}
