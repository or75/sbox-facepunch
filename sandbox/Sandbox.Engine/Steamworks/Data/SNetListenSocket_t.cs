using System;

namespace Steamworks.Data
{
	// Token: 0x020001C1 RID: 449
	internal struct SNetListenSocket_t : IEquatable<SNetListenSocket_t>, IComparable<SNetListenSocket_t>
	{
		// Token: 0x06000AE8 RID: 2792 RVA: 0x0000F8B0 File Offset: 0x0000DAB0
		public static implicit operator SNetListenSocket_t(uint value)
		{
			return new SNetListenSocket_t
			{
				Value = value
			};
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0000F8CE File Offset: 0x0000DACE
		public static implicit operator uint(SNetListenSocket_t value)
		{
			return value.Value;
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x0000F8D6 File Offset: 0x0000DAD6
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x0000F8E3 File Offset: 0x0000DAE3
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0000F8F0 File Offset: 0x0000DAF0
		public override bool Equals(object p)
		{
			return this.Equals((SNetListenSocket_t)p);
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x0000F8FE File Offset: 0x0000DAFE
		public bool Equals(SNetListenSocket_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x0000F90E File Offset: 0x0000DB0E
		public static bool operator ==(SNetListenSocket_t a, SNetListenSocket_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x0000F918 File Offset: 0x0000DB18
		public static bool operator !=(SNetListenSocket_t a, SNetListenSocket_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x0000F925 File Offset: 0x0000DB25
		public int CompareTo(SNetListenSocket_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D4A RID: 3402
		internal uint Value;
	}
}
