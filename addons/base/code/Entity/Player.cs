using Sandbox.UI;
using System.ComponentModel.DataAnnotations;

namespace Sandbox
{
	/// <summary>
	/// This is what you should derive your player from. This base exists in addon code
	/// so we can take advantage of codegen for replication. The side effect is that we
	/// can put stuff in here that we don't need to access from the engine - which gives
	/// more transparency to our code.
	/// </summary>
	[Display( Name = "Player" ), Icon( "emoji_people" )]
	public partial class Player : AnimEntity
	{
		/// <summary>
		/// The PlayerController takes player input and moves the player. This needs
		/// to match between client and server. The client moves the local player and
		/// then checks that when the server moves the player, everything is the same.
		/// This is called prediction. If it doesn't match the player resets everything
		/// to what the server did, that's a prediction error.
		/// You should really never manually set this on the client - it's replicated so
		/// that setting the class on the server will automatically network and set it
		/// on the client.
		/// </summary>
		[Net, Predicted]
		public PawnController Controller { get; set; }

		/// <summary>
		/// This is used for noclip mode
		/// </summary>
		[Net, Predicted]
		public PawnController DevController { get; set; }

		/// <summary>
		/// Return the controller to use. Remember any logic you use here needs to match
		/// on both client and server. This is called as an accessor every tick.. so maybe
		/// avoid creating new classes here or you're gonna be making a ton of garbage!
		/// </summary>
		public virtual PawnController GetActiveController()
		{
			if ( DevController != null ) return DevController;

			return Controller;
		}


		/// <summary>
		/// The player animator is responsible for positioning/rotating the player and
		/// interacting with the animation graph.
		/// </summary>
		[Net, Predicted]
		public PawnAnimator Animator { get; set; }

		/// <summary>
		/// Return the controller to use. Remember any logic you use here needs to match
		/// on both client and server. This is called as an accessor every tick.. so maybe
		/// avoid creating new classes here or you're gonna be making a ton of garbage!
		/// </summary>
		public virtual PawnAnimator GetActiveAnimator() => Animator;


		TimeSince timeSinceDied;

		/// <summary>
		/// Called every tick to simulate the player. This is called on the
		/// client as well as the server (for prediction). So be careful!
		/// </summary>
		public override void Simulate( Client cl )
		{
			if ( LifeState == LifeState.Dead )
			{
				if ( timeSinceDied > 3 && IsServer )
				{
					Respawn();
				}

				return;
			}

			//UpdatePhysicsHull();

			var controller = GetActiveController();
			controller?.Simulate( cl, this, GetActiveAnimator() );
		}


		public override void FrameSimulate( Client cl )
		{
			base.FrameSimulate( cl );

			var controller = GetActiveController();
			controller?.FrameSimulate( cl, this, GetActiveAnimator() );
		}

		public override void Spawn()
		{
			EnableLagCompensation = true;

			base.Spawn();
		}

		/// <summary>
		/// Called once the player's health reaches 0
		/// </summary>
		public override void OnKilled()
		{
			Game.Current?.OnKilled( this );

			timeSinceDied = 0;
			LifeState = LifeState.Dead;
			StopUsing();

			Client?.AddInt( "deaths", 1 );
		}


		/// <summary>
		/// Sets LifeState to Alive, Health to Max, nulls velocity, and calls Gamemode.PlayerRespawn
		/// </summary>
		public virtual void Respawn()
		{
			Host.AssertServer();

			LifeState = LifeState.Alive;
			Health = 100;
			Velocity = Vector3.Zero;
			WaterLevel.Clear();

			CreateHull();

			Game.Current?.MoveToSpawnpoint( this );
			ResetInterpolation();
		}

		/// <summary>
		/// Create a physics hull for this player. The hull stops physics objects and players passing through
		/// the player. It's basically a big solid box. It also what hits triggers and stuff.
		/// The player doesn't use this hull for its movement size.
		/// </summary>
		public virtual void CreateHull()
		{
			CollisionGroup = CollisionGroup.Player;
			AddCollisionLayer( CollisionLayer.Player );
			SetupPhysicsFromAABB( PhysicsMotionType.Keyframed, new Vector3( -16, -16, 0 ), new Vector3( 16, 16, 72 ) );

			//var capsule = new Capsule( new Vector3( 0, 0, 16 ), new Vector3( 0, 0, 72 - 16 ), 32 );
			//var phys = SetupPhysicsFromCapsule( PhysicsMotionType.Keyframed, capsule );


			//	phys.GetBody(0).RemoveShadowController();

			// TODO - investigate this? if we don't set movetype then the lerp is too much. Can we control lerp amount?
			// if so we should expose that instead, that would be awesome.
			MoveType = MoveType.MOVETYPE_WALK;
			EnableHitboxes = true;
		}

