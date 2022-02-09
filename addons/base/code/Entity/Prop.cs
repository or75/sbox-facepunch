using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Sandbox
{
	/// <summary>
	/// A prop that physically simulates as a single rigid body. It can be constrained to other physics objects using hinges
	/// or other constraints. It can also be configured to break when it takes enough damage.
	/// Note that the health of the object will be overridden by the health inside the model, to ensure consistent health game-wide.
	/// If the model used by the prop is configured to be used as a prop_dynamic (i.e. it should not be physically simulated) then it CANNOT be
	/// used as a prop_physics. Upon level load it will display a warning in the console and remove itself. Use a prop_dynamic instead.
	/// </summary>
	[Library( "prop_physics" )]
	[Hammer.Model]
	[Hammer.RenderFields]
	[Hammer.VisGroup( Hammer.VisGroup.Physics )]
	[Display( Name = "Prop" ), Icon( "chair" )]
	public partial class Prop : BasePhysics
	{
		protected enum PropCollisionGroups
		{
			UNUSED = -1,
			COLLISION_GROUP_ALWAYS = CollisionGroup.Always,
			COLLISION_GROUP_NONPHYSICAL = CollisionGroup.Never,
			COLLISION_GROUP_DEFAULT = CollisionGroup.Default,
			COLLISION_GROUP_DEBRIS = CollisionGroup.Debris,
			COLLISION_GROUP_WEAPON = CollisionGroup.Weapon,
		};

		[Property]
		protected PropCollisionGroups CollisionGroupOverride { get; set; } = PropCollisionGroups.UNUSED;

		/// <summary>
		/// If set, the prop will spawn with motion disabled and will act as a nav blocker until broken.
		/// </summary>
		[Property]
		public bool Static { get; set; } = false;

		public override void Spawn()
		{
			base.Spawn();

			MoveType = MoveType.Physics;
			CollisionGroup = CollisionGroup.Interactive;
			PhysicsEnabled = true;
			UsePhysicsCollision = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			if ( CollisionGroupOverride != PropCollisionGroups.UNUSED )
			{
				CollisionGroup = (CollisionGroup)CollisionGroupOverride;

				if ( CollisionGroupOverride == PropCollisionGroups.COLLISION_GROUP_DEBRIS || CollisionGroupOverride == PropCollisionGroups.COLLISION_GROUP_WEAPON )
				{
					SetInteractsAs( CollisionLayer.Debris );
				}
			}

			if ( Static )
			{
				PhysicsEnabled = false;
				Components.Add( new Component.NavBlocker() );
			}
		}

		public override void ClientSpawn()
		{
			base.ClientSpawn();

			SpawnParticles();
		}

		private void SpawnParticles()
		{
			if ( Model == null || Model.IsError )
				return;

			var particleList = Model.GetParticles();
			if ( particleList == null || particleList.Length <= 0 )
				return;

			foreach ( var particleData in particleList )
			{
				var part = Particles.Create( particleData.Name );
				part.SetEntityAttachment( 0, this, particleData.AttachmentPoint, particleData.AttachmentOffset, particleData.AttachmentType );
			}
		}

		public override void OnNewModel( Model model )
		{
			base.OnNewModel( model );

			// When a model is reloaded, all entities get set to NULL model first
			if ( model.IsError ) return;

			if ( IsServer )
			{
				UpdatePropData( model );
			}
		}

		protected virtual void UpdatePropData( Model model )
		{
			Host.AssertServer();

			if ( model.TryGetData( out ModelPropData propInfo ) )
			{
				Health = propInfo.Health;
			}

			//
			// If health is unset, set it to -1 - which means it cannot be destroyed
			//
			if ( Health <= 0 )
				Health = -1;
		}

		DamageInfo LastDamage;

		/// <summary>
		/// Fired when the entity gets damaged.
		/// </summary>
		protected Output OnDamaged { get; set; }

		/// <summary>
		/// This prop won't be able to be damaged for this amount of time
		/// </summary>
		public RealTimeUntil Invulnerable { get; set; }

		public override void TakeDamage( DamageInfo info )
		{
			if ( Invulnerable > 0 )
			{
				// We still want to apply forces
				ApplyDamageForces( info );

				return;
			}

			LastDamage = info;

			base.TakeDamage( info );
			
			// TODO: Add damage type as argument? Or should it be the new health value?
			OnDamaged.Fire( this );
		}

		public override void OnKilled()
		{
			if ( LifeState != LifeState.Alive )
				return;

			LifeState = LifeState.Dead;

			if ( LastDamage.Flags.HasFlag( DamageFlags.PhysicsImpact ) )
			{
				Velocity = lastCollision.PreVelocity;
			}

			if ( HasExplosionBehavior() )
			{
				if ( LastDamage.Flags.HasFlag( DamageFlags.Blast ) )
				{
					LifeState = LifeState.Dying;

					// Don't explode right away and cause a stack overflow
					var rand = new Random();
					_ = ExplodeAsync( RandomExtension.Float( rand, 0.05f, 0.25f ) );

					return;
				}
				else
				{
					DoGibs();
					DoExplosion();
					Delete(); // LifeState.Dead prevents this in OnKilled
				}
			}
			else
			{
				DoGibs();
				Delete(); // LifeState.Dead prevents this in OnKilled
			}

			base.OnKilled();
		}

		CollisionEventData lastCollision;

		protected override void OnPhysicsCollision( CollisionEventData eventData )
		{
			lastCollision = eventData;

			base.OnPhysicsCollision( eventData );
		}

		private bool HasExplosionBehavior()
		{
			if ( Model == null || Model.IsError )
				return false;

			return Model.HasExplosionBehavior();
		}

		/// <summary>
		/// Fired when the entity gets destroyed.
		/// </summary>
		protected Output OnBreak { get; set; }

		private void DoGibs()
		{
			var result = new Breakables.Result();
			result.CopyParamsFrom( LastDamage );
			Breakables.Break( this, result );

			// This applies forces from explosive damage to our gibs... But this is already done by DoExplosion, we just need to make sure its called after spawning gibs.
			/*if ( LastDamage.Flags.HasFlag( DamageFlags.Blast ) )
			{
				foreach ( var prop in result.Props )
				{
					if ( !prop.IsValid() )
						continue;

					var body = prop.PhysicsBody;
					if ( !body.IsValid() )
						continue;

					body.ApplyImpulseAt( LastDamage.Position, LastDamage.Force * 25.0f );
				}
			}*/

			OnBreak.Fire( LastDamage.Attacker );
		}

		public async Task ExplodeAsync( float fTime )
		{
			if ( LifeState != LifeState.Alive && LifeState != LifeState.Dying )
				return;

			LifeState = LifeState.Dead;

			await Task.DelaySeconds( fTime );

			DoGibs();
			DoExplosion();

			Delete();
		}

		private void DoExplosion()
		{
			if ( Model == null || Model.IsError )
				return;

			if ( !Model.HasExplosionBehavior() )
				return;

			var srcPos = Position;
			if ( PhysicsBody.IsValid() ) srcPos = PhysicsBody.MassCenter;

			var explosionBehavior = Model.GetExplosionBehavior();

			// Damage and push away all other entities
			if ( explosionBehavior.Radius > 0.0f )
			{
				new ExplosionEntity
				{
					Position = srcPos,
					Radius = explosionBehavior.Radius,
					Damage = explosionBehavior.Damage,
					ForceScale = explosionBehavior.Force,
					ParticleOverride = explosionBehavior.Effect,
					SoundOverride = explosionBehavior.Sound
				}.Explode( this );
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			Unweld( true );
		}

		[Event.Physics.PostStep]
		public void OnPostPhysicsStep()
		{
			if ( !this.IsValid() )
				return;

			Liquid?.Update();
		}

		/// <summary>
		/// Causes this prop to break, regardless if it is actually breakable or not. (i.e. ignores health and whether the model has gibs)
		/// </summary>
		[Input]
		public void Break()
		{
			OnKilled();
			LifeState = LifeState.Dead;
			Delete();
		}
	}
}
