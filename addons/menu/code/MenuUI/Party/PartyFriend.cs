
using Sandbox;
using Sandbox.UI;

namespace Party
{
	public class PartyFriend : Panel
	{
		public Friend Friend { get; set; }

		public PartyFriend( Friend friend, Panel parent )
		{
			Parent = parent;
			Friend = friend;

			AddClass( "tight avatar button" );

			Style.SetBackgroundImage( $"avatar:{friend.Id}" );

		}
	}
}
