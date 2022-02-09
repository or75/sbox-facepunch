using System;
using System.Runtime.CompilerServices;

namespace Sandbox
{
	// Token: 0x02000287 RID: 647
	[NullableContext(1)]
	[Nullable(0)]
	public struct PlayerGameRank
	{
		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000FFD RID: 4093 RVA: 0x0001CF26 File Offset: 0x0001B126
		// (set) Token: 0x06000FFE RID: 4094 RVA: 0x0001CF2E File Offset: 0x0001B12E
		public long PlayerId { readonly get; set; }

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000FFF RID: 4095 RVA: 0x0001CF37 File Offset: 0x0001B137
		// (set) Token: 0x06001000 RID: 4096 RVA: 0x0001CF3F File Offset: 0x0001B13F
		public string PlayerName { readonly get; set; }

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06001001 RID: 4097 RVA: 0x0001CF48 File Offset: 0x0001B148
		// (set) Token: 0x06001002 RID: 4098 RVA: 0x0001CF50 File Offset: 0x0001B150
		public int Level { readonly get; set; }

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06001003 RID: 4099 RVA: 0x0001CF59 File Offset: 0x0001B159
		// (set) Token: 0x06001004 RID: 4100 RVA: 0x0001CF61 File Offset: 0x0001B161
		public int Wins { readonly get; set; }

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06001005 RID: 4101 RVA: 0x0001CF6A File Offset: 0x0001B16A
		// (set) Token: 0x06001006 RID: 4102 RVA: 0x0001CF72 File Offset: 0x0001B172
		public int Losses { readonly get; set; }

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06001007 RID: 4103 RVA: 0x0001CF7B File Offset: 0x0001B17B
		// (set) Token: 0x06001008 RID: 4104 RVA: 0x0001CF83 File Offset: 0x0001B183
		public int Draws { readonly get; set; }

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06001009 RID: 4105 RVA: 0x0001CF8C File Offset: 0x0001B18C
		// (set) Token: 0x0600100A RID: 4106 RVA: 0x0001CF94 File Offset: 0x0001B194
		public PlayerGameRank.LeaderboardFacet Global { readonly get; set; }

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x0600100B RID: 4107 RVA: 0x0001CF9D File Offset: 0x0001B19D
		// (set) Token: 0x0600100C RID: 4108 RVA: 0x0001CFA5 File Offset: 0x0001B1A5
		public PlayerGameRank.LeaderboardFacet Country { readonly get; set; }

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x0600100D RID: 4109 RVA: 0x0001CFAE File Offset: 0x0001B1AE
		// (set) Token: 0x0600100E RID: 4110 RVA: 0x0001CFB6 File Offset: 0x0001B1B6
		public PlayerGameRank.LeaderboardFacet State { readonly get; set; }

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x0600100F RID: 4111 RVA: 0x0001CFBF File Offset: 0x0001B1BF
		// (set) Token: 0x06001010 RID: 4112 RVA: 0x0001CFC7 File Offset: 0x0001B1C7
		public PlayerGameRank.LeaderboardFacet City { readonly get; set; }

		// Token: 0x020003D9 RID: 985
		[Nullable(0)]
		public struct LeaderboardFacet
		{
			// Token: 0x1700046D RID: 1133
			// (get) Token: 0x06001715 RID: 5909 RVA: 0x00035692 File Offset: 0x00033892
			// (set) Token: 0x06001716 RID: 5910 RVA: 0x0003569A File Offset: 0x0003389A
			public string Value { readonly get; set; }

			// Token: 0x1700046E RID: 1134
			// (get) Token: 0x06001717 RID: 5911 RVA: 0x000356A3 File Offset: 0x000338A3
			// (set) Token: 0x06001718 RID: 5912 RVA: 0x000356AB File Offset: 0x000338AB
			public int Position { readonly get; set; }

			// Token: 0x1700046F RID: 1135
			// (get) Token: 0x06001719 RID: 5913 RVA: 0x000356B4 File Offset: 0x000338B4
			// (set) Token: 0x0600171A RID: 5914 RVA: 0x000356BC File Offset: 0x000338BC
			public int Total { readonly get; set; }
		}
	}
}
