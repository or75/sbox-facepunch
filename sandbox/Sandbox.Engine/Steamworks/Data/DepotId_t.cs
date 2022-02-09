using System;

namespace Steamworks.Data
{
	// Token: 0x020001AF RID: 431
	internal struct DepotId_t : IEquatable<DepotId_t>, IComparable<DepotId_t>
	{
		// Token: 0x06000A46 RID: 2630 RVA: 0x0000EF04 File Offset: 0x0000D104
		public static implicit operator DepotId_t(uint value)
		{
			return new DepotId_t
			{
				Value = value
			};
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x0000EF22 File Offset: 0x0000D122
		public static implicit operator uint(DepotId_t value)
		{
			return value.Value;
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x0000EF2A File Offset: 0x0000D12A
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x0000EF37 File Offset: 0x0000D137
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x0000EF44 File Offset: 0x0000D144
		public override bool Equals(object p)
		{
			return this.Equals((DepotId_t)p);
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x0000EF52 File Offset: 0x0000D152
		public bool Equals(DepotId_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x0000EF62 File Offset: 0x0000D162
		public static bool operator ==(DepotId_t a, DepotId_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x0000EF6C File Offset: 0x0000D16C
		public static bool operator !=(DepotId_t a, DepotId_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x0000EF79 File Offset: 0x0000D179
		public int CompareTo(DepotId_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D38 RID: 3384
		internal uint Value;
	}
}
