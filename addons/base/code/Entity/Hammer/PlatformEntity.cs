using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Sandbox
{
	/// <summary>
	/// A simple platform that moves between two locations and can be controlled through map IO.
	/// </summary>
	[Library( "ent_platform" )]
	[Hammer.SupportsSolid]
	[Hammer.Model]
	[Hammer.RenderFields]
	[Hammer.DoorHelper( "movedir", "movedir_islocal", "movedir_type", "movedistance" )]
	[Hammer.VisGroup( Hammer.VisGroup.Dynamic )]
	public partial class PlatformEntity : KeyframeEntity
	{
		/// <summary>
		/// Specifies the direction to move in when the platform is used, or axis of rotation for rotating platforms.
		/// </summary>
		[Property( "movedir", Title = "Move Direction" )]
		public Angles MoveDir { get; set; } = new Angles( 0, 0, 0 );

		/// <summary>
		/// If checked, the movement direction angle is in local space and should be rotated by the entity's angles after spawning.
		/// </summary>
		[Property( "movedir_islocal", Title = "Move Direction is Expressed in Local Space" )]
		public bool MoveDirIsLocal { get; set; } = true;

		// The values correspond to DoorHelper.
		public enum PlatformMoveType
		{
			//Moving = 0 // Moving with Distance=Lip
			Moving = 3, // StartPos + Dir * Distance
			Rotating = 1,
			RotatingContinious = 4, // Rotating without reversing
			//NotMoving = 2,
		}

		/// <summary>
		/// Movement type of the platform.<br/>
		/// <b>Moving</b>: Moving linearly and reversing direction at final position if Looping is enabled.<br/>
		/// <b>Rotating</b>: Rotating and reversing direction at final rotation if Looping is enabled.<br/>
		/// <b>Rotating Continious</b>: Rotating continiously past Move Distance. OnReached outputs are fired every Move Distance degrees.<br/>
		/// </summary>
		[Property( "movedir_type", Title = "Movement Type" )]
		public PlatformMoveType MoveDirType { get; set; } = PlatformMoveType.Moving;

		/// <summary>
		/// How much to move in the move direction, or rotate around the axis for rotating move type.
		/// </summary>
		[Property]
		public float MoveDistance { get; set; } = 100.0f;

		/// <summary>
		/// The speed to move/rotate with.
		/// </summary>
		[Property]
		public float Speed { get; protected set; } = 64.0f;

		/// <summary>
		/// If set to above 0 and <b>Loop Movement</b> is enabled, the amount of time to wait before automatically toggling direction.
		/// </summary>
		[Property]
		public float TimeToHold { get; set; } = 0.0f;
		
		/// <summary>
		/// If set, the platform will automatically go back upon reaching either end of the movement range.
		/// </summary>
		[Property]
		public bool LoopMovement { get; set; } = false;

		// TODO: Acceleration/deceleration?

		/// <summary>
		/// If set, the platform will start moving on spawn.
		/// </summary>
		[Property, Category( "Spawn Settings" )]
		public bool StartsMoving { get; set; } = true;

		/// <summary>
		/// At what percentage between start and end positions should the platform spawn in
		/// </summary>
		[Property, Category( "Spawn Settings" ), Hammer.MinMax( 0, 100 )]
		public float StartPosition { get; set; } = 0;

		/// <summary>
		/// Sound to play when starting to move
		/// </summary>
		[Property, FGDType( "sound" ), Category( "Sounds" )]
		public string StartMoveSound { get; set; }

		/// <summary>
		/// Sound to play when we stopped moving
		/// </summary>
		[Property, FGDType( "sound" ), Category( "Sounds" )]
		public string StopMoveSound { get; set; }

		/// <summary>
		/// Sound to play while platform is moving.
		/// </summary>
		[Property( "moving_sound" ), FGDType( "sound" ), Category( "Sounds" )]
		public string MovingSound { get; set; }



		public bool IsMoving { get; protected set; }
		public bool IsMovingForwards { get; protected set; }

		Vector3 PositionA;
		Vector3 PositionB;
		Rotation RotationA;

		public override void Spawn()
		{
			base.Spawn();

			SetupPhysicsFromModel( PhysicsMotionType.Keyframed );

			// PlatformMoveType.Moving
			{
				PositionA = LocalPosition;
				PositionB = PositionA + MoveDir.Direction * MoveDistance;

				if ( MoveDirIsLocal )
				{
					var dir_world = Transform.NormalToWorld( MoveDir.Direction );
					PositionB = PositionA + dir_world * MoveDistance;
				}
			}

			// PlatformMoveType.Rotating
			{
				RotationA = LocalRotation;
			}

			IsMoving = false;
			IsMovingForwards = true;

			if ( StartPosition > 0 )
			{
				if ( MoveDirType == PlatformMoveType.Moving )
				{
					LocalPosition = Vector3.Lerp( PositionA, PositionB, StartPosition / 100.0f );
				}
				else
				{
					LocalRotation = Rotation.Lerp( RotationA, RotationA.RotateAroundAxis( GetRotationAxis(), MoveDistance != 0 ? MoveDistance : 360.0f ), StartPosition / 100.0f );
					CurrentRotation = 0.0f.LerpTo( MoveDistance != 0 ? MoveDistance : 360.0f, StartPosition / 100.0f );
				}
			}

			if ( StartsMoving )
			{
				StartMoving();
			}
		}

		protected override void OnDestroy()
		{
			if ( MoveSoundInstance.HasValue )
			{
				MoveSoundInstance.Value.Stop();
				MoveSoundInstance = null;
			}

			base.OnDestroy();
		}

		Vector3 GetRotationAxis()
		{
			var axis = Rotation.From( MoveDir ).Up;
			if ( !MoveDirIsLocal ) axis = Transform.NormalToLocal( axis );

			return axis;
		}

		/// <summary>
		/// Fired when the platform reaches its beginning location
		/// </summary>
		protected Output OnReachedStart { get; set; }

		/// <summary>
		/// Fired when the platform reaches its end location (startPos + dir * distance)
		/// </summary>
		protected Output OnReachedEnd { get; set; }

		/// <summary>
		/// Contains the current rotation of the platform in degrees.
		/// </summary>
		public float CurrentRotation { get; protected set; } = 0;

		int movement = 0;
		Sound? MoveSoundInstance = null;
		async Task DoMove()
		{
			if ( !IsMoving ) Sound.FromEntity( StartMoveSound, this );

			IsMoving = true;
			var moveId = ++movement;

			if ( !MoveSoundInstance.HasValue && !string.IsNullOrEmpty( MovingSound ) )
			{
				MoveSoundInstance = PlaySound( MovingSound );
			}

			if ( MoveDirType == PlatformMoveType.Moving )
			{
				var position = IsMovingForwards ? PositionB : PositionA;

				var distance = Vector3.DistanceBetween( LocalPosition, position );
				var timeToTake = distance / Math.Max( Speed, 0.1f );

				var success = await LocalKeyframeTo( position, timeToTake, null );
				if ( !success )
					return;
			}
			else if ( MoveDirType == PlatformMoveType.RotatingContinious || MoveDirType == PlatformMoveType.Rotating )
			{
				var moveDist = MoveDistance;
				if ( moveDist == 0 ) moveDist = 360.0f;
				if ( IsMovingForwards ) moveDist = -moveDist;

				// If speed is negative, allow going backwards
				var speed = Speed;
				if ( speed < 0 )
				{
					moveDist = -moveDist;
					speed = -speed;
				}

				var timeToTake = Math.Abs( moveDist ) / speed;
				var initialRotation = CurrentRotation - (CurrentRotation % moveDist);
				
				var axis_rot = GetRotationAxis();
				var lastTime = Time.Now;
				for ( float f = CurrentRotation % moveDist / moveDist; f < 1; )
				{
					await Task.NextPhysicsFrame();
					var diff = Math.Max( Time.Now - lastTime, 0 );
					lastTime = Time.Now;

					if ( moveId != movement || !this.IsValid() ) return;


					var delta = diff / timeToTake;
					CurrentRotation += delta * moveDist;
					LocalRotation = RotationA.RotateAroundAxis( axis_rot, CurrentRotation );
					f += delta;
				}

				// Snap to the ideal final position
				var axis_final = GetRotationAxis();
				CurrentRotation = initialRotation + moveDist;
				LocalRotation = RotationA.RotateAroundAxis( axis_final, CurrentRotation );  
			}
			else { Log.Warning( $"{this}: Unknown platform move type {MoveDirType}!" ); await Task.Delay( 100 ); }

			if ( moveId != movement || !this.IsValid() ) return;

			if ( IsMovingForwards )
			{
				_ = OnReachedEnd.Fire( this );
			}
			else
			{
				_ = OnReachedStart.Fire( this );
			}

			if ( MoveDirType != PlatformMoveType.RotatingContinious || TimeToHold > 0 )
			{
				IsMoving = false;

				if ( MoveSoundInstance.HasValue )
				{
					MoveSoundInstance.Value.Stop();
					MoveSoundInstance = null;
				}

				// Do not play the stop sound for instant changing direction
				if ( !LoopMovement || TimeToHold > 0 )
				{
					Sound.FromEntity( StopMoveSound, this );
				}
			}

			if ( !LoopMovement ) return;
			
			// ToggleMovement input during this time causes unexpected behavior
			IsMoving = true;
			if ( TimeToHold > 0 ) await Task.DelaySeconds( TimeToHold );
			IsMoving = false;

			if ( moveId != movement || !this.IsValid() ) return;

			if ( MoveDirType != PlatformMoveType.RotatingContinious )
			{
				IsMovingForwards = !IsMovingForwards;
			}

			_ = DoMove();
		}

		/// <summary>
		/// Start moving in platform's current move direction
		/// </summary>
		[Input] public void StartMoving()
		{
			_ = DoMove();
		}

		/// <summary>
		/// Set the move direction to forwards and start moving
		/// </summary>
		[Input] public void StartMovingForward()
		{
			IsMovingForwards = true;
			StartMoving();
		}

		/// <summary>
		/// Set the move direction to backwards and start moving
		/// </summary>
		[Input] public void StartMovingBackwards()
		{
			IsMovingForwards = false;
			StartMoving();
		}

		/// <summary>
		/// Reverse current move direction. Will NOT start moving if stopped
		/// </summary>
		[Input] public void ReverseMoving()
		{
			IsMovingForwards = !IsMovingForwards;

			if ( IsMoving )
			{
				// We changed direction, play the start moving sound
				// TODO: Have a "Change direction while moving" sound option?
				PlaySound( StartMoveSound );
				StartMoving();
			}
		}

		/// <summary>
		/// Stop moving, preserving move direction
		/// </summary>
		[Input] public void StopMoving()
		{
			if ( !IsMoving ) return;

			movement++;
			_ = LocalKeyframeTo( LocalPosition, 0, null ); // Bad
			_ = LocalRotateKeyframeTo( LocalRotation, 0, null );

			IsMoving = false;
			PlaySound( StopMoveSound );

			if ( MoveSoundInstance.HasValue )
			{
				MoveSoundInstance.Value.Stop();
				MoveSoundInstance = null;
			}
		}

		/// <summary>
		/// Toggle moving, preserving move direction
		/// </summary>
		[Input] public void ToggleMoving()
		{
			if ( IsMoving )
			{
				StopMoving();
				return;
			}

			StartMoving();
		}

		/// <summary>
		/// Sets the move speed
		/// </summary>
		[Input] public void SetSpeed( float speed )
		{
			Speed = speed;

			// Update the moving speed
			if ( IsMoving ) StartMoving();
		}
	}
}
