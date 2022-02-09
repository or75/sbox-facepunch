using System;
using System.Runtime.CompilerServices;

namespace Sandbox
{
	// Token: 0x020000FA RID: 250
	public struct TimeUntil : IEquatable<TimeUntil>
	{
		// Token: 0x0600149F RID: 5279 RVA: 0x000526FE File Offset: 0x000508FE
		public static implicit operator bool(TimeUntil ts)
		{
			return Time.Now >= ts.time;
		}

		// Token: 0x060014A0 RID: 5280 RVA: 0x00052710 File Offset: 0x00050910
		public static implicit operator float(TimeUntil ts)
		{
			return ts.time - Time.Now;
		}

		// Token: 0x060014A1 RID: 5281 RVA: 0x00052720 File Offset: 0x00050920
		public static implicit operator TimeUntil(float ts)
		{
			return new TimeUntil
			{
				time = Time.Now + ts,
				startTime = Time.Now
			};
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x060014A2 RID: 5282 RVA: 0x00052750 File Offset: 0x00050950
		public float Absolute
		{
			get
			{
				return this.time;
			}
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x060014A3 RID: 5283 RVA: 0x00052758 File Offset: 0x00050958
		public float Relative
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x060014A4 RID: 5284 RVA: 0x00052765 File Offset: 0x00050965
		public float Fraction
		{
			get
			{
				return Math.Clamp((Time.Now - this.startTime) / (this.time - this.startTime), 0f, 1f);
			}
		}

		// Token: 0x060014A5 RID: 5285 RVA: 0x00052790 File Offset: 0x00050990
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.Relative);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x060014A6 RID: 5286 RVA: 0x000527BA File Offset: 0x000509BA
		public static bool operator ==(TimeUntil left, TimeUntil right)
		{
			return left.Equals(right);
		}

		// Token: 0x060014A7 RID: 5287 RVA: 0x000527C4 File Offset: 0x000509C4
		public static bool operator !=(TimeUntil left, TimeUntil right)
		{
			return !(left == right);
		}

		// Token: 0x060014A8 RID: 5288 RVA: 0x000527D0 File Offset: 0x000509D0
		public override bool Equals(object obj)
		{
			if (obj is TimeUntil)
			{
				TimeUntil o = (TimeUntil)obj;
				return this.Equals(o);
			}
			return false;
		}

		// Token: 0x060014A9 RID: 5289 RVA: 0x000527F5 File Offset: 0x000509F5
		public bool Equals(TimeUntil o)
		{
			return this.time == o.time;
		}

		// Token: 0x060014AA RID: 5290 RVA: 0x00052805 File Offset: 0x00050A05
		public override int GetHashCode()
		{
			return HashCode.Combine<float>(this.time);
		}

		// Token: 0x040004CA RID: 1226
		private float time;

		// Token: 0x040004CB RID: 1227
		private float startTime;
	}
}
