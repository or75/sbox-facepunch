using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x0200004C RID: 76
	internal struct QLabel
	{
		// Token: 0x060009F7 RID: 2551 RVA: 0x0001AFD1 File Offset: 0x000191D1
		public static implicit operator IntPtr(QLabel value)
		{
			return value.self;
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x0001AFDC File Offset: 0x000191DC
		public static implicit operator QLabel(IntPtr value)
		{
			return new QLabel
			{
				self = value
			};
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x0001AFFA File Offset: 0x000191FA
		public static bool operator ==(QLabel c1, QLabel c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x0001B00D File Offset: 0x0001920D
		public static bool operator !=(QLabel c1, QLabel c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x0001B020 File Offset: 0x00019220
		public override bool Equals(object obj)
		{
			if (obj is QLabel)
			{
				QLabel c = (QLabel)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x0001B04A File Offset: 0x0001924A
		internal QLabel(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x0001B054 File Offset: 0x00019254
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QLabel ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060009FE RID: 2558 RVA: 0x0001B08F File Offset: 0x0001928F
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060009FF RID: 2559 RVA: 0x0001B0A1 File Offset: 0x000192A1
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x0001B0AC File Offset: 0x000192AC
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x0001B0BF File Offset: 0x000192BF
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QLabel was null when calling " + n);
			}
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x0001B0DA File Offset: 0x000192DA
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x0001B0E8 File Offset: 0x000192E8
		public static implicit operator QFrame(QLabel value)
		{
			method to_QFrame_From_QLabel = QLabel.__N.To_QFrame_From_QLabel;
			return calli(System.IntPtr(System.IntPtr), value, to_QFrame_From_QLabel);
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x0001B10C File Offset: 0x0001930C
		public static explicit operator QLabel(QFrame value)
		{
			method from_QFrame_To_QLabel = QLabel.__N.From_QFrame_To_QLabel;
			return calli(System.IntPtr(System.IntPtr), value, from_QFrame_To_QLabel);
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x0001B130 File Offset: 0x00019330
		public static implicit operator QWidget(QLabel value)
		{
			method to_QWidget_From_QLabel = QLabel.__N.To_QWidget_From_QLabel;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QLabel);
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x0001B154 File Offset: 0x00019354
		public static explicit operator QLabel(QWidget value)
		{
			method from_QWidget_To_QLabel = QLabel.__N.From_QWidget_To_QLabel;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QLabel);
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x0001B178 File Offset: 0x00019378
		public static implicit operator QObject(QLabel value)
		{
			method to_QObject_From_QLabel = QLabel.__N.To_QObject_From_QLabel;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QLabel);
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x0001B19C File Offset: 0x0001939C
		public static explicit operator QLabel(QObject value)
		{
			method from_QObject_To_QLabel = QLabel.__N.From_QObject_To_QLabel;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QLabel);
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x0001B1C0 File Offset: 0x000193C0
		internal static QLabel Create(QWidget parent)
		{
			method qlabel_Create = QLabel.__N.QLabel_Create;
			return calli(System.IntPtr(System.IntPtr), parent, qlabel_Create);
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x0001B1E4 File Offset: 0x000193E4
		internal static QLabel Create(string title, QWidget parent)
		{
			method qlabel_f = QLabel.__N.QLabel_f2;
			return calli(System.IntPtr(System.IntPtr,System.IntPtr), Interop.GetWPointer(title), parent, qlabel_f);
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x0001B210 File Offset: 0x00019410
		internal readonly void setText(string text)
		{
			this.NullCheck("setText");
			method qlabel_setText = QLabel.__N.QLabel_setText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qlabel_setText);
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x0001B240 File Offset: 0x00019440
		internal readonly string text()
		{
			this.NullCheck("text");
			method qlabel_text = QLabel.__N.QLabel_text;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlabel_text));
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x0001B270 File Offset: 0x00019470
		internal readonly void setWordWrap(bool on)
		{
			this.NullCheck("setWordWrap");
			method qlabel_setWordWrap = QLabel.__N.QLabel_setWordWrap;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qlabel_setWordWrap);
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x0001B2A4 File Offset: 0x000194A4
		internal readonly bool wordWrap()
		{
			this.NullCheck("wordWrap");
			method qlabel_wordWrap = QLabel.__N.QLabel_wordWrap;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_wordWrap) > 0;
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x0001B2D4 File Offset: 0x000194D4
		internal readonly int indent()
		{
			this.NullCheck("indent");
			method qlabel_indent = QLabel.__N.QLabel_indent;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_indent);
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x0001B300 File Offset: 0x00019500
		internal readonly void setIndent(int none)
		{
			this.NullCheck("setIndent");
			method qlabel_setIndent = QLabel.__N.QLabel_setIndent;
			calli(System.Void(System.IntPtr,System.Int32), this.self, none, qlabel_setIndent);
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x0001B32C File Offset: 0x0001952C
		internal readonly int margin()
		{
			this.NullCheck("margin");
			method qlabel_margin = QLabel.__N.QLabel_margin;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_margin);
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x0001B358 File Offset: 0x00019558
		internal readonly void setMargin(int none)
		{
			this.NullCheck("setMargin");
			method qlabel_setMargin = QLabel.__N.QLabel_setMargin;
			calli(System.Void(System.IntPtr,System.Int32), this.self, none, qlabel_setMargin);
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x0001B384 File Offset: 0x00019584
		internal readonly bool openExternalLinks()
		{
			this.NullCheck("openExternalLinks");
			method qlabel_openExternalLinks = QLabel.__N.QLabel_openExternalLinks;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_openExternalLinks) > 0;
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x0001B3B4 File Offset: 0x000195B4
		internal readonly void setOpenExternalLinks(bool open)
		{
			this.NullCheck("setOpenExternalLinks");
			method qlabel_setOpenExternalLinks = QLabel.__N.QLabel_setOpenExternalLinks;
			calli(System.Void(System.IntPtr,System.Int32), this.self, open ? 1 : 0, qlabel_setOpenExternalLinks);
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x0001B3E8 File Offset: 0x000195E8
		internal readonly bool hasSelectedText()
		{
			this.NullCheck("hasSelectedText");
			method qlabel_hasSelectedText = QLabel.__N.QLabel_hasSelectedText;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_hasSelectedText) > 0;
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x0001B418 File Offset: 0x00019618
		internal readonly string selectedText()
		{
			this.NullCheck("selectedText");
			method qlabel_selectedText = QLabel.__N.QLabel_selectedText;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlabel_selectedText));
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x0001B448 File Offset: 0x00019648
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qlabel_isTopLevel = QLabel.__N.QLabel_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_isTopLevel) > 0;
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x0001B478 File Offset: 0x00019678
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qlabel_isWindow = QLabel.__N.QLabel_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_isWindow) > 0;
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x0001B4A8 File Offset: 0x000196A8
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qlabel_isModal = QLabel.__N.QLabel_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_isModal) > 0;
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x0001B4D8 File Offset: 0x000196D8
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qlabel_setStyleSheet = QLabel.__N.QLabel_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qlabel_setStyleSheet);
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x0001B508 File Offset: 0x00019708
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qlabel_windowTitle = QLabel.__N.QLabel_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlabel_windowTitle));
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x0001B538 File Offset: 0x00019738
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qlabel_setWindowTitle = QLabel.__N.QLabel_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qlabel_setWindowTitle);
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x0001B568 File Offset: 0x00019768
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qlabel_setWindowFlags = QLabel.__N.QLabel_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qlabel_setWindowFlags);
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x0001B594 File Offset: 0x00019794
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qlabel_windowFlags = QLabel.__N.QLabel_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qlabel_windowFlags);
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x0001B5C0 File Offset: 0x000197C0
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qlabel_size = QLabel.__N.QLabel_size;
			return calli(Vector3(System.IntPtr), this.self, qlabel_size);
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x0001B5EC File Offset: 0x000197EC
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qlabel_resize = QLabel.__N.QLabel_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qlabel_resize);
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x0001B618 File Offset: 0x00019818
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qlabel_minimumSize = QLabel.__N.QLabel_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qlabel_minimumSize);
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x0001B644 File Offset: 0x00019844
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qlabel_setMinimumSize = QLabel.__N.QLabel_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qlabel_setMinimumSize);
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x0001B670 File Offset: 0x00019870
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qlabel_maximumSize = QLabel.__N.QLabel_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qlabel_maximumSize);
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x0001B69C File Offset: 0x0001989C
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qlabel_setMaximumSize = QLabel.__N.QLabel_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qlabel_setMaximumSize);
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x0001B6C8 File Offset: 0x000198C8
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qlabel_pos = QLabel.__N.QLabel_pos;
			return calli(Vector3(System.IntPtr), this.self, qlabel_pos);
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x0001B6F4 File Offset: 0x000198F4
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qlabel_move = QLabel.__N.QLabel_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qlabel_move);
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x0001B720 File Offset: 0x00019920
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qlabel_isEnabled = QLabel.__N.QLabel_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_isEnabled) > 0;
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x0001B750 File Offset: 0x00019950
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qlabel_setEnabled = QLabel.__N.QLabel_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qlabel_setEnabled);
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x0001B784 File Offset: 0x00019984
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qlabel_setVisible = QLabel.__N.QLabel_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qlabel_setVisible);
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x0001B7B8 File Offset: 0x000199B8
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qlabel_setHidden = QLabel.__N.QLabel_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qlabel_setHidden);
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x0001B7EC File Offset: 0x000199EC
		internal readonly void show()
		{
			this.NullCheck("show");
			method qlabel_show = QLabel.__N.QLabel_show;
			calli(System.Void(System.IntPtr), this.self, qlabel_show);
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x0001B818 File Offset: 0x00019A18
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qlabel_hide = QLabel.__N.QLabel_hide;
			calli(System.Void(System.IntPtr), this.self, qlabel_hide);
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x0001B844 File Offset: 0x00019A44
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qlabel_showMinimized = QLabel.__N.QLabel_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qlabel_showMinimized);
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x0001B870 File Offset: 0x00019A70
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qlabel_showMaximized = QLabel.__N.QLabel_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qlabel_showMaximized);
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x0001B89C File Offset: 0x00019A9C
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qlabel_showFullScreen = QLabel.__N.QLabel_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qlabel_showFullScreen);
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x0001B8C8 File Offset: 0x00019AC8
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qlabel_showNormal = QLabel.__N.QLabel_showNormal;
			calli(System.Void(System.IntPtr), this.self, qlabel_showNormal);
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x0001B8F4 File Offset: 0x00019AF4
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qlabel_close = QLabel.__N.QLabel_close;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_close) > 0;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x0001B924 File Offset: 0x00019B24
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qlabel_raise = QLabel.__N.QLabel_raise;
			calli(System.Void(System.IntPtr), this.self, qlabel_raise);
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x0001B950 File Offset: 0x00019B50
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qlabel_lower = QLabel.__N.QLabel_lower;
			calli(System.Void(System.IntPtr), this.self, qlabel_lower);
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x0001B97C File Offset: 0x00019B7C
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qlabel_isVisible = QLabel.__N.QLabel_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_isVisible) > 0;
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x0001B9AC File Offset: 0x00019BAC
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qlabel_setAttribute = QLabel.__N.QLabel_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qlabel_setAttribute);
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x0001B9E0 File Offset: 0x00019BE0
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qlabel_testAttribute = QLabel.__N.QLabel_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qlabel_testAttribute) > 0;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x0001BA10 File Offset: 0x00019C10
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qlabel_acceptDrops = QLabel.__N.QLabel_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_acceptDrops) > 0;
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x0001BA40 File Offset: 0x00019C40
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qlabel_setAcceptDrops = QLabel.__N.QLabel_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qlabel_setAcceptDrops);
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x0001BA74 File Offset: 0x00019C74
		internal readonly void update()
		{
			this.NullCheck("update");
			method qlabel_update = QLabel.__N.QLabel_update;
			calli(System.Void(System.IntPtr), this.self, qlabel_update);
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x0001BAA0 File Offset: 0x00019CA0
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qlabel_repaint = QLabel.__N.QLabel_repaint;
			calli(System.Void(System.IntPtr), this.self, qlabel_repaint);
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x0001BACC File Offset: 0x00019CCC
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qlabel_setCursor = QLabel.__N.QLabel_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qlabel_setCursor);
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x0001BAF8 File Offset: 0x00019CF8
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qlabel_unsetCursor = QLabel.__N.QLabel_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qlabel_unsetCursor);
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x0001BB24 File Offset: 0x00019D24
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qlabel_setWindowIcon = QLabel.__N.QLabel_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qlabel_setWindowIcon);
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x0001BB54 File Offset: 0x00019D54
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qlabel_setWindowIconText = QLabel.__N.QLabel_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qlabel_setWindowIconText);
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x0001BB84 File Offset: 0x00019D84
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qlabel_setWindowOpacity = QLabel.__N.QLabel_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qlabel_setWindowOpacity);
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x0001BBB0 File Offset: 0x00019DB0
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qlabel_windowOpacity = QLabel.__N.QLabel_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qlabel_windowOpacity);
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x0001BBDC File Offset: 0x00019DDC
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qlabel_isMinimized = QLabel.__N.QLabel_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_isMinimized) > 0;
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x0001BC0C File Offset: 0x00019E0C
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qlabel_isMaximized = QLabel.__N.QLabel_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_isMaximized) > 0;
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x0001BC3C File Offset: 0x00019E3C
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qlabel_isFullScreen = QLabel.__N.QLabel_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_isFullScreen) > 0;
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x0001BC6C File Offset: 0x00019E6C
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qlabel_setMouseTracking = QLabel.__N.QLabel_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qlabel_setMouseTracking);
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x0001BCA0 File Offset: 0x00019EA0
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qlabel_hasMouseTracking = QLabel.__N.QLabel_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_hasMouseTracking) > 0;
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x0001BCD0 File Offset: 0x00019ED0
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qlabel_underMouse = QLabel.__N.QLabel_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_underMouse) > 0;
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x0001BD00 File Offset: 0x00019F00
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qlabel_mapToGlobal = QLabel.__N.QLabel_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qlabel_mapToGlobal);
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x0001BD2C File Offset: 0x00019F2C
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qlabel_mapFromGlobal = QLabel.__N.QLabel_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qlabel_mapFromGlobal);
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x0001BD58 File Offset: 0x00019F58
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qlabel_hasFocus = QLabel.__N.QLabel_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_hasFocus) > 0;
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x0001BD88 File Offset: 0x00019F88
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qlabel_focusPolicy = QLabel.__N.QLabel_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qlabel_focusPolicy);
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x0001BDB4 File Offset: 0x00019FB4
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qlabel_setFocusPolicy = QLabel.__N.QLabel_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qlabel_setFocusPolicy);
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x0001BDE0 File Offset: 0x00019FE0
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qlabel_setFocusProxy = QLabel.__N.QLabel_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qlabel_setFocusProxy);
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x0001BE10 File Offset: 0x0001A010
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qlabel_isActiveWindow = QLabel.__N.QLabel_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_isActiveWindow) > 0;
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x0001BE40 File Offset: 0x0001A040
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qlabel_updatesEnabled = QLabel.__N.QLabel_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_updatesEnabled) > 0;
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x0001BE70 File Offset: 0x0001A070
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qlabel_setUpdatesEnabled = QLabel.__N.QLabel_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qlabel_setUpdatesEnabled);
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x0001BEA4 File Offset: 0x0001A0A4
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qlabel_setFocus = QLabel.__N.QLabel_setFocus;
			calli(System.Void(System.IntPtr), this.self, qlabel_setFocus);
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x0001BED0 File Offset: 0x0001A0D0
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qlabel_activateWindow = QLabel.__N.QLabel_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qlabel_activateWindow);
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x0001BEFC File Offset: 0x0001A0FC
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qlabel_clearFocus = QLabel.__N.QLabel_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qlabel_clearFocus);
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x0001BF28 File Offset: 0x0001A128
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qlabel_setSizePolicy = QLabel.__N.QLabel_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qlabel_setSizePolicy);
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x0001BF58 File Offset: 0x0001A158
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qlabel_devicePixelRatioF = QLabel.__N.QLabel_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qlabel_devicePixelRatioF);
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x0001BF84 File Offset: 0x0001A184
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qlabel_saveGeometry = QLabel.__N.QLabel_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qlabel_saveGeometry));
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x0001BFB4 File Offset: 0x0001A1B4
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qlabel_restoreGeometry = QLabel.__N.QLabel_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qlabel_restoreGeometry) > 0;
		}

		// Token: 0x06000A57 RID: 2647 RVA: 0x0001BFE8 File Offset: 0x0001A1E8
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qlabel_addAction = QLabel.__N.QLabel_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qlabel_addAction);
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x0001C018 File Offset: 0x0001A218
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qlabel_removeAction = QLabel.__N.QLabel_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qlabel_removeAction);
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x0001C048 File Offset: 0x0001A248
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qlabel_setParent = QLabel.__N.QLabel_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qlabel_setParent);
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x0001C078 File Offset: 0x0001A278
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qlabel_parentWidget = QLabel.__N.QLabel_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qlabel_parentWidget);
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x0001C0A8 File Offset: 0x0001A2A8
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qlabel_AddClassName = QLabel.__N.QLabel_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qlabel_AddClassName);
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x0001C0D8 File Offset: 0x0001A2D8
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qlabel_Polish = QLabel.__N.QLabel_Polish;
			calli(System.Void(System.IntPtr), this.self, qlabel_Polish);
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x0001C104 File Offset: 0x0001A304
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qlabel_toolTip = QLabel.__N.QLabel_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlabel_toolTip));
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x0001C134 File Offset: 0x0001A334
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qlabel_setToolTip = QLabel.__N.QLabel_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qlabel_setToolTip);
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x0001C164 File Offset: 0x0001A364
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qlabel_statusTip = QLabel.__N.QLabel_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlabel_statusTip));
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x0001C194 File Offset: 0x0001A394
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qlabel_setStatusTip = QLabel.__N.QLabel_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qlabel_setStatusTip);
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x0001C1C4 File Offset: 0x0001A3C4
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qlabel_toolTipDuration = QLabel.__N.QLabel_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_toolTipDuration);
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x0001C1F0 File Offset: 0x0001A3F0
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qlabel_setToolTipDuration = QLabel.__N.QLabel_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qlabel_setToolTipDuration);
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x0001C21C File Offset: 0x0001A41C
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qlabel_autoFillBackground = QLabel.__N.QLabel_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qlabel_autoFillBackground) > 0;
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x0001C24C File Offset: 0x0001A44C
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qlabel_setAutoFillBackground = QLabel.__N.QLabel_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qlabel_setAutoFillBackground);
		}

		// Token: 0x04000057 RID: 87
		internal IntPtr self;

		// Token: 0x02000118 RID: 280
		internal static class __N
		{
			// Token: 0x04000C2D RID: 3117
			internal static method From_QFrame_To_QLabel;

			// Token: 0x04000C2E RID: 3118
			internal static method To_QFrame_From_QLabel;

			// Token: 0x04000C2F RID: 3119
			internal static method From_QWidget_To_QLabel;

			// Token: 0x04000C30 RID: 3120
			internal static method To_QWidget_From_QLabel;

			// Token: 0x04000C31 RID: 3121
			internal static method From_QObject_To_QLabel;

			// Token: 0x04000C32 RID: 3122
			internal static method To_QObject_From_QLabel;

			// Token: 0x04000C33 RID: 3123
			internal static method QLabel_Create;

			// Token: 0x04000C34 RID: 3124
			internal static method QLabel_f2;

			// Token: 0x04000C35 RID: 3125
			internal static method QLabel_setText;

			// Token: 0x04000C36 RID: 3126
			internal static method QLabel_text;

			// Token: 0x04000C37 RID: 3127
			internal static method QLabel_setWordWrap;

			// Token: 0x04000C38 RID: 3128
			internal static method QLabel_wordWrap;

			// Token: 0x04000C39 RID: 3129
			internal static method QLabel_indent;

			// Token: 0x04000C3A RID: 3130
			internal static method QLabel_setIndent;

			// Token: 0x04000C3B RID: 3131
			internal static method QLabel_margin;

			// Token: 0x04000C3C RID: 3132
			internal static method QLabel_setMargin;

			// Token: 0x04000C3D RID: 3133
			internal static method QLabel_openExternalLinks;

			// Token: 0x04000C3E RID: 3134
			internal static method QLabel_setOpenExternalLinks;

			// Token: 0x04000C3F RID: 3135
			internal static method QLabel_hasSelectedText;

			// Token: 0x04000C40 RID: 3136
			internal static method QLabel_selectedText;

			// Token: 0x04000C41 RID: 3137
			internal static method QLabel_isTopLevel;

			// Token: 0x04000C42 RID: 3138
			internal static method QLabel_isWindow;

			// Token: 0x04000C43 RID: 3139
			internal static method QLabel_isModal;

			// Token: 0x04000C44 RID: 3140
			internal static method QLabel_setStyleSheet;

			// Token: 0x04000C45 RID: 3141
			internal static method QLabel_windowTitle;

			// Token: 0x04000C46 RID: 3142
			internal static method QLabel_setWindowTitle;

			// Token: 0x04000C47 RID: 3143
			internal static method QLabel_setWindowFlags;

			// Token: 0x04000C48 RID: 3144
			internal static method QLabel_windowFlags;

			// Token: 0x04000C49 RID: 3145
			internal static method QLabel_size;

			// Token: 0x04000C4A RID: 3146
			internal static method QLabel_resize;

			// Token: 0x04000C4B RID: 3147
			internal static method QLabel_minimumSize;

			// Token: 0x04000C4C RID: 3148
			internal static method QLabel_setMinimumSize;

			// Token: 0x04000C4D RID: 3149
			internal static method QLabel_maximumSize;

			// Token: 0x04000C4E RID: 3150
			internal static method QLabel_setMaximumSize;

			// Token: 0x04000C4F RID: 3151
			internal static method QLabel_pos;

			// Token: 0x04000C50 RID: 3152
			internal static method QLabel_move;

			// Token: 0x04000C51 RID: 3153
			internal static method QLabel_isEnabled;

			// Token: 0x04000C52 RID: 3154
			internal static method QLabel_setEnabled;

			// Token: 0x04000C53 RID: 3155
			internal static method QLabel_setVisible;

			// Token: 0x04000C54 RID: 3156
			internal static method QLabel_setHidden;

			// Token: 0x04000C55 RID: 3157
			internal static method QLabel_show;

			// Token: 0x04000C56 RID: 3158
			internal static method QLabel_hide;

			// Token: 0x04000C57 RID: 3159
			internal static method QLabel_showMinimized;

			// Token: 0x04000C58 RID: 3160
			internal static method QLabel_showMaximized;

			// Token: 0x04000C59 RID: 3161
			internal static method QLabel_showFullScreen;

			// Token: 0x04000C5A RID: 3162
			internal static method QLabel_showNormal;

			// Token: 0x04000C5B RID: 3163
			internal static method QLabel_close;

			// Token: 0x04000C5C RID: 3164
			internal static method QLabel_raise;

			// Token: 0x04000C5D RID: 3165
			internal static method QLabel_lower;

			// Token: 0x04000C5E RID: 3166
			internal static method QLabel_isVisible;

			// Token: 0x04000C5F RID: 3167
			internal static method QLabel_setAttribute;

			// Token: 0x04000C60 RID: 3168
			internal static method QLabel_testAttribute;

			// Token: 0x04000C61 RID: 3169
			internal static method QLabel_acceptDrops;

			// Token: 0x04000C62 RID: 3170
			internal static method QLabel_setAcceptDrops;

			// Token: 0x04000C63 RID: 3171
			internal static method QLabel_update;

			// Token: 0x04000C64 RID: 3172
			internal static method QLabel_repaint;

			// Token: 0x04000C65 RID: 3173
			internal static method QLabel_setCursor;

			// Token: 0x04000C66 RID: 3174
			internal static method QLabel_unsetCursor;

			// Token: 0x04000C67 RID: 3175
			internal static method QLabel_setWindowIcon;

			// Token: 0x04000C68 RID: 3176
			internal static method QLabel_setWindowIconText;

			// Token: 0x04000C69 RID: 3177
			internal static method QLabel_setWindowOpacity;

			// Token: 0x04000C6A RID: 3178
			internal static method QLabel_windowOpacity;

			// Token: 0x04000C6B RID: 3179
			internal static method QLabel_isMinimized;

			// Token: 0x04000C6C RID: 3180
			internal static method QLabel_isMaximized;

			// Token: 0x04000C6D RID: 3181
			internal static method QLabel_isFullScreen;

			// Token: 0x04000C6E RID: 3182
			internal static method QLabel_setMouseTracking;

			// Token: 0x04000C6F RID: 3183
			internal static method QLabel_hasMouseTracking;

			// Token: 0x04000C70 RID: 3184
			internal static method QLabel_underMouse;

			// Token: 0x04000C71 RID: 3185
			internal static method QLabel_mapToGlobal;

			// Token: 0x04000C72 RID: 3186
			internal static method QLabel_mapFromGlobal;

			// Token: 0x04000C73 RID: 3187
			internal static method QLabel_hasFocus;

			// Token: 0x04000C74 RID: 3188
			internal static method QLabel_focusPolicy;

			// Token: 0x04000C75 RID: 3189
			internal static method QLabel_setFocusPolicy;

			// Token: 0x04000C76 RID: 3190
			internal static method QLabel_setFocusProxy;

			// Token: 0x04000C77 RID: 3191
			internal static method QLabel_isActiveWindow;

			// Token: 0x04000C78 RID: 3192
			internal static method QLabel_updatesEnabled;

			// Token: 0x04000C79 RID: 3193
			internal static method QLabel_setUpdatesEnabled;

			// Token: 0x04000C7A RID: 3194
			internal static method QLabel_setFocus;

			// Token: 0x04000C7B RID: 3195
			internal static method QLabel_activateWindow;

			// Token: 0x04000C7C RID: 3196
			internal static method QLabel_clearFocus;

			// Token: 0x04000C7D RID: 3197
			internal static method QLabel_setSizePolicy;

			// Token: 0x04000C7E RID: 3198
			internal static method QLabel_devicePixelRatioF;

			// Token: 0x04000C7F RID: 3199
			internal static method QLabel_saveGeometry;

			// Token: 0x04000C80 RID: 3200
			internal static method QLabel_restoreGeometry;

			// Token: 0x04000C81 RID: 3201
			internal static method QLabel_addAction;

			// Token: 0x04000C82 RID: 3202
			internal static method QLabel_removeAction;

			// Token: 0x04000C83 RID: 3203
			internal static method QLabel_setParent;

			// Token: 0x04000C84 RID: 3204
			internal static method QLabel_parentWidget;

			// Token: 0x04000C85 RID: 3205
			internal static method QLabel_AddClassName;

			// Token: 0x04000C86 RID: 3206
			internal static method QLabel_Polish;

			// Token: 0x04000C87 RID: 3207
			internal static method QLabel_toolTip;

			// Token: 0x04000C88 RID: 3208
			internal static method QLabel_setToolTip;

			// Token: 0x04000C89 RID: 3209
			internal static method QLabel_statusTip;

			// Token: 0x04000C8A RID: 3210
			internal static method QLabel_setStatusTip;

			// Token: 0x04000C8B RID: 3211
			internal static method QLabel_toolTipDuration;

			// Token: 0x04000C8C RID: 3212
			internal static method QLabel_setToolTipDuration;

			// Token: 0x04000C8D RID: 3213
			internal static method QLabel_autoFillBackground;

			// Token: 0x04000C8E RID: 3214
			internal static method QLabel_setAutoFillBackground;
		}
	}
}
