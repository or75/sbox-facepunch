using System;

namespace Steamworks.Data
{
	// Token: 0x020001D2 RID: 466
	internal struct SteamInventoryResult_t : IEquatable<SteamInventoryResult_t>, IComparable<SteamInventoryResult_t>
	{
		// Token: 0x06000B81 RID: 2945 RVA: 0x000101B8 File Offset: 0x0000E3B8
		public static implicit operator SteamInventoryResult_t(int value)
		{
			return new SteamInventoryResult_t
			{
				Value = value
			};
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x000101D6 File Offset: 0x0000E3D6
		public static implicit operator int(SteamInventoryResult_t value)
		{
			return value.Value;
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x000101DE File Offset: 0x0000E3DE
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x000101EB File Offset: 0x0000E3EB
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x000101F8 File Offset: 0x0000E3F8
		public override bool Equals(object p)
		{
			return this.Equals((SteamInventoryResult_t)p);
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x00010206 File Offset: 0x0000E406
		public bool Equals(SteamInventoryResult_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x00010216 File Offset: 0x0000E416
		public static bool operator ==(SteamInventoryResult_t a, SteamInventoryResult_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x00010220 File Offset: 0x0000E420
		public static bool operator !=(SteamInventoryResult_t a, SteamInventoryResult_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x0001022D File Offset: 0x0000E42D
		public int CompareTo(SteamInventoryResult_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D5B RID: 3419
		internal int Value;
	}
}
