using System;

namespace Sandbox
{
	// Token: 0x02000051 RID: 81
	public struct RealTimeUntil : IEquatable<RealTimeUntil>
	{
		// Token: 0x060003B3 RID: 947 RVA: 0x0000DE96 File Offset: 0x0000C096
		public static implicit operator bool(RealTimeUntil ts)
		{
			return RealTime.Now >= ts.time;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000DEA8 File Offset: 0x0000C0A8
		public static implicit operator float(RealTimeUntil ts)
		{
			return ts.time - RealTime.Now;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0000DEB8 File Offset: 0x0000C0B8
		public static implicit operator RealTimeUntil(float ts)
		{
			return new RealTimeUntil
			{
				time = RealTime.Now + ts,
				startTime = RealTime.Now
			};
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x0000DEE8 File Offset: 0x0000C0E8
		public float Absolute
		{
			get
			{
				return this.time;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x0000DEF0 File Offset: 0x0000C0F0
		public float Relative
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x0000DEFD File Offset: 0x0000C0FD
		public float Fraction
		{
			get
			{
				return Math.Clamp((RealTime.Now - this.startTime) / (this.time - this.startTime), 0f, 1f);
			}
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0000DF28 File Offset: 0x0000C128
		public override string ToString()
		{
			return string.Format("{0}", this.Relative);
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0000DF3F File Offset: 0x0000C13F
		public static bool operator ==(RealTimeUntil left, RealTimeUntil right)
		{
			return left.Equals(right);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000DF49 File Offset: 0x0000C149
		public static bool operator !=(RealTimeUntil left, RealTimeUntil right)
		{
			return !(left == right);
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0000DF58 File Offset: 0x0000C158
		public override bool Equals(object obj)
		{
			if (obj is RealTimeUntil)
			{
				RealTimeUntil o = (RealTimeUntil)obj;
				return this.Equals(o);
			}
			return false;
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0000DF7D File Offset: 0x0000C17D
		public bool Equals(RealTimeUntil o)
		{
			return this.time == o.time;
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0000DF8D File Offset: 0x0000C18D
		public override int GetHashCode()
		{
			return HashCode.Combine<float>(this.time);
		}

		// Token: 0x040000D5 RID: 213
		private float time;

		// Token: 0x040000D6 RID: 214
		private float startTime;
	}
}
