using System;

namespace Steamworks.Data
{
	// Token: 0x020001B2 RID: 434
	internal struct AccountID_t : IEquatable<AccountID_t>, IComparable<AccountID_t>
	{
		// Token: 0x06000A61 RID: 2657 RVA: 0x0000F09C File Offset: 0x0000D29C
		public static implicit operator AccountID_t(uint value)
		{
			return new AccountID_t
			{
				Value = value
			};
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x0000F0BA File Offset: 0x0000D2BA
		public static implicit operator uint(AccountID_t value)
		{
			return value.Value;
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x0000F0C2 File Offset: 0x0000D2C2
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x0000F0CF File Offset: 0x0000D2CF
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x0000F0DC File Offset: 0x0000D2DC
		public override bool Equals(object p)
		{
			return this.Equals((AccountID_t)p);
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x0000F0EA File Offset: 0x0000D2EA
		public bool Equals(AccountID_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x0000F0FA File Offset: 0x0000D2FA
		public static bool operator ==(AccountID_t a, AccountID_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x0000F104 File Offset: 0x0000D304
		public static bool operator !=(AccountID_t a, AccountID_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x0000F111 File Offset: 0x0000D311
		public int CompareTo(AccountID_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D3B RID: 3387
		internal uint Value;
	}
}
