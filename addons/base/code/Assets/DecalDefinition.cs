using NativeEngine;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox
{
	[Library( "decal" ), AutoGenerate]
	public partial class DecalDefinition : Asset
	{
		/// <summary>
		/// A dictionary of decals by asset path.
		/// </summary>
		public static Dictionary<string, DecalDefinition> ByPath = new();

		public class DecalEntry
		{
			/// <summary>
			/// Material to use.
			/// </summary>
			public Material Material { get; set; }

			/// <summary>
			/// Width of the decal.
			/// </summary>
			[Internal.DefaultValue( "5 5 0" )]
			public RangedFloat Width { get; set; } = new RangedFloat( 5 );

			/// <summary>
			/// Height of the decal.
			/// </summary>
			[Internal.DefaultValue( "5 5 0" )]
			public RangedFloat Height { get; set; } = new RangedFloat( 5 );

			/// <summary>
			/// Keep aspect ratio of the decal image when using randomly generating Width and Height.
			/// </summary>
			public bool KeepAspect { get; set; }

			/// <summary>
			/// TODO: Describe me
			/// </summary>
			[Internal.DefaultValue( "3 3 0" )]
			public RangedFloat Depth { get; set; } = new RangedFloat( 3 );

			/// <summary>
			/// Rotation to apply when placing the decal.
			/// </summary>
			[Internal.DefaultValue( "0 360 1" )]
			public RangedFloat Rotation { get; set; } = new RangedFloat( 0, 360 );
		}

		/// <summary>
		/// A list of decals, from which an entry will be randomly selected when this decal is placed.
		/// </summary>
		[Property( Title = "Decal List" )]
		public DecalEntry[] Decals { get; set; }

		protected override void PostLoad()
		{
			ByPath[Path] = this;
		}

		/// <summary>
		/// Place this decal somewhere
		/// </summary>
		public void PlaceUsingTrace( TraceResult tr )
		{
			var entry = Rand.FromArray( Decals );
			if ( entry == null )
				return;

			var w = entry.Width.GetValue();
			var h = entry.Height.GetValue();
			var d = entry.Depth.GetValue();
			var r = entry.Rotation.GetValue();

			if ( entry.KeepAspect )
			{
				h = w * (entry.Width.x / entry.Height.x);
			}

			var rot = Rotation.LookAt( tr.Normal ) * Rotation.FromAxis( Vector3.Forward, r );

			var pos = tr.EndPos;

			if ( tr.Entity is ModelEntity me && !me.IsWorld )
			{
				var tx = me.GetBoneTransform( tr.Bone );
				pos = tx.PointToLocal( pos );
				rot = tx.RotationToLocal( rot );
			}

			Place( entry.Material, tr.Entity, tr.Bone, pos, rot, new Vector3( w, h, d ) );
		}

		[ClientRpc]
		public static void Place( Material material, Entity ent, int bone, Vector3 localpos, Rotation localrot, Vector3 scale )
		{
			if ( ent is ModelEntity me )
			{
				var tx = me.GetBoneTransform( bone );
				var pos = tx.PointToWorld( localpos );
				var rot = tx.RotationToWorld( localrot );

				Sandbox.Decals.Place( material, ent, bone, pos, scale, rot );
			}
			else
			{
				if ( !ent.IsValid() )
				{
					ent = PhysicsWorld.WorldBody?.Entity;
				}

				if ( ent.IsValid() )
				{
					Sandbox.Decals.Place( material, ent, bone, localpos, scale, localrot );
				}
			}
		}
	}
}
