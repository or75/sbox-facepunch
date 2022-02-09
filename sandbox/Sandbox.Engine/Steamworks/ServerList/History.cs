using System;
using Steamworks.Data;

namespace Steamworks.ServerList
{
	// Token: 0x020000C6 RID: 198
	internal class History : Base
	{
		// Token: 0x06000759 RID: 1881 RVA: 0x0000C724 File Offset: 0x0000A924
		internal override void LaunchQuery()
		{
			MatchMakingKeyValuePair[] filters = this.GetFilters();
			this.request = Base.Internal.RequestHistoryServerList(base.AppId.Value, ref filters, (uint)filters.Length, IntPtr.Zero);
		}
	}
}
