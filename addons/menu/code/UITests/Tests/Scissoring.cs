using Sandbox.UI.Construct;
using System;
using System.Linq;

namespace Sandbox.UI.Tests
{
	[UseTemplate]
	public class Scissoring : Panel
	{
		public Scissoring() 
		{
			Style.FlexWrap = Wrap.Wrap;
			Style.JustifyContent = Justify.Center; 
			Style.AlignItems = Align.Center;
			Style.AlignContent = Align.Center;
		}
	}
}
