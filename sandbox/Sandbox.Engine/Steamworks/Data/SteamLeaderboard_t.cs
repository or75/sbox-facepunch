using System;

namespace Steamworks.Data
{
	// Token: 0x020001BE RID: 446
	internal struct SteamLeaderboard_t : IEquatable<SteamLeaderboard_t>, IComparable<SteamLeaderboard_t>
	{
		// Token: 0x06000ACD RID: 2765 RVA: 0x0000F718 File Offset: 0x0000D918
		public static implicit operator SteamLeaderboard_t(ulong value)
		{
			return new SteamLeaderboard_t
			{
				Value = value
			};
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x0000F736 File Offset: 0x0000D936
		public static implicit operator ulong(SteamLeaderboard_t value)
		{
			return value.Value;
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x0000F73E File Offset: 0x0000D93E
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x0000F74B File Offset: 0x0000D94B
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x0000F758 File Offset: 0x0000D958
		public override bool Equals(object p)
		{
			return this.Equals((SteamLeaderboard_t)p);
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x0000F766 File Offset: 0x0000D966
		public bool Equals(SteamLeaderboard_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x0000F776 File Offset: 0x0000D976
		public static bool operator ==(SteamLeaderboard_t a, SteamLeaderboard_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x0000F780 File Offset: 0x0000D980
		public static bool operator !=(SteamLeaderboard_t a, SteamLeaderboard_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x0000F78D File Offset: 0x0000D98D
		public int CompareTo(SteamLeaderboard_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D47 RID: 3399
		internal ulong Value;
	}
}
