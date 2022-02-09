using System;

namespace Steamworks.Data
{
	// Token: 0x020001C0 RID: 448
	internal struct SNetSocket_t : IEquatable<SNetSocket_t>, IComparable<SNetSocket_t>
	{
		// Token: 0x06000ADF RID: 2783 RVA: 0x0000F828 File Offset: 0x0000DA28
		public static implicit operator SNetSocket_t(uint value)
		{
			return new SNetSocket_t
			{
				Value = value
			};
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x0000F846 File Offset: 0x0000DA46
		public static implicit operator uint(SNetSocket_t value)
		{
			return value.Value;
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x0000F84E File Offset: 0x0000DA4E
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x0000F85B File Offset: 0x0000DA5B
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x0000F868 File Offset: 0x0000DA68
		public override bool Equals(object p)
		{
			return this.Equals((SNetSocket_t)p);
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x0000F876 File Offset: 0x0000DA76
		public bool Equals(SNetSocket_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x0000F886 File Offset: 0x0000DA86
		public static bool operator ==(SNetSocket_t a, SNetSocket_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x0000F890 File Offset: 0x0000DA90
		public static bool operator !=(SNetSocket_t a, SNetSocket_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x0000F89D File Offset: 0x0000DA9D
		public int CompareTo(SNetSocket_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D49 RID: 3401
		internal uint Value;
	}
}
