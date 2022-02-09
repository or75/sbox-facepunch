using System;

namespace Steamworks.Data
{
	// Token: 0x020001B0 RID: 432
	internal struct RTime32 : IEquatable<RTime32>, IComparable<RTime32>
	{
		// Token: 0x06000A4F RID: 2639 RVA: 0x0000EF8C File Offset: 0x0000D18C
		public static implicit operator RTime32(uint value)
		{
			return new RTime32
			{
				Value = value
			};
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x0000EFAA File Offset: 0x0000D1AA
		public static implicit operator uint(RTime32 value)
		{
			return value.Value;
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x0000EFB2 File Offset: 0x0000D1B2
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x0000EFBF File Offset: 0x0000D1BF
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x0000EFCC File Offset: 0x0000D1CC
		public override bool Equals(object p)
		{
			return this.Equals((RTime32)p);
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x0000EFDA File Offset: 0x0000D1DA
		public bool Equals(RTime32 p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x0000EFEA File Offset: 0x0000D1EA
		public static bool operator ==(RTime32 a, RTime32 b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x0000EFF4 File Offset: 0x0000D1F4
		public static bool operator !=(RTime32 a, RTime32 b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x0000F001 File Offset: 0x0000D201
		public int CompareTo(RTime32 other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D39 RID: 3385
		internal uint Value;
	}
}
