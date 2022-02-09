
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;

namespace Sandbox
{
	[UseTemplate]
	internal sealed class LoadingScreen : RootPanel
	{
		internal static LoadingScreen Current { get; set; }

		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string DownloadProgress { get; set; }

		public LoadingScreen()
		{
			Current = this;

			AddClass( "hidden" );

			Title = "Loading";
			Subtitle = "Please Wait";
			DownloadProgress = "";
		}

		public override void Tick()
		{
			base.Tick();
		}

		protected override void UpdateBounds( Rect rect )
		{
			if ( IsVR )
			{
				PanelBounds = new Rect( 0, 0, 3840, 2400 );
				return;
			}

			base.UpdateBounds( rect );
		}

		protected override void UpdateScale( Rect screenSize )
		{
			if ( IsVR )
			{
				Scale = 2.33f;
				return;
			}

			base.UpdateScale( screenSize );
		}

		public void UpdateProgress( float progress, string title, string subtitle, string statistic )
		{
			if ( title != null ) Title = title;
			Subtitle = subtitle;
			DownloadProgress = "";
		}

		public void UpdateDownloadProgress( long got, long total )
		{
			if ( total <= 0 )
			{
				DownloadProgress = $"{ got.FormatBytes().ToUpper() } (Size unknown)";
				return;
			}

			DownloadProgress = $"{got.FormatBytes().ToUpper()} of {total.FormatBytes().ToUpper()} ({got * 100 / total}%)";
		}

		public void Cancel()
		{
			ConsoleSystem.Run( "disconnect" );
		}
	}
}
