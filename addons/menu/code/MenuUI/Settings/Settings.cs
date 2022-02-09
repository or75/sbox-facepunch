
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

[UseTemplate, NavigatorTarget( "/settings" )]
public class Settings : NavigatorPanel
{
	public Settings()
	{

	}

	protected override void PreTemplateApplied()
	{
		base.PreTemplateApplied();
	}

	protected override void OnEvent( PanelEvent e )
	{
		base.OnEvent( e );

		if ( e.Is( "setting-changed" ) )
		{
			AddClass( "is-dirty" );
		}
	}

	public void ApplySettings()
	{
		RemoveClass( "is-dirty" );

		// Send a message to all the created child panels
		foreach( var panel in Cache )
		{
			panel.Panel.CreateEvent( "apply-settings" );
		}

		// All rows
		foreach ( var row in Descendants.OfType<SettingRow>() )
		{
			row.ApplySetting();
		}
	}

	public override void Tick()
	{
		base.Tick();
	}


	protected override void PostTemplateApplied()
	{
		base.PostTemplateApplied();

		if ( CurrentPanel == null )
			Navigate( "/settings/video" );

		RemoveClass( "is-dirty" );
	}
}


