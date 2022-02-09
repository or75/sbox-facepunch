using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000051 RID: 81
	internal struct QMenu
	{
		// Token: 0x06000BEA RID: 3050 RVA: 0x000204A1 File Offset: 0x0001E6A1
		public static implicit operator IntPtr(QMenu value)
		{
			return value.self;
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x000204AC File Offset: 0x0001E6AC
		public static implicit operator QMenu(IntPtr value)
		{
			return new QMenu
			{
				self = value
			};
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x000204CA File Offset: 0x0001E6CA
		public static bool operator ==(QMenu c1, QMenu c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x000204DD File Offset: 0x0001E6DD
		public static bool operator !=(QMenu c1, QMenu c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x000204F0 File Offset: 0x0001E6F0
		public override bool Equals(object obj)
		{
			if (obj is QMenu)
			{
				QMenu c = (QMenu)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x0002051A File Offset: 0x0001E71A
		internal QMenu(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x00020524 File Offset: 0x0001E724
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QMenu ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000BF1 RID: 3057 RVA: 0x0002055F File Offset: 0x0001E75F
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000BF2 RID: 3058 RVA: 0x00020571 File Offset: 0x0001E771
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x0002057C File Offset: 0x0001E77C
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x0002058F File Offset: 0x0001E78F
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QMenu was null when calling " + n);
			}
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x000205AA File Offset: 0x0001E7AA
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x000205B8 File Offset: 0x0001E7B8
		public static implicit operator QWidget(QMenu value)
		{
			method to_QWidget_From_QMenu = QMenu.__N.To_QWidget_From_QMenu;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QMenu);
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x000205DC File Offset: 0x0001E7DC
		public static explicit operator QMenu(QWidget value)
		{
			method from_QWidget_To_QMenu = QMenu.__N.From_QWidget_To_QMenu;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QMenu);
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x00020600 File Offset: 0x0001E800
		public static implicit operator QObject(QMenu value)
		{
			method to_QObject_From_QMenu = QMenu.__N.To_QObject_From_QMenu;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QMenu);
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x00020624 File Offset: 0x0001E824
		public static explicit operator QMenu(QObject value)
		{
			method from_QObject_To_QMenu = QMenu.__N.From_QObject_To_QMenu;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QMenu);
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x00020648 File Offset: 0x0001E848
		internal static QMenu Create(QWidget parent)
		{
			method qmenu_Create = QMenu.__N.QMenu_Create;
			return calli(System.IntPtr(System.IntPtr), parent, qmenu_Create);
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x0002066C File Offset: 0x0001E86C
		internal readonly void insertAction(QAction before, QAction action)
		{
			this.NullCheck("insertAction");
			method qmenu_insertAction = QMenu.__N.QMenu_insertAction;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, before, action, qmenu_insertAction);
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x000206A4 File Offset: 0x0001E8A4
		internal readonly QAction addSeparator()
		{
			this.NullCheck("addSeparator");
			method qmenu_addSeparator = QMenu.__N.QMenu_addSeparator;
			return calli(System.IntPtr(System.IntPtr), this.self, qmenu_addSeparator);
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x000206D4 File Offset: 0x0001E8D4
		internal readonly bool isEmpty()
		{
			this.NullCheck("isEmpty");
			method qmenu_isEmpty = QMenu.__N.QMenu_isEmpty;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_isEmpty) > 0;
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x00020704 File Offset: 0x0001E904
		internal readonly void clear()
		{
			this.NullCheck("clear");
			method qmenu_clear = QMenu.__N.QMenu_clear;
			calli(System.Void(System.IntPtr), this.self, qmenu_clear);
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x00020730 File Offset: 0x0001E930
		internal readonly string title()
		{
			this.NullCheck("title");
			method qmenu_title = QMenu.__N.QMenu_title;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qmenu_title));
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x00020760 File Offset: 0x0001E960
		internal readonly void setTitle(string title)
		{
			this.NullCheck("setTitle");
			method qmenu_setTitle = QMenu.__N.QMenu_setTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qmenu_setTitle);
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x00020790 File Offset: 0x0001E990
		internal readonly void exec(Vector3 pos)
		{
			this.NullCheck("exec");
			method qmenu_exec = QMenu.__N.QMenu_exec;
			calli(System.Void(System.IntPtr,Vector3), this.self, pos, qmenu_exec);
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x000207BC File Offset: 0x0001E9BC
		internal readonly QAction activeAction()
		{
			this.NullCheck("activeAction");
			method qmenu_activeAction = QMenu.__N.QMenu_activeAction;
			return calli(System.IntPtr(System.IntPtr), this.self, qmenu_activeAction);
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x000207EC File Offset: 0x0001E9EC
		internal readonly QAction addMenu(QMenu menu)
		{
			this.NullCheck("addMenu");
			method qmenu_addMenu = QMenu.__N.QMenu_addMenu;
			return calli(System.IntPtr(System.IntPtr,System.IntPtr), this.self, menu, qmenu_addMenu);
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x00020824 File Offset: 0x0001EA24
		internal readonly QAction insertMenu(QAction before, QMenu menu)
		{
			this.NullCheck("insertMenu");
			method qmenu_insertMenu = QMenu.__N.QMenu_insertMenu;
			return calli(System.IntPtr(System.IntPtr,System.IntPtr,System.IntPtr), this.self, before, menu, qmenu_insertMenu);
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x00020860 File Offset: 0x0001EA60
		internal readonly void setTearOffEnabled(bool b)
		{
			this.NullCheck("setTearOffEnabled");
			method qmenu_setTearOffEnabled = QMenu.__N.QMenu_setTearOffEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qmenu_setTearOffEnabled);
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x00020894 File Offset: 0x0001EA94
		internal readonly bool isTearOffEnabled()
		{
			this.NullCheck("isTearOffEnabled");
			method qmenu_isTearOffEnabled = QMenu.__N.QMenu_isTearOffEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_isTearOffEnabled) > 0;
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x000208C4 File Offset: 0x0001EAC4
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qmenu_isTopLevel = QMenu.__N.QMenu_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_isTopLevel) > 0;
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x000208F4 File Offset: 0x0001EAF4
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qmenu_isWindow = QMenu.__N.QMenu_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_isWindow) > 0;
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x00020924 File Offset: 0x0001EB24
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qmenu_isModal = QMenu.__N.QMenu_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_isModal) > 0;
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x00020954 File Offset: 0x0001EB54
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qmenu_setStyleSheet = QMenu.__N.QMenu_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qmenu_setStyleSheet);
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x00020984 File Offset: 0x0001EB84
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qmenu_windowTitle = QMenu.__N.QMenu_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qmenu_windowTitle));
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x000209B4 File Offset: 0x0001EBB4
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qmenu_setWindowTitle = QMenu.__N.QMenu_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qmenu_setWindowTitle);
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x000209E4 File Offset: 0x0001EBE4
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qmenu_setWindowFlags = QMenu.__N.QMenu_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qmenu_setWindowFlags);
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x00020A10 File Offset: 0x0001EC10
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qmenu_windowFlags = QMenu.__N.QMenu_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qmenu_windowFlags);
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x00020A3C File Offset: 0x0001EC3C
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qmenu_size = QMenu.__N.QMenu_size;
			return calli(Vector3(System.IntPtr), this.self, qmenu_size);
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x00020A68 File Offset: 0x0001EC68
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qmenu_resize = QMenu.__N.QMenu_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qmenu_resize);
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x00020A94 File Offset: 0x0001EC94
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qmenu_minimumSize = QMenu.__N.QMenu_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qmenu_minimumSize);
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x00020AC0 File Offset: 0x0001ECC0
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qmenu_setMinimumSize = QMenu.__N.QMenu_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qmenu_setMinimumSize);
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x00020AEC File Offset: 0x0001ECEC
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qmenu_maximumSize = QMenu.__N.QMenu_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qmenu_maximumSize);
		}

		// Token: 0x06000C14 RID: 3092 RVA: 0x00020B18 File Offset: 0x0001ED18
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qmenu_setMaximumSize = QMenu.__N.QMenu_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qmenu_setMaximumSize);
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x00020B44 File Offset: 0x0001ED44
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qmenu_pos = QMenu.__N.QMenu_pos;
			return calli(Vector3(System.IntPtr), this.self, qmenu_pos);
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x00020B70 File Offset: 0x0001ED70
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qmenu_move = QMenu.__N.QMenu_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qmenu_move);
		}

		// Token: 0x06000C17 RID: 3095 RVA: 0x00020B9C File Offset: 0x0001ED9C
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qmenu_isEnabled = QMenu.__N.QMenu_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_isEnabled) > 0;
		}

		// Token: 0x06000C18 RID: 3096 RVA: 0x00020BCC File Offset: 0x0001EDCC
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qmenu_setEnabled = QMenu.__N.QMenu_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qmenu_setEnabled);
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x00020C00 File Offset: 0x0001EE00
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qmenu_setVisible = QMenu.__N.QMenu_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qmenu_setVisible);
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x00020C34 File Offset: 0x0001EE34
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qmenu_setHidden = QMenu.__N.QMenu_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qmenu_setHidden);
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x00020C68 File Offset: 0x0001EE68
		internal readonly void show()
		{
			this.NullCheck("show");
			method qmenu_show = QMenu.__N.QMenu_show;
			calli(System.Void(System.IntPtr), this.self, qmenu_show);
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x00020C94 File Offset: 0x0001EE94
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qmenu_hide = QMenu.__N.QMenu_hide;
			calli(System.Void(System.IntPtr), this.self, qmenu_hide);
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x00020CC0 File Offset: 0x0001EEC0
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qmenu_showMinimized = QMenu.__N.QMenu_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qmenu_showMinimized);
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x00020CEC File Offset: 0x0001EEEC
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qmenu_showMaximized = QMenu.__N.QMenu_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qmenu_showMaximized);
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x00020D18 File Offset: 0x0001EF18
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qmenu_showFullScreen = QMenu.__N.QMenu_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qmenu_showFullScreen);
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x00020D44 File Offset: 0x0001EF44
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qmenu_showNormal = QMenu.__N.QMenu_showNormal;
			calli(System.Void(System.IntPtr), this.self, qmenu_showNormal);
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x00020D70 File Offset: 0x0001EF70
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qmenu_close = QMenu.__N.QMenu_close;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_close) > 0;
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x00020DA0 File Offset: 0x0001EFA0
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qmenu_raise = QMenu.__N.QMenu_raise;
			calli(System.Void(System.IntPtr), this.self, qmenu_raise);
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x00020DCC File Offset: 0x0001EFCC
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qmenu_lower = QMenu.__N.QMenu_lower;
			calli(System.Void(System.IntPtr), this.self, qmenu_lower);
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x00020DF8 File Offset: 0x0001EFF8
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qmenu_isVisible = QMenu.__N.QMenu_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_isVisible) > 0;
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x00020E28 File Offset: 0x0001F028
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qmenu_setAttribute = QMenu.__N.QMenu_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qmenu_setAttribute);
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x00020E5C File Offset: 0x0001F05C
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qmenu_testAttribute = QMenu.__N.QMenu_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qmenu_testAttribute) > 0;
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x00020E8C File Offset: 0x0001F08C
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qmenu_acceptDrops = QMenu.__N.QMenu_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_acceptDrops) > 0;
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x00020EBC File Offset: 0x0001F0BC
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qmenu_setAcceptDrops = QMenu.__N.QMenu_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qmenu_setAcceptDrops);
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x00020EF0 File Offset: 0x0001F0F0
		internal readonly void update()
		{
			this.NullCheck("update");
			method qmenu_update = QMenu.__N.QMenu_update;
			calli(System.Void(System.IntPtr), this.self, qmenu_update);
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x00020F1C File Offset: 0x0001F11C
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qmenu_repaint = QMenu.__N.QMenu_repaint;
			calli(System.Void(System.IntPtr), this.self, qmenu_repaint);
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x00020F48 File Offset: 0x0001F148
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qmenu_setCursor = QMenu.__N.QMenu_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qmenu_setCursor);
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x00020F74 File Offset: 0x0001F174
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qmenu_unsetCursor = QMenu.__N.QMenu_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qmenu_unsetCursor);
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x00020FA0 File Offset: 0x0001F1A0
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qmenu_setWindowIcon = QMenu.__N.QMenu_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qmenu_setWindowIcon);
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x00020FD0 File Offset: 0x0001F1D0
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qmenu_setWindowIconText = QMenu.__N.QMenu_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qmenu_setWindowIconText);
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x00021000 File Offset: 0x0001F200
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qmenu_setWindowOpacity = QMenu.__N.QMenu_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qmenu_setWindowOpacity);
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x0002102C File Offset: 0x0001F22C
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qmenu_windowOpacity = QMenu.__N.QMenu_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qmenu_windowOpacity);
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x00021058 File Offset: 0x0001F258
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qmenu_isMinimized = QMenu.__N.QMenu_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_isMinimized) > 0;
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x00021088 File Offset: 0x0001F288
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qmenu_isMaximized = QMenu.__N.QMenu_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_isMaximized) > 0;
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x000210B8 File Offset: 0x0001F2B8
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qmenu_isFullScreen = QMenu.__N.QMenu_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_isFullScreen) > 0;
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x000210E8 File Offset: 0x0001F2E8
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qmenu_setMouseTracking = QMenu.__N.QMenu_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qmenu_setMouseTracking);
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x0002111C File Offset: 0x0001F31C
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qmenu_hasMouseTracking = QMenu.__N.QMenu_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_hasMouseTracking) > 0;
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x0002114C File Offset: 0x0001F34C
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qmenu_underMouse = QMenu.__N.QMenu_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_underMouse) > 0;
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x0002117C File Offset: 0x0001F37C
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qmenu_mapToGlobal = QMenu.__N.QMenu_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qmenu_mapToGlobal);
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x000211A8 File Offset: 0x0001F3A8
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qmenu_mapFromGlobal = QMenu.__N.QMenu_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qmenu_mapFromGlobal);
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x000211D4 File Offset: 0x0001F3D4
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qmenu_hasFocus = QMenu.__N.QMenu_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_hasFocus) > 0;
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x00021204 File Offset: 0x0001F404
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qmenu_focusPolicy = QMenu.__N.QMenu_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qmenu_focusPolicy);
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x00021230 File Offset: 0x0001F430
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qmenu_setFocusPolicy = QMenu.__N.QMenu_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qmenu_setFocusPolicy);
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x0002125C File Offset: 0x0001F45C
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qmenu_setFocusProxy = QMenu.__N.QMenu_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qmenu_setFocusProxy);
		}

		// Token: 0x06000C3D RID: 3133 RVA: 0x0002128C File Offset: 0x0001F48C
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qmenu_isActiveWindow = QMenu.__N.QMenu_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_isActiveWindow) > 0;
		}

		// Token: 0x06000C3E RID: 3134 RVA: 0x000212BC File Offset: 0x0001F4BC
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qmenu_updatesEnabled = QMenu.__N.QMenu_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_updatesEnabled) > 0;
		}

		// Token: 0x06000C3F RID: 3135 RVA: 0x000212EC File Offset: 0x0001F4EC
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qmenu_setUpdatesEnabled = QMenu.__N.QMenu_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qmenu_setUpdatesEnabled);
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x00021320 File Offset: 0x0001F520
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qmenu_setFocus = QMenu.__N.QMenu_setFocus;
			calli(System.Void(System.IntPtr), this.self, qmenu_setFocus);
		}

		// Token: 0x06000C41 RID: 3137 RVA: 0x0002134C File Offset: 0x0001F54C
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qmenu_activateWindow = QMenu.__N.QMenu_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qmenu_activateWindow);
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x00021378 File Offset: 0x0001F578
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qmenu_clearFocus = QMenu.__N.QMenu_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qmenu_clearFocus);
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x000213A4 File Offset: 0x0001F5A4
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qmenu_setSizePolicy = QMenu.__N.QMenu_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qmenu_setSizePolicy);
		}

		// Token: 0x06000C44 RID: 3140 RVA: 0x000213D4 File Offset: 0x0001F5D4
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qmenu_devicePixelRatioF = QMenu.__N.QMenu_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qmenu_devicePixelRatioF);
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x00021400 File Offset: 0x0001F600
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qmenu_saveGeometry = QMenu.__N.QMenu_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qmenu_saveGeometry));
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x00021430 File Offset: 0x0001F630
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qmenu_restoreGeometry = QMenu.__N.QMenu_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qmenu_restoreGeometry) > 0;
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x00021464 File Offset: 0x0001F664
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qmenu_addAction = QMenu.__N.QMenu_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qmenu_addAction);
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x00021494 File Offset: 0x0001F694
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qmenu_removeAction = QMenu.__N.QMenu_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qmenu_removeAction);
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x000214C4 File Offset: 0x0001F6C4
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qmenu_setParent = QMenu.__N.QMenu_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qmenu_setParent);
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x000214F4 File Offset: 0x0001F6F4
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qmenu_parentWidget = QMenu.__N.QMenu_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qmenu_parentWidget);
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x00021524 File Offset: 0x0001F724
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qmenu_AddClassName = QMenu.__N.QMenu_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qmenu_AddClassName);
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x00021554 File Offset: 0x0001F754
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qmenu_Polish = QMenu.__N.QMenu_Polish;
			calli(System.Void(System.IntPtr), this.self, qmenu_Polish);
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x00021580 File Offset: 0x0001F780
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qmenu_toolTip = QMenu.__N.QMenu_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qmenu_toolTip));
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x000215B0 File Offset: 0x0001F7B0
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qmenu_setToolTip = QMenu.__N.QMenu_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qmenu_setToolTip);
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x000215E0 File Offset: 0x0001F7E0
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qmenu_statusTip = QMenu.__N.QMenu_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qmenu_statusTip));
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x00021610 File Offset: 0x0001F810
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qmenu_setStatusTip = QMenu.__N.QMenu_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qmenu_setStatusTip);
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x00021640 File Offset: 0x0001F840
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qmenu_toolTipDuration = QMenu.__N.QMenu_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_toolTipDuration);
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x0002166C File Offset: 0x0001F86C
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qmenu_setToolTipDuration = QMenu.__N.QMenu_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qmenu_setToolTipDuration);
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x00021698 File Offset: 0x0001F898
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qmenu_autoFillBackground = QMenu.__N.QMenu_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qmenu_autoFillBackground) > 0;
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x000216C8 File Offset: 0x0001F8C8
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qmenu_setAutoFillBackground = QMenu.__N.QMenu_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qmenu_setAutoFillBackground);
		}

		// Token: 0x0400005C RID: 92
		internal IntPtr self;

		// Token: 0x0200011D RID: 285
		internal static class __N
		{
			// Token: 0x04000DE4 RID: 3556
			internal static method From_QWidget_To_QMenu;

			// Token: 0x04000DE5 RID: 3557
			internal static method To_QWidget_From_QMenu;

			// Token: 0x04000DE6 RID: 3558
			internal static method From_QObject_To_QMenu;

			// Token: 0x04000DE7 RID: 3559
			internal static method To_QObject_From_QMenu;

			// Token: 0x04000DE8 RID: 3560
			internal static method QMenu_Create;

			// Token: 0x04000DE9 RID: 3561
			internal static method QMenu_insertAction;

			// Token: 0x04000DEA RID: 3562
			internal static method QMenu_addSeparator;

			// Token: 0x04000DEB RID: 3563
			internal static method QMenu_isEmpty;

			// Token: 0x04000DEC RID: 3564
			internal static method QMenu_clear;

			// Token: 0x04000DED RID: 3565
			internal static method QMenu_title;

			// Token: 0x04000DEE RID: 3566
			internal static method QMenu_setTitle;

			// Token: 0x04000DEF RID: 3567
			internal static method QMenu_exec;

			// Token: 0x04000DF0 RID: 3568
			internal static method QMenu_activeAction;

			// Token: 0x04000DF1 RID: 3569
			internal static method QMenu_addMenu;

			// Token: 0x04000DF2 RID: 3570
			internal static method QMenu_insertMenu;

			// Token: 0x04000DF3 RID: 3571
			internal static method QMenu_setTearOffEnabled;

			// Token: 0x04000DF4 RID: 3572
			internal static method QMenu_isTearOffEnabled;

			// Token: 0x04000DF5 RID: 3573
			internal static method QMenu_isTopLevel;

			// Token: 0x04000DF6 RID: 3574
			internal static method QMenu_isWindow;

			// Token: 0x04000DF7 RID: 3575
			internal static method QMenu_isModal;

			// Token: 0x04000DF8 RID: 3576
			internal static method QMenu_setStyleSheet;

			// Token: 0x04000DF9 RID: 3577
			internal static method QMenu_windowTitle;

			// Token: 0x04000DFA RID: 3578
			internal static method QMenu_setWindowTitle;

			// Token: 0x04000DFB RID: 3579
			internal static method QMenu_setWindowFlags;

			// Token: 0x04000DFC RID: 3580
			internal static method QMenu_windowFlags;

			// Token: 0x04000DFD RID: 3581
			internal static method QMenu_size;

			// Token: 0x04000DFE RID: 3582
			internal static method QMenu_resize;

			// Token: 0x04000DFF RID: 3583
			internal static method QMenu_minimumSize;

			// Token: 0x04000E00 RID: 3584
			internal static method QMenu_setMinimumSize;

			// Token: 0x04000E01 RID: 3585
			internal static method QMenu_maximumSize;

			// Token: 0x04000E02 RID: 3586
			internal static method QMenu_setMaximumSize;

			// Token: 0x04000E03 RID: 3587
			internal static method QMenu_pos;

			// Token: 0x04000E04 RID: 3588
			internal static method QMenu_move;

			// Token: 0x04000E05 RID: 3589
			internal static method QMenu_isEnabled;

			// Token: 0x04000E06 RID: 3590
			internal static method QMenu_setEnabled;

			// Token: 0x04000E07 RID: 3591
			internal static method QMenu_setVisible;

			// Token: 0x04000E08 RID: 3592
			internal static method QMenu_setHidden;

			// Token: 0x04000E09 RID: 3593
			internal static method QMenu_show;

			// Token: 0x04000E0A RID: 3594
			internal static method QMenu_hide;

			// Token: 0x04000E0B RID: 3595
			internal static method QMenu_showMinimized;

			// Token: 0x04000E0C RID: 3596
			internal static method QMenu_showMaximized;

			// Token: 0x04000E0D RID: 3597
			internal static method QMenu_showFullScreen;

			// Token: 0x04000E0E RID: 3598
			internal static method QMenu_showNormal;

			// Token: 0x04000E0F RID: 3599
			internal static method QMenu_close;

			// Token: 0x04000E10 RID: 3600
			internal static method QMenu_raise;

			// Token: 0x04000E11 RID: 3601
			internal static method QMenu_lower;

			// Token: 0x04000E12 RID: 3602
			internal static method QMenu_isVisible;

			// Token: 0x04000E13 RID: 3603
			internal static method QMenu_setAttribute;

			// Token: 0x04000E14 RID: 3604
			internal static method QMenu_testAttribute;

			// Token: 0x04000E15 RID: 3605
			internal static method QMenu_acceptDrops;

			// Token: 0x04000E16 RID: 3606
			internal static method QMenu_setAcceptDrops;

			// Token: 0x04000E17 RID: 3607
			internal static method QMenu_update;

			// Token: 0x04000E18 RID: 3608
			internal static method QMenu_repaint;

			// Token: 0x04000E19 RID: 3609
			internal static method QMenu_setCursor;

			// Token: 0x04000E1A RID: 3610
			internal static method QMenu_unsetCursor;

			// Token: 0x04000E1B RID: 3611
			internal static method QMenu_setWindowIcon;

			// Token: 0x04000E1C RID: 3612
			internal static method QMenu_setWindowIconText;

			// Token: 0x04000E1D RID: 3613
			internal static method QMenu_setWindowOpacity;

			// Token: 0x04000E1E RID: 3614
			internal static method QMenu_windowOpacity;

			// Token: 0x04000E1F RID: 3615
			internal static method QMenu_isMinimized;

			// Token: 0x04000E20 RID: 3616
			internal static method QMenu_isMaximized;

			// Token: 0x04000E21 RID: 3617
			internal static method QMenu_isFullScreen;

			// Token: 0x04000E22 RID: 3618
			internal static method QMenu_setMouseTracking;

			// Token: 0x04000E23 RID: 3619
			internal static method QMenu_hasMouseTracking;

			// Token: 0x04000E24 RID: 3620
			internal static method QMenu_underMouse;

			// Token: 0x04000E25 RID: 3621
			internal static method QMenu_mapToGlobal;

			// Token: 0x04000E26 RID: 3622
			internal static method QMenu_mapFromGlobal;

			// Token: 0x04000E27 RID: 3623
			internal static method QMenu_hasFocus;

			// Token: 0x04000E28 RID: 3624
			internal static method QMenu_focusPolicy;

			// Token: 0x04000E29 RID: 3625
			internal static method QMenu_setFocusPolicy;

			// Token: 0x04000E2A RID: 3626
			internal static method QMenu_setFocusProxy;

			// Token: 0x04000E2B RID: 3627
			internal static method QMenu_isActiveWindow;

			// Token: 0x04000E2C RID: 3628
			internal static method QMenu_updatesEnabled;

			// Token: 0x04000E2D RID: 3629
			internal static method QMenu_setUpdatesEnabled;

			// Token: 0x04000E2E RID: 3630
			internal static method QMenu_setFocus;

			// Token: 0x04000E2F RID: 3631
			internal static method QMenu_activateWindow;

			// Token: 0x04000E30 RID: 3632
			internal static method QMenu_clearFocus;

			// Token: 0x04000E31 RID: 3633
			internal static method QMenu_setSizePolicy;

			// Token: 0x04000E32 RID: 3634
			internal static method QMenu_devicePixelRatioF;

			// Token: 0x04000E33 RID: 3635
			internal static method QMenu_saveGeometry;

			// Token: 0x04000E34 RID: 3636
			internal static method QMenu_restoreGeometry;

			// Token: 0x04000E35 RID: 3637
			internal static method QMenu_addAction;

			// Token: 0x04000E36 RID: 3638
			internal static method QMenu_removeAction;

			// Token: 0x04000E37 RID: 3639
			internal static method QMenu_setParent;

			// Token: 0x04000E38 RID: 3640
			internal static method QMenu_parentWidget;

			// Token: 0x04000E39 RID: 3641
			internal static method QMenu_AddClassName;

			// Token: 0x04000E3A RID: 3642
			internal static method QMenu_Polish;

			// Token: 0x04000E3B RID: 3643
			internal static method QMenu_toolTip;

			// Token: 0x04000E3C RID: 3644
			internal static method QMenu_setToolTip;

			// Token: 0x04000E3D RID: 3645
			internal static method QMenu_statusTip;

			// Token: 0x04000E3E RID: 3646
			internal static method QMenu_setStatusTip;

			// Token: 0x04000E3F RID: 3647
			internal static method QMenu_toolTipDuration;

			// Token: 0x04000E40 RID: 3648
			internal static method QMenu_setToolTipDuration;

			// Token: 0x04000E41 RID: 3649
			internal static method QMenu_autoFillBackground;

			// Token: 0x04000E42 RID: 3650
			internal static method QMenu_setAutoFillBackground;
		}
	}
}
