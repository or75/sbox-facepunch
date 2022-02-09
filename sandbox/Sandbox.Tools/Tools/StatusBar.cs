using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000C5 RID: 197
	public class StatusBar : Widget
	{
		// Token: 0x0600166B RID: 5739 RVA: 0x000595E5 File Offset: 0x000577E5
		internal StatusBar(QStatusBar widget)
		{
			this.NativeInit(widget);
		}

		// Token: 0x0600166C RID: 5740 RVA: 0x000595FC File Offset: 0x000577FC
		public StatusBar(Widget parent)
		{
			InteropSystem.Alloc<StatusBar>(this);
			this.NativeInit(CStatusBar.Create((parent != null) ? parent._widget : default(QWidget), this));
			this.SizeGrip = false;
		}

		// Token: 0x0600166D RID: 5741 RVA: 0x00059641 File Offset: 0x00057841
		internal override void NativeInit(IntPtr ptr)
		{
			this._statusbar = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x0600166E RID: 5742 RVA: 0x00059656 File Offset: 0x00057856
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._statusbar = default(QStatusBar);
		}

		// Token: 0x0600166F RID: 5743 RVA: 0x0005966A File Offset: 0x0005786A
		public void AddWidgetLeft(Widget w, int stretch = 0)
		{
			this._statusbar.addWidget(w._widget, stretch);
		}

		// Token: 0x06001670 RID: 5744 RVA: 0x0005967E File Offset: 0x0005787E
		public void RemoveWidget(Widget w)
		{
			this._statusbar.removeWidget(w._widget);
		}

		// Token: 0x06001671 RID: 5745 RVA: 0x00059691 File Offset: 0x00057891
		public void AddWidgetRight(Widget w, int stretch = 0)
		{
			this._statusbar.addPermanentWidget(w._widget, stretch);
		}

		// Token: 0x06001672 RID: 5746 RVA: 0x000596A5 File Offset: 0x000578A5
		public void ShowMessage(string text, float seconds = 5f)
		{
			this._statusbar.showMessage(text, (int)(seconds * 1000f));
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06001673 RID: 5747 RVA: 0x000596BB File Offset: 0x000578BB
		// (set) Token: 0x06001674 RID: 5748 RVA: 0x000596C8 File Offset: 0x000578C8
		public bool SizeGrip
		{
			get
			{
				return this._statusbar.isSizeGripEnabled();
			}
			set
			{
				this._statusbar.setSizeGripEnabled(value);
			}
		}

		// Token: 0x0400049A RID: 1178
		internal QStatusBar _statusbar;
	}
}
