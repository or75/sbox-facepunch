
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;

namespace Sandbox.UI
{
	public class Menu : Panel
	{
		public Panel SelectedChild { get; set; }

		public override void OnButtonTyped( string button, KeyModifiers km )
		{
			if ( button == "up" )
			{
				MoveSelection( -1 );
			}

			if ( button == "down" )
			{
				MoveSelection( -1 );
			}

			base.OnButtonTyped( button, km );
		}

		public void MoveSelection( int dir )
		{
			var currentIndex = GetChildIndex( SelectedChild );

			if ( currentIndex >= 0 ) currentIndex += dir;
			else if ( currentIndex < 0 ) currentIndex = dir == 1 ? 0 : -1;

			SelectedChild?.SetClass( "active", false );
			SelectedChild = GetChild( currentIndex, true ) ;
			SelectedChild?.SetClass( "active", true );
		}


	}
}
