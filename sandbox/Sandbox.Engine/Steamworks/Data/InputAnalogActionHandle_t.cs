using System;

namespace Steamworks.Data
{
	// Token: 0x020001C8 RID: 456
	internal struct InputAnalogActionHandle_t : IEquatable<InputAnalogActionHandle_t>, IComparable<InputAnalogActionHandle_t>
	{
		// Token: 0x06000B27 RID: 2855 RVA: 0x0000FC68 File Offset: 0x0000DE68
		public static implicit operator InputAnalogActionHandle_t(ulong value)
		{
			return new InputAnalogActionHandle_t
			{
				Value = value
			};
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0000FC86 File Offset: 0x0000DE86
		public static implicit operator ulong(InputAnalogActionHandle_t value)
		{
			return value.Value;
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0000FC8E File Offset: 0x0000DE8E
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x0000FC9B File Offset: 0x0000DE9B
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0000FCA8 File Offset: 0x0000DEA8
		public override bool Equals(object p)
		{
			return this.Equals((InputAnalogActionHandle_t)p);
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0000FCB6 File Offset: 0x0000DEB6
		public bool Equals(InputAnalogActionHandle_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x0000FCC6 File Offset: 0x0000DEC6
		public static bool operator ==(InputAnalogActionHandle_t a, InputAnalogActionHandle_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x0000FCD0 File Offset: 0x0000DED0
		public static bool operator !=(InputAnalogActionHandle_t a, InputAnalogActionHandle_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0000FCDD File Offset: 0x0000DEDD
		public int CompareTo(InputAnalogActionHandle_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D51 RID: 3409
		internal ulong Value;
	}
}
