
namespace Sandbox
{
	/// <summary>
	/// A generic non model physics object.
	/// </summary>
    [Library( "func_physbox" )]
	[Hammer.Solid]
	[Hammer.RenderFields]
	[Hammer.VisGroup( Hammer.VisGroup.Physics )]
	public partial class FuncPhysbox : BasePhysics
	{
		[Spawnflags]
		public enum Flags
		{
			StartMotionless = 32768,
			StartAsleep = 1048576
		}

		/// <summary>
		/// Physical properties of this physbox
		/// </summary>
		[Property( "propdata", Title = "Physical material" )] [Net]
		public string PropData { get; set; }

		/// <summary>
		/// Amount of damage this entity can take before breaking
		/// </summary>
		[Property( "health", Title = "Health" )]
		public float _health { get; set; }

		public override void Spawn()
		{
			base.Spawn();

			Health = _health;

			CreatePhysics();

			if ( SpawnFlags.Has( Flags.StartMotionless ) )
			{
				PhysicsBody.MotionEnabled = false;
			}

			if ( SpawnFlags.Has( Flags.StartAsleep ) )
			{
				PhysicsGroup.Sleep();
			}
		}

		public override void ClientSpawn()
		{
			base.ClientSpawn();

			CreatePhysics();
		}

		void CreatePhysics()
		{
			SetupPhysicsFromModel( PhysicsMotionType.Dynamic );

			PhysicsGroup.SetSurface( PropData );
		}

		/// <summary>
		/// Fired when the entity gets damaged
		/// </summary>
		protected Output OnDamaged { get; set; }

		public override void TakeDamage( DamageInfo info )
		{
			base.TakeDamage( info );

			OnDamaged.Fire( this );
		}

		/// <summary>
		/// Wake up this physics object, if it is sleeping.
		/// </summary>
		[Input] protected void Wake() { PhysicsGroup.Wake(); }

		/// <summary>
		/// Wake up this physics object, if it is sleeping.
		/// </summary>
		[Input] protected void Sleep() { PhysicsGroup.Sleep(); }

		/// <summary>
		/// Enable motion (gravity, etc) on this entity
		/// </summary>
		[Input] protected void EnableMotion() { PhysicsBody.MotionEnabled = true; }

		/// <summary>
		/// Disable motion (gravity, etc) on this entity
		/// </summary>
		[Input] protected void DisableMotion() { PhysicsBody.MotionEnabled = false; }
	}
}
