using System;

namespace Sandbox.AddonProvision.Models.Github
{
	// Token: 0x02000308 RID: 776
	internal class BranchInfo
	{
		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x060014C9 RID: 5321 RVA: 0x0002CAB0 File Offset: 0x0002ACB0
		// (set) Token: 0x060014CA RID: 5322 RVA: 0x0002CAB8 File Offset: 0x0002ACB8
		public string Name { get; set; }

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x060014CB RID: 5323 RVA: 0x0002CAC1 File Offset: 0x0002ACC1
		// (set) Token: 0x060014CC RID: 5324 RVA: 0x0002CAC9 File Offset: 0x0002ACC9
		public Commit Commit { get; set; }
	}
}
