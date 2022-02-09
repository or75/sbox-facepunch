using Sandbox;
using Sandbox.UI;
using System;

namespace Sandbox
{
	internal class DevCamPP : Sandbox.StandardPostProcess { }

	[UseTemplate]
	internal class DevCamSettings : Panel
	{
		public bool DofEnabled { get; set; } = false;
		public bool DofCoC { get; set; } = true;
		public bool DofEdgeBleed { get; set; } = false;

		public int DofQuality { get; set; } = 2;


		public float DofRadius { get; set; } = 3.0f;
		public float DofFStop { get; set; } = 1.6f;
		public float DofFocalLength { get; set; } = 64.0f;
		public float DofFocalPoint { get; set; } = 64.0f;

		private bool isPicking = false;
		private bool isFocalPoint = false;

		public bool Picking => isPicking;

		public DevCamSettings()
		{
			PostProcess.Add( new DevCamPP() );
			Hide();
		}

		public override void Tick()
		{
			base.Tick();

			if ( isPicking )
			{
				var tr = Trace.Ray( Input.Cursor, 10000.0f ).Run();
				if ( tr.Hit )
				{
					float hitResult = tr.Distance;
					if ( !isFocalPoint ) hitResult = Math.Abs( DofFocalPoint - hitResult );

					if ( isFocalPoint ) DofFocalPoint = hitResult;

				}
			}

			DevCamPP pp = PostProcess.Get<DevCamPP>();
			if ( pp == null ) return;

			pp.DepthOfField.Enabled = DofEnabled;
			if ( !DofEnabled ) return;

			pp.DepthOfField.BlurCircleOfConfusion = DofCoC;
			pp.DepthOfField.BleedFocusEdge = DofEdgeBleed;
			pp.DepthOfField.Quality = (StandardPostProcess.DepthOfFieldSettings.DofQuality)DofQuality;
			pp.DepthOfField.Radius = DofRadius;
			pp.DepthOfField.FStop = DofFStop;
			pp.DepthOfField.FocalLength = DofFocalLength;
			pp.DepthOfField.FocalPoint = DofFocalPoint * 2.0f;
		}

		public void DisableDof()
		{
			DofEnabled = false;

			DevCamPP pp = PostProcess.Get<DevCamPP>();
			if ( pp == null ) return;

			pp.DepthOfField.Enabled = false;
		}

		public void VisibilityState( bool newState )
		{
			SetClass( "hidden", !newState );
			// Stop picking if we close the menu
			if ( !newState ) isPicking = false;
		}

		public void Show() => VisibilityState( true );

		public void Hide() => VisibilityState( false );

		public void FinishPicking() => isPicking = false;

		public void PickFocalPoint()
		{
			isPicking = true;
			isFocalPoint = true;
		}
		public void PickFocusPlane()
		{
			isPicking = true;
			isFocalPoint = false;
		}
	}

	internal class DevCamFocalSelector : Panel
	{
		private DevCamSettings _settingParent;
		public DevCamFocalSelector( DevCamSettings _parent )
		{
			StyleSheet.Load( "/UI/DevCamSettings.scss" );
			_settingParent = _parent;
		}
		public void VisibilityState( bool newState ) => SetClass( "hidden", !newState );
		public void Show() => VisibilityState( true );
		public void Hide() => VisibilityState( false );

		public override void Tick()
		{
			base.Tick();
			VisibilityState( _settingParent?.Picking ?? false );
		}

		protected override void OnMouseDown( MousePanelEvent e )
		{
			base.OnMouseDown( e );
			if ( _settingParent?.Picking ?? false && e.Button == "mouseleft" )
			{
				_settingParent.FinishPicking();
			}
		}
	}
}
