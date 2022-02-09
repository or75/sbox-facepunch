using System;

namespace Steamworks.Data
{
	// Token: 0x020001CE RID: 462
	internal struct UGCUpdateHandle_t : IEquatable<UGCUpdateHandle_t>, IComparable<UGCUpdateHandle_t>
	{
		// Token: 0x06000B5D RID: 2909 RVA: 0x0000FF98 File Offset: 0x0000E198
		public static implicit operator UGCUpdateHandle_t(ulong value)
		{
			return new UGCUpdateHandle_t
			{
				Value = value
			};
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x0000FFB6 File Offset: 0x0000E1B6
		public static implicit operator ulong(UGCUpdateHandle_t value)
		{
			return value.Value;
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x0000FFBE File Offset: 0x0000E1BE
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x0000FFCB File Offset: 0x0000E1CB
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x0000FFD8 File Offset: 0x0000E1D8
		public override bool Equals(object p)
		{
			return this.Equals((UGCUpdateHandle_t)p);
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x0000FFE6 File Offset: 0x0000E1E6
		public bool Equals(UGCUpdateHandle_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x0000FFF6 File Offset: 0x0000E1F6
		public static bool operator ==(UGCUpdateHandle_t a, UGCUpdateHandle_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x00010000 File Offset: 0x0000E200
		public static bool operator !=(UGCUpdateHandle_t a, UGCUpdateHandle_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x0001000D File Offset: 0x0000E20D
		public int CompareTo(UGCUpdateHandle_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D57 RID: 3415
		internal ulong Value;
	}
}
