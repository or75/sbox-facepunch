using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Sandbox.UI
{
	public partial class TextEntry
	{
		public IconPanel IconPanel { get; protected set; }

		[Property]
		public string Icon
		{
			get => IconPanel?.Text;
			set
			{
				if ( string.IsNullOrEmpty( value ) )
				{
					IconPanel?.Delete( true );
				}
				else
				{
					IconPanel ??= Add.Icon( value );
					IconPanel.Text = value;
				}

				SetClass( "has-icon", IconPanel != null );
			}
		}
	}
}
