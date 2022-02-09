using System;

namespace Steamworks.Data
{
	// Token: 0x020001B6 RID: 438
	internal struct HSteamUser : IEquatable<HSteamUser>, IComparable<HSteamUser>
	{
		// Token: 0x06000A85 RID: 2693 RVA: 0x0000F2BC File Offset: 0x0000D4BC
		public static implicit operator HSteamUser(int value)
		{
			return new HSteamUser
			{
				Value = value
			};
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x0000F2DA File Offset: 0x0000D4DA
		public static implicit operator int(HSteamUser value)
		{
			return value.Value;
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x0000F2E2 File Offset: 0x0000D4E2
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x0000F2EF File Offset: 0x0000D4EF
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x0000F2FC File Offset: 0x0000D4FC
		public override bool Equals(object p)
		{
			return this.Equals((HSteamUser)p);
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x0000F30A File Offset: 0x0000D50A
		public bool Equals(HSteamUser p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x0000F31A File Offset: 0x0000D51A
		public static bool operator ==(HSteamUser a, HSteamUser b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x0000F324 File Offset: 0x0000D524
		public static bool operator !=(HSteamUser a, HSteamUser b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x0000F331 File Offset: 0x0000D531
		public int CompareTo(HSteamUser other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D3F RID: 3391
		internal int Value;
	}
}
