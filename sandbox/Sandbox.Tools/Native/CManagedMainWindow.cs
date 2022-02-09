using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x0200003B RID: 59
	internal struct CManagedMainWindow
	{
		// Token: 0x06000581 RID: 1409 RVA: 0x0000F355 File Offset: 0x0000D555
		public static implicit operator IntPtr(CManagedMainWindow value)
		{
			return value.self;
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0000F360 File Offset: 0x0000D560
		public static implicit operator CManagedMainWindow(IntPtr value)
		{
			return new CManagedMainWindow
			{
				self = value
			};
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0000F37E File Offset: 0x0000D57E
		public static bool operator ==(CManagedMainWindow c1, CManagedMainWindow c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x0000F391 File Offset: 0x0000D591
		public static bool operator !=(CManagedMainWindow c1, CManagedMainWindow c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x0000F3A4 File Offset: 0x0000D5A4
		public override bool Equals(object obj)
		{
			if (obj is CManagedMainWindow)
			{
				CManagedMainWindow c = (CManagedMainWindow)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x0000F3CE File Offset: 0x0000D5CE
		internal CManagedMainWindow(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x0000F3D8 File Offset: 0x0000D5D8
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CManagedMainWindow ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x0000F414 File Offset: 0x0000D614
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x0000F426 File Offset: 0x0000D626
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x0000F431 File Offset: 0x0000D631
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x0000F444 File Offset: 0x0000D644
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CManagedMainWindow was null when calling " + n);
			}
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x0000F45F File Offset: 0x0000D65F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x0000F46C File Offset: 0x0000D66C
		public static implicit operator CFramelessMainWindow(CManagedMainWindow value)
		{
			method to_CFramelessMainWindow_From_CManagedMainWindow = CManagedMainWindow.__N.To_CFramelessMainWindow_From_CManagedMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, to_CFramelessMainWindow_From_CManagedMainWindow);
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0000F490 File Offset: 0x0000D690
		public static explicit operator CManagedMainWindow(CFramelessMainWindow value)
		{
			method from_CFramelessMainWindow_To_CManagedMainWindow = CManagedMainWindow.__N.From_CFramelessMainWindow_To_CManagedMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, from_CFramelessMainWindow_To_CManagedMainWindow);
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x0000F4B4 File Offset: 0x0000D6B4
		public static implicit operator QMainWindow(CManagedMainWindow value)
		{
			method to_QMainWindow_From_CManagedMainWindow = CManagedMainWindow.__N.To_QMainWindow_From_CManagedMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, to_QMainWindow_From_CManagedMainWindow);
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x0000F4D8 File Offset: 0x0000D6D8
		public static explicit operator CManagedMainWindow(QMainWindow value)
		{
			method from_QMainWindow_To_CManagedMainWindow = CManagedMainWindow.__N.From_QMainWindow_To_CManagedMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, from_QMainWindow_To_CManagedMainWindow);
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x0000F4FC File Offset: 0x0000D6FC
		public static implicit operator QWidget(CManagedMainWindow value)
		{
			method to_QWidget_From_CManagedMainWindow = CManagedMainWindow.__N.To_QWidget_From_CManagedMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_CManagedMainWindow);
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0000F520 File Offset: 0x0000D720
		public static explicit operator CManagedMainWindow(QWidget value)
		{
			method from_QWidget_To_CManagedMainWindow = CManagedMainWindow.__N.From_QWidget_To_CManagedMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_CManagedMainWindow);
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x0000F544 File Offset: 0x0000D744
		public static implicit operator QObject(CManagedMainWindow value)
		{
			method to_QObject_From_CManagedMainWindow = CManagedMainWindow.__N.To_QObject_From_CManagedMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_CManagedMainWindow);
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x0000F568 File Offset: 0x0000D768
		public static explicit operator CManagedMainWindow(QObject value)
		{
			method from_QObject_To_CManagedMainWindow = CManagedMainWindow.__N.From_QObject_To_CManagedMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_CManagedMainWindow);
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x0000F58C File Offset: 0x0000D78C
		internal static CManagedMainWindow Create(QWidget parent, Window managedobj)
		{
			method cmnged_f = CManagedMainWindow.__N.CMnged_f37;
			return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedobj == null) ? 0U : InteropSystem.GetAddress<Window>(managedobj, true), cmnged_f);
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x0000F5C0 File Offset: 0x0000D7C0
		internal readonly void NativeWindowDoubleClick()
		{
			this.NullCheck("NativeWindowDoubleClick");
			method cmnged_NativeWindowDoubleClick = CManagedMainWindow.__N.CMnged_NativeWindowDoubleClick;
			calli(System.Void(System.IntPtr), this.self, cmnged_NativeWindowDoubleClick);
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x0000F5EC File Offset: 0x0000D7EC
		internal readonly void NativeStartMouseDown(int mode)
		{
			this.NullCheck("NativeStartMouseDown");
			method cmnged_NativeStartMouseDown = CManagedMainWindow.__N.CMnged_NativeStartMouseDown;
			calli(System.Void(System.IntPtr,System.Int32), this.self, mode, cmnged_NativeStartMouseDown);
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0000F618 File Offset: 0x0000D818
		internal readonly void setProxyControls(QLabel titleLabel, QMenuBar menuBar, QPushButton icon)
		{
			this.NullCheck("setProxyControls");
			method cmnged_setProxyControls = CManagedMainWindow.__N.CMnged_setProxyControls;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr,System.IntPtr), this.self, titleLabel, menuBar, icon, cmnged_setProxyControls);
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x0000F654 File Offset: 0x0000D854
		internal readonly Vector3 iconSize()
		{
			this.NullCheck("iconSize");
			method cmnged_iconSize = CManagedMainWindow.__N.CMnged_iconSize;
			return calli(Vector3(System.IntPtr), this.self, cmnged_iconSize);
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x0000F680 File Offset: 0x0000D880
		internal readonly void setIconSize(Vector3 iconSize)
		{
			this.NullCheck("setIconSize");
			method cmnged_setIconSize = CManagedMainWindow.__N.CMnged_setIconSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, iconSize, cmnged_setIconSize);
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0000F6AC File Offset: 0x0000D8AC
		internal readonly QMenuBar menuBar()
		{
			this.NullCheck("menuBar");
			method cmnged_menuBar = CManagedMainWindow.__N.CMnged_menuBar;
			return calli(System.IntPtr(System.IntPtr), this.self, cmnged_menuBar);
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0000F6DC File Offset: 0x0000D8DC
		internal readonly void setMenuBar(QMenuBar menubar)
		{
			this.NullCheck("setMenuBar");
			method cmnged_setMenuBar = CManagedMainWindow.__N.CMnged_setMenuBar;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, menubar, cmnged_setMenuBar);
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x0000F70C File Offset: 0x0000D90C
		internal readonly void setMenuWidget(QWidget menubar)
		{
			this.NullCheck("setMenuWidget");
			method cmnged_setMenuWidget = CManagedMainWindow.__N.CMnged_setMenuWidget;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, menubar, cmnged_setMenuWidget);
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0000F73C File Offset: 0x0000D93C
		internal readonly QStatusBar statusBar()
		{
			this.NullCheck("statusBar");
			method cmnged_statusBar = CManagedMainWindow.__N.CMnged_statusBar;
			return calli(System.IntPtr(System.IntPtr), this.self, cmnged_statusBar);
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0000F76C File Offset: 0x0000D96C
		internal readonly void setStatusBar(QStatusBar statusbar)
		{
			this.NullCheck("setStatusBar");
			method cmnged_setStatusBar = CManagedMainWindow.__N.CMnged_setStatusBar;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, statusbar, cmnged_setStatusBar);
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x0000F79C File Offset: 0x0000D99C
		internal readonly QWidget centralWidget()
		{
			this.NullCheck("centralWidget");
			method cmnged_centralWidget = CManagedMainWindow.__N.CMnged_centralWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, cmnged_centralWidget);
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x0000F7CC File Offset: 0x0000D9CC
		internal readonly void setCentralWidget(QWidget widget)
		{
			this.NullCheck("setCentralWidget");
			method cmnged_setCentralWidget = CManagedMainWindow.__N.CMnged_setCentralWidget;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, cmnged_setCentralWidget);
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x0000F7FC File Offset: 0x0000D9FC
		internal readonly void addDockWidget(DockArea area, QDockWidget dockwidget)
		{
			this.NullCheck("addDockWidget");
			method cmnged_addDockWidget = CManagedMainWindow.__N.CMnged_addDockWidget;
			calli(System.Void(System.IntPtr,System.Int64,System.IntPtr), this.self, (long)area, dockwidget, cmnged_addDockWidget);
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x0000F830 File Offset: 0x0000DA30
		internal readonly void tabifyDockWidget(QDockWidget first, QDockWidget second)
		{
			this.NullCheck("tabifyDockWidget");
			method cmnged_tabifyDockWidget = CManagedMainWindow.__N.CMnged_tabifyDockWidget;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, first, second, cmnged_tabifyDockWidget);
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x0000F868 File Offset: 0x0000DA68
		internal readonly bool isAnimated()
		{
			this.NullCheck("isAnimated");
			method cmnged_isAnimated = CManagedMainWindow.__N.CMnged_isAnimated;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_isAnimated) > 0;
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x0000F898 File Offset: 0x0000DA98
		internal readonly void setAnimated(bool enabled)
		{
			this.NullCheck("setAnimated");
			method cmnged_setAnimated = CManagedMainWindow.__N.CMnged_setAnimated;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, cmnged_setAnimated);
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x0000F8CC File Offset: 0x0000DACC
		internal readonly void addToolBarBreak(ToolbarPosition area)
		{
			this.NullCheck("addToolBarBreak");
			method cmnged_addToolBarBreak = CManagedMainWindow.__N.CMnged_addToolBarBreak;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)area, cmnged_addToolBarBreak);
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x0000F8F8 File Offset: 0x0000DAF8
		internal readonly void insertToolBarBreak(QToolBar before)
		{
			this.NullCheck("insertToolBarBreak");
			method cmnged_insertToolBarBreak = CManagedMainWindow.__N.CMnged_insertToolBarBreak;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, before, cmnged_insertToolBarBreak);
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x0000F928 File Offset: 0x0000DB28
		internal readonly void addToolBar(ToolbarPosition area, QToolBar toolbar)
		{
			this.NullCheck("addToolBar");
			method cmnged_addToolBar = CManagedMainWindow.__N.CMnged_addToolBar;
			calli(System.Void(System.IntPtr,System.Int64,System.IntPtr), this.self, (long)area, toolbar, cmnged_addToolBar);
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x0000F95C File Offset: 0x0000DB5C
		internal readonly void addToolBar(QToolBar toolbar)
		{
			this.NullCheck("addToolBar");
			method cmnged_f = CManagedMainWindow.__N.CMnged_f38;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, toolbar, cmnged_f);
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x0000F98C File Offset: 0x0000DB8C
		internal readonly void insertToolBar(QToolBar before, QToolBar toolbar)
		{
			this.NullCheck("insertToolBar");
			method cmnged_insertToolBar = CManagedMainWindow.__N.CMnged_insertToolBar;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, before, toolbar, cmnged_insertToolBar);
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x0000F9C4 File Offset: 0x0000DBC4
		internal readonly void removeToolBar(QToolBar toolbar)
		{
			this.NullCheck("removeToolBar");
			method cmnged_removeToolBar = CManagedMainWindow.__N.CMnged_removeToolBar;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, toolbar, cmnged_removeToolBar);
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0000F9F4 File Offset: 0x0000DBF4
		internal readonly void removeToolBarBreak(QToolBar before)
		{
			this.NullCheck("removeToolBarBreak");
			method cmnged_removeToolBarBreak = CManagedMainWindow.__N.CMnged_removeToolBarBreak;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, before, cmnged_removeToolBarBreak);
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0000FA24 File Offset: 0x0000DC24
		internal readonly string saveState(int version)
		{
			this.NullCheck("saveState");
			method cmnged_saveState = CManagedMainWindow.__N.CMnged_saveState;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.Int32), this.self, version, cmnged_saveState));
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0000FA54 File Offset: 0x0000DC54
		internal readonly bool restoreState(string state)
		{
			this.NullCheck("restoreState");
			method cmnged_restoreState = CManagedMainWindow.__N.CMnged_restoreState;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), cmnged_restoreState) > 0;
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x0000FA88 File Offset: 0x0000DC88
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method cmnged_isTopLevel = CManagedMainWindow.__N.CMnged_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_isTopLevel) > 0;
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x0000FAB8 File Offset: 0x0000DCB8
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method cmnged_isWindow = CManagedMainWindow.__N.CMnged_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_isWindow) > 0;
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x0000FAE8 File Offset: 0x0000DCE8
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method cmnged_isModal = CManagedMainWindow.__N.CMnged_isModal;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_isModal) > 0;
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0000FB18 File Offset: 0x0000DD18
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method cmnged_setStyleSheet = CManagedMainWindow.__N.CMnged_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), cmnged_setStyleSheet);
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0000FB48 File Offset: 0x0000DD48
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method cmnged_windowTitle = CManagedMainWindow.__N.CMnged_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, cmnged_windowTitle));
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0000FB78 File Offset: 0x0000DD78
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method cmnged_setWindowTitle = CManagedMainWindow.__N.CMnged_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), cmnged_setWindowTitle);
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x0000FBA8 File Offset: 0x0000DDA8
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method cmnged_setWindowFlags = CManagedMainWindow.__N.CMnged_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, cmnged_setWindowFlags);
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0000FBD4 File Offset: 0x0000DDD4
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method cmnged_windowFlags = CManagedMainWindow.__N.CMnged_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, cmnged_windowFlags);
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x0000FC00 File Offset: 0x0000DE00
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method cmnged_size = CManagedMainWindow.__N.CMnged_size;
			return calli(Vector3(System.IntPtr), this.self, cmnged_size);
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x0000FC2C File Offset: 0x0000DE2C
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method cmnged_resize = CManagedMainWindow.__N.CMnged_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, cmnged_resize);
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x0000FC58 File Offset: 0x0000DE58
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method cmnged_minimumSize = CManagedMainWindow.__N.CMnged_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, cmnged_minimumSize);
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x0000FC84 File Offset: 0x0000DE84
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method cmnged_setMinimumSize = CManagedMainWindow.__N.CMnged_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, cmnged_setMinimumSize);
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x0000FCB0 File Offset: 0x0000DEB0
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method cmnged_maximumSize = CManagedMainWindow.__N.CMnged_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, cmnged_maximumSize);
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0000FCDC File Offset: 0x0000DEDC
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method cmnged_setMaximumSize = CManagedMainWindow.__N.CMnged_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, cmnged_setMaximumSize);
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0000FD08 File Offset: 0x0000DF08
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method cmnged_f = CManagedMainWindow.__N.CMnged_f39;
			return calli(Vector3(System.IntPtr), this.self, cmnged_f);
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0000FD34 File Offset: 0x0000DF34
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method cmnged_move = CManagedMainWindow.__N.CMnged_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, cmnged_move);
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0000FD60 File Offset: 0x0000DF60
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method cmnged_f = CManagedMainWindow.__N.CMnged_f40;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_f) > 0;
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0000FD90 File Offset: 0x0000DF90
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method cmnged_f = CManagedMainWindow.__N.CMnged_f41;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, cmnged_f);
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0000FDC4 File Offset: 0x0000DFC4
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method cmnged_f = CManagedMainWindow.__N.CMnged_f42;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, cmnged_f);
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0000FDF8 File Offset: 0x0000DFF8
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method cmnged_setHidden = CManagedMainWindow.__N.CMnged_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, cmnged_setHidden);
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x0000FE2C File Offset: 0x0000E02C
		internal readonly void show()
		{
			this.NullCheck("show");
			method cmnged_show = CManagedMainWindow.__N.CMnged_show;
			calli(System.Void(System.IntPtr), this.self, cmnged_show);
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0000FE58 File Offset: 0x0000E058
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method cmnged_hide = CManagedMainWindow.__N.CMnged_hide;
			calli(System.Void(System.IntPtr), this.self, cmnged_hide);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x0000FE84 File Offset: 0x0000E084
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method cmnged_showMinimized = CManagedMainWindow.__N.CMnged_showMinimized;
			calli(System.Void(System.IntPtr), this.self, cmnged_showMinimized);
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x0000FEB0 File Offset: 0x0000E0B0
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method cmnged_showMaximized = CManagedMainWindow.__N.CMnged_showMaximized;
			calli(System.Void(System.IntPtr), this.self, cmnged_showMaximized);
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x0000FEDC File Offset: 0x0000E0DC
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method cmnged_showFullScreen = CManagedMainWindow.__N.CMnged_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, cmnged_showFullScreen);
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0000FF08 File Offset: 0x0000E108
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method cmnged_showNormal = CManagedMainWindow.__N.CMnged_showNormal;
			calli(System.Void(System.IntPtr), this.self, cmnged_showNormal);
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0000FF34 File Offset: 0x0000E134
		internal readonly bool close()
		{
			this.NullCheck("close");
			method cmnged_close = CManagedMainWindow.__N.CMnged_close;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_close) > 0;
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0000FF64 File Offset: 0x0000E164
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method cmnged_raise = CManagedMainWindow.__N.CMnged_raise;
			calli(System.Void(System.IntPtr), this.self, cmnged_raise);
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0000FF90 File Offset: 0x0000E190
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method cmnged_lower = CManagedMainWindow.__N.CMnged_lower;
			calli(System.Void(System.IntPtr), this.self, cmnged_lower);
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0000FFBC File Offset: 0x0000E1BC
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method cmnged_f = CManagedMainWindow.__N.CMnged_f43;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_f) > 0;
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x0000FFEC File Offset: 0x0000E1EC
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method cmnged_setAttribute = CManagedMainWindow.__N.CMnged_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, cmnged_setAttribute);
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x00010020 File Offset: 0x0000E220
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method cmnged_testAttribute = CManagedMainWindow.__N.CMnged_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, cmnged_testAttribute) > 0;
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x00010050 File Offset: 0x0000E250
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method cmnged_f = CManagedMainWindow.__N.CMnged_f44;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_f) > 0;
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x00010080 File Offset: 0x0000E280
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method cmnged_f = CManagedMainWindow.__N.CMnged_f45;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, cmnged_f);
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x000100B4 File Offset: 0x0000E2B4
		internal readonly void update()
		{
			this.NullCheck("update");
			method cmnged_f = CManagedMainWindow.__N.CMnged_f46;
			calli(System.Void(System.IntPtr), this.self, cmnged_f);
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x000100E0 File Offset: 0x0000E2E0
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method cmnged_repaint = CManagedMainWindow.__N.CMnged_repaint;
			calli(System.Void(System.IntPtr), this.self, cmnged_repaint);
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0001010C File Offset: 0x0000E30C
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method cmnged_f = CManagedMainWindow.__N.CMnged_f47;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, cmnged_f);
		}

		// Token: 0x060005D4 RID: 1492 RVA: 0x00010138 File Offset: 0x0000E338
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method cmnged_f = CManagedMainWindow.__N.CMnged_f48;
			calli(System.Void(System.IntPtr), this.self, cmnged_f);
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x00010164 File Offset: 0x0000E364
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method cmnged_setWindowIcon = CManagedMainWindow.__N.CMnged_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), cmnged_setWindowIcon);
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x00010194 File Offset: 0x0000E394
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method cmnged_setWindowIconText = CManagedMainWindow.__N.CMnged_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), cmnged_setWindowIconText);
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x000101C4 File Offset: 0x0000E3C4
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method cmnged_setWindowOpacity = CManagedMainWindow.__N.CMnged_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, cmnged_setWindowOpacity);
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x000101F0 File Offset: 0x0000E3F0
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method cmnged_windowOpacity = CManagedMainWindow.__N.CMnged_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, cmnged_windowOpacity);
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0001021C File Offset: 0x0000E41C
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method cmnged_isMinimized = CManagedMainWindow.__N.CMnged_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_isMinimized) > 0;
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0001024C File Offset: 0x0000E44C
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method cmnged_isMaximized = CManagedMainWindow.__N.CMnged_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_isMaximized) > 0;
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0001027C File Offset: 0x0000E47C
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method cmnged_isFullScreen = CManagedMainWindow.__N.CMnged_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_isFullScreen) > 0;
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x000102AC File Offset: 0x0000E4AC
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method cmnged_setMouseTracking = CManagedMainWindow.__N.CMnged_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, cmnged_setMouseTracking);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x000102E0 File Offset: 0x0000E4E0
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method cmnged_hasMouseTracking = CManagedMainWindow.__N.CMnged_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_hasMouseTracking) > 0;
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x00010310 File Offset: 0x0000E510
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method cmnged_underMouse = CManagedMainWindow.__N.CMnged_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_underMouse) > 0;
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x00010340 File Offset: 0x0000E540
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method cmnged_mapToGlobal = CManagedMainWindow.__N.CMnged_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, cmnged_mapToGlobal);
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0001036C File Offset: 0x0000E56C
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method cmnged_mapFromGlobal = CManagedMainWindow.__N.CMnged_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, cmnged_mapFromGlobal);
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x00010398 File Offset: 0x0000E598
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method cmnged_hasFocus = CManagedMainWindow.__N.CMnged_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_hasFocus) > 0;
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x000103C8 File Offset: 0x0000E5C8
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method cmnged_focusPolicy = CManagedMainWindow.__N.CMnged_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, cmnged_focusPolicy);
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x000103F4 File Offset: 0x0000E5F4
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method cmnged_setFocusPolicy = CManagedMainWindow.__N.CMnged_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, cmnged_setFocusPolicy);
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00010420 File Offset: 0x0000E620
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method cmnged_setFocusProxy = CManagedMainWindow.__N.CMnged_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, cmnged_setFocusProxy);
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x00010450 File Offset: 0x0000E650
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method cmnged_isActiveWindow = CManagedMainWindow.__N.CMnged_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_isActiveWindow) > 0;
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x00010480 File Offset: 0x0000E680
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method cmnged_updatesEnabled = CManagedMainWindow.__N.CMnged_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_updatesEnabled) > 0;
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x000104B0 File Offset: 0x0000E6B0
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method cmnged_setUpdatesEnabled = CManagedMainWindow.__N.CMnged_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, cmnged_setUpdatesEnabled);
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x000104E4 File Offset: 0x0000E6E4
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method cmnged_setFocus = CManagedMainWindow.__N.CMnged_setFocus;
			calli(System.Void(System.IntPtr), this.self, cmnged_setFocus);
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x00010510 File Offset: 0x0000E710
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method cmnged_activateWindow = CManagedMainWindow.__N.CMnged_activateWindow;
			calli(System.Void(System.IntPtr), this.self, cmnged_activateWindow);
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0001053C File Offset: 0x0000E73C
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method cmnged_clearFocus = CManagedMainWindow.__N.CMnged_clearFocus;
			calli(System.Void(System.IntPtr), this.self, cmnged_clearFocus);
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00010568 File Offset: 0x0000E768
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method cmnged_setSizePolicy = CManagedMainWindow.__N.CMnged_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, cmnged_setSizePolicy);
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x00010598 File Offset: 0x0000E798
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method cmnged_devicePixelRatioF = CManagedMainWindow.__N.CMnged_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, cmnged_devicePixelRatioF);
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x000105C4 File Offset: 0x0000E7C4
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method cmnged_saveGeometry = CManagedMainWindow.__N.CMnged_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cmnged_saveGeometry));
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x000105F4 File Offset: 0x0000E7F4
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method cmnged_restoreGeometry = CManagedMainWindow.__N.CMnged_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), cmnged_restoreGeometry) > 0;
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x00010628 File Offset: 0x0000E828
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method cmnged_addAction = CManagedMainWindow.__N.CMnged_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, cmnged_addAction);
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x00010658 File Offset: 0x0000E858
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method cmnged_removeAction = CManagedMainWindow.__N.CMnged_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, cmnged_removeAction);
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x00010688 File Offset: 0x0000E888
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method cmnged_setParent = CManagedMainWindow.__N.CMnged_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, cmnged_setParent);
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x000106B8 File Offset: 0x0000E8B8
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method cmnged_parentWidget = CManagedMainWindow.__N.CMnged_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, cmnged_parentWidget);
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x000106E8 File Offset: 0x0000E8E8
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method cmnged_AddClassName = CManagedMainWindow.__N.CMnged_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), cmnged_AddClassName);
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x00010718 File Offset: 0x0000E918
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method cmnged_Polish = CManagedMainWindow.__N.CMnged_Polish;
			calli(System.Void(System.IntPtr), this.self, cmnged_Polish);
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00010744 File Offset: 0x0000E944
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method cmnged_toolTip = CManagedMainWindow.__N.CMnged_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, cmnged_toolTip));
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x00010774 File Offset: 0x0000E974
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method cmnged_setToolTip = CManagedMainWindow.__N.CMnged_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), cmnged_setToolTip);
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x000107A4 File Offset: 0x0000E9A4
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method cmnged_statusTip = CManagedMainWindow.__N.CMnged_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, cmnged_statusTip));
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x000107D4 File Offset: 0x0000E9D4
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method cmnged_setStatusTip = CManagedMainWindow.__N.CMnged_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), cmnged_setStatusTip);
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00010804 File Offset: 0x0000EA04
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method cmnged_toolTipDuration = CManagedMainWindow.__N.CMnged_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_toolTipDuration);
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00010830 File Offset: 0x0000EA30
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method cmnged_setToolTipDuration = CManagedMainWindow.__N.CMnged_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, cmnged_setToolTipDuration);
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x0001085C File Offset: 0x0000EA5C
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method cmnged_autoFillBackground = CManagedMainWindow.__N.CMnged_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_autoFillBackground) > 0;
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x0001088C File Offset: 0x0000EA8C
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method cmnged_setAutoFillBackground = CManagedMainWindow.__N.CMnged_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, cmnged_setAutoFillBackground);
		}

		// Token: 0x04000047 RID: 71
		internal IntPtr self;

		// Token: 0x02000107 RID: 263
		internal static class __N
		{
			// Token: 0x04000877 RID: 2167
			internal static method From_CFramelessMainWindow_To_CManagedMainWindow;

			// Token: 0x04000878 RID: 2168
			internal static method To_CFramelessMainWindow_From_CManagedMainWindow;

			// Token: 0x04000879 RID: 2169
			internal static method From_QMainWindow_To_CManagedMainWindow;

			// Token: 0x0400087A RID: 2170
			internal static method To_QMainWindow_From_CManagedMainWindow;

			// Token: 0x0400087B RID: 2171
			internal static method From_QWidget_To_CManagedMainWindow;

			// Token: 0x0400087C RID: 2172
			internal static method To_QWidget_From_CManagedMainWindow;

			// Token: 0x0400087D RID: 2173
			internal static method From_QObject_To_CManagedMainWindow;

			// Token: 0x0400087E RID: 2174
			internal static method To_QObject_From_CManagedMainWindow;

			// Token: 0x0400087F RID: 2175
			internal static method CMnged_f37;

			// Token: 0x04000880 RID: 2176
			internal static method CMnged_NativeWindowDoubleClick;

			// Token: 0x04000881 RID: 2177
			internal static method CMnged_NativeStartMouseDown;

			// Token: 0x04000882 RID: 2178
			internal static method CMnged_setProxyControls;

			// Token: 0x04000883 RID: 2179
			internal static method CMnged_iconSize;

			// Token: 0x04000884 RID: 2180
			internal static method CMnged_setIconSize;

			// Token: 0x04000885 RID: 2181
			internal static method CMnged_menuBar;

			// Token: 0x04000886 RID: 2182
			internal static method CMnged_setMenuBar;

			// Token: 0x04000887 RID: 2183
			internal static method CMnged_setMenuWidget;

			// Token: 0x04000888 RID: 2184
			internal static method CMnged_statusBar;

			// Token: 0x04000889 RID: 2185
			internal static method CMnged_setStatusBar;

			// Token: 0x0400088A RID: 2186
			internal static method CMnged_centralWidget;

			// Token: 0x0400088B RID: 2187
			internal static method CMnged_setCentralWidget;

			// Token: 0x0400088C RID: 2188
			internal static method CMnged_addDockWidget;

			// Token: 0x0400088D RID: 2189
			internal static method CMnged_tabifyDockWidget;

			// Token: 0x0400088E RID: 2190
			internal static method CMnged_isAnimated;

			// Token: 0x0400088F RID: 2191
			internal static method CMnged_setAnimated;

			// Token: 0x04000890 RID: 2192
			internal static method CMnged_addToolBarBreak;

			// Token: 0x04000891 RID: 2193
			internal static method CMnged_insertToolBarBreak;

			// Token: 0x04000892 RID: 2194
			internal static method CMnged_addToolBar;

			// Token: 0x04000893 RID: 2195
			internal static method CMnged_f38;

			// Token: 0x04000894 RID: 2196
			internal static method CMnged_insertToolBar;

			// Token: 0x04000895 RID: 2197
			internal static method CMnged_removeToolBar;

			// Token: 0x04000896 RID: 2198
			internal static method CMnged_removeToolBarBreak;

			// Token: 0x04000897 RID: 2199
			internal static method CMnged_saveState;

			// Token: 0x04000898 RID: 2200
			internal static method CMnged_restoreState;

			// Token: 0x04000899 RID: 2201
			internal static method CMnged_isTopLevel;

			// Token: 0x0400089A RID: 2202
			internal static method CMnged_isWindow;

			// Token: 0x0400089B RID: 2203
			internal static method CMnged_isModal;

			// Token: 0x0400089C RID: 2204
			internal static method CMnged_setStyleSheet;

			// Token: 0x0400089D RID: 2205
			internal static method CMnged_windowTitle;

			// Token: 0x0400089E RID: 2206
			internal static method CMnged_setWindowTitle;

			// Token: 0x0400089F RID: 2207
			internal static method CMnged_setWindowFlags;

			// Token: 0x040008A0 RID: 2208
			internal static method CMnged_windowFlags;

			// Token: 0x040008A1 RID: 2209
			internal static method CMnged_size;

			// Token: 0x040008A2 RID: 2210
			internal static method CMnged_resize;

			// Token: 0x040008A3 RID: 2211
			internal static method CMnged_minimumSize;

			// Token: 0x040008A4 RID: 2212
			internal static method CMnged_setMinimumSize;

			// Token: 0x040008A5 RID: 2213
			internal static method CMnged_maximumSize;

			// Token: 0x040008A6 RID: 2214
			internal static method CMnged_setMaximumSize;

			// Token: 0x040008A7 RID: 2215
			internal static method CMnged_f39;

			// Token: 0x040008A8 RID: 2216
			internal static method CMnged_move;

			// Token: 0x040008A9 RID: 2217
			internal static method CMnged_f40;

			// Token: 0x040008AA RID: 2218
			internal static method CMnged_f41;

			// Token: 0x040008AB RID: 2219
			internal static method CMnged_f42;

			// Token: 0x040008AC RID: 2220
			internal static method CMnged_setHidden;

			// Token: 0x040008AD RID: 2221
			internal static method CMnged_show;

			// Token: 0x040008AE RID: 2222
			internal static method CMnged_hide;

			// Token: 0x040008AF RID: 2223
			internal static method CMnged_showMinimized;

			// Token: 0x040008B0 RID: 2224
			internal static method CMnged_showMaximized;

			// Token: 0x040008B1 RID: 2225
			internal static method CMnged_showFullScreen;

			// Token: 0x040008B2 RID: 2226
			internal static method CMnged_showNormal;

			// Token: 0x040008B3 RID: 2227
			internal static method CMnged_close;

			// Token: 0x040008B4 RID: 2228
			internal static method CMnged_raise;

			// Token: 0x040008B5 RID: 2229
			internal static method CMnged_lower;

			// Token: 0x040008B6 RID: 2230
			internal static method CMnged_f43;

			// Token: 0x040008B7 RID: 2231
			internal static method CMnged_setAttribute;

			// Token: 0x040008B8 RID: 2232
			internal static method CMnged_testAttribute;

			// Token: 0x040008B9 RID: 2233
			internal static method CMnged_f44;

			// Token: 0x040008BA RID: 2234
			internal static method CMnged_f45;

			// Token: 0x040008BB RID: 2235
			internal static method CMnged_f46;

			// Token: 0x040008BC RID: 2236
			internal static method CMnged_repaint;

			// Token: 0x040008BD RID: 2237
			internal static method CMnged_f47;

			// Token: 0x040008BE RID: 2238
			internal static method CMnged_f48;

			// Token: 0x040008BF RID: 2239
			internal static method CMnged_setWindowIcon;

			// Token: 0x040008C0 RID: 2240
			internal static method CMnged_setWindowIconText;

			// Token: 0x040008C1 RID: 2241
			internal static method CMnged_setWindowOpacity;

			// Token: 0x040008C2 RID: 2242
			internal static method CMnged_windowOpacity;

			// Token: 0x040008C3 RID: 2243
			internal static method CMnged_isMinimized;

			// Token: 0x040008C4 RID: 2244
			internal static method CMnged_isMaximized;

			// Token: 0x040008C5 RID: 2245
			internal static method CMnged_isFullScreen;

			// Token: 0x040008C6 RID: 2246
			internal static method CMnged_setMouseTracking;

			// Token: 0x040008C7 RID: 2247
			internal static method CMnged_hasMouseTracking;

			// Token: 0x040008C8 RID: 2248
			internal static method CMnged_underMouse;

			// Token: 0x040008C9 RID: 2249
			internal static method CMnged_mapToGlobal;

			// Token: 0x040008CA RID: 2250
			internal static method CMnged_mapFromGlobal;

			// Token: 0x040008CB RID: 2251
			internal static method CMnged_hasFocus;

			// Token: 0x040008CC RID: 2252
			internal static method CMnged_focusPolicy;

			// Token: 0x040008CD RID: 2253
			internal static method CMnged_setFocusPolicy;

			// Token: 0x040008CE RID: 2254
			internal static method CMnged_setFocusProxy;

			// Token: 0x040008CF RID: 2255
			internal static method CMnged_isActiveWindow;

			// Token: 0x040008D0 RID: 2256
			internal static method CMnged_updatesEnabled;

			// Token: 0x040008D1 RID: 2257
			internal static method CMnged_setUpdatesEnabled;

			// Token: 0x040008D2 RID: 2258
			internal static method CMnged_setFocus;

			// Token: 0x040008D3 RID: 2259
			internal static method CMnged_activateWindow;

			// Token: 0x040008D4 RID: 2260
			internal static method CMnged_clearFocus;

			// Token: 0x040008D5 RID: 2261
			internal static method CMnged_setSizePolicy;

			// Token: 0x040008D6 RID: 2262
			internal static method CMnged_devicePixelRatioF;

			// Token: 0x040008D7 RID: 2263
			internal static method CMnged_saveGeometry;

			// Token: 0x040008D8 RID: 2264
			internal static method CMnged_restoreGeometry;

			// Token: 0x040008D9 RID: 2265
			internal static method CMnged_addAction;

			// Token: 0x040008DA RID: 2266
			internal static method CMnged_removeAction;

			// Token: 0x040008DB RID: 2267
			internal static method CMnged_setParent;

			// Token: 0x040008DC RID: 2268
			internal static method CMnged_parentWidget;

			// Token: 0x040008DD RID: 2269
			internal static method CMnged_AddClassName;

			// Token: 0x040008DE RID: 2270
			internal static method CMnged_Polish;

			// Token: 0x040008DF RID: 2271
			internal static method CMnged_toolTip;

			// Token: 0x040008E0 RID: 2272
			internal static method CMnged_setToolTip;

			// Token: 0x040008E1 RID: 2273
			internal static method CMnged_statusTip;

			// Token: 0x040008E2 RID: 2274
			internal static method CMnged_setStatusTip;

			// Token: 0x040008E3 RID: 2275
			internal static method CMnged_toolTipDuration;

			// Token: 0x040008E4 RID: 2276
			internal static method CMnged_setToolTipDuration;

			// Token: 0x040008E5 RID: 2277
			internal static method CMnged_autoFillBackground;

			// Token: 0x040008E6 RID: 2278
			internal static method CMnged_setAutoFillBackground;
		}
	}
}
