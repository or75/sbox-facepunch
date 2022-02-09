using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000BA RID: 186
	public class Layout : QObject
	{
		// Token: 0x06001573 RID: 5491 RVA: 0x00057810 File Offset: 0x00055A10
		internal override void NativeInit(IntPtr ptr)
		{
			this._layout = ptr;
			base.NativeInit(ptr);
			this.Spacing = 0;
			this.SetContentMargins(0, 0, 0, 0);
		}

		// Token: 0x06001574 RID: 5492 RVA: 0x00057836 File Offset: 0x00055A36
		internal override void NativeShutdown()
		{
			this._layout = default(QLayout);
			base.NativeShutdown();
		}

		// Token: 0x06001575 RID: 5493 RVA: 0x0005784A File Offset: 0x00055A4A
		public virtual T Add<T>(T widget, int stretch = 0) where T : Widget
		{
			if (!widget.IsValid())
			{
				throw new ArgumentNullException("widget");
			}
			this._layout.addWidget(widget._widget);
			return widget;
		}

		// Token: 0x06001576 RID: 5494 RVA: 0x0005787B File Offset: 0x00055A7B
		public virtual Layout Add(Layout layout, int stretch = 0)
		{
			if (!layout.IsValid())
			{
				throw new ArgumentNullException("layout");
			}
			this._layout.addItem(layout._layout);
			return layout;
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06001577 RID: 5495 RVA: 0x000578A2 File Offset: 0x00055AA2
		// (set) Token: 0x06001578 RID: 5496 RVA: 0x000578AF File Offset: 0x00055AAF
		public int Spacing
		{
			get
			{
				return this._layout.spacing();
			}
			set
			{
				this._layout.setSpacing(value);
			}
		}

		// Token: 0x06001579 RID: 5497 RVA: 0x000578BD File Offset: 0x00055ABD
		public void SetContentMargins(int left, int top, int right, int bottom)
		{
			this._layout.setContentsMargins(left, top, right, bottom);
		}

		// Token: 0x0600157A RID: 5498 RVA: 0x000578CF File Offset: 0x00055ACF
		public Layout MakeTopToBottom(int stretch = 0)
		{
			return this.Add(new BoxLayout(BoxLayout.Direction.TopToBottom, null), stretch);
		}

		// Token: 0x0600157B RID: 5499 RVA: 0x000578DF File Offset: 0x00055ADF
		public Layout MakeBottomToTop(int stretch = 0)
		{
			return this.Add(new BoxLayout(BoxLayout.Direction.BottomToTop, null), stretch);
		}

		// Token: 0x0600157C RID: 5500 RVA: 0x000578EF File Offset: 0x00055AEF
		public Layout MakeLeftToRight(int stretch = 0)
		{
			return this.Add(new BoxLayout(BoxLayout.Direction.LeftToRight, null), stretch);
		}

		// Token: 0x04000470 RID: 1136
		internal QLayout _layout;
	}
}
