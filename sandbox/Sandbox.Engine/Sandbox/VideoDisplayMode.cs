using System;

namespace Sandbox
{
	// Token: 0x02000297 RID: 663
	public struct VideoDisplayMode
	{
		// Token: 0x1700033B RID: 827
		// (get) Token: 0x060010D0 RID: 4304 RVA: 0x0001F678 File Offset: 0x0001D878
		// (set) Token: 0x060010D1 RID: 4305 RVA: 0x0001F680 File Offset: 0x0001D880
		public int Width { readonly get; set; }

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x060010D2 RID: 4306 RVA: 0x0001F689 File Offset: 0x0001D889
		// (set) Token: 0x060010D3 RID: 4307 RVA: 0x0001F691 File Offset: 0x0001D891
		public int Height { readonly get; set; }

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x060010D4 RID: 4308 RVA: 0x0001F69A File Offset: 0x0001D89A
		// (set) Token: 0x060010D5 RID: 4309 RVA: 0x0001F6A2 File Offset: 0x0001D8A2
		public float RefreshRate { readonly get; set; }

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x060010D6 RID: 4310 RVA: 0x0001F6AB File Offset: 0x0001D8AB
		// (set) Token: 0x060010D7 RID: 4311 RVA: 0x0001F6B3 File Offset: 0x0001D8B3
		public ImageFormat Format { readonly get; set; }
	}
}
