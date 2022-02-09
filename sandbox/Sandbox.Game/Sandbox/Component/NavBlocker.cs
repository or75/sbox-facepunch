using System;
using NativeEngine;

namespace Sandbox.Component
{
	/// <summary>
	/// A static nav blocker.
	/// </summary>
	// Token: 0x0200016E RID: 366
	[DisallowMultipleComponent]
	public sealed class NavBlocker : EntityComponent
	{
		// Token: 0x06001B6B RID: 7019 RVA: 0x0006E6DB File Offset: 0x0006C8DB
		public NavBlocker(NavBlockerType type)
		{
			this.navBlockerType = type;
		}

		// Token: 0x06001B6C RID: 7020 RVA: 0x0006E6EA File Offset: 0x0006C8EA
		public NavBlocker()
			: this(NavBlockerType.BLOCK)
		{
		}

		// Token: 0x06001B6D RID: 7021 RVA: 0x0006E6F3 File Offset: 0x0006C8F3
		protected override void OnActivate()
		{
			if (!this.native.IsNull || !Host.IsServer)
			{
				return;
			}
			this.native = NavObstacle.SBOX_Create(base.Entity.GetEntityIntPtr(), (int)this.navBlockerType, true, false);
		}

		// Token: 0x06001B6E RID: 7022 RVA: 0x0006E72D File Offset: 0x0006C92D
		protected override void OnDeactivate()
		{
			if (this.native.IsNull || !Host.IsServer)
			{
				return;
			}
			this.native.SBOX_Delete();
			this.native = IntPtr.Zero;
		}

		// Token: 0x04000783 RID: 1923
		private NavObstacle native;

		// Token: 0x04000784 RID: 1924
		private NavBlockerType navBlockerType;
	}
}
