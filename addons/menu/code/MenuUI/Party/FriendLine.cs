using Sandbox.UI;
using Sandbox;

namespace Party
{
	[UseTemplate]
	public class FriendLine : Button
	{
		public Friend Friend { get; set; }
		public Panel Avatar { get; set; }

		public FriendLine( Panel canvas, Friend friend )
		{
			Parent = canvas;
			Friend = friend;

			Avatar?.Style.SetBackgroundImage( $"avatar:{Friend.Id}" );
		}
	}
}
