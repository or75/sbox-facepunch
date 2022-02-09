using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandbox
{
	[Hammer.AutoApplyMaterial( "materials/tools/toolstrigger.vmat" )]
	[Hammer.Solid]
	[Hammer.VisGroup( Hammer.VisGroup.Trigger )]
	[Display( Name = "Base Trigger" ), Icon( "select_all" )]
	public partial class BaseTrigger : ModelEntity
	{
		[AdminCmd( "drawtriggers_toggle" )]
		public static void ToggleDrawTriggers()
		{
			foreach ( var trigger in All.OfType<BaseTrigger>() )
			{
				trigger.ToggleDebugBits( DebugOverlayBits.TriggerBounds );
			}
		}

		[Spawnflags( (int)Flags.Clients) ]
		public enum Flags
		{
			Clients = 1,
			Npcs = 2,
			Pushables = 4,
			PhysicsObjects = 8,
			AlliedNpcs = 16,
			ClientInVehicle = 32,
			Everything = 64,
			ClientNotInVehicle = 512,
			PhysicsDebris = 1024
		}

		/// <summary>
		/// Should this entity start disabled?
		/// </summary>
		[Property( Title = "Start Disabled" ) ]
		public bool StartDisabled { get; set; } = false;

		/// <summary>
		/// Entities with these tags can activate this trigger.
		/// </summary>
		[Property]
		public TagList ActvationTags { get; set; } = "player";

		public bool Enabled { get; protected set; }

		public IEnumerable<Entity> TouchingEntities => touchingEntities;
		public int TouchingEntityCount => touchingEntities.Count;
		readonly List<Entity> touchingEntities = new();

		// Used for when an entity enters the trigger while it is disabled, and then the trigger gets enabled
		readonly List<Entity> touchingEntitiesWhileDisabled = new();

		public override void Spawn()
		{
			base.Spawn();

			SetupPhysicsFromModel( PhysicsMotionType.Static );
			CollisionGroup = CollisionGroup.Trigger;
			EnableSolidCollisions = false;
			EnableTouch = true;
			Enabled = !StartDisabled;

			Transmit = TransmitType.Never;
		}

		public override void StartTouch( Entity other )
		{
			base.StartTouch( other );

			if ( other.IsWorld )
				return;

			AddToucher( other );
		}

		// This is to make sure we can add a toucher after they have entered the trigger but we were on a cooldown or something (trigger_multiple's wait param)
		public override void Touch( Entity other )
		{
			base.Touch( other );

			if ( other.IsWorld )
				return;

			AddToucher( other );
		}

		public override void EndTouch( Entity other )
		{
			base.EndTouch( other );

			if ( other.IsWorld )
				return;

			if ( touchingEntitiesWhileDisabled.Contains( other ) )
			{
				touchingEntitiesWhileDisabled.Remove( other );
			}
				
			if ( touchingEntities.Contains( other ) )
			{
				touchingEntities.Remove( other );
				OnTouchEnd( other );

				if ( touchingEntities.Count < 1 ) OnTouchEndAll( other );
			}
		}

		protected void AddToucher( Entity toucher )
		{
			if ( !toucher.IsValid() )
				return;

			if ( !Enabled )
			{
				// We don't care about the filter because we will pass these entities to StartTouch
				if ( !touchingEntitiesWhileDisabled.Contains( toucher ) )
				{
					touchingEntitiesWhileDisabled.Add( toucher );
				}
				
				return;
			}

			if ( touchingEntities.Contains( toucher ) )
				return;

			if ( !PassesTriggerFilters( toucher ) )
				return;

			bool anyoneTouching = touchingEntities.Count > 0;

			touchingEntities.Add( toucher );
			OnTouchStart( toucher );

			if ( !anyoneTouching ) OnTouchStartAll( toucher );
		}

		/// <summary>
		/// Fired when an entity starts touching this trigger. The touching entity must pass this trigger's filters to cause this output to fire.
		/// </summary>
		protected Output OnStartTouch { get; set; }

		/// <summary>
		/// Fired when an entity stops touching this trigger. Only entities that passed this trigger's filters will cause this output to fire.
		/// </summary>
		protected Output OnEndTouch { get; set; }

		/// <summary>
		/// Fired when an entity starts touching this trigger while no other passing entities are touching it.
		/// </summary>
		protected Output OnStartTouchAll { get; set; }

		/// <summary>
		/// Fired when all entities touching this trigger have stopped touching it.
		/// </summary>
		protected Output OnEndTouchAll { get; set; }

		/// <summary>
		/// Enables this trigger
		/// </summary>
		[Input]
		public void Enable()
		{
			Enabled = true;

			// Everything that is already inside the volume now just started touching us.
			foreach ( var entity in touchingEntitiesWhileDisabled.ToArray() )
			{
				StartTouch( entity );
			}
			touchingEntitiesWhileDisabled.Clear();
		}

		/// <summary>
		/// Disables this trigger
		/// </summary>
		[Input]
		public void Disable()
		{
			Enabled = false;

			// We are disabled, pretend all our touching entities stopped touching us.
			foreach ( var entity in TouchingEntities.ToList() )
			{
				if ( !entity.IsValid() )
					continue;

				EndTouch( entity );

				if ( !touchingEntitiesWhileDisabled.Contains( entity ) )
				{
					touchingEntitiesWhileDisabled.Add( entity );
				}
			}
		}

		/// <summary>
		/// Toggles this trigger between enabled and disabled states
		/// </summary>
		[Input]
		public void Toggle()
		{
			if ( Enabled )
			{
				Disable();
			}
			else
			{
				Enable();
			}
		}

		/// <summary>
		///	An entity that passes PassesTriggerFilters has started touching the trigger
		/// </summary>
		public virtual void OnTouchStart( Entity toucher )
		{
			OnStartTouch.Fire( toucher );
		}

		/// <summary>
		///	An entity that started touching this trigger has stopped touching
		/// </summary>
		public virtual void OnTouchEnd( Entity toucher )
		{
			OnEndTouch.Fire( toucher );
		}

		/// <summary>
		///	Called when an entity starts touching this trigger while no other passing entities are touching it
		/// </summary>
		public virtual void OnTouchStartAll( Entity toucher )
		{
			OnStartTouchAll.Fire( toucher );
		}

		/// <summary>
		///	Called when all entities touching this trigger have stopped touching it.
		/// </summary>
		public virtual void OnTouchEndAll( Entity toucher )
		{
			OnEndTouchAll.Fire( toucher );
		}

		/// <summary>
		///	Determine if an entity should be allowed to touch this trigger
		/// </summary>
		public virtual bool PassesTriggerFilters( Entity other )
		{
			if ( other is not ModelEntity modelEnt )
				return false;

			if ( other.Tags.HasAny( ActvationTags ) )
			{
				return true;
			}

			if ( SpawnFlags.Has( Flags.Clients ) )
			{
				if ( modelEnt.CollisionGroup == CollisionGroup.Player && modelEnt.LifeState == LifeState.Alive )
					return true;
			}

			if ( SpawnFlags.Has( Flags.Everything ) )
			{
				return true;
			}

			return false;
		}
	}
}
