using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000050 RID: 80
	internal struct QMainWindow
	{
		// Token: 0x06000B76 RID: 2934 RVA: 0x0001F091 File Offset: 0x0001D291
		public static implicit operator IntPtr(QMainWindow value)
		{
			return value.self;
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x0001F09C File Offset: 0x0001D29C
		public static implicit operator QMainWindow(IntPtr value)
		{
			return new QMainWindow
			{
				self = value
			};
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x0001F0BA File Offset: 0x0001D2BA
		public static bool operator ==(QMainWindow c1, QMainWindow c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x0001F0CD File Offset: 0x0001D2CD
		public static bool operator !=(QMainWindow c1, QMainWindow c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000B7A RID: 2938 RVA: 0x0001F0E0 File Offset: 0x0001D2E0
		public override bool Equals(object obj)
		{
			if (obj is QMainWindow)
			{
				QMainWindow c = (QMainWindow)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x0001F10A File Offset: 0x0001D30A
		internal QMainWindow(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x0001F114 File Offset: 0x0001D314
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QMainWindow ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000B7D RID: 2941 RVA: 0x0001F150 File Offset: 0x0001D350
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000B7E RID: 2942 RVA: 0x0001F162 File Offset: 0x0001D362
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x0001F16D File Offset: 0x0001D36D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x0001F180 File Offset: 0x0001D380
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QMainWindow was null when calling " + n);
			}
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x0001F19B File Offset: 0x0001D39B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x0001F1A8 File Offset: 0x0001D3A8
		public static implicit operator QWidget(QMainWindow value)
		{
			method to_QWidget_From_QMainWindow = QMainWindow.__N.To_QWidget_From_QMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QMainWindow);
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x0001F1CC File Offset: 0x0001D3CC
		public static explicit operator QMainWindow(QWidget value)
		{
			method from_QWidget_To_QMainWindow = QMainWindow.__N.From_QWidget_To_QMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QMainWindow);
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x0001F1F0 File Offset: 0x0001D3F0
		public static implicit operator QObject(QMainWindow value)
		{
			method to_QObject_From_QMainWindow = QMainWindow.__N.To_QObject_From_QMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QMainWindow);
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x0001F214 File Offset: 0x0001D414
		public static explicit operator QMainWindow(QObject value)
		{
			method from_QObject_To_QMainWindow = QMainWindow.__N.From_QObject_To_QMainWindow;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QMainWindow);
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x0001F238 File Offset: 0x0001D438
		internal readonly Vector3 iconSize()
		{
			this.NullCheck("iconSize");
			method qmnWnd_iconSize = QMainWindow.__N.QMnWnd_iconSize;
			return calli(Vector3(System.IntPtr), this.self, qmnWnd_iconSize);
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x0001F264 File Offset: 0x0001D464
		internal readonly void setIconSize(Vector3 iconSize)
		{
			this.NullCheck("setIconSize");
			method qmnWnd_setIconSize = QMainWindow.__N.QMnWnd_setIconSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, iconSize, qmnWnd_setIconSize);
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x0001F290 File Offset: 0x0001D490
		internal readonly QMenuBar menuBar()
		{
			this.NullCheck("menuBar");
			method qmnWnd_menuBar = QMainWindow.__N.QMnWnd_menuBar;
			return calli(System.IntPtr(System.IntPtr), this.self, qmnWnd_menuBar);
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x0001F2C0 File Offset: 0x0001D4C0
		internal readonly void setMenuBar(QMenuBar menubar)
		{
			this.NullCheck("setMenuBar");
			method qmnWnd_setMenuBar = QMainWindow.__N.QMnWnd_setMenuBar;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, menubar, qmnWnd_setMenuBar);
		}

		// Token: 0x06000B8A RID: 2954 RVA: 0x0001F2F0 File Offset: 0x0001D4F0
		internal readonly void setMenuWidget(QWidget menubar)
		{
			this.NullCheck("setMenuWidget");
			method qmnWnd_setMenuWidget = QMainWindow.__N.QMnWnd_setMenuWidget;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, menubar, qmnWnd_setMenuWidget);
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x0001F320 File Offset: 0x0001D520
		internal readonly QStatusBar statusBar()
		{
			this.NullCheck("statusBar");
			method qmnWnd_statusBar = QMainWindow.__N.QMnWnd_statusBar;
			return calli(System.IntPtr(System.IntPtr), this.self, qmnWnd_statusBar);
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x0001F350 File Offset: 0x0001D550
		internal readonly void setStatusBar(QStatusBar statusbar)
		{
			this.NullCheck("setStatusBar");
			method qmnWnd_setStatusBar = QMainWindow.__N.QMnWnd_setStatusBar;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, statusbar, qmnWnd_setStatusBar);
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x0001F380 File Offset: 0x0001D580
		internal readonly QWidget centralWidget()
		{
			this.NullCheck("centralWidget");
			method qmnWnd_centralWidget = QMainWindow.__N.QMnWnd_centralWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qmnWnd_centralWidget);
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x0001F3B0 File Offset: 0x0001D5B0
		internal readonly void setCentralWidget(QWidget widget)
		{
			this.NullCheck("setCentralWidget");
			method qmnWnd_setCentralWidget = QMainWindow.__N.QMnWnd_setCentralWidget;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qmnWnd_setCentralWidget);
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x0001F3E0 File Offset: 0x0001D5E0
		internal readonly void addDockWidget(DockArea area, QDockWidget dockwidget)
		{
			this.NullCheck("addDockWidget");
			method qmnWnd_addDockWidget = QMainWindow.__N.QMnWnd_addDockWidget;
			calli(System.Void(System.IntPtr,System.Int64,System.IntPtr), this.self, (long)area, dockwidget, qmnWnd_addDockWidget);
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x0001F414 File Offset: 0x0001D614
		internal readonly void tabifyDockWidget(QDockWidget first, QDockWidget second)
		{
			this.NullCheck("tabifyDockWidget");
			method qmnWnd_tabifyDockWidget = QMainWindow.__N.QMnWnd_tabifyDockWidget;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, first, second, qmnWnd_tabifyDockWidget);
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x0001F44C File Offset: 0x0001D64C
		internal readonly bool isAnimated()
		{
			this.NullCheck("isAnimated");
			method qmnWnd_isAnimated = QMainWindow.__N.QMnWnd_isAnimated;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_isAnimated) > 0;
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x0001F47C File Offset: 0x0001D67C
		internal readonly void setAnimated(bool enabled)
		{
			this.NullCheck("setAnimated");
			method qmnWnd_setAnimated = QMainWindow.__N.QMnWnd_setAnimated;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qmnWnd_setAnimated);
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x0001F4B0 File Offset: 0x0001D6B0
		internal readonly void addToolBarBreak(ToolbarPosition area)
		{
			this.NullCheck("addToolBarBreak");
			method qmnWnd_addToolBarBreak = QMainWindow.__N.QMnWnd_addToolBarBreak;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)area, qmnWnd_addToolBarBreak);
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x0001F4DC File Offset: 0x0001D6DC
		internal readonly void insertToolBarBreak(QToolBar before)
		{
			this.NullCheck("insertToolBarBreak");
			method qmnWnd_insertToolBarBreak = QMainWindow.__N.QMnWnd_insertToolBarBreak;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, before, qmnWnd_insertToolBarBreak);
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x0001F50C File Offset: 0x0001D70C
		internal readonly void addToolBar(ToolbarPosition area, QToolBar toolbar)
		{
			this.NullCheck("addToolBar");
			method qmnWnd_addToolBar = QMainWindow.__N.QMnWnd_addToolBar;
			calli(System.Void(System.IntPtr,System.Int64,System.IntPtr), this.self, (long)area, toolbar, qmnWnd_addToolBar);
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x0001F540 File Offset: 0x0001D740
		internal readonly void addToolBar(QToolBar toolbar)
		{
			this.NullCheck("addToolBar");
			method qmnWnd_f = QMainWindow.__N.QMnWnd_f2;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, toolbar, qmnWnd_f);
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x0001F570 File Offset: 0x0001D770
		internal readonly void insertToolBar(QToolBar before, QToolBar toolbar)
		{
			this.NullCheck("insertToolBar");
			method qmnWnd_insertToolBar = QMainWindow.__N.QMnWnd_insertToolBar;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, before, toolbar, qmnWnd_insertToolBar);
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x0001F5A8 File Offset: 0x0001D7A8
		internal readonly void removeToolBar(QToolBar toolbar)
		{
			this.NullCheck("removeToolBar");
			method qmnWnd_removeToolBar = QMainWindow.__N.QMnWnd_removeToolBar;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, toolbar, qmnWnd_removeToolBar);
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x0001F5D8 File Offset: 0x0001D7D8
		internal readonly void removeToolBarBreak(QToolBar before)
		{
			this.NullCheck("removeToolBarBreak");
			method qmnWnd_removeToolBarBreak = QMainWindow.__N.QMnWnd_removeToolBarBreak;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, before, qmnWnd_removeToolBarBreak);
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x0001F608 File Offset: 0x0001D808
		internal readonly string saveState(int version)
		{
			this.NullCheck("saveState");
			method qmnWnd_saveState = QMainWindow.__N.QMnWnd_saveState;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.Int32), this.self, version, qmnWnd_saveState));
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x0001F638 File Offset: 0x0001D838
		internal readonly bool restoreState(string state)
		{
			this.NullCheck("restoreState");
			method qmnWnd_restoreState = QMainWindow.__N.QMnWnd_restoreState;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qmnWnd_restoreState) > 0;
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x0001F66C File Offset: 0x0001D86C
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qmnWnd_isTopLevel = QMainWindow.__N.QMnWnd_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_isTopLevel) > 0;
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x0001F69C File Offset: 0x0001D89C
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qmnWnd_isWindow = QMainWindow.__N.QMnWnd_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_isWindow) > 0;
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x0001F6CC File Offset: 0x0001D8CC
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qmnWnd_isModal = QMainWindow.__N.QMnWnd_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_isModal) > 0;
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x0001F6FC File Offset: 0x0001D8FC
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qmnWnd_setStyleSheet = QMainWindow.__N.QMnWnd_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qmnWnd_setStyleSheet);
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x0001F72C File Offset: 0x0001D92C
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qmnWnd_windowTitle = QMainWindow.__N.QMnWnd_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qmnWnd_windowTitle));
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x0001F75C File Offset: 0x0001D95C
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qmnWnd_setWindowTitle = QMainWindow.__N.QMnWnd_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qmnWnd_setWindowTitle);
		}

		// Token: 0x06000BA2 RID: 2978 RVA: 0x0001F78C File Offset: 0x0001D98C
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qmnWnd_setWindowFlags = QMainWindow.__N.QMnWnd_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qmnWnd_setWindowFlags);
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x0001F7B8 File Offset: 0x0001D9B8
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qmnWnd_windowFlags = QMainWindow.__N.QMnWnd_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qmnWnd_windowFlags);
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x0001F7E4 File Offset: 0x0001D9E4
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qmnWnd_size = QMainWindow.__N.QMnWnd_size;
			return calli(Vector3(System.IntPtr), this.self, qmnWnd_size);
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x0001F810 File Offset: 0x0001DA10
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qmnWnd_resize = QMainWindow.__N.QMnWnd_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qmnWnd_resize);
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x0001F83C File Offset: 0x0001DA3C
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qmnWnd_minimumSize = QMainWindow.__N.QMnWnd_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qmnWnd_minimumSize);
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x0001F868 File Offset: 0x0001DA68
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qmnWnd_setMinimumSize = QMainWindow.__N.QMnWnd_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qmnWnd_setMinimumSize);
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x0001F894 File Offset: 0x0001DA94
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qmnWnd_maximumSize = QMainWindow.__N.QMnWnd_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qmnWnd_maximumSize);
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x0001F8C0 File Offset: 0x0001DAC0
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qmnWnd_setMaximumSize = QMainWindow.__N.QMnWnd_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qmnWnd_setMaximumSize);
		}

		// Token: 0x06000BAA RID: 2986 RVA: 0x0001F8EC File Offset: 0x0001DAEC
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qmnWnd_pos = QMainWindow.__N.QMnWnd_pos;
			return calli(Vector3(System.IntPtr), this.self, qmnWnd_pos);
		}

		// Token: 0x06000BAB RID: 2987 RVA: 0x0001F918 File Offset: 0x0001DB18
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qmnWnd_move = QMainWindow.__N.QMnWnd_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qmnWnd_move);
		}

		// Token: 0x06000BAC RID: 2988 RVA: 0x0001F944 File Offset: 0x0001DB44
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qmnWnd_isEnabled = QMainWindow.__N.QMnWnd_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_isEnabled) > 0;
		}

		// Token: 0x06000BAD RID: 2989 RVA: 0x0001F974 File Offset: 0x0001DB74
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qmnWnd_setEnabled = QMainWindow.__N.QMnWnd_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qmnWnd_setEnabled);
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x0001F9A8 File Offset: 0x0001DBA8
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qmnWnd_setVisible = QMainWindow.__N.QMnWnd_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qmnWnd_setVisible);
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x0001F9DC File Offset: 0x0001DBDC
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qmnWnd_setHidden = QMainWindow.__N.QMnWnd_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qmnWnd_setHidden);
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x0001FA10 File Offset: 0x0001DC10
		internal readonly void show()
		{
			this.NullCheck("show");
			method qmnWnd_show = QMainWindow.__N.QMnWnd_show;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_show);
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x0001FA3C File Offset: 0x0001DC3C
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qmnWnd_hide = QMainWindow.__N.QMnWnd_hide;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_hide);
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0001FA68 File Offset: 0x0001DC68
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qmnWnd_showMinimized = QMainWindow.__N.QMnWnd_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_showMinimized);
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x0001FA94 File Offset: 0x0001DC94
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qmnWnd_showMaximized = QMainWindow.__N.QMnWnd_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_showMaximized);
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x0001FAC0 File Offset: 0x0001DCC0
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qmnWnd_showFullScreen = QMainWindow.__N.QMnWnd_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_showFullScreen);
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x0001FAEC File Offset: 0x0001DCEC
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qmnWnd_showNormal = QMainWindow.__N.QMnWnd_showNormal;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_showNormal);
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x0001FB18 File Offset: 0x0001DD18
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qmnWnd_close = QMainWindow.__N.QMnWnd_close;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_close) > 0;
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x0001FB48 File Offset: 0x0001DD48
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qmnWnd_raise = QMainWindow.__N.QMnWnd_raise;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_raise);
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x0001FB74 File Offset: 0x0001DD74
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qmnWnd_lower = QMainWindow.__N.QMnWnd_lower;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_lower);
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x0001FBA0 File Offset: 0x0001DDA0
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qmnWnd_isVisible = QMainWindow.__N.QMnWnd_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_isVisible) > 0;
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x0001FBD0 File Offset: 0x0001DDD0
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qmnWnd_setAttribute = QMainWindow.__N.QMnWnd_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qmnWnd_setAttribute);
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x0001FC04 File Offset: 0x0001DE04
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qmnWnd_testAttribute = QMainWindow.__N.QMnWnd_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qmnWnd_testAttribute) > 0;
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x0001FC34 File Offset: 0x0001DE34
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qmnWnd_acceptDrops = QMainWindow.__N.QMnWnd_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_acceptDrops) > 0;
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x0001FC64 File Offset: 0x0001DE64
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qmnWnd_setAcceptDrops = QMainWindow.__N.QMnWnd_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qmnWnd_setAcceptDrops);
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x0001FC98 File Offset: 0x0001DE98
		internal readonly void update()
		{
			this.NullCheck("update");
			method qmnWnd_update = QMainWindow.__N.QMnWnd_update;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_update);
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x0001FCC4 File Offset: 0x0001DEC4
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qmnWnd_repaint = QMainWindow.__N.QMnWnd_repaint;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_repaint);
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x0001FCF0 File Offset: 0x0001DEF0
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qmnWnd_setCursor = QMainWindow.__N.QMnWnd_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qmnWnd_setCursor);
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x0001FD1C File Offset: 0x0001DF1C
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qmnWnd_unsetCursor = QMainWindow.__N.QMnWnd_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_unsetCursor);
		}

		// Token: 0x06000BC2 RID: 3010 RVA: 0x0001FD48 File Offset: 0x0001DF48
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qmnWnd_setWindowIcon = QMainWindow.__N.QMnWnd_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qmnWnd_setWindowIcon);
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x0001FD78 File Offset: 0x0001DF78
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qmnWnd_setWindowIconText = QMainWindow.__N.QMnWnd_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qmnWnd_setWindowIconText);
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x0001FDA8 File Offset: 0x0001DFA8
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qmnWnd_setWindowOpacity = QMainWindow.__N.QMnWnd_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qmnWnd_setWindowOpacity);
		}

		// Token: 0x06000BC5 RID: 3013 RVA: 0x0001FDD4 File Offset: 0x0001DFD4
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qmnWnd_windowOpacity = QMainWindow.__N.QMnWnd_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qmnWnd_windowOpacity);
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x0001FE00 File Offset: 0x0001E000
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qmnWnd_isMinimized = QMainWindow.__N.QMnWnd_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_isMinimized) > 0;
		}

		// Token: 0x06000BC7 RID: 3015 RVA: 0x0001FE30 File Offset: 0x0001E030
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qmnWnd_isMaximized = QMainWindow.__N.QMnWnd_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_isMaximized) > 0;
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x0001FE60 File Offset: 0x0001E060
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qmnWnd_isFullScreen = QMainWindow.__N.QMnWnd_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_isFullScreen) > 0;
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x0001FE90 File Offset: 0x0001E090
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qmnWnd_setMouseTracking = QMainWindow.__N.QMnWnd_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qmnWnd_setMouseTracking);
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x0001FEC4 File Offset: 0x0001E0C4
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qmnWnd_hasMouseTracking = QMainWindow.__N.QMnWnd_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_hasMouseTracking) > 0;
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x0001FEF4 File Offset: 0x0001E0F4
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qmnWnd_underMouse = QMainWindow.__N.QMnWnd_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_underMouse) > 0;
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x0001FF24 File Offset: 0x0001E124
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qmnWnd_mapToGlobal = QMainWindow.__N.QMnWnd_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qmnWnd_mapToGlobal);
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x0001FF50 File Offset: 0x0001E150
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qmnWnd_mapFromGlobal = QMainWindow.__N.QMnWnd_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qmnWnd_mapFromGlobal);
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x0001FF7C File Offset: 0x0001E17C
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qmnWnd_hasFocus = QMainWindow.__N.QMnWnd_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_hasFocus) > 0;
		}

		// Token: 0x06000BCF RID: 3023 RVA: 0x0001FFAC File Offset: 0x0001E1AC
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qmnWnd_focusPolicy = QMainWindow.__N.QMnWnd_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qmnWnd_focusPolicy);
		}

		// Token: 0x06000BD0 RID: 3024 RVA: 0x0001FFD8 File Offset: 0x0001E1D8
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qmnWnd_setFocusPolicy = QMainWindow.__N.QMnWnd_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qmnWnd_setFocusPolicy);
		}

		// Token: 0x06000BD1 RID: 3025 RVA: 0x00020004 File Offset: 0x0001E204
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qmnWnd_setFocusProxy = QMainWindow.__N.QMnWnd_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qmnWnd_setFocusProxy);
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x00020034 File Offset: 0x0001E234
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qmnWnd_isActiveWindow = QMainWindow.__N.QMnWnd_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_isActiveWindow) > 0;
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x00020064 File Offset: 0x0001E264
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qmnWnd_updatesEnabled = QMainWindow.__N.QMnWnd_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_updatesEnabled) > 0;
		}

		// Token: 0x06000BD4 RID: 3028 RVA: 0x00020094 File Offset: 0x0001E294
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qmnWnd_setUpdatesEnabled = QMainWindow.__N.QMnWnd_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qmnWnd_setUpdatesEnabled);
		}

		// Token: 0x06000BD5 RID: 3029 RVA: 0x000200C8 File Offset: 0x0001E2C8
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qmnWnd_setFocus = QMainWindow.__N.QMnWnd_setFocus;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_setFocus);
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x000200F4 File Offset: 0x0001E2F4
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qmnWnd_activateWindow = QMainWindow.__N.QMnWnd_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_activateWindow);
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x00020120 File Offset: 0x0001E320
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qmnWnd_clearFocus = QMainWindow.__N.QMnWnd_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_clearFocus);
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x0002014C File Offset: 0x0001E34C
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qmnWnd_setSizePolicy = QMainWindow.__N.QMnWnd_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qmnWnd_setSizePolicy);
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x0002017C File Offset: 0x0001E37C
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qmnWnd_devicePixelRatioF = QMainWindow.__N.QMnWnd_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qmnWnd_devicePixelRatioF);
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x000201A8 File Offset: 0x0001E3A8
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qmnWnd_saveGeometry = QMainWindow.__N.QMnWnd_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qmnWnd_saveGeometry));
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x000201D8 File Offset: 0x0001E3D8
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qmnWnd_restoreGeometry = QMainWindow.__N.QMnWnd_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qmnWnd_restoreGeometry) > 0;
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x0002020C File Offset: 0x0001E40C
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qmnWnd_addAction = QMainWindow.__N.QMnWnd_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qmnWnd_addAction);
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x0002023C File Offset: 0x0001E43C
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qmnWnd_removeAction = QMainWindow.__N.QMnWnd_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qmnWnd_removeAction);
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x0002026C File Offset: 0x0001E46C
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qmnWnd_setParent = QMainWindow.__N.QMnWnd_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qmnWnd_setParent);
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x0002029C File Offset: 0x0001E49C
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qmnWnd_parentWidget = QMainWindow.__N.QMnWnd_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qmnWnd_parentWidget);
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x000202CC File Offset: 0x0001E4CC
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qmnWnd_AddClassName = QMainWindow.__N.QMnWnd_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qmnWnd_AddClassName);
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x000202FC File Offset: 0x0001E4FC
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qmnWnd_Polish = QMainWindow.__N.QMnWnd_Polish;
			calli(System.Void(System.IntPtr), this.self, qmnWnd_Polish);
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x00020328 File Offset: 0x0001E528
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qmnWnd_toolTip = QMainWindow.__N.QMnWnd_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qmnWnd_toolTip));
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x00020358 File Offset: 0x0001E558
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qmnWnd_setToolTip = QMainWindow.__N.QMnWnd_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qmnWnd_setToolTip);
		}

		// Token: 0x06000BE4 RID: 3044 RVA: 0x00020388 File Offset: 0x0001E588
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qmnWnd_statusTip = QMainWindow.__N.QMnWnd_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qmnWnd_statusTip));
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x000203B8 File Offset: 0x0001E5B8
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qmnWnd_setStatusTip = QMainWindow.__N.QMnWnd_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qmnWnd_setStatusTip);
		}

		// Token: 0x06000BE6 RID: 3046 RVA: 0x000203E8 File Offset: 0x0001E5E8
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qmnWnd_toolTipDuration = QMainWindow.__N.QMnWnd_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_toolTipDuration);
		}

		// Token: 0x06000BE7 RID: 3047 RVA: 0x00020414 File Offset: 0x0001E614
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qmnWnd_setToolTipDuration = QMainWindow.__N.QMnWnd_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qmnWnd_setToolTipDuration);
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x00020440 File Offset: 0x0001E640
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qmnWnd_autoFillBackground = QMainWindow.__N.QMnWnd_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qmnWnd_autoFillBackground) > 0;
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x00020470 File Offset: 0x0001E670
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qmnWnd_setAutoFillBackground = QMainWindow.__N.QMnWnd_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qmnWnd_setAutoFillBackground);
		}

		// Token: 0x0400005B RID: 91
		internal IntPtr self;

		// Token: 0x0200011C RID: 284
		internal static class __N
		{
			// Token: 0x04000D7C RID: 3452
			internal static method From_QWidget_To_QMainWindow;

			// Token: 0x04000D7D RID: 3453
			internal static method To_QWidget_From_QMainWindow;

			// Token: 0x04000D7E RID: 3454
			internal static method From_QObject_To_QMainWindow;

			// Token: 0x04000D7F RID: 3455
			internal static method To_QObject_From_QMainWindow;

			// Token: 0x04000D80 RID: 3456
			internal static method QMnWnd_iconSize;

			// Token: 0x04000D81 RID: 3457
			internal static method QMnWnd_setIconSize;

			// Token: 0x04000D82 RID: 3458
			internal static method QMnWnd_menuBar;

			// Token: 0x04000D83 RID: 3459
			internal static method QMnWnd_setMenuBar;

			// Token: 0x04000D84 RID: 3460
			internal static method QMnWnd_setMenuWidget;

			// Token: 0x04000D85 RID: 3461
			internal static method QMnWnd_statusBar;

			// Token: 0x04000D86 RID: 3462
			internal static method QMnWnd_setStatusBar;

			// Token: 0x04000D87 RID: 3463
			internal static method QMnWnd_centralWidget;

			// Token: 0x04000D88 RID: 3464
			internal static method QMnWnd_setCentralWidget;

			// Token: 0x04000D89 RID: 3465
			internal static method QMnWnd_addDockWidget;

			// Token: 0x04000D8A RID: 3466
			internal static method QMnWnd_tabifyDockWidget;

			// Token: 0x04000D8B RID: 3467
			internal static method QMnWnd_isAnimated;

			// Token: 0x04000D8C RID: 3468
			internal static method QMnWnd_setAnimated;

			// Token: 0x04000D8D RID: 3469
			internal static method QMnWnd_addToolBarBreak;

			// Token: 0x04000D8E RID: 3470
			internal static method QMnWnd_insertToolBarBreak;

			// Token: 0x04000D8F RID: 3471
			internal static method QMnWnd_addToolBar;

			// Token: 0x04000D90 RID: 3472
			internal static method QMnWnd_f2;

			// Token: 0x04000D91 RID: 3473
			internal static method QMnWnd_insertToolBar;

			// Token: 0x04000D92 RID: 3474
			internal static method QMnWnd_removeToolBar;

			// Token: 0x04000D93 RID: 3475
			internal static method QMnWnd_removeToolBarBreak;

			// Token: 0x04000D94 RID: 3476
			internal static method QMnWnd_saveState;

			// Token: 0x04000D95 RID: 3477
			internal static method QMnWnd_restoreState;

			// Token: 0x04000D96 RID: 3478
			internal static method QMnWnd_isTopLevel;

			// Token: 0x04000D97 RID: 3479
			internal static method QMnWnd_isWindow;

			// Token: 0x04000D98 RID: 3480
			internal static method QMnWnd_isModal;

			// Token: 0x04000D99 RID: 3481
			internal static method QMnWnd_setStyleSheet;

			// Token: 0x04000D9A RID: 3482
			internal static method QMnWnd_windowTitle;

			// Token: 0x04000D9B RID: 3483
			internal static method QMnWnd_setWindowTitle;

			// Token: 0x04000D9C RID: 3484
			internal static method QMnWnd_setWindowFlags;

			// Token: 0x04000D9D RID: 3485
			internal static method QMnWnd_windowFlags;

			// Token: 0x04000D9E RID: 3486
			internal static method QMnWnd_size;

			// Token: 0x04000D9F RID: 3487
			internal static method QMnWnd_resize;

			// Token: 0x04000DA0 RID: 3488
			internal static method QMnWnd_minimumSize;

			// Token: 0x04000DA1 RID: 3489
			internal static method QMnWnd_setMinimumSize;

			// Token: 0x04000DA2 RID: 3490
			internal static method QMnWnd_maximumSize;

			// Token: 0x04000DA3 RID: 3491
			internal static method QMnWnd_setMaximumSize;

			// Token: 0x04000DA4 RID: 3492
			internal static method QMnWnd_pos;

			// Token: 0x04000DA5 RID: 3493
			internal static method QMnWnd_move;

			// Token: 0x04000DA6 RID: 3494
			internal static method QMnWnd_isEnabled;

			// Token: 0x04000DA7 RID: 3495
			internal static method QMnWnd_setEnabled;

			// Token: 0x04000DA8 RID: 3496
			internal static method QMnWnd_setVisible;

			// Token: 0x04000DA9 RID: 3497
			internal static method QMnWnd_setHidden;

			// Token: 0x04000DAA RID: 3498
			internal static method QMnWnd_show;

			// Token: 0x04000DAB RID: 3499
			internal static method QMnWnd_hide;

			// Token: 0x04000DAC RID: 3500
			internal static method QMnWnd_showMinimized;

			// Token: 0x04000DAD RID: 3501
			internal static method QMnWnd_showMaximized;

			// Token: 0x04000DAE RID: 3502
			internal static method QMnWnd_showFullScreen;

			// Token: 0x04000DAF RID: 3503
			internal static method QMnWnd_showNormal;

			// Token: 0x04000DB0 RID: 3504
			internal static method QMnWnd_close;

			// Token: 0x04000DB1 RID: 3505
			internal static method QMnWnd_raise;

			// Token: 0x04000DB2 RID: 3506
			internal static method QMnWnd_lower;

			// Token: 0x04000DB3 RID: 3507
			internal static method QMnWnd_isVisible;

			// Token: 0x04000DB4 RID: 3508
			internal static method QMnWnd_setAttribute;

			// Token: 0x04000DB5 RID: 3509
			internal static method QMnWnd_testAttribute;

			// Token: 0x04000DB6 RID: 3510
			internal static method QMnWnd_acceptDrops;

			// Token: 0x04000DB7 RID: 3511
			internal static method QMnWnd_setAcceptDrops;

			// Token: 0x04000DB8 RID: 3512
			internal static method QMnWnd_update;

			// Token: 0x04000DB9 RID: 3513
			internal static method QMnWnd_repaint;

			// Token: 0x04000DBA RID: 3514
			internal static method QMnWnd_setCursor;

			// Token: 0x04000DBB RID: 3515
			internal static method QMnWnd_unsetCursor;

			// Token: 0x04000DBC RID: 3516
			internal static method QMnWnd_setWindowIcon;

			// Token: 0x04000DBD RID: 3517
			internal static method QMnWnd_setWindowIconText;

			// Token: 0x04000DBE RID: 3518
			internal static method QMnWnd_setWindowOpacity;

			// Token: 0x04000DBF RID: 3519
			internal static method QMnWnd_windowOpacity;

			// Token: 0x04000DC0 RID: 3520
			internal static method QMnWnd_isMinimized;

			// Token: 0x04000DC1 RID: 3521
			internal static method QMnWnd_isMaximized;

			// Token: 0x04000DC2 RID: 3522
			internal static method QMnWnd_isFullScreen;

			// Token: 0x04000DC3 RID: 3523
			internal static method QMnWnd_setMouseTracking;

			// Token: 0x04000DC4 RID: 3524
			internal static method QMnWnd_hasMouseTracking;

			// Token: 0x04000DC5 RID: 3525
			internal static method QMnWnd_underMouse;

			// Token: 0x04000DC6 RID: 3526
			internal static method QMnWnd_mapToGlobal;

			// Token: 0x04000DC7 RID: 3527
			internal static method QMnWnd_mapFromGlobal;

			// Token: 0x04000DC8 RID: 3528
			internal static method QMnWnd_hasFocus;

			// Token: 0x04000DC9 RID: 3529
			internal static method QMnWnd_focusPolicy;

			// Token: 0x04000DCA RID: 3530
			internal static method QMnWnd_setFocusPolicy;

			// Token: 0x04000DCB RID: 3531
			internal static method QMnWnd_setFocusProxy;

			// Token: 0x04000DCC RID: 3532
			internal static method QMnWnd_isActiveWindow;

			// Token: 0x04000DCD RID: 3533
			internal static method QMnWnd_updatesEnabled;

			// Token: 0x04000DCE RID: 3534
			internal static method QMnWnd_setUpdatesEnabled;

			// Token: 0x04000DCF RID: 3535
			internal static method QMnWnd_setFocus;

			// Token: 0x04000DD0 RID: 3536
			internal static method QMnWnd_activateWindow;

			// Token: 0x04000DD1 RID: 3537
			internal static method QMnWnd_clearFocus;

			// Token: 0x04000DD2 RID: 3538
			internal static method QMnWnd_setSizePolicy;

			// Token: 0x04000DD3 RID: 3539
			internal static method QMnWnd_devicePixelRatioF;

			// Token: 0x04000DD4 RID: 3540
			internal static method QMnWnd_saveGeometry;

			// Token: 0x04000DD5 RID: 3541
			internal static method QMnWnd_restoreGeometry;

			// Token: 0x04000DD6 RID: 3542
			internal static method QMnWnd_addAction;

			// Token: 0x04000DD7 RID: 3543
			internal static method QMnWnd_removeAction;

			// Token: 0x04000DD8 RID: 3544
			internal static method QMnWnd_setParent;

			// Token: 0x04000DD9 RID: 3545
			internal static method QMnWnd_parentWidget;

			// Token: 0x04000DDA RID: 3546
			internal static method QMnWnd_AddClassName;

			// Token: 0x04000DDB RID: 3547
			internal static method QMnWnd_Polish;

			// Token: 0x04000DDC RID: 3548
			internal static method QMnWnd_toolTip;

			// Token: 0x04000DDD RID: 3549
			internal static method QMnWnd_setToolTip;

			// Token: 0x04000DDE RID: 3550
			internal static method QMnWnd_statusTip;

			// Token: 0x04000DDF RID: 3551
			internal static method QMnWnd_setStatusTip;

			// Token: 0x04000DE0 RID: 3552
			internal static method QMnWnd_toolTipDuration;

			// Token: 0x04000DE1 RID: 3553
			internal static method QMnWnd_setToolTipDuration;

			// Token: 0x04000DE2 RID: 3554
			internal static method QMnWnd_autoFillBackground;

			// Token: 0x04000DE3 RID: 3555
			internal static method QMnWnd_setAutoFillBackground;
		}
	}
}
