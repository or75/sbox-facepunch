
namespace Sandbox
{
	/// <summary>
	/// A monitor that renders the view from a given point_camera entity.
	/// </summary>
	[Library( "func_monitor" )]
	public partial class FuncMonitor : BrushEntity
	{
		[Property( "Camera name" ), FGDType( "target_destination" )]
		public string CameraName { get; set; }

		[Net]
		public PointCamera TargetCamera { get; set; }

		[Net]
		private string ModelName { get; set; }

		private SceneMonitorObject so;

		public override void Spawn()
		{
			base.Spawn();

			TargetCamera = FindByName( CameraName ) as PointCamera;

			ModelName = GetModelName();
			SetModel( "" );
		}

		public override void ClientSpawn()
		{
			base.ClientSpawn();

			so = new SceneMonitorObject( Model.Load( ModelName ), Transform );
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			if ( so != null && so.IsValid )
			{
				so.Delete();
				so = null;
			}
		}

		[Event.Frame]
		protected void OnFrame()
		{
			if ( !IsClient )
				return;

			if ( so == null || !so.IsValid )
				return;

			so.Transform = Transform;

			if ( !TargetCamera.IsValid() )
				return;

			so.View.Position = TargetCamera.Position;
			so.View.Rotation = TargetCamera.Rotation;
			so.View.FieldOfView = TargetCamera.Fov;
			so.View.ZNear = TargetCamera.ZNear;
			so.View.ZFar = TargetCamera.ZFar;
			so.View.Aspect = TargetCamera.Aspect;
		}
	}
}
