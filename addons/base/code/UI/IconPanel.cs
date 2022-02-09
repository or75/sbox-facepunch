using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;

namespace Sandbox.UI
{

	[Library( "IconPanel", Alias = new[] { "icon" } )]
	public class IconPanel : Label
	{
		public IconPanel()
		{
			AddClass( "iconpanel" );
		}
	}

	namespace Construct
	{
		public static class IconPanelConstructor
		{
			public static IconPanel Icon( this PanelCreator self, string icon, string classes = null )
			{
				var control = self.panel.AddChild<IconPanel>();

				if ( icon  != null )
					control.Text = icon;

				if ( classes != null )
					control.AddClass( classes );

				return control;
			}
		}
	}

}