		/// <summary>
		/// Called from the gamemode, clientside only.
		/// </summary>
		public override void BuildInput( InputBuilder input )
		{
			if ( input.StopProcessing )
				return;

			ActiveChild?.BuildInput( input );

			GetActiveController()?.BuildInput( input );

			if ( input.StopProcessing )
				return;

			GetActiveAnimator()?.BuildInput( input );
		}

		/// <summary>
		/// A generic corpse entity
		/// </summary>
		public Entity Corpse { get; set; }


		/// <summary>
		/// Called after the camera setup logic has run. Allow the player to
		/// do stuff to the camera, or using the camera. Such as positioning entities
		/// relative to it, like viewmodels etc.
		/// </summary>
		public override void PostCameraSetup( ref CameraSetup setup )
		{
			Host.AssertClient();

			if ( ActiveChild != null )
			{
				ActiveChild.PostCameraSetup( ref setup );
			}
		}


		TimeSince timeSinceLastFootstep = 0;

		/// <summary>
		/// A foostep has arrived!
		/// </summary>
		public override void OnAnimEventFootstep( Vector3 pos, int foot, float volume )
		{
			if ( LifeState != LifeState.Alive )
				return;

			if ( !IsClient )
				return;

			if ( timeSinceLastFootstep < 0.2f )
				return;

			volume *= FootstepVolume();

			timeSinceLastFootstep = 0;

			//DebugOverlay.Box( 1, pos, -1, 1, Color.Red );
			//DebugOverlay.Text( pos, $"{volume}", Color.White, 5 );

			var tr = Trace.Ray( pos, pos + Vector3.Down * 20 )
				.Radius( 1 )
				.Ignore( this )
				.Run();

			if ( !tr.Hit ) return;

			tr.Surface.DoFootstep( this, tr, foot, volume );
		}

		public virtual float FootstepVolume()
		{
			return Velocity.WithZ( 0 ).Length.LerpInverse( 0.0f, 200.0f ) * 0.2f;
		}

		public override void StartTouch( Entity other )
		{
			if ( IsClient ) return;

			if ( other is PickupTrigger )
			{
				StartTouch( other.Parent );
				return;
			}

			Inventory?.Add( other, Inventory.Active == null );
		}

		/// <summary>
		/// This isn't networked, but it's predicted. If it wasn't then when the prediction system
		/// re-ran the commands LastActiveChild would be the value set in a future tick, so ActiveEnd
		/// and ActiveStart would get called mulitple times and out of order, causing all kinds of pain.
		/// </summary>
		[Predicted]
		Entity LastActiveChild { get; set; }

		/// <summary>
		/// Simulated the active child. This is important because it calls ActiveEnd and ActiveStart.
		/// If you don't call these things, viewmodels and stuff won't work, because the entity won't
		/// know it's become the active entity.
		/// </summary>
		public virtual void SimulateActiveChild( Client cl, Entity child )
		{
			if ( LastActiveChild != child )
			{
				OnActiveChildChanged( LastActiveChild, child );
				LastActiveChild = child;
			}

			if ( !LastActiveChild.IsValid() )
				return;

			if ( LastActiveChild.IsAuthority )
			{
				LastActiveChild.Simulate( cl );
			}
		}

		/// <summary>
		/// Called when the Active child is detected to have changed
		/// </summary>
		public virtual void OnActiveChildChanged( Entity previous, Entity next )
		{
			previous?.ActiveEnd( this, previous.Owner != this );
			next?.ActiveStart( this );
		}

		public override void TakeDamage( DamageInfo info )
		{
			if ( LifeState == LifeState.Dead )
				return;

			base.TakeDamage( info );

			this.ProceduralHitReaction( info );

			//
			// Add a score to the killer
			//
			if ( LifeState == LifeState.Dead && info.Attacker != null )
			{
				if ( info.Attacker.Client != null )
				{
					info.Attacker.Client.AddInt( "kills" );
				}
			}
		}
	}
}
