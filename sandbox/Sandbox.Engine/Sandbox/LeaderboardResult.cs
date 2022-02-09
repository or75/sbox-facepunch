using System;
using System.Collections.Generic;

namespace Sandbox
{
	// Token: 0x02000282 RID: 642
	public class LeaderboardResult
	{
		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06000FC1 RID: 4033 RVA: 0x0001CC00 File Offset: 0x0001AE00
		// (set) Token: 0x06000FC2 RID: 4034 RVA: 0x0001CC08 File Offset: 0x0001AE08
		public int Skip { get; set; }

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06000FC3 RID: 4035 RVA: 0x0001CC11 File Offset: 0x0001AE11
		// (set) Token: 0x06000FC4 RID: 4036 RVA: 0x0001CC19 File Offset: 0x0001AE19
		public int Take { get; set; }

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000FC5 RID: 4037 RVA: 0x0001CC22 File Offset: 0x0001AE22
		// (set) Token: 0x06000FC6 RID: 4038 RVA: 0x0001CC2A File Offset: 0x0001AE2A
		public int Count { get; set; }

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000FC7 RID: 4039 RVA: 0x0001CC33 File Offset: 0x0001AE33
		// (set) Token: 0x06000FC8 RID: 4040 RVA: 0x0001CC3B File Offset: 0x0001AE3B
		public int? PlayerPlace { get; set; }

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06000FC9 RID: 4041 RVA: 0x0001CC44 File Offset: 0x0001AE44
		// (set) Token: 0x06000FCA RID: 4042 RVA: 0x0001CC4C File Offset: 0x0001AE4C
		public List<LeaderboardResult.Entry> Entries { get; set; }

		// Token: 0x020003D1 RID: 977
		public struct Entry
		{
			// Token: 0x1700045B RID: 1115
			// (get) Token: 0x060016E7 RID: 5863 RVA: 0x000352CA File Offset: 0x000334CA
			// (set) Token: 0x060016E8 RID: 5864 RVA: 0x000352D2 File Offset: 0x000334D2
			public long PlayerId { readonly get; set; }

			// Token: 0x1700045C RID: 1116
			// (get) Token: 0x060016E9 RID: 5865 RVA: 0x000352DB File Offset: 0x000334DB
			// (set) Token: 0x060016EA RID: 5866 RVA: 0x000352E3 File Offset: 0x000334E3
			public string DisplayName { readonly get; set; }

			// Token: 0x1700045D RID: 1117
			// (get) Token: 0x060016EB RID: 5867 RVA: 0x000352EC File Offset: 0x000334EC
			// (set) Token: 0x060016EC RID: 5868 RVA: 0x000352F4 File Offset: 0x000334F4
			public float Rating { readonly get; set; }
		}
	}
}
