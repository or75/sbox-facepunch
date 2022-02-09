using System;

namespace Steamworks.Data
{
	// Token: 0x020001D0 RID: 464
	internal struct InventoryItemId : IEquatable<InventoryItemId>, IComparable<InventoryItemId>
	{
		// Token: 0x06000B6F RID: 2927 RVA: 0x000100A8 File Offset: 0x0000E2A8
		public static implicit operator InventoryItemId(ulong value)
		{
			return new InventoryItemId
			{
				Value = value
			};
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x000100C6 File Offset: 0x0000E2C6
		public static implicit operator ulong(InventoryItemId value)
		{
			return value.Value;
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x000100CE File Offset: 0x0000E2CE
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x000100DB File Offset: 0x0000E2DB
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x000100E8 File Offset: 0x0000E2E8
		public override bool Equals(object p)
		{
			return this.Equals((InventoryItemId)p);
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x000100F6 File Offset: 0x0000E2F6
		public bool Equals(InventoryItemId p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x00010106 File Offset: 0x0000E306
		public static bool operator ==(InventoryItemId a, InventoryItemId b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B76 RID: 2934 RVA: 0x00010110 File Offset: 0x0000E310
		public static bool operator !=(InventoryItemId a, InventoryItemId b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x0001011D File Offset: 0x0000E31D
		public int CompareTo(InventoryItemId other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D59 RID: 3417
		internal ulong Value;
	}
}
