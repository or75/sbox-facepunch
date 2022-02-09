using System;

namespace Sandbox.UI
{
	// Token: 0x02000128 RID: 296
	[Hotload.SkipAttribute]
	public class Box
	{
		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06001708 RID: 5896 RVA: 0x0005C605 File Offset: 0x0005A805
		public float Left
		{
			get
			{
				return this.Rect.left;
			}
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06001709 RID: 5897 RVA: 0x0005C612 File Offset: 0x0005A812
		public float Right
		{
			get
			{
				return this.Rect.right;
			}
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x0600170A RID: 5898 RVA: 0x0005C61F File Offset: 0x0005A81F
		public float Top
		{
			get
			{
				return this.Rect.top;
			}
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x0600170B RID: 5899 RVA: 0x0005C62C File Offset: 0x0005A82C
		public float Bottom
		{
			get
			{
				return this.Rect.bottom;
			}
		}

		// Token: 0x040005C8 RID: 1480
		public Rect RectOuter;

		// Token: 0x040005C9 RID: 1481
		public Rect RectInner;

		// Token: 0x040005CA RID: 1482
		public Rect Rect;

		// Token: 0x040005CB RID: 1483
		public Rect ClipRect;
	}
}
