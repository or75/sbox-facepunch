using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
	public partial class Game
	{

		/// <summary>
		/// This entity is probably a pawn, and would like to be placed on a spawnpoint.
		/// If you were making a team based game you'd want to choose the spawn based on team.
		/// Or not even call this. Up to you. Added as a convenience.
		/// </summary>
		public virtual void MoveToSpawnpoint( Entity pawn )
		{
			var spawnpoint = Entity.All
									.OfType<SpawnPoint>()               // get all SpawnPoint entities
									.OrderBy( x => Guid.NewGuid() )     // order them by random
									.FirstOrDefault();                  // take the first one

			if ( spawnpoint == null )
			{
				Log.Warning( $"Couldn't find spawnpoint for {pawn}!" );
				return;
			}

			pawn.Transform = spawnpoint.Transform;
		}

		/// <summary>
		/// An entity has been killed. This is usually a pawn but anything can call it.
		/// </summary>
		public virtual void OnKilled( Entity pawn )
		{
			Host.AssertServer();

			if ( pawn.Client != null )
			{
				OnKilled( pawn.Client, pawn );
				return;
			}
		}

		/// <summary>
		/// An entity, which is a pawn, and has a client, has been killed.
		/// </summary>
		public virtual void OnKilled( Client client, Entity pawn )
		{
			Host.AssertServer();

			Log.Info( $"{client.Name} was killed" );

			if ( pawn.LastAttacker != null )
			{
				if ( pawn.LastAttacker.Client != null )
				{
					OnKilledMessage( pawn.LastAttacker.Client.PlayerId, pawn.LastAttacker.Client.Name, client.PlayerId, client.Name, pawn.LastAttackerWeapon?.ClassInfo?.Name );
				}
				else
				{
					OnKilledMessage( pawn.LastAttacker.NetworkIdent, pawn.LastAttacker.ToString(), client.PlayerId, client.Name, "killed" );
				}
			}
			else
			{
				OnKilledMessage( 0, "", client.PlayerId, client.Name, "died" );
			}
		}

		/// <summary>
		/// Called clientside from OnKilled on the server to add kill messages to the killfeed. 
		/// </summary>
		[ClientRpc]
		public virtual void OnKilledMessage( long leftid, string left, long rightid, string right, string method )
		{
			UI.KillFeed.Current?.AddEntry( leftid, left, rightid, right, method );
		}

	}
}
