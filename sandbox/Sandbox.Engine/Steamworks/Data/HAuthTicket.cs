using System;

namespace Steamworks.Data
{
	// Token: 0x020001B4 RID: 436
	internal struct HAuthTicket : IEquatable<HAuthTicket>, IComparable<HAuthTicket>
	{
		// Token: 0x06000A73 RID: 2675 RVA: 0x0000F1AC File Offset: 0x0000D3AC
		public static implicit operator HAuthTicket(uint value)
		{
			return new HAuthTicket
			{
				Value = value
			};
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x0000F1CA File Offset: 0x0000D3CA
		public static implicit operator uint(HAuthTicket value)
		{
			return value.Value;
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x0000F1D2 File Offset: 0x0000D3D2
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x0000F1DF File Offset: 0x0000D3DF
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x0000F1EC File Offset: 0x0000D3EC
		public override bool Equals(object p)
		{
			return this.Equals((HAuthTicket)p);
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x0000F1FA File Offset: 0x0000D3FA
		public bool Equals(HAuthTicket p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x0000F20A File Offset: 0x0000D40A
		public static bool operator ==(HAuthTicket a, HAuthTicket b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x0000F214 File Offset: 0x0000D414
		public static bool operator !=(HAuthTicket a, HAuthTicket b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x0000F221 File Offset: 0x0000D421
		public int CompareTo(HAuthTicket other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D3D RID: 3389
		internal uint Value;
	}
}
