using System;

namespace Steamworks.Data
{
	// Token: 0x020001D1 RID: 465
	internal struct InventoryDefId : IEquatable<InventoryDefId>, IComparable<InventoryDefId>
	{
		// Token: 0x06000B78 RID: 2936 RVA: 0x00010130 File Offset: 0x0000E330
		public static implicit operator InventoryDefId(int value)
		{
			return new InventoryDefId
			{
				Value = value
			};
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x0001014E File Offset: 0x0000E34E
		public static implicit operator int(InventoryDefId value)
		{
			return value.Value;
		}

		// Token: 0x06000B7A RID: 2938 RVA: 0x00010156 File Offset: 0x0000E356
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x00010163 File Offset: 0x0000E363
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x00010170 File Offset: 0x0000E370
		public override bool Equals(object p)
		{
			return this.Equals((InventoryDefId)p);
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x0001017E File Offset: 0x0000E37E
		public bool Equals(InventoryDefId p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x0001018E File Offset: 0x0000E38E
		public static bool operator ==(InventoryDefId a, InventoryDefId b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x00010198 File Offset: 0x0000E398
		public static bool operator !=(InventoryDefId a, InventoryDefId b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x000101A5 File Offset: 0x0000E3A5
		public int CompareTo(InventoryDefId other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D5A RID: 3418
		internal int Value;
	}
}
