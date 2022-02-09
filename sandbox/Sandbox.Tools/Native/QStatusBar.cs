using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x0200005A RID: 90
	internal struct QStatusBar
	{
		// Token: 0x06000ED6 RID: 3798 RVA: 0x000281C9 File Offset: 0x000263C9
		public static implicit operator IntPtr(QStatusBar value)
		{
			return value.self;
		}

		// Token: 0x06000ED7 RID: 3799 RVA: 0x000281D4 File Offset: 0x000263D4
		public static implicit operator QStatusBar(IntPtr value)
		{
			return new QStatusBar
			{
				self = value
			};
		}

		// Token: 0x06000ED8 RID: 3800 RVA: 0x000281F2 File Offset: 0x000263F2
		public static bool operator ==(QStatusBar c1, QStatusBar c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x00028205 File Offset: 0x00026405
		public static bool operator !=(QStatusBar c1, QStatusBar c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x00028218 File Offset: 0x00026418
		public override bool Equals(object obj)
		{
			if (obj is QStatusBar)
			{
				QStatusBar c = (QStatusBar)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000EDB RID: 3803 RVA: 0x00028242 File Offset: 0x00026442
		internal QStatusBar(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000EDC RID: 3804 RVA: 0x0002824C File Offset: 0x0002644C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QStatusBar ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000EDD RID: 3805 RVA: 0x00028288 File Offset: 0x00026488
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000EDE RID: 3806 RVA: 0x0002829A File Offset: 0x0002649A
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000EDF RID: 3807 RVA: 0x000282A5 File Offset: 0x000264A5
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000EE0 RID: 3808 RVA: 0x000282B8 File Offset: 0x000264B8
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QStatusBar was null when calling " + n);
			}
		}

		// Token: 0x06000EE1 RID: 3809 RVA: 0x000282D3 File Offset: 0x000264D3
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000EE2 RID: 3810 RVA: 0x000282E0 File Offset: 0x000264E0
		public static implicit operator QWidget(QStatusBar value)
		{
			method to_QWidget_From_QStatusBar = QStatusBar.__N.To_QWidget_From_QStatusBar;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QStatusBar);
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x00028304 File Offset: 0x00026504
		public static explicit operator QStatusBar(QWidget value)
		{
			method from_QWidget_To_QStatusBar = QStatusBar.__N.From_QWidget_To_QStatusBar;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QStatusBar);
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x00028328 File Offset: 0x00026528
		public static implicit operator QObject(QStatusBar value)
		{
			method to_QObject_From_QStatusBar = QStatusBar.__N.To_QObject_From_QStatusBar;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QStatusBar);
		}

		// Token: 0x06000EE5 RID: 3813 RVA: 0x0002834C File Offset: 0x0002654C
		public static explicit operator QStatusBar(QObject value)
		{
			method from_QObject_To_QStatusBar = QStatusBar.__N.From_QObject_To_QStatusBar;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QStatusBar);
		}

		// Token: 0x06000EE6 RID: 3814 RVA: 0x00028370 File Offset: 0x00026570
		internal readonly string currentMessage()
		{
			this.NullCheck("currentMessage");
			method qsttsB_currentMessage = QStatusBar.__N.QSttsB_currentMessage;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qsttsB_currentMessage));
		}

		// Token: 0x06000EE7 RID: 3815 RVA: 0x000283A0 File Offset: 0x000265A0
		internal readonly void showMessage(string text, int timeout)
		{
			this.NullCheck("showMessage");
			method qsttsB_showMessage = QStatusBar.__N.QSttsB_showMessage;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetWPointer(text), timeout, qsttsB_showMessage);
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x000283D4 File Offset: 0x000265D4
		internal readonly void clearMessage()
		{
			this.NullCheck("clearMessage");
			method qsttsB_clearMessage = QStatusBar.__N.QSttsB_clearMessage;
			calli(System.Void(System.IntPtr), this.self, qsttsB_clearMessage);
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x00028400 File Offset: 0x00026600
		internal readonly void setSizeGripEnabled(bool b)
		{
			this.NullCheck("setSizeGripEnabled");
			method qsttsB_setSizeGripEnabled = QStatusBar.__N.QSttsB_setSizeGripEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qsttsB_setSizeGripEnabled);
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x00028434 File Offset: 0x00026634
		internal readonly bool isSizeGripEnabled()
		{
			this.NullCheck("isSizeGripEnabled");
			method qsttsB_isSizeGripEnabled = QStatusBar.__N.QSttsB_isSizeGripEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_isSizeGripEnabled) > 0;
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x00028464 File Offset: 0x00026664
		internal readonly void addWidget(QWidget widget, int stretch)
		{
			this.NullCheck("addWidget");
			method qsttsB_addWidget = QStatusBar.__N.QSttsB_addWidget;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, widget, stretch, qsttsB_addWidget);
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x00028498 File Offset: 0x00026698
		internal readonly int insertWidget(int index, QWidget widget, int stretch)
		{
			this.NullCheck("insertWidget");
			method qsttsB_insertWidget = QStatusBar.__N.QSttsB_insertWidget;
			return calli(System.Int32(System.IntPtr,System.Int32,System.IntPtr,System.Int32), this.self, index, widget, stretch, qsttsB_insertWidget);
		}

		// Token: 0x06000EED RID: 3821 RVA: 0x000284CC File Offset: 0x000266CC
		internal readonly void addPermanentWidget(QWidget widget, int stretch)
		{
			this.NullCheck("addPermanentWidget");
			method qsttsB_addPermanentWidget = QStatusBar.__N.QSttsB_addPermanentWidget;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, widget, stretch, qsttsB_addPermanentWidget);
		}

		// Token: 0x06000EEE RID: 3822 RVA: 0x00028500 File Offset: 0x00026700
		internal readonly int insertPermanentWidget(int index, QWidget widget, int stretch)
		{
			this.NullCheck("insertPermanentWidget");
			method qsttsB_insertPermanentWidget = QStatusBar.__N.QSttsB_insertPermanentWidget;
			return calli(System.Int32(System.IntPtr,System.Int32,System.IntPtr,System.Int32), this.self, index, widget, stretch, qsttsB_insertPermanentWidget);
		}

		// Token: 0x06000EEF RID: 3823 RVA: 0x00028534 File Offset: 0x00026734
		internal readonly void removeWidget(QWidget widget)
		{
			this.NullCheck("removeWidget");
			method qsttsB_removeWidget = QStatusBar.__N.QSttsB_removeWidget;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qsttsB_removeWidget);
		}

		// Token: 0x06000EF0 RID: 3824 RVA: 0x00028564 File Offset: 0x00026764
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qsttsB_isTopLevel = QStatusBar.__N.QSttsB_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_isTopLevel) > 0;
		}

		// Token: 0x06000EF1 RID: 3825 RVA: 0x00028594 File Offset: 0x00026794
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qsttsB_isWindow = QStatusBar.__N.QSttsB_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_isWindow) > 0;
		}

		// Token: 0x06000EF2 RID: 3826 RVA: 0x000285C4 File Offset: 0x000267C4
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qsttsB_isModal = QStatusBar.__N.QSttsB_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_isModal) > 0;
		}

		// Token: 0x06000EF3 RID: 3827 RVA: 0x000285F4 File Offset: 0x000267F4
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qsttsB_setStyleSheet = QStatusBar.__N.QSttsB_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qsttsB_setStyleSheet);
		}

		// Token: 0x06000EF4 RID: 3828 RVA: 0x00028624 File Offset: 0x00026824
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qsttsB_windowTitle = QStatusBar.__N.QSttsB_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qsttsB_windowTitle));
		}

		// Token: 0x06000EF5 RID: 3829 RVA: 0x00028654 File Offset: 0x00026854
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qsttsB_setWindowTitle = QStatusBar.__N.QSttsB_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qsttsB_setWindowTitle);
		}

		// Token: 0x06000EF6 RID: 3830 RVA: 0x00028684 File Offset: 0x00026884
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qsttsB_setWindowFlags = QStatusBar.__N.QSttsB_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qsttsB_setWindowFlags);
		}

		// Token: 0x06000EF7 RID: 3831 RVA: 0x000286B0 File Offset: 0x000268B0
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qsttsB_windowFlags = QStatusBar.__N.QSttsB_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qsttsB_windowFlags);
		}

		// Token: 0x06000EF8 RID: 3832 RVA: 0x000286DC File Offset: 0x000268DC
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qsttsB_size = QStatusBar.__N.QSttsB_size;
			return calli(Vector3(System.IntPtr), this.self, qsttsB_size);
		}

		// Token: 0x06000EF9 RID: 3833 RVA: 0x00028708 File Offset: 0x00026908
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qsttsB_resize = QStatusBar.__N.QSttsB_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qsttsB_resize);
		}

		// Token: 0x06000EFA RID: 3834 RVA: 0x00028734 File Offset: 0x00026934
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qsttsB_minimumSize = QStatusBar.__N.QSttsB_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qsttsB_minimumSize);
		}

		// Token: 0x06000EFB RID: 3835 RVA: 0x00028760 File Offset: 0x00026960
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qsttsB_setMinimumSize = QStatusBar.__N.QSttsB_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qsttsB_setMinimumSize);
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x0002878C File Offset: 0x0002698C
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qsttsB_maximumSize = QStatusBar.__N.QSttsB_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qsttsB_maximumSize);
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x000287B8 File Offset: 0x000269B8
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qsttsB_setMaximumSize = QStatusBar.__N.QSttsB_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qsttsB_setMaximumSize);
		}

		// Token: 0x06000EFE RID: 3838 RVA: 0x000287E4 File Offset: 0x000269E4
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qsttsB_pos = QStatusBar.__N.QSttsB_pos;
			return calli(Vector3(System.IntPtr), this.self, qsttsB_pos);
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x00028810 File Offset: 0x00026A10
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qsttsB_move = QStatusBar.__N.QSttsB_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qsttsB_move);
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x0002883C File Offset: 0x00026A3C
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qsttsB_isEnabled = QStatusBar.__N.QSttsB_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_isEnabled) > 0;
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x0002886C File Offset: 0x00026A6C
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qsttsB_setEnabled = QStatusBar.__N.QSttsB_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qsttsB_setEnabled);
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x000288A0 File Offset: 0x00026AA0
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qsttsB_setVisible = QStatusBar.__N.QSttsB_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qsttsB_setVisible);
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x000288D4 File Offset: 0x00026AD4
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qsttsB_setHidden = QStatusBar.__N.QSttsB_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qsttsB_setHidden);
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x00028908 File Offset: 0x00026B08
		internal readonly void show()
		{
			this.NullCheck("show");
			method qsttsB_show = QStatusBar.__N.QSttsB_show;
			calli(System.Void(System.IntPtr), this.self, qsttsB_show);
		}

		// Token: 0x06000F05 RID: 3845 RVA: 0x00028934 File Offset: 0x00026B34
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qsttsB_hide = QStatusBar.__N.QSttsB_hide;
			calli(System.Void(System.IntPtr), this.self, qsttsB_hide);
		}

		// Token: 0x06000F06 RID: 3846 RVA: 0x00028960 File Offset: 0x00026B60
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qsttsB_showMinimized = QStatusBar.__N.QSttsB_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qsttsB_showMinimized);
		}

		// Token: 0x06000F07 RID: 3847 RVA: 0x0002898C File Offset: 0x00026B8C
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qsttsB_showMaximized = QStatusBar.__N.QSttsB_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qsttsB_showMaximized);
		}

		// Token: 0x06000F08 RID: 3848 RVA: 0x000289B8 File Offset: 0x00026BB8
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qsttsB_showFullScreen = QStatusBar.__N.QSttsB_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qsttsB_showFullScreen);
		}

		// Token: 0x06000F09 RID: 3849 RVA: 0x000289E4 File Offset: 0x00026BE4
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qsttsB_showNormal = QStatusBar.__N.QSttsB_showNormal;
			calli(System.Void(System.IntPtr), this.self, qsttsB_showNormal);
		}

		// Token: 0x06000F0A RID: 3850 RVA: 0x00028A10 File Offset: 0x00026C10
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qsttsB_close = QStatusBar.__N.QSttsB_close;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_close) > 0;
		}

		// Token: 0x06000F0B RID: 3851 RVA: 0x00028A40 File Offset: 0x00026C40
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qsttsB_raise = QStatusBar.__N.QSttsB_raise;
			calli(System.Void(System.IntPtr), this.self, qsttsB_raise);
		}

		// Token: 0x06000F0C RID: 3852 RVA: 0x00028A6C File Offset: 0x00026C6C
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qsttsB_lower = QStatusBar.__N.QSttsB_lower;
			calli(System.Void(System.IntPtr), this.self, qsttsB_lower);
		}

		// Token: 0x06000F0D RID: 3853 RVA: 0x00028A98 File Offset: 0x00026C98
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qsttsB_isVisible = QStatusBar.__N.QSttsB_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_isVisible) > 0;
		}

		// Token: 0x06000F0E RID: 3854 RVA: 0x00028AC8 File Offset: 0x00026CC8
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qsttsB_setAttribute = QStatusBar.__N.QSttsB_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qsttsB_setAttribute);
		}

		// Token: 0x06000F0F RID: 3855 RVA: 0x00028AFC File Offset: 0x00026CFC
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qsttsB_testAttribute = QStatusBar.__N.QSttsB_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qsttsB_testAttribute) > 0;
		}

		// Token: 0x06000F10 RID: 3856 RVA: 0x00028B2C File Offset: 0x00026D2C
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qsttsB_acceptDrops = QStatusBar.__N.QSttsB_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_acceptDrops) > 0;
		}

		// Token: 0x06000F11 RID: 3857 RVA: 0x00028B5C File Offset: 0x00026D5C
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qsttsB_setAcceptDrops = QStatusBar.__N.QSttsB_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qsttsB_setAcceptDrops);
		}

		// Token: 0x06000F12 RID: 3858 RVA: 0x00028B90 File Offset: 0x00026D90
		internal readonly void update()
		{
			this.NullCheck("update");
			method qsttsB_update = QStatusBar.__N.QSttsB_update;
			calli(System.Void(System.IntPtr), this.self, qsttsB_update);
		}

		// Token: 0x06000F13 RID: 3859 RVA: 0x00028BBC File Offset: 0x00026DBC
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qsttsB_repaint = QStatusBar.__N.QSttsB_repaint;
			calli(System.Void(System.IntPtr), this.self, qsttsB_repaint);
		}

		// Token: 0x06000F14 RID: 3860 RVA: 0x00028BE8 File Offset: 0x00026DE8
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qsttsB_setCursor = QStatusBar.__N.QSttsB_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qsttsB_setCursor);
		}

		// Token: 0x06000F15 RID: 3861 RVA: 0x00028C14 File Offset: 0x00026E14
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qsttsB_unsetCursor = QStatusBar.__N.QSttsB_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qsttsB_unsetCursor);
		}

		// Token: 0x06000F16 RID: 3862 RVA: 0x00028C40 File Offset: 0x00026E40
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qsttsB_setWindowIcon = QStatusBar.__N.QSttsB_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qsttsB_setWindowIcon);
		}

		// Token: 0x06000F17 RID: 3863 RVA: 0x00028C70 File Offset: 0x00026E70
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qsttsB_setWindowIconText = QStatusBar.__N.QSttsB_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qsttsB_setWindowIconText);
		}

		// Token: 0x06000F18 RID: 3864 RVA: 0x00028CA0 File Offset: 0x00026EA0
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qsttsB_setWindowOpacity = QStatusBar.__N.QSttsB_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qsttsB_setWindowOpacity);
		}

		// Token: 0x06000F19 RID: 3865 RVA: 0x00028CCC File Offset: 0x00026ECC
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qsttsB_windowOpacity = QStatusBar.__N.QSttsB_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qsttsB_windowOpacity);
		}

		// Token: 0x06000F1A RID: 3866 RVA: 0x00028CF8 File Offset: 0x00026EF8
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qsttsB_isMinimized = QStatusBar.__N.QSttsB_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_isMinimized) > 0;
		}

		// Token: 0x06000F1B RID: 3867 RVA: 0x00028D28 File Offset: 0x00026F28
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qsttsB_isMaximized = QStatusBar.__N.QSttsB_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_isMaximized) > 0;
		}

		// Token: 0x06000F1C RID: 3868 RVA: 0x00028D58 File Offset: 0x00026F58
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qsttsB_isFullScreen = QStatusBar.__N.QSttsB_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_isFullScreen) > 0;
		}

		// Token: 0x06000F1D RID: 3869 RVA: 0x00028D88 File Offset: 0x00026F88
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qsttsB_setMouseTracking = QStatusBar.__N.QSttsB_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qsttsB_setMouseTracking);
		}

		// Token: 0x06000F1E RID: 3870 RVA: 0x00028DBC File Offset: 0x00026FBC
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qsttsB_hasMouseTracking = QStatusBar.__N.QSttsB_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_hasMouseTracking) > 0;
		}

		// Token: 0x06000F1F RID: 3871 RVA: 0x00028DEC File Offset: 0x00026FEC
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qsttsB_underMouse = QStatusBar.__N.QSttsB_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_underMouse) > 0;
		}

		// Token: 0x06000F20 RID: 3872 RVA: 0x00028E1C File Offset: 0x0002701C
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qsttsB_mapToGlobal = QStatusBar.__N.QSttsB_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qsttsB_mapToGlobal);
		}

		// Token: 0x06000F21 RID: 3873 RVA: 0x00028E48 File Offset: 0x00027048
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qsttsB_mapFromGlobal = QStatusBar.__N.QSttsB_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qsttsB_mapFromGlobal);
		}

		// Token: 0x06000F22 RID: 3874 RVA: 0x00028E74 File Offset: 0x00027074
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qsttsB_hasFocus = QStatusBar.__N.QSttsB_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_hasFocus) > 0;
		}

		// Token: 0x06000F23 RID: 3875 RVA: 0x00028EA4 File Offset: 0x000270A4
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qsttsB_focusPolicy = QStatusBar.__N.QSttsB_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qsttsB_focusPolicy);
		}

		// Token: 0x06000F24 RID: 3876 RVA: 0x00028ED0 File Offset: 0x000270D0
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qsttsB_setFocusPolicy = QStatusBar.__N.QSttsB_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qsttsB_setFocusPolicy);
		}

		// Token: 0x06000F25 RID: 3877 RVA: 0x00028EFC File Offset: 0x000270FC
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qsttsB_setFocusProxy = QStatusBar.__N.QSttsB_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qsttsB_setFocusProxy);
		}

		// Token: 0x06000F26 RID: 3878 RVA: 0x00028F2C File Offset: 0x0002712C
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qsttsB_isActiveWindow = QStatusBar.__N.QSttsB_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_isActiveWindow) > 0;
		}

		// Token: 0x06000F27 RID: 3879 RVA: 0x00028F5C File Offset: 0x0002715C
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qsttsB_updatesEnabled = QStatusBar.__N.QSttsB_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_updatesEnabled) > 0;
		}

		// Token: 0x06000F28 RID: 3880 RVA: 0x00028F8C File Offset: 0x0002718C
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qsttsB_setUpdatesEnabled = QStatusBar.__N.QSttsB_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qsttsB_setUpdatesEnabled);
		}

		// Token: 0x06000F29 RID: 3881 RVA: 0x00028FC0 File Offset: 0x000271C0
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qsttsB_setFocus = QStatusBar.__N.QSttsB_setFocus;
			calli(System.Void(System.IntPtr), this.self, qsttsB_setFocus);
		}

		// Token: 0x06000F2A RID: 3882 RVA: 0x00028FEC File Offset: 0x000271EC
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qsttsB_activateWindow = QStatusBar.__N.QSttsB_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qsttsB_activateWindow);
		}

		// Token: 0x06000F2B RID: 3883 RVA: 0x00029018 File Offset: 0x00027218
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qsttsB_clearFocus = QStatusBar.__N.QSttsB_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qsttsB_clearFocus);
		}

		// Token: 0x06000F2C RID: 3884 RVA: 0x00029044 File Offset: 0x00027244
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qsttsB_setSizePolicy = QStatusBar.__N.QSttsB_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qsttsB_setSizePolicy);
		}

		// Token: 0x06000F2D RID: 3885 RVA: 0x00029074 File Offset: 0x00027274
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qsttsB_devicePixelRatioF = QStatusBar.__N.QSttsB_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qsttsB_devicePixelRatioF);
		}

		// Token: 0x06000F2E RID: 3886 RVA: 0x000290A0 File Offset: 0x000272A0
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qsttsB_saveGeometry = QStatusBar.__N.QSttsB_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qsttsB_saveGeometry));
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x000290D0 File Offset: 0x000272D0
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qsttsB_restoreGeometry = QStatusBar.__N.QSttsB_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qsttsB_restoreGeometry) > 0;
		}

		// Token: 0x06000F30 RID: 3888 RVA: 0x00029104 File Offset: 0x00027304
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qsttsB_addAction = QStatusBar.__N.QSttsB_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qsttsB_addAction);
		}

		// Token: 0x06000F31 RID: 3889 RVA: 0x00029134 File Offset: 0x00027334
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qsttsB_removeAction = QStatusBar.__N.QSttsB_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qsttsB_removeAction);
		}

		// Token: 0x06000F32 RID: 3890 RVA: 0x00029164 File Offset: 0x00027364
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qsttsB_setParent = QStatusBar.__N.QSttsB_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qsttsB_setParent);
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x00029194 File Offset: 0x00027394
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qsttsB_parentWidget = QStatusBar.__N.QSttsB_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qsttsB_parentWidget);
		}

		// Token: 0x06000F34 RID: 3892 RVA: 0x000291C4 File Offset: 0x000273C4
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qsttsB_AddClassName = QStatusBar.__N.QSttsB_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qsttsB_AddClassName);
		}

		// Token: 0x06000F35 RID: 3893 RVA: 0x000291F4 File Offset: 0x000273F4
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qsttsB_Polish = QStatusBar.__N.QSttsB_Polish;
			calli(System.Void(System.IntPtr), this.self, qsttsB_Polish);
		}

		// Token: 0x06000F36 RID: 3894 RVA: 0x00029220 File Offset: 0x00027420
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qsttsB_toolTip = QStatusBar.__N.QSttsB_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qsttsB_toolTip));
		}

		// Token: 0x06000F37 RID: 3895 RVA: 0x00029250 File Offset: 0x00027450
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qsttsB_setToolTip = QStatusBar.__N.QSttsB_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qsttsB_setToolTip);
		}

		// Token: 0x06000F38 RID: 3896 RVA: 0x00029280 File Offset: 0x00027480
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qsttsB_statusTip = QStatusBar.__N.QSttsB_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qsttsB_statusTip));
		}

		// Token: 0x06000F39 RID: 3897 RVA: 0x000292B0 File Offset: 0x000274B0
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qsttsB_setStatusTip = QStatusBar.__N.QSttsB_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qsttsB_setStatusTip);
		}

		// Token: 0x06000F3A RID: 3898 RVA: 0x000292E0 File Offset: 0x000274E0
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qsttsB_toolTipDuration = QStatusBar.__N.QSttsB_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_toolTipDuration);
		}

		// Token: 0x06000F3B RID: 3899 RVA: 0x0002930C File Offset: 0x0002750C
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qsttsB_setToolTipDuration = QStatusBar.__N.QSttsB_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qsttsB_setToolTipDuration);
		}

		// Token: 0x06000F3C RID: 3900 RVA: 0x00029338 File Offset: 0x00027538
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qsttsB_autoFillBackground = QStatusBar.__N.QSttsB_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qsttsB_autoFillBackground) > 0;
		}

		// Token: 0x06000F3D RID: 3901 RVA: 0x00029368 File Offset: 0x00027568
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qsttsB_setAutoFillBackground = QStatusBar.__N.QSttsB_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qsttsB_setAutoFillBackground);
		}

		// Token: 0x04000065 RID: 101
		internal IntPtr self;

		// Token: 0x02000126 RID: 294
		internal static class __N
		{
			// Token: 0x04001064 RID: 4196
			internal static method From_QWidget_To_QStatusBar;

			// Token: 0x04001065 RID: 4197
			internal static method To_QWidget_From_QStatusBar;

			// Token: 0x04001066 RID: 4198
			internal static method From_QObject_To_QStatusBar;

			// Token: 0x04001067 RID: 4199
			internal static method To_QObject_From_QStatusBar;

			// Token: 0x04001068 RID: 4200
			internal static method QSttsB_currentMessage;

			// Token: 0x04001069 RID: 4201
			internal static method QSttsB_showMessage;

			// Token: 0x0400106A RID: 4202
			internal static method QSttsB_clearMessage;

			// Token: 0x0400106B RID: 4203
			internal static method QSttsB_setSizeGripEnabled;

			// Token: 0x0400106C RID: 4204
			internal static method QSttsB_isSizeGripEnabled;

			// Token: 0x0400106D RID: 4205
			internal static method QSttsB_addWidget;

			// Token: 0x0400106E RID: 4206
			internal static method QSttsB_insertWidget;

			// Token: 0x0400106F RID: 4207
			internal static method QSttsB_addPermanentWidget;

			// Token: 0x04001070 RID: 4208
			internal static method QSttsB_insertPermanentWidget;

			// Token: 0x04001071 RID: 4209
			internal static method QSttsB_removeWidget;

			// Token: 0x04001072 RID: 4210
			internal static method QSttsB_isTopLevel;

			// Token: 0x04001073 RID: 4211
			internal static method QSttsB_isWindow;

			// Token: 0x04001074 RID: 4212
			internal static method QSttsB_isModal;

			// Token: 0x04001075 RID: 4213
			internal static method QSttsB_setStyleSheet;

			// Token: 0x04001076 RID: 4214
			internal static method QSttsB_windowTitle;

			// Token: 0x04001077 RID: 4215
			internal static method QSttsB_setWindowTitle;

			// Token: 0x04001078 RID: 4216
			internal static method QSttsB_setWindowFlags;

			// Token: 0x04001079 RID: 4217
			internal static method QSttsB_windowFlags;

			// Token: 0x0400107A RID: 4218
			internal static method QSttsB_size;

			// Token: 0x0400107B RID: 4219
			internal static method QSttsB_resize;

			// Token: 0x0400107C RID: 4220
			internal static method QSttsB_minimumSize;

			// Token: 0x0400107D RID: 4221
			internal static method QSttsB_setMinimumSize;

			// Token: 0x0400107E RID: 4222
			internal static method QSttsB_maximumSize;

			// Token: 0x0400107F RID: 4223
			internal static method QSttsB_setMaximumSize;

			// Token: 0x04001080 RID: 4224
			internal static method QSttsB_pos;

			// Token: 0x04001081 RID: 4225
			internal static method QSttsB_move;

			// Token: 0x04001082 RID: 4226
			internal static method QSttsB_isEnabled;

			// Token: 0x04001083 RID: 4227
			internal static method QSttsB_setEnabled;

			// Token: 0x04001084 RID: 4228
			internal static method QSttsB_setVisible;

			// Token: 0x04001085 RID: 4229
			internal static method QSttsB_setHidden;

			// Token: 0x04001086 RID: 4230
			internal static method QSttsB_show;

			// Token: 0x04001087 RID: 4231
			internal static method QSttsB_hide;

			// Token: 0x04001088 RID: 4232
			internal static method QSttsB_showMinimized;

			// Token: 0x04001089 RID: 4233
			internal static method QSttsB_showMaximized;

			// Token: 0x0400108A RID: 4234
			internal static method QSttsB_showFullScreen;

			// Token: 0x0400108B RID: 4235
			internal static method QSttsB_showNormal;

			// Token: 0x0400108C RID: 4236
			internal static method QSttsB_close;

			// Token: 0x0400108D RID: 4237
			internal static method QSttsB_raise;

			// Token: 0x0400108E RID: 4238
			internal static method QSttsB_lower;

			// Token: 0x0400108F RID: 4239
			internal static method QSttsB_isVisible;

			// Token: 0x04001090 RID: 4240
			internal static method QSttsB_setAttribute;

			// Token: 0x04001091 RID: 4241
			internal static method QSttsB_testAttribute;

			// Token: 0x04001092 RID: 4242
			internal static method QSttsB_acceptDrops;

			// Token: 0x04001093 RID: 4243
			internal static method QSttsB_setAcceptDrops;

			// Token: 0x04001094 RID: 4244
			internal static method QSttsB_update;

			// Token: 0x04001095 RID: 4245
			internal static method QSttsB_repaint;

			// Token: 0x04001096 RID: 4246
			internal static method QSttsB_setCursor;

			// Token: 0x04001097 RID: 4247
			internal static method QSttsB_unsetCursor;

			// Token: 0x04001098 RID: 4248
			internal static method QSttsB_setWindowIcon;

			// Token: 0x04001099 RID: 4249
			internal static method QSttsB_setWindowIconText;

			// Token: 0x0400109A RID: 4250
			internal static method QSttsB_setWindowOpacity;

			// Token: 0x0400109B RID: 4251
			internal static method QSttsB_windowOpacity;

			// Token: 0x0400109C RID: 4252
			internal static method QSttsB_isMinimized;

			// Token: 0x0400109D RID: 4253
			internal static method QSttsB_isMaximized;

			// Token: 0x0400109E RID: 4254
			internal static method QSttsB_isFullScreen;

			// Token: 0x0400109F RID: 4255
			internal static method QSttsB_setMouseTracking;

			// Token: 0x040010A0 RID: 4256
			internal static method QSttsB_hasMouseTracking;

			// Token: 0x040010A1 RID: 4257
			internal static method QSttsB_underMouse;

			// Token: 0x040010A2 RID: 4258
			internal static method QSttsB_mapToGlobal;

			// Token: 0x040010A3 RID: 4259
			internal static method QSttsB_mapFromGlobal;

			// Token: 0x040010A4 RID: 4260
			internal static method QSttsB_hasFocus;

			// Token: 0x040010A5 RID: 4261
			internal static method QSttsB_focusPolicy;

			// Token: 0x040010A6 RID: 4262
			internal static method QSttsB_setFocusPolicy;

			// Token: 0x040010A7 RID: 4263
			internal static method QSttsB_setFocusProxy;

			// Token: 0x040010A8 RID: 4264
			internal static method QSttsB_isActiveWindow;

			// Token: 0x040010A9 RID: 4265
			internal static method QSttsB_updatesEnabled;

			// Token: 0x040010AA RID: 4266
			internal static method QSttsB_setUpdatesEnabled;

			// Token: 0x040010AB RID: 4267
			internal static method QSttsB_setFocus;

			// Token: 0x040010AC RID: 4268
			internal static method QSttsB_activateWindow;

			// Token: 0x040010AD RID: 4269
			internal static method QSttsB_clearFocus;

			// Token: 0x040010AE RID: 4270
			internal static method QSttsB_setSizePolicy;

			// Token: 0x040010AF RID: 4271
			internal static method QSttsB_devicePixelRatioF;

			// Token: 0x040010B0 RID: 4272
			internal static method QSttsB_saveGeometry;

			// Token: 0x040010B1 RID: 4273
			internal static method QSttsB_restoreGeometry;

			// Token: 0x040010B2 RID: 4274
			internal static method QSttsB_addAction;

			// Token: 0x040010B3 RID: 4275
			internal static method QSttsB_removeAction;

			// Token: 0x040010B4 RID: 4276
			internal static method QSttsB_setParent;

			// Token: 0x040010B5 RID: 4277
			internal static method QSttsB_parentWidget;

			// Token: 0x040010B6 RID: 4278
			internal static method QSttsB_AddClassName;

			// Token: 0x040010B7 RID: 4279
			internal static method QSttsB_Polish;

			// Token: 0x040010B8 RID: 4280
			internal static method QSttsB_toolTip;

			// Token: 0x040010B9 RID: 4281
			internal static method QSttsB_setToolTip;

			// Token: 0x040010BA RID: 4282
			internal static method QSttsB_statusTip;

			// Token: 0x040010BB RID: 4283
			internal static method QSttsB_setStatusTip;

			// Token: 0x040010BC RID: 4284
			internal static method QSttsB_toolTipDuration;

			// Token: 0x040010BD RID: 4285
			internal static method QSttsB_setToolTipDuration;

			// Token: 0x040010BE RID: 4286
			internal static method QSttsB_autoFillBackground;

			// Token: 0x040010BF RID: 4287
			internal static method QSttsB_setAutoFillBackground;
		}
	}
}
