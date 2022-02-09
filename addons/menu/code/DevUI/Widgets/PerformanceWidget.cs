using Sandbox.UI.Construct;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Sandbox.UI.Dev
{
	public class PerformanceWidget : BaseWidget
	{

		[ConVar.Menu( Saved = true )]
		public static int widget_perf { get; set; }

		Label Fps;
		Label Ms;

		public PerformanceWidget()
		{
			AddClass( "performance-widget" );

			AddHeader( "Performance", "timer" );

			StandardMode();
		}

		public void StandardMode()
		{
			{
				var box = Add.Panel( "box" );
				Fps = box.Add.Label( "XXX", "value" );
				box.Add.Label( "fps", "unit" );
			}			
			
			{
				var box = Add.Panel( "box" );
				Ms = box.Add.Label( "XXX", "value" );
				box.Add.Label( "ms", "unit" );
			}
		}

		RealTimeSince timeSinceUpdate;

		List<double> FrameTimes = new();

		public override void CloseWidget()
		{
			widget_perf = 0;
		}

		public override void Tick()
		{
			base.Tick();

			SetClass( "hidden", widget_perf == 0 );

			FrameTimes.Add( PerformanceStats.FrameTime );

			while ( FrameTimes.Count > 60 )
				FrameTimes.RemoveAt( 0 );

			var Average = FrameTimes.Average();

			if ( !IsVisible ) return;
			if ( timeSinceUpdate < 1 / 60.0f ) return;

			timeSinceUpdate = 0;

			Fps.Text = $"{(1.0f / Average):0}";
			Ms.Text = $"{(Average * 1000):0.00}";
		}
	}
}
