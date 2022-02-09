
using Sandbox;
using Sandbox.UI;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.UI.Tests;
using Sandbox.UI.Construct;
using System.Threading;

[UseTemplate, NavigatorTarget( "/game/{game_ident}/edit" ) ]
public class GameEditPage : BaseGamePanel
{
	public NavigatorPanel Navigator { get; set; }

	public GameEditPage()
	{

	}

	protected override Task OnFullGameInformation()
	{
		if ( Navigator.CurrentUrl == null )
		{
			Navigator.Navigate( $"/game/{GameIdent}/edit/home" );
		}

		return base.OnFullGameInformation();
	}

	protected override void OnEvent( PanelEvent e )
	{
		//
		// If one of our child forms changed, update the package
		//
		if ( e.Name == "form.changed" )
		{
			e.StopPropagation();
			CreateEvent( "package.changed", debounce: 0.5f );
			return;
		}

		base.OnEvent( e );
	}
}
