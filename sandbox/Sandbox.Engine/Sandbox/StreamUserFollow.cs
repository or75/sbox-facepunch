using System;

namespace Sandbox
{
	// Token: 0x020002DA RID: 730
	public struct StreamUserFollow
	{
		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06001345 RID: 4933 RVA: 0x00027AAB File Offset: 0x00025CAB
		// (set) Token: 0x06001346 RID: 4934 RVA: 0x00027AB3 File Offset: 0x00025CB3
		public string UserId { readonly get; internal set; }

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06001347 RID: 4935 RVA: 0x00027ABC File Offset: 0x00025CBC
		// (set) Token: 0x06001348 RID: 4936 RVA: 0x00027AC4 File Offset: 0x00025CC4
		public string Username { readonly get; internal set; }

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06001349 RID: 4937 RVA: 0x00027ACD File Offset: 0x00025CCD
		// (set) Token: 0x0600134A RID: 4938 RVA: 0x00027AD5 File Offset: 0x00025CD5
		public string DisplayName { readonly get; internal set; }

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x0600134B RID: 4939 RVA: 0x00027ADE File Offset: 0x00025CDE
		// (set) Token: 0x0600134C RID: 4940 RVA: 0x00027AE6 File Offset: 0x00025CE6
		public DateTimeOffset CreatedAt { readonly get; internal set; }
	}
}
