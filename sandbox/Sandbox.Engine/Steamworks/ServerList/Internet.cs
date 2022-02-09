using System;
using Steamworks.Data;

namespace Steamworks.ServerList
{
	// Token: 0x020000C7 RID: 199
	internal class Internet : Base
	{
		// Token: 0x0600075B RID: 1883 RVA: 0x0000C76C File Offset: 0x0000A96C
		internal override void LaunchQuery()
		{
			MatchMakingKeyValuePair[] filters = this.GetFilters();
			this.request = Base.Internal.RequestInternetServerList(base.AppId.Value, ref filters, (uint)filters.Length, IntPtr.Zero);
		}
	}
}
