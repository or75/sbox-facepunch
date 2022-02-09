
using System.ComponentModel;

namespace Sandbox
{
	/// <summary>
	/// A generic brush/mesh that can toggle its visibilty and collisions, and can be broken.
	/// </summary>
    [Library( "func_brush" )]
	[Hammer.Solid]
	[Hammer.RenderFields]
	[Hammer.VisGroup( Hammer.VisGroup.Dynamic )]
	public partial class BrushEntity : ModelEntity
	{
		bool _enabled;

		/// <summary>
		/// Whether this func_brush is visible/active at all
		/// </summary>
		[Internal.DefaultValue( true )]
		[Property( "Enabled" )] public bool Enabled
		{
			get { return _enabled; }
			set
			{
				_enabled = value;
				CheckSolidityAndEnabled();
			}
		}

		bool _solid;

		/// <summary>
		/// Whether this func_brush has collisions
		/// </summary>
		[Internal.DefaultValue( true )]
		[Property( "Solid" )] public bool Solid
		{
			get { return _solid; }
			set
			{
				_solid = value;
				CheckSolidityAndEnabled();
			}
		}

		// TODO: Merge FuncPhysbox into this, and rename to ent_brush or smth? Mass override?
		// TODO: Add a "spawn this entity on break" option? Like guns and stuff from crates, etc
		// TODO: Explosion on break options?
		// TODO: Damage filters? Only break on input option?
		// TODO: Material type override?

		/// <summary>
		/// If set to above 0, the entity will have this much health on spawn and will be breakable.
		/// </summary>
		// TODO: Health is automatically applied somewhere in the engine from "health" keyvalue by name, causing HealthOverride to be not set!
		[Property( "health" ), DisplayName( "Health" )]
		public float HealthOverride { get; set; } = 0;

		public override void Spawn()
		{
			base.Spawn();

			SetupPhysicsFromModel( PhysicsMotionType.Static );
		}
		
#region Breakable

		/// <summary>
		/// Fired when the entity gets damaged, even if it is unbreakable.
		/// </summary>
		protected Output OnDamaged { get; set; }
		
		DamageInfo LastDamage;
		public override void TakeDamage( DamageInfo info )
		{
			// The door was damaged, even if its unbreakable, we still want to fire it
			// TODO: Add damage type as argument? Or should it be the new health value?
			OnDamaged.Fire( this );

			base.TakeDamage( info );

			LastDamage = info;
		}

		/// <summary>
		/// Fired when the entity gets destroyed.
		/// </summary>
		protected Output OnBreak { get; set; }

		public override void OnKilled()
		{
			if ( LifeState != LifeState.Alive )
				return;

			var result = new Breakables.Result();
			result.CopyParamsFrom( LastDamage );
			Breakables.Break( this, result );

			OnBreak.Fire( LastDamage.Attacker );
			
			base.OnKilled();
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

#endregion

		private void CheckSolidityAndEnabled()
		{
			if ( Solid && Enabled )
			{
				EnableAllCollisions = true;
			}
			else
			{
				EnableAllCollisions = false;
			}

			EnableDrawing = Enabled;
		}

		/// <summary>
		/// Make this func_brush non solid
		/// </summary>
		[Input] protected void DisableSolid() { Solid = false; }

		/// <summary>
		/// Make this func_brush solid
		/// </summary>
		[Input] protected void EnableSolid() { Solid = true; }

		/// <summary>
		/// Toggle solidity of this func_brush
		/// </summary>
		[Input] protected void ToggleSolid() { Solid = !Solid; }

		/// <summary>
		/// Enable this func_brush, making it visible
		/// </summary>
		[Input] protected void Enable() { Enabled = true; }

		/// <summary>
		/// Disable this func_brush, making it invisible and non solid
		/// </summary>
		[Input] protected void Disable() { Enabled = false; }

		/// <summary>
		/// Toggle this func_brush
		/// </summary>
		[Input] protected void Toggle() { Enabled = !Enabled; }
	}
}
