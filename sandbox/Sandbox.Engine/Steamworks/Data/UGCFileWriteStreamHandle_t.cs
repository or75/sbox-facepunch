using System;

namespace Steamworks.Data
{
	// Token: 0x020001BD RID: 445
	internal struct UGCFileWriteStreamHandle_t : IEquatable<UGCFileWriteStreamHandle_t>, IComparable<UGCFileWriteStreamHandle_t>
	{
		// Token: 0x06000AC4 RID: 2756 RVA: 0x0000F690 File Offset: 0x0000D890
		public static implicit operator UGCFileWriteStreamHandle_t(ulong value)
		{
			return new UGCFileWriteStreamHandle_t
			{
				Value = value
			};
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x0000F6AE File Offset: 0x0000D8AE
		public static implicit operator ulong(UGCFileWriteStreamHandle_t value)
		{
			return value.Value;
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x0000F6B6 File Offset: 0x0000D8B6
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x0000F6C3 File Offset: 0x0000D8C3
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x0000F6D0 File Offset: 0x0000D8D0
		public override bool Equals(object p)
		{
			return this.Equals((UGCFileWriteStreamHandle_t)p);
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x0000F6DE File Offset: 0x0000D8DE
		public bool Equals(UGCFileWriteStreamHandle_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x0000F6EE File Offset: 0x0000D8EE
		public static bool operator ==(UGCFileWriteStreamHandle_t a, UGCFileWriteStreamHandle_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x0000F6F8 File Offset: 0x0000D8F8
		public static bool operator !=(UGCFileWriteStreamHandle_t a, UGCFileWriteStreamHandle_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x0000F705 File Offset: 0x0000D905
		public int CompareTo(UGCFileWriteStreamHandle_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D46 RID: 3398
		internal ulong Value;
	}
}
