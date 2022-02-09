using System;

namespace Steamworks.Data
{
	// Token: 0x020001BF RID: 447
	internal struct SteamLeaderboardEntries_t : IEquatable<SteamLeaderboardEntries_t>, IComparable<SteamLeaderboardEntries_t>
	{
		// Token: 0x06000AD6 RID: 2774 RVA: 0x0000F7A0 File Offset: 0x0000D9A0
		public static implicit operator SteamLeaderboardEntries_t(ulong value)
		{
			return new SteamLeaderboardEntries_t
			{
				Value = value
			};
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x0000F7BE File Offset: 0x0000D9BE
		public static implicit operator ulong(SteamLeaderboardEntries_t value)
		{
			return value.Value;
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x0000F7C6 File Offset: 0x0000D9C6
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x0000F7D3 File Offset: 0x0000D9D3
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x0000F7E0 File Offset: 0x0000D9E0
		public override bool Equals(object p)
		{
			return this.Equals((SteamLeaderboardEntries_t)p);
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x0000F7EE File Offset: 0x0000D9EE
		public bool Equals(SteamLeaderboardEntries_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x0000F7FE File Offset: 0x0000D9FE
		public static bool operator ==(SteamLeaderboardEntries_t a, SteamLeaderboardEntries_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x0000F808 File Offset: 0x0000DA08
		public static bool operator !=(SteamLeaderboardEntries_t a, SteamLeaderboardEntries_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x0000F815 File Offset: 0x0000DA15
		public int CompareTo(SteamLeaderboardEntries_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D48 RID: 3400
		internal ulong Value;
	}
}
