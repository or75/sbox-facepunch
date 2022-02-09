using System;

namespace Sandbox.Component
{
	/// <summary>
	/// A component for controlling the "glow" outline on a entity
	///
	/// TODO: Wouldn't it be nice if this didn't even touch any engine stuff
	/// and we could create the scene object or whatever ourselves in a controlled
	/// and cleaned up way?
	///
	/// </summary>
	// Token: 0x0200016D RID: 365
	public sealed class Glow : EntityComponent<ModelEntity>
	{
		/// <summary>
		/// The colour of the glow
		/// </summary>
		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x06001B62 RID: 7010 RVA: 0x0006E5E9 File Offset: 0x0006C7E9
		// (set) Token: 0x06001B63 RID: 7011 RVA: 0x0006E600 File Offset: 0x0006C800
		public Color Color
		{
			get
			{
				return base.Entity.glowProperty.GetGlowColorOverride();
			}
			set
			{
				base.Entity.glowProperty.SetGlowColorOverride(value);
			}
		}

		/// <summary>
		/// Gets or set if the glow is active on the object.
		/// </summary>
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06001B64 RID: 7012 RVA: 0x0006E618 File Offset: 0x0006C818
		// (set) Token: 0x06001B65 RID: 7013 RVA: 0x0006E62C File Offset: 0x0006C82C
		public bool Active
		{
			get
			{
				return base.Entity.glowProperty.IsGlowing();
			}
			set
			{
				if (value == this.Active)
				{
					return;
				}
				if (value)
				{
					base.Entity.glowProperty.StartGlowing();
					base.Entity.glowProperty.SetGlowState(3);
					return;
				}
				base.Entity.glowProperty.StopGlowing();
				base.Entity.glowProperty.SetGlowState(0);
			}
		}

		/// <summary>
		/// The minimum distance that this object will start glowing.
		/// </summary>
		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06001B66 RID: 7014 RVA: 0x0006E689 File Offset: 0x0006C889
		// (set) Token: 0x06001B67 RID: 7015 RVA: 0x0006E69B File Offset: 0x0006C89B
		public int RangeMin
		{
			get
			{
				return base.Entity.glowProperty.GetGlowRangeMin();
			}
			set
			{
				base.Entity.glowProperty.SetGlowRangeMin(value);
			}
		}

		/// <summary>
		/// The maximum distance that this object will glow.
		/// </summary>
		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06001B68 RID: 7016 RVA: 0x0006E6AE File Offset: 0x0006C8AE
		// (set) Token: 0x06001B69 RID: 7017 RVA: 0x0006E6C0 File Offset: 0x0006C8C0
		public int RangeMax
		{
			get
			{
				return base.Entity.glowProperty.GetGlowRange();
			}
			set
			{
				base.Entity.glowProperty.SetGlowRange(value);
			}
		}
	}
}
