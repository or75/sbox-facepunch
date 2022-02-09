using System;

namespace Steamworks.Data
{
	// Token: 0x020001CB RID: 459
	internal struct ControllerDigitalActionHandle_t : IEquatable<ControllerDigitalActionHandle_t>, IComparable<ControllerDigitalActionHandle_t>
	{
		// Token: 0x06000B42 RID: 2882 RVA: 0x0000FE00 File Offset: 0x0000E000
		public static implicit operator ControllerDigitalActionHandle_t(ulong value)
		{
			return new ControllerDigitalActionHandle_t
			{
				Value = value
			};
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x0000FE1E File Offset: 0x0000E01E
		public static implicit operator ulong(ControllerDigitalActionHandle_t value)
		{
			return value.Value;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0000FE26 File Offset: 0x0000E026
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x0000FE33 File Offset: 0x0000E033
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x0000FE40 File Offset: 0x0000E040
		public override bool Equals(object p)
		{
			return this.Equals((ControllerDigitalActionHandle_t)p);
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x0000FE4E File Offset: 0x0000E04E
		public bool Equals(ControllerDigitalActionHandle_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x0000FE5E File Offset: 0x0000E05E
		public static bool operator ==(ControllerDigitalActionHandle_t a, ControllerDigitalActionHandle_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x0000FE68 File Offset: 0x0000E068
		public static bool operator !=(ControllerDigitalActionHandle_t a, ControllerDigitalActionHandle_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x0000FE75 File Offset: 0x0000E075
		public int CompareTo(ControllerDigitalActionHandle_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D54 RID: 3412
		internal ulong Value;
	}
}
