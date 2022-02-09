using System;

namespace Sandbox
{
	// Token: 0x02000294 RID: 660
	internal struct CookieItem
	{
		// Token: 0x17000339 RID: 825
		// (get) Token: 0x060010BF RID: 4287 RVA: 0x0001F28C File Offset: 0x0001D48C
		// (set) Token: 0x060010C0 RID: 4288 RVA: 0x0001F294 File Offset: 0x0001D494
		public string Value { readonly get; set; }

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x060010C1 RID: 4289 RVA: 0x0001F29D File Offset: 0x0001D49D
		// (set) Token: 0x060010C2 RID: 4290 RVA: 0x0001F2A5 File Offset: 0x0001D4A5
		public long Timeout { readonly get; set; }
	}
}
