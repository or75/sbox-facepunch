using Sandbox.UI.Construct;
using System;
using System.Linq;

namespace Sandbox.UI.Tests
{
	[UseTemplate]
	public class TextRendering : Panel
	{
		public TextRendering() 
		{
			Style.FlexWrap = Wrap.Wrap;
			Style.JustifyContent = Justify.Center; 
			Style.AlignItems = Align.Center;
			Style.AlignContent = Align.Center;
		}
	}
}
