using System;
using System.Collections.Generic;
using System.Linq;
using Native;
using Sandbox;
using Sandbox.Internal;

namespace Tools
{
	// Token: 0x020000D2 RID: 210
	public class Window : Widget
	{
		// Token: 0x170001BB RID: 443
		// (get) Token: 0x0600177C RID: 6012 RVA: 0x0005B017 File Offset: 0x00059217
		// (set) Token: 0x0600177D RID: 6013 RVA: 0x0005B01F File Offset: 0x0005921F
		public string StateCookie
		{
			get
			{
				return this._stateCookie;
			}
			set
			{
				if (this._stateCookie == value)
				{
					return;
				}
				this._stateCookie = value;
				this.RestoreFromStateCookie();
			}
		}

		// Token: 0x0600177E RID: 6014 RVA: 0x0005B040 File Offset: 0x00059240
		public virtual void RestoreFromStateCookie()
		{
			string state = GlobalToolsNamespace.Cookie.GetString("Window." + this.StateCookie + ".State", null);
			string geo = GlobalToolsNamespace.Cookie.GetString("Window." + this.StateCookie + ".Geometry", null);
			if (geo != null)
			{
				base.RestoreGeometry(geo);
			}
			if (state != null)
			{
				this.RestoreState(state);
			}
		}

