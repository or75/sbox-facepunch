using Sandbox.UI.Construct;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Sandbox.UI.Dev
{
	public class PerformanceChartWidget : BaseWidget
	{
		[ConVar.Menu( Saved = true )]
		public static int widget_perfchart { get; set; }

		Panel Bars;

		public PerformanceChartWidget()
		{
			AddClass( "performancechart-widget" );

			AddHeader( "Performance Chart", "timer" );

			StandardMode();
		}

		public void StandardMode()
		{
			var row = Add.Panel( "row" );

			Bars = row.Add.Panel( "chart" );

			for (int i = 0; i < 60; i++)
			{
				timeSinceBar = 1;
				UpdateBars( 1.0f / 100.0f );
			}
		}

		List<double> FrameTimes = new();

		public override void CloseWidget()
		{
			widget_perfchart = 0;
		}

		public override void Tick()
		{
			base.Tick();

			SetClass( "hidden", widget_perfchart == 0 );

			if ( !IsVisible ) return;

			FrameTimes.Add( PerformanceStats.FrameTime );

			while ( FrameTimes.Count > 60 )
				FrameTimes.RemoveAt( 0 );

			UpdateBars( FrameTimes.Average() );
		}

		RealTimeSince timeSinceBar;

		public void UpdateBars( double average )
		{
			if ( timeSinceBar < 1.0f / 4.0f )
				return;

			float ms = (float) average * 1000.0f;
			var height = ms.LerpInverse( 1000 / 10.0f, 1000 / 100.0f );

			timeSinceBar = 0;

			if ( height < 0.05f )
				height = 0.05f;

			var bar = Bars.Add.Panel( "bar" );
			bar.Style.Height = Length.Fraction( height );

			if ( Bars.ChildrenCount > 60 )
				Bars.GetChild( 0 ).Delete( true );

			if ( ms > 1000.0f / 10.0f )
				bar.AddClass( "shit" );
			else if ( ms > 1000.0f / 30.0f )
				bar.AddClass( "bad" );
			else if ( ms > 1000.0f / 60.0f )
				bar.AddClass( "poor" );
		}
	}
}
