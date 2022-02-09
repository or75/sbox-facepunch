using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x0200003D RID: 61
	internal struct QAbstractButton
	{
		// Token: 0x06000612 RID: 1554 RVA: 0x00010B7E File Offset: 0x0000ED7E
		public static implicit operator IntPtr(QAbstractButton value)
		{
			return value.self;
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x00010B88 File Offset: 0x0000ED88
		public static implicit operator QAbstractButton(IntPtr value)
		{
			return new QAbstractButton
			{
				self = value
			};
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x00010BA6 File Offset: 0x0000EDA6
		public static bool operator ==(QAbstractButton c1, QAbstractButton c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x00010BB9 File Offset: 0x0000EDB9
		public static bool operator !=(QAbstractButton c1, QAbstractButton c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x00010BCC File Offset: 0x0000EDCC
		public override bool Equals(object obj)
		{
			if (obj is QAbstractButton)
			{
				QAbstractButton c = (QAbstractButton)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x00010BF6 File Offset: 0x0000EDF6
		internal QAbstractButton(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00010C00 File Offset: 0x0000EE00
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QAbstractButton ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000619 RID: 1561 RVA: 0x00010C3C File Offset: 0x0000EE3C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600061A RID: 1562 RVA: 0x00010C4E File Offset: 0x0000EE4E
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x00010C59 File Offset: 0x0000EE59
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x00010C6C File Offset: 0x0000EE6C
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QAbstractButton was null when calling " + n);
			}
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x00010C87 File Offset: 0x0000EE87
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x00010C94 File Offset: 0x0000EE94
		public static implicit operator QWidget(QAbstractButton value)
		{
			method to_QWidget_From_QAbstractButton = QAbstractButton.__N.To_QWidget_From_QAbstractButton;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QAbstractButton);
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00010CB8 File Offset: 0x0000EEB8
		public static explicit operator QAbstractButton(QWidget value)
		{
			method from_QWidget_To_QAbstractButton = QAbstractButton.__N.From_QWidget_To_QAbstractButton;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QAbstractButton);
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00010CDC File Offset: 0x0000EEDC
		public static implicit operator QObject(QAbstractButton value)
		{
			method to_QObject_From_QAbstractButton = QAbstractButton.__N.To_QObject_From_QAbstractButton;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QAbstractButton);
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00010D00 File Offset: 0x0000EF00
		public static explicit operator QAbstractButton(QObject value)
		{
			method from_QObject_To_QAbstractButton = QAbstractButton.__N.From_QObject_To_QAbstractButton;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QAbstractButton);
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00010D24 File Offset: 0x0000EF24
		internal readonly void setText(string text)
		{
			this.NullCheck("setText");
			method qabstr_setText = QAbstractButton.__N.QAbstr_setText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qabstr_setText);
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00010D54 File Offset: 0x0000EF54
		internal readonly string text()
		{
			this.NullCheck("text");
			method qabstr_text = QAbstractButton.__N.QAbstr_text;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qabstr_text));
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00010D84 File Offset: 0x0000EF84
		internal readonly void setIcon(string icon)
		{
			this.NullCheck("setIcon");
			method qabstr_setIcon = QAbstractButton.__N.QAbstr_setIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qabstr_setIcon);
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x00010DB4 File Offset: 0x0000EFB4
		internal readonly void setCheckable(bool b)
		{
			this.NullCheck("setCheckable");
			method qabstr_setCheckable = QAbstractButton.__N.QAbstr_setCheckable;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qabstr_setCheckable);
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x00010DE8 File Offset: 0x0000EFE8
		internal readonly bool isCheckable()
		{
			this.NullCheck("isCheckable");
			method qabstr_isCheckable = QAbstractButton.__N.QAbstr_isCheckable;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_isCheckable) > 0;
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x00010E18 File Offset: 0x0000F018
		internal readonly bool isChecked()
		{
			this.NullCheck("isChecked");
			method qabstr_isChecked = QAbstractButton.__N.QAbstr_isChecked;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_isChecked) > 0;
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x00010E48 File Offset: 0x0000F048
		internal readonly void setDown(bool b)
		{
			this.NullCheck("setDown");
			method qabstr_setDown = QAbstractButton.__N.QAbstr_setDown;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qabstr_setDown);
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x00010E7C File Offset: 0x0000F07C
		internal readonly bool isDown()
		{
			this.NullCheck("isDown");
			method qabstr_isDown = QAbstractButton.__N.QAbstr_isDown;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_isDown) > 0;
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x00010EAC File Offset: 0x0000F0AC
		internal readonly void setIconSize(Vector3 size)
		{
			this.NullCheck("setIconSize");
			method qabstr_setIconSize = QAbstractButton.__N.QAbstr_setIconSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, size, qabstr_setIconSize);
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x00010ED8 File Offset: 0x0000F0D8
		internal readonly void animateClick(int msec)
		{
			this.NullCheck("animateClick");
			method qabstr_animateClick = QAbstractButton.__N.QAbstr_animateClick;
			calli(System.Void(System.IntPtr,System.Int32), this.self, msec, qabstr_animateClick);
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x00010F04 File Offset: 0x0000F104
		internal readonly void click()
		{
			this.NullCheck("click");
			method qabstr_click = QAbstractButton.__N.QAbstr_click;
			calli(System.Void(System.IntPtr), this.self, qabstr_click);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x00010F30 File Offset: 0x0000F130
		internal readonly void toggle()
		{
			this.NullCheck("toggle");
			method qabstr_toggle = QAbstractButton.__N.QAbstr_toggle;
			calli(System.Void(System.IntPtr), this.self, qabstr_toggle);
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x00010F5C File Offset: 0x0000F15C
		internal readonly void setChecked(bool b)
		{
			this.NullCheck("setChecked");
			method qabstr_setChecked = QAbstractButton.__N.QAbstr_setChecked;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qabstr_setChecked);
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x00010F90 File Offset: 0x0000F190
		internal readonly void setAutoRepeat(bool x)
		{
			this.NullCheck("setAutoRepeat");
			method qabstr_setAutoRepeat = QAbstractButton.__N.QAbstr_setAutoRepeat;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qabstr_setAutoRepeat);
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x00010FC4 File Offset: 0x0000F1C4
		internal readonly bool autoRepeat()
		{
			this.NullCheck("autoRepeat");
			method qabstr_autoRepeat = QAbstractButton.__N.QAbstr_autoRepeat;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_autoRepeat) > 0;
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x00010FF4 File Offset: 0x0000F1F4
		internal readonly void setAutoRepeatDelay(int x)
		{
			this.NullCheck("setAutoRepeatDelay");
			method qabstr_setAutoRepeatDelay = QAbstractButton.__N.QAbstr_setAutoRepeatDelay;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qabstr_setAutoRepeatDelay);
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00011020 File Offset: 0x0000F220
		internal readonly int autoRepeatDelay()
		{
			this.NullCheck("autoRepeatDelay");
			method qabstr_autoRepeatDelay = QAbstractButton.__N.QAbstr_autoRepeatDelay;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_autoRepeatDelay);
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0001104C File Offset: 0x0000F24C
		internal readonly void setAutoRepeatInterval(int x)
		{
			this.NullCheck("setAutoRepeatInterval");
			method qabstr_setAutoRepeatInterval = QAbstractButton.__N.QAbstr_setAutoRepeatInterval;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qabstr_setAutoRepeatInterval);
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00011078 File Offset: 0x0000F278
		internal readonly int autoRepeatInterval()
		{
			this.NullCheck("autoRepeatInterval");
			method qabstr_autoRepeatInterval = QAbstractButton.__N.QAbstr_autoRepeatInterval;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_autoRepeatInterval);
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x000110A4 File Offset: 0x0000F2A4
		internal readonly void setAutoExclusive(bool x)
		{
			this.NullCheck("setAutoExclusive");
			method qabstr_setAutoExclusive = QAbstractButton.__N.QAbstr_setAutoExclusive;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qabstr_setAutoExclusive);
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x000110D8 File Offset: 0x0000F2D8
		internal readonly bool autoExclusive()
		{
			this.NullCheck("autoExclusive");
			method qabstr_autoExclusive = QAbstractButton.__N.QAbstr_autoExclusive;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_autoExclusive) > 0;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x00011108 File Offset: 0x0000F308
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qabstr_isTopLevel = QAbstractButton.__N.QAbstr_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_isTopLevel) > 0;
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x00011138 File Offset: 0x0000F338
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qabstr_isWindow = QAbstractButton.__N.QAbstr_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_isWindow) > 0;
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x00011168 File Offset: 0x0000F368
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qabstr_isModal = QAbstractButton.__N.QAbstr_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_isModal) > 0;
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x00011198 File Offset: 0x0000F398
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qabstr_setStyleSheet = QAbstractButton.__N.QAbstr_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qabstr_setStyleSheet);
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x000111C8 File Offset: 0x0000F3C8
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qabstr_windowTitle = QAbstractButton.__N.QAbstr_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qabstr_windowTitle));
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x000111F8 File Offset: 0x0000F3F8
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qabstr_setWindowTitle = QAbstractButton.__N.QAbstr_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qabstr_setWindowTitle);
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x00011228 File Offset: 0x0000F428
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qabstr_setWindowFlags = QAbstractButton.__N.QAbstr_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qabstr_setWindowFlags);
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x00011254 File Offset: 0x0000F454
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qabstr_windowFlags = QAbstractButton.__N.QAbstr_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qabstr_windowFlags);
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x00011280 File Offset: 0x0000F480
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qabstr_size = QAbstractButton.__N.QAbstr_size;
			return calli(Vector3(System.IntPtr), this.self, qabstr_size);
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x000112AC File Offset: 0x0000F4AC
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qabstr_resize = QAbstractButton.__N.QAbstr_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qabstr_resize);
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x000112D8 File Offset: 0x0000F4D8
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qabstr_minimumSize = QAbstractButton.__N.QAbstr_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qabstr_minimumSize);
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x00011304 File Offset: 0x0000F504
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qabstr_setMinimumSize = QAbstractButton.__N.QAbstr_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qabstr_setMinimumSize);
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x00011330 File Offset: 0x0000F530
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qabstr_maximumSize = QAbstractButton.__N.QAbstr_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qabstr_maximumSize);
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0001135C File Offset: 0x0000F55C
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qabstr_setMaximumSize = QAbstractButton.__N.QAbstr_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qabstr_setMaximumSize);
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x00011388 File Offset: 0x0000F588
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qabstr_pos = QAbstractButton.__N.QAbstr_pos;
			return calli(Vector3(System.IntPtr), this.self, qabstr_pos);
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x000113B4 File Offset: 0x0000F5B4
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qabstr_move = QAbstractButton.__N.QAbstr_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qabstr_move);
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x000113E0 File Offset: 0x0000F5E0
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qabstr_isEnabled = QAbstractButton.__N.QAbstr_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_isEnabled) > 0;
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x00011410 File Offset: 0x0000F610
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qabstr_setEnabled = QAbstractButton.__N.QAbstr_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qabstr_setEnabled);
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x00011444 File Offset: 0x0000F644
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qabstr_setVisible = QAbstractButton.__N.QAbstr_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qabstr_setVisible);
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x00011478 File Offset: 0x0000F678
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qabstr_setHidden = QAbstractButton.__N.QAbstr_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qabstr_setHidden);
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x000114AC File Offset: 0x0000F6AC
		internal readonly void show()
		{
			this.NullCheck("show");
			method qabstr_show = QAbstractButton.__N.QAbstr_show;
			calli(System.Void(System.IntPtr), this.self, qabstr_show);
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x000114D8 File Offset: 0x0000F6D8
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qabstr_hide = QAbstractButton.__N.QAbstr_hide;
			calli(System.Void(System.IntPtr), this.self, qabstr_hide);
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x00011504 File Offset: 0x0000F704
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qabstr_showMinimized = QAbstractButton.__N.QAbstr_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qabstr_showMinimized);
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x00011530 File Offset: 0x0000F730
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qabstr_showMaximized = QAbstractButton.__N.QAbstr_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qabstr_showMaximized);
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0001155C File Offset: 0x0000F75C
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qabstr_showFullScreen = QAbstractButton.__N.QAbstr_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qabstr_showFullScreen);
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x00011588 File Offset: 0x0000F788
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qabstr_showNormal = QAbstractButton.__N.QAbstr_showNormal;
			calli(System.Void(System.IntPtr), this.self, qabstr_showNormal);
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x000115B4 File Offset: 0x0000F7B4
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qabstr_close = QAbstractButton.__N.QAbstr_close;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_close) > 0;
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x000115E4 File Offset: 0x0000F7E4
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qabstr_raise = QAbstractButton.__N.QAbstr_raise;
			calli(System.Void(System.IntPtr), this.self, qabstr_raise);
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x00011610 File Offset: 0x0000F810
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qabstr_lower = QAbstractButton.__N.QAbstr_lower;
			calli(System.Void(System.IntPtr), this.self, qabstr_lower);
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x0001163C File Offset: 0x0000F83C
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qabstr_isVisible = QAbstractButton.__N.QAbstr_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_isVisible) > 0;
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0001166C File Offset: 0x0000F86C
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qabstr_setAttribute = QAbstractButton.__N.QAbstr_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qabstr_setAttribute);
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x000116A0 File Offset: 0x0000F8A0
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qabstr_testAttribute = QAbstractButton.__N.QAbstr_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qabstr_testAttribute) > 0;
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x000116D0 File Offset: 0x0000F8D0
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qabstr_acceptDrops = QAbstractButton.__N.QAbstr_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_acceptDrops) > 0;
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x00011700 File Offset: 0x0000F900
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qabstr_setAcceptDrops = QAbstractButton.__N.QAbstr_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qabstr_setAcceptDrops);
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x00011734 File Offset: 0x0000F934
		internal readonly void update()
		{
			this.NullCheck("update");
			method qabstr_update = QAbstractButton.__N.QAbstr_update;
			calli(System.Void(System.IntPtr), this.self, qabstr_update);
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x00011760 File Offset: 0x0000F960
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qabstr_repaint = QAbstractButton.__N.QAbstr_repaint;
			calli(System.Void(System.IntPtr), this.self, qabstr_repaint);
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0001178C File Offset: 0x0000F98C
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qabstr_setCursor = QAbstractButton.__N.QAbstr_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qabstr_setCursor);
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x000117B8 File Offset: 0x0000F9B8
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qabstr_unsetCursor = QAbstractButton.__N.QAbstr_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qabstr_unsetCursor);
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x000117E4 File Offset: 0x0000F9E4
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qabstr_setWindowIcon = QAbstractButton.__N.QAbstr_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qabstr_setWindowIcon);
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x00011814 File Offset: 0x0000FA14
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qabstr_setWindowIconText = QAbstractButton.__N.QAbstr_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qabstr_setWindowIconText);
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x00011844 File Offset: 0x0000FA44
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qabstr_setWindowOpacity = QAbstractButton.__N.QAbstr_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qabstr_setWindowOpacity);
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x00011870 File Offset: 0x0000FA70
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qabstr_windowOpacity = QAbstractButton.__N.QAbstr_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qabstr_windowOpacity);
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0001189C File Offset: 0x0000FA9C
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qabstr_isMinimized = QAbstractButton.__N.QAbstr_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_isMinimized) > 0;
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x000118CC File Offset: 0x0000FACC
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qabstr_isMaximized = QAbstractButton.__N.QAbstr_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_isMaximized) > 0;
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x000118FC File Offset: 0x0000FAFC
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qabstr_isFullScreen = QAbstractButton.__N.QAbstr_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_isFullScreen) > 0;
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x0001192C File Offset: 0x0000FB2C
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qabstr_setMouseTracking = QAbstractButton.__N.QAbstr_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qabstr_setMouseTracking);
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x00011960 File Offset: 0x0000FB60
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qabstr_hasMouseTracking = QAbstractButton.__N.QAbstr_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_hasMouseTracking) > 0;
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x00011990 File Offset: 0x0000FB90
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qabstr_underMouse = QAbstractButton.__N.QAbstr_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_underMouse) > 0;
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x000119C0 File Offset: 0x0000FBC0
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qabstr_mapToGlobal = QAbstractButton.__N.QAbstr_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qabstr_mapToGlobal);
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x000119EC File Offset: 0x0000FBEC
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qabstr_mapFromGlobal = QAbstractButton.__N.QAbstr_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qabstr_mapFromGlobal);
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x00011A18 File Offset: 0x0000FC18
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qabstr_hasFocus = QAbstractButton.__N.QAbstr_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_hasFocus) > 0;
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x00011A48 File Offset: 0x0000FC48
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qabstr_focusPolicy = QAbstractButton.__N.QAbstr_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qabstr_focusPolicy);
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x00011A74 File Offset: 0x0000FC74
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qabstr_setFocusPolicy = QAbstractButton.__N.QAbstr_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qabstr_setFocusPolicy);
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x00011AA0 File Offset: 0x0000FCA0
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qabstr_setFocusProxy = QAbstractButton.__N.QAbstr_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qabstr_setFocusProxy);
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x00011AD0 File Offset: 0x0000FCD0
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qabstr_isActiveWindow = QAbstractButton.__N.QAbstr_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_isActiveWindow) > 0;
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x00011B00 File Offset: 0x0000FD00
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qabstr_updatesEnabled = QAbstractButton.__N.QAbstr_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_updatesEnabled) > 0;
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x00011B30 File Offset: 0x0000FD30
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qabstr_setUpdatesEnabled = QAbstractButton.__N.QAbstr_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qabstr_setUpdatesEnabled);
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x00011B64 File Offset: 0x0000FD64
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qabstr_setFocus = QAbstractButton.__N.QAbstr_setFocus;
			calli(System.Void(System.IntPtr), this.self, qabstr_setFocus);
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x00011B90 File Offset: 0x0000FD90
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qabstr_activateWindow = QAbstractButton.__N.QAbstr_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qabstr_activateWindow);
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x00011BBC File Offset: 0x0000FDBC
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qabstr_clearFocus = QAbstractButton.__N.QAbstr_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qabstr_clearFocus);
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x00011BE8 File Offset: 0x0000FDE8
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qabstr_setSizePolicy = QAbstractButton.__N.QAbstr_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qabstr_setSizePolicy);
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x00011C18 File Offset: 0x0000FE18
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qabstr_devicePixelRatioF = QAbstractButton.__N.QAbstr_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qabstr_devicePixelRatioF);
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x00011C44 File Offset: 0x0000FE44
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qabstr_saveGeometry = QAbstractButton.__N.QAbstr_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qabstr_saveGeometry));
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x00011C74 File Offset: 0x0000FE74
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qabstr_restoreGeometry = QAbstractButton.__N.QAbstr_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qabstr_restoreGeometry) > 0;
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x00011CA8 File Offset: 0x0000FEA8
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qabstr_addAction = QAbstractButton.__N.QAbstr_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qabstr_addAction);
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x00011CD8 File Offset: 0x0000FED8
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qabstr_removeAction = QAbstractButton.__N.QAbstr_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qabstr_removeAction);
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x00011D08 File Offset: 0x0000FF08
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qabstr_setParent = QAbstractButton.__N.QAbstr_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qabstr_setParent);
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x00011D38 File Offset: 0x0000FF38
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qabstr_parentWidget = QAbstractButton.__N.QAbstr_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qabstr_parentWidget);
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x00011D68 File Offset: 0x0000FF68
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qabstr_AddClassName = QAbstractButton.__N.QAbstr_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qabstr_AddClassName);
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x00011D98 File Offset: 0x0000FF98
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qabstr_Polish = QAbstractButton.__N.QAbstr_Polish;
			calli(System.Void(System.IntPtr), this.self, qabstr_Polish);
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x00011DC4 File Offset: 0x0000FFC4
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qabstr_toolTip = QAbstractButton.__N.QAbstr_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qabstr_toolTip));
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00011DF4 File Offset: 0x0000FFF4
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qabstr_setToolTip = QAbstractButton.__N.QAbstr_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qabstr_setToolTip);
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00011E24 File Offset: 0x00010024
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qabstr_statusTip = QAbstractButton.__N.QAbstr_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qabstr_statusTip));
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x00011E54 File Offset: 0x00010054
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qabstr_setStatusTip = QAbstractButton.__N.QAbstr_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qabstr_setStatusTip);
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x00011E84 File Offset: 0x00010084
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qabstr_toolTipDuration = QAbstractButton.__N.QAbstr_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_toolTipDuration);
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00011EB0 File Offset: 0x000100B0
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qabstr_setToolTipDuration = QAbstractButton.__N.QAbstr_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qabstr_setToolTipDuration);
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x00011EDC File Offset: 0x000100DC
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qabstr_autoFillBackground = QAbstractButton.__N.QAbstr_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qabstr_autoFillBackground) > 0;
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x00011F0C File Offset: 0x0001010C
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qabstr_setAutoFillBackground = QAbstractButton.__N.QAbstr_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qabstr_setAutoFillBackground);
		}

		// Token: 0x04000049 RID: 73
		internal IntPtr self;

		// Token: 0x02000109 RID: 265
		internal static class __N
		{
			// Token: 0x040008F0 RID: 2288
			internal static method From_QWidget_To_QAbstractButton;

			// Token: 0x040008F1 RID: 2289
			internal static method To_QWidget_From_QAbstractButton;

			// Token: 0x040008F2 RID: 2290
			internal static method From_QObject_To_QAbstractButton;

			// Token: 0x040008F3 RID: 2291
			internal static method To_QObject_From_QAbstractButton;

			// Token: 0x040008F4 RID: 2292
			internal static method QAbstr_setText;

			// Token: 0x040008F5 RID: 2293
			internal static method QAbstr_text;

			// Token: 0x040008F6 RID: 2294
			internal static method QAbstr_setIcon;

			// Token: 0x040008F7 RID: 2295
			internal static method QAbstr_setCheckable;

			// Token: 0x040008F8 RID: 2296
			internal static method QAbstr_isCheckable;

			// Token: 0x040008F9 RID: 2297
			internal static method QAbstr_isChecked;

			// Token: 0x040008FA RID: 2298
			internal static method QAbstr_setDown;

			// Token: 0x040008FB RID: 2299
			internal static method QAbstr_isDown;

			// Token: 0x040008FC RID: 2300
			internal static method QAbstr_setIconSize;

			// Token: 0x040008FD RID: 2301
			internal static method QAbstr_animateClick;

			// Token: 0x040008FE RID: 2302
			internal static method QAbstr_click;

			// Token: 0x040008FF RID: 2303
			internal static method QAbstr_toggle;

			// Token: 0x04000900 RID: 2304
			internal static method QAbstr_setChecked;

			// Token: 0x04000901 RID: 2305
			internal static method QAbstr_setAutoRepeat;

			// Token: 0x04000902 RID: 2306
			internal static method QAbstr_autoRepeat;

			// Token: 0x04000903 RID: 2307
			internal static method QAbstr_setAutoRepeatDelay;

			// Token: 0x04000904 RID: 2308
			internal static method QAbstr_autoRepeatDelay;

			// Token: 0x04000905 RID: 2309
			internal static method QAbstr_setAutoRepeatInterval;

			// Token: 0x04000906 RID: 2310
			internal static method QAbstr_autoRepeatInterval;

			// Token: 0x04000907 RID: 2311
			internal static method QAbstr_setAutoExclusive;

			// Token: 0x04000908 RID: 2312
			internal static method QAbstr_autoExclusive;

			// Token: 0x04000909 RID: 2313
			internal static method QAbstr_isTopLevel;

			// Token: 0x0400090A RID: 2314
			internal static method QAbstr_isWindow;

			// Token: 0x0400090B RID: 2315
			internal static method QAbstr_isModal;

			// Token: 0x0400090C RID: 2316
			internal static method QAbstr_setStyleSheet;

			// Token: 0x0400090D RID: 2317
			internal static method QAbstr_windowTitle;

			// Token: 0x0400090E RID: 2318
			internal static method QAbstr_setWindowTitle;

			// Token: 0x0400090F RID: 2319
			internal static method QAbstr_setWindowFlags;

			// Token: 0x04000910 RID: 2320
			internal static method QAbstr_windowFlags;

			// Token: 0x04000911 RID: 2321
			internal static method QAbstr_size;

			// Token: 0x04000912 RID: 2322
			internal static method QAbstr_resize;

			// Token: 0x04000913 RID: 2323
			internal static method QAbstr_minimumSize;

			// Token: 0x04000914 RID: 2324
			internal static method QAbstr_setMinimumSize;

			// Token: 0x04000915 RID: 2325
			internal static method QAbstr_maximumSize;

			// Token: 0x04000916 RID: 2326
			internal static method QAbstr_setMaximumSize;

			// Token: 0x04000917 RID: 2327
			internal static method QAbstr_pos;

			// Token: 0x04000918 RID: 2328
			internal static method QAbstr_move;

			// Token: 0x04000919 RID: 2329
			internal static method QAbstr_isEnabled;

			// Token: 0x0400091A RID: 2330
			internal static method QAbstr_setEnabled;

			// Token: 0x0400091B RID: 2331
			internal static method QAbstr_setVisible;

			// Token: 0x0400091C RID: 2332
			internal static method QAbstr_setHidden;

			// Token: 0x0400091D RID: 2333
			internal static method QAbstr_show;

			// Token: 0x0400091E RID: 2334
			internal static method QAbstr_hide;

			// Token: 0x0400091F RID: 2335
			internal static method QAbstr_showMinimized;

			// Token: 0x04000920 RID: 2336
			internal static method QAbstr_showMaximized;

			// Token: 0x04000921 RID: 2337
			internal static method QAbstr_showFullScreen;

			// Token: 0x04000922 RID: 2338
			internal static method QAbstr_showNormal;

			// Token: 0x04000923 RID: 2339
			internal static method QAbstr_close;

			// Token: 0x04000924 RID: 2340
			internal static method QAbstr_raise;

			// Token: 0x04000925 RID: 2341
			internal static method QAbstr_lower;

			// Token: 0x04000926 RID: 2342
			internal static method QAbstr_isVisible;

			// Token: 0x04000927 RID: 2343
			internal static method QAbstr_setAttribute;

			// Token: 0x04000928 RID: 2344
			internal static method QAbstr_testAttribute;

			// Token: 0x04000929 RID: 2345
			internal static method QAbstr_acceptDrops;

			// Token: 0x0400092A RID: 2346
			internal static method QAbstr_setAcceptDrops;

			// Token: 0x0400092B RID: 2347
			internal static method QAbstr_update;

			// Token: 0x0400092C RID: 2348
			internal static method QAbstr_repaint;

			// Token: 0x0400092D RID: 2349
			internal static method QAbstr_setCursor;

			// Token: 0x0400092E RID: 2350
			internal static method QAbstr_unsetCursor;

			// Token: 0x0400092F RID: 2351
			internal static method QAbstr_setWindowIcon;

			// Token: 0x04000930 RID: 2352
			internal static method QAbstr_setWindowIconText;

			// Token: 0x04000931 RID: 2353
			internal static method QAbstr_setWindowOpacity;

			// Token: 0x04000932 RID: 2354
			internal static method QAbstr_windowOpacity;

			// Token: 0x04000933 RID: 2355
			internal static method QAbstr_isMinimized;

			// Token: 0x04000934 RID: 2356
			internal static method QAbstr_isMaximized;

			// Token: 0x04000935 RID: 2357
			internal static method QAbstr_isFullScreen;

			// Token: 0x04000936 RID: 2358
			internal static method QAbstr_setMouseTracking;

			// Token: 0x04000937 RID: 2359
			internal static method QAbstr_hasMouseTracking;

			// Token: 0x04000938 RID: 2360
			internal static method QAbstr_underMouse;

			// Token: 0x04000939 RID: 2361
			internal static method QAbstr_mapToGlobal;

			// Token: 0x0400093A RID: 2362
			internal static method QAbstr_mapFromGlobal;

			// Token: 0x0400093B RID: 2363
			internal static method QAbstr_hasFocus;

			// Token: 0x0400093C RID: 2364
			internal static method QAbstr_focusPolicy;

			// Token: 0x0400093D RID: 2365
			internal static method QAbstr_setFocusPolicy;

			// Token: 0x0400093E RID: 2366
			internal static method QAbstr_setFocusProxy;

			// Token: 0x0400093F RID: 2367
			internal static method QAbstr_isActiveWindow;

			// Token: 0x04000940 RID: 2368
			internal static method QAbstr_updatesEnabled;

			// Token: 0x04000941 RID: 2369
			internal static method QAbstr_setUpdatesEnabled;

			// Token: 0x04000942 RID: 2370
			internal static method QAbstr_setFocus;

			// Token: 0x04000943 RID: 2371
			internal static method QAbstr_activateWindow;

			// Token: 0x04000944 RID: 2372
			internal static method QAbstr_clearFocus;

			// Token: 0x04000945 RID: 2373
			internal static method QAbstr_setSizePolicy;

			// Token: 0x04000946 RID: 2374
			internal static method QAbstr_devicePixelRatioF;

			// Token: 0x04000947 RID: 2375
			internal static method QAbstr_saveGeometry;

			// Token: 0x04000948 RID: 2376
			internal static method QAbstr_restoreGeometry;

			// Token: 0x04000949 RID: 2377
			internal static method QAbstr_addAction;

			// Token: 0x0400094A RID: 2378
			internal static method QAbstr_removeAction;

			// Token: 0x0400094B RID: 2379
			internal static method QAbstr_setParent;

			// Token: 0x0400094C RID: 2380
			internal static method QAbstr_parentWidget;

			// Token: 0x0400094D RID: 2381
			internal static method QAbstr_AddClassName;

			// Token: 0x0400094E RID: 2382
			internal static method QAbstr_Polish;

			// Token: 0x0400094F RID: 2383
			internal static method QAbstr_toolTip;

			// Token: 0x04000950 RID: 2384
			internal static method QAbstr_setToolTip;

			// Token: 0x04000951 RID: 2385
			internal static method QAbstr_statusTip;

			// Token: 0x04000952 RID: 2386
			internal static method QAbstr_setStatusTip;

			// Token: 0x04000953 RID: 2387
			internal static method QAbstr_toolTipDuration;

			// Token: 0x04000954 RID: 2388
			internal static method QAbstr_setToolTipDuration;

			// Token: 0x04000955 RID: 2389
			internal static method QAbstr_autoFillBackground;

			// Token: 0x04000956 RID: 2390
			internal static method QAbstr_setAutoFillBackground;
		}
	}
}
