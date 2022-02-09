using System;

namespace Steamworks.Data
{
	// Token: 0x020001B5 RID: 437
	internal struct HSteamPipe : IEquatable<HSteamPipe>, IComparable<HSteamPipe>
	{
		// Token: 0x06000A7C RID: 2684 RVA: 0x0000F234 File Offset: 0x0000D434
		public static implicit operator HSteamPipe(int value)
		{
			return new HSteamPipe
			{
				Value = value
			};
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x0000F252 File Offset: 0x0000D452
		public static implicit operator int(HSteamPipe value)
		{
			return value.Value;
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x0000F25A File Offset: 0x0000D45A
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x0000F267 File Offset: 0x0000D467
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x0000F274 File Offset: 0x0000D474
		public override bool Equals(object p)
		{
			return this.Equals((HSteamPipe)p);
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x0000F282 File Offset: 0x0000D482
		public bool Equals(HSteamPipe p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x0000F292 File Offset: 0x0000D492
		public static bool operator ==(HSteamPipe a, HSteamPipe b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x0000F29C File Offset: 0x0000D49C
		public static bool operator !=(HSteamPipe a, HSteamPipe b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x0000F2A9 File Offset: 0x0000D4A9
		public int CompareTo(HSteamPipe other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D3E RID: 3390
		internal int Value;
	}
}
