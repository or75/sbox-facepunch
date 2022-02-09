using Sandbox.UI.Construct;
using System;
using System.Linq;

namespace Sandbox.UI.Tests
{
	public class Position : Panel
	{
		public Position()
		{
			StyleSheet.Load( "uitests/tests/position.scss" );

			Add.Panel( "a" ).Add.Panel( "child" );
			Add.Panel( "b" ).Add.Panel( "child" );
			Add.Panel( "c" ).Add.Panel( "child" );
			Add.Panel( "d" ).Add.Panel( "child" );
		}
	}
}
