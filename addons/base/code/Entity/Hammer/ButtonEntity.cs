using System;
using System.Threading.Tasks;

namespace Sandbox
{
	/// <summary>
	/// A generic button that is useful to control other map entities via inputs/outputs.
	/// </summary>
	[Library( "ent_button" )]
	[Hammer.SupportsSolid]
	[Hammer.DoorHelper( "movedir", "movedir_islocal", "movedir_type", "distance" )]
	[Hammer.RenderFields]
	[Hammer.Model( Archetypes = ModelArchetype.animated_model | ModelArchetype.static_prop_model )]
	[Hammer.VisGroup( Hammer.VisGroup.Dynamic )]
	public partial class ButtonEntity : KeyframeEntity, IUse
	{
		[Flags]
		public enum ActivationFlags
		{
			UseActivates = 1,
			DamageActivates = 2,
			//TouchActivates = 4,
			//Toggle = 8,
		}

		/// <summary>
		/// How this button can be activated
		/// </summary>
		[Property, FGDType( "flags" )]
		public ActivationFlags ActivationSettings { get; set; } = ActivationFlags.UseActivates;

		[Flags]
		public enum Flags
		{
			StartsLocked = 1,
			NonSolid = 2,
		}

		/// <summary>
		/// Settings that are only relevant on spawn
		/// </summary>
		[Property, FGDType( "flags" )]
		public Flags SpawnSettings { get; set; }

		/// <summary>
		/// Specifies the direction to move in when the button is used, or axis of rotation for rotating buttons.
		/// </summary>
		[Property( Title = "Move Direction" )]
		public Angles MoveDir { get; set; } = new Angles( 0, 0, 0 );

		/// <summary>
		/// If checked, the movement direction angle is in local space and should be rotated by the entity's angles after spawning.
		/// </summary>
		[Property( "movedir_islocal", Title = "Move Direction is Expressed in Local Space" )]
		public bool MoveDirIsLocal { get; set; } = true;

		public enum ButtonMoveType
		{
			Moving,
			Rotating,
			NotMoving
		}

		/// <summary>
		/// Movement type of the button.
		/// </summary>
		[Property( "movedir_type", Title = "Movement Type" )]
		public ButtonMoveType MoveDirType { get; set; } = ButtonMoveType.Moving;

		/// <summary>
		/// Moving button: The amount, in inches, of the button to leave sticking out of the wall it recedes into when pressed. Negative values make the button recede even further into the wall.
		/// Rotating button: The amount, in degrees, that the button should rotate when it's pressed.
		/// </summary>
		[Property]
		public float Distance { get; set; } = 0.0f;

		/// <summary>
		/// The speed that the button moves, in inches per second
		/// </summary>
		[Property]
		public float Speed { get; set; } = 100.0f;

		/// <summary>
		/// Amount of time, in seconds, after the button has been fully pressed before it starts to return to the starting position. Once it has returned, it can be used again. If the value is set to -1, the button never returns.
		/// </summary>
		[Property( "reset_delay", Title = "Reset Delay (-1 stay)" )]
		public float ResetDelay { get; set; } = 1.0f;

		/// <summary>
		/// Sound played when the button is pressed and is unlocked
		/// </summary>
		[Property( "unlocked_sound", Title = "Activation Sound"), FGDType( "sound" )]
		public string UnlockedSound { get; set; } // TODO: Switch to SoundEvent when that works

		/// <summary>
		/// Sound played when the button is pressed and is locked
		/// </summary>
		[Property( "locked_sound", Title = "Locked Activation Sound"), FGDType( "sound" )]
		public string LockedSound { get; set; } // TODO: Switch to SoundEvent when that works

		public bool Locked { get; set; }

		/// <summary>
		/// The easing function for both movement and rotation
		/// TODO: Expose to hammer in a nice way
		/// </summary>
		public Easing.Function Ease { get; set; } = Easing.EaseOut;

		bool State;
		bool Moving;

		Vector3 PositionStart;
		Vector3 PositionEnd;

		Rotation RotationStart;
		Rotation RotationEnd;

