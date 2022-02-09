
namespace Sandbox
{
	[Library( "ent_nav_blocker" )]
	[Hammer.AutoApplyMaterial( "materials/tools/toolsnavattribute.vmat" )]
	[Hammer.Solid]
	[Hammer.VisGroup( Hammer.VisGroup.Navigation )]
	[Hammer.EntityTool( "Nav Blocker", "Navigation" )]
	public partial class NavBlockerEntity : ModelEntity
	{
		/// <summary>
		/// Enabled state of this entity.
		/// </summary>
		[Property]
		public bool Enabled { get; protected set; } = true;

		public override void Spawn()
		{
			base.Spawn();

			SetupPhysicsFromModel( PhysicsMotionType.Static );

			EnableAllCollisions = false;
			Transmit = TransmitType.Never;

			if ( Enabled )
			{
				Enable();
			}
		}

		/// <summary>
		/// Enables this blocker.
		/// </summary>
		[Input]
		public void Enable()
		{
			Enabled = true;

			if ( Components.Get<Component.NavBlocker>( true ) != null ) return;

			// If you are looking here, take note that the blocker will not update as the entity moves.
			Components.Add( new Component.NavBlocker( NavBlockerType.BLOCK ) );
		}

		/// <summary>
		/// Disables this blocker.
		/// </summary>
		[Input]
		public void Disable()
		{
			Enabled = false;

			var comp = Components.Get<Component.NavBlocker>( true );
			if ( comp == null ) return;
			Components.Remove( comp );
		}
	}
}
