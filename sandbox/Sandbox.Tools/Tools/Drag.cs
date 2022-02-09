using System;

namespace Tools
{
	// Token: 0x02000099 RID: 153
	public class Drag : QObject
	{
		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06001477 RID: 5239 RVA: 0x00055F38 File Offset: 0x00054138
		// (set) Token: 0x06001478 RID: 5240 RVA: 0x00055F40 File Offset: 0x00054140
		public DragData Data { get; private set; }

		// Token: 0x06001479 RID: 5241 RVA: 0x00055F49 File Offset: 0x00054149
		public Drag(QObject parent)
		{
			this.NativeInit(QDrag.Create(parent._object));
			this.Data = new DragData();
			this._drag.setMimeData(this.Data._data);
		}

		// Token: 0x0600147A RID: 5242 RVA: 0x00055F88 File Offset: 0x00054188
		public Drag(GraphicsMouseEvent e)
		{
			this.NativeInit(QDrag.Create(e.ptr.widget()));
			this.Data = new DragData();
			this._drag.setMimeData(this.Data._data);
		}

		// Token: 0x0600147B RID: 5243 RVA: 0x00055FDD File Offset: 0x000541DD
		internal override void NativeInit(IntPtr ptr)
		{
			this._drag = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x0600147C RID: 5244 RVA: 0x00055FF2 File Offset: 0x000541F2
		internal override void NativeShutdown()
		{
			this._drag = default(QDrag);
			base.NativeShutdown();
		}

		// Token: 0x0600147D RID: 5245 RVA: 0x00056006 File Offset: 0x00054206
		public void Execute()
		{
			this._drag.exec();
		}

		// Token: 0x04000208 RID: 520
		internal QDrag _drag;
	}
}
