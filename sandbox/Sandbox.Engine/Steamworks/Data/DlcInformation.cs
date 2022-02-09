using System;

namespace Steamworks.Data
{
	// Token: 0x020001DB RID: 475
	internal struct DlcInformation
	{
		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000BBE RID: 3006 RVA: 0x00010647 File Offset: 0x0000E847
		// (set) Token: 0x06000BBF RID: 3007 RVA: 0x0001064F File Offset: 0x0000E84F
		internal AppId AppId { readonly get; set; }

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000BC0 RID: 3008 RVA: 0x00010658 File Offset: 0x0000E858
		// (set) Token: 0x06000BC1 RID: 3009 RVA: 0x00010660 File Offset: 0x0000E860
		internal string Name { readonly get; set; }

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x00010669 File Offset: 0x0000E869
		// (set) Token: 0x06000BC3 RID: 3011 RVA: 0x00010671 File Offset: 0x0000E871
		internal bool Available { readonly get; set; }
	}
}
