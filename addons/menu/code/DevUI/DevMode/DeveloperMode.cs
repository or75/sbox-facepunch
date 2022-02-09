using Sandbox.Html;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading;

namespace Sandbox.UI.Dev
{

	[UseTemplate]
	public class DeveloperMode : Panel
	{
		static DeveloperMode Singleton;

		public Console Console { get; set; }
		public Panel GameScreen { get; set; }
		public TabContainer Right { get; set; }
		public TabContainer Bottom { get; set; }
		public TabContainer Top { get; set; }
		public PropertySheet PropertySheet { get; set; }

		public static bool Open { get; protected set; }

		public DeveloperMode()
		{
			Singleton = this;
		}

		protected override void PostTemplateApplied()
		{
			base.PostTemplateApplied();

			GameScreen = new Panel();
			GameScreen.AddClass( "game_screen" );
			Top.AddTab( GameScreen, "Game", "sports_esports" );

			Console = new Console();
			Bottom.AddTab( Console, "Console", "code" );

			PropertySheet = new PropertySheet();
			Right.AddTab( PropertySheet, "Properties", "view_list" );
		}

		public override void Tick()
		{
			base.Tick();

			SetClass( "open", Open );

			if ( Open )
			{
				MenuEngine.Tools.DeveloperView( GameScreen.Box.RectInner );
			}
			else
			{
				MenuEngine.Tools.DeveloperView( default );
			}
		}
		

		void Toggle()
		{
			Open = !Open;

			MenuEngine.Tools.DeveloperView( default );   

			if ( Open )
			{
				Console.Input.Focus();
				Event.Run( "developermode.open" );
			}
			else
			{
				Console.Input.Blur();
				Event.Run( "developermode.close" );
			}

			FindRootPanel().SetClass( "developermode", Open );

			MenuEngine.Tools.SkipAllTransitions();
		}

		public override Panel FindPopupPanel() => this;

		[MenuCmd( "con_toggle" )]
		static void ToggleConsole()
		{
			Singleton?.Toggle();
		}

		public static void OpenProperty( object targetObject )
		{
			Singleton.PropertySheet.Target = targetObject;
		}

		public static object ActiveProperty()
		{
			return Singleton.PropertySheet.Target;
		}
	}
}
