using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x0200005B RID: 91
	internal struct QTabBar
	{
		// Token: 0x06000F3E RID: 3902 RVA: 0x00029399 File Offset: 0x00027599
		public static implicit operator IntPtr(QTabBar value)
		{
			return value.self;
		}

		// Token: 0x06000F3F RID: 3903 RVA: 0x000293A4 File Offset: 0x000275A4
		public static implicit operator QTabBar(IntPtr value)
		{
			return new QTabBar
			{
				self = value
			};
		}

		// Token: 0x06000F40 RID: 3904 RVA: 0x000293C2 File Offset: 0x000275C2
		public static bool operator ==(QTabBar c1, QTabBar c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000F41 RID: 3905 RVA: 0x000293D5 File Offset: 0x000275D5
		public static bool operator !=(QTabBar c1, QTabBar c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000F42 RID: 3906 RVA: 0x000293E8 File Offset: 0x000275E8
		public override bool Equals(object obj)
		{
			if (obj is QTabBar)
			{
				QTabBar c = (QTabBar)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000F43 RID: 3907 RVA: 0x00029412 File Offset: 0x00027612
		internal QTabBar(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x0002941C File Offset: 0x0002761C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QTabBar ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000F45 RID: 3909 RVA: 0x00029457 File Offset: 0x00027657
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000F46 RID: 3910 RVA: 0x00029469 File Offset: 0x00027669
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x00029474 File Offset: 0x00027674
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000F48 RID: 3912 RVA: 0x00029487 File Offset: 0x00027687
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QTabBar was null when calling " + n);
			}
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x000294A2 File Offset: 0x000276A2
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x000294B0 File Offset: 0x000276B0
		public static implicit operator QWidget(QTabBar value)
		{
			method to_QWidget_From_QTabBar = QTabBar.__N.To_QWidget_From_QTabBar;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QTabBar);
		}

		// Token: 0x06000F4B RID: 3915 RVA: 0x000294D4 File Offset: 0x000276D4
		public static explicit operator QTabBar(QWidget value)
		{
			method from_QWidget_To_QTabBar = QTabBar.__N.From_QWidget_To_QTabBar;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QTabBar);
		}

		// Token: 0x06000F4C RID: 3916 RVA: 0x000294F8 File Offset: 0x000276F8
		public static implicit operator QObject(QTabBar value)
		{
			method to_QObject_From_QTabBar = QTabBar.__N.To_QObject_From_QTabBar;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QTabBar);
		}

		// Token: 0x06000F4D RID: 3917 RVA: 0x0002951C File Offset: 0x0002771C
		public static explicit operator QTabBar(QObject value)
		{
			method from_QObject_To_QTabBar = QTabBar.__N.From_QObject_To_QTabBar;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QTabBar);
		}

		// Token: 0x06000F4E RID: 3918 RVA: 0x00029540 File Offset: 0x00027740
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qtabBa_isTopLevel = QTabBar.__N.QTabBa_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_isTopLevel) > 0;
		}

		// Token: 0x06000F4F RID: 3919 RVA: 0x00029570 File Offset: 0x00027770
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qtabBa_isWindow = QTabBar.__N.QTabBa_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_isWindow) > 0;
		}

		// Token: 0x06000F50 RID: 3920 RVA: 0x000295A0 File Offset: 0x000277A0
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qtabBa_isModal = QTabBar.__N.QTabBa_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_isModal) > 0;
		}

		// Token: 0x06000F51 RID: 3921 RVA: 0x000295D0 File Offset: 0x000277D0
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qtabBa_setStyleSheet = QTabBar.__N.QTabBa_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qtabBa_setStyleSheet);
		}

		// Token: 0x06000F52 RID: 3922 RVA: 0x00029600 File Offset: 0x00027800
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qtabBa_windowTitle = QTabBar.__N.QTabBa_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qtabBa_windowTitle));
		}

		// Token: 0x06000F53 RID: 3923 RVA: 0x00029630 File Offset: 0x00027830
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qtabBa_setWindowTitle = QTabBar.__N.QTabBa_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qtabBa_setWindowTitle);
		}

		// Token: 0x06000F54 RID: 3924 RVA: 0x00029660 File Offset: 0x00027860
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qtabBa_setWindowFlags = QTabBar.__N.QTabBa_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qtabBa_setWindowFlags);
		}

		// Token: 0x06000F55 RID: 3925 RVA: 0x0002968C File Offset: 0x0002788C
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qtabBa_windowFlags = QTabBar.__N.QTabBa_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qtabBa_windowFlags);
		}

		// Token: 0x06000F56 RID: 3926 RVA: 0x000296B8 File Offset: 0x000278B8
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qtabBa_size = QTabBar.__N.QTabBa_size;
			return calli(Vector3(System.IntPtr), this.self, qtabBa_size);
		}

		// Token: 0x06000F57 RID: 3927 RVA: 0x000296E4 File Offset: 0x000278E4
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qtabBa_resize = QTabBar.__N.QTabBa_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qtabBa_resize);
		}

		// Token: 0x06000F58 RID: 3928 RVA: 0x00029710 File Offset: 0x00027910
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qtabBa_minimumSize = QTabBar.__N.QTabBa_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qtabBa_minimumSize);
		}

		// Token: 0x06000F59 RID: 3929 RVA: 0x0002973C File Offset: 0x0002793C
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qtabBa_setMinimumSize = QTabBar.__N.QTabBa_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qtabBa_setMinimumSize);
		}

		// Token: 0x06000F5A RID: 3930 RVA: 0x00029768 File Offset: 0x00027968
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qtabBa_maximumSize = QTabBar.__N.QTabBa_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qtabBa_maximumSize);
		}

		// Token: 0x06000F5B RID: 3931 RVA: 0x00029794 File Offset: 0x00027994
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qtabBa_setMaximumSize = QTabBar.__N.QTabBa_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qtabBa_setMaximumSize);
		}

		// Token: 0x06000F5C RID: 3932 RVA: 0x000297C0 File Offset: 0x000279C0
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qtabBa_pos = QTabBar.__N.QTabBa_pos;
			return calli(Vector3(System.IntPtr), this.self, qtabBa_pos);
		}

		// Token: 0x06000F5D RID: 3933 RVA: 0x000297EC File Offset: 0x000279EC
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qtabBa_move = QTabBar.__N.QTabBa_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qtabBa_move);
		}

		// Token: 0x06000F5E RID: 3934 RVA: 0x00029818 File Offset: 0x00027A18
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qtabBa_isEnabled = QTabBar.__N.QTabBa_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_isEnabled) > 0;
		}

		// Token: 0x06000F5F RID: 3935 RVA: 0x00029848 File Offset: 0x00027A48
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qtabBa_setEnabled = QTabBar.__N.QTabBa_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qtabBa_setEnabled);
		}

		// Token: 0x06000F60 RID: 3936 RVA: 0x0002987C File Offset: 0x00027A7C
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qtabBa_setVisible = QTabBar.__N.QTabBa_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qtabBa_setVisible);
		}

		// Token: 0x06000F61 RID: 3937 RVA: 0x000298B0 File Offset: 0x00027AB0
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qtabBa_setHidden = QTabBar.__N.QTabBa_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qtabBa_setHidden);
		}

		// Token: 0x06000F62 RID: 3938 RVA: 0x000298E4 File Offset: 0x00027AE4
		internal readonly void show()
		{
			this.NullCheck("show");
			method qtabBa_show = QTabBar.__N.QTabBa_show;
			calli(System.Void(System.IntPtr), this.self, qtabBa_show);
		}

		// Token: 0x06000F63 RID: 3939 RVA: 0x00029910 File Offset: 0x00027B10
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qtabBa_hide = QTabBar.__N.QTabBa_hide;
			calli(System.Void(System.IntPtr), this.self, qtabBa_hide);
		}

		// Token: 0x06000F64 RID: 3940 RVA: 0x0002993C File Offset: 0x00027B3C
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qtabBa_showMinimized = QTabBar.__N.QTabBa_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qtabBa_showMinimized);
		}

		// Token: 0x06000F65 RID: 3941 RVA: 0x00029968 File Offset: 0x00027B68
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qtabBa_showMaximized = QTabBar.__N.QTabBa_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qtabBa_showMaximized);
		}

		// Token: 0x06000F66 RID: 3942 RVA: 0x00029994 File Offset: 0x00027B94
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qtabBa_showFullScreen = QTabBar.__N.QTabBa_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qtabBa_showFullScreen);
		}

		// Token: 0x06000F67 RID: 3943 RVA: 0x000299C0 File Offset: 0x00027BC0
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qtabBa_showNormal = QTabBar.__N.QTabBa_showNormal;
			calli(System.Void(System.IntPtr), this.self, qtabBa_showNormal);
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x000299EC File Offset: 0x00027BEC
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qtabBa_close = QTabBar.__N.QTabBa_close;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_close) > 0;
		}

		// Token: 0x06000F69 RID: 3945 RVA: 0x00029A1C File Offset: 0x00027C1C
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qtabBa_raise = QTabBar.__N.QTabBa_raise;
			calli(System.Void(System.IntPtr), this.self, qtabBa_raise);
		}

		// Token: 0x06000F6A RID: 3946 RVA: 0x00029A48 File Offset: 0x00027C48
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qtabBa_lower = QTabBar.__N.QTabBa_lower;
			calli(System.Void(System.IntPtr), this.self, qtabBa_lower);
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x00029A74 File Offset: 0x00027C74
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qtabBa_isVisible = QTabBar.__N.QTabBa_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_isVisible) > 0;
		}

		// Token: 0x06000F6C RID: 3948 RVA: 0x00029AA4 File Offset: 0x00027CA4
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qtabBa_setAttribute = QTabBar.__N.QTabBa_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qtabBa_setAttribute);
		}

		// Token: 0x06000F6D RID: 3949 RVA: 0x00029AD8 File Offset: 0x00027CD8
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qtabBa_testAttribute = QTabBar.__N.QTabBa_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qtabBa_testAttribute) > 0;
		}

		// Token: 0x06000F6E RID: 3950 RVA: 0x00029B08 File Offset: 0x00027D08
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qtabBa_acceptDrops = QTabBar.__N.QTabBa_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_acceptDrops) > 0;
		}

		// Token: 0x06000F6F RID: 3951 RVA: 0x00029B38 File Offset: 0x00027D38
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qtabBa_setAcceptDrops = QTabBar.__N.QTabBa_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qtabBa_setAcceptDrops);
		}

		// Token: 0x06000F70 RID: 3952 RVA: 0x00029B6C File Offset: 0x00027D6C
		internal readonly void update()
		{
			this.NullCheck("update");
			method qtabBa_update = QTabBar.__N.QTabBa_update;
			calli(System.Void(System.IntPtr), this.self, qtabBa_update);
		}

		// Token: 0x06000F71 RID: 3953 RVA: 0x00029B98 File Offset: 0x00027D98
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qtabBa_repaint = QTabBar.__N.QTabBa_repaint;
			calli(System.Void(System.IntPtr), this.self, qtabBa_repaint);
		}

		// Token: 0x06000F72 RID: 3954 RVA: 0x00029BC4 File Offset: 0x00027DC4
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qtabBa_setCursor = QTabBar.__N.QTabBa_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qtabBa_setCursor);
		}

		// Token: 0x06000F73 RID: 3955 RVA: 0x00029BF0 File Offset: 0x00027DF0
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qtabBa_unsetCursor = QTabBar.__N.QTabBa_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qtabBa_unsetCursor);
		}

		// Token: 0x06000F74 RID: 3956 RVA: 0x00029C1C File Offset: 0x00027E1C
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qtabBa_setWindowIcon = QTabBar.__N.QTabBa_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qtabBa_setWindowIcon);
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x00029C4C File Offset: 0x00027E4C
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qtabBa_setWindowIconText = QTabBar.__N.QTabBa_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qtabBa_setWindowIconText);
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x00029C7C File Offset: 0x00027E7C
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qtabBa_setWindowOpacity = QTabBar.__N.QTabBa_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qtabBa_setWindowOpacity);
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x00029CA8 File Offset: 0x00027EA8
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qtabBa_windowOpacity = QTabBar.__N.QTabBa_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qtabBa_windowOpacity);
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x00029CD4 File Offset: 0x00027ED4
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qtabBa_isMinimized = QTabBar.__N.QTabBa_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_isMinimized) > 0;
		}

		// Token: 0x06000F79 RID: 3961 RVA: 0x00029D04 File Offset: 0x00027F04
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qtabBa_isMaximized = QTabBar.__N.QTabBa_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_isMaximized) > 0;
		}

		// Token: 0x06000F7A RID: 3962 RVA: 0x00029D34 File Offset: 0x00027F34
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qtabBa_isFullScreen = QTabBar.__N.QTabBa_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_isFullScreen) > 0;
		}

		// Token: 0x06000F7B RID: 3963 RVA: 0x00029D64 File Offset: 0x00027F64
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qtabBa_setMouseTracking = QTabBar.__N.QTabBa_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qtabBa_setMouseTracking);
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x00029D98 File Offset: 0x00027F98
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qtabBa_hasMouseTracking = QTabBar.__N.QTabBa_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_hasMouseTracking) > 0;
		}

		// Token: 0x06000F7D RID: 3965 RVA: 0x00029DC8 File Offset: 0x00027FC8
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qtabBa_underMouse = QTabBar.__N.QTabBa_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_underMouse) > 0;
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x00029DF8 File Offset: 0x00027FF8
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qtabBa_mapToGlobal = QTabBar.__N.QTabBa_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qtabBa_mapToGlobal);
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x00029E24 File Offset: 0x00028024
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qtabBa_mapFromGlobal = QTabBar.__N.QTabBa_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qtabBa_mapFromGlobal);
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x00029E50 File Offset: 0x00028050
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qtabBa_hasFocus = QTabBar.__N.QTabBa_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_hasFocus) > 0;
		}

		// Token: 0x06000F81 RID: 3969 RVA: 0x00029E80 File Offset: 0x00028080
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qtabBa_focusPolicy = QTabBar.__N.QTabBa_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qtabBa_focusPolicy);
		}

		// Token: 0x06000F82 RID: 3970 RVA: 0x00029EAC File Offset: 0x000280AC
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qtabBa_setFocusPolicy = QTabBar.__N.QTabBa_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qtabBa_setFocusPolicy);
		}

		// Token: 0x06000F83 RID: 3971 RVA: 0x00029ED8 File Offset: 0x000280D8
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qtabBa_setFocusProxy = QTabBar.__N.QTabBa_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qtabBa_setFocusProxy);
		}

		// Token: 0x06000F84 RID: 3972 RVA: 0x00029F08 File Offset: 0x00028108
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qtabBa_isActiveWindow = QTabBar.__N.QTabBa_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_isActiveWindow) > 0;
		}

		// Token: 0x06000F85 RID: 3973 RVA: 0x00029F38 File Offset: 0x00028138
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qtabBa_updatesEnabled = QTabBar.__N.QTabBa_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_updatesEnabled) > 0;
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x00029F68 File Offset: 0x00028168
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qtabBa_setUpdatesEnabled = QTabBar.__N.QTabBa_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qtabBa_setUpdatesEnabled);
		}

		// Token: 0x06000F87 RID: 3975 RVA: 0x00029F9C File Offset: 0x0002819C
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qtabBa_setFocus = QTabBar.__N.QTabBa_setFocus;
			calli(System.Void(System.IntPtr), this.self, qtabBa_setFocus);
		}

		// Token: 0x06000F88 RID: 3976 RVA: 0x00029FC8 File Offset: 0x000281C8
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qtabBa_activateWindow = QTabBar.__N.QTabBa_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qtabBa_activateWindow);
		}

		// Token: 0x06000F89 RID: 3977 RVA: 0x00029FF4 File Offset: 0x000281F4
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qtabBa_clearFocus = QTabBar.__N.QTabBa_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qtabBa_clearFocus);
		}

		// Token: 0x06000F8A RID: 3978 RVA: 0x0002A020 File Offset: 0x00028220
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qtabBa_setSizePolicy = QTabBar.__N.QTabBa_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qtabBa_setSizePolicy);
		}

		// Token: 0x06000F8B RID: 3979 RVA: 0x0002A050 File Offset: 0x00028250
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qtabBa_devicePixelRatioF = QTabBar.__N.QTabBa_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qtabBa_devicePixelRatioF);
		}

		// Token: 0x06000F8C RID: 3980 RVA: 0x0002A07C File Offset: 0x0002827C
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qtabBa_saveGeometry = QTabBar.__N.QTabBa_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qtabBa_saveGeometry));
		}

		// Token: 0x06000F8D RID: 3981 RVA: 0x0002A0AC File Offset: 0x000282AC
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qtabBa_restoreGeometry = QTabBar.__N.QTabBa_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qtabBa_restoreGeometry) > 0;
		}

		// Token: 0x06000F8E RID: 3982 RVA: 0x0002A0E0 File Offset: 0x000282E0
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qtabBa_addAction = QTabBar.__N.QTabBa_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qtabBa_addAction);
		}

		// Token: 0x06000F8F RID: 3983 RVA: 0x0002A110 File Offset: 0x00028310
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qtabBa_removeAction = QTabBar.__N.QTabBa_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qtabBa_removeAction);
		}

		// Token: 0x06000F90 RID: 3984 RVA: 0x0002A140 File Offset: 0x00028340
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qtabBa_setParent = QTabBar.__N.QTabBa_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qtabBa_setParent);
		}

		// Token: 0x06000F91 RID: 3985 RVA: 0x0002A170 File Offset: 0x00028370
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qtabBa_parentWidget = QTabBar.__N.QTabBa_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qtabBa_parentWidget);
		}

		// Token: 0x06000F92 RID: 3986 RVA: 0x0002A1A0 File Offset: 0x000283A0
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qtabBa_AddClassName = QTabBar.__N.QTabBa_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qtabBa_AddClassName);
		}

		// Token: 0x06000F93 RID: 3987 RVA: 0x0002A1D0 File Offset: 0x000283D0
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qtabBa_Polish = QTabBar.__N.QTabBa_Polish;
			calli(System.Void(System.IntPtr), this.self, qtabBa_Polish);
		}

		// Token: 0x06000F94 RID: 3988 RVA: 0x0002A1FC File Offset: 0x000283FC
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qtabBa_toolTip = QTabBar.__N.QTabBa_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qtabBa_toolTip));
		}

		// Token: 0x06000F95 RID: 3989 RVA: 0x0002A22C File Offset: 0x0002842C
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qtabBa_setToolTip = QTabBar.__N.QTabBa_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qtabBa_setToolTip);
		}

		// Token: 0x06000F96 RID: 3990 RVA: 0x0002A25C File Offset: 0x0002845C
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qtabBa_statusTip = QTabBar.__N.QTabBa_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qtabBa_statusTip));
		}

		// Token: 0x06000F97 RID: 3991 RVA: 0x0002A28C File Offset: 0x0002848C
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qtabBa_setStatusTip = QTabBar.__N.QTabBa_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qtabBa_setStatusTip);
		}

		// Token: 0x06000F98 RID: 3992 RVA: 0x0002A2BC File Offset: 0x000284BC
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qtabBa_toolTipDuration = QTabBar.__N.QTabBa_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_toolTipDuration);
		}

		// Token: 0x06000F99 RID: 3993 RVA: 0x0002A2E8 File Offset: 0x000284E8
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qtabBa_setToolTipDuration = QTabBar.__N.QTabBa_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qtabBa_setToolTipDuration);
		}

		// Token: 0x06000F9A RID: 3994 RVA: 0x0002A314 File Offset: 0x00028514
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qtabBa_autoFillBackground = QTabBar.__N.QTabBa_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qtabBa_autoFillBackground) > 0;
		}

		// Token: 0x06000F9B RID: 3995 RVA: 0x0002A344 File Offset: 0x00028544
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qtabBa_setAutoFillBackground = QTabBar.__N.QTabBa_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qtabBa_setAutoFillBackground);
		}

		// Token: 0x04000066 RID: 102
		internal IntPtr self;

		// Token: 0x02000127 RID: 295
		internal static class __N
		{
			// Token: 0x040010C0 RID: 4288
			internal static method From_QWidget_To_QTabBar;

			// Token: 0x040010C1 RID: 4289
			internal static method To_QWidget_From_QTabBar;

			// Token: 0x040010C2 RID: 4290
			internal static method From_QObject_To_QTabBar;

			// Token: 0x040010C3 RID: 4291
			internal static method To_QObject_From_QTabBar;

			// Token: 0x040010C4 RID: 4292
			internal static method QTabBa_isTopLevel;

			// Token: 0x040010C5 RID: 4293
			internal static method QTabBa_isWindow;

			// Token: 0x040010C6 RID: 4294
			internal static method QTabBa_isModal;

			// Token: 0x040010C7 RID: 4295
			internal static method QTabBa_setStyleSheet;

			// Token: 0x040010C8 RID: 4296
			internal static method QTabBa_windowTitle;

			// Token: 0x040010C9 RID: 4297
			internal static method QTabBa_setWindowTitle;

			// Token: 0x040010CA RID: 4298
			internal static method QTabBa_setWindowFlags;

			// Token: 0x040010CB RID: 4299
			internal static method QTabBa_windowFlags;

			// Token: 0x040010CC RID: 4300
			internal static method QTabBa_size;

			// Token: 0x040010CD RID: 4301
			internal static method QTabBa_resize;

			// Token: 0x040010CE RID: 4302
			internal static method QTabBa_minimumSize;

			// Token: 0x040010CF RID: 4303
			internal static method QTabBa_setMinimumSize;

			// Token: 0x040010D0 RID: 4304
			internal static method QTabBa_maximumSize;

			// Token: 0x040010D1 RID: 4305
			internal static method QTabBa_setMaximumSize;

			// Token: 0x040010D2 RID: 4306
			internal static method QTabBa_pos;

			// Token: 0x040010D3 RID: 4307
			internal static method QTabBa_move;

			// Token: 0x040010D4 RID: 4308
			internal static method QTabBa_isEnabled;

			// Token: 0x040010D5 RID: 4309
			internal static method QTabBa_setEnabled;

			// Token: 0x040010D6 RID: 4310
			internal static method QTabBa_setVisible;

			// Token: 0x040010D7 RID: 4311
			internal static method QTabBa_setHidden;

			// Token: 0x040010D8 RID: 4312
			internal static method QTabBa_show;

			// Token: 0x040010D9 RID: 4313
			internal static method QTabBa_hide;

			// Token: 0x040010DA RID: 4314
			internal static method QTabBa_showMinimized;

			// Token: 0x040010DB RID: 4315
			internal static method QTabBa_showMaximized;

			// Token: 0x040010DC RID: 4316
			internal static method QTabBa_showFullScreen;

			// Token: 0x040010DD RID: 4317
			internal static method QTabBa_showNormal;

			// Token: 0x040010DE RID: 4318
			internal static method QTabBa_close;

			// Token: 0x040010DF RID: 4319
			internal static method QTabBa_raise;

			// Token: 0x040010E0 RID: 4320
			internal static method QTabBa_lower;

			// Token: 0x040010E1 RID: 4321
			internal static method QTabBa_isVisible;

			// Token: 0x040010E2 RID: 4322
			internal static method QTabBa_setAttribute;

			// Token: 0x040010E3 RID: 4323
			internal static method QTabBa_testAttribute;

			// Token: 0x040010E4 RID: 4324
			internal static method QTabBa_acceptDrops;

			// Token: 0x040010E5 RID: 4325
			internal static method QTabBa_setAcceptDrops;

			// Token: 0x040010E6 RID: 4326
			internal static method QTabBa_update;

			// Token: 0x040010E7 RID: 4327
			internal static method QTabBa_repaint;

			// Token: 0x040010E8 RID: 4328
			internal static method QTabBa_setCursor;

			// Token: 0x040010E9 RID: 4329
			internal static method QTabBa_unsetCursor;

			// Token: 0x040010EA RID: 4330
			internal static method QTabBa_setWindowIcon;

			// Token: 0x040010EB RID: 4331
			internal static method QTabBa_setWindowIconText;

			// Token: 0x040010EC RID: 4332
			internal static method QTabBa_setWindowOpacity;

			// Token: 0x040010ED RID: 4333
			internal static method QTabBa_windowOpacity;

			// Token: 0x040010EE RID: 4334
			internal static method QTabBa_isMinimized;

			// Token: 0x040010EF RID: 4335
			internal static method QTabBa_isMaximized;

			// Token: 0x040010F0 RID: 4336
			internal static method QTabBa_isFullScreen;

			// Token: 0x040010F1 RID: 4337
			internal static method QTabBa_setMouseTracking;

			// Token: 0x040010F2 RID: 4338
			internal static method QTabBa_hasMouseTracking;

			// Token: 0x040010F3 RID: 4339
			internal static method QTabBa_underMouse;

			// Token: 0x040010F4 RID: 4340
			internal static method QTabBa_mapToGlobal;

			// Token: 0x040010F5 RID: 4341
			internal static method QTabBa_mapFromGlobal;

			// Token: 0x040010F6 RID: 4342
			internal static method QTabBa_hasFocus;

			// Token: 0x040010F7 RID: 4343
			internal static method QTabBa_focusPolicy;

			// Token: 0x040010F8 RID: 4344
			internal static method QTabBa_setFocusPolicy;

			// Token: 0x040010F9 RID: 4345
			internal static method QTabBa_setFocusProxy;

			// Token: 0x040010FA RID: 4346
			internal static method QTabBa_isActiveWindow;

			// Token: 0x040010FB RID: 4347
			internal static method QTabBa_updatesEnabled;

			// Token: 0x040010FC RID: 4348
			internal static method QTabBa_setUpdatesEnabled;

			// Token: 0x040010FD RID: 4349
			internal static method QTabBa_setFocus;

			// Token: 0x040010FE RID: 4350
			internal static method QTabBa_activateWindow;

			// Token: 0x040010FF RID: 4351
			internal static method QTabBa_clearFocus;

			// Token: 0x04001100 RID: 4352
			internal static method QTabBa_setSizePolicy;

			// Token: 0x04001101 RID: 4353
			internal static method QTabBa_devicePixelRatioF;

			// Token: 0x04001102 RID: 4354
			internal static method QTabBa_saveGeometry;

			// Token: 0x04001103 RID: 4355
			internal static method QTabBa_restoreGeometry;

			// Token: 0x04001104 RID: 4356
			internal static method QTabBa_addAction;

			// Token: 0x04001105 RID: 4357
			internal static method QTabBa_removeAction;

			// Token: 0x04001106 RID: 4358
			internal static method QTabBa_setParent;

			// Token: 0x04001107 RID: 4359
			internal static method QTabBa_parentWidget;

			// Token: 0x04001108 RID: 4360
			internal static method QTabBa_AddClassName;

			// Token: 0x04001109 RID: 4361
			internal static method QTabBa_Polish;

			// Token: 0x0400110A RID: 4362
			internal static method QTabBa_toolTip;

			// Token: 0x0400110B RID: 4363
			internal static method QTabBa_setToolTip;

			// Token: 0x0400110C RID: 4364
			internal static method QTabBa_statusTip;

			// Token: 0x0400110D RID: 4365
			internal static method QTabBa_setStatusTip;

			// Token: 0x0400110E RID: 4366
			internal static method QTabBa_toolTipDuration;

			// Token: 0x0400110F RID: 4367
			internal static method QTabBa_setToolTipDuration;

			// Token: 0x04001110 RID: 4368
			internal static method QTabBa_autoFillBackground;

			// Token: 0x04001111 RID: 4369
			internal static method QTabBa_setAutoFillBackground;
		}
	}
}
