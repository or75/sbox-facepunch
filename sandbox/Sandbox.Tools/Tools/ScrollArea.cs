using System;
using Native;

namespace Tools
{
	// Token: 0x020000C3 RID: 195
	public class ScrollArea : Frame
	{
		// Token: 0x06001653 RID: 5715 RVA: 0x000593EE File Offset: 0x000575EE
		internal ScrollArea(IntPtr widget)
		{
			this.NativeInit(widget);
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06001654 RID: 5716 RVA: 0x000593FD File Offset: 0x000575FD
		// (set) Token: 0x06001655 RID: 5717 RVA: 0x00059405 File Offset: 0x00057605
		public ScrollBar VerticalScrollbar { get; set; }

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06001656 RID: 5718 RVA: 0x0005940E File Offset: 0x0005760E
		// (set) Token: 0x06001657 RID: 5719 RVA: 0x00059416 File Offset: 0x00057616
		public ScrollBar HorizontalScrollbar { get; set; }

		// Token: 0x06001658 RID: 5720 RVA: 0x00059420 File Offset: 0x00057620
		public ScrollArea(Widget parent)
		{
			QScrollArea ptr = QScrollArea.CreateQScrollArea((parent != null) ? parent._widget : default(QWidget));
			this.NativeInit(ptr);
			this._scrollarea.setWidgetResizable(true);
			this.VerticalScrollbar = new ScrollBar(this._scrollarea.verticalScrollBar());
			this.HorizontalScrollbar = new ScrollBar(this._scrollarea.horizontalScrollBar());
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06001659 RID: 5721 RVA: 0x0005949B File Offset: 0x0005769B
		// (set) Token: 0x0600165A RID: 5722 RVA: 0x000594A4 File Offset: 0x000576A4
		public Widget Canvas
		{
			get
			{
				return this._canvas;
			}
			set
			{
				this._canvas = value;
				this._scrollarea.setWidget((value != null) ? value._widget : default(QWidget));
				if (value != null)
				{
					value._widget.setAutoFillBackground(false);
				}
			}
		}

		// Token: 0x0600165B RID: 5723 RVA: 0x000594E6 File Offset: 0x000576E6
		internal override void NativeInit(IntPtr ptr)
		{
			this._scrollarea = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x0600165C RID: 5724 RVA: 0x000594FB File Offset: 0x000576FB
		internal override void NativeShutdown()
		{
			this._scrollarea = default(QScrollArea);
			base.NativeShutdown();
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x0600165D RID: 5725 RVA: 0x0005950F File Offset: 0x0005770F
		// (set) Token: 0x0600165E RID: 5726 RVA: 0x0005951C File Offset: 0x0005771C
		public ScrollbarMode HorizontalScrollbarMode
		{
			get
			{
				return this._scrollarea.horizontalScrollBarPolicy();
			}
			set
			{
				this._scrollarea.setHorizontalScrollBarPolicy(value);
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x0600165F RID: 5727 RVA: 0x0005952A File Offset: 0x0005772A
		// (set) Token: 0x06001660 RID: 5728 RVA: 0x00059537 File Offset: 0x00057737
		public ScrollbarMode VerticalScrollbarMode
		{
			get
			{
				return this._scrollarea.verticalScrollBarPolicy();
			}
			set
			{
				this._scrollarea.setVerticalScrollBarPolicy(value);
			}
		}

		// Token: 0x06001661 RID: 5729 RVA: 0x00059545 File Offset: 0x00057745
		public void MakeVisible(Widget widget)
		{
			this._scrollarea.ensureWidgetVisible(widget._widget, 50, 50);
		}

		// Token: 0x04000495 RID: 1173
		internal QScrollArea _scrollarea;

		// Token: 0x04000498 RID: 1176
		private Widget _canvas;
	}
}
