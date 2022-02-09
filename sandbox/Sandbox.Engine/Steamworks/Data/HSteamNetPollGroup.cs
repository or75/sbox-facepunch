using System;

namespace Steamworks.Data
{
	// Token: 0x020001D5 RID: 469
	internal struct HSteamNetPollGroup : IEquatable<HSteamNetPollGroup>, IComparable<HSteamNetPollGroup>
	{
		// Token: 0x06000B9C RID: 2972 RVA: 0x00010350 File Offset: 0x0000E550
		public static implicit operator HSteamNetPollGroup(uint value)
		{
			return new HSteamNetPollGroup
			{
				Value = value
			};
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x0001036E File Offset: 0x0000E56E
		public static implicit operator uint(HSteamNetPollGroup value)
		{
			return value.Value;
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x00010376 File Offset: 0x0000E576
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x00010383 File Offset: 0x0000E583
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x00010390 File Offset: 0x0000E590
		public override bool Equals(object p)
		{
			return this.Equals((HSteamNetPollGroup)p);
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x0001039E File Offset: 0x0000E59E
		public bool Equals(HSteamNetPollGroup p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x000103AE File Offset: 0x0000E5AE
		public static bool operator ==(HSteamNetPollGroup a, HSteamNetPollGroup b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x000103B8 File Offset: 0x0000E5B8
		public static bool operator !=(HSteamNetPollGroup a, HSteamNetPollGroup b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x000103C5 File Offset: 0x0000E5C5
		public int CompareTo(HSteamNetPollGroup other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D5E RID: 3422
		internal uint Value;
	}
}
