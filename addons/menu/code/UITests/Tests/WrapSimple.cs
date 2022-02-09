using Sandbox.UI.Construct;

namespace Sandbox.UI.Tests
{
	public class WrapSimple : Panel
	{
		public WrapSimple()
		{
			Style.FlexWrap = Wrap.Wrap;
			Style.JustifyContent = Justify.FlexStart;

			StyleSheet.Parse( ".cell \n" +
				"{ \n" +
				"	width: 40px; \n" +
				"	height: 40px; \n" +
				"	margin: 5px; \n" +
				"" +
				"	&:outro\n" +
				"	{\n" +
				"		transition: all 0.2s ease;\n" +
				"		width: 0px;" +
				"		margin-right: 0px;\n" +
				"		margin-left: 0px;\n" +
				"	}\n" +
				"}\n" );

			for ( int i=0; i<200; i++ )
			{
				var p = Add.Panel( "cell" );
				p.Style.BackgroundColor = Color.Random;
				p.AddEventListener( "onclick", () => p.Delete() );
			}
		}
	}
}
