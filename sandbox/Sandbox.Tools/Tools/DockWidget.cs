using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x02000096 RID: 150
	public class DockWidget : Widget
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06001467 RID: 5223 RVA: 0x00055DC4 File Offset: 0x00053FC4
		// (set) Token: 0x06001468 RID: 5224 RVA: 0x00055DD1 File Offset: 0x00053FD1
		public string Title
		{
			get
			{
				return this._dockwidget.windowTitle();
			}
			set
			{
				this._dockwidget.setWindowTitle(value);
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06001469 RID: 5225 RVA: 0x00055DDF File Offset: 0x00053FDF
		// (set) Token: 0x0600146A RID: 5226 RVA: 0x00055DE8 File Offset: 0x00053FE8
		public Widget Widget
		{
			get
			{
				return this._innerwidget;
			}
			set
			{
				this._innerwidget = value;
				Widget innerwidget = this._innerwidget;
				this._dockwidget.setWidget((innerwidget != null) ? innerwidget._widget : default(QWidget));
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600146B RID: 5227 RVA: 0x00055E21 File Offset: 0x00054021
		// (set) Token: 0x0600146C RID: 5228 RVA: 0x00055E2B File Offset: 0x0005402B
		public bool DeleteOnClose
		{
			get
			{
				return base.HasFlag(Widget.Flag.DeleteOnClose);
			}
			set
			{
				base.SetFlag(Widget.Flag.DeleteOnClose, true);
			}
		}

		// Token: 0x0600146D RID: 5229 RVA: 0x00055E38 File Offset: 0x00054038
		public DockWidget(string title, string icon = null, Widget parent = null, string name = null)
		{
			InteropSystem.Alloc<DockWidget>(this);
			QDockWidget ptr = CDockWidget.Create((parent != null) ? parent._widget : default(QWidget), this);
			this.NativeInit(ptr);
			if (title != null)
			{
				this.Title = title;
			}
			if (!string.IsNullOrEmpty(icon))
			{
				this.SetIcon(icon);
			}
			if (name != null)
			{
				base.Name = name;
			}
			this._dockwidget.setFeatures((DockWidgetFeatures)7);
		}

		// Token: 0x0600146E RID: 5230 RVA: 0x00055EA9 File Offset: 0x000540A9
		public void SetIcon(string icon)
		{
			this._dockwidget.setIcon(icon);
		}

		// Token: 0x0600146F RID: 5231 RVA: 0x00055EB7 File Offset: 0x000540B7
		internal override void NativeInit(IntPtr ptr)
		{
			base.NativeInit(ptr);
			this._dockwidget = ptr;
		}

		// Token: 0x06001470 RID: 5232 RVA: 0x00055ECC File Offset: 0x000540CC
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._dockwidget = default(QDockWidget);
		}

		// Token: 0x06001471 RID: 5233 RVA: 0x00055EE0 File Offset: 0x000540E0
		public void Show()
		{
			this._dockwidget.show();
		}

		// Token: 0x06001472 RID: 5234 RVA: 0x00055EED File Offset: 0x000540ED
		public void Hide()
		{
			this._dockwidget.hide();
		}

		// Token: 0x06001473 RID: 5235 RVA: 0x00055EFA File Offset: 0x000540FA
		public void MakeMinimized()
		{
			this._dockwidget.showMinimized();
		}

		// Token: 0x06001474 RID: 5236 RVA: 0x00055F07 File Offset: 0x00054107
		public void MakeMaximized()
		{
			this._dockwidget.showMaximized();
		}

		// Token: 0x06001475 RID: 5237 RVA: 0x00055F14 File Offset: 0x00054114
		public void MakeWindowed()
		{
			this._dockwidget.showNormal();
		}

		// Token: 0x06001476 RID: 5238 RVA: 0x00055F21 File Offset: 0x00054121
		public Option GetToggleViewOption()
		{
			return new Option(this._dockwidget.toggleViewAction());
		}

		// Token: 0x040001F9 RID: 505
		internal QDockWidget _dockwidget;

		// Token: 0x040001FA RID: 506
		private Widget _innerwidget;
	}
}
