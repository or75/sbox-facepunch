using Sandbox.UI;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sandbox
{
	/// <summary>
	/// An entity that can be carried in the player's inventory and hands.
	/// </summary>
	[Display( Name = "Carriable" ), Icon( "luggage" )]
	public class BaseCarriable : AnimEntity
	{
		public virtual string ViewModelPath => null;
		public BaseViewModel ViewModelEntity { get; protected set; }

		public Panel CreateCrosshair() { return new StandardCrosshair(); }

		public Panel CrosshairPanel { get; protected set; }

		public override void Spawn()
		{
			base.Spawn();

			MoveType = MoveType.Physics;
			CollisionGroup = CollisionGroup.Interactive;
			PhysicsEnabled = true;
			UsePhysicsCollision = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;
		}

		public override bool CanCarry( Entity carrier )
		{
			return true;
		}

		public override void OnCarryStart( Entity carrier )
		{
			if ( IsClient ) return;

			SetParent( carrier, true );
			Owner = carrier;
			MoveType = MoveType.None;
			EnableAllCollisions = false;
			EnableDrawing = false;
		}

		public virtual void SimulateAnimator( PawnAnimator anim )
		{
			anim.SetParam( "holdtype", 1 );
			anim.SetParam( "aimat_weight", 1.0f );
			anim.SetParam( "holdtype_handedness", 0 );
		}

		public override void OnCarryDrop( Entity dropper )
		{
			if ( IsClient ) return;

			SetParent( null );
			Owner = null;
			MoveType = MoveType.Physics;
			EnableDrawing = true;
			EnableAllCollisions = true;
		}

		/// <summary>
		/// This entity has become the active entity. This most likely
		/// means a player was carrying it in their inventory and now
		/// has it in their hands.
		/// </summary>
		public override void ActiveStart( Entity ent )
		{
			base.ActiveStart( ent );

			EnableDrawing = true;

			if ( ent is Player player )
			{
				var animator = player.GetActiveAnimator();
				if ( animator != null )
				{
					SimulateAnimator( animator );
				}
			}

			//
			// If we're the local player (clientside) create viewmodel
			// and any HUD elements that this weapon wants
			//
			if ( IsLocalPawn )
			{
				DestroyViewModel();
				DestroyHudElements();

				CreateViewModel();
				CreateHudElements();

				ViewModelEntity?.SetAnimBool( "deploy", true );
			}
		}

		/// <summary>
		/// This entity has stopped being the active entity. This most
		/// likely means a player was holding it but has switched away
		/// or dropped it (in which case dropped = true)
		/// </summary>
		public override void ActiveEnd( Entity ent, bool dropped )
		{
			base.ActiveEnd( ent, dropped );

			//
			// If we're just holstering, then hide us
			//
			if ( !dropped )
			{
				EnableDrawing = false;
			}

			if ( IsClient )
			{
				DestroyViewModel();
				DestroyHudElements();
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			if ( IsClient && ViewModelEntity.IsValid() )
			{
				DestroyViewModel();
				DestroyHudElements();
			}
		}

		/// <summary>
		/// Create the viewmodel. You can override this in your base classes if you want
		/// to create a certain viewmodel entity.
		/// </summary>
		public virtual void CreateViewModel()
		{
			Host.AssertClient();

			if ( string.IsNullOrEmpty( ViewModelPath ) )
				return;

			ViewModelEntity = new BaseViewModel();
			ViewModelEntity.Position = Position;
			ViewModelEntity.Owner = Owner;
			ViewModelEntity.EnableViewmodelRendering = true;
			ViewModelEntity.SetModel( ViewModelPath );
		}

		/// <summary>
		/// We're done with the viewmodel - delete it
		/// </summary>
		public virtual void DestroyViewModel()
		{
			ViewModelEntity?.Delete();
			ViewModelEntity = null;
		}

		public virtual void CreateHudElements()
		{
			CrosshairPanel = CreateCrosshair();
			CrosshairCanvas.SetCrosshair( CrosshairPanel );
		}

		public virtual void DestroyHudElements()
		{
			CrosshairPanel?.Delete( true );
			CrosshairPanel = null;
		}

		/// <summary>
		/// Utility - return the entity we should be spawning particles from etc
		/// </summary>
		public virtual ModelEntity EffectEntity => ( ViewModelEntity.IsValid() && IsFirstPersonMode ) ? ViewModelEntity : this;

	}
}
