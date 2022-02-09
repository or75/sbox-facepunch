using System;

namespace Sandbox.UI
{
	// Token: 0x02000136 RID: 310
	[Hotload.SkipAttribute]
	public struct Shadow
	{
		// Token: 0x06001883 RID: 6275 RVA: 0x000643B0 File Offset: 0x000625B0
		public Shadow Scale(float f)
		{
			Shadow s = this;
			s.OffsetX *= f;
			s.OffsetY *= f;
			s.Blur *= f;
			s.Spread *= f;
			return s;
		}

		// Token: 0x06001884 RID: 6276 RVA: 0x000643F8 File Offset: 0x000625F8
		public Shadow LerpTo(Shadow shadow, float delta)
		{
			return new Shadow
			{
				OffsetX = this.OffsetX.LerpTo(shadow.OffsetX, delta, false),
				OffsetY = this.OffsetY.LerpTo(shadow.OffsetY, delta, false),
				Blur = this.Blur.LerpTo(shadow.Blur, delta, false),
				Spread = this.Spread.LerpTo(shadow.Spread, delta, false),
				Color = Color.Lerp(this.Color, shadow.Color, delta, true)
			};
		}

		// Token: 0x06001885 RID: 6277 RVA: 0x00064490 File Offset: 0x00062690
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float, float, Color>(this.OffsetX, this.OffsetY, this.Blur, this.Spread, this.Color);
		}

		// Token: 0x04000673 RID: 1651
		public float OffsetX;

		// Token: 0x04000674 RID: 1652
		public float OffsetY;

		// Token: 0x04000675 RID: 1653
		public float Blur;

		// Token: 0x04000676 RID: 1654
		public float Spread;

		// Token: 0x04000677 RID: 1655
		public Color Color;
	}
}
