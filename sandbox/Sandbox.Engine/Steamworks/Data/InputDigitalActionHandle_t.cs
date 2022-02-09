using System;

namespace Steamworks.Data
{
	// Token: 0x020001C7 RID: 455
	internal struct InputDigitalActionHandle_t : IEquatable<InputDigitalActionHandle_t>, IComparable<InputDigitalActionHandle_t>
	{
		// Token: 0x06000B1E RID: 2846 RVA: 0x0000FBE0 File Offset: 0x0000DDE0
		public static implicit operator InputDigitalActionHandle_t(ulong value)
		{
			return new InputDigitalActionHandle_t
			{
				Value = value
			};
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x0000FBFE File Offset: 0x0000DDFE
		public static implicit operator ulong(InputDigitalActionHandle_t value)
		{
			return value.Value;
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0000FC06 File Offset: 0x0000DE06
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x0000FC13 File Offset: 0x0000DE13
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x0000FC20 File Offset: 0x0000DE20
		public override bool Equals(object p)
		{
			return this.Equals((InputDigitalActionHandle_t)p);
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x0000FC2E File Offset: 0x0000DE2E
		public bool Equals(InputDigitalActionHandle_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x0000FC3E File Offset: 0x0000DE3E
		public static bool operator ==(InputDigitalActionHandle_t a, InputDigitalActionHandle_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0000FC48 File Offset: 0x0000DE48
		public static bool operator !=(InputDigitalActionHandle_t a, InputDigitalActionHandle_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0000FC55 File Offset: 0x0000DE55
		public int CompareTo(InputDigitalActionHandle_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D50 RID: 3408
		internal ulong Value;
	}
}
