using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x0200004E RID: 78
	internal struct QLineEdit
	{
		// Token: 0x06000A82 RID: 2690 RVA: 0x0001C6B6 File Offset: 0x0001A8B6
		public static implicit operator IntPtr(QLineEdit value)
		{
			return value.self;
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x0001C6C0 File Offset: 0x0001A8C0
		public static implicit operator QLineEdit(IntPtr value)
		{
			return new QLineEdit
			{
				self = value
			};
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x0001C6DE File Offset: 0x0001A8DE
		public static bool operator ==(QLineEdit c1, QLineEdit c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x0001C6F1 File Offset: 0x0001A8F1
		public static bool operator !=(QLineEdit c1, QLineEdit c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x0001C704 File Offset: 0x0001A904
		public override bool Equals(object obj)
		{
			if (obj is QLineEdit)
			{
				QLineEdit c = (QLineEdit)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x0001C72E File Offset: 0x0001A92E
		internal QLineEdit(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x0001C738 File Offset: 0x0001A938
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QLineEdit ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000A89 RID: 2697 RVA: 0x0001C774 File Offset: 0x0001A974
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000A8A RID: 2698 RVA: 0x0001C786 File Offset: 0x0001A986
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x0001C791 File Offset: 0x0001A991
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x0001C7A4 File Offset: 0x0001A9A4
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QLineEdit was null when calling " + n);
			}
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x0001C7BF File Offset: 0x0001A9BF
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x0001C7CC File Offset: 0x0001A9CC
		public static implicit operator QWidget(QLineEdit value)
		{
			method to_QWidget_From_QLineEdit = QLineEdit.__N.To_QWidget_From_QLineEdit;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QLineEdit);
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x0001C7F0 File Offset: 0x0001A9F0
		public static explicit operator QLineEdit(QWidget value)
		{
			method from_QWidget_To_QLineEdit = QLineEdit.__N.From_QWidget_To_QLineEdit;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QLineEdit);
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x0001C814 File Offset: 0x0001AA14
		public static implicit operator QObject(QLineEdit value)
		{
			method to_QObject_From_QLineEdit = QLineEdit.__N.To_QObject_From_QLineEdit;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QLineEdit);
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x0001C838 File Offset: 0x0001AA38
		public static explicit operator QLineEdit(QObject value)
		{
			method from_QObject_To_QLineEdit = QLineEdit.__N.From_QObject_To_QLineEdit;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QLineEdit);
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0001C85C File Offset: 0x0001AA5C
		internal readonly void setText(string text)
		{
			this.NullCheck("setText");
			method qlneEd_setText = QLineEdit.__N.QLneEd_setText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qlneEd_setText);
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x0001C88C File Offset: 0x0001AA8C
		internal readonly string text()
		{
			this.NullCheck("text");
			method qlneEd_text = QLineEdit.__N.QLneEd_text;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlneEd_text));
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x0001C8BC File Offset: 0x0001AABC
		internal readonly string displayText()
		{
			this.NullCheck("displayText");
			method qlneEd_displayText = QLineEdit.__N.QLneEd_displayText;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlneEd_displayText));
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x0001C8EC File Offset: 0x0001AAEC
		internal readonly string placeholderText()
		{
			this.NullCheck("placeholderText");
			method qlneEd_placeholderText = QLineEdit.__N.QLneEd_placeholderText;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlneEd_placeholderText));
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x0001C91C File Offset: 0x0001AB1C
		internal readonly void setPlaceholderText(string str)
		{
			this.NullCheck("setPlaceholderText");
			method qlneEd_setPlaceholderText = QLineEdit.__N.QLneEd_setPlaceholderText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qlneEd_setPlaceholderText);
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x0001C94C File Offset: 0x0001AB4C
		internal readonly int maxLength()
		{
			this.NullCheck("maxLength");
			method qlneEd_maxLength = QLineEdit.__N.QLneEd_maxLength;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_maxLength);
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x0001C978 File Offset: 0x0001AB78
		internal readonly void setMaxLength(int x)
		{
			this.NullCheck("setMaxLength");
			method qlneEd_setMaxLength = QLineEdit.__N.QLneEd_setMaxLength;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qlneEd_setMaxLength);
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x0001C9A4 File Offset: 0x0001ABA4
		internal readonly void setFrame(bool x)
		{
			this.NullCheck("setFrame");
			method qlneEd_setFrame = QLineEdit.__N.QLneEd_setFrame;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qlneEd_setFrame);
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x0001C9D8 File Offset: 0x0001ABD8
		internal readonly bool hasFrame()
		{
			this.NullCheck("hasFrame");
			method qlneEd_hasFrame = QLineEdit.__N.QLneEd_hasFrame;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_hasFrame) > 0;
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x0001CA08 File Offset: 0x0001AC08
		internal readonly void setClearButtonEnabled(bool enable)
		{
			this.NullCheck("setClearButtonEnabled");
			method qlneEd_setClearButtonEnabled = QLineEdit.__N.QLneEd_setClearButtonEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qlneEd_setClearButtonEnabled);
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x0001CA3C File Offset: 0x0001AC3C
		internal readonly bool isClearButtonEnabled()
		{
			this.NullCheck("isClearButtonEnabled");
			method qlneEd_isClearButtonEnabled = QLineEdit.__N.QLneEd_isClearButtonEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_isClearButtonEnabled) > 0;
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x0001CA6C File Offset: 0x0001AC6C
		internal readonly bool isReadOnly()
		{
			this.NullCheck("isReadOnly");
			method qlneEd_isReadOnly = QLineEdit.__N.QLneEd_isReadOnly;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_isReadOnly) > 0;
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x0001CA9C File Offset: 0x0001AC9C
		internal readonly void setReadOnly(bool x)
		{
			this.NullCheck("setReadOnly");
			method qlneEd_setReadOnly = QLineEdit.__N.QLneEd_setReadOnly;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qlneEd_setReadOnly);
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x0001CAD0 File Offset: 0x0001ACD0
		internal readonly int cursorPosition()
		{
			this.NullCheck("cursorPosition");
			method qlneEd_cursorPosition = QLineEdit.__N.QLneEd_cursorPosition;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_cursorPosition);
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x0001CAFC File Offset: 0x0001ACFC
		internal readonly void setCursorPosition(int x)
		{
			this.NullCheck("setCursorPosition");
			method qlneEd_setCursorPosition = QLineEdit.__N.QLneEd_setCursorPosition;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qlneEd_setCursorPosition);
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x0001CB28 File Offset: 0x0001AD28
		internal readonly bool hasSelectedText()
		{
			this.NullCheck("hasSelectedText");
			method qlneEd_hasSelectedText = QLineEdit.__N.QLneEd_hasSelectedText;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_hasSelectedText) > 0;
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x0001CB58 File Offset: 0x0001AD58
		internal readonly string selectedText()
		{
			this.NullCheck("selectedText");
			method qlneEd_selectedText = QLineEdit.__N.QLneEd_selectedText;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlneEd_selectedText));
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x0001CB88 File Offset: 0x0001AD88
		internal readonly void clear()
		{
			this.NullCheck("clear");
			method qlneEd_clear = QLineEdit.__N.QLneEd_clear;
			calli(System.Void(System.IntPtr), this.self, qlneEd_clear);
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x0001CBB4 File Offset: 0x0001ADB4
		internal readonly void selectAll()
		{
			this.NullCheck("selectAll");
			method qlneEd_selectAll = QLineEdit.__N.QLneEd_selectAll;
			calli(System.Void(System.IntPtr), this.self, qlneEd_selectAll);
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x0001CBE0 File Offset: 0x0001ADE0
		internal readonly void undo()
		{
			this.NullCheck("undo");
			method qlneEd_undo = QLineEdit.__N.QLneEd_undo;
			calli(System.Void(System.IntPtr), this.self, qlneEd_undo);
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x0001CC0C File Offset: 0x0001AE0C
		internal readonly void redo()
		{
			this.NullCheck("redo");
			method qlneEd_redo = QLineEdit.__N.QLneEd_redo;
			calli(System.Void(System.IntPtr), this.self, qlneEd_redo);
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x0001CC38 File Offset: 0x0001AE38
		internal readonly void cut()
		{
			this.NullCheck("cut");
			method qlneEd_cut = QLineEdit.__N.QLneEd_cut;
			calli(System.Void(System.IntPtr), this.self, qlneEd_cut);
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x0001CC64 File Offset: 0x0001AE64
		internal readonly void copy()
		{
			this.NullCheck("copy");
			method qlneEd_copy = QLineEdit.__N.QLneEd_copy;
			calli(System.Void(System.IntPtr), this.self, qlneEd_copy);
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x0001CC90 File Offset: 0x0001AE90
		internal readonly void paste()
		{
			this.NullCheck("paste");
			method qlneEd_paste = QLineEdit.__N.QLneEd_paste;
			calli(System.Void(System.IntPtr), this.self, qlneEd_paste);
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x0001CCBC File Offset: 0x0001AEBC
		internal readonly void deselect()
		{
			this.NullCheck("deselect");
			method qlneEd_deselect = QLineEdit.__N.QLneEd_deselect;
			calli(System.Void(System.IntPtr), this.self, qlneEd_deselect);
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x0001CCE8 File Offset: 0x0001AEE8
		internal readonly void insert(string x)
		{
			this.NullCheck("insert");
			method qlneEd_insert = QLineEdit.__N.QLneEd_insert;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(x), qlneEd_insert);
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x0001CD18 File Offset: 0x0001AF18
		internal readonly void addAction(QAction action, int position)
		{
			this.NullCheck("addAction");
			method qlneEd_addAction = QLineEdit.__N.QLneEd_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, action, position, qlneEd_addAction);
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x0001CD4C File Offset: 0x0001AF4C
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qlneEd_isTopLevel = QLineEdit.__N.QLneEd_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_isTopLevel) > 0;
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x0001CD7C File Offset: 0x0001AF7C
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qlneEd_isWindow = QLineEdit.__N.QLneEd_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_isWindow) > 0;
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x0001CDAC File Offset: 0x0001AFAC
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qlneEd_isModal = QLineEdit.__N.QLneEd_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_isModal) > 0;
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x0001CDDC File Offset: 0x0001AFDC
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qlneEd_setStyleSheet = QLineEdit.__N.QLneEd_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qlneEd_setStyleSheet);
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x0001CE0C File Offset: 0x0001B00C
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qlneEd_windowTitle = QLineEdit.__N.QLneEd_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlneEd_windowTitle));
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x0001CE3C File Offset: 0x0001B03C
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qlneEd_setWindowTitle = QLineEdit.__N.QLneEd_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qlneEd_setWindowTitle);
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x0001CE6C File Offset: 0x0001B06C
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qlneEd_setWindowFlags = QLineEdit.__N.QLneEd_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qlneEd_setWindowFlags);
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x0001CE98 File Offset: 0x0001B098
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qlneEd_windowFlags = QLineEdit.__N.QLneEd_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qlneEd_windowFlags);
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x0001CEC4 File Offset: 0x0001B0C4
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qlneEd_size = QLineEdit.__N.QLneEd_size;
			return calli(Vector3(System.IntPtr), this.self, qlneEd_size);
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x0001CEF0 File Offset: 0x0001B0F0
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qlneEd_resize = QLineEdit.__N.QLneEd_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qlneEd_resize);
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x0001CF1C File Offset: 0x0001B11C
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qlneEd_minimumSize = QLineEdit.__N.QLneEd_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qlneEd_minimumSize);
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x0001CF48 File Offset: 0x0001B148
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qlneEd_setMinimumSize = QLineEdit.__N.QLneEd_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qlneEd_setMinimumSize);
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x0001CF74 File Offset: 0x0001B174
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qlneEd_maximumSize = QLineEdit.__N.QLneEd_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qlneEd_maximumSize);
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x0001CFA0 File Offset: 0x0001B1A0
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qlneEd_setMaximumSize = QLineEdit.__N.QLneEd_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qlneEd_setMaximumSize);
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x0001CFCC File Offset: 0x0001B1CC
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qlneEd_pos = QLineEdit.__N.QLneEd_pos;
			return calli(Vector3(System.IntPtr), this.self, qlneEd_pos);
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x0001CFF8 File Offset: 0x0001B1F8
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qlneEd_move = QLineEdit.__N.QLneEd_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qlneEd_move);
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x0001D024 File Offset: 0x0001B224
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qlneEd_isEnabled = QLineEdit.__N.QLneEd_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_isEnabled) > 0;
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x0001D054 File Offset: 0x0001B254
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qlneEd_setEnabled = QLineEdit.__N.QLneEd_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qlneEd_setEnabled);
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x0001D088 File Offset: 0x0001B288
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qlneEd_setVisible = QLineEdit.__N.QLneEd_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qlneEd_setVisible);
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x0001D0BC File Offset: 0x0001B2BC
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qlneEd_setHidden = QLineEdit.__N.QLneEd_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qlneEd_setHidden);
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x0001D0F0 File Offset: 0x0001B2F0
		internal readonly void show()
		{
			this.NullCheck("show");
			method qlneEd_show = QLineEdit.__N.QLneEd_show;
			calli(System.Void(System.IntPtr), this.self, qlneEd_show);
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x0001D11C File Offset: 0x0001B31C
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qlneEd_hide = QLineEdit.__N.QLneEd_hide;
			calli(System.Void(System.IntPtr), this.self, qlneEd_hide);
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x0001D148 File Offset: 0x0001B348
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qlneEd_showMinimized = QLineEdit.__N.QLneEd_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qlneEd_showMinimized);
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x0001D174 File Offset: 0x0001B374
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qlneEd_showMaximized = QLineEdit.__N.QLneEd_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qlneEd_showMaximized);
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x0001D1A0 File Offset: 0x0001B3A0
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qlneEd_showFullScreen = QLineEdit.__N.QLneEd_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qlneEd_showFullScreen);
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x0001D1CC File Offset: 0x0001B3CC
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qlneEd_showNormal = QLineEdit.__N.QLneEd_showNormal;
			calli(System.Void(System.IntPtr), this.self, qlneEd_showNormal);
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x0001D1F8 File Offset: 0x0001B3F8
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qlneEd_close = QLineEdit.__N.QLneEd_close;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_close) > 0;
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x0001D228 File Offset: 0x0001B428
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qlneEd_raise = QLineEdit.__N.QLneEd_raise;
			calli(System.Void(System.IntPtr), this.self, qlneEd_raise);
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x0001D254 File Offset: 0x0001B454
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qlneEd_lower = QLineEdit.__N.QLneEd_lower;
			calli(System.Void(System.IntPtr), this.self, qlneEd_lower);
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x0001D280 File Offset: 0x0001B480
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qlneEd_isVisible = QLineEdit.__N.QLneEd_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_isVisible) > 0;
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x0001D2B0 File Offset: 0x0001B4B0
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qlneEd_setAttribute = QLineEdit.__N.QLneEd_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qlneEd_setAttribute);
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x0001D2E4 File Offset: 0x0001B4E4
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qlneEd_testAttribute = QLineEdit.__N.QLneEd_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qlneEd_testAttribute) > 0;
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x0001D314 File Offset: 0x0001B514
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qlneEd_acceptDrops = QLineEdit.__N.QLneEd_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_acceptDrops) > 0;
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x0001D344 File Offset: 0x0001B544
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qlneEd_setAcceptDrops = QLineEdit.__N.QLneEd_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qlneEd_setAcceptDrops);
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x0001D378 File Offset: 0x0001B578
		internal readonly void update()
		{
			this.NullCheck("update");
			method qlneEd_update = QLineEdit.__N.QLneEd_update;
			calli(System.Void(System.IntPtr), this.self, qlneEd_update);
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x0001D3A4 File Offset: 0x0001B5A4
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qlneEd_repaint = QLineEdit.__N.QLneEd_repaint;
			calli(System.Void(System.IntPtr), this.self, qlneEd_repaint);
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x0001D3D0 File Offset: 0x0001B5D0
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qlneEd_setCursor = QLineEdit.__N.QLneEd_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qlneEd_setCursor);
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x0001D3FC File Offset: 0x0001B5FC
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qlneEd_unsetCursor = QLineEdit.__N.QLneEd_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qlneEd_unsetCursor);
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x0001D428 File Offset: 0x0001B628
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qlneEd_setWindowIcon = QLineEdit.__N.QLneEd_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qlneEd_setWindowIcon);
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x0001D458 File Offset: 0x0001B658
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qlneEd_setWindowIconText = QLineEdit.__N.QLneEd_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qlneEd_setWindowIconText);
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x0001D488 File Offset: 0x0001B688
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qlneEd_setWindowOpacity = QLineEdit.__N.QLneEd_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qlneEd_setWindowOpacity);
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x0001D4B4 File Offset: 0x0001B6B4
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qlneEd_windowOpacity = QLineEdit.__N.QLneEd_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qlneEd_windowOpacity);
		}

		// Token: 0x06000AD7 RID: 2775 RVA: 0x0001D4E0 File Offset: 0x0001B6E0
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qlneEd_isMinimized = QLineEdit.__N.QLneEd_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_isMinimized) > 0;
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x0001D510 File Offset: 0x0001B710
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qlneEd_isMaximized = QLineEdit.__N.QLneEd_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_isMaximized) > 0;
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x0001D540 File Offset: 0x0001B740
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qlneEd_isFullScreen = QLineEdit.__N.QLneEd_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_isFullScreen) > 0;
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x0001D570 File Offset: 0x0001B770
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qlneEd_setMouseTracking = QLineEdit.__N.QLneEd_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qlneEd_setMouseTracking);
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x0001D5A4 File Offset: 0x0001B7A4
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qlneEd_hasMouseTracking = QLineEdit.__N.QLneEd_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_hasMouseTracking) > 0;
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x0001D5D4 File Offset: 0x0001B7D4
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qlneEd_underMouse = QLineEdit.__N.QLneEd_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_underMouse) > 0;
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x0001D604 File Offset: 0x0001B804
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qlneEd_mapToGlobal = QLineEdit.__N.QLneEd_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qlneEd_mapToGlobal);
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x0001D630 File Offset: 0x0001B830
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qlneEd_mapFromGlobal = QLineEdit.__N.QLneEd_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qlneEd_mapFromGlobal);
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x0001D65C File Offset: 0x0001B85C
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qlneEd_hasFocus = QLineEdit.__N.QLneEd_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_hasFocus) > 0;
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x0001D68C File Offset: 0x0001B88C
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qlneEd_focusPolicy = QLineEdit.__N.QLneEd_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qlneEd_focusPolicy);
		}

		// Token: 0x06000AE1 RID: 2785 RVA: 0x0001D6B8 File Offset: 0x0001B8B8
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qlneEd_setFocusPolicy = QLineEdit.__N.QLneEd_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qlneEd_setFocusPolicy);
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x0001D6E4 File Offset: 0x0001B8E4
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qlneEd_setFocusProxy = QLineEdit.__N.QLneEd_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qlneEd_setFocusProxy);
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x0001D714 File Offset: 0x0001B914
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qlneEd_isActiveWindow = QLineEdit.__N.QLneEd_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_isActiveWindow) > 0;
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x0001D744 File Offset: 0x0001B944
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qlneEd_updatesEnabled = QLineEdit.__N.QLneEd_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_updatesEnabled) > 0;
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x0001D774 File Offset: 0x0001B974
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qlneEd_setUpdatesEnabled = QLineEdit.__N.QLneEd_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qlneEd_setUpdatesEnabled);
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x0001D7A8 File Offset: 0x0001B9A8
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qlneEd_setFocus = QLineEdit.__N.QLneEd_setFocus;
			calli(System.Void(System.IntPtr), this.self, qlneEd_setFocus);
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x0001D7D4 File Offset: 0x0001B9D4
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qlneEd_activateWindow = QLineEdit.__N.QLneEd_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qlneEd_activateWindow);
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x0001D800 File Offset: 0x0001BA00
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qlneEd_clearFocus = QLineEdit.__N.QLneEd_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qlneEd_clearFocus);
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0001D82C File Offset: 0x0001BA2C
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qlneEd_setSizePolicy = QLineEdit.__N.QLneEd_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qlneEd_setSizePolicy);
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x0001D85C File Offset: 0x0001BA5C
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qlneEd_devicePixelRatioF = QLineEdit.__N.QLneEd_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qlneEd_devicePixelRatioF);
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x0001D888 File Offset: 0x0001BA88
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qlneEd_saveGeometry = QLineEdit.__N.QLneEd_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qlneEd_saveGeometry));
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0001D8B8 File Offset: 0x0001BAB8
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qlneEd_restoreGeometry = QLineEdit.__N.QLneEd_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qlneEd_restoreGeometry) > 0;
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x0001D8EC File Offset: 0x0001BAEC
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qlneEd_f = QLineEdit.__N.QLneEd_f2;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qlneEd_f);
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x0001D91C File Offset: 0x0001BB1C
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qlneEd_removeAction = QLineEdit.__N.QLneEd_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qlneEd_removeAction);
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x0001D94C File Offset: 0x0001BB4C
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qlneEd_setParent = QLineEdit.__N.QLneEd_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qlneEd_setParent);
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x0001D97C File Offset: 0x0001BB7C
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qlneEd_parentWidget = QLineEdit.__N.QLneEd_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qlneEd_parentWidget);
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x0001D9AC File Offset: 0x0001BBAC
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qlneEd_AddClassName = QLineEdit.__N.QLneEd_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qlneEd_AddClassName);
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x0001D9DC File Offset: 0x0001BBDC
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qlneEd_Polish = QLineEdit.__N.QLneEd_Polish;
			calli(System.Void(System.IntPtr), this.self, qlneEd_Polish);
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0001DA08 File Offset: 0x0001BC08
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qlneEd_toolTip = QLineEdit.__N.QLneEd_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlneEd_toolTip));
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x0001DA38 File Offset: 0x0001BC38
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qlneEd_setToolTip = QLineEdit.__N.QLneEd_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qlneEd_setToolTip);
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x0001DA68 File Offset: 0x0001BC68
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qlneEd_statusTip = QLineEdit.__N.QLneEd_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlneEd_statusTip));
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0001DA98 File Offset: 0x0001BC98
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qlneEd_setStatusTip = QLineEdit.__N.QLneEd_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qlneEd_setStatusTip);
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x0001DAC8 File Offset: 0x0001BCC8
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qlneEd_toolTipDuration = QLineEdit.__N.QLneEd_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_toolTipDuration);
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0001DAF4 File Offset: 0x0001BCF4
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qlneEd_setToolTipDuration = QLineEdit.__N.QLneEd_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qlneEd_setToolTipDuration);
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0001DB20 File Offset: 0x0001BD20
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qlneEd_autoFillBackground = QLineEdit.__N.QLneEd_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qlneEd_autoFillBackground) > 0;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x0001DB50 File Offset: 0x0001BD50
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qlneEd_setAutoFillBackground = QLineEdit.__N.QLneEd_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qlneEd_setAutoFillBackground);
		}

		// Token: 0x04000059 RID: 89
		internal IntPtr self;

		// Token: 0x0200011A RID: 282
		internal static class __N
		{
			// Token: 0x04000CA0 RID: 3232
			internal static method From_QWidget_To_QLineEdit;

			// Token: 0x04000CA1 RID: 3233
			internal static method To_QWidget_From_QLineEdit;

			// Token: 0x04000CA2 RID: 3234
			internal static method From_QObject_To_QLineEdit;

			// Token: 0x04000CA3 RID: 3235
			internal static method To_QObject_From_QLineEdit;

			// Token: 0x04000CA4 RID: 3236
			internal static method QLneEd_setText;

			// Token: 0x04000CA5 RID: 3237
			internal static method QLneEd_text;

			// Token: 0x04000CA6 RID: 3238
			internal static method QLneEd_displayText;

			// Token: 0x04000CA7 RID: 3239
			internal static method QLneEd_placeholderText;

			// Token: 0x04000CA8 RID: 3240
			internal static method QLneEd_setPlaceholderText;

			// Token: 0x04000CA9 RID: 3241
			internal static method QLneEd_maxLength;

			// Token: 0x04000CAA RID: 3242
			internal static method QLneEd_setMaxLength;

			// Token: 0x04000CAB RID: 3243
			internal static method QLneEd_setFrame;

			// Token: 0x04000CAC RID: 3244
			internal static method QLneEd_hasFrame;

			// Token: 0x04000CAD RID: 3245
			internal static method QLneEd_setClearButtonEnabled;

			// Token: 0x04000CAE RID: 3246
			internal static method QLneEd_isClearButtonEnabled;

			// Token: 0x04000CAF RID: 3247
			internal static method QLneEd_isReadOnly;

			// Token: 0x04000CB0 RID: 3248
			internal static method QLneEd_setReadOnly;

			// Token: 0x04000CB1 RID: 3249
			internal static method QLneEd_cursorPosition;

			// Token: 0x04000CB2 RID: 3250
			internal static method QLneEd_setCursorPosition;

			// Token: 0x04000CB3 RID: 3251
			internal static method QLneEd_hasSelectedText;

			// Token: 0x04000CB4 RID: 3252
			internal static method QLneEd_selectedText;

			// Token: 0x04000CB5 RID: 3253
			internal static method QLneEd_clear;

			// Token: 0x04000CB6 RID: 3254
			internal static method QLneEd_selectAll;

			// Token: 0x04000CB7 RID: 3255
			internal static method QLneEd_undo;

			// Token: 0x04000CB8 RID: 3256
			internal static method QLneEd_redo;

			// Token: 0x04000CB9 RID: 3257
			internal static method QLneEd_cut;

			// Token: 0x04000CBA RID: 3258
			internal static method QLneEd_copy;

			// Token: 0x04000CBB RID: 3259
			internal static method QLneEd_paste;

			// Token: 0x04000CBC RID: 3260
			internal static method QLneEd_deselect;

			// Token: 0x04000CBD RID: 3261
			internal static method QLneEd_insert;

			// Token: 0x04000CBE RID: 3262
			internal static method QLneEd_addAction;

			// Token: 0x04000CBF RID: 3263
			internal static method QLneEd_isTopLevel;

			// Token: 0x04000CC0 RID: 3264
			internal static method QLneEd_isWindow;

			// Token: 0x04000CC1 RID: 3265
			internal static method QLneEd_isModal;

			// Token: 0x04000CC2 RID: 3266
			internal static method QLneEd_setStyleSheet;

			// Token: 0x04000CC3 RID: 3267
			internal static method QLneEd_windowTitle;

			// Token: 0x04000CC4 RID: 3268
			internal static method QLneEd_setWindowTitle;

			// Token: 0x04000CC5 RID: 3269
			internal static method QLneEd_setWindowFlags;

			// Token: 0x04000CC6 RID: 3270
			internal static method QLneEd_windowFlags;

			// Token: 0x04000CC7 RID: 3271
			internal static method QLneEd_size;

			// Token: 0x04000CC8 RID: 3272
			internal static method QLneEd_resize;

			// Token: 0x04000CC9 RID: 3273
			internal static method QLneEd_minimumSize;

			// Token: 0x04000CCA RID: 3274
			internal static method QLneEd_setMinimumSize;

			// Token: 0x04000CCB RID: 3275
			internal static method QLneEd_maximumSize;

			// Token: 0x04000CCC RID: 3276
			internal static method QLneEd_setMaximumSize;

			// Token: 0x04000CCD RID: 3277
			internal static method QLneEd_pos;

			// Token: 0x04000CCE RID: 3278
			internal static method QLneEd_move;

			// Token: 0x04000CCF RID: 3279
			internal static method QLneEd_isEnabled;

			// Token: 0x04000CD0 RID: 3280
			internal static method QLneEd_setEnabled;

			// Token: 0x04000CD1 RID: 3281
			internal static method QLneEd_setVisible;

			// Token: 0x04000CD2 RID: 3282
			internal static method QLneEd_setHidden;

			// Token: 0x04000CD3 RID: 3283
			internal static method QLneEd_show;

			// Token: 0x04000CD4 RID: 3284
			internal static method QLneEd_hide;

			// Token: 0x04000CD5 RID: 3285
			internal static method QLneEd_showMinimized;

			// Token: 0x04000CD6 RID: 3286
			internal static method QLneEd_showMaximized;

			// Token: 0x04000CD7 RID: 3287
			internal static method QLneEd_showFullScreen;

			// Token: 0x04000CD8 RID: 3288
			internal static method QLneEd_showNormal;

			// Token: 0x04000CD9 RID: 3289
			internal static method QLneEd_close;

			// Token: 0x04000CDA RID: 3290
			internal static method QLneEd_raise;

			// Token: 0x04000CDB RID: 3291
			internal static method QLneEd_lower;

			// Token: 0x04000CDC RID: 3292
			internal static method QLneEd_isVisible;

			// Token: 0x04000CDD RID: 3293
			internal static method QLneEd_setAttribute;

			// Token: 0x04000CDE RID: 3294
			internal static method QLneEd_testAttribute;

			// Token: 0x04000CDF RID: 3295
			internal static method QLneEd_acceptDrops;

			// Token: 0x04000CE0 RID: 3296
			internal static method QLneEd_setAcceptDrops;

			// Token: 0x04000CE1 RID: 3297
			internal static method QLneEd_update;

			// Token: 0x04000CE2 RID: 3298
			internal static method QLneEd_repaint;

			// Token: 0x04000CE3 RID: 3299
			internal static method QLneEd_setCursor;

			// Token: 0x04000CE4 RID: 3300
			internal static method QLneEd_unsetCursor;

			// Token: 0x04000CE5 RID: 3301
			internal static method QLneEd_setWindowIcon;

			// Token: 0x04000CE6 RID: 3302
			internal static method QLneEd_setWindowIconText;

			// Token: 0x04000CE7 RID: 3303
			internal static method QLneEd_setWindowOpacity;

			// Token: 0x04000CE8 RID: 3304
			internal static method QLneEd_windowOpacity;

			// Token: 0x04000CE9 RID: 3305
			internal static method QLneEd_isMinimized;

			// Token: 0x04000CEA RID: 3306
			internal static method QLneEd_isMaximized;

			// Token: 0x04000CEB RID: 3307
			internal static method QLneEd_isFullScreen;

			// Token: 0x04000CEC RID: 3308
			internal static method QLneEd_setMouseTracking;

			// Token: 0x04000CED RID: 3309
			internal static method QLneEd_hasMouseTracking;

			// Token: 0x04000CEE RID: 3310
			internal static method QLneEd_underMouse;

			// Token: 0x04000CEF RID: 3311
			internal static method QLneEd_mapToGlobal;

			// Token: 0x04000CF0 RID: 3312
			internal static method QLneEd_mapFromGlobal;

			// Token: 0x04000CF1 RID: 3313
			internal static method QLneEd_hasFocus;

			// Token: 0x04000CF2 RID: 3314
			internal static method QLneEd_focusPolicy;

			// Token: 0x04000CF3 RID: 3315
			internal static method QLneEd_setFocusPolicy;

			// Token: 0x04000CF4 RID: 3316
			internal static method QLneEd_setFocusProxy;

			// Token: 0x04000CF5 RID: 3317
			internal static method QLneEd_isActiveWindow;

			// Token: 0x04000CF6 RID: 3318
			internal static method QLneEd_updatesEnabled;

			// Token: 0x04000CF7 RID: 3319
			internal static method QLneEd_setUpdatesEnabled;

			// Token: 0x04000CF8 RID: 3320
			internal static method QLneEd_setFocus;

			// Token: 0x04000CF9 RID: 3321
			internal static method QLneEd_activateWindow;

			// Token: 0x04000CFA RID: 3322
			internal static method QLneEd_clearFocus;

			// Token: 0x04000CFB RID: 3323
			internal static method QLneEd_setSizePolicy;

			// Token: 0x04000CFC RID: 3324
			internal static method QLneEd_devicePixelRatioF;

			// Token: 0x04000CFD RID: 3325
			internal static method QLneEd_saveGeometry;

			// Token: 0x04000CFE RID: 3326
			internal static method QLneEd_restoreGeometry;

			// Token: 0x04000CFF RID: 3327
			internal static method QLneEd_f2;

			// Token: 0x04000D00 RID: 3328
			internal static method QLneEd_removeAction;

			// Token: 0x04000D01 RID: 3329
			internal static method QLneEd_setParent;

			// Token: 0x04000D02 RID: 3330
			internal static method QLneEd_parentWidget;

			// Token: 0x04000D03 RID: 3331
			internal static method QLneEd_AddClassName;

			// Token: 0x04000D04 RID: 3332
			internal static method QLneEd_Polish;

			// Token: 0x04000D05 RID: 3333
			internal static method QLneEd_toolTip;

			// Token: 0x04000D06 RID: 3334
			internal static method QLneEd_setToolTip;

			// Token: 0x04000D07 RID: 3335
			internal static method QLneEd_statusTip;

			// Token: 0x04000D08 RID: 3336
			internal static method QLneEd_setStatusTip;

			// Token: 0x04000D09 RID: 3337
			internal static method QLneEd_toolTipDuration;

			// Token: 0x04000D0A RID: 3338
			internal static method QLneEd_setToolTipDuration;

			// Token: 0x04000D0B RID: 3339
			internal static method QLneEd_autoFillBackground;

			// Token: 0x04000D0C RID: 3340
			internal static method QLneEd_setAutoFillBackground;
		}
	}
}
