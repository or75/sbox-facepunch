
namespace Sandbox
{
	public static class DevCommands
	{
		// TODO: CheatCmd
		[AdminCmd]
		public static void setpos( float posX,  float posY, float posZ, float pitch = 0, float yaw = 0, float roll = 0 )
		{
			if ( ConsoleSystem.Caller == null )
			{
				Log.Warning( "setpos: This command can only be ran by a player" );
				return;
			}
			
			var ent = ConsoleSystem.Caller.Pawn;
			if ( ent == null )
			{
				Log.Warning( "setpos: Player is missing a Pawn entity" );
				return;
			}
			
			ent.Velocity = Vector3.Zero;
			ent.Position = new Vector3( posX, posY, posZ );
			ent.EyeRot = Rotation.From( pitch, yaw, roll );
			// TODO: Leave any vehicles? Check if stuck in world?
		}


		[AdminCmd]
		public static void setang( float pitch,  float yaw, float roll )
		{
			if ( ConsoleSystem.Caller == null )
			{
				Log.Warning( "setang: This command can only be ran by a player" );
				return;
			}

			if ( ConsoleSystem.Caller.Pawn == null )
			{
				Log.Warning( "setang: Player is missing a Pawn entity" );
				return;
			}
			
			ConsoleSystem.Caller.Pawn.EyeRot = Rotation.From( pitch, yaw, roll );
		}
		
		[ServerCmd]
		public static void getpos()
		{
			if ( ConsoleSystem.Caller == null )
			{
				Log.Warning( "getpos: This command can only be ran by a player" );
				return;
			}
			
			var ent = ConsoleSystem.Caller.Pawn;
			if ( ent == null )
			{
				Log.Warning( "getpos: Player is missing a Pawn entity" );
				return;
			}

			var ang = ent.EyeRot.Angles();
			var pos = ent.Position;

			Log.Info( $"setpos {pos.x:F2} {pos.y:F2} {pos.z:F2} {ang.pitch:F2} {ang.yaw:F2} {ang.roll:F2}" );
		}
	}
}
