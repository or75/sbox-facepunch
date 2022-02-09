using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sandbox
{
	/// <summary>
	/// Extensions for Surfaces
	/// </summary>
	public static partial class SurfaceExtension
	{
		/// <summary>
		/// Create a particle effect and play an impact sound for this surface being hit by a bullet
		/// </summary>
		public static Particles DoBulletImpact( this Surface self, TraceResult tr )
		{
			//
			// No effects on resimulate
			//
			if ( !Prediction.FirstTime ) 
				return null;

			//
			// Drop a decal
			//
			var decalPath = Rand.FromArray( self.ImpactEffects.BulletDecal );

			var surf = self.GetBaseSurface();
			while ( string.IsNullOrWhiteSpace( decalPath ) && surf != null )
			{
				decalPath = Rand.FromArray( surf.ImpactEffects.BulletDecal );
				surf = surf.GetBaseSurface();
			}

			if ( !string.IsNullOrWhiteSpace( decalPath ) )
			{
				if ( DecalDefinition.ByPath.TryGetValue( decalPath, out var decal ) )
				{
					decal.PlaceUsingTrace( tr );
				}
			}

			//
			// Make an impact sound
			//
			var sound = self.Sounds.Bullet;

			surf = self.GetBaseSurface();
			while ( string.IsNullOrWhiteSpace( sound ) && surf != null )
			{
				sound = surf.Sounds.Bullet;
				surf = surf.GetBaseSurface();
			}

			if ( !string.IsNullOrWhiteSpace( sound ) )
			{
				Sound.FromWorld( sound, tr.EndPos );
			}

			//
			// Get us a particle effect
			//

			string particleName = Rand.FromArray( self.ImpactEffects.Bullet );
			if ( string.IsNullOrWhiteSpace( particleName ) ) particleName = Rand.FromArray( self.ImpactEffects.Regular );

			surf = self.GetBaseSurface();
			while ( string.IsNullOrWhiteSpace( particleName ) && surf != null )
			{
				particleName = Rand.FromArray( surf.ImpactEffects.Bullet );
				if ( string.IsNullOrWhiteSpace( particleName ) ) particleName = Rand.FromArray( surf.ImpactEffects.Regular );

				surf = surf.GetBaseSurface();
			}

			if ( !string.IsNullOrWhiteSpace( particleName ) )
			{
				var ps = Particles.Create( particleName, tr.EndPos );
				ps.SetForward( 0, tr.Normal );

				return ps;
			}

			return default;
		}

		/// <summary>
		/// Create a footstep effect
		/// </summary>
		public static void DoFootstep( this Surface self, Entity ent, TraceResult tr, int foot, float volume )
		{
			var sound = foot == 0 ? self.Sounds.FootLeft : self.Sounds.FootRight;

			if ( !string.IsNullOrWhiteSpace( sound ) )
			{
				ent.PlaySound( sound )
					.SetPosition( tr.EndPos )
					.SetVolume( volume );
			}
			else if ( self.GetBaseSurface() != null )
			{
				// Give base surface a chance
				self.GetBaseSurface().DoFootstep( ent, tr, foot, volume );
			}
		}
	}

}
