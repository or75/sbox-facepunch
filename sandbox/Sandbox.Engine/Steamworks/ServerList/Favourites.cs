using System;
using Steamworks.Data;

namespace Steamworks.ServerList
{
	// Token: 0x020000C4 RID: 196
	internal class Favourites : Base
	{
		// Token: 0x06000755 RID: 1877 RVA: 0x0000C694 File Offset: 0x0000A894
		internal override void LaunchQuery()
		{
			MatchMakingKeyValuePair[] filters = this.GetFilters();
			this.request = Base.Internal.RequestFavoritesServerList(base.AppId.Value, ref filters, (uint)filters.Length, IntPtr.Zero);
		}
	}
}
