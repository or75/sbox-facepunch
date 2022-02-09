using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000045 RID: 69
	internal struct QDockWidget
	{
		// Token: 0x06000801 RID: 2049 RVA: 0x00015CF9 File Offset: 0x00013EF9
		public static implicit operator IntPtr(QDockWidget value)
		{
			return value.self;
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x00015D04 File Offset: 0x00013F04
		public static implicit operator QDockWidget(IntPtr value)
		{
			return new QDockWidget
			{
				self = value
			};
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x00015D22 File Offset: 0x00013F22
		public static bool operator ==(QDockWidget c1, QDockWidget c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x00015D35 File Offset: 0x00013F35
		public static bool operator !=(QDockWidget c1, QDockWidget c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x00015D48 File Offset: 0x00013F48
		public override bool Equals(object obj)
		{
			if (obj is QDockWidget)
			{
				QDockWidget c = (QDockWidget)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x00015D72 File Offset: 0x00013F72
		internal QDockWidget(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x00015D7C File Offset: 0x00013F7C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QDockWidget ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x00015DB8 File Offset: 0x00013FB8
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x00015DCA File Offset: 0x00013FCA
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x00015DD5 File Offset: 0x00013FD5
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x00015DE8 File Offset: 0x00013FE8
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QDockWidget was null when calling " + n);
			}
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00015E03 File Offset: 0x00014003
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x00015E10 File Offset: 0x00014010
		public static implicit operator QWidget(QDockWidget value)
		{
			method to_QWidget_From_QDockWidget = QDockWidget.__N.To_QWidget_From_QDockWidget;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QDockWidget);
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x00015E34 File Offset: 0x00014034
		public static explicit operator QDockWidget(QWidget value)
		{
			method from_QWidget_To_QDockWidget = QDockWidget.__N.From_QWidget_To_QDockWidget;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QDockWidget);
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x00015E58 File Offset: 0x00014058
		public static implicit operator QObject(QDockWidget value)
		{
			method to_QObject_From_QDockWidget = QDockWidget.__N.To_QObject_From_QDockWidget;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QDockWidget);
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x00015E7C File Offset: 0x0001407C
		public static explicit operator QDockWidget(QObject value)
		{
			method from_QObject_To_QDockWidget = QDockWidget.__N.From_QObject_To_QDockWidget;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QDockWidget);
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x00015EA0 File Offset: 0x000140A0
		internal readonly QWidget widget()
		{
			this.NullCheck("widget");
			method qdckWd_widget = QDockWidget.__N.QDckWd_widget;
			return calli(System.IntPtr(System.IntPtr), this.self, qdckWd_widget);
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x00015ED0 File Offset: 0x000140D0
		internal readonly void setWidget(QWidget widget)
		{
			this.NullCheck("setWidget");
			method qdckWd_setWidget = QDockWidget.__N.QDckWd_setWidget;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qdckWd_setWidget);
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x00015F00 File Offset: 0x00014100
		internal readonly void setFeatures(DockWidgetFeatures features)
		{
			this.NullCheck("setFeatures");
			method qdckWd_setFeatures = QDockWidget.__N.QDckWd_setFeatures;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)features, qdckWd_setFeatures);
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x00015F2C File Offset: 0x0001412C
		internal readonly DockWidgetFeatures features()
		{
			this.NullCheck("features");
			method qdckWd_features = QDockWidget.__N.QDckWd_features;
			return calli(System.Int64(System.IntPtr), this.self, qdckWd_features);
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x00015F58 File Offset: 0x00014158
		internal readonly void setFloating(bool floating)
		{
			this.NullCheck("setFloating");
			method qdckWd_setFloating = QDockWidget.__N.QDckWd_setFloating;
			calli(System.Void(System.IntPtr,System.Int32), this.self, floating ? 1 : 0, qdckWd_setFloating);
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x00015F8C File Offset: 0x0001418C
		internal readonly bool isFloating()
		{
			this.NullCheck("isFloating");
			method qdckWd_isFloating = QDockWidget.__N.QDckWd_isFloating;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_isFloating) > 0;
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x00015FBC File Offset: 0x000141BC
		internal readonly void setAllowedAreas(DockArea areas)
		{
			this.NullCheck("setAllowedAreas");
			method qdckWd_setAllowedAreas = QDockWidget.__N.QDckWd_setAllowedAreas;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)areas, qdckWd_setAllowedAreas);
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x00015FE8 File Offset: 0x000141E8
		internal readonly DockArea allowedAreas()
		{
			this.NullCheck("allowedAreas");
			method qdckWd_allowedAreas = QDockWidget.__N.QDckWd_allowedAreas;
			return calli(System.Int64(System.IntPtr), this.self, qdckWd_allowedAreas);
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x00016014 File Offset: 0x00014214
		internal readonly void setIcon(string icon)
		{
			this.NullCheck("setIcon");
			method qdckWd_setIcon = QDockWidget.__N.QDckWd_setIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qdckWd_setIcon);
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x00016044 File Offset: 0x00014244
		internal readonly QAction toggleViewAction()
		{
			this.NullCheck("toggleViewAction");
			method qdckWd_toggleViewAction = QDockWidget.__N.QDckWd_toggleViewAction;
			return calli(System.IntPtr(System.IntPtr), this.self, qdckWd_toggleViewAction);
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x00016074 File Offset: 0x00014274
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qdckWd_isTopLevel = QDockWidget.__N.QDckWd_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_isTopLevel) > 0;
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x000160A4 File Offset: 0x000142A4
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qdckWd_isWindow = QDockWidget.__N.QDckWd_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_isWindow) > 0;
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x000160D4 File Offset: 0x000142D4
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qdckWd_isModal = QDockWidget.__N.QDckWd_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_isModal) > 0;
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x00016104 File Offset: 0x00014304
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qdckWd_setStyleSheet = QDockWidget.__N.QDckWd_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qdckWd_setStyleSheet);
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x00016134 File Offset: 0x00014334
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qdckWd_windowTitle = QDockWidget.__N.QDckWd_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qdckWd_windowTitle));
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x00016164 File Offset: 0x00014364
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qdckWd_setWindowTitle = QDockWidget.__N.QDckWd_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qdckWd_setWindowTitle);
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x00016194 File Offset: 0x00014394
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qdckWd_setWindowFlags = QDockWidget.__N.QDckWd_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qdckWd_setWindowFlags);
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x000161C0 File Offset: 0x000143C0
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qdckWd_windowFlags = QDockWidget.__N.QDckWd_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qdckWd_windowFlags);
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x000161EC File Offset: 0x000143EC
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qdckWd_size = QDockWidget.__N.QDckWd_size;
			return calli(Vector3(System.IntPtr), this.self, qdckWd_size);
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x00016218 File Offset: 0x00014418
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qdckWd_resize = QDockWidget.__N.QDckWd_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qdckWd_resize);
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x00016244 File Offset: 0x00014444
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qdckWd_minimumSize = QDockWidget.__N.QDckWd_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qdckWd_minimumSize);
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x00016270 File Offset: 0x00014470
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qdckWd_setMinimumSize = QDockWidget.__N.QDckWd_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qdckWd_setMinimumSize);
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x0001629C File Offset: 0x0001449C
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qdckWd_maximumSize = QDockWidget.__N.QDckWd_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qdckWd_maximumSize);
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x000162C8 File Offset: 0x000144C8
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qdckWd_setMaximumSize = QDockWidget.__N.QDckWd_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qdckWd_setMaximumSize);
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x000162F4 File Offset: 0x000144F4
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qdckWd_pos = QDockWidget.__N.QDckWd_pos;
			return calli(Vector3(System.IntPtr), this.self, qdckWd_pos);
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x00016320 File Offset: 0x00014520
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qdckWd_move = QDockWidget.__N.QDckWd_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qdckWd_move);
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x0001634C File Offset: 0x0001454C
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qdckWd_isEnabled = QDockWidget.__N.QDckWd_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_isEnabled) > 0;
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0001637C File Offset: 0x0001457C
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qdckWd_setEnabled = QDockWidget.__N.QDckWd_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qdckWd_setEnabled);
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x000163B0 File Offset: 0x000145B0
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qdckWd_setVisible = QDockWidget.__N.QDckWd_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qdckWd_setVisible);
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x000163E4 File Offset: 0x000145E4
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qdckWd_setHidden = QDockWidget.__N.QDckWd_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qdckWd_setHidden);
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x00016418 File Offset: 0x00014618
		internal readonly void show()
		{
			this.NullCheck("show");
			method qdckWd_show = QDockWidget.__N.QDckWd_show;
			calli(System.Void(System.IntPtr), this.self, qdckWd_show);
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x00016444 File Offset: 0x00014644
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qdckWd_hide = QDockWidget.__N.QDckWd_hide;
			calli(System.Void(System.IntPtr), this.self, qdckWd_hide);
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x00016470 File Offset: 0x00014670
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qdckWd_showMinimized = QDockWidget.__N.QDckWd_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qdckWd_showMinimized);
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x0001649C File Offset: 0x0001469C
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qdckWd_showMaximized = QDockWidget.__N.QDckWd_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qdckWd_showMaximized);
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x000164C8 File Offset: 0x000146C8
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qdckWd_showFullScreen = QDockWidget.__N.QDckWd_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qdckWd_showFullScreen);
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x000164F4 File Offset: 0x000146F4
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qdckWd_showNormal = QDockWidget.__N.QDckWd_showNormal;
			calli(System.Void(System.IntPtr), this.self, qdckWd_showNormal);
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x00016520 File Offset: 0x00014720
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qdckWd_close = QDockWidget.__N.QDckWd_close;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_close) > 0;
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x00016550 File Offset: 0x00014750
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qdckWd_raise = QDockWidget.__N.QDckWd_raise;
			calli(System.Void(System.IntPtr), this.self, qdckWd_raise);
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x0001657C File Offset: 0x0001477C
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qdckWd_lower = QDockWidget.__N.QDckWd_lower;
			calli(System.Void(System.IntPtr), this.self, qdckWd_lower);
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x000165A8 File Offset: 0x000147A8
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qdckWd_isVisible = QDockWidget.__N.QDckWd_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_isVisible) > 0;
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x000165D8 File Offset: 0x000147D8
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qdckWd_setAttribute = QDockWidget.__N.QDckWd_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qdckWd_setAttribute);
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x0001660C File Offset: 0x0001480C
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qdckWd_testAttribute = QDockWidget.__N.QDckWd_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qdckWd_testAttribute) > 0;
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x0001663C File Offset: 0x0001483C
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qdckWd_acceptDrops = QDockWidget.__N.QDckWd_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_acceptDrops) > 0;
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x0001666C File Offset: 0x0001486C
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qdckWd_setAcceptDrops = QDockWidget.__N.QDckWd_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qdckWd_setAcceptDrops);
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x000166A0 File Offset: 0x000148A0
		internal readonly void update()
		{
			this.NullCheck("update");
			method qdckWd_update = QDockWidget.__N.QDckWd_update;
			calli(System.Void(System.IntPtr), this.self, qdckWd_update);
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x000166CC File Offset: 0x000148CC
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qdckWd_repaint = QDockWidget.__N.QDckWd_repaint;
			calli(System.Void(System.IntPtr), this.self, qdckWd_repaint);
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x000166F8 File Offset: 0x000148F8
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qdckWd_setCursor = QDockWidget.__N.QDckWd_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qdckWd_setCursor);
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x00016724 File Offset: 0x00014924
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qdckWd_unsetCursor = QDockWidget.__N.QDckWd_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qdckWd_unsetCursor);
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x00016750 File Offset: 0x00014950
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qdckWd_setWindowIcon = QDockWidget.__N.QDckWd_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qdckWd_setWindowIcon);
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x00016780 File Offset: 0x00014980
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qdckWd_setWindowIconText = QDockWidget.__N.QDckWd_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qdckWd_setWindowIconText);
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x000167B0 File Offset: 0x000149B0
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qdckWd_setWindowOpacity = QDockWidget.__N.QDckWd_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qdckWd_setWindowOpacity);
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x000167DC File Offset: 0x000149DC
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qdckWd_windowOpacity = QDockWidget.__N.QDckWd_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qdckWd_windowOpacity);
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x00016808 File Offset: 0x00014A08
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qdckWd_isMinimized = QDockWidget.__N.QDckWd_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_isMinimized) > 0;
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x00016838 File Offset: 0x00014A38
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qdckWd_isMaximized = QDockWidget.__N.QDckWd_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_isMaximized) > 0;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00016868 File Offset: 0x00014A68
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qdckWd_isFullScreen = QDockWidget.__N.QDckWd_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_isFullScreen) > 0;
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x00016898 File Offset: 0x00014A98
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qdckWd_setMouseTracking = QDockWidget.__N.QDckWd_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qdckWd_setMouseTracking);
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x000168CC File Offset: 0x00014ACC
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qdckWd_hasMouseTracking = QDockWidget.__N.QDckWd_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_hasMouseTracking) > 0;
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x000168FC File Offset: 0x00014AFC
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qdckWd_underMouse = QDockWidget.__N.QDckWd_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_underMouse) > 0;
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x0001692C File Offset: 0x00014B2C
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qdckWd_mapToGlobal = QDockWidget.__N.QDckWd_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qdckWd_mapToGlobal);
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x00016958 File Offset: 0x00014B58
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qdckWd_mapFromGlobal = QDockWidget.__N.QDckWd_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qdckWd_mapFromGlobal);
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x00016984 File Offset: 0x00014B84
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qdckWd_hasFocus = QDockWidget.__N.QDckWd_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_hasFocus) > 0;
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x000169B4 File Offset: 0x00014BB4
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qdckWd_focusPolicy = QDockWidget.__N.QDckWd_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qdckWd_focusPolicy);
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x000169E0 File Offset: 0x00014BE0
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qdckWd_setFocusPolicy = QDockWidget.__N.QDckWd_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qdckWd_setFocusPolicy);
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x00016A0C File Offset: 0x00014C0C
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qdckWd_setFocusProxy = QDockWidget.__N.QDckWd_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qdckWd_setFocusProxy);
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x00016A3C File Offset: 0x00014C3C
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qdckWd_isActiveWindow = QDockWidget.__N.QDckWd_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_isActiveWindow) > 0;
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x00016A6C File Offset: 0x00014C6C
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qdckWd_updatesEnabled = QDockWidget.__N.QDckWd_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_updatesEnabled) > 0;
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x00016A9C File Offset: 0x00014C9C
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qdckWd_setUpdatesEnabled = QDockWidget.__N.QDckWd_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qdckWd_setUpdatesEnabled);
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x00016AD0 File Offset: 0x00014CD0
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qdckWd_setFocus = QDockWidget.__N.QDckWd_setFocus;
			calli(System.Void(System.IntPtr), this.self, qdckWd_setFocus);
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00016AFC File Offset: 0x00014CFC
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qdckWd_activateWindow = QDockWidget.__N.QDckWd_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qdckWd_activateWindow);
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x00016B28 File Offset: 0x00014D28
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qdckWd_clearFocus = QDockWidget.__N.QDckWd_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qdckWd_clearFocus);
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x00016B54 File Offset: 0x00014D54
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qdckWd_setSizePolicy = QDockWidget.__N.QDckWd_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qdckWd_setSizePolicy);
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00016B84 File Offset: 0x00014D84
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qdckWd_devicePixelRatioF = QDockWidget.__N.QDckWd_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qdckWd_devicePixelRatioF);
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x00016BB0 File Offset: 0x00014DB0
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qdckWd_saveGeometry = QDockWidget.__N.QDckWd_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qdckWd_saveGeometry));
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x00016BE0 File Offset: 0x00014DE0
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qdckWd_restoreGeometry = QDockWidget.__N.QDckWd_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qdckWd_restoreGeometry) > 0;
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x00016C14 File Offset: 0x00014E14
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qdckWd_addAction = QDockWidget.__N.QDckWd_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qdckWd_addAction);
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x00016C44 File Offset: 0x00014E44
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qdckWd_removeAction = QDockWidget.__N.QDckWd_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qdckWd_removeAction);
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x00016C74 File Offset: 0x00014E74
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qdckWd_setParent = QDockWidget.__N.QDckWd_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qdckWd_setParent);
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x00016CA4 File Offset: 0x00014EA4
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qdckWd_parentWidget = QDockWidget.__N.QDckWd_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qdckWd_parentWidget);
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x00016CD4 File Offset: 0x00014ED4
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qdckWd_AddClassName = QDockWidget.__N.QDckWd_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qdckWd_AddClassName);
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x00016D04 File Offset: 0x00014F04
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qdckWd_Polish = QDockWidget.__N.QDckWd_Polish;
			calli(System.Void(System.IntPtr), this.self, qdckWd_Polish);
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x00016D30 File Offset: 0x00014F30
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qdckWd_toolTip = QDockWidget.__N.QDckWd_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qdckWd_toolTip));
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x00016D60 File Offset: 0x00014F60
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qdckWd_setToolTip = QDockWidget.__N.QDckWd_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qdckWd_setToolTip);
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x00016D90 File Offset: 0x00014F90
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qdckWd_statusTip = QDockWidget.__N.QDckWd_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qdckWd_statusTip));
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x00016DC0 File Offset: 0x00014FC0
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qdckWd_setStatusTip = QDockWidget.__N.QDckWd_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qdckWd_setStatusTip);
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x00016DF0 File Offset: 0x00014FF0
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qdckWd_toolTipDuration = QDockWidget.__N.QDckWd_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_toolTipDuration);
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x00016E1C File Offset: 0x0001501C
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qdckWd_setToolTipDuration = QDockWidget.__N.QDckWd_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qdckWd_setToolTipDuration);
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x00016E48 File Offset: 0x00015048
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qdckWd_autoFillBackground = QDockWidget.__N.QDckWd_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qdckWd_autoFillBackground) > 0;
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x00016E78 File Offset: 0x00015078
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qdckWd_setAutoFillBackground = QDockWidget.__N.QDckWd_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qdckWd_setAutoFillBackground);
		}

		// Token: 0x04000050 RID: 80
		internal IntPtr self;

		// Token: 0x02000111 RID: 273
		internal static class __N
		{
			// Token: 0x04000A8B RID: 2699
			internal static method From_QWidget_To_QDockWidget;

			// Token: 0x04000A8C RID: 2700
			internal static method To_QWidget_From_QDockWidget;

			// Token: 0x04000A8D RID: 2701
			internal static method From_QObject_To_QDockWidget;

			// Token: 0x04000A8E RID: 2702
			internal static method To_QObject_From_QDockWidget;

			// Token: 0x04000A8F RID: 2703
			internal static method QDckWd_widget;

			// Token: 0x04000A90 RID: 2704
			internal static method QDckWd_setWidget;

			// Token: 0x04000A91 RID: 2705
			internal static method QDckWd_setFeatures;

			// Token: 0x04000A92 RID: 2706
			internal static method QDckWd_features;

			// Token: 0x04000A93 RID: 2707
			internal static method QDckWd_setFloating;

			// Token: 0x04000A94 RID: 2708
			internal static method QDckWd_isFloating;

			// Token: 0x04000A95 RID: 2709
			internal static method QDckWd_setAllowedAreas;

			// Token: 0x04000A96 RID: 2710
			internal static method QDckWd_allowedAreas;

			// Token: 0x04000A97 RID: 2711
			internal static method QDckWd_setIcon;

			// Token: 0x04000A98 RID: 2712
			internal static method QDckWd_toggleViewAction;

			// Token: 0x04000A99 RID: 2713
			internal static method QDckWd_isTopLevel;

			// Token: 0x04000A9A RID: 2714
			internal static method QDckWd_isWindow;

			// Token: 0x04000A9B RID: 2715
			internal static method QDckWd_isModal;

			// Token: 0x04000A9C RID: 2716
			internal static method QDckWd_setStyleSheet;

			// Token: 0x04000A9D RID: 2717
			internal static method QDckWd_windowTitle;

			// Token: 0x04000A9E RID: 2718
			internal static method QDckWd_setWindowTitle;

			// Token: 0x04000A9F RID: 2719
			internal static method QDckWd_setWindowFlags;

			// Token: 0x04000AA0 RID: 2720
			internal static method QDckWd_windowFlags;

			// Token: 0x04000AA1 RID: 2721
			internal static method QDckWd_size;

			// Token: 0x04000AA2 RID: 2722
			internal static method QDckWd_resize;

			// Token: 0x04000AA3 RID: 2723
			internal static method QDckWd_minimumSize;

			// Token: 0x04000AA4 RID: 2724
			internal static method QDckWd_setMinimumSize;

			// Token: 0x04000AA5 RID: 2725
			internal static method QDckWd_maximumSize;

			// Token: 0x04000AA6 RID: 2726
			internal static method QDckWd_setMaximumSize;

			// Token: 0x04000AA7 RID: 2727
			internal static method QDckWd_pos;

			// Token: 0x04000AA8 RID: 2728
			internal static method QDckWd_move;

			// Token: 0x04000AA9 RID: 2729
			internal static method QDckWd_isEnabled;

			// Token: 0x04000AAA RID: 2730
			internal static method QDckWd_setEnabled;

			// Token: 0x04000AAB RID: 2731
			internal static method QDckWd_setVisible;

			// Token: 0x04000AAC RID: 2732
			internal static method QDckWd_setHidden;

			// Token: 0x04000AAD RID: 2733
			internal static method QDckWd_show;

			// Token: 0x04000AAE RID: 2734
			internal static method QDckWd_hide;

			// Token: 0x04000AAF RID: 2735
			internal static method QDckWd_showMinimized;

			// Token: 0x04000AB0 RID: 2736
			internal static method QDckWd_showMaximized;

			// Token: 0x04000AB1 RID: 2737
			internal static method QDckWd_showFullScreen;

			// Token: 0x04000AB2 RID: 2738
			internal static method QDckWd_showNormal;

			// Token: 0x04000AB3 RID: 2739
			internal static method QDckWd_close;

			// Token: 0x04000AB4 RID: 2740
			internal static method QDckWd_raise;

			// Token: 0x04000AB5 RID: 2741
			internal static method QDckWd_lower;

			// Token: 0x04000AB6 RID: 2742
			internal static method QDckWd_isVisible;

			// Token: 0x04000AB7 RID: 2743
			internal static method QDckWd_setAttribute;

			// Token: 0x04000AB8 RID: 2744
			internal static method QDckWd_testAttribute;

			// Token: 0x04000AB9 RID: 2745
			internal static method QDckWd_acceptDrops;

			// Token: 0x04000ABA RID: 2746
			internal static method QDckWd_setAcceptDrops;

			// Token: 0x04000ABB RID: 2747
			internal static method QDckWd_update;

			// Token: 0x04000ABC RID: 2748
			internal static method QDckWd_repaint;

			// Token: 0x04000ABD RID: 2749
			internal static method QDckWd_setCursor;

			// Token: 0x04000ABE RID: 2750
			internal static method QDckWd_unsetCursor;

			// Token: 0x04000ABF RID: 2751
			internal static method QDckWd_setWindowIcon;

			// Token: 0x04000AC0 RID: 2752
			internal static method QDckWd_setWindowIconText;

			// Token: 0x04000AC1 RID: 2753
			internal static method QDckWd_setWindowOpacity;

			// Token: 0x04000AC2 RID: 2754
			internal static method QDckWd_windowOpacity;

			// Token: 0x04000AC3 RID: 2755
			internal static method QDckWd_isMinimized;

			// Token: 0x04000AC4 RID: 2756
			internal static method QDckWd_isMaximized;

			// Token: 0x04000AC5 RID: 2757
			internal static method QDckWd_isFullScreen;

			// Token: 0x04000AC6 RID: 2758
			internal static method QDckWd_setMouseTracking;

			// Token: 0x04000AC7 RID: 2759
			internal static method QDckWd_hasMouseTracking;

			// Token: 0x04000AC8 RID: 2760
			internal static method QDckWd_underMouse;

			// Token: 0x04000AC9 RID: 2761
			internal static method QDckWd_mapToGlobal;

			// Token: 0x04000ACA RID: 2762
			internal static method QDckWd_mapFromGlobal;

			// Token: 0x04000ACB RID: 2763
			internal static method QDckWd_hasFocus;

			// Token: 0x04000ACC RID: 2764
			internal static method QDckWd_focusPolicy;

			// Token: 0x04000ACD RID: 2765
			internal static method QDckWd_setFocusPolicy;

			// Token: 0x04000ACE RID: 2766
			internal static method QDckWd_setFocusProxy;

			// Token: 0x04000ACF RID: 2767
			internal static method QDckWd_isActiveWindow;

			// Token: 0x04000AD0 RID: 2768
			internal static method QDckWd_updatesEnabled;

			// Token: 0x04000AD1 RID: 2769
			internal static method QDckWd_setUpdatesEnabled;

			// Token: 0x04000AD2 RID: 2770
			internal static method QDckWd_setFocus;

			// Token: 0x04000AD3 RID: 2771
			internal static method QDckWd_activateWindow;

			// Token: 0x04000AD4 RID: 2772
			internal static method QDckWd_clearFocus;

			// Token: 0x04000AD5 RID: 2773
			internal static method QDckWd_setSizePolicy;

			// Token: 0x04000AD6 RID: 2774
			internal static method QDckWd_devicePixelRatioF;

			// Token: 0x04000AD7 RID: 2775
			internal static method QDckWd_saveGeometry;

			// Token: 0x04000AD8 RID: 2776
			internal static method QDckWd_restoreGeometry;

			// Token: 0x04000AD9 RID: 2777
			internal static method QDckWd_addAction;

			// Token: 0x04000ADA RID: 2778
			internal static method QDckWd_removeAction;

			// Token: 0x04000ADB RID: 2779
			internal static method QDckWd_setParent;

			// Token: 0x04000ADC RID: 2780
			internal static method QDckWd_parentWidget;

			// Token: 0x04000ADD RID: 2781
			internal static method QDckWd_AddClassName;

			// Token: 0x04000ADE RID: 2782
			internal static method QDckWd_Polish;

			// Token: 0x04000ADF RID: 2783
			internal static method QDckWd_toolTip;

			// Token: 0x04000AE0 RID: 2784
			internal static method QDckWd_setToolTip;

			// Token: 0x04000AE1 RID: 2785
			internal static method QDckWd_statusTip;

			// Token: 0x04000AE2 RID: 2786
			internal static method QDckWd_setStatusTip;

			// Token: 0x04000AE3 RID: 2787
			internal static method QDckWd_toolTipDuration;

			// Token: 0x04000AE4 RID: 2788
			internal static method QDckWd_setToolTipDuration;

			// Token: 0x04000AE5 RID: 2789
			internal static method QDckWd_autoFillBackground;

			// Token: 0x04000AE6 RID: 2790
			internal static method QDckWd_setAutoFillBackground;
		}
	}
}
