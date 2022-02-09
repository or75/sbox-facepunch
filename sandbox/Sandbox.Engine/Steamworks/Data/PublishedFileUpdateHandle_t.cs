using System;

namespace Steamworks.Data
{
	// Token: 0x020001BB RID: 443
	internal struct PublishedFileUpdateHandle_t : IEquatable<PublishedFileUpdateHandle_t>, IComparable<PublishedFileUpdateHandle_t>
	{
		// Token: 0x06000AB2 RID: 2738 RVA: 0x0000F580 File Offset: 0x0000D780
		public static implicit operator PublishedFileUpdateHandle_t(ulong value)
		{
			return new PublishedFileUpdateHandle_t
			{
				Value = value
			};
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x0000F59E File Offset: 0x0000D79E
		public static implicit operator ulong(PublishedFileUpdateHandle_t value)
		{
			return value.Value;
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x0000F5A6 File Offset: 0x0000D7A6
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x0000F5B3 File Offset: 0x0000D7B3
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x0000F5C0 File Offset: 0x0000D7C0
		public override bool Equals(object p)
		{
			return this.Equals((PublishedFileUpdateHandle_t)p);
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x0000F5CE File Offset: 0x0000D7CE
		public bool Equals(PublishedFileUpdateHandle_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x0000F5DE File Offset: 0x0000D7DE
		public static bool operator ==(PublishedFileUpdateHandle_t a, PublishedFileUpdateHandle_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x0000F5E8 File Offset: 0x0000D7E8
		public static bool operator !=(PublishedFileUpdateHandle_t a, PublishedFileUpdateHandle_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x0000F5F5 File Offset: 0x0000D7F5
		public int CompareTo(PublishedFileUpdateHandle_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D44 RID: 3396
		internal ulong Value;
	}
}
