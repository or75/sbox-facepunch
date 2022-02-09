using System;

namespace Steamworks.Data
{
	// Token: 0x020001E8 RID: 488
	internal struct NumericalFilter
	{
		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000C0B RID: 3083 RVA: 0x000113B0 File Offset: 0x0000F5B0
		// (set) Token: 0x06000C0C RID: 3084 RVA: 0x000113B8 File Offset: 0x0000F5B8
		internal string Key { readonly get; set; }

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000C0D RID: 3085 RVA: 0x000113C1 File Offset: 0x0000F5C1
		// (set) Token: 0x06000C0E RID: 3086 RVA: 0x000113C9 File Offset: 0x0000F5C9
		internal int Value { readonly get; set; }

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000C0F RID: 3087 RVA: 0x000113D2 File Offset: 0x0000F5D2
		// (set) Token: 0x06000C10 RID: 3088 RVA: 0x000113DA File Offset: 0x0000F5DA
		internal LobbyComparison Comparer { readonly get; set; }

		// Token: 0x06000C11 RID: 3089 RVA: 0x000113E3 File Offset: 0x0000F5E3
		internal NumericalFilter(string k, int v, LobbyComparison c)
		{
			this.Key = k;
			this.Value = v;
			this.Comparer = c;
		}
	}
}
