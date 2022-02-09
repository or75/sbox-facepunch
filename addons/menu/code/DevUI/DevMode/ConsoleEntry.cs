using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading;

namespace Sandbox.UI.Dev
{
	public class ConsoleEntry : Panel
	{
		static ConsoleEntry Selected;

		public Label Time;
		public Label Message;
		public LogEvent Event;

		public bool AutoDelete;
		public RealTimeUntil TimeUntilDelete;

		public ConsoleEntry()
		{
			Time = Add.Label( null, "time" );
			Time.Selectable = false;

			Message = Add.Label( null, "message" );

			AddEventListener( "onmousedown", OpenStackTrace );
		}

		public override void Tick()
		{
			base.Tick();

			if ( AutoDelete && TimeUntilDelete <= 0 )
			{
				Delete();
			}

			SetClass( "selected", Selected == this );
		}

		internal void SetLogEvent( LogEvent e )
		{
			Event = e;

			Time.Text = Event.Time.ToString( "hh:mm:ss" );
			Message.Text = Event.Message;
			AddClass( e.Level.ToString() );

			if ( e.Logger != null )
			{
				AddClass( e.Logger );
			}
		}

		internal void DeleteIn( float seconds )
		{
			AutoDelete = true;
			TimeUntilDelete = seconds;
		}

		void OpenStackTrace()
		{
			if ( Event.Stack == null )
				return;

			DeveloperMode.OpenProperty( Event );
			Selected = this;
		}
	}
}
