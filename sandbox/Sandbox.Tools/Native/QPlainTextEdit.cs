using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000056 RID: 86
	internal struct QPlainTextEdit
	{
		// Token: 0x06000CF1 RID: 3313 RVA: 0x00022ECB File Offset: 0x000210CB
		public static implicit operator IntPtr(QPlainTextEdit value)
		{
			return value.self;
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x00022ED4 File Offset: 0x000210D4
		public static implicit operator QPlainTextEdit(IntPtr value)
		{
			return new QPlainTextEdit
			{
				self = value
			};
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x00022EF2 File Offset: 0x000210F2
		public static bool operator ==(QPlainTextEdit c1, QPlainTextEdit c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x00022F05 File Offset: 0x00021105
		public static bool operator !=(QPlainTextEdit c1, QPlainTextEdit c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x00022F18 File Offset: 0x00021118
		public override bool Equals(object obj)
		{
			if (obj is QPlainTextEdit)
			{
				QPlainTextEdit c = (QPlainTextEdit)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x00022F42 File Offset: 0x00021142
		internal QPlainTextEdit(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000CF7 RID: 3319 RVA: 0x00022F4C File Offset: 0x0002114C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QPlainTextEdit ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x00022F88 File Offset: 0x00021188
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x00022F9A File Offset: 0x0002119A
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x00022FA5 File Offset: 0x000211A5
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x00022FB8 File Offset: 0x000211B8
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QPlainTextEdit was null when calling " + n);
			}
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x00022FD3 File Offset: 0x000211D3
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000CFD RID: 3325 RVA: 0x00022FE0 File Offset: 0x000211E0
		public static implicit operator QAbstractScrollArea(QPlainTextEdit value)
		{
			method to_QAbstractScrollArea_From_QPlainTextEdit = QPlainTextEdit.__N.To_QAbstractScrollArea_From_QPlainTextEdit;
			return calli(System.IntPtr(System.IntPtr), value, to_QAbstractScrollArea_From_QPlainTextEdit);
		}

		// Token: 0x06000CFE RID: 3326 RVA: 0x00023004 File Offset: 0x00021204
		public static explicit operator QPlainTextEdit(QAbstractScrollArea value)
		{
			method from_QAbstractScrollArea_To_QPlainTextEdit = QPlainTextEdit.__N.From_QAbstractScrollArea_To_QPlainTextEdit;
			return calli(System.IntPtr(System.IntPtr), value, from_QAbstractScrollArea_To_QPlainTextEdit);
		}

		// Token: 0x06000CFF RID: 3327 RVA: 0x00023028 File Offset: 0x00021228
		public static implicit operator QFrame(QPlainTextEdit value)
		{
			method to_QFrame_From_QPlainTextEdit = QPlainTextEdit.__N.To_QFrame_From_QPlainTextEdit;
			return calli(System.IntPtr(System.IntPtr), value, to_QFrame_From_QPlainTextEdit);
		}

		// Token: 0x06000D00 RID: 3328 RVA: 0x0002304C File Offset: 0x0002124C
		public static explicit operator QPlainTextEdit(QFrame value)
		{
			method from_QFrame_To_QPlainTextEdit = QPlainTextEdit.__N.From_QFrame_To_QPlainTextEdit;
			return calli(System.IntPtr(System.IntPtr), value, from_QFrame_To_QPlainTextEdit);
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x00023070 File Offset: 0x00021270
		public static implicit operator QWidget(QPlainTextEdit value)
		{
			method to_QWidget_From_QPlainTextEdit = QPlainTextEdit.__N.To_QWidget_From_QPlainTextEdit;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QPlainTextEdit);
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x00023094 File Offset: 0x00021294
		public static explicit operator QPlainTextEdit(QWidget value)
		{
			method from_QWidget_To_QPlainTextEdit = QPlainTextEdit.__N.From_QWidget_To_QPlainTextEdit;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QPlainTextEdit);
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x000230B8 File Offset: 0x000212B8
		public static implicit operator QObject(QPlainTextEdit value)
		{
			method to_QObject_From_QPlainTextEdit = QPlainTextEdit.__N.To_QObject_From_QPlainTextEdit;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QPlainTextEdit);
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x000230DC File Offset: 0x000212DC
		public static explicit operator QPlainTextEdit(QObject value)
		{
			method from_QObject_To_QPlainTextEdit = QPlainTextEdit.__N.From_QObject_To_QPlainTextEdit;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QPlainTextEdit);
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x00023100 File Offset: 0x00021300
		internal readonly QTextDocument document()
		{
			this.NullCheck("document");
			method qplnTe_document = QPlainTextEdit.__N.QPlnTe_document;
			return calli(System.IntPtr(System.IntPtr), this.self, qplnTe_document);
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x00023130 File Offset: 0x00021330
		internal readonly void setPlaceholderText(string placeholderText)
		{
			this.NullCheck("setPlaceholderText");
			method qplnTe_setPlaceholderText = QPlainTextEdit.__N.QPlnTe_setPlaceholderText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(placeholderText), qplnTe_setPlaceholderText);
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x00023160 File Offset: 0x00021360
		internal readonly string placeholderText()
		{
			this.NullCheck("placeholderText");
			method qplnTe_placeholderText = QPlainTextEdit.__N.QPlnTe_placeholderText;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qplnTe_placeholderText));
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x00023190 File Offset: 0x00021390
		internal readonly bool isReadOnly()
		{
			this.NullCheck("isReadOnly");
			method qplnTe_isReadOnly = QPlainTextEdit.__N.QPlnTe_isReadOnly;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_isReadOnly) > 0;
		}

		// Token: 0x06000D09 RID: 3337 RVA: 0x000231C0 File Offset: 0x000213C0
		internal readonly void setReadOnly(bool ro)
		{
			this.NullCheck("setReadOnly");
			method qplnTe_setReadOnly = QPlainTextEdit.__N.QPlnTe_setReadOnly;
			calli(System.Void(System.IntPtr,System.Int32), this.self, ro ? 1 : 0, qplnTe_setReadOnly);
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x000231F4 File Offset: 0x000213F4
		internal readonly void setTextInteractionFlags(TextInteractionFlags flags)
		{
			this.NullCheck("setTextInteractionFlags");
			method qplnTe_setTextInteractionFlags = QPlainTextEdit.__N.QPlnTe_setTextInteractionFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)flags, qplnTe_setTextInteractionFlags);
		}

		// Token: 0x06000D0B RID: 3339 RVA: 0x00023220 File Offset: 0x00021420
		internal readonly TextInteractionFlags textInteractionFlags()
		{
			this.NullCheck("textInteractionFlags");
			method qplnTe_textInteractionFlags = QPlainTextEdit.__N.QPlnTe_textInteractionFlags;
			return calli(System.Int64(System.IntPtr), this.self, qplnTe_textInteractionFlags);
		}

		// Token: 0x06000D0C RID: 3340 RVA: 0x0002324C File Offset: 0x0002144C
		internal readonly bool tabChangesFocus()
		{
			this.NullCheck("tabChangesFocus");
			method qplnTe_tabChangesFocus = QPlainTextEdit.__N.QPlnTe_tabChangesFocus;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_tabChangesFocus) > 0;
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x0002327C File Offset: 0x0002147C
		internal readonly void setTabChangesFocus(bool b)
		{
			this.NullCheck("setTabChangesFocus");
			method qplnTe_setTabChangesFocus = QPlainTextEdit.__N.QPlnTe_setTabChangesFocus;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qplnTe_setTabChangesFocus);
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x000232B0 File Offset: 0x000214B0
		internal readonly void setDocumentTitle(string title)
		{
			this.NullCheck("setDocumentTitle");
			method qplnTe_setDocumentTitle = QPlainTextEdit.__N.QPlnTe_setDocumentTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qplnTe_setDocumentTitle);
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x000232E0 File Offset: 0x000214E0
		internal readonly string documentTitle()
		{
			this.NullCheck("documentTitle");
			method qplnTe_documentTitle = QPlainTextEdit.__N.QPlnTe_documentTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qplnTe_documentTitle));
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x00023310 File Offset: 0x00021510
		internal readonly bool isUndoRedoEnabled()
		{
			this.NullCheck("isUndoRedoEnabled");
			method qplnTe_isUndoRedoEnabled = QPlainTextEdit.__N.QPlnTe_isUndoRedoEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_isUndoRedoEnabled) > 0;
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x00023340 File Offset: 0x00021540
		internal readonly void setUndoRedoEnabled(bool enable)
		{
			this.NullCheck("setUndoRedoEnabled");
			method qplnTe_setUndoRedoEnabled = QPlainTextEdit.__N.QPlnTe_setUndoRedoEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qplnTe_setUndoRedoEnabled);
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x00023374 File Offset: 0x00021574
		internal readonly void setMaximumBlockCount(int maximum)
		{
			this.NullCheck("setMaximumBlockCount");
			method qplnTe_setMaximumBlockCount = QPlainTextEdit.__N.QPlnTe_setMaximumBlockCount;
			calli(System.Void(System.IntPtr,System.Int32), this.self, maximum, qplnTe_setMaximumBlockCount);
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x000233A0 File Offset: 0x000215A0
		internal readonly int maximumBlockCount()
		{
			this.NullCheck("maximumBlockCount");
			method qplnTe_maximumBlockCount = QPlainTextEdit.__N.QPlnTe_maximumBlockCount;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_maximumBlockCount);
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x000233CC File Offset: 0x000215CC
		internal readonly LineWrapMode lineWrapMode()
		{
			this.NullCheck("lineWrapMode");
			method qplnTe_lineWrapMode = QPlainTextEdit.__N.QPlnTe_lineWrapMode;
			return calli(System.Int64(System.IntPtr), this.self, qplnTe_lineWrapMode);
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x000233F8 File Offset: 0x000215F8
		internal readonly void setLineWrapMode(LineWrapMode mode)
		{
			this.NullCheck("setLineWrapMode");
			method qplnTe_setLineWrapMode = QPlainTextEdit.__N.QPlnTe_setLineWrapMode;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)mode, qplnTe_setLineWrapMode);
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x00023424 File Offset: 0x00021624
		internal readonly QTextOptionWrapMode wordWrapMode()
		{
			this.NullCheck("wordWrapMode");
			method qplnTe_wordWrapMode = QPlainTextEdit.__N.QPlnTe_wordWrapMode;
			return calli(System.Int64(System.IntPtr), this.self, qplnTe_wordWrapMode);
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x00023450 File Offset: 0x00021650
		internal readonly void setWordWrapMode(QTextOptionWrapMode policy)
		{
			this.NullCheck("setWordWrapMode");
			method qplnTe_setWordWrapMode = QPlainTextEdit.__N.QPlnTe_setWordWrapMode;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qplnTe_setWordWrapMode);
		}

		// Token: 0x06000D18 RID: 3352 RVA: 0x0002347C File Offset: 0x0002167C
		internal readonly void setBackgroundVisible(bool visible)
		{
			this.NullCheck("setBackgroundVisible");
			method qplnTe_setBackgroundVisible = QPlainTextEdit.__N.QPlnTe_setBackgroundVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qplnTe_setBackgroundVisible);
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x000234B0 File Offset: 0x000216B0
		internal readonly bool backgroundVisible()
		{
			this.NullCheck("backgroundVisible");
			method qplnTe_backgroundVisible = QPlainTextEdit.__N.QPlnTe_backgroundVisible;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_backgroundVisible) > 0;
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x000234E0 File Offset: 0x000216E0
		internal readonly void setCenterOnScroll(bool enabled)
		{
			this.NullCheck("setCenterOnScroll");
			method qplnTe_setCenterOnScroll = QPlainTextEdit.__N.QPlnTe_setCenterOnScroll;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qplnTe_setCenterOnScroll);
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x00023514 File Offset: 0x00021714
		internal readonly bool centerOnScroll()
		{
			this.NullCheck("centerOnScroll");
			method qplnTe_centerOnScroll = QPlainTextEdit.__N.QPlnTe_centerOnScroll;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_centerOnScroll) > 0;
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x00023544 File Offset: 0x00021744
		internal readonly bool find(string exp)
		{
			this.NullCheck("find");
			method qplnTe_find = QPlainTextEdit.__N.QPlnTe_find;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(exp), qplnTe_find) > 0;
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x00023578 File Offset: 0x00021778
		internal readonly string toPlainText()
		{
			this.NullCheck("toPlainText");
			method qplnTe_toPlainText = QPlainTextEdit.__N.QPlnTe_toPlainText;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qplnTe_toPlainText));
		}

		// Token: 0x06000D1E RID: 3358 RVA: 0x000235A8 File Offset: 0x000217A8
		internal readonly void setPlainText(string text)
		{
			this.NullCheck("setPlainText");
			method qplnTe_setPlainText = QPlainTextEdit.__N.QPlnTe_setPlainText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qplnTe_setPlainText);
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x000235D8 File Offset: 0x000217D8
		internal readonly void ensureCursorVisible()
		{
			this.NullCheck("ensureCursorVisible");
			method qplnTe_ensureCursorVisible = QPlainTextEdit.__N.QPlnTe_ensureCursorVisible;
			calli(System.Void(System.IntPtr), this.self, qplnTe_ensureCursorVisible);
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x00023604 File Offset: 0x00021804
		internal readonly void insertPlainText(string text)
		{
			this.NullCheck("insertPlainText");
			method qplnTe_insertPlainText = QPlainTextEdit.__N.QPlnTe_insertPlainText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qplnTe_insertPlainText);
		}

		// Token: 0x06000D21 RID: 3361 RVA: 0x00023634 File Offset: 0x00021834
		internal readonly void appendPlainText(string text)
		{
			this.NullCheck("appendPlainText");
			method qplnTe_appendPlainText = QPlainTextEdit.__N.QPlnTe_appendPlainText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qplnTe_appendPlainText);
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x00023664 File Offset: 0x00021864
		internal readonly void appendHtml(string html)
		{
			this.NullCheck("appendHtml");
			method qplnTe_appendHtml = QPlainTextEdit.__N.QPlnTe_appendHtml;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(html), qplnTe_appendHtml);
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x00023694 File Offset: 0x00021894
		internal readonly void centerCursor()
		{
			this.NullCheck("centerCursor");
			method qplnTe_centerCursor = QPlainTextEdit.__N.QPlnTe_centerCursor;
			calli(System.Void(System.IntPtr), this.self, qplnTe_centerCursor);
		}

		// Token: 0x06000D24 RID: 3364 RVA: 0x000236C0 File Offset: 0x000218C0
		internal readonly void clear()
		{
			this.NullCheck("clear");
			method qplnTe_clear = QPlainTextEdit.__N.QPlnTe_clear;
			calli(System.Void(System.IntPtr), this.self, qplnTe_clear);
		}

		// Token: 0x06000D25 RID: 3365 RVA: 0x000236EC File Offset: 0x000218EC
		internal readonly void selectAll()
		{
			this.NullCheck("selectAll");
			method qplnTe_selectAll = QPlainTextEdit.__N.QPlnTe_selectAll;
			calli(System.Void(System.IntPtr), this.self, qplnTe_selectAll);
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x00023718 File Offset: 0x00021918
		internal readonly string anchorAt(Vector3 pos)
		{
			this.NullCheck("anchorAt");
			method qplnTe_anchorAt = QPlainTextEdit.__N.QPlnTe_anchorAt;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr,Vector3), this.self, pos, qplnTe_anchorAt));
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x00023748 File Offset: 0x00021948
		internal readonly void setTextCursor(TextCursor cursor)
		{
			this.NullCheck("setTextCursor");
			method qplnTe_setTextCursor = QPlainTextEdit.__N.QPlnTe_setTextCursor;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, cursor.GetPointerAssertIfNull(), qplnTe_setTextCursor);
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x00023778 File Offset: 0x00021978
		internal readonly TextCursor textCursor()
		{
			this.NullCheck("textCursor");
			method qplnTe_textCursor = QPlainTextEdit.__N.QPlnTe_textCursor;
			return new TextCursor(calli(System.IntPtr(System.IntPtr), this.self, qplnTe_textCursor));
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x000237A8 File Offset: 0x000219A8
		internal readonly TextCursor cursorForPosition(Vector3 pos)
		{
			this.NullCheck("cursorForPosition");
			method qplnTe_cursorForPosition = QPlainTextEdit.__N.QPlnTe_cursorForPosition;
			return new TextCursor(calli(System.IntPtr(System.IntPtr,Vector3), this.self, pos, qplnTe_cursorForPosition));
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x000237D8 File Offset: 0x000219D8
		internal readonly QRectF cursorRect(TextCursor c)
		{
			this.NullCheck("cursorRect");
			method qplnTe_cursorRect = QPlainTextEdit.__N.QPlnTe_cursorRect;
			return calli(QRectF(System.IntPtr,System.IntPtr), this.self, c.GetPointerAssertIfNull(), qplnTe_cursorRect);
		}

		// Token: 0x06000D2B RID: 3371 RVA: 0x00023808 File Offset: 0x00021A08
		internal readonly float tabStopDistance()
		{
			this.NullCheck("tabStopDistance");
			method qplnTe_tabStopDistance = QPlainTextEdit.__N.QPlnTe_tabStopDistance;
			return calli(System.Single(System.IntPtr), this.self, qplnTe_tabStopDistance);
		}

		// Token: 0x06000D2C RID: 3372 RVA: 0x00023834 File Offset: 0x00021A34
		internal readonly void setTabStopDistance(float distance)
		{
			this.NullCheck("setTabStopDistance");
			method qplnTe_setTabStopDistance = QPlainTextEdit.__N.QPlnTe_setTabStopDistance;
			calli(System.Void(System.IntPtr,System.Single), this.self, distance, qplnTe_setTabStopDistance);
		}

		// Token: 0x06000D2D RID: 3373 RVA: 0x00023860 File Offset: 0x00021A60
		internal readonly QWidget viewport()
		{
			this.NullCheck("viewport");
			method qplnTe_viewport = QPlainTextEdit.__N.QPlnTe_viewport;
			return calli(System.IntPtr(System.IntPtr), this.self, qplnTe_viewport);
		}

		// Token: 0x06000D2E RID: 3374 RVA: 0x00023890 File Offset: 0x00021A90
		internal readonly QScrollBar horizontalScrollBar()
		{
			this.NullCheck("horizontalScrollBar");
			method qplnTe_horizontalScrollBar = QPlainTextEdit.__N.QPlnTe_horizontalScrollBar;
			return calli(System.IntPtr(System.IntPtr), this.self, qplnTe_horizontalScrollBar);
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x000238C0 File Offset: 0x00021AC0
		internal readonly QScrollBar verticalScrollBar()
		{
			this.NullCheck("verticalScrollBar");
			method qplnTe_verticalScrollBar = QPlainTextEdit.__N.QPlnTe_verticalScrollBar;
			return calli(System.IntPtr(System.IntPtr), this.self, qplnTe_verticalScrollBar);
		}

		// Token: 0x06000D30 RID: 3376 RVA: 0x000238F0 File Offset: 0x00021AF0
		internal readonly ScrollbarMode horizontalScrollBarPolicy()
		{
			this.NullCheck("horizontalScrollBarPolicy");
			method qplnTe_horizontalScrollBarPolicy = QPlainTextEdit.__N.QPlnTe_horizontalScrollBarPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qplnTe_horizontalScrollBarPolicy);
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x0002391C File Offset: 0x00021B1C
		internal readonly void setHorizontalScrollBarPolicy(ScrollbarMode m)
		{
			this.NullCheck("setHorizontalScrollBarPolicy");
			method qplnTe_setHorizontalScrollBarPolicy = QPlainTextEdit.__N.QPlnTe_setHorizontalScrollBarPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)m, qplnTe_setHorizontalScrollBarPolicy);
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x00023948 File Offset: 0x00021B48
		internal readonly ScrollbarMode verticalScrollBarPolicy()
		{
			this.NullCheck("verticalScrollBarPolicy");
			method qplnTe_verticalScrollBarPolicy = QPlainTextEdit.__N.QPlnTe_verticalScrollBarPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qplnTe_verticalScrollBarPolicy);
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x00023974 File Offset: 0x00021B74
		internal readonly void setVerticalScrollBarPolicy(ScrollbarMode m)
		{
			this.NullCheck("setVerticalScrollBarPolicy");
			method qplnTe_setVerticalScrollBarPolicy = QPlainTextEdit.__N.QPlnTe_setVerticalScrollBarPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)m, qplnTe_setVerticalScrollBarPolicy);
		}

		// Token: 0x06000D34 RID: 3380 RVA: 0x000239A0 File Offset: 0x00021BA0
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qplnTe_isTopLevel = QPlainTextEdit.__N.QPlnTe_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_isTopLevel) > 0;
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x000239D0 File Offset: 0x00021BD0
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qplnTe_isWindow = QPlainTextEdit.__N.QPlnTe_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_isWindow) > 0;
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x00023A00 File Offset: 0x00021C00
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qplnTe_isModal = QPlainTextEdit.__N.QPlnTe_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_isModal) > 0;
		}

		// Token: 0x06000D37 RID: 3383 RVA: 0x00023A30 File Offset: 0x00021C30
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qplnTe_setStyleSheet = QPlainTextEdit.__N.QPlnTe_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qplnTe_setStyleSheet);
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x00023A60 File Offset: 0x00021C60
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qplnTe_windowTitle = QPlainTextEdit.__N.QPlnTe_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qplnTe_windowTitle));
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x00023A90 File Offset: 0x00021C90
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qplnTe_setWindowTitle = QPlainTextEdit.__N.QPlnTe_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qplnTe_setWindowTitle);
		}

		// Token: 0x06000D3A RID: 3386 RVA: 0x00023AC0 File Offset: 0x00021CC0
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qplnTe_setWindowFlags = QPlainTextEdit.__N.QPlnTe_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qplnTe_setWindowFlags);
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x00023AEC File Offset: 0x00021CEC
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qplnTe_windowFlags = QPlainTextEdit.__N.QPlnTe_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qplnTe_windowFlags);
		}

		// Token: 0x06000D3C RID: 3388 RVA: 0x00023B18 File Offset: 0x00021D18
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qplnTe_size = QPlainTextEdit.__N.QPlnTe_size;
			return calli(Vector3(System.IntPtr), this.self, qplnTe_size);
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x00023B44 File Offset: 0x00021D44
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qplnTe_resize = QPlainTextEdit.__N.QPlnTe_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qplnTe_resize);
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x00023B70 File Offset: 0x00021D70
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qplnTe_minimumSize = QPlainTextEdit.__N.QPlnTe_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qplnTe_minimumSize);
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x00023B9C File Offset: 0x00021D9C
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qplnTe_setMinimumSize = QPlainTextEdit.__N.QPlnTe_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qplnTe_setMinimumSize);
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x00023BC8 File Offset: 0x00021DC8
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qplnTe_maximumSize = QPlainTextEdit.__N.QPlnTe_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qplnTe_maximumSize);
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x00023BF4 File Offset: 0x00021DF4
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qplnTe_setMaximumSize = QPlainTextEdit.__N.QPlnTe_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qplnTe_setMaximumSize);
		}

		// Token: 0x06000D42 RID: 3394 RVA: 0x00023C20 File Offset: 0x00021E20
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qplnTe_pos = QPlainTextEdit.__N.QPlnTe_pos;
			return calli(Vector3(System.IntPtr), this.self, qplnTe_pos);
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x00023C4C File Offset: 0x00021E4C
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qplnTe_move = QPlainTextEdit.__N.QPlnTe_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qplnTe_move);
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x00023C78 File Offset: 0x00021E78
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qplnTe_isEnabled = QPlainTextEdit.__N.QPlnTe_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_isEnabled) > 0;
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x00023CA8 File Offset: 0x00021EA8
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qplnTe_setEnabled = QPlainTextEdit.__N.QPlnTe_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qplnTe_setEnabled);
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x00023CDC File Offset: 0x00021EDC
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qplnTe_setVisible = QPlainTextEdit.__N.QPlnTe_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qplnTe_setVisible);
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x00023D10 File Offset: 0x00021F10
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qplnTe_setHidden = QPlainTextEdit.__N.QPlnTe_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qplnTe_setHidden);
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x00023D44 File Offset: 0x00021F44
		internal readonly void show()
		{
			this.NullCheck("show");
			method qplnTe_show = QPlainTextEdit.__N.QPlnTe_show;
			calli(System.Void(System.IntPtr), this.self, qplnTe_show);
		}

		// Token: 0x06000D49 RID: 3401 RVA: 0x00023D70 File Offset: 0x00021F70
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qplnTe_hide = QPlainTextEdit.__N.QPlnTe_hide;
			calli(System.Void(System.IntPtr), this.self, qplnTe_hide);
		}

		// Token: 0x06000D4A RID: 3402 RVA: 0x00023D9C File Offset: 0x00021F9C
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qplnTe_showMinimized = QPlainTextEdit.__N.QPlnTe_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qplnTe_showMinimized);
		}

		// Token: 0x06000D4B RID: 3403 RVA: 0x00023DC8 File Offset: 0x00021FC8
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qplnTe_showMaximized = QPlainTextEdit.__N.QPlnTe_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qplnTe_showMaximized);
		}

		// Token: 0x06000D4C RID: 3404 RVA: 0x00023DF4 File Offset: 0x00021FF4
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qplnTe_showFullScreen = QPlainTextEdit.__N.QPlnTe_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qplnTe_showFullScreen);
		}

		// Token: 0x06000D4D RID: 3405 RVA: 0x00023E20 File Offset: 0x00022020
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qplnTe_showNormal = QPlainTextEdit.__N.QPlnTe_showNormal;
			calli(System.Void(System.IntPtr), this.self, qplnTe_showNormal);
		}

		// Token: 0x06000D4E RID: 3406 RVA: 0x00023E4C File Offset: 0x0002204C
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qplnTe_close = QPlainTextEdit.__N.QPlnTe_close;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_close) > 0;
		}

		// Token: 0x06000D4F RID: 3407 RVA: 0x00023E7C File Offset: 0x0002207C
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qplnTe_raise = QPlainTextEdit.__N.QPlnTe_raise;
			calli(System.Void(System.IntPtr), this.self, qplnTe_raise);
		}

		// Token: 0x06000D50 RID: 3408 RVA: 0x00023EA8 File Offset: 0x000220A8
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qplnTe_lower = QPlainTextEdit.__N.QPlnTe_lower;
			calli(System.Void(System.IntPtr), this.self, qplnTe_lower);
		}

		// Token: 0x06000D51 RID: 3409 RVA: 0x00023ED4 File Offset: 0x000220D4
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qplnTe_isVisible = QPlainTextEdit.__N.QPlnTe_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_isVisible) > 0;
		}

		// Token: 0x06000D52 RID: 3410 RVA: 0x00023F04 File Offset: 0x00022104
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qplnTe_setAttribute = QPlainTextEdit.__N.QPlnTe_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qplnTe_setAttribute);
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x00023F38 File Offset: 0x00022138
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qplnTe_testAttribute = QPlainTextEdit.__N.QPlnTe_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qplnTe_testAttribute) > 0;
		}

		// Token: 0x06000D54 RID: 3412 RVA: 0x00023F68 File Offset: 0x00022168
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qplnTe_acceptDrops = QPlainTextEdit.__N.QPlnTe_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_acceptDrops) > 0;
		}

		// Token: 0x06000D55 RID: 3413 RVA: 0x00023F98 File Offset: 0x00022198
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qplnTe_setAcceptDrops = QPlainTextEdit.__N.QPlnTe_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qplnTe_setAcceptDrops);
		}

		// Token: 0x06000D56 RID: 3414 RVA: 0x00023FCC File Offset: 0x000221CC
		internal readonly void update()
		{
			this.NullCheck("update");
			method qplnTe_update = QPlainTextEdit.__N.QPlnTe_update;
			calli(System.Void(System.IntPtr), this.self, qplnTe_update);
		}

		// Token: 0x06000D57 RID: 3415 RVA: 0x00023FF8 File Offset: 0x000221F8
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qplnTe_repaint = QPlainTextEdit.__N.QPlnTe_repaint;
			calli(System.Void(System.IntPtr), this.self, qplnTe_repaint);
		}

		// Token: 0x06000D58 RID: 3416 RVA: 0x00024024 File Offset: 0x00022224
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qplnTe_setCursor = QPlainTextEdit.__N.QPlnTe_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qplnTe_setCursor);
		}

		// Token: 0x06000D59 RID: 3417 RVA: 0x00024050 File Offset: 0x00022250
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qplnTe_unsetCursor = QPlainTextEdit.__N.QPlnTe_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qplnTe_unsetCursor);
		}

		// Token: 0x06000D5A RID: 3418 RVA: 0x0002407C File Offset: 0x0002227C
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qplnTe_setWindowIcon = QPlainTextEdit.__N.QPlnTe_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qplnTe_setWindowIcon);
		}

		// Token: 0x06000D5B RID: 3419 RVA: 0x000240AC File Offset: 0x000222AC
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qplnTe_setWindowIconText = QPlainTextEdit.__N.QPlnTe_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qplnTe_setWindowIconText);
		}

		// Token: 0x06000D5C RID: 3420 RVA: 0x000240DC File Offset: 0x000222DC
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qplnTe_setWindowOpacity = QPlainTextEdit.__N.QPlnTe_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qplnTe_setWindowOpacity);
		}

		// Token: 0x06000D5D RID: 3421 RVA: 0x00024108 File Offset: 0x00022308
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qplnTe_windowOpacity = QPlainTextEdit.__N.QPlnTe_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qplnTe_windowOpacity);
		}

		// Token: 0x06000D5E RID: 3422 RVA: 0x00024134 File Offset: 0x00022334
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qplnTe_isMinimized = QPlainTextEdit.__N.QPlnTe_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_isMinimized) > 0;
		}

		// Token: 0x06000D5F RID: 3423 RVA: 0x00024164 File Offset: 0x00022364
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qplnTe_isMaximized = QPlainTextEdit.__N.QPlnTe_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_isMaximized) > 0;
		}

		// Token: 0x06000D60 RID: 3424 RVA: 0x00024194 File Offset: 0x00022394
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qplnTe_isFullScreen = QPlainTextEdit.__N.QPlnTe_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_isFullScreen) > 0;
		}

		// Token: 0x06000D61 RID: 3425 RVA: 0x000241C4 File Offset: 0x000223C4
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qplnTe_setMouseTracking = QPlainTextEdit.__N.QPlnTe_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qplnTe_setMouseTracking);
		}

		// Token: 0x06000D62 RID: 3426 RVA: 0x000241F8 File Offset: 0x000223F8
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qplnTe_hasMouseTracking = QPlainTextEdit.__N.QPlnTe_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_hasMouseTracking) > 0;
		}

		// Token: 0x06000D63 RID: 3427 RVA: 0x00024228 File Offset: 0x00022428
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qplnTe_underMouse = QPlainTextEdit.__N.QPlnTe_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_underMouse) > 0;
		}

		// Token: 0x06000D64 RID: 3428 RVA: 0x00024258 File Offset: 0x00022458
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qplnTe_mapToGlobal = QPlainTextEdit.__N.QPlnTe_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qplnTe_mapToGlobal);
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x00024284 File Offset: 0x00022484
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qplnTe_mapFromGlobal = QPlainTextEdit.__N.QPlnTe_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qplnTe_mapFromGlobal);
		}

		// Token: 0x06000D66 RID: 3430 RVA: 0x000242B0 File Offset: 0x000224B0
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qplnTe_hasFocus = QPlainTextEdit.__N.QPlnTe_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_hasFocus) > 0;
		}

		// Token: 0x06000D67 RID: 3431 RVA: 0x000242E0 File Offset: 0x000224E0
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qplnTe_focusPolicy = QPlainTextEdit.__N.QPlnTe_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qplnTe_focusPolicy);
		}

		// Token: 0x06000D68 RID: 3432 RVA: 0x0002430C File Offset: 0x0002250C
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qplnTe_setFocusPolicy = QPlainTextEdit.__N.QPlnTe_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qplnTe_setFocusPolicy);
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x00024338 File Offset: 0x00022538
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qplnTe_setFocusProxy = QPlainTextEdit.__N.QPlnTe_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qplnTe_setFocusProxy);
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x00024368 File Offset: 0x00022568
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qplnTe_isActiveWindow = QPlainTextEdit.__N.QPlnTe_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_isActiveWindow) > 0;
		}

		// Token: 0x06000D6B RID: 3435 RVA: 0x00024398 File Offset: 0x00022598
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qplnTe_updatesEnabled = QPlainTextEdit.__N.QPlnTe_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_updatesEnabled) > 0;
		}

		// Token: 0x06000D6C RID: 3436 RVA: 0x000243C8 File Offset: 0x000225C8
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qplnTe_setUpdatesEnabled = QPlainTextEdit.__N.QPlnTe_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qplnTe_setUpdatesEnabled);
		}

		// Token: 0x06000D6D RID: 3437 RVA: 0x000243FC File Offset: 0x000225FC
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qplnTe_setFocus = QPlainTextEdit.__N.QPlnTe_setFocus;
			calli(System.Void(System.IntPtr), this.self, qplnTe_setFocus);
		}

		// Token: 0x06000D6E RID: 3438 RVA: 0x00024428 File Offset: 0x00022628
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qplnTe_activateWindow = QPlainTextEdit.__N.QPlnTe_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qplnTe_activateWindow);
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x00024454 File Offset: 0x00022654
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qplnTe_clearFocus = QPlainTextEdit.__N.QPlnTe_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qplnTe_clearFocus);
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x00024480 File Offset: 0x00022680
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qplnTe_setSizePolicy = QPlainTextEdit.__N.QPlnTe_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qplnTe_setSizePolicy);
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x000244B0 File Offset: 0x000226B0
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qplnTe_devicePixelRatioF = QPlainTextEdit.__N.QPlnTe_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qplnTe_devicePixelRatioF);
		}

		// Token: 0x06000D72 RID: 3442 RVA: 0x000244DC File Offset: 0x000226DC
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qplnTe_saveGeometry = QPlainTextEdit.__N.QPlnTe_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qplnTe_saveGeometry));
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x0002450C File Offset: 0x0002270C
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qplnTe_restoreGeometry = QPlainTextEdit.__N.QPlnTe_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qplnTe_restoreGeometry) > 0;
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x00024540 File Offset: 0x00022740
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qplnTe_addAction = QPlainTextEdit.__N.QPlnTe_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qplnTe_addAction);
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x00024570 File Offset: 0x00022770
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qplnTe_removeAction = QPlainTextEdit.__N.QPlnTe_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qplnTe_removeAction);
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x000245A0 File Offset: 0x000227A0
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qplnTe_setParent = QPlainTextEdit.__N.QPlnTe_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qplnTe_setParent);
		}

		// Token: 0x06000D77 RID: 3447 RVA: 0x000245D0 File Offset: 0x000227D0
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qplnTe_parentWidget = QPlainTextEdit.__N.QPlnTe_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qplnTe_parentWidget);
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x00024600 File Offset: 0x00022800
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qplnTe_AddClassName = QPlainTextEdit.__N.QPlnTe_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qplnTe_AddClassName);
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x00024630 File Offset: 0x00022830
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qplnTe_Polish = QPlainTextEdit.__N.QPlnTe_Polish;
			calli(System.Void(System.IntPtr), this.self, qplnTe_Polish);
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x0002465C File Offset: 0x0002285C
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qplnTe_toolTip = QPlainTextEdit.__N.QPlnTe_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qplnTe_toolTip));
		}

		// Token: 0x06000D7B RID: 3451 RVA: 0x0002468C File Offset: 0x0002288C
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qplnTe_setToolTip = QPlainTextEdit.__N.QPlnTe_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qplnTe_setToolTip);
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x000246BC File Offset: 0x000228BC
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qplnTe_statusTip = QPlainTextEdit.__N.QPlnTe_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qplnTe_statusTip));
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x000246EC File Offset: 0x000228EC
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qplnTe_setStatusTip = QPlainTextEdit.__N.QPlnTe_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qplnTe_setStatusTip);
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x0002471C File Offset: 0x0002291C
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qplnTe_toolTipDuration = QPlainTextEdit.__N.QPlnTe_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_toolTipDuration);
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x00024748 File Offset: 0x00022948
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qplnTe_setToolTipDuration = QPlainTextEdit.__N.QPlnTe_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qplnTe_setToolTipDuration);
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x00024774 File Offset: 0x00022974
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qplnTe_autoFillBackground = QPlainTextEdit.__N.QPlnTe_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qplnTe_autoFillBackground) > 0;
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x000247A4 File Offset: 0x000229A4
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qplnTe_setAutoFillBackground = QPlainTextEdit.__N.QPlnTe_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qplnTe_setAutoFillBackground);
		}

		// Token: 0x04000061 RID: 97
		internal IntPtr self;

		// Token: 0x02000122 RID: 290
		internal static class __N
		{
			// Token: 0x04000EAF RID: 3759
			internal static method From_QAbstractScrollArea_To_QPlainTextEdit;

			// Token: 0x04000EB0 RID: 3760
			internal static method To_QAbstractScrollArea_From_QPlainTextEdit;

			// Token: 0x04000EB1 RID: 3761
			internal static method From_QFrame_To_QPlainTextEdit;

			// Token: 0x04000EB2 RID: 3762
			internal static method To_QFrame_From_QPlainTextEdit;

			// Token: 0x04000EB3 RID: 3763
			internal static method From_QWidget_To_QPlainTextEdit;

			// Token: 0x04000EB4 RID: 3764
			internal static method To_QWidget_From_QPlainTextEdit;

			// Token: 0x04000EB5 RID: 3765
			internal static method From_QObject_To_QPlainTextEdit;

			// Token: 0x04000EB6 RID: 3766
			internal static method To_QObject_From_QPlainTextEdit;

			// Token: 0x04000EB7 RID: 3767
			internal static method QPlnTe_document;

			// Token: 0x04000EB8 RID: 3768
			internal static method QPlnTe_setPlaceholderText;

			// Token: 0x04000EB9 RID: 3769
			internal static method QPlnTe_placeholderText;

			// Token: 0x04000EBA RID: 3770
			internal static method QPlnTe_isReadOnly;

			// Token: 0x04000EBB RID: 3771
			internal static method QPlnTe_setReadOnly;

			// Token: 0x04000EBC RID: 3772
			internal static method QPlnTe_setTextInteractionFlags;

			// Token: 0x04000EBD RID: 3773
			internal static method QPlnTe_textInteractionFlags;

			// Token: 0x04000EBE RID: 3774
			internal static method QPlnTe_tabChangesFocus;

			// Token: 0x04000EBF RID: 3775
			internal static method QPlnTe_setTabChangesFocus;

			// Token: 0x04000EC0 RID: 3776
			internal static method QPlnTe_setDocumentTitle;

			// Token: 0x04000EC1 RID: 3777
			internal static method QPlnTe_documentTitle;

			// Token: 0x04000EC2 RID: 3778
			internal static method QPlnTe_isUndoRedoEnabled;

			// Token: 0x04000EC3 RID: 3779
			internal static method QPlnTe_setUndoRedoEnabled;

			// Token: 0x04000EC4 RID: 3780
			internal static method QPlnTe_setMaximumBlockCount;

			// Token: 0x04000EC5 RID: 3781
			internal static method QPlnTe_maximumBlockCount;

			// Token: 0x04000EC6 RID: 3782
			internal static method QPlnTe_lineWrapMode;

			// Token: 0x04000EC7 RID: 3783
			internal static method QPlnTe_setLineWrapMode;

			// Token: 0x04000EC8 RID: 3784
			internal static method QPlnTe_wordWrapMode;

			// Token: 0x04000EC9 RID: 3785
			internal static method QPlnTe_setWordWrapMode;

			// Token: 0x04000ECA RID: 3786
			internal static method QPlnTe_setBackgroundVisible;

			// Token: 0x04000ECB RID: 3787
			internal static method QPlnTe_backgroundVisible;

			// Token: 0x04000ECC RID: 3788
			internal static method QPlnTe_setCenterOnScroll;

			// Token: 0x04000ECD RID: 3789
			internal static method QPlnTe_centerOnScroll;

			// Token: 0x04000ECE RID: 3790
			internal static method QPlnTe_find;

			// Token: 0x04000ECF RID: 3791
			internal static method QPlnTe_toPlainText;

			// Token: 0x04000ED0 RID: 3792
			internal static method QPlnTe_setPlainText;

			// Token: 0x04000ED1 RID: 3793
			internal static method QPlnTe_ensureCursorVisible;

			// Token: 0x04000ED2 RID: 3794
			internal static method QPlnTe_insertPlainText;

			// Token: 0x04000ED3 RID: 3795
			internal static method QPlnTe_appendPlainText;

			// Token: 0x04000ED4 RID: 3796
			internal static method QPlnTe_appendHtml;

			// Token: 0x04000ED5 RID: 3797
			internal static method QPlnTe_centerCursor;

			// Token: 0x04000ED6 RID: 3798
			internal static method QPlnTe_clear;

			// Token: 0x04000ED7 RID: 3799
			internal static method QPlnTe_selectAll;

			// Token: 0x04000ED8 RID: 3800
			internal static method QPlnTe_anchorAt;

			// Token: 0x04000ED9 RID: 3801
			internal static method QPlnTe_setTextCursor;

			// Token: 0x04000EDA RID: 3802
			internal static method QPlnTe_textCursor;

			// Token: 0x04000EDB RID: 3803
			internal static method QPlnTe_cursorForPosition;

			// Token: 0x04000EDC RID: 3804
			internal static method QPlnTe_cursorRect;

			// Token: 0x04000EDD RID: 3805
			internal static method QPlnTe_tabStopDistance;

			// Token: 0x04000EDE RID: 3806
			internal static method QPlnTe_setTabStopDistance;

			// Token: 0x04000EDF RID: 3807
			internal static method QPlnTe_viewport;

			// Token: 0x04000EE0 RID: 3808
			internal static method QPlnTe_horizontalScrollBar;

			// Token: 0x04000EE1 RID: 3809
			internal static method QPlnTe_verticalScrollBar;

			// Token: 0x04000EE2 RID: 3810
			internal static method QPlnTe_horizontalScrollBarPolicy;

			// Token: 0x04000EE3 RID: 3811
			internal static method QPlnTe_setHorizontalScrollBarPolicy;

			// Token: 0x04000EE4 RID: 3812
			internal static method QPlnTe_verticalScrollBarPolicy;

			// Token: 0x04000EE5 RID: 3813
			internal static method QPlnTe_setVerticalScrollBarPolicy;

			// Token: 0x04000EE6 RID: 3814
			internal static method QPlnTe_isTopLevel;

			// Token: 0x04000EE7 RID: 3815
			internal static method QPlnTe_isWindow;

			// Token: 0x04000EE8 RID: 3816
			internal static method QPlnTe_isModal;

			// Token: 0x04000EE9 RID: 3817
			internal static method QPlnTe_setStyleSheet;

			// Token: 0x04000EEA RID: 3818
			internal static method QPlnTe_windowTitle;

			// Token: 0x04000EEB RID: 3819
			internal static method QPlnTe_setWindowTitle;

			// Token: 0x04000EEC RID: 3820
			internal static method QPlnTe_setWindowFlags;

			// Token: 0x04000EED RID: 3821
			internal static method QPlnTe_windowFlags;

			// Token: 0x04000EEE RID: 3822
			internal static method QPlnTe_size;

			// Token: 0x04000EEF RID: 3823
			internal static method QPlnTe_resize;

			// Token: 0x04000EF0 RID: 3824
			internal static method QPlnTe_minimumSize;

			// Token: 0x04000EF1 RID: 3825
			internal static method QPlnTe_setMinimumSize;

			// Token: 0x04000EF2 RID: 3826
			internal static method QPlnTe_maximumSize;

			// Token: 0x04000EF3 RID: 3827
			internal static method QPlnTe_setMaximumSize;

			// Token: 0x04000EF4 RID: 3828
			internal static method QPlnTe_pos;

			// Token: 0x04000EF5 RID: 3829
			internal static method QPlnTe_move;

			// Token: 0x04000EF6 RID: 3830
			internal static method QPlnTe_isEnabled;

			// Token: 0x04000EF7 RID: 3831
			internal static method QPlnTe_setEnabled;

			// Token: 0x04000EF8 RID: 3832
			internal static method QPlnTe_setVisible;

			// Token: 0x04000EF9 RID: 3833
			internal static method QPlnTe_setHidden;

			// Token: 0x04000EFA RID: 3834
			internal static method QPlnTe_show;

			// Token: 0x04000EFB RID: 3835
			internal static method QPlnTe_hide;

			// Token: 0x04000EFC RID: 3836
			internal static method QPlnTe_showMinimized;

			// Token: 0x04000EFD RID: 3837
			internal static method QPlnTe_showMaximized;

			// Token: 0x04000EFE RID: 3838
			internal static method QPlnTe_showFullScreen;

			// Token: 0x04000EFF RID: 3839
			internal static method QPlnTe_showNormal;

			// Token: 0x04000F00 RID: 3840
			internal static method QPlnTe_close;

			// Token: 0x04000F01 RID: 3841
			internal static method QPlnTe_raise;

			// Token: 0x04000F02 RID: 3842
			internal static method QPlnTe_lower;

			// Token: 0x04000F03 RID: 3843
			internal static method QPlnTe_isVisible;

			// Token: 0x04000F04 RID: 3844
			internal static method QPlnTe_setAttribute;

			// Token: 0x04000F05 RID: 3845
			internal static method QPlnTe_testAttribute;

			// Token: 0x04000F06 RID: 3846
			internal static method QPlnTe_acceptDrops;

			// Token: 0x04000F07 RID: 3847
			internal static method QPlnTe_setAcceptDrops;

			// Token: 0x04000F08 RID: 3848
			internal static method QPlnTe_update;

			// Token: 0x04000F09 RID: 3849
			internal static method QPlnTe_repaint;

			// Token: 0x04000F0A RID: 3850
			internal static method QPlnTe_setCursor;

			// Token: 0x04000F0B RID: 3851
			internal static method QPlnTe_unsetCursor;

			// Token: 0x04000F0C RID: 3852
			internal static method QPlnTe_setWindowIcon;

			// Token: 0x04000F0D RID: 3853
			internal static method QPlnTe_setWindowIconText;

			// Token: 0x04000F0E RID: 3854
			internal static method QPlnTe_setWindowOpacity;

			// Token: 0x04000F0F RID: 3855
			internal static method QPlnTe_windowOpacity;

			// Token: 0x04000F10 RID: 3856
			internal static method QPlnTe_isMinimized;

			// Token: 0x04000F11 RID: 3857
			internal static method QPlnTe_isMaximized;

			// Token: 0x04000F12 RID: 3858
			internal static method QPlnTe_isFullScreen;

			// Token: 0x04000F13 RID: 3859
			internal static method QPlnTe_setMouseTracking;

			// Token: 0x04000F14 RID: 3860
			internal static method QPlnTe_hasMouseTracking;

			// Token: 0x04000F15 RID: 3861
			internal static method QPlnTe_underMouse;

			// Token: 0x04000F16 RID: 3862
			internal static method QPlnTe_mapToGlobal;

			// Token: 0x04000F17 RID: 3863
			internal static method QPlnTe_mapFromGlobal;

			// Token: 0x04000F18 RID: 3864
			internal static method QPlnTe_hasFocus;

			// Token: 0x04000F19 RID: 3865
			internal static method QPlnTe_focusPolicy;

			// Token: 0x04000F1A RID: 3866
			internal static method QPlnTe_setFocusPolicy;

			// Token: 0x04000F1B RID: 3867
			internal static method QPlnTe_setFocusProxy;

			// Token: 0x04000F1C RID: 3868
			internal static method QPlnTe_isActiveWindow;

			// Token: 0x04000F1D RID: 3869
			internal static method QPlnTe_updatesEnabled;

			// Token: 0x04000F1E RID: 3870
			internal static method QPlnTe_setUpdatesEnabled;

			// Token: 0x04000F1F RID: 3871
			internal static method QPlnTe_setFocus;

			// Token: 0x04000F20 RID: 3872
			internal static method QPlnTe_activateWindow;

			// Token: 0x04000F21 RID: 3873
			internal static method QPlnTe_clearFocus;

			// Token: 0x04000F22 RID: 3874
			internal static method QPlnTe_setSizePolicy;

			// Token: 0x04000F23 RID: 3875
			internal static method QPlnTe_devicePixelRatioF;

			// Token: 0x04000F24 RID: 3876
			internal static method QPlnTe_saveGeometry;

			// Token: 0x04000F25 RID: 3877
			internal static method QPlnTe_restoreGeometry;

			// Token: 0x04000F26 RID: 3878
			internal static method QPlnTe_addAction;

			// Token: 0x04000F27 RID: 3879
			internal static method QPlnTe_removeAction;

			// Token: 0x04000F28 RID: 3880
			internal static method QPlnTe_setParent;

			// Token: 0x04000F29 RID: 3881
			internal static method QPlnTe_parentWidget;

			// Token: 0x04000F2A RID: 3882
			internal static method QPlnTe_AddClassName;

			// Token: 0x04000F2B RID: 3883
			internal static method QPlnTe_Polish;

			// Token: 0x04000F2C RID: 3884
			internal static method QPlnTe_toolTip;

			// Token: 0x04000F2D RID: 3885
			internal static method QPlnTe_setToolTip;

			// Token: 0x04000F2E RID: 3886
			internal static method QPlnTe_statusTip;

			// Token: 0x04000F2F RID: 3887
			internal static method QPlnTe_setStatusTip;

			// Token: 0x04000F30 RID: 3888
			internal static method QPlnTe_toolTipDuration;

			// Token: 0x04000F31 RID: 3889
			internal static method QPlnTe_setToolTipDuration;

			// Token: 0x04000F32 RID: 3890
			internal static method QPlnTe_autoFillBackground;

			// Token: 0x04000F33 RID: 3891
			internal static method QPlnTe_setAutoFillBackground;
		}
	}
}
