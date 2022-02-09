using System;

namespace Sandbox
{
	// Token: 0x02000283 RID: 643
	public class ApiUpdateResult<T>
	{
		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06000FCC RID: 4044 RVA: 0x0001CC5D File Offset: 0x0001AE5D
		// (set) Token: 0x06000FCD RID: 4045 RVA: 0x0001CC65 File Offset: 0x0001AE65
		public bool Valid { get; set; }

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06000FCE RID: 4046 RVA: 0x0001CC6E File Offset: 0x0001AE6E
		// (set) Token: 0x06000FCF RID: 4047 RVA: 0x0001CC76 File Offset: 0x0001AE76
		public T Result { get; set; }

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000FD0 RID: 4048 RVA: 0x0001CC7F File Offset: 0x0001AE7F
		// (set) Token: 0x06000FD1 RID: 4049 RVA: 0x0001CC87 File Offset: 0x0001AE87
		public ApiUpdateResult<T>.Error[] Errors { get; set; }

		// Token: 0x020003D2 RID: 978
		public struct Error
		{
			// Token: 0x1700045E RID: 1118
			// (get) Token: 0x060016ED RID: 5869 RVA: 0x000352FD File Offset: 0x000334FD
			// (set) Token: 0x060016EE RID: 5870 RVA: 0x00035305 File Offset: 0x00033505
			public string Name { readonly get; set; }

			// Token: 0x1700045F RID: 1119
			// (get) Token: 0x060016EF RID: 5871 RVA: 0x0003530E File Offset: 0x0003350E
			// (set) Token: 0x060016F0 RID: 5872 RVA: 0x00035316 File Offset: 0x00033516
			public string Message { readonly get; set; }
		}
	}
}
