using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading;

namespace Sandbox.UI.Dev
{
	public class ConsoleOverlay : Panel
	{
		[ConVar.Menu( "consoleoverlay", Help = "Enable the console to draw at the top of the screen all the time", Saved = true )]
		public static bool ConsoleOverlayEnabled { get; set; }

		internal Panel Output;

		public ConsoleOverlay()
		{
			StyleSheet.Load( "/devui/devmode/ConsoleOverlay.scss" );
			Output = Add.Panel( "output" );
			MenuEngine.Tools.AddLogger( OnConsoleMessage ); 
		}

		public override void Tick()
		{
			base.Tick();

			SetClass( "hidden", !ConsoleOverlayEnabled );
		}

		private void OnConsoleMessage( LogEvent e )
		{
			if ( !ConsoleOverlayEnabled )
				return;

			var entry = Output.AddChild<ConsoleEntry>();
			entry.SetLogEvent( e );
			entry.DeleteIn( 8 );

			var c = Output.Children.Count();

			for ( int i=0; i< c - 10; i++ )
			{
				Output.Children.First().Delete( true );
			}
		}
	}
}
