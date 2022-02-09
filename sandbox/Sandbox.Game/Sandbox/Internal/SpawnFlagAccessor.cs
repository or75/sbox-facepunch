using System;

namespace Sandbox.Internal
{
	// Token: 0x02000175 RID: 373
	public readonly struct SpawnFlagAccessor
	{
		// Token: 0x06001B92 RID: 7058 RVA: 0x0006EF63 File Offset: 0x0006D163
		internal SpawnFlagAccessor(Entity owner)
		{
			this.Owner = owner;
		}

		/// <summary>
		/// Return true if entity has this spawngflag
		/// </summary>
		// Token: 0x06001B93 RID: 7059 RVA: 0x0006EF6C File Offset: 0x0006D16C
		public bool Has<T>(T flag) where T : Enum
		{
			if (this.Owner.clientEnt.IsValid)
			{
				return this.Owner.clientEnt.HasSpawnFlags(Convert.ToInt32(flag));
			}
			return this.Owner.serverEnt.IsValid && this.Owner.serverEnt.HasSpawnFlags(Convert.ToInt32(flag));
		}

		// Token: 0x06001B94 RID: 7060 RVA: 0x0006EFD8 File Offset: 0x0006D1D8
		public void Add<T>(T flag) where T : Enum
		{
			if (this.Owner.clientEnt.IsValid)
			{
				this.Owner.clientEnt.AddSpawnFlags(Convert.ToInt32(flag));
				return;
			}
			if (this.Owner.serverEnt.IsValid)
			{
				this.Owner.serverEnt.AddSpawnFlags(Convert.ToInt32(flag));
				return;
			}
		}

		// Token: 0x0400078B RID: 1931
		private readonly Entity Owner;
	}
}
