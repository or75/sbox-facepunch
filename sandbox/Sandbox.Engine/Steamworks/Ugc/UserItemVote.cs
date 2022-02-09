using System;
using Steamworks.Data;

namespace Steamworks.Ugc
{
	// Token: 0x020000C2 RID: 194
	internal struct UserItemVote
	{
		// Token: 0x0600073B RID: 1851 RVA: 0x0000C2B4 File Offset: 0x0000A4B4
		internal static UserItemVote? From(GetUserItemVoteResult_t result)
		{
			return new UserItemVote?(new UserItemVote
			{
				VotedUp = result.VotedUp,
				VotedDown = result.VotedDown,
				VoteSkipped = result.VoteSkipped
			});
		}

		// Token: 0x04000971 RID: 2417
		internal bool VotedUp;

		// Token: 0x04000972 RID: 2418
		internal bool VotedDown;

		// Token: 0x04000973 RID: 2419
		internal bool VoteSkipped;
	}
}
