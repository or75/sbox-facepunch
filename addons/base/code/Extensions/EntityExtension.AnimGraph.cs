using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
	public static partial class EntityExtensions
	{

		/// <summary>
		/// Sets the procedural hit creation parameters for the animgraph node, which makes the 
		/// model twitch according to where it got hit. 
		/// 
		/// The parameters set are
		/// 
		///		bool hit
		///		int hit_bone
		///		vector hit_offset
		///		vector hit_direction
		///		vector hit_strength
		///		
		/// </summary>
		public static void ProceduralHitReaction( this AnimEntity self, DamageInfo info, float damageScale = 1.0f )
		{
			var tx = self.GetBoneTransform( info.BoneIndex );
			//DebugOverlay.Text( tx.Position, $"{info.BoneIndex}: {GetBoneName( info.BoneIndex)}", 10.0f );

			var localToBone = tx.PointToLocal( info.Position );

			if ( localToBone == Vector3.Zero )
				localToBone = Vector3.One;

			self.SetAnimBool( "hit", true );
			self.SetAnimInt( "hit_bone", info.BoneIndex );
			self.SetAnimVector( "hit_offset", localToBone );
			self.SetAnimVector( "hit_direction", info.Force.Normal );
			self.SetAnimFloat( "hit_strength", (info.Force.Length / 1000.0f) * damageScale );
		}
	}
}
