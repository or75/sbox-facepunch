using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000B7 RID: 183
	public class GraphicsWidget : GraphicsItem
	{
		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600155B RID: 5467 RVA: 0x0005757B File Offset: 0x0005577B
		// (set) Token: 0x0600155C RID: 5468 RVA: 0x00057583 File Offset: 0x00055783
		public Widget Widget
		{
			get
			{
				return this.embeddedWidget;
			}
			set
			{
				this.embeddedWidget = value;
				Widget widget = this.embeddedWidget;
				this._proxyWidget.setWidget((widget != null) ? widget._widget : IntPtr.Zero);
			}
		}

		// Token: 0x0600155D RID: 5469 RVA: 0x000575B4 File Offset: 0x000557B4
		public GraphicsWidget(Widget widget, GraphicsItem parent = null)
			: base(null)
		{
			InteropSystem.Alloc<GraphicsWidget>(this);
			this.NativeInit(WidgetUtil.CreateGraphicsProxy(parent.IsValid() ? parent._graphicsitem : IntPtr.Zero, this));
			this.Widget = widget;
			base.Parent = parent;
			this.NoSystemBackground = true;
		}

		// Token: 0x0600155E RID: 5470 RVA: 0x00057610 File Offset: 0x00055810
		public GraphicsWidget(GraphicsItem parent = null)
			: base(null)
		{
			InteropSystem.Alloc<GraphicsWidget>(this);
			this.NativeInit(WidgetUtil.CreateGraphicsProxy(parent.IsValid() ? parent._graphicsitem : IntPtr.Zero, this));
			base.Parent = parent;
			this.NoSystemBackground = true;
		}

		// Token: 0x0600155F RID: 5471 RVA: 0x00057663 File Offset: 0x00055863
		internal override void NativeInit(QGraphicsItem ptr)
		{
			this._proxyWidget = (QGraphicsProxyWidget)ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x06001560 RID: 5472 RVA: 0x00057678 File Offset: 0x00055878
		internal override void NativeShutdown()
		{
			this._proxyWidget = default(QGraphicsProxyWidget);
			base.NativeShutdown();
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06001561 RID: 5473 RVA: 0x0005768C File Offset: 0x0005588C
		// (set) Token: 0x06001562 RID: 5474 RVA: 0x0005769E File Offset: 0x0005589E
		public override Vector2 Size
		{
			get
			{
				return this._proxyWidget.size();
			}
			set
			{
				this._proxyWidget.resize(value);
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06001563 RID: 5475 RVA: 0x000576B1 File Offset: 0x000558B1
		// (set) Token: 0x06001564 RID: 5476 RVA: 0x000576BB File Offset: 0x000558BB
		public bool TranslucentBackground
		{
			get
			{
				return this.HasFlag(Widget.Flag.WA_TranslucentBackground);
			}
			set
			{
				this.SetFlag(Widget.Flag.WA_TranslucentBackground, value);
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06001565 RID: 5477 RVA: 0x000576C6 File Offset: 0x000558C6
		// (set) Token: 0x06001566 RID: 5478 RVA: 0x000576D0 File Offset: 0x000558D0
		public bool NoSystemBackground
		{
			get
			{
				return this.HasFlag(Widget.Flag.WA_NoSystemBackground);
			}
			set
			{
				this.SetFlag(Widget.Flag.WA_NoSystemBackground, value);
			}
		}

		// Token: 0x06001567 RID: 5479 RVA: 0x000576DB File Offset: 0x000558DB
		internal void SetFlag(Widget.Flag f, bool b)
		{
			this._proxyWidget.setAttribute(f, b);
		}

		// Token: 0x06001568 RID: 5480 RVA: 0x000576EA File Offset: 0x000558EA
		internal bool HasFlag(Widget.Flag f)
		{
			return this._proxyWidget.testAttribute(f);
		}

		// Token: 0x06001569 RID: 5481 RVA: 0x000576F8 File Offset: 0x000558F8
		internal void Poop()
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000459 RID: 1113
		private QGraphicsProxyWidget _proxyWidget;

		// Token: 0x0400045A RID: 1114
		private Widget embeddedWidget;
	}
}
