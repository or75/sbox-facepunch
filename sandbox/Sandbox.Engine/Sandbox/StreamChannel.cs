using System;

namespace Sandbox
{
	// Token: 0x020002D3 RID: 723
	public struct StreamChannel
	{
		// Token: 0x1700038C RID: 908
		// (get) Token: 0x060012CD RID: 4813 RVA: 0x00027400 File Offset: 0x00025600
		// (set) Token: 0x060012CE RID: 4814 RVA: 0x00027408 File Offset: 0x00025608
		public string UserId { readonly get; internal set; }

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x060012CF RID: 4815 RVA: 0x00027411 File Offset: 0x00025611
		// (set) Token: 0x060012D0 RID: 4816 RVA: 0x00027419 File Offset: 0x00025619
		public string Username { readonly get; internal set; }

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x060012D1 RID: 4817 RVA: 0x00027422 File Offset: 0x00025622
		// (set) Token: 0x060012D2 RID: 4818 RVA: 0x0002742A File Offset: 0x0002562A
		public string DisplayName { readonly get; internal set; }

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x060012D3 RID: 4819 RVA: 0x00027433 File Offset: 0x00025633
		// (set) Token: 0x060012D4 RID: 4820 RVA: 0x0002743B File Offset: 0x0002563B
		public string Language { readonly get; internal set; }

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x060012D5 RID: 4821 RVA: 0x00027444 File Offset: 0x00025644
		// (set) Token: 0x060012D6 RID: 4822 RVA: 0x0002744C File Offset: 0x0002564C
		public string GameId { readonly get; internal set; }

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x060012D7 RID: 4823 RVA: 0x00027455 File Offset: 0x00025655
		// (set) Token: 0x060012D8 RID: 4824 RVA: 0x0002745D File Offset: 0x0002565D
		public string GameName { readonly get; internal set; }

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x060012D9 RID: 4825 RVA: 0x00027466 File Offset: 0x00025666
		// (set) Token: 0x060012DA RID: 4826 RVA: 0x0002746E File Offset: 0x0002566E
		public string Title { readonly get; internal set; }

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x060012DB RID: 4827 RVA: 0x00027477 File Offset: 0x00025677
		// (set) Token: 0x060012DC RID: 4828 RVA: 0x0002747F File Offset: 0x0002567F
		public int Delay { readonly get; internal set; }
	}
}
