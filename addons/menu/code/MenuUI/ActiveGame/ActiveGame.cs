
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.Internal;

[UseTemplate, NavigatorTarget( "/activegame" )]
public class ActiveGame : Panel
{
	public Package GamePackage { get; set; }
	public Package MapPackage { get; set; }
	public string GameName => Global.GameName;

	public ActiveGame()
	{
		
	}


	int infoHash;

	public override void Tick()
	{
		base.Tick();

		var hash = HashCode.Combine( Global.GameName, Global.MapName );
		if ( hash != infoHash )
		{
			infoHash = hash;
			_ = UpdatePackageInfo();
		}
	}

	public async Task UpdatePackageInfo()
	{
		GamePackage = await Package.Fetch( Global.GameName, false );
		SetClass( "has-game", GamePackage != null );

		MapPackage = await Package.Fetch( Global.MapName, false );
		SetClass( "has-map", MapPackage != null );
	}
}

