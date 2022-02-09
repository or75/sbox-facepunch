using System;

namespace Steamworks.Data
{
	// Token: 0x020001B3 RID: 435
	internal struct PartyBeaconID_t : IEquatable<PartyBeaconID_t>, IComparable<PartyBeaconID_t>
	{
		// Token: 0x06000A6A RID: 2666 RVA: 0x0000F124 File Offset: 0x0000D324
		public static implicit operator PartyBeaconID_t(ulong value)
		{
			return new PartyBeaconID_t
			{
				Value = value
			};
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x0000F142 File Offset: 0x0000D342
		public static implicit operator ulong(PartyBeaconID_t value)
		{
			return value.Value;
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x0000F14A File Offset: 0x0000D34A
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x0000F157 File Offset: 0x0000D357
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x0000F164 File Offset: 0x0000D364
		public override bool Equals(object p)
		{
			return this.Equals((PartyBeaconID_t)p);
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x0000F172 File Offset: 0x0000D372
		public bool Equals(PartyBeaconID_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x0000F182 File Offset: 0x0000D382
		public static bool operator ==(PartyBeaconID_t a, PartyBeaconID_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x0000F18C File Offset: 0x0000D38C
		public static bool operator !=(PartyBeaconID_t a, PartyBeaconID_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x0000F199 File Offset: 0x0000D399
		public int CompareTo(PartyBeaconID_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D3C RID: 3388
		internal ulong Value;
	}
}
