using System;
using System.Collections.Generic;
using Native;

namespace Tools
{
	// Token: 0x020000AC RID: 172
	internal class GraphicsScene : QObject
	{
		// Token: 0x060014C6 RID: 5318 RVA: 0x000565B5 File Offset: 0x000547B5
		internal GraphicsScene(IntPtr widget)
		{
			this.NativeInit(widget);
		}

		// Token: 0x060014C7 RID: 5319 RVA: 0x000565D0 File Offset: 0x000547D0
		internal GraphicsScene(GraphicsView parent)
		{
			this.View = parent;
			QGraphicsScene ptr = WidgetUtil.CreateGraphicsScene(parent._object, parent);
			this.NativeInit(ptr);
		}

		// Token: 0x060014C8 RID: 5320 RVA: 0x0005660E File Offset: 0x0005480E
		internal override void NativeInit(IntPtr ptr)
		{
			this._scene = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x060014C9 RID: 5321 RVA: 0x00056624 File Offset: 0x00054824
		internal override void NativeShutdown()
		{
			this._scene = default(QGraphicsScene);
			base.NativeShutdown();
			foreach (KeyValuePair<IntPtr, GraphicsItem> item in this.Items)
			{
				item.Value.NativeShutdown();
			}
			this.Items.Clear();
		}

		// Token: 0x060014CA RID: 5322 RVA: 0x0005669C File Offset: 0x0005489C
		public void Add(GraphicsItem t)
		{
			t.Scene = this;
			this._scene.addItem(t._graphicsitem);
			this.Items[t._graphicsitem] = t;
		}

		// Token: 0x060014CB RID: 5323 RVA: 0x000566CD File Offset: 0x000548CD
		internal void RemoveInternal(GraphicsItem item)
		{
			this._scene.removeItem(item._graphicsitem);
			this.Items.Remove(item._graphicsitem);
		}

		// Token: 0x060014CC RID: 5324 RVA: 0x000566F8 File Offset: 0x000548F8
		public GraphicsWidget Add(Widget t)
		{
			GraphicsWidget pw = new GraphicsWidget(t, null);
			this.Add(pw);
			return pw;
		}

		// Token: 0x0400041C RID: 1052
		private GraphicsView View;

		// Token: 0x0400041D RID: 1053
		internal QGraphicsScene _scene;

		// Token: 0x0400041E RID: 1054
		private Dictionary<IntPtr, GraphicsItem> Items = new Dictionary<IntPtr, GraphicsItem>();
	}
}
