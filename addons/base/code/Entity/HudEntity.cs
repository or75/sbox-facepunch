using Sandbox.UI;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sandbox
{

	/// <summary>
	/// A base HUD entity that lets you define which type of RootPanel to create.
	/// </summary>
	[Display( Name = "Hud Entity" ), Icon( "branding_watermark" )]
	public abstract class HudEntity<T> : Entity where T: RootPanel, new()
	{
		public T RootPanel { get; set; }

		public HudEntity()
		{
			Transmit = TransmitType.Always;

			if ( IsClient )
			{
				CreateRootPanel();
				Local.Hud = RootPanel;
			}
		}

		/// <summary>
		/// Create the root panel, T
		/// </summary>
		public virtual void CreateRootPanel()
		{
			RootPanel = new T();
			RootPanel.AcceptsFocus = false;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			if ( Local.Hud == RootPanel )
			{
				Local.Hud = null;
			}

			//
			// clean up the panel
			// or it'll stick around forever
			//
			RootPanel?.Delete();
			RootPanel = null;
		}
	}
}
