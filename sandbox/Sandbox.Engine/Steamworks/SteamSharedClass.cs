using System;

namespace Steamworks
{
	// Token: 0x020000BC RID: 188
	internal class SteamSharedClass<T> : SteamClass
	{
		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000720 RID: 1824 RVA: 0x0000B76B File Offset: 0x0000996B
		internal static SteamInterface Interface
		{
			get
			{
				return SteamSharedClass<T>.InterfaceClient ?? SteamSharedClass<T>.InterfaceServer;
			}
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x0000B77B File Offset: 0x0000997B
		internal override void InitializeInterface(bool server)
		{
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x0000B77D File Offset: 0x0000997D
		internal virtual void SetInterface(bool server, SteamInterface iface)
		{
			if (server)
			{
				SteamSharedClass<T>.InterfaceServer = iface;
			}
			if (!server)
			{
				SteamSharedClass<T>.InterfaceClient = iface;
			}
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x0000B791 File Offset: 0x00009991
		internal override void DestroyInterface(bool server)
		{
			if (!server)
			{
				SteamSharedClass<T>.InterfaceClient = null;
			}
			if (server)
			{
				SteamSharedClass<T>.InterfaceServer = null;
			}
		}

		// Token: 0x04000969 RID: 2409
		internal static SteamInterface InterfaceClient;

		// Token: 0x0400096A RID: 2410
		internal static SteamInterface InterfaceServer;
	}
}
