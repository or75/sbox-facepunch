using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000BB RID: 187
	public class BoxLayout : Layout
	{
		// Token: 0x0600157E RID: 5502 RVA: 0x00057908 File Offset: 0x00055B08
		public BoxLayout(BoxLayout.Direction direction, Widget parent)
		{
			this.NativeInit(QBoxLayout.Create(direction, (parent != null) ? parent._widget : default(QWidget)));
		}

		/// <summary>
		/// Add a spacing item
		/// </summary>
		// Token: 0x0600157F RID: 5503 RVA: 0x00057940 File Offset: 0x00055B40
		public void AddSpacingCell(int size)
		{
			this._boxlayout.addSpacing(size);
		}

		/// <summary>
		/// Add a atretch item
		/// </summary>
		// Token: 0x06001580 RID: 5504 RVA: 0x0005794E File Offset: 0x00055B4E
		public void AddStretchCell(int stretch = 0)
		{
			this._boxlayout.addStretch(stretch);
		}

		// Token: 0x06001581 RID: 5505 RVA: 0x0005795C File Offset: 0x00055B5C
		public int GetCellStretch(int index)
		{
			return this._boxlayout.stretch(index);
		}

		// Token: 0x06001582 RID: 5506 RVA: 0x0005796A File Offset: 0x00055B6A
		public void SetCellStretch(int index, int stretch)
		{
			this._boxlayout.setStretch(index, stretch);
		}

		// Token: 0x06001583 RID: 5507 RVA: 0x00057979 File Offset: 0x00055B79
		public void SetCellStretch(Widget widget, int stretch)
		{
			if (!widget.IsValid())
			{
				throw new ArgumentNullException("widget");
			}
			this._boxlayout.setStretchFactor(widget._widget, stretch);
		}

		// Token: 0x06001584 RID: 5508 RVA: 0x000579A1 File Offset: 0x00055BA1
		public void SetCellStretch(Layout layout, int stretch)
		{
			if (!layout.IsValid())
			{
				throw new ArgumentNullException("layout");
			}
			this._boxlayout.setStretchFactor(layout._layout, stretch);
		}

		// Token: 0x06001585 RID: 5509 RVA: 0x000579C9 File Offset: 0x00055BC9
		public override T Add<T>(T widget, int stretch = 0)
		{
			if (!widget.IsValid())
			{
				throw new ArgumentNullException("widget");
			}
			this._boxlayout.addWidget(widget._widget, stretch);
			return widget;
		}

		// Token: 0x06001586 RID: 5510 RVA: 0x000579FB File Offset: 0x00055BFB
		public override Layout Add(Layout layout, int stretch = 0)
		{
			if (!layout.IsValid())
			{
				throw new ArgumentNullException("layout");
			}
			this._boxlayout.addLayout(layout._layout, stretch);
			return layout;
		}

		// Token: 0x06001587 RID: 5511 RVA: 0x00057A23 File Offset: 0x00055C23
		internal override void NativeInit(IntPtr ptr)
		{
			this._boxlayout = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x06001588 RID: 5512 RVA: 0x00057A38 File Offset: 0x00055C38
		internal override void NativeShutdown()
		{
			this._boxlayout = default(QBoxLayout);
			base.NativeShutdown();
		}

		// Token: 0x04000471 RID: 1137
		internal QBoxLayout _boxlayout;

		// Token: 0x0200014F RID: 335
		public enum Direction
		{
			// Token: 0x040012C1 RID: 4801
			LeftToRight,
			// Token: 0x040012C2 RID: 4802
			RightToLeft,
			// Token: 0x040012C3 RID: 4803
			TopToBottom,
			// Token: 0x040012C4 RID: 4804
			BottomToTop
		}
	}
}
