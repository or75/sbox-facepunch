using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x0200005C RID: 92
	internal struct QToolBar
	{
		// Token: 0x06000F9C RID: 3996 RVA: 0x0002A375 File Offset: 0x00028575
		public static implicit operator IntPtr(QToolBar value)
		{
			return value.self;
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x0002A380 File Offset: 0x00028580
		public static implicit operator QToolBar(IntPtr value)
		{
			return new QToolBar
			{
				self = value
			};
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x0002A39E File Offset: 0x0002859E
		public static bool operator ==(QToolBar c1, QToolBar c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000F9F RID: 3999 RVA: 0x0002A3B1 File Offset: 0x000285B1
		public static bool operator !=(QToolBar c1, QToolBar c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000FA0 RID: 4000 RVA: 0x0002A3C4 File Offset: 0x000285C4
		public override bool Equals(object obj)
		{
			if (obj is QToolBar)
			{
				QToolBar c = (QToolBar)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x0002A3EE File Offset: 0x000285EE
		internal QToolBar(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x0002A3F8 File Offset: 0x000285F8
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QToolBar ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000FA3 RID: 4003 RVA: 0x0002A434 File Offset: 0x00028634
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000FA4 RID: 4004 RVA: 0x0002A446 File Offset: 0x00028646
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x0002A451 File Offset: 0x00028651
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000FA6 RID: 4006 RVA: 0x0002A464 File Offset: 0x00028664
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QToolBar was null when calling " + n);
			}
		}

		// Token: 0x06000FA7 RID: 4007 RVA: 0x0002A47F File Offset: 0x0002867F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000FA8 RID: 4008 RVA: 0x0002A48C File Offset: 0x0002868C
		public static implicit operator QWidget(QToolBar value)
		{
			method to_QWidget_From_QToolBar = QToolBar.__N.To_QWidget_From_QToolBar;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QToolBar);
		}

		// Token: 0x06000FA9 RID: 4009 RVA: 0x0002A4B0 File Offset: 0x000286B0
		public static explicit operator QToolBar(QWidget value)
		{
			method from_QWidget_To_QToolBar = QToolBar.__N.From_QWidget_To_QToolBar;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QToolBar);
		}

		// Token: 0x06000FAA RID: 4010 RVA: 0x0002A4D4 File Offset: 0x000286D4
		public static implicit operator QObject(QToolBar value)
		{
			method to_QObject_From_QToolBar = QToolBar.__N.To_QObject_From_QToolBar;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QToolBar);
		}

		// Token: 0x06000FAB RID: 4011 RVA: 0x0002A4F8 File Offset: 0x000286F8
		public static explicit operator QToolBar(QObject value)
		{
			method from_QObject_To_QToolBar = QToolBar.__N.From_QObject_To_QToolBar;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QToolBar);
		}

		// Token: 0x06000FAC RID: 4012 RVA: 0x0002A51C File Offset: 0x0002871C
		internal readonly void setMovable(bool movable)
		{
			this.NullCheck("setMovable");
			method qtoolB_setMovable = QToolBar.__N.QToolB_setMovable;
			calli(System.Void(System.IntPtr,System.Int32), this.self, movable ? 1 : 0, qtoolB_setMovable);
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x0002A550 File Offset: 0x00028750
		internal readonly bool isMovable()
		{
			this.NullCheck("isMovable");
			method qtoolB_isMovable = QToolBar.__N.QToolB_isMovable;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_isMovable) > 0;
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x0002A580 File Offset: 0x00028780
		internal readonly void setAllowedAreas(ToolbarPosition areas)
		{
			this.NullCheck("setAllowedAreas");
			method qtoolB_setAllowedAreas = QToolBar.__N.QToolB_setAllowedAreas;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)areas, qtoolB_setAllowedAreas);
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x0002A5AC File Offset: 0x000287AC
		internal readonly ToolbarPosition allowedAreas()
		{
			this.NullCheck("allowedAreas");
			method qtoolB_allowedAreas = QToolBar.__N.QToolB_allowedAreas;
			return calli(System.Int64(System.IntPtr), this.self, qtoolB_allowedAreas);
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x0002A5D8 File Offset: 0x000287D8
		internal readonly void clear()
		{
			this.NullCheck("clear");
			method qtoolB_clear = QToolBar.__N.QToolB_clear;
			calli(System.Void(System.IntPtr), this.self, qtoolB_clear);
		}

		// Token: 0x06000FB1 RID: 4017 RVA: 0x0002A604 File Offset: 0x00028804
		internal readonly void insertAction(QAction before, QAction action)
		{
			this.NullCheck("insertAction");
			method qtoolB_insertAction = QToolBar.__N.QToolB_insertAction;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, before, action, qtoolB_insertAction);
		}

		// Token: 0x06000FB2 RID: 4018 RVA: 0x0002A63C File Offset: 0x0002883C
		internal readonly QAction insertWidget(QAction before, QWidget widget)
		{
			this.NullCheck("insertWidget");
			method qtoolB_insertWidget = QToolBar.__N.QToolB_insertWidget;
			return calli(System.IntPtr(System.IntPtr,System.IntPtr,System.IntPtr), this.self, before, widget, qtoolB_insertWidget);
		}

		// Token: 0x06000FB3 RID: 4019 RVA: 0x0002A678 File Offset: 0x00028878
		internal readonly QAction addWidget(QWidget widget)
		{
			this.NullCheck("addWidget");
			method qtoolB_addWidget = QToolBar.__N.QToolB_addWidget;
			return calli(System.IntPtr(System.IntPtr,System.IntPtr), this.self, widget, qtoolB_addWidget);
		}

		// Token: 0x06000FB4 RID: 4020 RVA: 0x0002A6B0 File Offset: 0x000288B0
		internal readonly QAction addSeparator()
		{
			this.NullCheck("addSeparator");
			method qtoolB_addSeparator = QToolBar.__N.QToolB_addSeparator;
			return calli(System.IntPtr(System.IntPtr), this.self, qtoolB_addSeparator);
		}

		// Token: 0x06000FB5 RID: 4021 RVA: 0x0002A6E0 File Offset: 0x000288E0
		internal readonly bool isFloatable()
		{
			this.NullCheck("isFloatable");
			method qtoolB_isFloatable = QToolBar.__N.QToolB_isFloatable;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_isFloatable) > 0;
		}

		// Token: 0x06000FB6 RID: 4022 RVA: 0x0002A710 File Offset: 0x00028910
		internal readonly void setFloatable(bool floatable)
		{
			this.NullCheck("setFloatable");
			method qtoolB_setFloatable = QToolBar.__N.QToolB_setFloatable;
			calli(System.Void(System.IntPtr,System.Int32), this.self, floatable ? 1 : 0, qtoolB_setFloatable);
		}

		// Token: 0x06000FB7 RID: 4023 RVA: 0x0002A744 File Offset: 0x00028944
		internal readonly bool isFloating()
		{
			this.NullCheck("isFloating");
			method qtoolB_isFloating = QToolBar.__N.QToolB_isFloating;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_isFloating) > 0;
		}

		// Token: 0x06000FB8 RID: 4024 RVA: 0x0002A774 File Offset: 0x00028974
		internal readonly void setIconSize(Vector3 iconSize)
		{
			this.NullCheck("setIconSize");
			method qtoolB_setIconSize = QToolBar.__N.QToolB_setIconSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, iconSize, qtoolB_setIconSize);
		}

		// Token: 0x06000FB9 RID: 4025 RVA: 0x0002A7A0 File Offset: 0x000289A0
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qtoolB_isTopLevel = QToolBar.__N.QToolB_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_isTopLevel) > 0;
		}

		// Token: 0x06000FBA RID: 4026 RVA: 0x0002A7D0 File Offset: 0x000289D0
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qtoolB_isWindow = QToolBar.__N.QToolB_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_isWindow) > 0;
		}

		// Token: 0x06000FBB RID: 4027 RVA: 0x0002A800 File Offset: 0x00028A00
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qtoolB_isModal = QToolBar.__N.QToolB_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_isModal) > 0;
		}

		// Token: 0x06000FBC RID: 4028 RVA: 0x0002A830 File Offset: 0x00028A30
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qtoolB_setStyleSheet = QToolBar.__N.QToolB_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qtoolB_setStyleSheet);
		}

		// Token: 0x06000FBD RID: 4029 RVA: 0x0002A860 File Offset: 0x00028A60
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qtoolB_windowTitle = QToolBar.__N.QToolB_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qtoolB_windowTitle));
		}

		// Token: 0x06000FBE RID: 4030 RVA: 0x0002A890 File Offset: 0x00028A90
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qtoolB_setWindowTitle = QToolBar.__N.QToolB_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qtoolB_setWindowTitle);
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x0002A8C0 File Offset: 0x00028AC0
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qtoolB_setWindowFlags = QToolBar.__N.QToolB_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qtoolB_setWindowFlags);
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x0002A8EC File Offset: 0x00028AEC
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qtoolB_windowFlags = QToolBar.__N.QToolB_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qtoolB_windowFlags);
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x0002A918 File Offset: 0x00028B18
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qtoolB_size = QToolBar.__N.QToolB_size;
			return calli(Vector3(System.IntPtr), this.self, qtoolB_size);
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x0002A944 File Offset: 0x00028B44
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qtoolB_resize = QToolBar.__N.QToolB_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qtoolB_resize);
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x0002A970 File Offset: 0x00028B70
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qtoolB_minimumSize = QToolBar.__N.QToolB_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qtoolB_minimumSize);
		}

		// Token: 0x06000FC4 RID: 4036 RVA: 0x0002A99C File Offset: 0x00028B9C
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qtoolB_setMinimumSize = QToolBar.__N.QToolB_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qtoolB_setMinimumSize);
		}

		// Token: 0x06000FC5 RID: 4037 RVA: 0x0002A9C8 File Offset: 0x00028BC8
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qtoolB_maximumSize = QToolBar.__N.QToolB_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qtoolB_maximumSize);
		}

		// Token: 0x06000FC6 RID: 4038 RVA: 0x0002A9F4 File Offset: 0x00028BF4
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qtoolB_setMaximumSize = QToolBar.__N.QToolB_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qtoolB_setMaximumSize);
		}

		// Token: 0x06000FC7 RID: 4039 RVA: 0x0002AA20 File Offset: 0x00028C20
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qtoolB_pos = QToolBar.__N.QToolB_pos;
			return calli(Vector3(System.IntPtr), this.self, qtoolB_pos);
		}

		// Token: 0x06000FC8 RID: 4040 RVA: 0x0002AA4C File Offset: 0x00028C4C
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qtoolB_move = QToolBar.__N.QToolB_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qtoolB_move);
		}

		// Token: 0x06000FC9 RID: 4041 RVA: 0x0002AA78 File Offset: 0x00028C78
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qtoolB_isEnabled = QToolBar.__N.QToolB_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_isEnabled) > 0;
		}

		// Token: 0x06000FCA RID: 4042 RVA: 0x0002AAA8 File Offset: 0x00028CA8
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qtoolB_setEnabled = QToolBar.__N.QToolB_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qtoolB_setEnabled);
		}

		// Token: 0x06000FCB RID: 4043 RVA: 0x0002AADC File Offset: 0x00028CDC
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qtoolB_setVisible = QToolBar.__N.QToolB_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qtoolB_setVisible);
		}

		// Token: 0x06000FCC RID: 4044 RVA: 0x0002AB10 File Offset: 0x00028D10
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qtoolB_setHidden = QToolBar.__N.QToolB_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qtoolB_setHidden);
		}

		// Token: 0x06000FCD RID: 4045 RVA: 0x0002AB44 File Offset: 0x00028D44
		internal readonly void show()
		{
			this.NullCheck("show");
			method qtoolB_show = QToolBar.__N.QToolB_show;
			calli(System.Void(System.IntPtr), this.self, qtoolB_show);
		}

		// Token: 0x06000FCE RID: 4046 RVA: 0x0002AB70 File Offset: 0x00028D70
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qtoolB_hide = QToolBar.__N.QToolB_hide;
			calli(System.Void(System.IntPtr), this.self, qtoolB_hide);
		}

		// Token: 0x06000FCF RID: 4047 RVA: 0x0002AB9C File Offset: 0x00028D9C
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qtoolB_showMinimized = QToolBar.__N.QToolB_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qtoolB_showMinimized);
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x0002ABC8 File Offset: 0x00028DC8
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qtoolB_showMaximized = QToolBar.__N.QToolB_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qtoolB_showMaximized);
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x0002ABF4 File Offset: 0x00028DF4
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qtoolB_showFullScreen = QToolBar.__N.QToolB_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qtoolB_showFullScreen);
		}

		// Token: 0x06000FD2 RID: 4050 RVA: 0x0002AC20 File Offset: 0x00028E20
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qtoolB_showNormal = QToolBar.__N.QToolB_showNormal;
			calli(System.Void(System.IntPtr), this.self, qtoolB_showNormal);
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x0002AC4C File Offset: 0x00028E4C
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qtoolB_close = QToolBar.__N.QToolB_close;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_close) > 0;
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x0002AC7C File Offset: 0x00028E7C
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qtoolB_raise = QToolBar.__N.QToolB_raise;
			calli(System.Void(System.IntPtr), this.self, qtoolB_raise);
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x0002ACA8 File Offset: 0x00028EA8
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qtoolB_lower = QToolBar.__N.QToolB_lower;
			calli(System.Void(System.IntPtr), this.self, qtoolB_lower);
		}

		// Token: 0x06000FD6 RID: 4054 RVA: 0x0002ACD4 File Offset: 0x00028ED4
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qtoolB_isVisible = QToolBar.__N.QToolB_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_isVisible) > 0;
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x0002AD04 File Offset: 0x00028F04
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qtoolB_setAttribute = QToolBar.__N.QToolB_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qtoolB_setAttribute);
		}

		// Token: 0x06000FD8 RID: 4056 RVA: 0x0002AD38 File Offset: 0x00028F38
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qtoolB_testAttribute = QToolBar.__N.QToolB_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qtoolB_testAttribute) > 0;
		}

		// Token: 0x06000FD9 RID: 4057 RVA: 0x0002AD68 File Offset: 0x00028F68
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qtoolB_acceptDrops = QToolBar.__N.QToolB_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_acceptDrops) > 0;
		}

		// Token: 0x06000FDA RID: 4058 RVA: 0x0002AD98 File Offset: 0x00028F98
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qtoolB_setAcceptDrops = QToolBar.__N.QToolB_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qtoolB_setAcceptDrops);
		}

		// Token: 0x06000FDB RID: 4059 RVA: 0x0002ADCC File Offset: 0x00028FCC
		internal readonly void update()
		{
			this.NullCheck("update");
			method qtoolB_update = QToolBar.__N.QToolB_update;
			calli(System.Void(System.IntPtr), this.self, qtoolB_update);
		}

		// Token: 0x06000FDC RID: 4060 RVA: 0x0002ADF8 File Offset: 0x00028FF8
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qtoolB_repaint = QToolBar.__N.QToolB_repaint;
			calli(System.Void(System.IntPtr), this.self, qtoolB_repaint);
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x0002AE24 File Offset: 0x00029024
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qtoolB_setCursor = QToolBar.__N.QToolB_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qtoolB_setCursor);
		}

		// Token: 0x06000FDE RID: 4062 RVA: 0x0002AE50 File Offset: 0x00029050
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qtoolB_unsetCursor = QToolBar.__N.QToolB_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qtoolB_unsetCursor);
		}

		// Token: 0x06000FDF RID: 4063 RVA: 0x0002AE7C File Offset: 0x0002907C
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qtoolB_setWindowIcon = QToolBar.__N.QToolB_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qtoolB_setWindowIcon);
		}

		// Token: 0x06000FE0 RID: 4064 RVA: 0x0002AEAC File Offset: 0x000290AC
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qtoolB_setWindowIconText = QToolBar.__N.QToolB_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qtoolB_setWindowIconText);
		}

		// Token: 0x06000FE1 RID: 4065 RVA: 0x0002AEDC File Offset: 0x000290DC
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qtoolB_setWindowOpacity = QToolBar.__N.QToolB_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qtoolB_setWindowOpacity);
		}

		// Token: 0x06000FE2 RID: 4066 RVA: 0x0002AF08 File Offset: 0x00029108
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qtoolB_windowOpacity = QToolBar.__N.QToolB_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qtoolB_windowOpacity);
		}

		// Token: 0x06000FE3 RID: 4067 RVA: 0x0002AF34 File Offset: 0x00029134
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qtoolB_isMinimized = QToolBar.__N.QToolB_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_isMinimized) > 0;
		}

		// Token: 0x06000FE4 RID: 4068 RVA: 0x0002AF64 File Offset: 0x00029164
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qtoolB_isMaximized = QToolBar.__N.QToolB_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_isMaximized) > 0;
		}

		// Token: 0x06000FE5 RID: 4069 RVA: 0x0002AF94 File Offset: 0x00029194
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qtoolB_isFullScreen = QToolBar.__N.QToolB_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_isFullScreen) > 0;
		}

		// Token: 0x06000FE6 RID: 4070 RVA: 0x0002AFC4 File Offset: 0x000291C4
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qtoolB_setMouseTracking = QToolBar.__N.QToolB_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qtoolB_setMouseTracking);
		}

		// Token: 0x06000FE7 RID: 4071 RVA: 0x0002AFF8 File Offset: 0x000291F8
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qtoolB_hasMouseTracking = QToolBar.__N.QToolB_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_hasMouseTracking) > 0;
		}

		// Token: 0x06000FE8 RID: 4072 RVA: 0x0002B028 File Offset: 0x00029228
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qtoolB_underMouse = QToolBar.__N.QToolB_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_underMouse) > 0;
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x0002B058 File Offset: 0x00029258
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qtoolB_mapToGlobal = QToolBar.__N.QToolB_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qtoolB_mapToGlobal);
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x0002B084 File Offset: 0x00029284
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qtoolB_mapFromGlobal = QToolBar.__N.QToolB_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qtoolB_mapFromGlobal);
		}

		// Token: 0x06000FEB RID: 4075 RVA: 0x0002B0B0 File Offset: 0x000292B0
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qtoolB_hasFocus = QToolBar.__N.QToolB_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_hasFocus) > 0;
		}

		// Token: 0x06000FEC RID: 4076 RVA: 0x0002B0E0 File Offset: 0x000292E0
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qtoolB_focusPolicy = QToolBar.__N.QToolB_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qtoolB_focusPolicy);
		}

		// Token: 0x06000FED RID: 4077 RVA: 0x0002B10C File Offset: 0x0002930C
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qtoolB_setFocusPolicy = QToolBar.__N.QToolB_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qtoolB_setFocusPolicy);
		}

		// Token: 0x06000FEE RID: 4078 RVA: 0x0002B138 File Offset: 0x00029338
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qtoolB_setFocusProxy = QToolBar.__N.QToolB_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qtoolB_setFocusProxy);
		}

		// Token: 0x06000FEF RID: 4079 RVA: 0x0002B168 File Offset: 0x00029368
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qtoolB_isActiveWindow = QToolBar.__N.QToolB_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_isActiveWindow) > 0;
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x0002B198 File Offset: 0x00029398
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qtoolB_updatesEnabled = QToolBar.__N.QToolB_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_updatesEnabled) > 0;
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x0002B1C8 File Offset: 0x000293C8
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qtoolB_setUpdatesEnabled = QToolBar.__N.QToolB_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qtoolB_setUpdatesEnabled);
		}

		// Token: 0x06000FF2 RID: 4082 RVA: 0x0002B1FC File Offset: 0x000293FC
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qtoolB_setFocus = QToolBar.__N.QToolB_setFocus;
			calli(System.Void(System.IntPtr), this.self, qtoolB_setFocus);
		}

		// Token: 0x06000FF3 RID: 4083 RVA: 0x0002B228 File Offset: 0x00029428
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qtoolB_activateWindow = QToolBar.__N.QToolB_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qtoolB_activateWindow);
		}

		// Token: 0x06000FF4 RID: 4084 RVA: 0x0002B254 File Offset: 0x00029454
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qtoolB_clearFocus = QToolBar.__N.QToolB_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qtoolB_clearFocus);
		}

		// Token: 0x06000FF5 RID: 4085 RVA: 0x0002B280 File Offset: 0x00029480
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qtoolB_setSizePolicy = QToolBar.__N.QToolB_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qtoolB_setSizePolicy);
		}

		// Token: 0x06000FF6 RID: 4086 RVA: 0x0002B2B0 File Offset: 0x000294B0
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qtoolB_devicePixelRatioF = QToolBar.__N.QToolB_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qtoolB_devicePixelRatioF);
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x0002B2DC File Offset: 0x000294DC
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qtoolB_saveGeometry = QToolBar.__N.QToolB_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qtoolB_saveGeometry));
		}

		// Token: 0x06000FF8 RID: 4088 RVA: 0x0002B30C File Offset: 0x0002950C
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qtoolB_restoreGeometry = QToolBar.__N.QToolB_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qtoolB_restoreGeometry) > 0;
		}

		// Token: 0x06000FF9 RID: 4089 RVA: 0x0002B340 File Offset: 0x00029540
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qtoolB_addAction = QToolBar.__N.QToolB_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qtoolB_addAction);
		}

		// Token: 0x06000FFA RID: 4090 RVA: 0x0002B370 File Offset: 0x00029570
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qtoolB_removeAction = QToolBar.__N.QToolB_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qtoolB_removeAction);
		}

		// Token: 0x06000FFB RID: 4091 RVA: 0x0002B3A0 File Offset: 0x000295A0
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qtoolB_setParent = QToolBar.__N.QToolB_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qtoolB_setParent);
		}

		// Token: 0x06000FFC RID: 4092 RVA: 0x0002B3D0 File Offset: 0x000295D0
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qtoolB_parentWidget = QToolBar.__N.QToolB_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qtoolB_parentWidget);
		}

		// Token: 0x06000FFD RID: 4093 RVA: 0x0002B400 File Offset: 0x00029600
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qtoolB_AddClassName = QToolBar.__N.QToolB_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qtoolB_AddClassName);
		}

		// Token: 0x06000FFE RID: 4094 RVA: 0x0002B430 File Offset: 0x00029630
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qtoolB_Polish = QToolBar.__N.QToolB_Polish;
			calli(System.Void(System.IntPtr), this.self, qtoolB_Polish);
		}

		// Token: 0x06000FFF RID: 4095 RVA: 0x0002B45C File Offset: 0x0002965C
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qtoolB_toolTip = QToolBar.__N.QToolB_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qtoolB_toolTip));
		}

		// Token: 0x06001000 RID: 4096 RVA: 0x0002B48C File Offset: 0x0002968C
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qtoolB_setToolTip = QToolBar.__N.QToolB_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qtoolB_setToolTip);
		}

		// Token: 0x06001001 RID: 4097 RVA: 0x0002B4BC File Offset: 0x000296BC
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qtoolB_statusTip = QToolBar.__N.QToolB_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qtoolB_statusTip));
		}

		// Token: 0x06001002 RID: 4098 RVA: 0x0002B4EC File Offset: 0x000296EC
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qtoolB_setStatusTip = QToolBar.__N.QToolB_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qtoolB_setStatusTip);
		}

		// Token: 0x06001003 RID: 4099 RVA: 0x0002B51C File Offset: 0x0002971C
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qtoolB_toolTipDuration = QToolBar.__N.QToolB_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_toolTipDuration);
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x0002B548 File Offset: 0x00029748
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qtoolB_setToolTipDuration = QToolBar.__N.QToolB_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qtoolB_setToolTipDuration);
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x0002B574 File Offset: 0x00029774
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qtoolB_autoFillBackground = QToolBar.__N.QToolB_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qtoolB_autoFillBackground) > 0;
		}

		// Token: 0x06001006 RID: 4102 RVA: 0x0002B5A4 File Offset: 0x000297A4
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qtoolB_setAutoFillBackground = QToolBar.__N.QToolB_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qtoolB_setAutoFillBackground);
		}

		// Token: 0x04000067 RID: 103
		internal IntPtr self;

		// Token: 0x02000128 RID: 296
		internal static class __N
		{
			// Token: 0x04001112 RID: 4370
			internal static method From_QWidget_To_QToolBar;

			// Token: 0x04001113 RID: 4371
			internal static method To_QWidget_From_QToolBar;

			// Token: 0x04001114 RID: 4372
			internal static method From_QObject_To_QToolBar;

			// Token: 0x04001115 RID: 4373
			internal static method To_QObject_From_QToolBar;

			// Token: 0x04001116 RID: 4374
			internal static method QToolB_setMovable;

			// Token: 0x04001117 RID: 4375
			internal static method QToolB_isMovable;

			// Token: 0x04001118 RID: 4376
			internal static method QToolB_setAllowedAreas;

			// Token: 0x04001119 RID: 4377
			internal static method QToolB_allowedAreas;

			// Token: 0x0400111A RID: 4378
			internal static method QToolB_clear;

			// Token: 0x0400111B RID: 4379
			internal static method QToolB_insertAction;

			// Token: 0x0400111C RID: 4380
			internal static method QToolB_insertWidget;

			// Token: 0x0400111D RID: 4381
			internal static method QToolB_addWidget;

			// Token: 0x0400111E RID: 4382
			internal static method QToolB_addSeparator;

			// Token: 0x0400111F RID: 4383
			internal static method QToolB_isFloatable;

			// Token: 0x04001120 RID: 4384
			internal static method QToolB_setFloatable;

			// Token: 0x04001121 RID: 4385
			internal static method QToolB_isFloating;

			// Token: 0x04001122 RID: 4386
			internal static method QToolB_setIconSize;

			// Token: 0x04001123 RID: 4387
			internal static method QToolB_isTopLevel;

			// Token: 0x04001124 RID: 4388
			internal static method QToolB_isWindow;

			// Token: 0x04001125 RID: 4389
			internal static method QToolB_isModal;

			// Token: 0x04001126 RID: 4390
			internal static method QToolB_setStyleSheet;

			// Token: 0x04001127 RID: 4391
			internal static method QToolB_windowTitle;

			// Token: 0x04001128 RID: 4392
			internal static method QToolB_setWindowTitle;

			// Token: 0x04001129 RID: 4393
			internal static method QToolB_setWindowFlags;

			// Token: 0x0400112A RID: 4394
			internal static method QToolB_windowFlags;

			// Token: 0x0400112B RID: 4395
			internal static method QToolB_size;

			// Token: 0x0400112C RID: 4396
			internal static method QToolB_resize;

			// Token: 0x0400112D RID: 4397
			internal static method QToolB_minimumSize;

			// Token: 0x0400112E RID: 4398
			internal static method QToolB_setMinimumSize;

			// Token: 0x0400112F RID: 4399
			internal static method QToolB_maximumSize;

			// Token: 0x04001130 RID: 4400
			internal static method QToolB_setMaximumSize;

			// Token: 0x04001131 RID: 4401
			internal static method QToolB_pos;

			// Token: 0x04001132 RID: 4402
			internal static method QToolB_move;

			// Token: 0x04001133 RID: 4403
			internal static method QToolB_isEnabled;

			// Token: 0x04001134 RID: 4404
			internal static method QToolB_setEnabled;

			// Token: 0x04001135 RID: 4405
			internal static method QToolB_setVisible;

			// Token: 0x04001136 RID: 4406
			internal static method QToolB_setHidden;

			// Token: 0x04001137 RID: 4407
			internal static method QToolB_show;

			// Token: 0x04001138 RID: 4408
			internal static method QToolB_hide;

			// Token: 0x04001139 RID: 4409
			internal static method QToolB_showMinimized;

			// Token: 0x0400113A RID: 4410
			internal static method QToolB_showMaximized;

			// Token: 0x0400113B RID: 4411
			internal static method QToolB_showFullScreen;

			// Token: 0x0400113C RID: 4412
			internal static method QToolB_showNormal;

			// Token: 0x0400113D RID: 4413
			internal static method QToolB_close;

			// Token: 0x0400113E RID: 4414
			internal static method QToolB_raise;

			// Token: 0x0400113F RID: 4415
			internal static method QToolB_lower;

			// Token: 0x04001140 RID: 4416
			internal static method QToolB_isVisible;

			// Token: 0x04001141 RID: 4417
			internal static method QToolB_setAttribute;

			// Token: 0x04001142 RID: 4418
			internal static method QToolB_testAttribute;

			// Token: 0x04001143 RID: 4419
			internal static method QToolB_acceptDrops;

			// Token: 0x04001144 RID: 4420
			internal static method QToolB_setAcceptDrops;

			// Token: 0x04001145 RID: 4421
			internal static method QToolB_update;

			// Token: 0x04001146 RID: 4422
			internal static method QToolB_repaint;

			// Token: 0x04001147 RID: 4423
			internal static method QToolB_setCursor;

			// Token: 0x04001148 RID: 4424
			internal static method QToolB_unsetCursor;

			// Token: 0x04001149 RID: 4425
			internal static method QToolB_setWindowIcon;

			// Token: 0x0400114A RID: 4426
			internal static method QToolB_setWindowIconText;

			// Token: 0x0400114B RID: 4427
			internal static method QToolB_setWindowOpacity;

			// Token: 0x0400114C RID: 4428
			internal static method QToolB_windowOpacity;

			// Token: 0x0400114D RID: 4429
			internal static method QToolB_isMinimized;

			// Token: 0x0400114E RID: 4430
			internal static method QToolB_isMaximized;

			// Token: 0x0400114F RID: 4431
			internal static method QToolB_isFullScreen;

			// Token: 0x04001150 RID: 4432
			internal static method QToolB_setMouseTracking;

			// Token: 0x04001151 RID: 4433
			internal static method QToolB_hasMouseTracking;

			// Token: 0x04001152 RID: 4434
			internal static method QToolB_underMouse;

			// Token: 0x04001153 RID: 4435
			internal static method QToolB_mapToGlobal;

			// Token: 0x04001154 RID: 4436
			internal static method QToolB_mapFromGlobal;

			// Token: 0x04001155 RID: 4437
			internal static method QToolB_hasFocus;

			// Token: 0x04001156 RID: 4438
			internal static method QToolB_focusPolicy;

			// Token: 0x04001157 RID: 4439
			internal static method QToolB_setFocusPolicy;

			// Token: 0x04001158 RID: 4440
			internal static method QToolB_setFocusProxy;

			// Token: 0x04001159 RID: 4441
			internal static method QToolB_isActiveWindow;

			// Token: 0x0400115A RID: 4442
			internal static method QToolB_updatesEnabled;

			// Token: 0x0400115B RID: 4443
			internal static method QToolB_setUpdatesEnabled;

			// Token: 0x0400115C RID: 4444
			internal static method QToolB_setFocus;

			// Token: 0x0400115D RID: 4445
			internal static method QToolB_activateWindow;

			// Token: 0x0400115E RID: 4446
			internal static method QToolB_clearFocus;

			// Token: 0x0400115F RID: 4447
			internal static method QToolB_setSizePolicy;

			// Token: 0x04001160 RID: 4448
			internal static method QToolB_devicePixelRatioF;

			// Token: 0x04001161 RID: 4449
			internal static method QToolB_saveGeometry;

			// Token: 0x04001162 RID: 4450
			internal static method QToolB_restoreGeometry;

			// Token: 0x04001163 RID: 4451
			internal static method QToolB_addAction;

			// Token: 0x04001164 RID: 4452
			internal static method QToolB_removeAction;

			// Token: 0x04001165 RID: 4453
			internal static method QToolB_setParent;

			// Token: 0x04001166 RID: 4454
			internal static method QToolB_parentWidget;

			// Token: 0x04001167 RID: 4455
			internal static method QToolB_AddClassName;

			// Token: 0x04001168 RID: 4456
			internal static method QToolB_Polish;

			// Token: 0x04001169 RID: 4457
			internal static method QToolB_toolTip;

			// Token: 0x0400116A RID: 4458
			internal static method QToolB_setToolTip;

			// Token: 0x0400116B RID: 4459
			internal static method QToolB_statusTip;

			// Token: 0x0400116C RID: 4460
			internal static method QToolB_setStatusTip;

			// Token: 0x0400116D RID: 4461
			internal static method QToolB_toolTipDuration;

			// Token: 0x0400116E RID: 4462
			internal static method QToolB_setToolTipDuration;

			// Token: 0x0400116F RID: 4463
			internal static method QToolB_autoFillBackground;

			// Token: 0x04001170 RID: 4464
			internal static method QToolB_setAutoFillBackground;
		}
	}
}
