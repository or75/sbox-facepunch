using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000B6 RID: 182
	public class Pixmap
	{
		// Token: 0x06001555 RID: 5461 RVA: 0x000574C8 File Offset: 0x000556C8
		public Pixmap(int width, int height)
		{
			this.ptr = QPixmap.Create(width, height);
		}

		// Token: 0x06001556 RID: 5462 RVA: 0x000574DD File Offset: 0x000556DD
		private Pixmap(QPixmap ptr)
		{
			this.ptr = ptr;
		}

		// Token: 0x06001557 RID: 5463 RVA: 0x000574EC File Offset: 0x000556EC
		~Pixmap()
		{
			MainThread.QueueDispose(this.ptr);
			this.ptr = default(QPixmap);
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06001558 RID: 5464 RVA: 0x00057530 File Offset: 0x00055730
		public float Width
		{
			get
			{
				return (float)this.ptr.width();
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06001559 RID: 5465 RVA: 0x0005753E File Offset: 0x0005573E
		public float Height
		{
			get
			{
				return (float)this.ptr.height();
			}
		}

		// Token: 0x0600155A RID: 5466 RVA: 0x0005754C File Offset: 0x0005574C
		public static Pixmap FromFile(string filename)
		{
			QPixmap ptr = QPixmap.CreateFromFile("toolimages:" + filename);
			if (ptr.IsNull)
			{
				return null;
			}
			return new Pixmap(ptr);
		}

		// Token: 0x04000458 RID: 1112
		internal QPixmap ptr;
	}
}
