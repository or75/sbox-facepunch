
using Sandbox;
using Sandbox.UI;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.UI.Tests;
using Sandbox.UI.Construct;
using System.Threading;
using Sandbox.MenuEngine;

[UseTemplate, NavigatorTarget( "/game/{game_ident}/edit/config" ) ]
public class GameEditConfig : BaseGamePanel
{
	public Button SaveButton { get; set; }

	public GameEditConfig()
	{
		SaveButton.SetClass( "disabled", true );
	}

	[PanelEvent( "form.changed" )]
	public void OnFormChanged()
	{
		SaveButton.SetClass( "disabled", false );
	}

	public async Task SaveChanges()
	{
		SaveButton.SetClass( "disabled", true );
		SaveButton.SetClass( "working", true );

		await Package.UpdateConfig();

		SaveButton.SetClass( "working", false );
	}
}
