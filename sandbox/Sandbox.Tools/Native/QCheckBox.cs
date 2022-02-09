using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000043 RID: 67
	internal struct QCheckBox
	{
		// Token: 0x06000705 RID: 1797 RVA: 0x0001319F File Offset: 0x0001139F
		public static implicit operator IntPtr(QCheckBox value)
		{
			return value.self;
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x000131A8 File Offset: 0x000113A8
		public static implicit operator QCheckBox(IntPtr value)
		{
			return new QCheckBox
			{
				self = value
			};
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x000131C6 File Offset: 0x000113C6
		public static bool operator ==(QCheckBox c1, QCheckBox c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x000131D9 File Offset: 0x000113D9
		public static bool operator !=(QCheckBox c1, QCheckBox c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x000131EC File Offset: 0x000113EC
		public override bool Equals(object obj)
		{
			if (obj is QCheckBox)
			{
				QCheckBox c = (QCheckBox)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00013216 File Offset: 0x00011416
		internal QCheckBox(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00013220 File Offset: 0x00011420
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QCheckBox ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600070C RID: 1804 RVA: 0x0001325C File Offset: 0x0001145C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x0001326E File Offset: 0x0001146E
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x00013279 File Offset: 0x00011479
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x0001328C File Offset: 0x0001148C
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QCheckBox was null when calling " + n);
			}
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x000132A7 File Offset: 0x000114A7
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x000132B4 File Offset: 0x000114B4
		public static implicit operator QAbstractButton(QCheckBox value)
		{
			method to_QAbstractButton_From_QCheckBox = QCheckBox.__N.To_QAbstractButton_From_QCheckBox;
			return calli(System.IntPtr(System.IntPtr), value, to_QAbstractButton_From_QCheckBox);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x000132D8 File Offset: 0x000114D8
		public static explicit operator QCheckBox(QAbstractButton value)
		{
			method from_QAbstractButton_To_QCheckBox = QCheckBox.__N.From_QAbstractButton_To_QCheckBox;
			return calli(System.IntPtr(System.IntPtr), value, from_QAbstractButton_To_QCheckBox);
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x000132FC File Offset: 0x000114FC
		public static implicit operator QWidget(QCheckBox value)
		{
			method to_QWidget_From_QCheckBox = QCheckBox.__N.To_QWidget_From_QCheckBox;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QCheckBox);
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x00013320 File Offset: 0x00011520
		public static explicit operator QCheckBox(QWidget value)
		{
			method from_QWidget_To_QCheckBox = QCheckBox.__N.From_QWidget_To_QCheckBox;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QCheckBox);
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00013344 File Offset: 0x00011544
		public static implicit operator QObject(QCheckBox value)
		{
			method to_QObject_From_QCheckBox = QCheckBox.__N.To_QObject_From_QCheckBox;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QCheckBox);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x00013368 File Offset: 0x00011568
		public static explicit operator QCheckBox(QObject value)
		{
			method from_QObject_To_QCheckBox = QCheckBox.__N.From_QObject_To_QCheckBox;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QCheckBox);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x0001338C File Offset: 0x0001158C
		internal readonly void setTristate(bool y)
		{
			this.NullCheck("setTristate");
			method qcheck_setTristate = QCheckBox.__N.QCheck_setTristate;
			calli(System.Void(System.IntPtr,System.Int32), this.self, y ? 1 : 0, qcheck_setTristate);
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x000133C0 File Offset: 0x000115C0
		internal readonly bool isTristate()
		{
			this.NullCheck("isTristate");
			method qcheck_isTristate = QCheckBox.__N.QCheck_isTristate;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_isTristate) > 0;
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x000133F0 File Offset: 0x000115F0
		internal readonly CheckState checkState()
		{
			this.NullCheck("checkState");
			method qcheck_checkState = QCheckBox.__N.QCheck_checkState;
			return calli(System.Int64(System.IntPtr), this.self, qcheck_checkState);
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x0001341C File Offset: 0x0001161C
		internal readonly void setCheckState(CheckState state)
		{
			this.NullCheck("setCheckState");
			method qcheck_setCheckState = QCheckBox.__N.QCheck_setCheckState;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)state, qcheck_setCheckState);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x00013448 File Offset: 0x00011648
		internal readonly void setText(string text)
		{
			this.NullCheck("setText");
			method qcheck_setText = QCheckBox.__N.QCheck_setText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qcheck_setText);
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x00013478 File Offset: 0x00011678
		internal readonly string text()
		{
			this.NullCheck("text");
			method qcheck_text = QCheckBox.__N.QCheck_text;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qcheck_text));
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x000134A8 File Offset: 0x000116A8
		internal readonly void setIcon(string icon)
		{
			this.NullCheck("setIcon");
			method qcheck_setIcon = QCheckBox.__N.QCheck_setIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qcheck_setIcon);
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x000134D8 File Offset: 0x000116D8
		internal readonly void setCheckable(bool b)
		{
			this.NullCheck("setCheckable");
			method qcheck_setCheckable = QCheckBox.__N.QCheck_setCheckable;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qcheck_setCheckable);
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x0001350C File Offset: 0x0001170C
		internal readonly bool isCheckable()
		{
			this.NullCheck("isCheckable");
			method qcheck_isCheckable = QCheckBox.__N.QCheck_isCheckable;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_isCheckable) > 0;
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x0001353C File Offset: 0x0001173C
		internal readonly bool isChecked()
		{
			this.NullCheck("isChecked");
			method qcheck_isChecked = QCheckBox.__N.QCheck_isChecked;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_isChecked) > 0;
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x0001356C File Offset: 0x0001176C
		internal readonly void setDown(bool b)
		{
			this.NullCheck("setDown");
			method qcheck_setDown = QCheckBox.__N.QCheck_setDown;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qcheck_setDown);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x000135A0 File Offset: 0x000117A0
		internal readonly bool isDown()
		{
			this.NullCheck("isDown");
			method qcheck_isDown = QCheckBox.__N.QCheck_isDown;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_isDown) > 0;
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x000135D0 File Offset: 0x000117D0
		internal readonly void setIconSize(Vector3 size)
		{
			this.NullCheck("setIconSize");
			method qcheck_setIconSize = QCheckBox.__N.QCheck_setIconSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, size, qcheck_setIconSize);
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x000135FC File Offset: 0x000117FC
		internal readonly void animateClick(int msec)
		{
			this.NullCheck("animateClick");
			method qcheck_animateClick = QCheckBox.__N.QCheck_animateClick;
			calli(System.Void(System.IntPtr,System.Int32), this.self, msec, qcheck_animateClick);
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x00013628 File Offset: 0x00011828
		internal readonly void click()
		{
			this.NullCheck("click");
			method qcheck_click = QCheckBox.__N.QCheck_click;
			calli(System.Void(System.IntPtr), this.self, qcheck_click);
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00013654 File Offset: 0x00011854
		internal readonly void toggle()
		{
			this.NullCheck("toggle");
			method qcheck_toggle = QCheckBox.__N.QCheck_toggle;
			calli(System.Void(System.IntPtr), this.self, qcheck_toggle);
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00013680 File Offset: 0x00011880
		internal readonly void setChecked(bool b)
		{
			this.NullCheck("setChecked");
			method qcheck_setChecked = QCheckBox.__N.QCheck_setChecked;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qcheck_setChecked);
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x000136B4 File Offset: 0x000118B4
		internal readonly void setAutoRepeat(bool x)
		{
			this.NullCheck("setAutoRepeat");
			method qcheck_setAutoRepeat = QCheckBox.__N.QCheck_setAutoRepeat;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qcheck_setAutoRepeat);
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x000136E8 File Offset: 0x000118E8
		internal readonly bool autoRepeat()
		{
			this.NullCheck("autoRepeat");
			method qcheck_autoRepeat = QCheckBox.__N.QCheck_autoRepeat;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_autoRepeat) > 0;
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x00013718 File Offset: 0x00011918
		internal readonly void setAutoRepeatDelay(int x)
		{
			this.NullCheck("setAutoRepeatDelay");
			method qcheck_setAutoRepeatDelay = QCheckBox.__N.QCheck_setAutoRepeatDelay;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qcheck_setAutoRepeatDelay);
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00013744 File Offset: 0x00011944
		internal readonly int autoRepeatDelay()
		{
			this.NullCheck("autoRepeatDelay");
			method qcheck_autoRepeatDelay = QCheckBox.__N.QCheck_autoRepeatDelay;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_autoRepeatDelay);
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00013770 File Offset: 0x00011970
		internal readonly void setAutoRepeatInterval(int x)
		{
			this.NullCheck("setAutoRepeatInterval");
			method qcheck_setAutoRepeatInterval = QCheckBox.__N.QCheck_setAutoRepeatInterval;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qcheck_setAutoRepeatInterval);
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0001379C File Offset: 0x0001199C
		internal readonly int autoRepeatInterval()
		{
			this.NullCheck("autoRepeatInterval");
			method qcheck_autoRepeatInterval = QCheckBox.__N.QCheck_autoRepeatInterval;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_autoRepeatInterval);
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x000137C8 File Offset: 0x000119C8
		internal readonly void setAutoExclusive(bool x)
		{
			this.NullCheck("setAutoExclusive");
			method qcheck_setAutoExclusive = QCheckBox.__N.QCheck_setAutoExclusive;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qcheck_setAutoExclusive);
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x000137FC File Offset: 0x000119FC
		internal readonly bool autoExclusive()
		{
			this.NullCheck("autoExclusive");
			method qcheck_autoExclusive = QCheckBox.__N.QCheck_autoExclusive;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_autoExclusive) > 0;
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x0001382C File Offset: 0x00011A2C
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qcheck_isTopLevel = QCheckBox.__N.QCheck_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_isTopLevel) > 0;
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0001385C File Offset: 0x00011A5C
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qcheck_isWindow = QCheckBox.__N.QCheck_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_isWindow) > 0;
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x0001388C File Offset: 0x00011A8C
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qcheck_isModal = QCheckBox.__N.QCheck_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_isModal) > 0;
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x000138BC File Offset: 0x00011ABC
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qcheck_setStyleSheet = QCheckBox.__N.QCheck_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qcheck_setStyleSheet);
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x000138EC File Offset: 0x00011AEC
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qcheck_windowTitle = QCheckBox.__N.QCheck_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qcheck_windowTitle));
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x0001391C File Offset: 0x00011B1C
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qcheck_setWindowTitle = QCheckBox.__N.QCheck_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qcheck_setWindowTitle);
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x0001394C File Offset: 0x00011B4C
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qcheck_setWindowFlags = QCheckBox.__N.QCheck_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qcheck_setWindowFlags);
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x00013978 File Offset: 0x00011B78
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qcheck_windowFlags = QCheckBox.__N.QCheck_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qcheck_windowFlags);
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x000139A4 File Offset: 0x00011BA4
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qcheck_size = QCheckBox.__N.QCheck_size;
			return calli(Vector3(System.IntPtr), this.self, qcheck_size);
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x000139D0 File Offset: 0x00011BD0
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qcheck_resize = QCheckBox.__N.QCheck_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qcheck_resize);
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x000139FC File Offset: 0x00011BFC
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qcheck_minimumSize = QCheckBox.__N.QCheck_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qcheck_minimumSize);
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00013A28 File Offset: 0x00011C28
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qcheck_setMinimumSize = QCheckBox.__N.QCheck_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qcheck_setMinimumSize);
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00013A54 File Offset: 0x00011C54
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qcheck_maximumSize = QCheckBox.__N.QCheck_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qcheck_maximumSize);
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00013A80 File Offset: 0x00011C80
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qcheck_setMaximumSize = QCheckBox.__N.QCheck_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qcheck_setMaximumSize);
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x00013AAC File Offset: 0x00011CAC
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qcheck_pos = QCheckBox.__N.QCheck_pos;
			return calli(Vector3(System.IntPtr), this.self, qcheck_pos);
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x00013AD8 File Offset: 0x00011CD8
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qcheck_move = QCheckBox.__N.QCheck_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qcheck_move);
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00013B04 File Offset: 0x00011D04
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qcheck_isEnabled = QCheckBox.__N.QCheck_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_isEnabled) > 0;
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00013B34 File Offset: 0x00011D34
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qcheck_setEnabled = QCheckBox.__N.QCheck_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qcheck_setEnabled);
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00013B68 File Offset: 0x00011D68
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qcheck_setVisible = QCheckBox.__N.QCheck_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qcheck_setVisible);
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x00013B9C File Offset: 0x00011D9C
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qcheck_setHidden = QCheckBox.__N.QCheck_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qcheck_setHidden);
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x00013BD0 File Offset: 0x00011DD0
		internal readonly void show()
		{
			this.NullCheck("show");
			method qcheck_show = QCheckBox.__N.QCheck_show;
			calli(System.Void(System.IntPtr), this.self, qcheck_show);
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x00013BFC File Offset: 0x00011DFC
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qcheck_hide = QCheckBox.__N.QCheck_hide;
			calli(System.Void(System.IntPtr), this.self, qcheck_hide);
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x00013C28 File Offset: 0x00011E28
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qcheck_showMinimized = QCheckBox.__N.QCheck_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qcheck_showMinimized);
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x00013C54 File Offset: 0x00011E54
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qcheck_showMaximized = QCheckBox.__N.QCheck_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qcheck_showMaximized);
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x00013C80 File Offset: 0x00011E80
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qcheck_showFullScreen = QCheckBox.__N.QCheck_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qcheck_showFullScreen);
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00013CAC File Offset: 0x00011EAC
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qcheck_showNormal = QCheckBox.__N.QCheck_showNormal;
			calli(System.Void(System.IntPtr), this.self, qcheck_showNormal);
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x00013CD8 File Offset: 0x00011ED8
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qcheck_close = QCheckBox.__N.QCheck_close;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_close) > 0;
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00013D08 File Offset: 0x00011F08
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qcheck_raise = QCheckBox.__N.QCheck_raise;
			calli(System.Void(System.IntPtr), this.self, qcheck_raise);
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x00013D34 File Offset: 0x00011F34
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qcheck_lower = QCheckBox.__N.QCheck_lower;
			calli(System.Void(System.IntPtr), this.self, qcheck_lower);
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x00013D60 File Offset: 0x00011F60
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qcheck_isVisible = QCheckBox.__N.QCheck_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_isVisible) > 0;
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x00013D90 File Offset: 0x00011F90
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qcheck_setAttribute = QCheckBox.__N.QCheck_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qcheck_setAttribute);
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x00013DC4 File Offset: 0x00011FC4
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qcheck_testAttribute = QCheckBox.__N.QCheck_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qcheck_testAttribute) > 0;
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x00013DF4 File Offset: 0x00011FF4
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qcheck_acceptDrops = QCheckBox.__N.QCheck_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_acceptDrops) > 0;
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x00013E24 File Offset: 0x00012024
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qcheck_setAcceptDrops = QCheckBox.__N.QCheck_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qcheck_setAcceptDrops);
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x00013E58 File Offset: 0x00012058
		internal readonly void update()
		{
			this.NullCheck("update");
			method qcheck_update = QCheckBox.__N.QCheck_update;
			calli(System.Void(System.IntPtr), this.self, qcheck_update);
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x00013E84 File Offset: 0x00012084
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qcheck_repaint = QCheckBox.__N.QCheck_repaint;
			calli(System.Void(System.IntPtr), this.self, qcheck_repaint);
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x00013EB0 File Offset: 0x000120B0
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qcheck_setCursor = QCheckBox.__N.QCheck_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qcheck_setCursor);
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x00013EDC File Offset: 0x000120DC
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qcheck_unsetCursor = QCheckBox.__N.QCheck_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qcheck_unsetCursor);
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x00013F08 File Offset: 0x00012108
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qcheck_setWindowIcon = QCheckBox.__N.QCheck_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qcheck_setWindowIcon);
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x00013F38 File Offset: 0x00012138
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qcheck_setWindowIconText = QCheckBox.__N.QCheck_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qcheck_setWindowIconText);
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x00013F68 File Offset: 0x00012168
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qcheck_setWindowOpacity = QCheckBox.__N.QCheck_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qcheck_setWindowOpacity);
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x00013F94 File Offset: 0x00012194
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qcheck_windowOpacity = QCheckBox.__N.QCheck_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qcheck_windowOpacity);
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x00013FC0 File Offset: 0x000121C0
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qcheck_isMinimized = QCheckBox.__N.QCheck_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_isMinimized) > 0;
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x00013FF0 File Offset: 0x000121F0
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qcheck_isMaximized = QCheckBox.__N.QCheck_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_isMaximized) > 0;
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x00014020 File Offset: 0x00012220
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qcheck_isFullScreen = QCheckBox.__N.QCheck_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_isFullScreen) > 0;
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x00014050 File Offset: 0x00012250
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qcheck_setMouseTracking = QCheckBox.__N.QCheck_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qcheck_setMouseTracking);
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x00014084 File Offset: 0x00012284
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qcheck_hasMouseTracking = QCheckBox.__N.QCheck_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_hasMouseTracking) > 0;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x000140B4 File Offset: 0x000122B4
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qcheck_underMouse = QCheckBox.__N.QCheck_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_underMouse) > 0;
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x000140E4 File Offset: 0x000122E4
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qcheck_mapToGlobal = QCheckBox.__N.QCheck_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qcheck_mapToGlobal);
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x00014110 File Offset: 0x00012310
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qcheck_mapFromGlobal = QCheckBox.__N.QCheck_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qcheck_mapFromGlobal);
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0001413C File Offset: 0x0001233C
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qcheck_hasFocus = QCheckBox.__N.QCheck_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_hasFocus) > 0;
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0001416C File Offset: 0x0001236C
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qcheck_focusPolicy = QCheckBox.__N.QCheck_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qcheck_focusPolicy);
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x00014198 File Offset: 0x00012398
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qcheck_setFocusPolicy = QCheckBox.__N.QCheck_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qcheck_setFocusPolicy);
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x000141C4 File Offset: 0x000123C4
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qcheck_setFocusProxy = QCheckBox.__N.QCheck_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qcheck_setFocusProxy);
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x000141F4 File Offset: 0x000123F4
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qcheck_isActiveWindow = QCheckBox.__N.QCheck_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_isActiveWindow) > 0;
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x00014224 File Offset: 0x00012424
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qcheck_updatesEnabled = QCheckBox.__N.QCheck_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_updatesEnabled) > 0;
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x00014254 File Offset: 0x00012454
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qcheck_setUpdatesEnabled = QCheckBox.__N.QCheck_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qcheck_setUpdatesEnabled);
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x00014288 File Offset: 0x00012488
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qcheck_setFocus = QCheckBox.__N.QCheck_setFocus;
			calli(System.Void(System.IntPtr), this.self, qcheck_setFocus);
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x000142B4 File Offset: 0x000124B4
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qcheck_activateWindow = QCheckBox.__N.QCheck_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qcheck_activateWindow);
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x000142E0 File Offset: 0x000124E0
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qcheck_clearFocus = QCheckBox.__N.QCheck_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qcheck_clearFocus);
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x0001430C File Offset: 0x0001250C
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qcheck_setSizePolicy = QCheckBox.__N.QCheck_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qcheck_setSizePolicy);
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x0001433C File Offset: 0x0001253C
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qcheck_devicePixelRatioF = QCheckBox.__N.QCheck_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qcheck_devicePixelRatioF);
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x00014368 File Offset: 0x00012568
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qcheck_saveGeometry = QCheckBox.__N.QCheck_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qcheck_saveGeometry));
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x00014398 File Offset: 0x00012598
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qcheck_restoreGeometry = QCheckBox.__N.QCheck_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qcheck_restoreGeometry) > 0;
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x000143CC File Offset: 0x000125CC
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qcheck_addAction = QCheckBox.__N.QCheck_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qcheck_addAction);
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x000143FC File Offset: 0x000125FC
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qcheck_removeAction = QCheckBox.__N.QCheck_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qcheck_removeAction);
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0001442C File Offset: 0x0001262C
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qcheck_setParent = QCheckBox.__N.QCheck_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qcheck_setParent);
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x0001445C File Offset: 0x0001265C
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qcheck_parentWidget = QCheckBox.__N.QCheck_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qcheck_parentWidget);
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x0001448C File Offset: 0x0001268C
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qcheck_AddClassName = QCheckBox.__N.QCheck_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qcheck_AddClassName);
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x000144BC File Offset: 0x000126BC
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qcheck_Polish = QCheckBox.__N.QCheck_Polish;
			calli(System.Void(System.IntPtr), this.self, qcheck_Polish);
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x000144E8 File Offset: 0x000126E8
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qcheck_toolTip = QCheckBox.__N.QCheck_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qcheck_toolTip));
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x00014518 File Offset: 0x00012718
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qcheck_setToolTip = QCheckBox.__N.QCheck_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qcheck_setToolTip);
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x00014548 File Offset: 0x00012748
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qcheck_statusTip = QCheckBox.__N.QCheck_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qcheck_statusTip));
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x00014578 File Offset: 0x00012778
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qcheck_setStatusTip = QCheckBox.__N.QCheck_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qcheck_setStatusTip);
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x000145A8 File Offset: 0x000127A8
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qcheck_toolTipDuration = QCheckBox.__N.QCheck_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_toolTipDuration);
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x000145D4 File Offset: 0x000127D4
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qcheck_setToolTipDuration = QCheckBox.__N.QCheck_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qcheck_setToolTipDuration);
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x00014600 File Offset: 0x00012800
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qcheck_autoFillBackground = QCheckBox.__N.QCheck_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qcheck_autoFillBackground) > 0;
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x00014630 File Offset: 0x00012830
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qcheck_setAutoFillBackground = QCheckBox.__N.QCheck_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qcheck_setAutoFillBackground);
		}

		// Token: 0x0400004E RID: 78
		internal IntPtr self;

		// Token: 0x0200010F RID: 271
		internal static class __N
		{
			// Token: 0x040009A7 RID: 2471
			internal static method From_QAbstractButton_To_QCheckBox;

			// Token: 0x040009A8 RID: 2472
			internal static method To_QAbstractButton_From_QCheckBox;

			// Token: 0x040009A9 RID: 2473
			internal static method From_QWidget_To_QCheckBox;

			// Token: 0x040009AA RID: 2474
			internal static method To_QWidget_From_QCheckBox;

			// Token: 0x040009AB RID: 2475
			internal static method From_QObject_To_QCheckBox;

			// Token: 0x040009AC RID: 2476
			internal static method To_QObject_From_QCheckBox;

			// Token: 0x040009AD RID: 2477
			internal static method QCheck_setTristate;

			// Token: 0x040009AE RID: 2478
			internal static method QCheck_isTristate;

			// Token: 0x040009AF RID: 2479
			internal static method QCheck_checkState;

			// Token: 0x040009B0 RID: 2480
			internal static method QCheck_setCheckState;

			// Token: 0x040009B1 RID: 2481
			internal static method QCheck_setText;

			// Token: 0x040009B2 RID: 2482
			internal static method QCheck_text;

			// Token: 0x040009B3 RID: 2483
			internal static method QCheck_setIcon;

			// Token: 0x040009B4 RID: 2484
			internal static method QCheck_setCheckable;

			// Token: 0x040009B5 RID: 2485
			internal static method QCheck_isCheckable;

			// Token: 0x040009B6 RID: 2486
			internal static method QCheck_isChecked;

			// Token: 0x040009B7 RID: 2487
			internal static method QCheck_setDown;

			// Token: 0x040009B8 RID: 2488
			internal static method QCheck_isDown;

			// Token: 0x040009B9 RID: 2489
			internal static method QCheck_setIconSize;

			// Token: 0x040009BA RID: 2490
			internal static method QCheck_animateClick;

			// Token: 0x040009BB RID: 2491
			internal static method QCheck_click;

			// Token: 0x040009BC RID: 2492
			internal static method QCheck_toggle;

			// Token: 0x040009BD RID: 2493
			internal static method QCheck_setChecked;

			// Token: 0x040009BE RID: 2494
			internal static method QCheck_setAutoRepeat;

			// Token: 0x040009BF RID: 2495
			internal static method QCheck_autoRepeat;

			// Token: 0x040009C0 RID: 2496
			internal static method QCheck_setAutoRepeatDelay;

			// Token: 0x040009C1 RID: 2497
			internal static method QCheck_autoRepeatDelay;

			// Token: 0x040009C2 RID: 2498
			internal static method QCheck_setAutoRepeatInterval;

			// Token: 0x040009C3 RID: 2499
			internal static method QCheck_autoRepeatInterval;

			// Token: 0x040009C4 RID: 2500
			internal static method QCheck_setAutoExclusive;

			// Token: 0x040009C5 RID: 2501
			internal static method QCheck_autoExclusive;

			// Token: 0x040009C6 RID: 2502
			internal static method QCheck_isTopLevel;

			// Token: 0x040009C7 RID: 2503
			internal static method QCheck_isWindow;

			// Token: 0x040009C8 RID: 2504
			internal static method QCheck_isModal;

			// Token: 0x040009C9 RID: 2505
			internal static method QCheck_setStyleSheet;

			// Token: 0x040009CA RID: 2506
			internal static method QCheck_windowTitle;

			// Token: 0x040009CB RID: 2507
			internal static method QCheck_setWindowTitle;

			// Token: 0x040009CC RID: 2508
			internal static method QCheck_setWindowFlags;

			// Token: 0x040009CD RID: 2509
			internal static method QCheck_windowFlags;

			// Token: 0x040009CE RID: 2510
			internal static method QCheck_size;

			// Token: 0x040009CF RID: 2511
			internal static method QCheck_resize;

			// Token: 0x040009D0 RID: 2512
			internal static method QCheck_minimumSize;

			// Token: 0x040009D1 RID: 2513
			internal static method QCheck_setMinimumSize;

			// Token: 0x040009D2 RID: 2514
			internal static method QCheck_maximumSize;

			// Token: 0x040009D3 RID: 2515
			internal static method QCheck_setMaximumSize;

			// Token: 0x040009D4 RID: 2516
			internal static method QCheck_pos;

			// Token: 0x040009D5 RID: 2517
			internal static method QCheck_move;

			// Token: 0x040009D6 RID: 2518
			internal static method QCheck_isEnabled;

			// Token: 0x040009D7 RID: 2519
			internal static method QCheck_setEnabled;

			// Token: 0x040009D8 RID: 2520
			internal static method QCheck_setVisible;

			// Token: 0x040009D9 RID: 2521
			internal static method QCheck_setHidden;

			// Token: 0x040009DA RID: 2522
			internal static method QCheck_show;

			// Token: 0x040009DB RID: 2523
			internal static method QCheck_hide;

			// Token: 0x040009DC RID: 2524
			internal static method QCheck_showMinimized;

			// Token: 0x040009DD RID: 2525
			internal static method QCheck_showMaximized;

			// Token: 0x040009DE RID: 2526
			internal static method QCheck_showFullScreen;

			// Token: 0x040009DF RID: 2527
			internal static method QCheck_showNormal;

			// Token: 0x040009E0 RID: 2528
			internal static method QCheck_close;

			// Token: 0x040009E1 RID: 2529
			internal static method QCheck_raise;

			// Token: 0x040009E2 RID: 2530
			internal static method QCheck_lower;

			// Token: 0x040009E3 RID: 2531
			internal static method QCheck_isVisible;

			// Token: 0x040009E4 RID: 2532
			internal static method QCheck_setAttribute;

			// Token: 0x040009E5 RID: 2533
			internal static method QCheck_testAttribute;

			// Token: 0x040009E6 RID: 2534
			internal static method QCheck_acceptDrops;

			// Token: 0x040009E7 RID: 2535
			internal static method QCheck_setAcceptDrops;

			// Token: 0x040009E8 RID: 2536
			internal static method QCheck_update;

			// Token: 0x040009E9 RID: 2537
			internal static method QCheck_repaint;

			// Token: 0x040009EA RID: 2538
			internal static method QCheck_setCursor;

			// Token: 0x040009EB RID: 2539
			internal static method QCheck_unsetCursor;

			// Token: 0x040009EC RID: 2540
			internal static method QCheck_setWindowIcon;

			// Token: 0x040009ED RID: 2541
			internal static method QCheck_setWindowIconText;

			// Token: 0x040009EE RID: 2542
			internal static method QCheck_setWindowOpacity;

			// Token: 0x040009EF RID: 2543
			internal static method QCheck_windowOpacity;

			// Token: 0x040009F0 RID: 2544
			internal static method QCheck_isMinimized;

			// Token: 0x040009F1 RID: 2545
			internal static method QCheck_isMaximized;

			// Token: 0x040009F2 RID: 2546
			internal static method QCheck_isFullScreen;

			// Token: 0x040009F3 RID: 2547
			internal static method QCheck_setMouseTracking;

			// Token: 0x040009F4 RID: 2548
			internal static method QCheck_hasMouseTracking;

			// Token: 0x040009F5 RID: 2549
			internal static method QCheck_underMouse;

			// Token: 0x040009F6 RID: 2550
			internal static method QCheck_mapToGlobal;

			// Token: 0x040009F7 RID: 2551
			internal static method QCheck_mapFromGlobal;

			// Token: 0x040009F8 RID: 2552
			internal static method QCheck_hasFocus;

			// Token: 0x040009F9 RID: 2553
			internal static method QCheck_focusPolicy;

			// Token: 0x040009FA RID: 2554
			internal static method QCheck_setFocusPolicy;

			// Token: 0x040009FB RID: 2555
			internal static method QCheck_setFocusProxy;

			// Token: 0x040009FC RID: 2556
			internal static method QCheck_isActiveWindow;

			// Token: 0x040009FD RID: 2557
			internal static method QCheck_updatesEnabled;

			// Token: 0x040009FE RID: 2558
			internal static method QCheck_setUpdatesEnabled;

			// Token: 0x040009FF RID: 2559
			internal static method QCheck_setFocus;

			// Token: 0x04000A00 RID: 2560
			internal static method QCheck_activateWindow;

			// Token: 0x04000A01 RID: 2561
			internal static method QCheck_clearFocus;

			// Token: 0x04000A02 RID: 2562
			internal static method QCheck_setSizePolicy;

			// Token: 0x04000A03 RID: 2563
			internal static method QCheck_devicePixelRatioF;

			// Token: 0x04000A04 RID: 2564
			internal static method QCheck_saveGeometry;

			// Token: 0x04000A05 RID: 2565
			internal static method QCheck_restoreGeometry;

			// Token: 0x04000A06 RID: 2566
			internal static method QCheck_addAction;

			// Token: 0x04000A07 RID: 2567
			internal static method QCheck_removeAction;

			// Token: 0x04000A08 RID: 2568
			internal static method QCheck_setParent;

			// Token: 0x04000A09 RID: 2569
			internal static method QCheck_parentWidget;

			// Token: 0x04000A0A RID: 2570
			internal static method QCheck_AddClassName;

			// Token: 0x04000A0B RID: 2571
			internal static method QCheck_Polish;

			// Token: 0x04000A0C RID: 2572
			internal static method QCheck_toolTip;

			// Token: 0x04000A0D RID: 2573
			internal static method QCheck_setToolTip;

			// Token: 0x04000A0E RID: 2574
			internal static method QCheck_statusTip;

			// Token: 0x04000A0F RID: 2575
			internal static method QCheck_setStatusTip;

			// Token: 0x04000A10 RID: 2576
			internal static method QCheck_toolTipDuration;

			// Token: 0x04000A11 RID: 2577
			internal static method QCheck_setToolTipDuration;

			// Token: 0x04000A12 RID: 2578
			internal static method QCheck_autoFillBackground;

			// Token: 0x04000A13 RID: 2579
			internal static method QCheck_setAutoFillBackground;
		}
	}
}
