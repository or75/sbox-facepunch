using System;
using Native;

namespace Tools
{
	// Token: 0x020000C4 RID: 196
	public class ScrollBar : Widget
	{
		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06001662 RID: 5730 RVA: 0x0005955C File Offset: 0x0005775C
		// (set) Token: 0x06001663 RID: 5731 RVA: 0x00059569 File Offset: 0x00057769
		public int Minimum
		{
			get
			{
				return this._scrollbar.minimum();
			}
			set
			{
				this._scrollbar.setMinimum(value);
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06001664 RID: 5732 RVA: 0x00059577 File Offset: 0x00057777
		// (set) Token: 0x06001665 RID: 5733 RVA: 0x00059584 File Offset: 0x00057784
		public int Maximum
		{
			get
			{
				return this._scrollbar.maximum();
			}
			set
			{
				this._scrollbar.setMaximum(value);
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06001666 RID: 5734 RVA: 0x00059592 File Offset: 0x00057792
		// (set) Token: 0x06001667 RID: 5735 RVA: 0x0005959F File Offset: 0x0005779F
		public int SliderPosition
		{
			get
			{
				return this._scrollbar.sliderPosition();
			}
			set
			{
				this._scrollbar.setSliderPosition(value);
			}
		}

		// Token: 0x06001668 RID: 5736 RVA: 0x000595AD File Offset: 0x000577AD
		public ScrollBar(IntPtr ptr)
		{
			this.NativeInit(ptr);
		}

		// Token: 0x06001669 RID: 5737 RVA: 0x000595BC File Offset: 0x000577BC
		internal override void NativeInit(IntPtr ptr)
		{
			this._scrollbar = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x0600166A RID: 5738 RVA: 0x000595D1 File Offset: 0x000577D1
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._scrollbar = default(QScrollBar);
		}

		// Token: 0x04000499 RID: 1177
		private QScrollBar _scrollbar;
	}
}
