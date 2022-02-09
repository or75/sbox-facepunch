using System;

namespace Sandbox
{
	// Token: 0x02000050 RID: 80
	public struct RealTimeSince : IEquatable<RealTimeSince>
	{
		// Token: 0x060003A9 RID: 937 RVA: 0x0000DDDE File Offset: 0x0000BFDE
		public static implicit operator float(RealTimeSince ts)
		{
			return RealTime.Now - ts.time;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0000DDEC File Offset: 0x0000BFEC
		public static implicit operator RealTimeSince(float ts)
		{
			return new RealTimeSince
			{
				time = RealTime.Now - ts
			};
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060003AB RID: 939 RVA: 0x0000DE10 File Offset: 0x0000C010
		public float Absolute
		{
			get
			{
				return this.time;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060003AC RID: 940 RVA: 0x0000DE18 File Offset: 0x0000C018
		public float Relative
		{
			get
			{
				return this;
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0000DE25 File Offset: 0x0000C025
		public override string ToString()
		{
			return string.Format("{0}", this.Relative);
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0000DE3C File Offset: 0x0000C03C
		public static bool operator ==(RealTimeSince left, RealTimeSince right)
		{
			return left.Equals(right);
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000DE46 File Offset: 0x0000C046
		public static bool operator !=(RealTimeSince left, RealTimeSince right)
		{
			return !(left == right);
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0000DE54 File Offset: 0x0000C054
		public override bool Equals(object obj)
		{
			if (obj is RealTimeSince)
			{
				RealTimeSince o = (RealTimeSince)obj;
				return this.Equals(o);
			}
			return false;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0000DE79 File Offset: 0x0000C079
		public bool Equals(RealTimeSince o)
		{
			return this.time == o.time;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0000DE89 File Offset: 0x0000C089
		public override int GetHashCode()
		{
			return HashCode.Combine<float>(this.time);
		}

		// Token: 0x040000D4 RID: 212
		private float time;
	}
}
