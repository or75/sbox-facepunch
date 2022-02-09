using System;
using Steamworks.Data;

namespace Steamworks.ServerList
{
	// Token: 0x020000C5 RID: 197
	internal class Friends : Base
	{
		// Token: 0x06000757 RID: 1879 RVA: 0x0000C6DC File Offset: 0x0000A8DC
		internal override void LaunchQuery()
		{
			MatchMakingKeyValuePair[] filters = this.GetFilters();
			this.request = Base.Internal.RequestFriendsServerList(base.AppId.Value, ref filters, (uint)filters.Length, IntPtr.Zero);
		}
	}
}
