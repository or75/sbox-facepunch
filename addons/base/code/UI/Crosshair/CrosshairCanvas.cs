using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Threading.Tasks;

namespace Sandbox.UI
{
	public partial class CrosshairCanvas : Panel
	{
		public static CrosshairCanvas Singleton;

		public CrosshairCanvas()
		{
			Singleton = this;

			StyleSheet.Load( "/ui/crosshair/CrosshairCanvas.scss" );
		}

		public static void SetCrosshair( Panel crosshairPanel )
		{
			if ( Singleton == null )
				return;

			Singleton.DeleteChildren();
			crosshairPanel.Parent = Singleton;
		}
	}
}
