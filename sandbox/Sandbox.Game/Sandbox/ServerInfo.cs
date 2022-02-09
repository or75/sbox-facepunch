using System;
using System.Collections.Generic;

namespace Sandbox
{
	// Token: 0x020000C6 RID: 198
	internal struct ServerInfo
	{
		/// <summary>
		/// Addons that the user should have installed and mounted
		/// </summary>
		// Token: 0x17000268 RID: 616
		// (get) Token: 0x0600121A RID: 4634 RVA: 0x0004C9AC File Offset: 0x0004ABAC
		// (set) Token: 0x0600121B RID: 4635 RVA: 0x0004C9B4 File Offset: 0x0004ABB4
		public List<string> MountedAddons { readonly get; set; }

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x0600121C RID: 4636 RVA: 0x0004C9BD File Offset: 0x0004ABBD
		// (set) Token: 0x0600121D RID: 4637 RVA: 0x0004C9C5 File Offset: 0x0004ABC5
		public string GameIdent { readonly get; set; }

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x0600121E RID: 4638 RVA: 0x0004C9CE File Offset: 0x0004ABCE
		// (set) Token: 0x0600121F RID: 4639 RVA: 0x0004C9D6 File Offset: 0x0004ABD6
		public string MapIdent { readonly get; set; }

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06001220 RID: 4640 RVA: 0x0004C9DF File Offset: 0x0004ABDF
		// (set) Token: 0x06001221 RID: 4641 RVA: 0x0004C9E7 File Offset: 0x0004ABE7
		public string[] RequiredContent { readonly get; set; }
	}
}
