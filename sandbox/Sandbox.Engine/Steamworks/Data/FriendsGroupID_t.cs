using System;

namespace Steamworks.Data
{
	// Token: 0x020001B7 RID: 439
	internal struct FriendsGroupID_t : IEquatable<FriendsGroupID_t>, IComparable<FriendsGroupID_t>
	{
		// Token: 0x06000A8E RID: 2702 RVA: 0x0000F344 File Offset: 0x0000D544
		public static implicit operator FriendsGroupID_t(short value)
		{
			return new FriendsGroupID_t
			{
				Value = value
			};
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x0000F362 File Offset: 0x0000D562
		public static implicit operator short(FriendsGroupID_t value)
		{
			return value.Value;
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x0000F36A File Offset: 0x0000D56A
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x0000F377 File Offset: 0x0000D577
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0000F384 File Offset: 0x0000D584
		public override bool Equals(object p)
		{
			return this.Equals((FriendsGroupID_t)p);
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x0000F392 File Offset: 0x0000D592
		public bool Equals(FriendsGroupID_t p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x0000F3A2 File Offset: 0x0000D5A2
		public static bool operator ==(FriendsGroupID_t a, FriendsGroupID_t b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x0000F3AC File Offset: 0x0000D5AC
		public static bool operator !=(FriendsGroupID_t a, FriendsGroupID_t b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x0000F3B9 File Offset: 0x0000D5B9
		public int CompareTo(FriendsGroupID_t other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D40 RID: 3392
		internal short Value;
	}
}
