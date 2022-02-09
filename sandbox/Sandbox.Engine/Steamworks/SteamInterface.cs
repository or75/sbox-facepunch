using System;

namespace Steamworks
{
	// Token: 0x020000BA RID: 186
	internal abstract class SteamInterface
	{
		// Token: 0x06000714 RID: 1812 RVA: 0x0000B68F File Offset: 0x0000988F
		internal virtual IntPtr GetUserInterfacePointer()
		{
			return IntPtr.Zero;
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x0000B696 File Offset: 0x00009896
		internal virtual IntPtr GetServerInterfacePointer()
		{
			return IntPtr.Zero;
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x0000B69D File Offset: 0x0000989D
		internal virtual IntPtr GetGlobalInterfacePointer()
		{
			return IntPtr.Zero;
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x0000B6A4 File Offset: 0x000098A4
		public bool IsValid
		{
			get
			{
				return this.Self != IntPtr.Zero;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000718 RID: 1816 RVA: 0x0000B6B6 File Offset: 0x000098B6
		// (set) Token: 0x06000719 RID: 1817 RVA: 0x0000B6BE File Offset: 0x000098BE
		public bool IsServer { get; private set; }

		// Token: 0x0600071A RID: 1818 RVA: 0x0000B6C8 File Offset: 0x000098C8
		internal void SetupInterface(bool gameServer)
		{
			if (this.Self != IntPtr.Zero)
			{
				return;
			}
			this.IsServer = gameServer;
			this.SelfGlobal = this.GetGlobalInterfacePointer();
			this.Self = this.SelfGlobal;
			if (this.Self != IntPtr.Zero)
			{
				return;
			}
			if (gameServer)
			{
				this.SelfServer = this.GetServerInterfacePointer();
				this.Self = this.SelfServer;
				return;
			}
			this.SelfClient = this.GetUserInterfacePointer();
			this.Self = this.SelfClient;
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x0000B74E File Offset: 0x0000994E
		internal void ShutdownInterface()
		{
			this.Self = IntPtr.Zero;
		}

		// Token: 0x04000964 RID: 2404
		internal IntPtr Self;

		// Token: 0x04000965 RID: 2405
		internal IntPtr SelfGlobal;

		// Token: 0x04000966 RID: 2406
		internal IntPtr SelfServer;

		// Token: 0x04000967 RID: 2407
		internal IntPtr SelfClient;
	}
}
