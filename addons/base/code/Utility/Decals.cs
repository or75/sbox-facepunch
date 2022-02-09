using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Sandbox
{
	public static partial class Decals
	{
		/// <summary>
		/// Place a decal on an entity
		/// </summary>
		[ClientRpc]
		public static void Place( Material material, Entity entity, int bone, Vector3 position, Vector3 scale, Rotation rotation )
		{
			Host.AssertClientOrMenu();

			if ( material == null ) return;
			if ( !entity.IsValid() ) return;

			// TODO - we could probably do decals by ourselves now, it's just a sceneobject
			Sandbox.Internal.Decals.Place( material, entity, bone, position, scale, rotation );
		}

		/// <summary>
		/// Place a decal on the world
		/// </summary>
		[ClientRpc]
		public static void Place( Material material, Vector3 position, Vector3 scale, Rotation rotation )
		{
			Host.AssertClientOrMenu();

			if ( material == null ) return;

			// TODO - we could probably do decals by ourselves now, it's just a sceneobject
			Sandbox.Internal.Decals.Place( material, position, scale, rotation );
		}
	}
}