		public override void Spawn()
		{
			base.Spawn();

			SetupPhysicsFromModel( PhysicsMotionType.Keyframed );

			if ( SpawnSettings.HasFlag( Flags.NonSolid ) )
			{
				EnableSolidCollisions = false;
			}

			Locked = SpawnSettings.HasFlag( Flags.StartsLocked );

			// ButtonMoveType.Moving
			{
				var dir = MoveDir.Direction;
				var dir_world = dir;

				if ( MoveDirIsLocal ) dir_world = Transform.NormalToWorld( dir );

				var delta = dir_world * (MathF.Abs( CollisionBounds.Size.Dot( dir ) ) - Distance);

				PositionStart = LocalPosition;
				PositionEnd = PositionStart + delta;
			}

			// ButtonMoveType.Rotating
			{
				var axis = Rotation.From( MoveDir ).Up;

				if ( !MoveDirIsLocal ) axis = Transform.NormalToLocal( axis );

				RotationStart = LocalRotation;
				RotationEnd = RotationStart.RotateAroundAxis( axis, Distance );
			}
		}

		public virtual bool IsUsable( Entity user ) => !Moving && ActivationSettings.HasFlag( ActivationFlags.UseActivates );

		/// <summary>
		/// Fired when the button is used while locked
		/// </summary>
		protected Output OnUseLocked { get; set; }

		/// <summary>
		/// A player has pressed this
		/// </summary>
		public virtual bool OnUse( Entity user )
		{
			if ( !ActivationSettings.HasFlag( ActivationFlags.UseActivates ) ) return false;

			if ( Locked )
			{
				OnUseLocked.Fire( user );
				Sound.FromEntity( LockedSound, this );
				return false;
			}

			DoPress( user );

			return false;
		}

		/// <summary>
		/// Fired when the button is damaged
		/// </summary>
		protected Output OnDamaged { get; set; }

		public override void TakeDamage( DamageInfo info )
		{
			base.TakeDamage( info );

			OnDamaged.Fire( info.Attacker );

			if ( ActivationSettings.HasFlag( ActivationFlags.DamageActivates ) )
			{
				DoPress( info.Attacker );
			}
		}

		/// <summary>
		/// Fired when the button is pressed
		/// </summary>
		protected Output OnPressed { get; set; }

		internal void DoPress( Entity activator )
		{
			if ( Moving ) return;

			if ( Locked )
			{
				Sound.FromEntity( LockedSound, this );
				return;
			}

			State = !State;

			Sound.FromEntity( UnlockedSound, this );
			OnPressed.Fire( activator );

			_ = MoveToPosition( State, activator );
		}

		/// <summary>
		/// Fired when the button reaches the in/pressed position
		/// </summary>
		protected Output OnIn { get; set; }

		/// <summary>
		/// Fired when the button reaches the out/released position
		/// </summary>
		protected Output OnOut { get; set; }

		async Task MoveToPosition( bool state, Entity activator )
		{
			State = state;
			Moving = true;

			if ( MoveDirType == ButtonMoveType.Moving )
			{
				var position = state ? PositionEnd : PositionStart;
				var distance = Vector3.DistanceBetween( LocalPosition, position );
				var timeToTake = distance / Math.Max( Speed, 0.1f );

				if ( ! await LocalKeyframeTo( position, timeToTake, Ease ) )
				{
					Moving = false;
					return;
				}
			}
			else if ( MoveDirType == ButtonMoveType.Rotating )
			{
				var target = state ? RotationEnd : RotationStart;
				Rotation diff = LocalRotation * target.Inverse;
				var timeToTake = diff.Angle() / Math.Max( Speed, 0.1f );

				if ( ! await LocalRotateKeyframeTo( target, timeToTake, Ease ) )
				{
					Moving = false;
					return;
				}
			}
			else if ( MoveDirType != ButtonMoveType.NotMoving )
			{
				Log.Warning( $"{this}: Unknown button move type {MoveDirType}!" );
			}

			if ( state ) _ = OnIn.Fire( activator );
			else _ = OnOut.Fire( activator );

			if ( state == false )
			{
				Moving = false;
				return;
			}

			if ( ResetDelay < 0 )
			{
				// Continue to be moving so we can't be de pressed
				//Moving = false;
				return;
			}

			await Task.DelaySeconds( ResetDelay );

			Moving = false;

			await MoveToPosition( false, activator );
		}

		/// <summary>
		/// Become locked
		/// </summary>
		[Input]
		protected void Lock()
		{
			Locked = true;
		}

		/// <summary>
		/// Become unlocked
		/// </summary>
		[Input]
		protected void Unlock()
		{
			Locked = false;
		}

		/// <summary>
		/// Simulates the button being pressed
		/// </summary>
		[Input]
		protected void Press( Entity activator )
		{
			DoPress( activator );
		}
	}
}
