using System;

namespace Steamworks.Data
{
	// Token: 0x020001D4 RID: 468
	internal struct RemotePlaySessionID_t : IEquatable<RemotePlaySessionID_t>, IComparable<RemotePlaySessionID_t>
	{
		// Token: 0x06000B93 RID: 2963 RVA: 0x000102C8 File Offset: 0x0000E4C8
		public static implicit operator RemotePlaySessionID_t(uint value)
		{
			return new RemotePlaySessionID_t
			{
				Value = value
			};
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x000102E6 File Offset: 0x0000E4E6
		public static implicit operator uint(RemotePlaySessionID_t value)
		{
			return value.Value;
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x000102EE File Offset: 0x0000E4EE
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x000102FB File Offset: 0x0000E4FB
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x00010308 File Offset: 0x0000E508
		public override bool Equals(object p)
		{
			return this.Equals((RemotePlaySessionID_t)p);
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x00010316 File Offset: 0x0000E516
		public bool Equals(RemotePlaySessionID_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x00010326 File Offset: 0x0000E526
		public static bool operator ==(RemotePlaySessionID_t a, RemotePlaySessionID_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x00010330 File Offset: 0x0000E530
		public static bool operator !=(RemotePlaySessionID_t a, RemotePlaySessionID_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x0001033D File Offset: 0x0000E53D
		public int CompareTo(RemotePlaySessionID_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D5D RID: 3421
		internal uint Value;
	}
}
