using System;

namespace Steamworks.Data
{
	// Token: 0x020001BC RID: 444
	internal struct PublishedFileId : IEquatable<PublishedFileId>, IComparable<PublishedFileId>
	{
		// Token: 0x06000ABB RID: 2747 RVA: 0x0000F608 File Offset: 0x0000D808
		public static implicit operator PublishedFileId(ulong value)
		{
			return new PublishedFileId
			{
				Value = value
			};
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x0000F626 File Offset: 0x0000D826
		public static implicit operator ulong(PublishedFileId value)
		{
			return value.Value;
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x0000F62E File Offset: 0x0000D82E
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x0000F63B File Offset: 0x0000D83B
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x0000F648 File Offset: 0x0000D848
		public override bool Equals(object p)
		{
			return this.Equals((PublishedFileId)p);
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x0000F656 File Offset: 0x0000D856
		public bool Equals(PublishedFileId p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x0000F666 File Offset: 0x0000D866
		public static bool operator ==(PublishedFileId a, PublishedFileId b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x0000F670 File Offset: 0x0000D870
		public static bool operator !=(PublishedFileId a, PublishedFileId b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x0000F67D File Offset: 0x0000D87D
		public int CompareTo(PublishedFileId other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D45 RID: 3397
		internal ulong Value;
	}
}
