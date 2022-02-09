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
		internal Label PlaceholderLabel;

		public string Placeholder
		{
			get => PlaceholderLabel?.Text;
			set
			{
				if ( string.IsNullOrEmpty( value ) )
				{
					PlaceholderLabel?.Delete();
					PlaceholderLabel = null;
					return;
				}

				if ( PlaceholderLabel == null )
					PlaceholderLabel = Add.Label( value, "placeholder" );

				PlaceholderLabel.Text = value;
			}
		}
	}
}
