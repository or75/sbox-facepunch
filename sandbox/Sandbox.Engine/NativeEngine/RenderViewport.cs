using System;

namespace NativeEngine
{
	// Token: 0x02000266 RID: 614
	internal struct RenderViewport
	{
		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06000F4E RID: 3918 RVA: 0x0001B3D7 File Offset: 0x000195D7
		// (set) Token: 0x06000F4F RID: 3919 RVA: 0x0001B3DF File Offset: 0x000195DF
		private int m_nVersion { readonly get; set; }

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000F50 RID: 3920 RVA: 0x0001B3E8 File Offset: 0x000195E8
		// (set) Token: 0x06000F51 RID: 3921 RVA: 0x0001B3F0 File Offset: 0x000195F0
		private int m_nTopLeftX { readonly get; set; }

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000F52 RID: 3922 RVA: 0x0001B3F9 File Offset: 0x000195F9
		// (set) Token: 0x06000F53 RID: 3923 RVA: 0x0001B401 File Offset: 0x00019601
		private int m_nTopLeftY { readonly get; set; }

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000F54 RID: 3924 RVA: 0x0001B40A File Offset: 0x0001960A
		// (set) Token: 0x06000F55 RID: 3925 RVA: 0x0001B412 File Offset: 0x00019612
		private int m_nWidth { readonly get; set; }

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000F56 RID: 3926 RVA: 0x0001B41B File Offset: 0x0001961B
		// (set) Token: 0x06000F57 RID: 3927 RVA: 0x0001B423 File Offset: 0x00019623
		private int m_nHeight { readonly get; set; }

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000F58 RID: 3928 RVA: 0x0001B42C File Offset: 0x0001962C
		// (set) Token: 0x06000F59 RID: 3929 RVA: 0x0001B434 File Offset: 0x00019634
		private float m_flMinZ { readonly get; set; }

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000F5A RID: 3930 RVA: 0x0001B43D File Offset: 0x0001963D
		// (set) Token: 0x06000F5B RID: 3931 RVA: 0x0001B445 File Offset: 0x00019645
		private float m_flMaxZ { readonly get; set; }

		// Token: 0x06000F5C RID: 3932 RVA: 0x0001B44E File Offset: 0x0001964E
		public RenderViewport(int x, int y, int w, int h)
		{
			this.m_nVersion = 1;
			this.m_nTopLeftX = x;
			this.m_nTopLeftY = y;
			this.m_nWidth = w;
			this.m_nHeight = h;
			this.m_flMinZ = 0f;
			this.m_flMaxZ = 1f;
		}

		// Token: 0x06000F5D RID: 3933 RVA: 0x0001B48C File Offset: 0x0001968C
		public RenderViewport(Rect rect)
		{
			this.m_nVersion = 1;
			this.m_nTopLeftX = (int)rect.left;
			this.m_nTopLeftY = (int)rect.top;
			this.m_nWidth = (int)rect.right - (int)rect.left;
			this.m_nHeight = (int)rect.bottom - (int)rect.top;
			this.m_flMinZ = 0f;
			this.m_flMaxZ = 1f;
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000F5E RID: 3934 RVA: 0x0001B4FA File Offset: 0x000196FA
		public Rect Rect
		{
			get
			{
				return new Rect((float)this.m_nTopLeftX, (float)this.m_nTopLeftY, (float)this.m_nWidth, (float)this.m_nHeight);
			}
		}
	}
}
