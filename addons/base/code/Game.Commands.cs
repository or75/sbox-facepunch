using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
	public partial class Game
	{
		[ServerCmd( "kill", Help = "Kills the calling player with generic damage" )]
		public static void KillCommand()
		{
			var target = ConsoleSystem.Caller;
			if ( target == null ) return;

			(Current as Game)?.DoPlayerSuicide( target );
		}

		[ServerCmd( "noclip", Help = "Turns on noclip mode, which makes you non solid and lets you fly around" )]
		public static void NoclipCommand()
		{
			if ( ConsoleSystem.Caller == null ) return;

			(Current as Game)?.DoPlayerNoclip( ConsoleSystem.Caller );
		}


		[ServerCmd( "devcam", Help = "Enables the devcam. Input to the player will stop and you'll be able to freefly around." )]
		public static void DevcamCommand()
		{
			if ( ConsoleSystem.Caller == null ) return;

			(Current as Game)?.DoPlayerDevCam( ConsoleSystem.Caller );
		}

		[AdminCmd( "animgraph_preview", Help = "Set the preview entity animgraph will use" )]
		public static void AnimGraphPreviewCommand( string entityName )
		{
			var target = ConsoleSystem.Caller;
			if ( target == null ) return;

			if ( FindByName( entityName ) is AnimEntity animEntity )
			{
				animEntity.SetAnimGraphPreview();
				Log.Info( $"Set animgraph preview to \"{entityName}\"" );
			}
			else
			{
				Log.Warning( $"Unable to find anim entity \"{entityName}\"" );
			}
		}
	}
}
