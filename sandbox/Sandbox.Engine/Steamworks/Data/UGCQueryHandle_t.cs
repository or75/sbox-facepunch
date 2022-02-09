using System;

namespace Steamworks.Data
{
	// Token: 0x020001CD RID: 461
	internal struct UGCQueryHandle_t : IEquatable<UGCQueryHandle_t>, IComparable<UGCQueryHandle_t>
	{
		// Token: 0x06000B54 RID: 2900 RVA: 0x0000FF10 File Offset: 0x0000E110
		public static implicit operator UGCQueryHandle_t(ulong value)
		{
			return new UGCQueryHandle_t
			{
				Value = value
			};
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x0000FF2E File Offset: 0x0000E12E
		public static implicit operator ulong(UGCQueryHandle_t value)
		{
			return value.Value;
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x0000FF36 File Offset: 0x0000E136
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x0000FF43 File Offset: 0x0000E143
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x0000FF50 File Offset: 0x0000E150
		public override bool Equals(object p)
		{
			return this.Equals((UGCQueryHandle_t)p);
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x0000FF5E File Offset: 0x0000E15E
		public bool Equals(UGCQueryHandle_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x0000FF6E File Offset: 0x0000E16E
		public static bool operator ==(UGCQueryHandle_t a, UGCQueryHandle_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x0000FF78 File Offset: 0x0000E178
		public static bool operator !=(UGCQueryHandle_t a, UGCQueryHandle_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x0000FF85 File Offset: 0x0000E185
		public int CompareTo(UGCQueryHandle_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D56 RID: 3414
		internal ulong Value;
	}
}
