using System;

namespace Steamworks.Data
{
	// Token: 0x020001C9 RID: 457
	internal struct ControllerHandle_t : IEquatable<ControllerHandle_t>, IComparable<ControllerHandle_t>
	{
		// Token: 0x06000B30 RID: 2864 RVA: 0x0000FCF0 File Offset: 0x0000DEF0
		public static implicit operator ControllerHandle_t(ulong value)
		{
			return new ControllerHandle_t
			{
				Value = value
			};
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0000FD0E File Offset: 0x0000DF0E
		public static implicit operator ulong(ControllerHandle_t value)
		{
			return value.Value;
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x0000FD16 File Offset: 0x0000DF16
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x0000FD23 File Offset: 0x0000DF23
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x0000FD30 File Offset: 0x0000DF30
		public override bool Equals(object p)
		{
			return this.Equals((ControllerHandle_t)p);
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0000FD3E File Offset: 0x0000DF3E
		public bool Equals(ControllerHandle_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x0000FD4E File Offset: 0x0000DF4E
		public static bool operator ==(ControllerHandle_t a, ControllerHandle_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0000FD58 File Offset: 0x0000DF58
		public static bool operator !=(ControllerHandle_t a, ControllerHandle_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0000FD65 File Offset: 0x0000DF65
		public int CompareTo(ControllerHandle_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D52 RID: 3410
		internal ulong Value;
	}
}
