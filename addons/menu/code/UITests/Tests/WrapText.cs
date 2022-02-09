using Sandbox.UI.Construct;
using System;
using System.Linq;

namespace Sandbox.UI.Tests
{
	public class WrapText : Panel
	{
		public WrapText()
		{
			Style.FlexWrap = Wrap.Wrap;
			Style.JustifyContent = Justify.SpaceBetween; 
			Style.AlignItems = Align.Center;
			Style.AlignContent = Align.Center;

			var words = new[]{"lorem", "ipsum", "😍", "dolor", "sit", "amet", "consectetuer", "adipiscing", "elit", "sed", "diam", "🍔", "nonummy", "nibh", "euismod", "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

			for ( int i=0; i<100; i++ )
			{
				var p = Add.Label( string.Join( " ", words.OrderBy( x => Guid.NewGuid() ).Take( Rand.Int( 2, 7 ) ) ) );
				p.Style.Margin = 5;
				p.Style.Padding = 10;
				p.Style.FontSize = Rand.Float( 7, 15 );
				p.Style.FontWeight = Rand.Int( 200, 900 );
				p.Style.BackgroundColor = Color.Black;  
				p.Style.FontColor = Color.White;
			}
		}
	}
}