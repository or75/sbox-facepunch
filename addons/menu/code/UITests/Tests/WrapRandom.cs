using Sandbox.UI.Construct;

namespace Sandbox.UI.Tests
{
	public class WrapRandom : Panel
	{
		public WrapRandom()
		{
			Style.FlexWrap = Wrap.Wrap;
			Style.JustifyContent = Justify.SpaceBetween;

			for ( int i=0; i<100; i++ )
			{
				var p = Add.Panel();
				p.Style.Margin = Rand.Float( 5, 10 );
				p.Style.Padding = 10;
				p.Style.Width = Rand.Float( 20, 100 );
				p.Style.Height = Rand.Float( 20, 100 );
				p.Style.BackgroundColor = Color.Random;
			}
		}
	}
}