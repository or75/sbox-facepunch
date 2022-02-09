using System;

namespace Steamworks.Data
{
	// Token: 0x020001D3 RID: 467
	internal struct SteamInventoryUpdateHandle_t : IEquatable<SteamInventoryUpdateHandle_t>, IComparable<SteamInventoryUpdateHandle_t>
	{
		// Token: 0x06000B8A RID: 2954 RVA: 0x00010240 File Offset: 0x0000E440
		public static implicit operator SteamInventoryUpdateHandle_t(ulong value)
		{
			return new SteamInventoryUpdateHandle_t
			{
				Value = value
			};
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x0001025E File Offset: 0x0000E45E
		public static implicit operator ulong(SteamInventoryUpdateHandle_t value)
		{
			return value.Value;
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x00010266 File Offset: 0x0000E466
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x00010273 File Offset: 0x0000E473
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x00010280 File Offset: 0x0000E480
		public override bool Equals(object p)
		{
			return this.Equals((SteamInventoryUpdateHandle_t)p);
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x0001028E File Offset: 0x0000E48E
		public bool Equals(SteamInventoryUpdateHandle_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x0001029E File Offset: 0x0000E49E
		public static bool operator ==(SteamInventoryUpdateHandle_t a, SteamInventoryUpdateHandle_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x000102A8 File Offset: 0x0000E4A8
		public static bool operator !=(SteamInventoryUpdateHandle_t a, SteamInventoryUpdateHandle_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x000102B5 File Offset: 0x0000E4B5
		public int CompareTo(SteamInventoryUpdateHandle_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D5C RID: 3420
		internal ulong Value;
	}
}
