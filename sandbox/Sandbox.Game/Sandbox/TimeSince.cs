using System;
using System.Runtime.CompilerServices;

namespace Sandbox
{
	// Token: 0x020000F9 RID: 249
	public struct TimeSince : IEquatable<TimeSince>
	{
		// Token: 0x06001495 RID: 5269 RVA: 0x00052632 File Offset: 0x00050832
		public static implicit operator float(TimeSince ts)
		{
			return Time.Now - ts.time;
		}

		// Token: 0x06001496 RID: 5270 RVA: 0x00052640 File Offset: 0x00050840
		public static implicit operator TimeSince(float ts)
		{
			return new TimeSince
			{
				time = Time.Now - ts
			};
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06001497 RID: 5271 RVA: 0x00052664 File Offset: 0x00050864
		public float Absolute
		{
			get
			{
				return this.time;
			}
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06001498 RID: 5272 RVA: 0x0005266C File Offset: 0x0005086C
		public float Relative
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06001499 RID: 5273 RVA: 0x0005267C File Offset: 0x0005087C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.Relative);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0600149A RID: 5274 RVA: 0x000526A6 File Offset: 0x000508A6
		public static bool operator ==(TimeSince left, TimeSince right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600149B RID: 5275 RVA: 0x000526B0 File Offset: 0x000508B0
		public static bool operator !=(TimeSince left, TimeSince right)
		{
			return !(left == right);
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x000526BC File Offset: 0x000508BC
		public override bool Equals(object obj)
		{
			if (obj is TimeSince)
			{
				TimeSince o = (TimeSince)obj;
				return this.Equals(o);
			}
			return false;
		}

		// Token: 0x0600149D RID: 5277 RVA: 0x000526E1 File Offset: 0x000508E1
		public bool Equals(TimeSince o)
		{
			return this.time == o.time;
		}

		// Token: 0x0600149E RID: 5278 RVA: 0x000526F1 File Offset: 0x000508F1
		public override int GetHashCode()
		{
			return this.time.GetHashCode();
		}

		// Token: 0x040004C9 RID: 1225
		private float time;
	}
}
