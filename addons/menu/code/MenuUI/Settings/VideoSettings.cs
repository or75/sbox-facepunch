
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Linq;
using System.Threading.Tasks;

[UseTemplate, NavigatorTarget( "/settings/video" )]
public class VideoSettings : SettingsPanel
{
	public SettingRow VideoMode { get; set; }
	public SettingRow Resolution { get; set; }
	public SettingRow Vsync { get; set; }
	public SettingRow TextureFilteringMode { get; set; }
	public SettingRow RefreshRate { get; set; }

	public VideoSettings()
	{

	}

	protected override void PostTemplateApplied()
	{
		base.PostTemplateApplied();

		VideoMode.SetClass( "disabled", Global.IsToolsMode );
		Resolution.SetClass( "disabled", Global.IsToolsMode );
		Vsync.SetClass( "disabled", Global.IsToolsMode );

		ReadSettings();
	}

	public void ReadSettings()
	{
		VideoMode.Value = "window";
		if ( Sandbox.Internal.RenderSettings.Borderless ) VideoMode.Value = "borderless";
		if ( Sandbox.Internal.RenderSettings.Fullscreen ) VideoMode.Value = "exclusive";

		Resolution.Value = $"{Sandbox.Internal.RenderSettings.ResolutionWidth}x{Sandbox.Internal.RenderSettings.ResolutionHeight}";

		Vsync.Value = $"{Sandbox.Internal.RenderSettings.VSync}";
		TextureFilteringMode.Value = $"{Sandbox.Internal.RenderSettings.TextureFiltering}";
		RefreshRate.Value = $"{Sandbox.Internal.RenderSettings.MaxFrameRate}";
	}

	[PanelEvent( "apply-settings" )]
	public void ApplySettings()
	{
		//
		// Don't change video mode settings in tools mode, since it's invalid
		//
		if ( !Global.IsToolsMode )
		{
			Sandbox.Internal.RenderSettings.VSync = Vsync.Value.ToBool();

			switch ( VideoMode.Value )
			{
				case "window":
					{
						Sandbox.Internal.RenderSettings.Fullscreen = false;
						Sandbox.Internal.RenderSettings.Borderless = false;
						break;
					}

				case "borderless":
					{
						Sandbox.Internal.RenderSettings.Fullscreen = false;
						Sandbox.Internal.RenderSettings.Borderless = true;
						break;
					}

				case "exclusive":
					{
						Sandbox.Internal.RenderSettings.Fullscreen = true;
						Sandbox.Internal.RenderSettings.Borderless = false;
						break;
					}
			}

			if ( VideoMode.Value != "borderless" )
			{
				var parts = Resolution.Value.Split( "x", 2 ).Select( x => x.ToInt() ).ToArray();
				Sandbox.Internal.RenderSettings.ResolutionWidth = parts[0];
				Sandbox.Internal.RenderSettings.ResolutionHeight = parts[1];
			}
		}

		Sandbox.Internal.RenderSettings.TextureFiltering = TextureFilteringMode.Value.ToInt();
		Sandbox.Internal.RenderSettings.MaxFrameRate = RefreshRate.Value.ToInt();
		Sandbox.Internal.RenderSettings.Apply();
	}

	public override void Tick()
	{
		base.Tick();

		Resolution.SetClass( "disabled", Global.IsToolsMode || VideoMode.Value == "borderless" );
	}
}


