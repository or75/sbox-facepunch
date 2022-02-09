
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sandbox.Internal;

[UseTemplate]
public class GameLobbySettings : Panel
{
	[Property]
	public Package Game { get; set; }

	[Property]
	public Lobby Lobby { get; set; }

	public GameLobbySettings()
	{

	}
}
