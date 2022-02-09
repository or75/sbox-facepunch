using System;

namespace Steamworks.Data
{
	// Token: 0x020001CA RID: 458
	internal struct ControllerActionSetHandle_t : IEquatable<ControllerActionSetHandle_t>, IComparable<ControllerActionSetHandle_t>
	{
		// Token: 0x06000B39 RID: 2873 RVA: 0x0000FD78 File Offset: 0x0000DF78
		public static implicit operator ControllerActionSetHandle_t(ulong value)
		{
			return new ControllerActionSetHandle_t
			{
				Value = value
			};
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0000FD96 File Offset: 0x0000DF96
		public static implicit operator ulong(ControllerActionSetHandle_t value)
		{
			return value.Value;
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x0000FD9E File Offset: 0x0000DF9E
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x0000FDAB File Offset: 0x0000DFAB
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x0000FDB8 File Offset: 0x0000DFB8
		public override bool Equals(object p)
		{
			return this.Equals((ControllerActionSetHandle_t)p);
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x0000FDC6 File Offset: 0x0000DFC6
		public bool Equals(ControllerActionSetHandle_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x0000FDD6 File Offset: 0x0000DFD6
		public static bool operator ==(ControllerActionSetHandle_t a, ControllerActionSetHandle_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0000FDE0 File Offset: 0x0000DFE0
		public static bool operator !=(ControllerActionSetHandle_t a, ControllerActionSetHandle_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0000FDED File Offset: 0x0000DFED
		public int CompareTo(ControllerActionSetHandle_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D53 RID: 3411
		internal ulong Value;
	}
}
