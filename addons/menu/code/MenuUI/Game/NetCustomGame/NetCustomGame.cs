
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.Internal;

[UseTemplate]
public class NetCustomGame : BaseGamePanel
{
	public NetCustomGame( BaseGamePanel gamePanel ) : base ( gamePanel )
	{

	}

	public void JoinGame()
	{
		var config = new Dictionary<string, string>();
		config["map"] = Package.GameConfiguration.MapList.First();

		_ = Sandbox.MenuEngine.Tools.CreateGame( Package, config );
	}
}
