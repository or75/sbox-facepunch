﻿using Sandbox;
using System;

namespace Sandbox
{
	/// <summary>
	/// A struct to help you set up your citizen based animations
	/// </summary>
	public struct CitizenAnimationHelper
	{
		AnimEntity Owner;

		public CitizenAnimationHelper( AnimEntity entity )
		{
			Owner = entity;
		}

		/// <summary>
		/// Have the player look at this point in the world
		/// </summary>
		public void WithLookAt( Vector3 look, float eyesWeight = 1.0f, float headWeight = 1.0f, float bodyWeight = 1.0f )
		{
			Owner.SetAnimLookAt( "aim_eyes", look );
			Owner.SetAnimLookAt( "aim_head", look );
			Owner.SetAnimLookAt( "aim_body", look );

			Owner.SetAnimFloat( "aim_eyes_weight", eyesWeight );
			Owner.SetAnimFloat( "aim_head_weight", headWeight );
			Owner.SetAnimFloat( "aim_body_weight", bodyWeight );
		}

		public void WithVelocity( Vector3 Velocity )
		{
			var dir = Velocity;
			var forward = Owner.Rotation.Forward.Dot( dir );
			var sideward = Owner.Rotation.Right.Dot( dir );

			var angle = MathF.Atan2( sideward, forward ).RadianToDegree().NormalizeDegrees();

			Owner.SetAnimFloat( "move_direction", angle );
			Owner.SetAnimFloat( "move_speed", Velocity.Length );
			Owner.SetAnimFloat( "move_groundspeed", Velocity.WithZ( 0 ).Length );
			Owner.SetAnimFloat( "move_y", sideward );
			Owner.SetAnimFloat( "move_x", forward );
			Owner.SetAnimFloat( "move_z", Velocity.z );
		}

		public void WithWishVelocity( Vector3 Velocity )
		{
			var dir = Velocity;
			var forward = Owner.Rotation.Forward.Dot( dir );
			var sideward = Owner.Rotation.Right.Dot( dir );

			var angle = MathF.Atan2( sideward, forward ).RadianToDegree().NormalizeDegrees();

			Owner.SetAnimFloat( "wish_direction", angle );
			Owner.SetAnimFloat( "wish_speed", Velocity.Length );
			Owner.SetAnimFloat( "wish_groundspeed", Velocity.WithZ( 0 ).Length );
			Owner.SetAnimFloat( "wish_y", sideward );
			Owner.SetAnimFloat( "wish_x", forward );
			Owner.SetAnimFloat( "wish_z", Velocity.z );
		}
	}
}
