using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000038 RID: 56
	internal struct CFramelessMainWindow
	{
		// Token: 0x0600049B RID: 1179 RVA: 0x0000CD22 File Offset: 0x0000AF22
		public static implicit operator IntPtr(CFramelessMainWindow value)
		{
			return value.self;
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0000CD2C File Offset: 0x0000AF2C
		public static implicit operator CFramelessMainWindow(IntPtr value)
		{
			return new CFramelessMainWindow
			{
				self = value
			};
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x0000CD4A File Offset: 0x0000AF4A
		public static bool operator ==(CFramelessMainWindow c1, CFramelessMainWindow c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0000CD5D File Offset: 0x0000AF5D
		public static bool operator !=(CFramelessMainWindow c1, CFramelessMainWindow c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0000CD70 File Offset: 0x0000AF70
		public override bool Equals(object obj)
		{
			if (obj is CFramelessMainWindow)
			{
				CFramelessMainWindow c = (CFramelessMainWindow)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0000CD9A File Offset: 0x0000AF9A
		internal CFramelessMainWindow(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x0000CDA4 File Offset: 0x0000AFA4
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CFramelessMainWindow ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x0000CDE0 File Offset: 0x0000AFE0
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x0000CDF2 File Offset: 0x0000AFF2
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0000CDFD File Offset: 0x0000AFFD
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x0000CE10 File Offset: 0x0000B010
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CFramelessMainWindow was null when calling " + n);
			}
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x0000CE2B File Offset: 0x0000B02B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x0000CE38 File Offset: 0x0000B038
		public static implicit operator QMainWindow(CFramelessMainWindow value)
		{
			method to_QMainWindow_From_CFramelessMainWindow = CFramelessMainWindow.__N.To_QMainWindow_From_CFramelessMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, to_QMainWindow_From_CFramelessMainWindow);
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x0000CE5C File Offset: 0x0000B05C
		public static explicit operator CFramelessMainWindow(QMainWindow value)
		{
			method from_QMainWindow_To_CFramelessMainWindow = CFramelessMainWindow.__N.From_QMainWindow_To_CFramelessMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, from_QMainWindow_To_CFramelessMainWindow);
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x0000CE80 File Offset: 0x0000B080
		public static implicit operator QWidget(CFramelessMainWindow value)
		{
			method to_QWidget_From_CFramelessMainWindow = CFramelessMainWindow.__N.To_QWidget_From_CFramelessMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_CFramelessMainWindow);
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x0000CEA4 File Offset: 0x0000B0A4
		public static explicit operator CFramelessMainWindow(QWidget value)
		{
			method from_QWidget_To_CFramelessMainWindow = CFramelessMainWindow.__N.From_QWidget_To_CFramelessMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_CFramelessMainWindow);
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x0000CEC8 File Offset: 0x0000B0C8
		public static implicit operator QObject(CFramelessMainWindow value)
		{
			method to_QObject_From_CFramelessMainWindow = CFramelessMainWindow.__N.To_QObject_From_CFramelessMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_CFramelessMainWindow);
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0000CEEC File Offset: 0x0000B0EC
		public static explicit operator CFramelessMainWindow(QObject value)
		{
			method from_QObject_To_CFramelessMainWindow = CFramelessMainWindow.__N.From_QObject_To_CFramelessMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_CFramelessMainWindow);
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x0000CF10 File Offset: 0x0000B110
		internal readonly void NativeWindowDoubleClick()
		{
			this.NullCheck("NativeWindowDoubleClick");
			method cfrmel_NativeWindowDoubleClick = CFramelessMainWindow.__N.CFrmel_NativeWindowDoubleClick;
			calli(System.Void(System.IntPtr), this.self, cfrmel_NativeWindowDoubleClick);
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x0000CF3C File Offset: 0x0000B13C
		internal readonly void NativeStartMouseDown(int mode)
		{
			this.NullCheck("NativeStartMouseDown");
			method cfrmel_NativeStartMouseDown = CFramelessMainWindow.__N.CFrmel_NativeStartMouseDown;
			calli(System.Void(System.IntPtr,System.Int32), this.self, mode, cfrmel_NativeStartMouseDown);
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0000CF68 File Offset: 0x0000B168
		internal readonly void setProxyControls(QLabel titleLabel, QMenuBar menuBar, QPushButton icon)
		{
			this.NullCheck("setProxyControls");
			method cfrmel_setProxyControls = CFramelessMainWindow.__N.CFrmel_setProxyControls;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr,System.IntPtr), this.self, titleLabel, menuBar, icon, cfrmel_setProxyControls);
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0000CFA4 File Offset: 0x0000B1A4
		internal readonly Vector3 iconSize()
		{
			this.NullCheck("iconSize");
			method cfrmel_iconSize = CFramelessMainWindow.__N.CFrmel_iconSize;
			return calli(Vector3(System.IntPtr), this.self, cfrmel_iconSize);
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x0000CFD0 File Offset: 0x0000B1D0
		internal readonly void setIconSize(Vector3 iconSize)
		{
			this.NullCheck("setIconSize");
			method cfrmel_setIconSize = CFramelessMainWindow.__N.CFrmel_setIconSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, iconSize, cfrmel_setIconSize);
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0000CFFC File Offset: 0x0000B1FC
		internal readonly QMenuBar menuBar()
		{
			this.NullCheck("menuBar");
			method cfrmel_menuBar = CFramelessMainWindow.__N.CFrmel_menuBar;
			return calli(System.IntPtr(System.IntPtr), this.self, cfrmel_menuBar);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0000D02C File Offset: 0x0000B22C
		internal readonly void setMenuBar(QMenuBar menubar)
		{
			this.NullCheck("setMenuBar");
			method cfrmel_setMenuBar = CFramelessMainWindow.__N.CFrmel_setMenuBar;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, menubar, cfrmel_setMenuBar);
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0000D05C File Offset: 0x0000B25C
		internal readonly void setMenuWidget(QWidget menubar)
		{
			this.NullCheck("setMenuWidget");
			method cfrmel_setMenuWidget = CFramelessMainWindow.__N.CFrmel_setMenuWidget;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, menubar, cfrmel_setMenuWidget);
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x0000D08C File Offset: 0x0000B28C
		internal readonly QStatusBar statusBar()
		{
			this.NullCheck("statusBar");
			method cfrmel_statusBar = CFramelessMainWindow.__N.CFrmel_statusBar;
			return calli(System.IntPtr(System.IntPtr), this.self, cfrmel_statusBar);
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x0000D0BC File Offset: 0x0000B2BC
		internal readonly void setStatusBar(QStatusBar statusbar)
		{
			this.NullCheck("setStatusBar");
			method cfrmel_setStatusBar = CFramelessMainWindow.__N.CFrmel_setStatusBar;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, statusbar, cfrmel_setStatusBar);
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x0000D0EC File Offset: 0x0000B2EC
		internal readonly QWidget centralWidget()
		{
			this.NullCheck("centralWidget");
			method cfrmel_centralWidget = CFramelessMainWindow.__N.CFrmel_centralWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, cfrmel_centralWidget);
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x0000D11C File Offset: 0x0000B31C
		internal readonly void setCentralWidget(QWidget widget)
		{
			this.NullCheck("setCentralWidget");
			method cfrmel_setCentralWidget = CFramelessMainWindow.__N.CFrmel_setCentralWidget;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, cfrmel_setCentralWidget);
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0000D14C File Offset: 0x0000B34C
		internal readonly void addDockWidget(DockArea area, QDockWidget dockwidget)
		{
			this.NullCheck("addDockWidget");
			method cfrmel_addDockWidget = CFramelessMainWindow.__N.CFrmel_addDockWidget;
			calli(System.Void(System.IntPtr,System.Int64,System.IntPtr), this.self, (long)area, dockwidget, cfrmel_addDockWidget);
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x0000D180 File Offset: 0x0000B380
		internal readonly void tabifyDockWidget(QDockWidget first, QDockWidget second)
		{
			this.NullCheck("tabifyDockWidget");
			method cfrmel_tabifyDockWidget = CFramelessMainWindow.__N.CFrmel_tabifyDockWidget;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, first, second, cfrmel_tabifyDockWidget);
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x0000D1B8 File Offset: 0x0000B3B8
		internal readonly bool isAnimated()
		{
			this.NullCheck("isAnimated");
			method cfrmel_isAnimated = CFramelessMainWindow.__N.CFrmel_isAnimated;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_isAnimated) > 0;
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0000D1E8 File Offset: 0x0000B3E8
		internal readonly void setAnimated(bool enabled)
		{
			this.NullCheck("setAnimated");
			method cfrmel_setAnimated = CFramelessMainWindow.__N.CFrmel_setAnimated;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, cfrmel_setAnimated);
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x0000D21C File Offset: 0x0000B41C
		internal readonly void addToolBarBreak(ToolbarPosition area)
		{
			this.NullCheck("addToolBarBreak");
			method cfrmel_addToolBarBreak = CFramelessMainWindow.__N.CFrmel_addToolBarBreak;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)area, cfrmel_addToolBarBreak);
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x0000D248 File Offset: 0x0000B448
		internal readonly void insertToolBarBreak(QToolBar before)
		{
			this.NullCheck("insertToolBarBreak");
			method cfrmel_insertToolBarBreak = CFramelessMainWindow.__N.CFrmel_insertToolBarBreak;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, before, cfrmel_insertToolBarBreak);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0000D278 File Offset: 0x0000B478
		internal readonly void addToolBar(ToolbarPosition area, QToolBar toolbar)
		{
			this.NullCheck("addToolBar");
			method cfrmel_addToolBar = CFramelessMainWindow.__N.CFrmel_addToolBar;
			calli(System.Void(System.IntPtr,System.Int64,System.IntPtr), this.self, (long)area, toolbar, cfrmel_addToolBar);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0000D2AC File Offset: 0x0000B4AC
		internal readonly void addToolBar(QToolBar toolbar)
		{
			this.NullCheck("addToolBar");
			method cfrmel_f = CFramelessMainWindow.__N.CFrmel_f2;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, toolbar, cfrmel_f);
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x0000D2DC File Offset: 0x0000B4DC
		internal readonly void insertToolBar(QToolBar before, QToolBar toolbar)
		{
			this.NullCheck("insertToolBar");
			method cfrmel_insertToolBar = CFramelessMainWindow.__N.CFrmel_insertToolBar;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, before, toolbar, cfrmel_insertToolBar);
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x0000D314 File Offset: 0x0000B514
		internal readonly void removeToolBar(QToolBar toolbar)
		{
			this.NullCheck("removeToolBar");
			method cfrmel_removeToolBar = CFramelessMainWindow.__N.CFrmel_removeToolBar;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, toolbar, cfrmel_removeToolBar);
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0000D344 File Offset: 0x0000B544
		internal readonly void removeToolBarBreak(QToolBar before)
		{
			this.NullCheck("removeToolBarBreak");
			method cfrmel_removeToolBarBreak = CFramelessMainWindow.__N.CFrmel_removeToolBarBreak;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, before, cfrmel_removeToolBarBreak);
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x0000D374 File Offset: 0x0000B574
		internal readonly string saveState(int version)
		{
			this.NullCheck("saveState");
			method cfrmel_saveState = CFramelessMainWindow.__N.CFrmel_saveState;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.Int32), this.self, version, cfrmel_saveState));
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0000D3A4 File Offset: 0x0000B5A4
		internal readonly bool restoreState(string state)
		{
			this.NullCheck("restoreState");
			method cfrmel_restoreState = CFramelessMainWindow.__N.CFrmel_restoreState;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), cfrmel_restoreState) > 0;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0000D3D8 File Offset: 0x0000B5D8
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method cfrmel_isTopLevel = CFramelessMainWindow.__N.CFrmel_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_isTopLevel) > 0;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0000D408 File Offset: 0x0000B608
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method cfrmel_isWindow = CFramelessMainWindow.__N.CFrmel_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_isWindow) > 0;
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0000D438 File Offset: 0x0000B638
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method cfrmel_isModal = CFramelessMainWindow.__N.CFrmel_isModal;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_isModal) > 0;
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0000D468 File Offset: 0x0000B668
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method cfrmel_setStyleSheet = CFramelessMainWindow.__N.CFrmel_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), cfrmel_setStyleSheet);
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0000D498 File Offset: 0x0000B698
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method cfrmel_windowTitle = CFramelessMainWindow.__N.CFrmel_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, cfrmel_windowTitle));
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x0000D4C8 File Offset: 0x0000B6C8
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method cfrmel_setWindowTitle = CFramelessMainWindow.__N.CFrmel_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), cfrmel_setWindowTitle);
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x0000D4F8 File Offset: 0x0000B6F8
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method cfrmel_setWindowFlags = CFramelessMainWindow.__N.CFrmel_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, cfrmel_setWindowFlags);
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0000D524 File Offset: 0x0000B724
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method cfrmel_windowFlags = CFramelessMainWindow.__N.CFrmel_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, cfrmel_windowFlags);
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x0000D550 File Offset: 0x0000B750
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method cfrmel_size = CFramelessMainWindow.__N.CFrmel_size;
			return calli(Vector3(System.IntPtr), this.self, cfrmel_size);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0000D57C File Offset: 0x0000B77C
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method cfrmel_resize = CFramelessMainWindow.__N.CFrmel_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, cfrmel_resize);
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x0000D5A8 File Offset: 0x0000B7A8
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method cfrmel_minimumSize = CFramelessMainWindow.__N.CFrmel_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, cfrmel_minimumSize);
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x0000D5D4 File Offset: 0x0000B7D4
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method cfrmel_setMinimumSize = CFramelessMainWindow.__N.CFrmel_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, cfrmel_setMinimumSize);
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0000D600 File Offset: 0x0000B800
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method cfrmel_maximumSize = CFramelessMainWindow.__N.CFrmel_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, cfrmel_maximumSize);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0000D62C File Offset: 0x0000B82C
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method cfrmel_setMaximumSize = CFramelessMainWindow.__N.CFrmel_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, cfrmel_setMaximumSize);
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0000D658 File Offset: 0x0000B858
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method cfrmel_pos = CFramelessMainWindow.__N.CFrmel_pos;
			return calli(Vector3(System.IntPtr), this.self, cfrmel_pos);
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x0000D684 File Offset: 0x0000B884
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method cfrmel_move = CFramelessMainWindow.__N.CFrmel_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, cfrmel_move);
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x0000D6B0 File Offset: 0x0000B8B0
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method cfrmel_isEnabled = CFramelessMainWindow.__N.CFrmel_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_isEnabled) > 0;
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x0000D6E0 File Offset: 0x0000B8E0
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method cfrmel_setEnabled = CFramelessMainWindow.__N.CFrmel_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, cfrmel_setEnabled);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x0000D714 File Offset: 0x0000B914
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method cfrmel_setVisible = CFramelessMainWindow.__N.CFrmel_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, cfrmel_setVisible);
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x0000D748 File Offset: 0x0000B948
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method cfrmel_setHidden = CFramelessMainWindow.__N.CFrmel_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, cfrmel_setHidden);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x0000D77C File Offset: 0x0000B97C
		internal readonly void show()
		{
			this.NullCheck("show");
			method cfrmel_show = CFramelessMainWindow.__N.CFrmel_show;
			calli(System.Void(System.IntPtr), this.self, cfrmel_show);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x0000D7A8 File Offset: 0x0000B9A8
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method cfrmel_hide = CFramelessMainWindow.__N.CFrmel_hide;
			calli(System.Void(System.IntPtr), this.self, cfrmel_hide);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0000D7D4 File Offset: 0x0000B9D4
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method cfrmel_showMinimized = CFramelessMainWindow.__N.CFrmel_showMinimized;
			calli(System.Void(System.IntPtr), this.self, cfrmel_showMinimized);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0000D800 File Offset: 0x0000BA00
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method cfrmel_showMaximized = CFramelessMainWindow.__N.CFrmel_showMaximized;
			calli(System.Void(System.IntPtr), this.self, cfrmel_showMaximized);
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0000D82C File Offset: 0x0000BA2C
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method cfrmel_showFullScreen = CFramelessMainWindow.__N.CFrmel_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, cfrmel_showFullScreen);
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x0000D858 File Offset: 0x0000BA58
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method cfrmel_showNormal = CFramelessMainWindow.__N.CFrmel_showNormal;
			calli(System.Void(System.IntPtr), this.self, cfrmel_showNormal);
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x0000D884 File Offset: 0x0000BA84
		internal readonly bool close()
		{
			this.NullCheck("close");
			method cfrmel_close = CFramelessMainWindow.__N.CFrmel_close;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_close) > 0;
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x0000D8B4 File Offset: 0x0000BAB4
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method cfrmel_raise = CFramelessMainWindow.__N.CFrmel_raise;
			calli(System.Void(System.IntPtr), this.self, cfrmel_raise);
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0000D8E0 File Offset: 0x0000BAE0
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method cfrmel_lower = CFramelessMainWindow.__N.CFrmel_lower;
			calli(System.Void(System.IntPtr), this.self, cfrmel_lower);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0000D90C File Offset: 0x0000BB0C
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method cfrmel_isVisible = CFramelessMainWindow.__N.CFrmel_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_isVisible) > 0;
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x0000D93C File Offset: 0x0000BB3C
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method cfrmel_setAttribute = CFramelessMainWindow.__N.CFrmel_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, cfrmel_setAttribute);
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x0000D970 File Offset: 0x0000BB70
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method cfrmel_testAttribute = CFramelessMainWindow.__N.CFrmel_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, cfrmel_testAttribute) > 0;
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x0000D9A0 File Offset: 0x0000BBA0
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method cfrmel_acceptDrops = CFramelessMainWindow.__N.CFrmel_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_acceptDrops) > 0;
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x0000D9D0 File Offset: 0x0000BBD0
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method cfrmel_setAcceptDrops = CFramelessMainWindow.__N.CFrmel_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, cfrmel_setAcceptDrops);
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x0000DA04 File Offset: 0x0000BC04
		internal readonly void update()
		{
			this.NullCheck("update");
			method cfrmel_update = CFramelessMainWindow.__N.CFrmel_update;
			calli(System.Void(System.IntPtr), this.self, cfrmel_update);
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0000DA30 File Offset: 0x0000BC30
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method cfrmel_repaint = CFramelessMainWindow.__N.CFrmel_repaint;
			calli(System.Void(System.IntPtr), this.self, cfrmel_repaint);
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0000DA5C File Offset: 0x0000BC5C
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method cfrmel_setCursor = CFramelessMainWindow.__N.CFrmel_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, cfrmel_setCursor);
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0000DA88 File Offset: 0x0000BC88
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method cfrmel_unsetCursor = CFramelessMainWindow.__N.CFrmel_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, cfrmel_unsetCursor);
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x0000DAB4 File Offset: 0x0000BCB4
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method cfrmel_setWindowIcon = CFramelessMainWindow.__N.CFrmel_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), cfrmel_setWindowIcon);
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x0000DAE4 File Offset: 0x0000BCE4
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method cfrmel_setWindowIconText = CFramelessMainWindow.__N.CFrmel_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), cfrmel_setWindowIconText);
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0000DB14 File Offset: 0x0000BD14
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method cfrmel_setWindowOpacity = CFramelessMainWindow.__N.CFrmel_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, cfrmel_setWindowOpacity);
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0000DB40 File Offset: 0x0000BD40
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method cfrmel_windowOpacity = CFramelessMainWindow.__N.CFrmel_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, cfrmel_windowOpacity);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x0000DB6C File Offset: 0x0000BD6C
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method cfrmel_isMinimized = CFramelessMainWindow.__N.CFrmel_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_isMinimized) > 0;
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0000DB9C File Offset: 0x0000BD9C
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method cfrmel_isMaximized = CFramelessMainWindow.__N.CFrmel_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_isMaximized) > 0;
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0000DBCC File Offset: 0x0000BDCC
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method cfrmel_isFullScreen = CFramelessMainWindow.__N.CFrmel_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_isFullScreen) > 0;
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0000DBFC File Offset: 0x0000BDFC
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method cfrmel_setMouseTracking = CFramelessMainWindow.__N.CFrmel_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, cfrmel_setMouseTracking);
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0000DC30 File Offset: 0x0000BE30
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method cfrmel_hasMouseTracking = CFramelessMainWindow.__N.CFrmel_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_hasMouseTracking) > 0;
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0000DC60 File Offset: 0x0000BE60
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method cfrmel_underMouse = CFramelessMainWindow.__N.CFrmel_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_underMouse) > 0;
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0000DC90 File Offset: 0x0000BE90
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method cfrmel_mapToGlobal = CFramelessMainWindow.__N.CFrmel_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, cfrmel_mapToGlobal);
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0000DCBC File Offset: 0x0000BEBC
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method cfrmel_mapFromGlobal = CFramelessMainWindow.__N.CFrmel_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, cfrmel_mapFromGlobal);
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x0000DCE8 File Offset: 0x0000BEE8
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method cfrmel_hasFocus = CFramelessMainWindow.__N.CFrmel_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_hasFocus) > 0;
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x0000DD18 File Offset: 0x0000BF18
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method cfrmel_focusPolicy = CFramelessMainWindow.__N.CFrmel_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, cfrmel_focusPolicy);
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0000DD44 File Offset: 0x0000BF44
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method cfrmel_setFocusPolicy = CFramelessMainWindow.__N.CFrmel_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, cfrmel_setFocusPolicy);
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0000DD70 File Offset: 0x0000BF70
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method cfrmel_setFocusProxy = CFramelessMainWindow.__N.CFrmel_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, cfrmel_setFocusProxy);
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x0000DDA0 File Offset: 0x0000BFA0
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method cfrmel_isActiveWindow = CFramelessMainWindow.__N.CFrmel_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_isActiveWindow) > 0;
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x0000DDD0 File Offset: 0x0000BFD0
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method cfrmel_updatesEnabled = CFramelessMainWindow.__N.CFrmel_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_updatesEnabled) > 0;
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x0000DE00 File Offset: 0x0000C000
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method cfrmel_setUpdatesEnabled = CFramelessMainWindow.__N.CFrmel_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, cfrmel_setUpdatesEnabled);
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0000DE34 File Offset: 0x0000C034
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method cfrmel_setFocus = CFramelessMainWindow.__N.CFrmel_setFocus;
			calli(System.Void(System.IntPtr), this.self, cfrmel_setFocus);
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0000DE60 File Offset: 0x0000C060
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method cfrmel_activateWindow = CFramelessMainWindow.__N.CFrmel_activateWindow;
			calli(System.Void(System.IntPtr), this.self, cfrmel_activateWindow);
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0000DE8C File Offset: 0x0000C08C
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method cfrmel_clearFocus = CFramelessMainWindow.__N.CFrmel_clearFocus;
			calli(System.Void(System.IntPtr), this.self, cfrmel_clearFocus);
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0000DEB8 File Offset: 0x0000C0B8
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method cfrmel_setSizePolicy = CFramelessMainWindow.__N.CFrmel_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, cfrmel_setSizePolicy);
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0000DEE8 File Offset: 0x0000C0E8
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method cfrmel_devicePixelRatioF = CFramelessMainWindow.__N.CFrmel_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, cfrmel_devicePixelRatioF);
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x0000DF14 File Offset: 0x0000C114
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method cfrmel_saveGeometry = CFramelessMainWindow.__N.CFrmel_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cfrmel_saveGeometry));
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x0000DF44 File Offset: 0x0000C144
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method cfrmel_restoreGeometry = CFramelessMainWindow.__N.CFrmel_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), cfrmel_restoreGeometry) > 0;
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0000DF78 File Offset: 0x0000C178
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method cfrmel_addAction = CFramelessMainWindow.__N.CFrmel_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, cfrmel_addAction);
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x0000DFA8 File Offset: 0x0000C1A8
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method cfrmel_removeAction = CFramelessMainWindow.__N.CFrmel_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, cfrmel_removeAction);
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x0000DFD8 File Offset: 0x0000C1D8
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method cfrmel_setParent = CFramelessMainWindow.__N.CFrmel_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, cfrmel_setParent);
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x0000E008 File Offset: 0x0000C208
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method cfrmel_parentWidget = CFramelessMainWindow.__N.CFrmel_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, cfrmel_parentWidget);
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x0000E038 File Offset: 0x0000C238
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method cfrmel_AddClassName = CFramelessMainWindow.__N.CFrmel_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), cfrmel_AddClassName);
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0000E068 File Offset: 0x0000C268
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method cfrmel_Polish = CFramelessMainWindow.__N.CFrmel_Polish;
			calli(System.Void(System.IntPtr), this.self, cfrmel_Polish);
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0000E094 File Offset: 0x0000C294
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method cfrmel_toolTip = CFramelessMainWindow.__N.CFrmel_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, cfrmel_toolTip));
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0000E0C4 File Offset: 0x0000C2C4
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method cfrmel_setToolTip = CFramelessMainWindow.__N.CFrmel_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), cfrmel_setToolTip);
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0000E0F4 File Offset: 0x0000C2F4
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method cfrmel_statusTip = CFramelessMainWindow.__N.CFrmel_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, cfrmel_statusTip));
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0000E124 File Offset: 0x0000C324
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method cfrmel_setStatusTip = CFramelessMainWindow.__N.CFrmel_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), cfrmel_setStatusTip);
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0000E154 File Offset: 0x0000C354
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method cfrmel_toolTipDuration = CFramelessMainWindow.__N.CFrmel_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_toolTipDuration);
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x0000E180 File Offset: 0x0000C380
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method cfrmel_setToolTipDuration = CFramelessMainWindow.__N.CFrmel_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, cfrmel_setToolTipDuration);
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0000E1AC File Offset: 0x0000C3AC
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method cfrmel_autoFillBackground = CFramelessMainWindow.__N.CFrmel_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, cfrmel_autoFillBackground) > 0;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0000E1DC File Offset: 0x0000C3DC
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method cfrmel_setAutoFillBackground = CFramelessMainWindow.__N.CFrmel_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, cfrmel_setAutoFillBackground);
		}

		// Token: 0x04000044 RID: 68
		internal IntPtr self;

		// Token: 0x02000104 RID: 260
		internal static class __N
		{
			// Token: 0x040007B5 RID: 1973
			internal static method From_QMainWindow_To_CFramelessMainWindow;

			// Token: 0x040007B6 RID: 1974
			internal static method To_QMainWindow_From_CFramelessMainWindow;

			// Token: 0x040007B7 RID: 1975
			internal static method From_QWidget_To_CFramelessMainWindow;

			// Token: 0x040007B8 RID: 1976
			internal static method To_QWidget_From_CFramelessMainWindow;

			// Token: 0x040007B9 RID: 1977
			internal static method From_QObject_To_CFramelessMainWindow;

			// Token: 0x040007BA RID: 1978
			internal static method To_QObject_From_CFramelessMainWindow;

			// Token: 0x040007BB RID: 1979
			internal static method CFrmel_NativeWindowDoubleClick;

			// Token: 0x040007BC RID: 1980
			internal static method CFrmel_NativeStartMouseDown;

			// Token: 0x040007BD RID: 1981
			internal static method CFrmel_setProxyControls;

			// Token: 0x040007BE RID: 1982
			internal static method CFrmel_iconSize;

			// Token: 0x040007BF RID: 1983
			internal static method CFrmel_setIconSize;

			// Token: 0x040007C0 RID: 1984
			internal static method CFrmel_menuBar;

			// Token: 0x040007C1 RID: 1985
			internal static method CFrmel_setMenuBar;

			// Token: 0x040007C2 RID: 1986
			internal static method CFrmel_setMenuWidget;

			// Token: 0x040007C3 RID: 1987
			internal static method CFrmel_statusBar;

			// Token: 0x040007C4 RID: 1988
			internal static method CFrmel_setStatusBar;

			// Token: 0x040007C5 RID: 1989
			internal static method CFrmel_centralWidget;

			// Token: 0x040007C6 RID: 1990
			internal static method CFrmel_setCentralWidget;

			// Token: 0x040007C7 RID: 1991
			internal static method CFrmel_addDockWidget;

			// Token: 0x040007C8 RID: 1992
			internal static method CFrmel_tabifyDockWidget;

			// Token: 0x040007C9 RID: 1993
			internal static method CFrmel_isAnimated;

			// Token: 0x040007CA RID: 1994
			internal static method CFrmel_setAnimated;

			// Token: 0x040007CB RID: 1995
			internal static method CFrmel_addToolBarBreak;

			// Token: 0x040007CC RID: 1996
			internal static method CFrmel_insertToolBarBreak;

			// Token: 0x040007CD RID: 1997
			internal static method CFrmel_addToolBar;

			// Token: 0x040007CE RID: 1998
			internal static method CFrmel_f2;

			// Token: 0x040007CF RID: 1999
			internal static method CFrmel_insertToolBar;

			// Token: 0x040007D0 RID: 2000
			internal static method CFrmel_removeToolBar;

			// Token: 0x040007D1 RID: 2001
			internal static method CFrmel_removeToolBarBreak;

			// Token: 0x040007D2 RID: 2002
			internal static method CFrmel_saveState;

			// Token: 0x040007D3 RID: 2003
			internal static method CFrmel_restoreState;

			// Token: 0x040007D4 RID: 2004
			internal static method CFrmel_isTopLevel;

			// Token: 0x040007D5 RID: 2005
			internal static method CFrmel_isWindow;

			// Token: 0x040007D6 RID: 2006
			internal static method CFrmel_isModal;

			// Token: 0x040007D7 RID: 2007
			internal static method CFrmel_setStyleSheet;

			// Token: 0x040007D8 RID: 2008
			internal static method CFrmel_windowTitle;

			// Token: 0x040007D9 RID: 2009
			internal static method CFrmel_setWindowTitle;

			// Token: 0x040007DA RID: 2010
			internal static method CFrmel_setWindowFlags;

			// Token: 0x040007DB RID: 2011
			internal static method CFrmel_windowFlags;

			// Token: 0x040007DC RID: 2012
			internal static method CFrmel_size;

			// Token: 0x040007DD RID: 2013
			internal static method CFrmel_resize;

			// Token: 0x040007DE RID: 2014
			internal static method CFrmel_minimumSize;

			// Token: 0x040007DF RID: 2015
			internal static method CFrmel_setMinimumSize;

			// Token: 0x040007E0 RID: 2016
			internal static method CFrmel_maximumSize;

			// Token: 0x040007E1 RID: 2017
			internal static method CFrmel_setMaximumSize;

			// Token: 0x040007E2 RID: 2018
			internal static method CFrmel_pos;

			// Token: 0x040007E3 RID: 2019
			internal static method CFrmel_move;

			// Token: 0x040007E4 RID: 2020
			internal static method CFrmel_isEnabled;

			// Token: 0x040007E5 RID: 2021
			internal static method CFrmel_setEnabled;

			// Token: 0x040007E6 RID: 2022
			internal static method CFrmel_setVisible;

			// Token: 0x040007E7 RID: 2023
			internal static method CFrmel_setHidden;

			// Token: 0x040007E8 RID: 2024
			internal static method CFrmel_show;

			// Token: 0x040007E9 RID: 2025
			internal static method CFrmel_hide;

			// Token: 0x040007EA RID: 2026
			internal static method CFrmel_showMinimized;

			// Token: 0x040007EB RID: 2027
			internal static method CFrmel_showMaximized;

			// Token: 0x040007EC RID: 2028
			internal static method CFrmel_showFullScreen;

			// Token: 0x040007ED RID: 2029
			internal static method CFrmel_showNormal;

			// Token: 0x040007EE RID: 2030
			internal static method CFrmel_close;

			// Token: 0x040007EF RID: 2031
			internal static method CFrmel_raise;

			// Token: 0x040007F0 RID: 2032
			internal static method CFrmel_lower;

			// Token: 0x040007F1 RID: 2033
			internal static method CFrmel_isVisible;

			// Token: 0x040007F2 RID: 2034
			internal static method CFrmel_setAttribute;

			// Token: 0x040007F3 RID: 2035
			internal static method CFrmel_testAttribute;

			// Token: 0x040007F4 RID: 2036
			internal static method CFrmel_acceptDrops;

			// Token: 0x040007F5 RID: 2037
			internal static method CFrmel_setAcceptDrops;

			// Token: 0x040007F6 RID: 2038
			internal static method CFrmel_update;

			// Token: 0x040007F7 RID: 2039
			internal static method CFrmel_repaint;

			// Token: 0x040007F8 RID: 2040
			internal static method CFrmel_setCursor;

			// Token: 0x040007F9 RID: 2041
			internal static method CFrmel_unsetCursor;

			// Token: 0x040007FA RID: 2042
			internal static method CFrmel_setWindowIcon;

			// Token: 0x040007FB RID: 2043
			internal static method CFrmel_setWindowIconText;

			// Token: 0x040007FC RID: 2044
			internal static method CFrmel_setWindowOpacity;

			// Token: 0x040007FD RID: 2045
			internal static method CFrmel_windowOpacity;

			// Token: 0x040007FE RID: 2046
			internal static method CFrmel_isMinimized;

			// Token: 0x040007FF RID: 2047
			internal static method CFrmel_isMaximized;

			// Token: 0x04000800 RID: 2048
			internal static method CFrmel_isFullScreen;

			// Token: 0x04000801 RID: 2049
			internal static method CFrmel_setMouseTracking;

			// Token: 0x04000802 RID: 2050
			internal static method CFrmel_hasMouseTracking;

			// Token: 0x04000803 RID: 2051
			internal static method CFrmel_underMouse;

			// Token: 0x04000804 RID: 2052
			internal static method CFrmel_mapToGlobal;

			// Token: 0x04000805 RID: 2053
			internal static method CFrmel_mapFromGlobal;

			// Token: 0x04000806 RID: 2054
			internal static method CFrmel_hasFocus;

			// Token: 0x04000807 RID: 2055
			internal static method CFrmel_focusPolicy;

			// Token: 0x04000808 RID: 2056
			internal static method CFrmel_setFocusPolicy;

			// Token: 0x04000809 RID: 2057
			internal static method CFrmel_setFocusProxy;

			// Token: 0x0400080A RID: 2058
			internal static method CFrmel_isActiveWindow;

			// Token: 0x0400080B RID: 2059
			internal static method CFrmel_updatesEnabled;

			// Token: 0x0400080C RID: 2060
			internal static method CFrmel_setUpdatesEnabled;

			// Token: 0x0400080D RID: 2061
			internal static method CFrmel_setFocus;

			// Token: 0x0400080E RID: 2062
			internal static method CFrmel_activateWindow;

			// Token: 0x0400080F RID: 2063
			internal static method CFrmel_clearFocus;

			// Token: 0x04000810 RID: 2064
			internal static method CFrmel_setSizePolicy;

			// Token: 0x04000811 RID: 2065
			internal static method CFrmel_devicePixelRatioF;

			// Token: 0x04000812 RID: 2066
			internal static method CFrmel_saveGeometry;

			// Token: 0x04000813 RID: 2067
			internal static method CFrmel_restoreGeometry;

			// Token: 0x04000814 RID: 2068
			internal static method CFrmel_addAction;

			// Token: 0x04000815 RID: 2069
			internal static method CFrmel_removeAction;

			// Token: 0x04000816 RID: 2070
			internal static method CFrmel_setParent;

			// Token: 0x04000817 RID: 2071
			internal static method CFrmel_parentWidget;

			// Token: 0x04000818 RID: 2072
			internal static method CFrmel_AddClassName;

			// Token: 0x04000819 RID: 2073
			internal static method CFrmel_Polish;

			// Token: 0x0400081A RID: 2074
			internal static method CFrmel_toolTip;

			// Token: 0x0400081B RID: 2075
			internal static method CFrmel_setToolTip;

			// Token: 0x0400081C RID: 2076
			internal static method CFrmel_statusTip;

			// Token: 0x0400081D RID: 2077
			internal static method CFrmel_setStatusTip;

			// Token: 0x0400081E RID: 2078
			internal static method CFrmel_toolTipDuration;

			// Token: 0x0400081F RID: 2079
			internal static method CFrmel_setToolTipDuration;

			// Token: 0x04000820 RID: 2080
			internal static method CFrmel_autoFillBackground;

			// Token: 0x04000821 RID: 2081
			internal static method CFrmel_setAutoFillBackground;
		}
	}
}
