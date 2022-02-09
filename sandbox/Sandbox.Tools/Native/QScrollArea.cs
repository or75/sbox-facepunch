using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000058 RID: 88
	internal struct QScrollArea
	{
		// Token: 0x06000DF7 RID: 3575 RVA: 0x00025BDD File Offset: 0x00023DDD
		public static implicit operator IntPtr(QScrollArea value)
		{
			return value.self;
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x00025BE8 File Offset: 0x00023DE8
		public static implicit operator QScrollArea(IntPtr value)
		{
			return new QScrollArea
			{
				self = value
			};
		}

		// Token: 0x06000DF9 RID: 3577 RVA: 0x00025C06 File Offset: 0x00023E06
		public static bool operator ==(QScrollArea c1, QScrollArea c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000DFA RID: 3578 RVA: 0x00025C19 File Offset: 0x00023E19
		public static bool operator !=(QScrollArea c1, QScrollArea c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000DFB RID: 3579 RVA: 0x00025C2C File Offset: 0x00023E2C
		public override bool Equals(object obj)
		{
			if (obj is QScrollArea)
			{
				QScrollArea c = (QScrollArea)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000DFC RID: 3580 RVA: 0x00025C56 File Offset: 0x00023E56
		internal QScrollArea(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x00025C60 File Offset: 0x00023E60
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QScrollArea ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000DFE RID: 3582 RVA: 0x00025C9C File Offset: 0x00023E9C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000DFF RID: 3583 RVA: 0x00025CAE File Offset: 0x00023EAE
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x00025CB9 File Offset: 0x00023EB9
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x00025CCC File Offset: 0x00023ECC
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QScrollArea was null when calling " + n);
			}
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x00025CE7 File Offset: 0x00023EE7
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x00025CF4 File Offset: 0x00023EF4
		public static implicit operator QAbstractScrollArea(QScrollArea value)
		{
			method to_QAbstractScrollArea_From_QScrollArea = QScrollArea.__N.To_QAbstractScrollArea_From_QScrollArea;
			return calli(System.IntPtr(System.IntPtr), value, to_QAbstractScrollArea_From_QScrollArea);
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x00025D18 File Offset: 0x00023F18
		public static explicit operator QScrollArea(QAbstractScrollArea value)
		{
			method from_QAbstractScrollArea_To_QScrollArea = QScrollArea.__N.From_QAbstractScrollArea_To_QScrollArea;
			return calli(System.IntPtr(System.IntPtr), value, from_QAbstractScrollArea_To_QScrollArea);
		}

		// Token: 0x06000E05 RID: 3589 RVA: 0x00025D3C File Offset: 0x00023F3C
		public static implicit operator QFrame(QScrollArea value)
		{
			method to_QFrame_From_QScrollArea = QScrollArea.__N.To_QFrame_From_QScrollArea;
			return calli(System.IntPtr(System.IntPtr), value, to_QFrame_From_QScrollArea);
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x00025D60 File Offset: 0x00023F60
		public static explicit operator QScrollArea(QFrame value)
		{
			method from_QFrame_To_QScrollArea = QScrollArea.__N.From_QFrame_To_QScrollArea;
			return calli(System.IntPtr(System.IntPtr), value, from_QFrame_To_QScrollArea);
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x00025D84 File Offset: 0x00023F84
		public static implicit operator QWidget(QScrollArea value)
		{
			method to_QWidget_From_QScrollArea = QScrollArea.__N.To_QWidget_From_QScrollArea;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QScrollArea);
		}

		// Token: 0x06000E08 RID: 3592 RVA: 0x00025DA8 File Offset: 0x00023FA8
		public static explicit operator QScrollArea(QWidget value)
		{
			method from_QWidget_To_QScrollArea = QScrollArea.__N.From_QWidget_To_QScrollArea;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QScrollArea);
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x00025DCC File Offset: 0x00023FCC
		public static implicit operator QObject(QScrollArea value)
		{
			method to_QObject_From_QScrollArea = QScrollArea.__N.To_QObject_From_QScrollArea;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QScrollArea);
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x00025DF0 File Offset: 0x00023FF0
		public static explicit operator QScrollArea(QObject value)
		{
			method from_QObject_To_QScrollArea = QScrollArea.__N.From_QObject_To_QScrollArea;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QScrollArea);
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x00025E14 File Offset: 0x00024014
		internal static QScrollArea CreateQScrollArea(QWidget parent)
		{
			method qscrll_CreateQScrollArea = QScrollArea.__N.QScrll_CreateQScrollArea;
			return calli(System.IntPtr(System.IntPtr), parent, qscrll_CreateQScrollArea);
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x00025E38 File Offset: 0x00024038
		internal readonly void ensureVisible(int x, int y, int xmargin, int ymargin)
		{
			this.NullCheck("ensureVisible");
			method qscrll_ensureVisible = QScrollArea.__N.QScrll_ensureVisible;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.Int32,System.Int32), this.self, x, y, xmargin, ymargin, qscrll_ensureVisible);
		}

		// Token: 0x06000E0D RID: 3597 RVA: 0x00025E68 File Offset: 0x00024068
		internal readonly void ensureWidgetVisible(QWidget childWidget, int xmargin, int ymargin)
		{
			this.NullCheck("ensureWidgetVisible");
			method qscrll_ensureWidgetVisible = QScrollArea.__N.QScrll_ensureWidgetVisible;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32,System.Int32), this.self, childWidget, xmargin, ymargin, qscrll_ensureWidgetVisible);
		}

		// Token: 0x06000E0E RID: 3598 RVA: 0x00025E9C File Offset: 0x0002409C
		internal readonly bool widgetResizable()
		{
			this.NullCheck("widgetResizable");
			method qscrll_widgetResizable = QScrollArea.__N.QScrll_widgetResizable;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_widgetResizable) > 0;
		}

		// Token: 0x06000E0F RID: 3599 RVA: 0x00025ECC File Offset: 0x000240CC
		internal readonly void setWidgetResizable(bool resizable)
		{
			this.NullCheck("setWidgetResizable");
			method qscrll_setWidgetResizable = QScrollArea.__N.QScrll_setWidgetResizable;
			calli(System.Void(System.IntPtr,System.Int32), this.self, resizable ? 1 : 0, qscrll_setWidgetResizable);
		}

		// Token: 0x06000E10 RID: 3600 RVA: 0x00025F00 File Offset: 0x00024100
		internal readonly QWidget widget()
		{
			this.NullCheck("widget");
			method qscrll_widget = QScrollArea.__N.QScrll_widget;
			return calli(System.IntPtr(System.IntPtr), this.self, qscrll_widget);
		}

		// Token: 0x06000E11 RID: 3601 RVA: 0x00025F30 File Offset: 0x00024130
		internal readonly void setWidget(QWidget widget)
		{
			this.NullCheck("setWidget");
			method qscrll_setWidget = QScrollArea.__N.QScrll_setWidget;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qscrll_setWidget);
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x00025F60 File Offset: 0x00024160
		internal readonly QScrollBar horizontalScrollBar()
		{
			this.NullCheck("horizontalScrollBar");
			method qscrll_horizontalScrollBar = QScrollArea.__N.QScrll_horizontalScrollBar;
			return calli(System.IntPtr(System.IntPtr), this.self, qscrll_horizontalScrollBar);
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x00025F90 File Offset: 0x00024190
		internal readonly QScrollBar verticalScrollBar()
		{
			this.NullCheck("verticalScrollBar");
			method qscrll_verticalScrollBar = QScrollArea.__N.QScrll_verticalScrollBar;
			return calli(System.IntPtr(System.IntPtr), this.self, qscrll_verticalScrollBar);
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x00025FC0 File Offset: 0x000241C0
		internal readonly ScrollbarMode horizontalScrollBarPolicy()
		{
			this.NullCheck("horizontalScrollBarPolicy");
			method qscrll_horizontalScrollBarPolicy = QScrollArea.__N.QScrll_horizontalScrollBarPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qscrll_horizontalScrollBarPolicy);
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x00025FEC File Offset: 0x000241EC
		internal readonly void setHorizontalScrollBarPolicy(ScrollbarMode m)
		{
			this.NullCheck("setHorizontalScrollBarPolicy");
			method qscrll_setHorizontalScrollBarPolicy = QScrollArea.__N.QScrll_setHorizontalScrollBarPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)m, qscrll_setHorizontalScrollBarPolicy);
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x00026018 File Offset: 0x00024218
		internal readonly ScrollbarMode verticalScrollBarPolicy()
		{
			this.NullCheck("verticalScrollBarPolicy");
			method qscrll_verticalScrollBarPolicy = QScrollArea.__N.QScrll_verticalScrollBarPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qscrll_verticalScrollBarPolicy);
		}

		// Token: 0x06000E17 RID: 3607 RVA: 0x00026044 File Offset: 0x00024244
		internal readonly void setVerticalScrollBarPolicy(ScrollbarMode m)
		{
			this.NullCheck("setVerticalScrollBarPolicy");
			method qscrll_setVerticalScrollBarPolicy = QScrollArea.__N.QScrll_setVerticalScrollBarPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)m, qscrll_setVerticalScrollBarPolicy);
		}

		// Token: 0x06000E18 RID: 3608 RVA: 0x00026070 File Offset: 0x00024270
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qscrll_isTopLevel = QScrollArea.__N.QScrll_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_isTopLevel) > 0;
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x000260A0 File Offset: 0x000242A0
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qscrll_isWindow = QScrollArea.__N.QScrll_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_isWindow) > 0;
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x000260D0 File Offset: 0x000242D0
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qscrll_isModal = QScrollArea.__N.QScrll_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_isModal) > 0;
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x00026100 File Offset: 0x00024300
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qscrll_setStyleSheet = QScrollArea.__N.QScrll_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qscrll_setStyleSheet);
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x00026130 File Offset: 0x00024330
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qscrll_windowTitle = QScrollArea.__N.QScrll_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qscrll_windowTitle));
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x00026160 File Offset: 0x00024360
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qscrll_setWindowTitle = QScrollArea.__N.QScrll_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qscrll_setWindowTitle);
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x00026190 File Offset: 0x00024390
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qscrll_setWindowFlags = QScrollArea.__N.QScrll_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qscrll_setWindowFlags);
		}

		// Token: 0x06000E1F RID: 3615 RVA: 0x000261BC File Offset: 0x000243BC
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qscrll_windowFlags = QScrollArea.__N.QScrll_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qscrll_windowFlags);
		}

		// Token: 0x06000E20 RID: 3616 RVA: 0x000261E8 File Offset: 0x000243E8
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qscrll_size = QScrollArea.__N.QScrll_size;
			return calli(Vector3(System.IntPtr), this.self, qscrll_size);
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x00026214 File Offset: 0x00024414
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qscrll_resize = QScrollArea.__N.QScrll_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qscrll_resize);
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x00026240 File Offset: 0x00024440
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qscrll_minimumSize = QScrollArea.__N.QScrll_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qscrll_minimumSize);
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x0002626C File Offset: 0x0002446C
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qscrll_setMinimumSize = QScrollArea.__N.QScrll_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qscrll_setMinimumSize);
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x00026298 File Offset: 0x00024498
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qscrll_maximumSize = QScrollArea.__N.QScrll_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qscrll_maximumSize);
		}

		// Token: 0x06000E25 RID: 3621 RVA: 0x000262C4 File Offset: 0x000244C4
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qscrll_setMaximumSize = QScrollArea.__N.QScrll_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qscrll_setMaximumSize);
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x000262F0 File Offset: 0x000244F0
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qscrll_pos = QScrollArea.__N.QScrll_pos;
			return calli(Vector3(System.IntPtr), this.self, qscrll_pos);
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x0002631C File Offset: 0x0002451C
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qscrll_move = QScrollArea.__N.QScrll_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qscrll_move);
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x00026348 File Offset: 0x00024548
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qscrll_isEnabled = QScrollArea.__N.QScrll_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_isEnabled) > 0;
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x00026378 File Offset: 0x00024578
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qscrll_setEnabled = QScrollArea.__N.QScrll_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qscrll_setEnabled);
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x000263AC File Offset: 0x000245AC
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qscrll_setVisible = QScrollArea.__N.QScrll_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qscrll_setVisible);
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x000263E0 File Offset: 0x000245E0
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qscrll_setHidden = QScrollArea.__N.QScrll_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qscrll_setHidden);
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x00026414 File Offset: 0x00024614
		internal readonly void show()
		{
			this.NullCheck("show");
			method qscrll_show = QScrollArea.__N.QScrll_show;
			calli(System.Void(System.IntPtr), this.self, qscrll_show);
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x00026440 File Offset: 0x00024640
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qscrll_hide = QScrollArea.__N.QScrll_hide;
			calli(System.Void(System.IntPtr), this.self, qscrll_hide);
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x0002646C File Offset: 0x0002466C
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qscrll_showMinimized = QScrollArea.__N.QScrll_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qscrll_showMinimized);
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x00026498 File Offset: 0x00024698
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qscrll_showMaximized = QScrollArea.__N.QScrll_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qscrll_showMaximized);
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x000264C4 File Offset: 0x000246C4
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qscrll_showFullScreen = QScrollArea.__N.QScrll_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qscrll_showFullScreen);
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x000264F0 File Offset: 0x000246F0
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qscrll_showNormal = QScrollArea.__N.QScrll_showNormal;
			calli(System.Void(System.IntPtr), this.self, qscrll_showNormal);
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x0002651C File Offset: 0x0002471C
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qscrll_close = QScrollArea.__N.QScrll_close;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_close) > 0;
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x0002654C File Offset: 0x0002474C
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qscrll_raise = QScrollArea.__N.QScrll_raise;
			calli(System.Void(System.IntPtr), this.self, qscrll_raise);
		}

		// Token: 0x06000E34 RID: 3636 RVA: 0x00026578 File Offset: 0x00024778
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qscrll_lower = QScrollArea.__N.QScrll_lower;
			calli(System.Void(System.IntPtr), this.self, qscrll_lower);
		}

		// Token: 0x06000E35 RID: 3637 RVA: 0x000265A4 File Offset: 0x000247A4
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qscrll_isVisible = QScrollArea.__N.QScrll_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_isVisible) > 0;
		}

		// Token: 0x06000E36 RID: 3638 RVA: 0x000265D4 File Offset: 0x000247D4
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qscrll_setAttribute = QScrollArea.__N.QScrll_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qscrll_setAttribute);
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x00026608 File Offset: 0x00024808
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qscrll_testAttribute = QScrollArea.__N.QScrll_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qscrll_testAttribute) > 0;
		}

		// Token: 0x06000E38 RID: 3640 RVA: 0x00026638 File Offset: 0x00024838
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qscrll_acceptDrops = QScrollArea.__N.QScrll_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_acceptDrops) > 0;
		}

		// Token: 0x06000E39 RID: 3641 RVA: 0x00026668 File Offset: 0x00024868
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qscrll_setAcceptDrops = QScrollArea.__N.QScrll_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qscrll_setAcceptDrops);
		}

		// Token: 0x06000E3A RID: 3642 RVA: 0x0002669C File Offset: 0x0002489C
		internal readonly void update()
		{
			this.NullCheck("update");
			method qscrll_update = QScrollArea.__N.QScrll_update;
			calli(System.Void(System.IntPtr), this.self, qscrll_update);
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x000266C8 File Offset: 0x000248C8
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qscrll_repaint = QScrollArea.__N.QScrll_repaint;
			calli(System.Void(System.IntPtr), this.self, qscrll_repaint);
		}

		// Token: 0x06000E3C RID: 3644 RVA: 0x000266F4 File Offset: 0x000248F4
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qscrll_setCursor = QScrollArea.__N.QScrll_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qscrll_setCursor);
		}

		// Token: 0x06000E3D RID: 3645 RVA: 0x00026720 File Offset: 0x00024920
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qscrll_unsetCursor = QScrollArea.__N.QScrll_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qscrll_unsetCursor);
		}

		// Token: 0x06000E3E RID: 3646 RVA: 0x0002674C File Offset: 0x0002494C
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qscrll_setWindowIcon = QScrollArea.__N.QScrll_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qscrll_setWindowIcon);
		}

		// Token: 0x06000E3F RID: 3647 RVA: 0x0002677C File Offset: 0x0002497C
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qscrll_setWindowIconText = QScrollArea.__N.QScrll_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qscrll_setWindowIconText);
		}

		// Token: 0x06000E40 RID: 3648 RVA: 0x000267AC File Offset: 0x000249AC
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qscrll_setWindowOpacity = QScrollArea.__N.QScrll_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qscrll_setWindowOpacity);
		}

		// Token: 0x06000E41 RID: 3649 RVA: 0x000267D8 File Offset: 0x000249D8
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qscrll_windowOpacity = QScrollArea.__N.QScrll_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qscrll_windowOpacity);
		}

		// Token: 0x06000E42 RID: 3650 RVA: 0x00026804 File Offset: 0x00024A04
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qscrll_isMinimized = QScrollArea.__N.QScrll_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_isMinimized) > 0;
		}

		// Token: 0x06000E43 RID: 3651 RVA: 0x00026834 File Offset: 0x00024A34
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qscrll_isMaximized = QScrollArea.__N.QScrll_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_isMaximized) > 0;
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x00026864 File Offset: 0x00024A64
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qscrll_isFullScreen = QScrollArea.__N.QScrll_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_isFullScreen) > 0;
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x00026894 File Offset: 0x00024A94
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qscrll_setMouseTracking = QScrollArea.__N.QScrll_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qscrll_setMouseTracking);
		}

		// Token: 0x06000E46 RID: 3654 RVA: 0x000268C8 File Offset: 0x00024AC8
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qscrll_hasMouseTracking = QScrollArea.__N.QScrll_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_hasMouseTracking) > 0;
		}

		// Token: 0x06000E47 RID: 3655 RVA: 0x000268F8 File Offset: 0x00024AF8
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qscrll_underMouse = QScrollArea.__N.QScrll_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_underMouse) > 0;
		}

		// Token: 0x06000E48 RID: 3656 RVA: 0x00026928 File Offset: 0x00024B28
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qscrll_mapToGlobal = QScrollArea.__N.QScrll_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qscrll_mapToGlobal);
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x00026954 File Offset: 0x00024B54
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qscrll_mapFromGlobal = QScrollArea.__N.QScrll_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qscrll_mapFromGlobal);
		}

		// Token: 0x06000E4A RID: 3658 RVA: 0x00026980 File Offset: 0x00024B80
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qscrll_hasFocus = QScrollArea.__N.QScrll_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_hasFocus) > 0;
		}

		// Token: 0x06000E4B RID: 3659 RVA: 0x000269B0 File Offset: 0x00024BB0
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qscrll_focusPolicy = QScrollArea.__N.QScrll_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qscrll_focusPolicy);
		}

		// Token: 0x06000E4C RID: 3660 RVA: 0x000269DC File Offset: 0x00024BDC
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qscrll_setFocusPolicy = QScrollArea.__N.QScrll_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qscrll_setFocusPolicy);
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x00026A08 File Offset: 0x00024C08
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qscrll_setFocusProxy = QScrollArea.__N.QScrll_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qscrll_setFocusProxy);
		}

		// Token: 0x06000E4E RID: 3662 RVA: 0x00026A38 File Offset: 0x00024C38
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qscrll_isActiveWindow = QScrollArea.__N.QScrll_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_isActiveWindow) > 0;
		}

		// Token: 0x06000E4F RID: 3663 RVA: 0x00026A68 File Offset: 0x00024C68
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qscrll_updatesEnabled = QScrollArea.__N.QScrll_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_updatesEnabled) > 0;
		}

		// Token: 0x06000E50 RID: 3664 RVA: 0x00026A98 File Offset: 0x00024C98
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qscrll_setUpdatesEnabled = QScrollArea.__N.QScrll_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qscrll_setUpdatesEnabled);
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x00026ACC File Offset: 0x00024CCC
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qscrll_setFocus = QScrollArea.__N.QScrll_setFocus;
			calli(System.Void(System.IntPtr), this.self, qscrll_setFocus);
		}

		// Token: 0x06000E52 RID: 3666 RVA: 0x00026AF8 File Offset: 0x00024CF8
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qscrll_activateWindow = QScrollArea.__N.QScrll_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qscrll_activateWindow);
		}

		// Token: 0x06000E53 RID: 3667 RVA: 0x00026B24 File Offset: 0x00024D24
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qscrll_clearFocus = QScrollArea.__N.QScrll_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qscrll_clearFocus);
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x00026B50 File Offset: 0x00024D50
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qscrll_setSizePolicy = QScrollArea.__N.QScrll_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qscrll_setSizePolicy);
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x00026B80 File Offset: 0x00024D80
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qscrll_devicePixelRatioF = QScrollArea.__N.QScrll_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qscrll_devicePixelRatioF);
		}

		// Token: 0x06000E56 RID: 3670 RVA: 0x00026BAC File Offset: 0x00024DAC
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qscrll_saveGeometry = QScrollArea.__N.QScrll_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qscrll_saveGeometry));
		}

		// Token: 0x06000E57 RID: 3671 RVA: 0x00026BDC File Offset: 0x00024DDC
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qscrll_restoreGeometry = QScrollArea.__N.QScrll_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qscrll_restoreGeometry) > 0;
		}

		// Token: 0x06000E58 RID: 3672 RVA: 0x00026C10 File Offset: 0x00024E10
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qscrll_addAction = QScrollArea.__N.QScrll_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qscrll_addAction);
		}

		// Token: 0x06000E59 RID: 3673 RVA: 0x00026C40 File Offset: 0x00024E40
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qscrll_removeAction = QScrollArea.__N.QScrll_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qscrll_removeAction);
		}

		// Token: 0x06000E5A RID: 3674 RVA: 0x00026C70 File Offset: 0x00024E70
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qscrll_setParent = QScrollArea.__N.QScrll_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qscrll_setParent);
		}

		// Token: 0x06000E5B RID: 3675 RVA: 0x00026CA0 File Offset: 0x00024EA0
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qscrll_parentWidget = QScrollArea.__N.QScrll_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qscrll_parentWidget);
		}

		// Token: 0x06000E5C RID: 3676 RVA: 0x00026CD0 File Offset: 0x00024ED0
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qscrll_AddClassName = QScrollArea.__N.QScrll_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qscrll_AddClassName);
		}

		// Token: 0x06000E5D RID: 3677 RVA: 0x00026D00 File Offset: 0x00024F00
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qscrll_Polish = QScrollArea.__N.QScrll_Polish;
			calli(System.Void(System.IntPtr), this.self, qscrll_Polish);
		}

		// Token: 0x06000E5E RID: 3678 RVA: 0x00026D2C File Offset: 0x00024F2C
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qscrll_toolTip = QScrollArea.__N.QScrll_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qscrll_toolTip));
		}

		// Token: 0x06000E5F RID: 3679 RVA: 0x00026D5C File Offset: 0x00024F5C
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qscrll_setToolTip = QScrollArea.__N.QScrll_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qscrll_setToolTip);
		}

		// Token: 0x06000E60 RID: 3680 RVA: 0x00026D8C File Offset: 0x00024F8C
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qscrll_statusTip = QScrollArea.__N.QScrll_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qscrll_statusTip));
		}

		// Token: 0x06000E61 RID: 3681 RVA: 0x00026DBC File Offset: 0x00024FBC
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qscrll_setStatusTip = QScrollArea.__N.QScrll_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qscrll_setStatusTip);
		}

		// Token: 0x06000E62 RID: 3682 RVA: 0x00026DEC File Offset: 0x00024FEC
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qscrll_toolTipDuration = QScrollArea.__N.QScrll_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_toolTipDuration);
		}

		// Token: 0x06000E63 RID: 3683 RVA: 0x00026E18 File Offset: 0x00025018
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qscrll_setToolTipDuration = QScrollArea.__N.QScrll_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qscrll_setToolTipDuration);
		}

		// Token: 0x06000E64 RID: 3684 RVA: 0x00026E44 File Offset: 0x00025044
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qscrll_autoFillBackground = QScrollArea.__N.QScrll_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_autoFillBackground) > 0;
		}

		// Token: 0x06000E65 RID: 3685 RVA: 0x00026E74 File Offset: 0x00025074
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qscrll_setAutoFillBackground = QScrollArea.__N.QScrll_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qscrll_setAutoFillBackground);
		}

		// Token: 0x04000063 RID: 99
		internal IntPtr self;

		// Token: 0x02000124 RID: 292
		internal static class __N
		{
			// Token: 0x04000F9D RID: 3997
			internal static method From_QAbstractScrollArea_To_QScrollArea;

			// Token: 0x04000F9E RID: 3998
			internal static method To_QAbstractScrollArea_From_QScrollArea;

			// Token: 0x04000F9F RID: 3999
			internal static method From_QFrame_To_QScrollArea;

			// Token: 0x04000FA0 RID: 4000
			internal static method To_QFrame_From_QScrollArea;

			// Token: 0x04000FA1 RID: 4001
			internal static method From_QWidget_To_QScrollArea;

			// Token: 0x04000FA2 RID: 4002
			internal static method To_QWidget_From_QScrollArea;

			// Token: 0x04000FA3 RID: 4003
			internal static method From_QObject_To_QScrollArea;

			// Token: 0x04000FA4 RID: 4004
			internal static method To_QObject_From_QScrollArea;

			// Token: 0x04000FA5 RID: 4005
			internal static method QScrll_CreateQScrollArea;

			// Token: 0x04000FA6 RID: 4006
			internal static method QScrll_ensureVisible;

			// Token: 0x04000FA7 RID: 4007
			internal static method QScrll_ensureWidgetVisible;

			// Token: 0x04000FA8 RID: 4008
			internal static method QScrll_widgetResizable;

			// Token: 0x04000FA9 RID: 4009
			internal static method QScrll_setWidgetResizable;

			// Token: 0x04000FAA RID: 4010
			internal static method QScrll_widget;

			// Token: 0x04000FAB RID: 4011
			internal static method QScrll_setWidget;

			// Token: 0x04000FAC RID: 4012
			internal static method QScrll_horizontalScrollBar;

			// Token: 0x04000FAD RID: 4013
			internal static method QScrll_verticalScrollBar;

			// Token: 0x04000FAE RID: 4014
			internal static method QScrll_horizontalScrollBarPolicy;

			// Token: 0x04000FAF RID: 4015
			internal static method QScrll_setHorizontalScrollBarPolicy;

			// Token: 0x04000FB0 RID: 4016
			internal static method QScrll_verticalScrollBarPolicy;

			// Token: 0x04000FB1 RID: 4017
			internal static method QScrll_setVerticalScrollBarPolicy;

			// Token: 0x04000FB2 RID: 4018
			internal static method QScrll_isTopLevel;

			// Token: 0x04000FB3 RID: 4019
			internal static method QScrll_isWindow;

			// Token: 0x04000FB4 RID: 4020
			internal static method QScrll_isModal;

			// Token: 0x04000FB5 RID: 4021
			internal static method QScrll_setStyleSheet;

			// Token: 0x04000FB6 RID: 4022
			internal static method QScrll_windowTitle;

			// Token: 0x04000FB7 RID: 4023
			internal static method QScrll_setWindowTitle;

			// Token: 0x04000FB8 RID: 4024
			internal static method QScrll_setWindowFlags;

			// Token: 0x04000FB9 RID: 4025
			internal static method QScrll_windowFlags;

			// Token: 0x04000FBA RID: 4026
			internal static method QScrll_size;

			// Token: 0x04000FBB RID: 4027
			internal static method QScrll_resize;

			// Token: 0x04000FBC RID: 4028
			internal static method QScrll_minimumSize;

			// Token: 0x04000FBD RID: 4029
			internal static method QScrll_setMinimumSize;

			// Token: 0x04000FBE RID: 4030
			internal static method QScrll_maximumSize;

			// Token: 0x04000FBF RID: 4031
			internal static method QScrll_setMaximumSize;

			// Token: 0x04000FC0 RID: 4032
			internal static method QScrll_pos;

			// Token: 0x04000FC1 RID: 4033
			internal static method QScrll_move;

			// Token: 0x04000FC2 RID: 4034
			internal static method QScrll_isEnabled;

			// Token: 0x04000FC3 RID: 4035
			internal static method QScrll_setEnabled;

			// Token: 0x04000FC4 RID: 4036
			internal static method QScrll_setVisible;

			// Token: 0x04000FC5 RID: 4037
			internal static method QScrll_setHidden;

			// Token: 0x04000FC6 RID: 4038
			internal static method QScrll_show;

			// Token: 0x04000FC7 RID: 4039
			internal static method QScrll_hide;

			// Token: 0x04000FC8 RID: 4040
			internal static method QScrll_showMinimized;

			// Token: 0x04000FC9 RID: 4041
			internal static method QScrll_showMaximized;

			// Token: 0x04000FCA RID: 4042
			internal static method QScrll_showFullScreen;

			// Token: 0x04000FCB RID: 4043
			internal static method QScrll_showNormal;

			// Token: 0x04000FCC RID: 4044
			internal static method QScrll_close;

			// Token: 0x04000FCD RID: 4045
			internal static method QScrll_raise;

			// Token: 0x04000FCE RID: 4046
			internal static method QScrll_lower;

			// Token: 0x04000FCF RID: 4047
			internal static method QScrll_isVisible;

			// Token: 0x04000FD0 RID: 4048
			internal static method QScrll_setAttribute;

			// Token: 0x04000FD1 RID: 4049
			internal static method QScrll_testAttribute;

			// Token: 0x04000FD2 RID: 4050
			internal static method QScrll_acceptDrops;

			// Token: 0x04000FD3 RID: 4051
			internal static method QScrll_setAcceptDrops;

			// Token: 0x04000FD4 RID: 4052
			internal static method QScrll_update;

			// Token: 0x04000FD5 RID: 4053
			internal static method QScrll_repaint;

			// Token: 0x04000FD6 RID: 4054
			internal static method QScrll_setCursor;

			// Token: 0x04000FD7 RID: 4055
			internal static method QScrll_unsetCursor;

			// Token: 0x04000FD8 RID: 4056
			internal static method QScrll_setWindowIcon;

			// Token: 0x04000FD9 RID: 4057
			internal static method QScrll_setWindowIconText;

			// Token: 0x04000FDA RID: 4058
			internal static method QScrll_setWindowOpacity;

			// Token: 0x04000FDB RID: 4059
			internal static method QScrll_windowOpacity;

			// Token: 0x04000FDC RID: 4060
			internal static method QScrll_isMinimized;

			// Token: 0x04000FDD RID: 4061
			internal static method QScrll_isMaximized;

			// Token: 0x04000FDE RID: 4062
			internal static method QScrll_isFullScreen;

			// Token: 0x04000FDF RID: 4063
			internal static method QScrll_setMouseTracking;

			// Token: 0x04000FE0 RID: 4064
			internal static method QScrll_hasMouseTracking;

			// Token: 0x04000FE1 RID: 4065
			internal static method QScrll_underMouse;

			// Token: 0x04000FE2 RID: 4066
			internal static method QScrll_mapToGlobal;

			// Token: 0x04000FE3 RID: 4067
			internal static method QScrll_mapFromGlobal;

			// Token: 0x04000FE4 RID: 4068
			internal static method QScrll_hasFocus;

			// Token: 0x04000FE5 RID: 4069
			internal static method QScrll_focusPolicy;

			// Token: 0x04000FE6 RID: 4070
			internal static method QScrll_setFocusPolicy;

			// Token: 0x04000FE7 RID: 4071
			internal static method QScrll_setFocusProxy;

			// Token: 0x04000FE8 RID: 4072
			internal static method QScrll_isActiveWindow;

			// Token: 0x04000FE9 RID: 4073
			internal static method QScrll_updatesEnabled;

			// Token: 0x04000FEA RID: 4074
			internal static method QScrll_setUpdatesEnabled;

			// Token: 0x04000FEB RID: 4075
			internal static method QScrll_setFocus;

			// Token: 0x04000FEC RID: 4076
			internal static method QScrll_activateWindow;

			// Token: 0x04000FED RID: 4077
			internal static method QScrll_clearFocus;

			// Token: 0x04000FEE RID: 4078
			internal static method QScrll_setSizePolicy;

			// Token: 0x04000FEF RID: 4079
			internal static method QScrll_devicePixelRatioF;

			// Token: 0x04000FF0 RID: 4080
			internal static method QScrll_saveGeometry;

			// Token: 0x04000FF1 RID: 4081
			internal static method QScrll_restoreGeometry;

			// Token: 0x04000FF2 RID: 4082
			internal static method QScrll_addAction;

			// Token: 0x04000FF3 RID: 4083
			internal static method QScrll_removeAction;

			// Token: 0x04000FF4 RID: 4084
			internal static method QScrll_setParent;

			// Token: 0x04000FF5 RID: 4085
			internal static method QScrll_parentWidget;

			// Token: 0x04000FF6 RID: 4086
			internal static method QScrll_AddClassName;

			// Token: 0x04000FF7 RID: 4087
			internal static method QScrll_Polish;

			// Token: 0x04000FF8 RID: 4088
			internal static method QScrll_toolTip;

			// Token: 0x04000FF9 RID: 4089
			internal static method QScrll_setToolTip;

			// Token: 0x04000FFA RID: 4090
			internal static method QScrll_statusTip;

			// Token: 0x04000FFB RID: 4091
			internal static method QScrll_setStatusTip;

			// Token: 0x04000FFC RID: 4092
			internal static method QScrll_toolTipDuration;

			// Token: 0x04000FFD RID: 4093
			internal static method QScrll_setToolTipDuration;

			// Token: 0x04000FFE RID: 4094
			internal static method QScrll_autoFillBackground;

			// Token: 0x04000FFF RID: 4095
			internal static method QScrll_setAutoFillBackground;
		}
	}
}
