using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.UI.Tests
{
	[UseTemplate]
	public class Scrolling : Panel
	{
		public Scrolling()
		{
			Style.FlexWrap = Wrap.Wrap;
			Style.JustifyContent = Justify.Center; 
			Style.AlignItems = Align.Center;
			Style.AlignContent = Align.Center;
		}
	}
}
