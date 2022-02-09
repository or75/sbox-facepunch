using System;

namespace Steamworks.Data
{
	// Token: 0x020001CC RID: 460
	internal struct ControllerAnalogActionHandle_t : IEquatable<ControllerAnalogActionHandle_t>, IComparable<ControllerAnalogActionHandle_t>
	{
		// Token: 0x06000B4B RID: 2891 RVA: 0x0000FE88 File Offset: 0x0000E088
		public static implicit operator ControllerAnalogActionHandle_t(ulong value)
		{
			return new ControllerAnalogActionHandle_t
			{
				Value = value
			};
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x0000FEA6 File Offset: 0x0000E0A6
		public static implicit operator ulong(ControllerAnalogActionHandle_t value)
		{
			return value.Value;
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x0000FEAE File Offset: 0x0000E0AE
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x0000FEBB File Offset: 0x0000E0BB
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x0000FEC8 File Offset: 0x0000E0C8
		public override bool Equals(object p)
		{
			return this.Equals((ControllerAnalogActionHandle_t)p);
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x0000FED6 File Offset: 0x0000E0D6
		public bool Equals(ControllerAnalogActionHandle_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x0000FEE6 File Offset: 0x0000E0E6
		public static bool operator ==(ControllerAnalogActionHandle_t a, ControllerAnalogActionHandle_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x0000FEF0 File Offset: 0x0000E0F0
		public static bool operator !=(ControllerAnalogActionHandle_t a, ControllerAnalogActionHandle_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x0000FEFD File Offset: 0x0000E0FD
		public int CompareTo(ControllerAnalogActionHandle_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D55 RID: 3413
		internal ulong Value;
	}
}
