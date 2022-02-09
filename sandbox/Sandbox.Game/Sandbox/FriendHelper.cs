using System;
using Steamworks;

namespace Sandbox
{
	// Token: 0x020000BC RID: 188
	internal static class FriendHelper
	{
		// Token: 0x060011AE RID: 4526 RVA: 0x0004B0FC File Offset: 0x000492FC
		public static Friend ToSandbox(this Friend friend)
		{
			return new Friend(friend);
		}
	}
}
