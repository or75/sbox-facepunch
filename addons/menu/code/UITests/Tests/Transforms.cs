using Sandbox.UI.Construct;
using System;
using System.Linq;

namespace Sandbox.UI.Tests
{
	public class Transforms : Panel
	{
		public Transforms()
		{
			Style.FlexWrap = Wrap.Wrap;
			Style.JustifyContent = Justify.Center; 
			Style.AlignItems = Align.Center;
			Style.AlignContent = Align.Center;
			Style.Set( "font-size: 10px; width: 100%;" );
			StyleSheet.Parse( "label { padding: 10px; background-color: #aaa3; color: white; width: 50px; height: 50px; justify-content: center; align-items: center; } " +
				".parent { background-color: black; width: 100px; height: 100px; margin: 55px; }" );

			AddTest( "rotate( 15deg )\ncenter", "transform: rotate( 15deg );" );
			AddTest( "rotate( 15deg )\ntop left", "transform: rotate( 15deg ); transform-origin: 0px 0px;" );
			AddTest( "rotate( 15deg )\ntop middle", "transform: rotate( 15deg ); transform-origin: 50% 0px;" );
			AddTest( "rotate( 15deg )\nbottom right", "transform: rotate( 15deg ); transform-origin: 100% 100%;" );
			AddTest( "rotate( 15deg )\nbottom left", "transform: rotate( 15deg ); transform-origin: 0% 100%;" );

			AddTest( "scale( 1.1 )\ncenter", "transform: scale( 1.1 );" );
			AddTest( "scale( 1.1 )\ntop left", "transform: scale( 1.1 ); transform-origin: 0px 0px;" );
			AddTest( "scale( 1.1 )\ntop middle", "transform: scale( 1.1 ); transform-origin: 50% 0px;" );
			AddTest( "scale( 1.1 )\nbottom right", "transform: scale( 1.1 ); transform-origin: 100% 100%;" );
			AddTest( "scale( 1.1 )\nbottom left", "transform: scale( 1.1 ); transform-origin: 0% 100%;" );

			AddTest( "scale( 0.9 )\ncenter", "transform: scale( 0.9 );" );
			AddTest( "scale( 0.9 )\ntop left", "transform: scale( 0.9 ); transform-origin: 0px 0px;" );
			AddTest( "scale( 0.9 )\ntop middle", "transform: scale( 0.9 ); transform-origin: 50% 0px;" );
			AddTest( "scale( 0.9 )\nbottom right", "transform: scale( 0.9 ); transform-origin: 100% 100%;" );
			AddTest( "scale( 0.9 )\nbottom left", "transform: scale( 0.9 ); transform-origin: 0% 100%;" );

			AddTest( "rotate then translate", "transform: rotate( 90deg ) translateX( 100% );" );
			AddTest( "translate then rotate", "transform: translateX( 100% ) rotate( 90deg ); " );

			AddTest( "transform: skew( 15deg 30deg )\ncenter", "transform: skew( 15deg 30deg );" );
			AddTest( "transform: skew( 15deg 30deg )\ncenter", "transform: skew( 15deg 30deg );" );
			AddTest( "skewx( 15deg )\ntop left", "transform: skewx( 15deg ); transform-origin: 0px 0px;" );
			AddTest( "skewy( 15deg )\ntop middle", "transform: skewy( 15deg ); transform-origin: 50% 0px;" );

			AddTest( "matrix", "transform: matrix( 1, 2, -1, 1, 80, 80 ); transform-origin: 50% 0px;" );
			AddTest( "matrix3d", "transform: matrix3d( 0.359127, -0.469472, 0.806613, 0, 0.190951, 0.882948, 0.428884, 0, -0.913545, 0, 0.406737, 0, 0, 0, 0, 1 ); transform-origin: 50% 0px;" );
		}

		private void AddTest( string label, string v )
		{
			var parent = Add.Panel( "parent" );

			var p = parent.Add.Label( label );
			p.Style.Set( v );
		}
	}
}
