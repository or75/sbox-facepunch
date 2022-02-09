
namespace Sandbox
{
	/// <summary>
	/// Camera
	/// </summary>
	[Library( "point_camera" )]
	[Hammer.FrustumBoundless( "fov", "znear", "zfar" )]
	[Hammer.EditorModel( "models/editor/camera.vmdl" )]
	public partial class PointCamera : Entity
	{
		/// <summary>
		/// Field of view in degrees
		/// </summary>
		[Property] public float Fov { get; set; } = 90.0f;

		/// <summary>
		/// Distance to the near plane
		/// </summary>
		[Property] public float ZNear { get; set; } = 4.0f;

		/// <summary>
		/// Distance to the far plane
		/// </summary>
		[Property] public float ZFar { get; set; } = 10000.0f;

		/// <summary>
		/// Aspect ratio
		/// </summary>
		[Property] public float Aspect { get; set; } = 1.0f;

		public PointCamera() : base()
		{
			Transmit = TransmitType.Always;
		}
	}
}
