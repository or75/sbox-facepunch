﻿
namespace Sandbox.UI
{
	public class WorldPanel : RootPanel
	{
		public PanelSceneObject SceneObject { get; private set; }

		public Transform Transform
		{
			get => SceneObject.Transform;
			set => SceneObject.Transform = value;
		}

		public Vector3 Position
		{
			get => Transform.Position;
			set => Transform = Transform.WithPosition( value );
		}

		public Rotation Rotation
		{
			get => Transform.Rotation;
			set => Transform = Transform.WithRotation( value );
		}

		public float WorldScale
		{
			get => Transform.Scale;
			set => Transform = Transform.WithScale( value );
		}

		public float MaxInteractionDistance { get; set; }

		public WorldPanel()
		{
			SceneObject = new PanelSceneObject( this );
			SceneObject.Flags.IsOpaque = false;
			SceneObject.Flags.IsTranslucent = true;

			// Don't render this panel using the panel system
			RenderedManually = true;

			// Default size is 1000x1000, centered on scene object transform
			PanelBounds = new Rect( -500, -500, 1000, 1000 );

			// World panels are scaled down to world units,
			// so boost the panel scale to sensible default
			Scale = 2.0f;

			MaxInteractionDistance = 1000.0f;
		}

		/// <summary>
		/// Update the bounds for this panel. We purposely do nothing here because
		/// on world panels you can change the bounds by setting PanelBounds.
		/// </summary>
		protected override void UpdateBounds( Rect rect )
		{
			var right = Rotation.Right;
			var down = Rotation.Down;

			var panelBounds = PanelBounds * PanelSceneObject.ScreenToWorldScale;

			//
			// Work out the bounds by adding each corner to a bbox
			//
			var bounds = new BBox(		right * panelBounds.left +	down * panelBounds.top );
			bounds = bounds.AddPoint(	right * panelBounds.left +	down * panelBounds.bottom );
			bounds = bounds.AddPoint(	right * panelBounds.right + down * panelBounds.top );
			bounds = bounds.AddPoint(	right * panelBounds.right + down * panelBounds.bottom );

			SceneObject.Bounds = bounds + Position;
		}

		/// <summary>
		/// We override this to prevent the scale automatically being set based on screen
		/// size changing.. because that's obviously not needed here.
		/// </summary>
		protected override void UpdateScale( Rect screenSize )
		{

		}

		public override void Delete( bool immediate = false )
		{
			base.Delete( immediate );
		}

		public override void OnDeleted()
		{
			base.OnDeleted();

			SceneObject?.Delete();
			SceneObject = null;
		}

		public override bool RayToLocalPosition( Ray ray, out Vector2 position, out float distance )
		{
			position = default;
			distance = 0;

			var plane = new Plane( Position, Rotation.Forward );
			var pos = plane.Trace( ray, false, MaxInteractionDistance );

			if ( !pos.HasValue )
				return false;

			distance = Vector3.DistanceBetween( pos.Value, ray.Origin );
			if ( distance < 1 )
				return false;

			// to local coords
			var localPos3 = Transform.PointToLocal( pos.Value );
			var localPos = new Vector2( localPos3.y, -localPos3.z );

			// convert to screen coords
			localPos *= (1.0f / PanelSceneObject.ScreenToWorldScale / WorldScale);

			if ( !IsInside( localPos ) )
				return false;

			position = localPos;

			return true;
		}
	}
}
