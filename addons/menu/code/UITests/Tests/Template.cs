using Sandbox.UI.Construct;
using System;
using System.Linq;

namespace Sandbox.UI.Tests
{
	[UseTemplate]
	public class TemplateTest : Panel
	{
		public Button ClickableButton { get; set; }
		public Panel HoverableLabel { get; set; }

		public TemplateTest()
		{
			if ( ClickableButton == null ) Log.Warning( "ClickableButton was null!" );
			if ( HoverableLabel == null ) Log.Warning( "HoverableLabel was null!" );
		}

		public DateTime CurrentTime => DateTime.Now;

		static int ClickCount;

		public void ClickedButton( Button from )
		{
			from.SetText( $"Clicked {++ClickCount} Time{(ClickCount > 1 ? "s" : "")}" );
		}
	}
}
