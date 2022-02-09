
namespace Sandbox
{
	public class FixedCamera : Camera
	{
		Vector3 TargetPos;
		Rotation TargetRot;

		public FixedCamera()
		{
			var player = Local.Client?.Pawn;
			if ( player != null )
			{
				Position = player.Position;
				TargetPos = Position;

				Rotation = player.Rotation;
				TargetRot = Rotation;
			}
		}

		public override void Update()
		{
			FieldOfView = 70;
			Position = TargetPos;
			Rotation = TargetRot;
			Viewer = null;
		}
	}
}
