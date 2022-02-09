using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000B0 RID: 176
	public class Brush
	{
		// Token: 0x060014EB RID: 5355 RVA: 0x00056A6E File Offset: 0x00054C6E
		public Brush()
		{
			this.ptr = QBrush.Create();
		}

		// Token: 0x060014EC RID: 5356 RVA: 0x00056A81 File Offset: 0x00054C81
		internal Brush(QBrush ptr)
		{
			this.ptr = ptr;
		}

		// Token: 0x060014ED RID: 5357 RVA: 0x00056A90 File Offset: 0x00054C90
		public Brush(Color color)
		{
			this.ptr = QBrush.CreateFromColor(color);
		}

		// Token: 0x060014EE RID: 5358 RVA: 0x00056AA9 File Offset: 0x00054CA9
		public Brush(Pixmap pixmap)
		{
			Assert.NotNull<Pixmap>(pixmap);
			this.ptr = QBrush.FromImage(pixmap.ptr);
		}

		// Token: 0x060014EF RID: 5359 RVA: 0x00056AC8 File Offset: 0x00054CC8
		~Brush()
		{
			MainThread.QueueDispose(this.ptr);
			this.ptr = default(QBrush);
		}

		// Token: 0x0400042D RID: 1069
		internal QBrush ptr;
	}
}
