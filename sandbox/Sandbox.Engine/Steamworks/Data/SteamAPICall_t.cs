using System;

namespace Steamworks.Data
{
	// Token: 0x020001B1 RID: 433
	internal struct SteamAPICall_t : IEquatable<SteamAPICall_t>, IComparable<SteamAPICall_t>
	{
		// Token: 0x06000A58 RID: 2648 RVA: 0x0000F014 File Offset: 0x0000D214
		public static implicit operator SteamAPICall_t(ulong value)
		{
			return new SteamAPICall_t
			{
				Value = value
			};
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x0000F032 File Offset: 0x0000D232
		public static implicit operator ulong(SteamAPICall_t value)
		{
			return value.Value;
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x0000F03A File Offset: 0x0000D23A
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x0000F047 File Offset: 0x0000D247
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x0000F054 File Offset: 0x0000D254
		public override bool Equals(object p)
		{
			return this.Equals((SteamAPICall_t)p);
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x0000F062 File Offset: 0x0000D262
		public bool Equals(SteamAPICall_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x0000F072 File Offset: 0x0000D272
		public static bool operator ==(SteamAPICall_t a, SteamAPICall_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x0000F07C File Offset: 0x0000D27C
		public static bool operator !=(SteamAPICall_t a, SteamAPICall_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x0000F089 File Offset: 0x0000D289
		public int CompareTo(SteamAPICall_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D3A RID: 3386
		internal ulong Value;
	}
}
