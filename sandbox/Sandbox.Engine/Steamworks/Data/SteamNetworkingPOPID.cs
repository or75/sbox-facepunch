using System;

namespace Steamworks.Data
{
	// Token: 0x020001D6 RID: 470
	internal struct SteamNetworkingPOPID : IEquatable<SteamNetworkingPOPID>, IComparable<SteamNetworkingPOPID>
	{
		// Token: 0x06000BA5 RID: 2981 RVA: 0x000103D8 File Offset: 0x0000E5D8
		public static implicit operator SteamNetworkingPOPID(uint value)
		{
			return new SteamNetworkingPOPID
			{
				Value = value
			};
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x000103F6 File Offset: 0x0000E5F6
		public static implicit operator uint(SteamNetworkingPOPID value)
		{
			return value.Value;
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x000103FE File Offset: 0x0000E5FE
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x0001040B File Offset: 0x0000E60B
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x00010418 File Offset: 0x0000E618
		public override bool Equals(object p)
		{
			return this.Equals((SteamNetworkingPOPID)p);
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x00010426 File Offset: 0x0000E626
		public bool Equals(SteamNetworkingPOPID p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x00010436 File Offset: 0x0000E636
		public static bool operator ==(SteamNetworkingPOPID a, SteamNetworkingPOPID b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x00010440 File Offset: 0x0000E640
		public static bool operator !=(SteamNetworkingPOPID a, SteamNetworkingPOPID b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x0001044D File Offset: 0x0000E64D
		public int CompareTo(SteamNetworkingPOPID other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D5F RID: 3423
		internal uint Value;
	}
}
