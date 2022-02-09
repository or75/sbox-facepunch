using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000057 RID: 87
	internal struct QPushButton
	{
		// Token: 0x06000D82 RID: 3458 RVA: 0x000247D5 File Offset: 0x000229D5
		public static implicit operator IntPtr(QPushButton value)
		{
			return value.self;
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x000247E0 File Offset: 0x000229E0
		public static implicit operator QPushButton(IntPtr value)
		{
			return new QPushButton
			{
				self = value
			};
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x000247FE File Offset: 0x000229FE
		public static bool operator ==(QPushButton c1, QPushButton c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x00024811 File Offset: 0x00022A11
		public static bool operator !=(QPushButton c1, QPushButton c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x00024824 File Offset: 0x00022A24
		public override bool Equals(object obj)
		{
			if (obj is QPushButton)
			{
				QPushButton c = (QPushButton)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x0002484E File Offset: 0x00022A4E
		internal QPushButton(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x00024858 File Offset: 0x00022A58
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QPushButton ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000D89 RID: 3465 RVA: 0x00024894 File Offset: 0x00022A94
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000D8A RID: 3466 RVA: 0x000248A6 File Offset: 0x00022AA6
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000D8B RID: 3467 RVA: 0x000248B1 File Offset: 0x00022AB1
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000D8C RID: 3468 RVA: 0x000248C4 File Offset: 0x00022AC4
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QPushButton was null when calling " + n);
			}
		}

		// Token: 0x06000D8D RID: 3469 RVA: 0x000248DF File Offset: 0x00022ADF
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x000248EC File Offset: 0x00022AEC
		public static implicit operator QAbstractButton(QPushButton value)
		{
			method to_QAbstractButton_From_QPushButton = QPushButton.__N.To_QAbstractButton_From_QPushButton;
			return calli(System.IntPtr(System.IntPtr), value, to_QAbstractButton_From_QPushButton);
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x00024910 File Offset: 0x00022B10
		public static explicit operator QPushButton(QAbstractButton value)
		{
			method from_QAbstractButton_To_QPushButton = QPushButton.__N.From_QAbstractButton_To_QPushButton;
			return calli(System.IntPtr(System.IntPtr), value, from_QAbstractButton_To_QPushButton);
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x00024934 File Offset: 0x00022B34
		public static implicit operator QWidget(QPushButton value)
		{
			method to_QWidget_From_QPushButton = QPushButton.__N.To_QWidget_From_QPushButton;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QPushButton);
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x00024958 File Offset: 0x00022B58
		public static explicit operator QPushButton(QWidget value)
		{
			method from_QWidget_To_QPushButton = QPushButton.__N.From_QWidget_To_QPushButton;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QPushButton);
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x0002497C File Offset: 0x00022B7C
		public static implicit operator QObject(QPushButton value)
		{
			method to_QObject_From_QPushButton = QPushButton.__N.To_QObject_From_QPushButton;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QPushButton);
		}

		// Token: 0x06000D93 RID: 3475 RVA: 0x000249A0 File Offset: 0x00022BA0
		public static explicit operator QPushButton(QObject value)
		{
			method from_QObject_To_QPushButton = QPushButton.__N.From_QObject_To_QPushButton;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QPushButton);
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x000249C4 File Offset: 0x00022BC4
		internal readonly void setText(string text)
		{
			this.NullCheck("setText");
			method qpshBt_setText = QPushButton.__N.QPshBt_setText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qpshBt_setText);
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x000249F4 File Offset: 0x00022BF4
		internal readonly string text()
		{
			this.NullCheck("text");
			method qpshBt_text = QPushButton.__N.QPshBt_text;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qpshBt_text));
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x00024A24 File Offset: 0x00022C24
		internal readonly void setIcon(string icon)
		{
			this.NullCheck("setIcon");
			method qpshBt_setIcon = QPushButton.__N.QPshBt_setIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qpshBt_setIcon);
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x00024A54 File Offset: 0x00022C54
		internal readonly void setCheckable(bool b)
		{
			this.NullCheck("setCheckable");
			method qpshBt_setCheckable = QPushButton.__N.QPshBt_setCheckable;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qpshBt_setCheckable);
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x00024A88 File Offset: 0x00022C88
		internal readonly bool isCheckable()
		{
			this.NullCheck("isCheckable");
			method qpshBt_isCheckable = QPushButton.__N.QPshBt_isCheckable;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_isCheckable) > 0;
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x00024AB8 File Offset: 0x00022CB8
		internal readonly bool isChecked()
		{
			this.NullCheck("isChecked");
			method qpshBt_isChecked = QPushButton.__N.QPshBt_isChecked;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_isChecked) > 0;
		}

		// Token: 0x06000D9A RID: 3482 RVA: 0x00024AE8 File Offset: 0x00022CE8
		internal readonly void setDown(bool b)
		{
			this.NullCheck("setDown");
			method qpshBt_setDown = QPushButton.__N.QPshBt_setDown;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qpshBt_setDown);
		}

		// Token: 0x06000D9B RID: 3483 RVA: 0x00024B1C File Offset: 0x00022D1C
		internal readonly bool isDown()
		{
			this.NullCheck("isDown");
			method qpshBt_isDown = QPushButton.__N.QPshBt_isDown;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_isDown) > 0;
		}

		// Token: 0x06000D9C RID: 3484 RVA: 0x00024B4C File Offset: 0x00022D4C
		internal readonly void setIconSize(Vector3 size)
		{
			this.NullCheck("setIconSize");
			method qpshBt_setIconSize = QPushButton.__N.QPshBt_setIconSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, size, qpshBt_setIconSize);
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x00024B78 File Offset: 0x00022D78
		internal readonly void animateClick(int msec)
		{
			this.NullCheck("animateClick");
			method qpshBt_animateClick = QPushButton.__N.QPshBt_animateClick;
			calli(System.Void(System.IntPtr,System.Int32), this.self, msec, qpshBt_animateClick);
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x00024BA4 File Offset: 0x00022DA4
		internal readonly void click()
		{
			this.NullCheck("click");
			method qpshBt_click = QPushButton.__N.QPshBt_click;
			calli(System.Void(System.IntPtr), this.self, qpshBt_click);
		}

		// Token: 0x06000D9F RID: 3487 RVA: 0x00024BD0 File Offset: 0x00022DD0
		internal readonly void toggle()
		{
			this.NullCheck("toggle");
			method qpshBt_toggle = QPushButton.__N.QPshBt_toggle;
			calli(System.Void(System.IntPtr), this.self, qpshBt_toggle);
		}

		// Token: 0x06000DA0 RID: 3488 RVA: 0x00024BFC File Offset: 0x00022DFC
		internal readonly void setChecked(bool b)
		{
			this.NullCheck("setChecked");
			method qpshBt_setChecked = QPushButton.__N.QPshBt_setChecked;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qpshBt_setChecked);
		}

		// Token: 0x06000DA1 RID: 3489 RVA: 0x00024C30 File Offset: 0x00022E30
		internal readonly void setAutoRepeat(bool x)
		{
			this.NullCheck("setAutoRepeat");
			method qpshBt_setAutoRepeat = QPushButton.__N.QPshBt_setAutoRepeat;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qpshBt_setAutoRepeat);
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x00024C64 File Offset: 0x00022E64
		internal readonly bool autoRepeat()
		{
			this.NullCheck("autoRepeat");
			method qpshBt_autoRepeat = QPushButton.__N.QPshBt_autoRepeat;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_autoRepeat) > 0;
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x00024C94 File Offset: 0x00022E94
		internal readonly void setAutoRepeatDelay(int x)
		{
			this.NullCheck("setAutoRepeatDelay");
			method qpshBt_setAutoRepeatDelay = QPushButton.__N.QPshBt_setAutoRepeatDelay;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qpshBt_setAutoRepeatDelay);
		}

		// Token: 0x06000DA4 RID: 3492 RVA: 0x00024CC0 File Offset: 0x00022EC0
		internal readonly int autoRepeatDelay()
		{
			this.NullCheck("autoRepeatDelay");
			method qpshBt_autoRepeatDelay = QPushButton.__N.QPshBt_autoRepeatDelay;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_autoRepeatDelay);
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x00024CEC File Offset: 0x00022EEC
		internal readonly void setAutoRepeatInterval(int x)
		{
			this.NullCheck("setAutoRepeatInterval");
			method qpshBt_setAutoRepeatInterval = QPushButton.__N.QPshBt_setAutoRepeatInterval;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qpshBt_setAutoRepeatInterval);
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x00024D18 File Offset: 0x00022F18
		internal readonly int autoRepeatInterval()
		{
			this.NullCheck("autoRepeatInterval");
			method qpshBt_autoRepeatInterval = QPushButton.__N.QPshBt_autoRepeatInterval;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_autoRepeatInterval);
		}

		// Token: 0x06000DA7 RID: 3495 RVA: 0x00024D44 File Offset: 0x00022F44
		internal readonly void setAutoExclusive(bool x)
		{
			this.NullCheck("setAutoExclusive");
			method qpshBt_setAutoExclusive = QPushButton.__N.QPshBt_setAutoExclusive;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qpshBt_setAutoExclusive);
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x00024D78 File Offset: 0x00022F78
		internal readonly bool autoExclusive()
		{
			this.NullCheck("autoExclusive");
			method qpshBt_autoExclusive = QPushButton.__N.QPshBt_autoExclusive;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_autoExclusive) > 0;
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x00024DA8 File Offset: 0x00022FA8
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qpshBt_isTopLevel = QPushButton.__N.QPshBt_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_isTopLevel) > 0;
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x00024DD8 File Offset: 0x00022FD8
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qpshBt_isWindow = QPushButton.__N.QPshBt_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_isWindow) > 0;
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x00024E08 File Offset: 0x00023008
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qpshBt_isModal = QPushButton.__N.QPshBt_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_isModal) > 0;
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x00024E38 File Offset: 0x00023038
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qpshBt_setStyleSheet = QPushButton.__N.QPshBt_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qpshBt_setStyleSheet);
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x00024E68 File Offset: 0x00023068
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qpshBt_windowTitle = QPushButton.__N.QPshBt_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qpshBt_windowTitle));
		}

		// Token: 0x06000DAE RID: 3502 RVA: 0x00024E98 File Offset: 0x00023098
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qpshBt_setWindowTitle = QPushButton.__N.QPshBt_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qpshBt_setWindowTitle);
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x00024EC8 File Offset: 0x000230C8
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qpshBt_setWindowFlags = QPushButton.__N.QPshBt_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qpshBt_setWindowFlags);
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x00024EF4 File Offset: 0x000230F4
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qpshBt_windowFlags = QPushButton.__N.QPshBt_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qpshBt_windowFlags);
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x00024F20 File Offset: 0x00023120
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qpshBt_size = QPushButton.__N.QPshBt_size;
			return calli(Vector3(System.IntPtr), this.self, qpshBt_size);
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x00024F4C File Offset: 0x0002314C
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qpshBt_resize = QPushButton.__N.QPshBt_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qpshBt_resize);
		}

		// Token: 0x06000DB3 RID: 3507 RVA: 0x00024F78 File Offset: 0x00023178
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qpshBt_minimumSize = QPushButton.__N.QPshBt_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qpshBt_minimumSize);
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x00024FA4 File Offset: 0x000231A4
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qpshBt_setMinimumSize = QPushButton.__N.QPshBt_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qpshBt_setMinimumSize);
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x00024FD0 File Offset: 0x000231D0
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qpshBt_maximumSize = QPushButton.__N.QPshBt_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qpshBt_maximumSize);
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x00024FFC File Offset: 0x000231FC
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qpshBt_setMaximumSize = QPushButton.__N.QPshBt_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qpshBt_setMaximumSize);
		}

		// Token: 0x06000DB7 RID: 3511 RVA: 0x00025028 File Offset: 0x00023228
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qpshBt_pos = QPushButton.__N.QPshBt_pos;
			return calli(Vector3(System.IntPtr), this.self, qpshBt_pos);
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x00025054 File Offset: 0x00023254
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qpshBt_move = QPushButton.__N.QPshBt_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qpshBt_move);
		}

		// Token: 0x06000DB9 RID: 3513 RVA: 0x00025080 File Offset: 0x00023280
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qpshBt_isEnabled = QPushButton.__N.QPshBt_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_isEnabled) > 0;
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x000250B0 File Offset: 0x000232B0
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qpshBt_setEnabled = QPushButton.__N.QPshBt_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qpshBt_setEnabled);
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x000250E4 File Offset: 0x000232E4
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qpshBt_setVisible = QPushButton.__N.QPshBt_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qpshBt_setVisible);
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x00025118 File Offset: 0x00023318
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qpshBt_setHidden = QPushButton.__N.QPshBt_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qpshBt_setHidden);
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x0002514C File Offset: 0x0002334C
		internal readonly void show()
		{
			this.NullCheck("show");
			method qpshBt_show = QPushButton.__N.QPshBt_show;
			calli(System.Void(System.IntPtr), this.self, qpshBt_show);
		}

		// Token: 0x06000DBE RID: 3518 RVA: 0x00025178 File Offset: 0x00023378
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qpshBt_hide = QPushButton.__N.QPshBt_hide;
			calli(System.Void(System.IntPtr), this.self, qpshBt_hide);
		}

		// Token: 0x06000DBF RID: 3519 RVA: 0x000251A4 File Offset: 0x000233A4
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qpshBt_showMinimized = QPushButton.__N.QPshBt_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qpshBt_showMinimized);
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x000251D0 File Offset: 0x000233D0
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qpshBt_showMaximized = QPushButton.__N.QPshBt_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qpshBt_showMaximized);
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x000251FC File Offset: 0x000233FC
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qpshBt_showFullScreen = QPushButton.__N.QPshBt_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qpshBt_showFullScreen);
		}

		// Token: 0x06000DC2 RID: 3522 RVA: 0x00025228 File Offset: 0x00023428
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qpshBt_showNormal = QPushButton.__N.QPshBt_showNormal;
			calli(System.Void(System.IntPtr), this.self, qpshBt_showNormal);
		}

		// Token: 0x06000DC3 RID: 3523 RVA: 0x00025254 File Offset: 0x00023454
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qpshBt_close = QPushButton.__N.QPshBt_close;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_close) > 0;
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x00025284 File Offset: 0x00023484
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qpshBt_raise = QPushButton.__N.QPshBt_raise;
			calli(System.Void(System.IntPtr), this.self, qpshBt_raise);
		}

		// Token: 0x06000DC5 RID: 3525 RVA: 0x000252B0 File Offset: 0x000234B0
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qpshBt_lower = QPushButton.__N.QPshBt_lower;
			calli(System.Void(System.IntPtr), this.self, qpshBt_lower);
		}

		// Token: 0x06000DC6 RID: 3526 RVA: 0x000252DC File Offset: 0x000234DC
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qpshBt_isVisible = QPushButton.__N.QPshBt_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_isVisible) > 0;
		}

		// Token: 0x06000DC7 RID: 3527 RVA: 0x0002530C File Offset: 0x0002350C
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qpshBt_setAttribute = QPushButton.__N.QPshBt_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qpshBt_setAttribute);
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x00025340 File Offset: 0x00023540
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qpshBt_testAttribute = QPushButton.__N.QPshBt_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qpshBt_testAttribute) > 0;
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x00025370 File Offset: 0x00023570
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qpshBt_acceptDrops = QPushButton.__N.QPshBt_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_acceptDrops) > 0;
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x000253A0 File Offset: 0x000235A0
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qpshBt_setAcceptDrops = QPushButton.__N.QPshBt_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qpshBt_setAcceptDrops);
		}

		// Token: 0x06000DCB RID: 3531 RVA: 0x000253D4 File Offset: 0x000235D4
		internal readonly void update()
		{
			this.NullCheck("update");
			method qpshBt_update = QPushButton.__N.QPshBt_update;
			calli(System.Void(System.IntPtr), this.self, qpshBt_update);
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x00025400 File Offset: 0x00023600
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qpshBt_repaint = QPushButton.__N.QPshBt_repaint;
			calli(System.Void(System.IntPtr), this.self, qpshBt_repaint);
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x0002542C File Offset: 0x0002362C
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qpshBt_setCursor = QPushButton.__N.QPshBt_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qpshBt_setCursor);
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x00025458 File Offset: 0x00023658
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qpshBt_unsetCursor = QPushButton.__N.QPshBt_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qpshBt_unsetCursor);
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x00025484 File Offset: 0x00023684
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qpshBt_setWindowIcon = QPushButton.__N.QPshBt_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qpshBt_setWindowIcon);
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x000254B4 File Offset: 0x000236B4
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qpshBt_setWindowIconText = QPushButton.__N.QPshBt_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qpshBt_setWindowIconText);
		}

		// Token: 0x06000DD1 RID: 3537 RVA: 0x000254E4 File Offset: 0x000236E4
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qpshBt_setWindowOpacity = QPushButton.__N.QPshBt_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qpshBt_setWindowOpacity);
		}

		// Token: 0x06000DD2 RID: 3538 RVA: 0x00025510 File Offset: 0x00023710
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qpshBt_windowOpacity = QPushButton.__N.QPshBt_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qpshBt_windowOpacity);
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x0002553C File Offset: 0x0002373C
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qpshBt_isMinimized = QPushButton.__N.QPshBt_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_isMinimized) > 0;
		}

		// Token: 0x06000DD4 RID: 3540 RVA: 0x0002556C File Offset: 0x0002376C
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qpshBt_isMaximized = QPushButton.__N.QPshBt_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_isMaximized) > 0;
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x0002559C File Offset: 0x0002379C
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qpshBt_isFullScreen = QPushButton.__N.QPshBt_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_isFullScreen) > 0;
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x000255CC File Offset: 0x000237CC
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qpshBt_setMouseTracking = QPushButton.__N.QPshBt_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qpshBt_setMouseTracking);
		}

		// Token: 0x06000DD7 RID: 3543 RVA: 0x00025600 File Offset: 0x00023800
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qpshBt_hasMouseTracking = QPushButton.__N.QPshBt_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_hasMouseTracking) > 0;
		}

		// Token: 0x06000DD8 RID: 3544 RVA: 0x00025630 File Offset: 0x00023830
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qpshBt_underMouse = QPushButton.__N.QPshBt_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_underMouse) > 0;
		}

		// Token: 0x06000DD9 RID: 3545 RVA: 0x00025660 File Offset: 0x00023860
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qpshBt_mapToGlobal = QPushButton.__N.QPshBt_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qpshBt_mapToGlobal);
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x0002568C File Offset: 0x0002388C
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qpshBt_mapFromGlobal = QPushButton.__N.QPshBt_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qpshBt_mapFromGlobal);
		}

		// Token: 0x06000DDB RID: 3547 RVA: 0x000256B8 File Offset: 0x000238B8
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qpshBt_hasFocus = QPushButton.__N.QPshBt_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_hasFocus) > 0;
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x000256E8 File Offset: 0x000238E8
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qpshBt_focusPolicy = QPushButton.__N.QPshBt_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qpshBt_focusPolicy);
		}

		// Token: 0x06000DDD RID: 3549 RVA: 0x00025714 File Offset: 0x00023914
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qpshBt_setFocusPolicy = QPushButton.__N.QPshBt_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qpshBt_setFocusPolicy);
		}

		// Token: 0x06000DDE RID: 3550 RVA: 0x00025740 File Offset: 0x00023940
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qpshBt_setFocusProxy = QPushButton.__N.QPshBt_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qpshBt_setFocusProxy);
		}

		// Token: 0x06000DDF RID: 3551 RVA: 0x00025770 File Offset: 0x00023970
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qpshBt_isActiveWindow = QPushButton.__N.QPshBt_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_isActiveWindow) > 0;
		}

		// Token: 0x06000DE0 RID: 3552 RVA: 0x000257A0 File Offset: 0x000239A0
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qpshBt_updatesEnabled = QPushButton.__N.QPshBt_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_updatesEnabled) > 0;
		}

		// Token: 0x06000DE1 RID: 3553 RVA: 0x000257D0 File Offset: 0x000239D0
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qpshBt_setUpdatesEnabled = QPushButton.__N.QPshBt_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qpshBt_setUpdatesEnabled);
		}

		// Token: 0x06000DE2 RID: 3554 RVA: 0x00025804 File Offset: 0x00023A04
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qpshBt_setFocus = QPushButton.__N.QPshBt_setFocus;
			calli(System.Void(System.IntPtr), this.self, qpshBt_setFocus);
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x00025830 File Offset: 0x00023A30
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qpshBt_activateWindow = QPushButton.__N.QPshBt_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qpshBt_activateWindow);
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x0002585C File Offset: 0x00023A5C
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qpshBt_clearFocus = QPushButton.__N.QPshBt_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qpshBt_clearFocus);
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x00025888 File Offset: 0x00023A88
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qpshBt_setSizePolicy = QPushButton.__N.QPshBt_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qpshBt_setSizePolicy);
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x000258B8 File Offset: 0x00023AB8
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qpshBt_devicePixelRatioF = QPushButton.__N.QPshBt_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qpshBt_devicePixelRatioF);
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x000258E4 File Offset: 0x00023AE4
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qpshBt_saveGeometry = QPushButton.__N.QPshBt_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qpshBt_saveGeometry));
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x00025914 File Offset: 0x00023B14
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qpshBt_restoreGeometry = QPushButton.__N.QPshBt_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qpshBt_restoreGeometry) > 0;
		}

		// Token: 0x06000DE9 RID: 3561 RVA: 0x00025948 File Offset: 0x00023B48
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qpshBt_addAction = QPushButton.__N.QPshBt_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qpshBt_addAction);
		}

		// Token: 0x06000DEA RID: 3562 RVA: 0x00025978 File Offset: 0x00023B78
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qpshBt_removeAction = QPushButton.__N.QPshBt_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qpshBt_removeAction);
		}

		// Token: 0x06000DEB RID: 3563 RVA: 0x000259A8 File Offset: 0x00023BA8
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qpshBt_setParent = QPushButton.__N.QPshBt_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qpshBt_setParent);
		}

		// Token: 0x06000DEC RID: 3564 RVA: 0x000259D8 File Offset: 0x00023BD8
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qpshBt_parentWidget = QPushButton.__N.QPshBt_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qpshBt_parentWidget);
		}

		// Token: 0x06000DED RID: 3565 RVA: 0x00025A08 File Offset: 0x00023C08
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qpshBt_AddClassName = QPushButton.__N.QPshBt_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qpshBt_AddClassName);
		}

		// Token: 0x06000DEE RID: 3566 RVA: 0x00025A38 File Offset: 0x00023C38
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qpshBt_Polish = QPushButton.__N.QPshBt_Polish;
			calli(System.Void(System.IntPtr), this.self, qpshBt_Polish);
		}

		// Token: 0x06000DEF RID: 3567 RVA: 0x00025A64 File Offset: 0x00023C64
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qpshBt_toolTip = QPushButton.__N.QPshBt_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qpshBt_toolTip));
		}

		// Token: 0x06000DF0 RID: 3568 RVA: 0x00025A94 File Offset: 0x00023C94
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qpshBt_setToolTip = QPushButton.__N.QPshBt_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qpshBt_setToolTip);
		}

		// Token: 0x06000DF1 RID: 3569 RVA: 0x00025AC4 File Offset: 0x00023CC4
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qpshBt_statusTip = QPushButton.__N.QPshBt_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qpshBt_statusTip));
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x00025AF4 File Offset: 0x00023CF4
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qpshBt_setStatusTip = QPushButton.__N.QPshBt_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qpshBt_setStatusTip);
		}

		// Token: 0x06000DF3 RID: 3571 RVA: 0x00025B24 File Offset: 0x00023D24
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qpshBt_toolTipDuration = QPushButton.__N.QPshBt_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_toolTipDuration);
		}

		// Token: 0x06000DF4 RID: 3572 RVA: 0x00025B50 File Offset: 0x00023D50
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qpshBt_setToolTipDuration = QPushButton.__N.QPshBt_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qpshBt_setToolTipDuration);
		}

		// Token: 0x06000DF5 RID: 3573 RVA: 0x00025B7C File Offset: 0x00023D7C
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qpshBt_autoFillBackground = QPushButton.__N.QPshBt_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qpshBt_autoFillBackground) > 0;
		}

		// Token: 0x06000DF6 RID: 3574 RVA: 0x00025BAC File Offset: 0x00023DAC
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qpshBt_setAutoFillBackground = QPushButton.__N.QPshBt_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qpshBt_setAutoFillBackground);
		}

		// Token: 0x04000062 RID: 98
		internal IntPtr self;

		// Token: 0x02000123 RID: 291
		internal static class __N
		{
			// Token: 0x04000F34 RID: 3892
			internal static method From_QAbstractButton_To_QPushButton;

			// Token: 0x04000F35 RID: 3893
			internal static method To_QAbstractButton_From_QPushButton;

			// Token: 0x04000F36 RID: 3894
			internal static method From_QWidget_To_QPushButton;

			// Token: 0x04000F37 RID: 3895
			internal static method To_QWidget_From_QPushButton;

			// Token: 0x04000F38 RID: 3896
			internal static method From_QObject_To_QPushButton;

			// Token: 0x04000F39 RID: 3897
			internal static method To_QObject_From_QPushButton;

			// Token: 0x04000F3A RID: 3898
			internal static method QPshBt_setText;

			// Token: 0x04000F3B RID: 3899
			internal static method QPshBt_text;

			// Token: 0x04000F3C RID: 3900
			internal static method QPshBt_setIcon;

			// Token: 0x04000F3D RID: 3901
			internal static method QPshBt_setCheckable;

			// Token: 0x04000F3E RID: 3902
			internal static method QPshBt_isCheckable;

			// Token: 0x04000F3F RID: 3903
			internal static method QPshBt_isChecked;

			// Token: 0x04000F40 RID: 3904
			internal static method QPshBt_setDown;

			// Token: 0x04000F41 RID: 3905
			internal static method QPshBt_isDown;

			// Token: 0x04000F42 RID: 3906
			internal static method QPshBt_setIconSize;

			// Token: 0x04000F43 RID: 3907
			internal static method QPshBt_animateClick;

			// Token: 0x04000F44 RID: 3908
			internal static method QPshBt_click;

			// Token: 0x04000F45 RID: 3909
			internal static method QPshBt_toggle;

			// Token: 0x04000F46 RID: 3910
			internal static method QPshBt_setChecked;

			// Token: 0x04000F47 RID: 3911
			internal static method QPshBt_setAutoRepeat;

			// Token: 0x04000F48 RID: 3912
			internal static method QPshBt_autoRepeat;

			// Token: 0x04000F49 RID: 3913
			internal static method QPshBt_setAutoRepeatDelay;

			// Token: 0x04000F4A RID: 3914
			internal static method QPshBt_autoRepeatDelay;

			// Token: 0x04000F4B RID: 3915
			internal static method QPshBt_setAutoRepeatInterval;

			// Token: 0x04000F4C RID: 3916
			internal static method QPshBt_autoRepeatInterval;

			// Token: 0x04000F4D RID: 3917
			internal static method QPshBt_setAutoExclusive;

			// Token: 0x04000F4E RID: 3918
			internal static method QPshBt_autoExclusive;

			// Token: 0x04000F4F RID: 3919
			internal static method QPshBt_isTopLevel;

			// Token: 0x04000F50 RID: 3920
			internal static method QPshBt_isWindow;

			// Token: 0x04000F51 RID: 3921
			internal static method QPshBt_isModal;

			// Token: 0x04000F52 RID: 3922
			internal static method QPshBt_setStyleSheet;

			// Token: 0x04000F53 RID: 3923
			internal static method QPshBt_windowTitle;

			// Token: 0x04000F54 RID: 3924
			internal static method QPshBt_setWindowTitle;

			// Token: 0x04000F55 RID: 3925
			internal static method QPshBt_setWindowFlags;

			// Token: 0x04000F56 RID: 3926
			internal static method QPshBt_windowFlags;

			// Token: 0x04000F57 RID: 3927
			internal static method QPshBt_size;

			// Token: 0x04000F58 RID: 3928
			internal static method QPshBt_resize;

			// Token: 0x04000F59 RID: 3929
			internal static method QPshBt_minimumSize;

			// Token: 0x04000F5A RID: 3930
			internal static method QPshBt_setMinimumSize;

			// Token: 0x04000F5B RID: 3931
			internal static method QPshBt_maximumSize;

			// Token: 0x04000F5C RID: 3932
			internal static method QPshBt_setMaximumSize;

			// Token: 0x04000F5D RID: 3933
			internal static method QPshBt_pos;

			// Token: 0x04000F5E RID: 3934
			internal static method QPshBt_move;

			// Token: 0x04000F5F RID: 3935
			internal static method QPshBt_isEnabled;

			// Token: 0x04000F60 RID: 3936
			internal static method QPshBt_setEnabled;

			// Token: 0x04000F61 RID: 3937
			internal static method QPshBt_setVisible;

			// Token: 0x04000F62 RID: 3938
			internal static method QPshBt_setHidden;

			// Token: 0x04000F63 RID: 3939
			internal static method QPshBt_show;

			// Token: 0x04000F64 RID: 3940
			internal static method QPshBt_hide;

			// Token: 0x04000F65 RID: 3941
			internal static method QPshBt_showMinimized;

			// Token: 0x04000F66 RID: 3942
			internal static method QPshBt_showMaximized;

			// Token: 0x04000F67 RID: 3943
			internal static method QPshBt_showFullScreen;

			// Token: 0x04000F68 RID: 3944
			internal static method QPshBt_showNormal;

			// Token: 0x04000F69 RID: 3945
			internal static method QPshBt_close;

			// Token: 0x04000F6A RID: 3946
			internal static method QPshBt_raise;

			// Token: 0x04000F6B RID: 3947
			internal static method QPshBt_lower;

			// Token: 0x04000F6C RID: 3948
			internal static method QPshBt_isVisible;

			// Token: 0x04000F6D RID: 3949
			internal static method QPshBt_setAttribute;

			// Token: 0x04000F6E RID: 3950
			internal static method QPshBt_testAttribute;

			// Token: 0x04000F6F RID: 3951
			internal static method QPshBt_acceptDrops;

			// Token: 0x04000F70 RID: 3952
			internal static method QPshBt_setAcceptDrops;

			// Token: 0x04000F71 RID: 3953
			internal static method QPshBt_update;

			// Token: 0x04000F72 RID: 3954
			internal static method QPshBt_repaint;

			// Token: 0x04000F73 RID: 3955
			internal static method QPshBt_setCursor;

			// Token: 0x04000F74 RID: 3956
			internal static method QPshBt_unsetCursor;

			// Token: 0x04000F75 RID: 3957
			internal static method QPshBt_setWindowIcon;

			// Token: 0x04000F76 RID: 3958
			internal static method QPshBt_setWindowIconText;

			// Token: 0x04000F77 RID: 3959
			internal static method QPshBt_setWindowOpacity;

			// Token: 0x04000F78 RID: 3960
			internal static method QPshBt_windowOpacity;

			// Token: 0x04000F79 RID: 3961
			internal static method QPshBt_isMinimized;

			// Token: 0x04000F7A RID: 3962
			internal static method QPshBt_isMaximized;

			// Token: 0x04000F7B RID: 3963
			internal static method QPshBt_isFullScreen;

			// Token: 0x04000F7C RID: 3964
			internal static method QPshBt_setMouseTracking;

			// Token: 0x04000F7D RID: 3965
			internal static method QPshBt_hasMouseTracking;

			// Token: 0x04000F7E RID: 3966
			internal static method QPshBt_underMouse;

			// Token: 0x04000F7F RID: 3967
			internal static method QPshBt_mapToGlobal;

			// Token: 0x04000F80 RID: 3968
			internal static method QPshBt_mapFromGlobal;

			// Token: 0x04000F81 RID: 3969
			internal static method QPshBt_hasFocus;

			// Token: 0x04000F82 RID: 3970
			internal static method QPshBt_focusPolicy;

			// Token: 0x04000F83 RID: 3971
			internal static method QPshBt_setFocusPolicy;

			// Token: 0x04000F84 RID: 3972
			internal static method QPshBt_setFocusProxy;

			// Token: 0x04000F85 RID: 3973
			internal static method QPshBt_isActiveWindow;

			// Token: 0x04000F86 RID: 3974
			internal static method QPshBt_updatesEnabled;

			// Token: 0x04000F87 RID: 3975
			internal static method QPshBt_setUpdatesEnabled;

			// Token: 0x04000F88 RID: 3976
			internal static method QPshBt_setFocus;

			// Token: 0x04000F89 RID: 3977
			internal static method QPshBt_activateWindow;

			// Token: 0x04000F8A RID: 3978
			internal static method QPshBt_clearFocus;

			// Token: 0x04000F8B RID: 3979
			internal static method QPshBt_setSizePolicy;

			// Token: 0x04000F8C RID: 3980
			internal static method QPshBt_devicePixelRatioF;

			// Token: 0x04000F8D RID: 3981
			internal static method QPshBt_saveGeometry;

			// Token: 0x04000F8E RID: 3982
			internal static method QPshBt_restoreGeometry;

			// Token: 0x04000F8F RID: 3983
			internal static method QPshBt_addAction;

			// Token: 0x04000F90 RID: 3984
			internal static method QPshBt_removeAction;

			// Token: 0x04000F91 RID: 3985
			internal static method QPshBt_setParent;

			// Token: 0x04000F92 RID: 3986
			internal static method QPshBt_parentWidget;

			// Token: 0x04000F93 RID: 3987
			internal static method QPshBt_AddClassName;

			// Token: 0x04000F94 RID: 3988
			internal static method QPshBt_Polish;

			// Token: 0x04000F95 RID: 3989
			internal static method QPshBt_toolTip;

			// Token: 0x04000F96 RID: 3990
			internal static method QPshBt_setToolTip;

			// Token: 0x04000F97 RID: 3991
			internal static method QPshBt_statusTip;

			// Token: 0x04000F98 RID: 3992
			internal static method QPshBt_setStatusTip;

			// Token: 0x04000F99 RID: 3993
			internal static method QPshBt_toolTipDuration;

			// Token: 0x04000F9A RID: 3994
			internal static method QPshBt_setToolTipDuration;

			// Token: 0x04000F9B RID: 3995
			internal static method QPshBt_autoFillBackground;

			// Token: 0x04000F9C RID: 3996
			internal static method QPshBt_setAutoFillBackground;
		}
	}
}
