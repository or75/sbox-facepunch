using System;

namespace Sandbox
{
	// Token: 0x020002D4 RID: 724
	public struct StreamChatMessage
	{
		// Token: 0x17000394 RID: 916
		// (get) Token: 0x060012DD RID: 4829 RVA: 0x00027488 File Offset: 0x00025688
		// (set) Token: 0x060012DE RID: 4830 RVA: 0x00027490 File Offset: 0x00025690
		public string Channel { readonly get; internal set; }

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x060012DF RID: 4831 RVA: 0x00027499 File Offset: 0x00025699
		// (set) Token: 0x060012E0 RID: 4832 RVA: 0x000274A1 File Offset: 0x000256A1
		public string DisplayName { readonly get; internal set; }

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x060012E1 RID: 4833 RVA: 0x000274AA File Offset: 0x000256AA
		// (set) Token: 0x060012E2 RID: 4834 RVA: 0x000274B2 File Offset: 0x000256B2
		public string Message { readonly get; internal set; }

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x060012E3 RID: 4835 RVA: 0x000274BB File Offset: 0x000256BB
		// (set) Token: 0x060012E4 RID: 4836 RVA: 0x000274C3 File Offset: 0x000256C3
		public string Username { readonly get; internal set; }

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x060012E5 RID: 4837 RVA: 0x000274CC File Offset: 0x000256CC
		// (set) Token: 0x060012E6 RID: 4838 RVA: 0x000274D4 File Offset: 0x000256D4
		public string Color { readonly get; internal set; }

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x060012E7 RID: 4839 RVA: 0x000274DD File Offset: 0x000256DD
		// (set) Token: 0x060012E8 RID: 4840 RVA: 0x000274E5 File Offset: 0x000256E5
		public string[] Badges { readonly get; internal set; }
	}
}
