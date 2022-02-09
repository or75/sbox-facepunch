using System;

namespace Steamworks
{
	// Token: 0x020000BD RID: 189
	internal class SteamClientClass<T> : SteamClass
	{
		// Token: 0x06000725 RID: 1829 RVA: 0x0000B7AD File Offset: 0x000099AD
		internal override void InitializeInterface(bool server)
		{
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x0000B7AF File Offset: 0x000099AF
		internal virtual void SetInterface(bool server, SteamInterface iface)
		{
			if (server)
			{
				throw new NotSupportedException();
			}
			SteamClientClass<T>.Interface = iface;
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x0000B7C0 File Offset: 0x000099C0
		internal override void DestroyInterface(bool server)
		{
			SteamClientClass<T>.Interface = null;
		}

		// Token: 0x0400096B RID: 2411
		internal static SteamInterface Interface;
	}
}
