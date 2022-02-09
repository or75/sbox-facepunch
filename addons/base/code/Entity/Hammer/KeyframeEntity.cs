
using System;
using System.Threading.Tasks;

namespace Sandbox
{
	/// <summary>
	/// An entity that is moved programatically. Like an elevator
	/// or a kliner smashing star wars garbage compactor
	/// </summary>
	public partial class KeyframeEntity : AnimEntity
	{
		int movement = 0;

		/// <summary>
		/// Move to given transform in given amount of time
		/// </summary>
		/// <param name="target">The target transform</param>
		/// <param name="seconds">How many seconds to take to move to target transform</param>
		/// <param name="easing">If set, the easing funtion</param>
		/// <returns>Whether we successded moving to given target or not</returns>
		public async Task<bool> KeyframeTo( Transform target, float seconds, Easing.Function easing = null )
		{
			var start = Transform;

			var moveid = ++movement;
			var lastTime = Time.Now;
			for ( float f = 0; f < 1; )
			{
				await Task.NextPhysicsFrame();
				
				var timeDelta = Math.Max( Time.Now - lastTime, 0 );
				lastTime = Time.Now;

				if ( moveid != movement || !this.IsValid() )
					return false;

				var eased = easing != null ? easing( f ) : f;

				var newtx = Transform.Lerp( start, target, eased, false );

				TryKeyframeTo( newtx );

				f += timeDelta / seconds;
			}

			Transform = target;
			return true;
		}

		/// <summary>
		/// Used by KeyframeTo methods to try to move to a given transform
		/// </summary>
		public virtual bool TryKeyframeTo( Transform pos )
		{
			Transform = pos;
			return true;
		}

		int local_movement = 0;

		/// <summary>
		/// Move to a given local position in given amount of time
		/// </summary>
		/// <param name="deltaTarget">The target local position</param>
		/// <param name="seconds">How many seconds to take to move to target transform</param>
		/// <param name="easing">If set, the easing funtion</param>
		/// <returns>Whether we successded moving to given local target or not</returns>
		public async Task<bool> LocalKeyframeTo( Vector3 deltaTarget, float seconds, Easing.Function easing = null )
		{
			var moveid = ++local_movement;
			var startPos = LocalPosition;
			
			var lastTime = Time.Now;
			for ( float f = 0; f < 1; )
			{
				await Task.NextPhysicsFrame();

				var timeDelta = Math.Max( Time.Now - lastTime, 0 );
				lastTime = Time.Now;

				if ( moveid != local_movement || !this.IsValid() )
					return false;

				var eased = easing != null ? easing( f ) : f;

				TryLocalKeyframeTo( Vector3.Lerp( startPos, deltaTarget, eased, false ) );

				f += timeDelta / seconds;
			}

			LocalPosition = deltaTarget;

			return true;
		}

		/// <summary>
		/// Used by KeyframeTo methods to try to move to a given local position
		/// </summary>
		public virtual bool TryLocalKeyframeTo( Vector3 pos )
		{
			LocalPosition = pos;
			return true;
		}

		int local_rot_movement = 0;

		/// <summary>
		/// Rotate to a given local rotation in given amount of time
		/// </summary>
		/// <param name="localTarget">The target local rotation</param>
		/// <param name="seconds">How many seconds to take to move to target transform</param>
		/// <param name="easing">If set, the easing funtion</param>
		/// <returns>Whether we successded rotating to given target or not</returns>
		public async Task<bool> LocalRotateKeyframeTo( Rotation localTarget, float seconds, Easing.Function easing = null )
		{
			var moveId = ++local_rot_movement;
			var startPos = LocalRotation;
			
			var lastTime = Time.Now;
			for ( float f = 0; f < 1; )
			{
				await Task.NextPhysicsFrame();

				var timeDelta = Math.Max( Time.Now - lastTime, 0 );
				lastTime = Time.Now;

				if ( moveId != local_rot_movement || !this.IsValid() )
					return false;

				var eased = easing != null ? easing( f ) : f;

				var newPos = Rotation.Lerp( startPos, localTarget, eased );
				TryLocalRotateTo( newPos );

				f += timeDelta / seconds;
			}

			LocalRotation = localTarget;

			return true;
		}

		/// <summary>
		/// Used by LocalRotateKeyframeTo to try to rotate to a given rotation
		/// </summary>
		public virtual bool TryLocalRotateTo( Rotation pos )
		{
			//var oldPos = Rotation;
			//  set angular velocity so it lerps on client?
			// would it lerp anyway?
			LocalRotation = pos;
			return true;
		}
	}
}
