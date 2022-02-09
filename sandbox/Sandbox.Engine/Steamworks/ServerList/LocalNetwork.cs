using System;

namespace Steamworks.ServerList
{
	// Token: 0x020000C9 RID: 201
	internal class LocalNetwork : Base
	{
		// Token: 0x06000761 RID: 1889 RVA: 0x0000C844 File Offset: 0x0000AA44
		internal override void LaunchQuery()
		{
			this.request = Base.Internal.RequestLANServerList(base.AppId.Value, IntPtr.Zero);
		}
	}
}
