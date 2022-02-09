using System;

namespace Sandbox.Internal
{
	// Token: 0x02000172 RID: 370
	public struct WaterLevel
	{
		// Token: 0x06001B88 RID: 7048 RVA: 0x0006ED25 File Offset: 0x0006CF25
		internal WaterLevel(Entity owner)
		{
			this = default(WaterLevel);
			this.owner = owner;
		}

		// Token: 0x06001B89 RID: 7049 RVA: 0x0006ED35 File Offset: 0x0006CF35
		public void Clear()
		{
			this.Fraction = 0f;
			this.Entity = null;
		}

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06001B8A RID: 7050 RVA: 0x0006ED4C File Offset: 0x0006CF4C
		// (set) Token: 0x06001B8B RID: 7051 RVA: 0x0006EDB4 File Offset: 0x0006CFB4
		public float Fraction
		{
			get
			{
				if (this.owner.clientEnt.IsValid)
				{
					return (float)this.owner.clientEnt.m_WaterLevel / 255f;
				}
				if (this.owner.serverEnt.IsValid)
				{
					return (float)this.owner.serverEnt.m_WaterLevel / 255f;
				}
				return 0f;
			}
			set
			{
				if (this.owner.clientEnt.IsValid)
				{
					this.owner.clientEnt.m_WaterLevel = (byte)(value * 255f);
				}
				if (this.owner.serverEnt.IsValid)
				{
					this.owner.serverEnt.m_WaterLevel = (byte)(value * 255f);
				}
			}
		}

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06001B8C RID: 7052 RVA: 0x0006EE18 File Offset: 0x0006D018
		// (set) Token: 0x06001B8D RID: 7053 RVA: 0x0006EE6C File Offset: 0x0006D06C
		public Entity Entity
		{
			get
			{
				if (this.owner.clientEnt.IsValid)
				{
					return this.owner.clientEnt.GetWaterEntity();
				}
				if (this.owner.serverEnt.IsValid)
				{
					return this.owner.serverEnt.GetWaterEntity();
				}
				return null;
			}
			set
			{
				if (this.owner.clientEnt.IsValid)
				{
					this.owner.clientEnt.SetWaterEntity((value != null) ? value.GetEntityIntPtr() : IntPtr.Zero);
				}
				if (this.owner.serverEnt.IsValid)
				{
					this.owner.serverEnt.SetWaterEntity((value != null) ? value.GetEntityIntPtr() : IntPtr.Zero);
				}
			}
		}

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06001B8E RID: 7054 RVA: 0x0006EEE7 File Offset: 0x0006D0E7
		public bool IsInWater
		{
			get
			{
				return this.Fraction > 0f;
			}
		}

		// Token: 0x04000788 RID: 1928
		private Entity owner;

		// Token: 0x04000789 RID: 1929
		public Vector3 WaterSurface;
	}
}
