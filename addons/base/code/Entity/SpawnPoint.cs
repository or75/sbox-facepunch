using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandbox
{
	/// <summary>
	/// This entity defines the spawn point of the player in first person shooter gamemodes.
	/// </summary>
	[Library( "info_player_start" )]
	[Hammer.EditorModel( "models/editor/playerstart.vmdl", FixedBounds = true )]
	[Hammer.EntityTool( "Player Spawnpoint", "Player", "Defines a point where the player can (re)spawn" )]
	[Display( Name = "Spawnpoint" ), Icon( "place" )]
	public class SpawnPoint : Entity
	{

	}
}
