using System;

namespace Steamworks.Data
{
	// Token: 0x020001C5 RID: 453
	internal struct InputHandle_t : IEquatable<InputHandle_t>, IComparable<InputHandle_t>
	{
		// Token: 0x06000B0C RID: 2828 RVA: 0x0000FAD0 File Offset: 0x0000DCD0
		public static implicit operator InputHandle_t(ulong value)
		{
			return new InputHandle_t
			{
				Value = value
			};
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x0000FAEE File Offset: 0x0000DCEE
		public static implicit operator ulong(InputHandle_t value)
		{
			return value.Value;
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x0000FAF6 File Offset: 0x0000DCF6
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x0000FB03 File Offset: 0x0000DD03
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x0000FB10 File Offset: 0x0000DD10
		public override bool Equals(object p)
		{
			return this.Equals((InputHandle_t)p);
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x0000FB1E File Offset: 0x0000DD1E
		public bool Equals(InputHandle_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x0000FB2E File Offset: 0x0000DD2E
		public static bool operator ==(InputHandle_t a, InputHandle_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x0000FB38 File Offset: 0x0000DD38
		public static bool operator !=(InputHandle_t a, InputHandle_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x0000FB45 File Offset: 0x0000DD45
		public int CompareTo(InputHandle_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D4E RID: 3406
		internal ulong Value;
	}
}
