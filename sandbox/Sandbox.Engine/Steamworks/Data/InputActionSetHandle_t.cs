using System;

namespace Steamworks.Data
{
	// Token: 0x020001C6 RID: 454
	internal struct InputActionSetHandle_t : IEquatable<InputActionSetHandle_t>, IComparable<InputActionSetHandle_t>
	{
		// Token: 0x06000B15 RID: 2837 RVA: 0x0000FB58 File Offset: 0x0000DD58
		public static implicit operator InputActionSetHandle_t(ulong value)
		{
			return new InputActionSetHandle_t
			{
				Value = value
			};
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x0000FB76 File Offset: 0x0000DD76
		public static implicit operator ulong(InputActionSetHandle_t value)
		{
			return value.Value;
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0000FB7E File Offset: 0x0000DD7E
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x0000FB8B File Offset: 0x0000DD8B
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x0000FB98 File Offset: 0x0000DD98
		public override bool Equals(object p)
		{
			return this.Equals((InputActionSetHandle_t)p);
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x0000FBA6 File Offset: 0x0000DDA6
		public bool Equals(InputActionSetHandle_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x0000FBB6 File Offset: 0x0000DDB6
		public static bool operator ==(InputActionSetHandle_t a, InputActionSetHandle_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x0000FBC0 File Offset: 0x0000DDC0
		public static bool operator !=(InputActionSetHandle_t a, InputActionSetHandle_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0000FBCD File Offset: 0x0000DDCD
		public int CompareTo(InputActionSetHandle_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D4F RID: 3407
		internal ulong Value;
	}
}
