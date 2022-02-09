using System;

namespace Steamworks.Data
{
	// Token: 0x020001BA RID: 442
	internal struct UGCHandle_t : IEquatable<UGCHandle_t>, IComparable<UGCHandle_t>
	{
		// Token: 0x06000AA9 RID: 2729 RVA: 0x0000F4F8 File Offset: 0x0000D6F8
		public static implicit operator UGCHandle_t(ulong value)
		{
			return new UGCHandle_t
			{
				Value = value
			};
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x0000F516 File Offset: 0x0000D716
		public static implicit operator ulong(UGCHandle_t value)
		{
			return value.Value;
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x0000F51E File Offset: 0x0000D71E
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x0000F52B File Offset: 0x0000D72B
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x0000F538 File Offset: 0x0000D738
		public override bool Equals(object p)
		{
			return this.Equals((UGCHandle_t)p);
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x0000F546 File Offset: 0x0000D746
		public bool Equals(UGCHandle_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x0000F556 File Offset: 0x0000D756
		public static bool operator ==(UGCHandle_t a, UGCHandle_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x0000F560 File Offset: 0x0000D760
		public static bool operator !=(UGCHandle_t a, UGCHandle_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x0000F56D File Offset: 0x0000D76D
		public int CompareTo(UGCHandle_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D43 RID: 3395
		internal ulong Value;
	}
}
