namespace Sandbox
{
	/// <summary>
	/// Generic water volume. Make sure to have light probe volume envelop the volume of the water for the water to gain proper lighting.
	/// </summary>
	[Library( "func_water" )]
	[Hammer.Solid]
	[Hammer.SkipProperty( "enable_shadows" )]
	[Hammer.SkipProperty( "SetColor" )]
	public partial class WaterFunc : Water
	{
		public override void Spawn()
		{
			base.Spawn();

			Transmit = TransmitType.Always;

			CreatePhysics();
			EnableDrawing = false;
		}

		public override void ClientSpawn()
		{
			Host.AssertClient();
			base.ClientSpawn();

			CreatePhysics();
		}

		void CreatePhysics()
		{
			SetInteractsExclude( CollisionLayer.STATIC_LEVEL );

			var physicsGroup = SetupPhysicsFromModel( PhysicsMotionType.Keyframed, true );
			physicsGroup.SetSurface( "water" );

			ClearCollisionLayers();
			AddCollisionLayer( CollisionLayer.Water );
			AddCollisionLayer( CollisionLayer.Trigger );
			EnableSolidCollisions = false;
			EnableTouch = true;
			EnableTouchPersists = true;
		}
	}
}