		// Token: 0x0600177F RID: 6015 RVA: 0x0005B0A4 File Offset: 0x000592A4
		[Event("app.exit")]
		public virtual void SaveToStateCookie()
		{
			if (string.IsNullOrWhiteSpace(this.StateCookie))
			{
				return;
			}
			string state = this.SaveState(0);
			string geo = base.SaveGeometry();
			GlobalToolsNamespace.Cookie.SetString("Window." + this.StateCookie + ".State", state);
			GlobalToolsNamespace.Cookie.SetString("Window." + this.StateCookie + ".Geometry", geo);
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06001780 RID: 6016 RVA: 0x0005B10E File Offset: 0x0005930E
		// (set) Token: 0x06001781 RID: 6017 RVA: 0x0005B11C File Offset: 0x0005931C
		public string Title
		{
			get
			{
				return this._mainWindow.windowTitle();
			}
			set
			{
				this._mainWindow.setWindowTitle(value);
				TitleBar tb = this.MenuWidget as TitleBar;
				if (tb != null)
				{
					tb.Title = value;
				}
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06001782 RID: 6018 RVA: 0x0005B14B File Offset: 0x0005934B
		// (set) Token: 0x06001783 RID: 6019 RVA: 0x0005B154 File Offset: 0x00059354
		public Widget Canvas
		{
			get
			{
				return this._canvas;
			}
			set
			{
				this._canvas = value;
				Widget canvas = this._canvas;
				this._mainWindow.setCentralWidget((canvas != null) ? canvas._widget : default(QWidget));
			}
		}

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06001784 RID: 6020 RVA: 0x0005B18D File Offset: 0x0005938D
		// (set) Token: 0x06001785 RID: 6021 RVA: 0x0005B197 File Offset: 0x00059397
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

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x06001786 RID: 6022 RVA: 0x0005B1A4 File Offset: 0x000593A4
		// (set) Token: 0x06001787 RID: 6023 RVA: 0x0005B1DC File Offset: 0x000593DC
		public virtual MenuBar MenuBar
		{
			get
			{
				MenuBar mb = this.MenuWidget as MenuBar;
				if (mb != null)
				{
					return mb;
				}
				TitleBar tb = this.MenuWidget as TitleBar;
				if (tb != null)
				{
					return tb.MenuBar;
				}
				return null;
			}
			set
			{
				this._mainWindow.setMenuBar((value != null) ? value._menubar : default(QMenuBar));
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06001788 RID: 6024 RVA: 0x0005B208 File Offset: 0x00059408
		// (set) Token: 0x06001789 RID: 6025 RVA: 0x0005B210 File Offset: 0x00059410
		public Widget MenuWidget
		{
			get
			{
				return this._menu;
			}
			set
			{
				if (this._menu == value)
				{
					return;
				}
				this._menu = value;
				Widget menu = this._menu;
				this._mainWindow.setMenuWidget((menu != null) ? menu._widget : default(QWidget));
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x0600178A RID: 6026 RVA: 0x0005B253 File Offset: 0x00059453
		// (set) Token: 0x0600178B RID: 6027 RVA: 0x0005B25C File Offset: 0x0005945C
		public StatusBar StatusBar
		{
			get
			{
				return this._status;
			}
			set
			{
				if (this._status == value)
				{
					return;
				}
				this._status = value;
				StatusBar status = this._status;
				this._mainWindow.setStatusBar((status != null) ? status._statusbar : default(QStatusBar));
			}
		}

		// Token: 0x0600178C RID: 6028 RVA: 0x0005B2A0 File Offset: 0x000594A0
		public Window(Widget parent = null)
		{
			InteropSystem.Alloc<Window>(this);
			this._nativeWindow = CManagedMainWindow.Create((parent != null) ? parent._widget : default(QWidget), this);
			this.NativeInit(this._nativeWindow);
			this.MenuWidget = new TitleBar(this);
			this.DeleteOnClose = true;
			this._mainWindow.setAnimated(false);
			this.SetIcon("window/icon.png");
		}

		// Token: 0x0600178D RID: 6029 RVA: 0x0005B320 File Offset: 0x00059520
		internal Window(CFramelessMainWindow ptr)
		{
			InteropSystem.Alloc<Window>(this);
			this._nativeWindow = ptr;
			this.NativeInit(this._nativeWindow);
			TitleBar tb = new TitleBar(this);
			this.MenuWidget = tb;
			this.DeleteOnClose = true;
			this._mainWindow.setAnimated(false);
			ptr.setProxyControls(tb.TitleLabel._label, tb.MenuBar._menubar, tb.IconButton._button);
			this.Title = this.Title;
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x0600178F RID: 6031 RVA: 0x0005B3FD File Offset: 0x000595FD
		// (set) Token: 0x0600178E RID: 6030 RVA: 0x0005B3AC File Offset: 0x000595AC
		public bool IsDialog
		{
			get
			{
				return this._mainWindow.windowFlags().HasFlag(WindowFlags.Dialog);
			}
			set
			{
				if (this.IsDialog)
				{
					return;
				}
				if (value)
				{
					this._mainWindow.setWindowFlags((WindowFlags)259);
				}
				else
				{
					this._mainWindow.setWindowFlags((WindowFlags)134270976);
				}
				TitleBar tb = this.MenuWidget as TitleBar;
				if (tb != null)
				{
					tb.SetDialogMode(value);
				}
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06001791 RID: 6033 RVA: 0x0005B444 File Offset: 0x00059644
		// (set) Token: 0x06001790 RID: 6032 RVA: 0x0005B41C File Offset: 0x0005961C
		public bool CloseButtonVisible
		{
			get
			{
				TitleBar tb = this.MenuWidget as TitleBar;
				return tb != null && tb.CloseButton.Visible;
			}
			set
			{
				TitleBar tb = this.MenuWidget as TitleBar;
				if (tb != null)
				{
					tb.CloseButton.Visible = value;
				}
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06001793 RID: 6035 RVA: 0x0005B4A4 File Offset: 0x000596A4
		// (set) Token: 0x06001792 RID: 6034 RVA: 0x0005B470 File Offset: 0x00059670
		public bool ResizeButtonsVisible
		{
			get
			{
				TitleBar tb = this.MenuWidget as TitleBar;
				return tb != null && tb.MaximizeButton.Visible;
			}
			set
			{
				TitleBar tb = this.MenuWidget as TitleBar;
				if (tb != null)
				{
					tb.MaximizeButton.Visible = value;
					tb.MinimizeButton.Visible = value;
				}
			}
		}

		// Token: 0x06001794 RID: 6036 RVA: 0x0005B4CD File Offset: 0x000596CD
		internal static void InitFramelessWindow(CFramelessMainWindow ptr)
		{
			new Window(ptr);
		}

		// Token: 0x06001795 RID: 6037 RVA: 0x0005B4D8 File Offset: 0x000596D8
		public void SetIcon(string name)
		{
			this._mainWindow.setWindowIcon(name);
			TitleBar tb = this.MenuWidget as TitleBar;
			if (tb != null)
			{
				tb.Icon = name;
			}
		}

		// Token: 0x06001796 RID: 6038 RVA: 0x0005B508 File Offset: 0x00059708
		internal override void NativeInit(IntPtr ptr)
		{
			this._mainWindow = ptr;
			if (this._mainWindow == default(QMainWindow))
			{
				throw new Exception("_mainWindow was null!");
			}
			base.NativeInit(ptr);
			Window.All.Add(this);
			this.MenuWidget = new MenuBar(this._mainWindow.menuBar());
			this.StatusBar = new StatusBar(this._mainWindow.statusBar());
		}

		// Token: 0x06001797 RID: 6039 RVA: 0x0005B580 File Offset: 0x00059780
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._mainWindow = default(QMainWindow);
			this._nativeWindow = default(CFramelessMainWindow);
			Window.All.Remove(this);
		}

		// Token: 0x06001798 RID: 6040 RVA: 0x0005B5AC File Offset: 0x000597AC
		public void Show()
		{
			this._mainWindow.show();
		}

		// Token: 0x06001799 RID: 6041 RVA: 0x0005B5B9 File Offset: 0x000597B9
		public void Hide()
		{
			this._mainWindow.hide();
		}

		// Token: 0x0600179A RID: 6042 RVA: 0x0005B5C6 File Offset: 0x000597C6
		public void MakeMinimized()
		{
			this._mainWindow.showMinimized();
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x0600179B RID: 6043 RVA: 0x0005B5D3 File Offset: 0x000597D3
		public bool IsMinimized
		{
			get
			{
				return this._mainWindow.isMinimized();
			}
		}

		// Token: 0x0600179C RID: 6044 RVA: 0x0005B5E0 File Offset: 0x000597E0
		public void MakeMaximized()
		{
			this._mainWindow.showMaximized();
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x0600179D RID: 6045 RVA: 0x0005B5ED File Offset: 0x000597ED
		public bool IsMaximized
		{
			get
			{
				return this._mainWindow.isMaximized();
			}
		}

		// Token: 0x0600179E RID: 6046 RVA: 0x0005B5FA File Offset: 0x000597FA
		public void MakeWindowed()
		{
			this._mainWindow.showNormal();
		}

		// Token: 0x0600179F RID: 6047 RVA: 0x0005B607 File Offset: 0x00059807
		public void Dock(DockWidget widget, DockArea area, DockWidget parent = null)
		{
			if (parent != null)
			{
				this.DockInTab(parent, widget);
				return;
			}
			this._mainWindow.addDockWidget(area, widget._dockwidget);
		}

		// Token: 0x060017A0 RID: 6048 RVA: 0x0005B627 File Offset: 0x00059827
		public void DockInTab(DockWidget parent, DockWidget widget)
		{
			this._mainWindow.tabifyDockWidget(parent._dockwidget, widget._dockwidget);
		}

		// Token: 0x060017A1 RID: 6049 RVA: 0x0005B640 File Offset: 0x00059840
		public DockWidget FindOrCreateDock(string name, string icon, DockArea area = DockArea.Left, string parentDock = null)
		{
			DockWidget child = base.Children.OfType<DockWidget>().FirstOrDefault((DockWidget x) => x.Name == name);
			if (child != null)
			{
				return child;
			}
			DockWidget parent = base.Children.OfType<DockWidget>().FirstOrDefault((DockWidget x) => x.Name == parentDock);
			DockWidget dw = new DockWidget(name, icon, this, name);
			this.Dock(dw, area, parent);
			dw.Visible = false;
			return dw;
		}

		// Token: 0x060017A2 RID: 6050 RVA: 0x0005B6C6 File Offset: 0x000598C6
		public void Close()
		{
			this.SaveToStateCookie();
			this._mainWindow.close();
		}

		// Token: 0x060017A3 RID: 6051 RVA: 0x0005B6DA File Offset: 0x000598DA
		public void TitlebarDoubleClick()
		{
			if (this._nativeWindow.IsValid)
			{
				this._nativeWindow.NativeWindowDoubleClick();
			}
		}

		// Token: 0x060017A4 RID: 6052 RVA: 0x0005B6F4 File Offset: 0x000598F4
		public void TitlebarPress()
		{
			if (this._nativeWindow.IsValid)
			{
				this._nativeWindow.NativeStartMouseDown(0);
			}
		}

		/// <summary>
		/// TODO this was a test, get rid of it
		/// </summary>
		// Token: 0x060017A5 RID: 6053 RVA: 0x0005B710 File Offset: 0x00059910
		public void Clear()
		{
			if (!this._mainWindow.IsValid)
			{
				return;
			}
			MenuBar mb = this.MenuBar;
			if (mb != null)
			{
				mb.Clear();
			}
			foreach (DockWidget dockWidget in base.Children.OfType<DockWidget>())
			{
				if (dockWidget != null)
				{
					dockWidget.Destroy();
				}
			}
			Widget canvas = this.Canvas;
			if (canvas != null)
			{
				canvas.Destroy();
			}
			this.Canvas = null;
		}

		// Token: 0x060017A6 RID: 6054 RVA: 0x0005B79C File Offset: 0x0005999C
		internal void InternalCloseEvent(IntPtr close)
		{
			this.OnClose(new CloseEvent
			{
				ptr = close
			});
		}

		// Token: 0x060017A7 RID: 6055 RVA: 0x0005B7C5 File Offset: 0x000599C5
		public virtual void OnClose(CloseEvent e)
		{
			this.SaveToStateCookie();
		}

		// Token: 0x060017A8 RID: 6056 RVA: 0x0005B7CD File Offset: 0x000599CD
		public void AddToolBar(ToolBar bar, ToolbarPosition position = ToolbarPosition.Top)
		{
			this._mainWindow.addToolBar(position, bar._toolbar);
		}

		// Token: 0x060017A9 RID: 6057 RVA: 0x0005B7E1 File Offset: 0x000599E1
		public void RemoveToolBar(ToolBar bar)
		{
			this._mainWindow.removeToolBar(bar._toolbar);
		}

		// Token: 0x060017AA RID: 6058 RVA: 0x0005B7F4 File Offset: 0x000599F4
		public string SaveState(int version = 0)
		{
			return this._mainWindow.saveState(version);
		}

		// Token: 0x060017AB RID: 6059 RVA: 0x0005B802 File Offset: 0x00059A02
		public void RestoreState(string state)
		{
			this._mainWindow.restoreState(state);
		}

		// Token: 0x060017AC RID: 6060 RVA: 0x0005B811 File Offset: 0x00059A11
		protected override void OnBlur(FocusChangeReason reason)
		{
			base.OnBlur(reason);
			this.SaveToStateCookie();
		}

		// Token: 0x040004D6 RID: 1238
		private string _stateCookie;

		// Token: 0x040004D7 RID: 1239
		public static List<Window> All = new List<Window>();

		// Token: 0x040004D8 RID: 1240
		private QMainWindow _mainWindow;

		// Token: 0x040004D9 RID: 1241
		private CFramelessMainWindow _nativeWindow;

		// Token: 0x040004DA RID: 1242
		private Widget _canvas;

		// Token: 0x040004DB RID: 1243
		private Widget _menu;

		// Token: 0x040004DC RID: 1244
		private StatusBar _status;
	}
}
