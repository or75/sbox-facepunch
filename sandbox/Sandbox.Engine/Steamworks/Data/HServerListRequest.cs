using System;

namespace Steamworks.Data
{
	// Token: 0x020001B8 RID: 440
	internal struct HServerListRequest : IEquatable<HServerListRequest>, IComparable<HServerListRequest>
	{
		// Token: 0x06000A97 RID: 2711 RVA: 0x0000F3CC File Offset: 0x0000D5CC
		public static implicit operator HServerListRequest(IntPtr value)
		{
			return new HServerListRequest
			{
				Value = value
			};
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x0000F3EA File Offset: 0x0000D5EA
		public static implicit operator IntPtr(HServerListRequest value)
		{
			return value.Value;
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x0000F3F2 File Offset: 0x0000D5F2
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x0000F3FF File Offset: 0x0000D5FF
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x0000F40C File Offset: 0x0000D60C
		public override bool Equals(object p)
		{
			return this.Equals((HServerListRequest)p);
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x0000F41A File Offset: 0x0000D61A
		public bool Equals(HServerListRequest p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x0000F42D File Offset: 0x0000D62D
		public static bool operator ==(HServerListRequest a, HServerListRequest b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x0000F437 File Offset: 0x0000D637
		public static bool operator !=(HServerListRequest a, HServerListRequest b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x0000F444 File Offset: 0x0000D644
		public int CompareTo(HServerListRequest other)
		{
			return this.Value.ToInt64().CompareTo(other.Value.ToInt64());
		}

		// Token: 0x04000D41 RID: 3393
		internal IntPtr Value;
	}
}
