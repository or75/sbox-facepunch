using System;

namespace Sandbox
{
	[Library( "water" )]
	[Hammer.Skip]
	
	public partial class Water : AnimEntity
	{
		public WaterController WaterController = new WaterController();
		public WaterSceneObject WaterSceneObject;

		/// <summary>
		/// Material to use for water
		/// </summary>
		[Property, ResourceType( "vmat" )]
		[Internal.DefaultValue( "materials/shadertest/test_water.vmat" )]
		[Net] public string WaterMaterial { get; set; }

		public Water()
		{
			WaterController.WaterEntity = this;

			EnableTouch = true;
			EnableTouchPersists = true;
		}

		public override void Touch( Entity other )
		{
			base.Touch( other );

			WaterController.Touch( other );
		}

		public override void EndTouch( Entity other )
		{
			base.EndTouch( other );

			WaterController.EndTouch( other );
		}

		public override void StartTouch( Entity other )
		{
			base.StartTouch( other );

			WaterController.StartTouch( other );
		}

		public override void ClientSpawn()
		{
			base.ClientSpawn();
			CreateWaterSceneObject();
		}

		void CreateWaterSceneObject()
		{
			// Assume no scene object if we didn't pass a material
			if( WaterMaterial is null || WaterMaterial.Length == 0 )
				return;

			WaterSceneObject = new WaterSceneObject( this, Material.Load( WaterMaterial ) )
			{
				Transform = this.Transform,
				RenderOverride = DoRender
			};
		}

		[Event.Frame]
		protected virtual void Think()
		{
			UpdateSceneObject( WaterSceneObject );
		}

		/// <summary>
		/// Keep the scene object updated. By default this moves the transform to match this entity's transform
		/// and updates the bounds to the new position.
		/// </summary>
		public virtual void UpdateSceneObject( SceneObject obj )
		{
			if ( WaterSceneObject == null ) 
				return;
				
			WaterSceneObject.Position = this.Position;
			WaterSceneObject.Transform = Transform;
			WaterSceneObject.Bounds = CollisionBounds + Position;
			
			WaterSceneObject.RenderBounds = CollisionBounds + Position;

			WaterSceneObject.Update();
		}

		public virtual void DoRender( SceneObject obj )
		{
			// Render.Draw Shit
		}
	}
}
