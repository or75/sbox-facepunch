
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Linq;
using System.Collections.Generic;

[NavigatorTarget( "/games/local" )]
public class LocalGameList : Panel
{
	List<GameIcon> GameIcons = new List<GameIcon>();

	public LocalGameList()
	{
		Rebuild();
	}

	[Event( "localaddons.changed" )]
	public void Rebuild()
	{
		//
		// At some point we're going to get this list from our api
		// but for now just use our addons
		//

		DeleteChildren( true );
		GameIcons.Clear();

		var packages = Package.GetLocal();
		if ( packages.Count() > 0 )
		{
			var group = Add.Panel( "group gametiles" );

			foreach ( var package in packages )
			{
				var gameIcon = new GameIcon( package );
				gameIcon.Parent = group;
				GameIcons.Add( gameIcon );
			}
		}
	}
}

