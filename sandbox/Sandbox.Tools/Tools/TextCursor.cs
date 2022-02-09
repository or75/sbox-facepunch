using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace Tools
{
	// Token: 0x02000086 RID: 134
	public class TextCursor : IDisposable
	{
		// Token: 0x06001362 RID: 4962 RVA: 0x00053626 File Offset: 0x00051826
		internal TextCursor(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06001363 RID: 4963 RVA: 0x00053638 File Offset: 0x00051838
		~TextCursor()
		{
			if (!this.IsNull)
			{
				MainThread.QueueDispose(this);
			}
		}

		// Token: 0x06001364 RID: 4964 RVA: 0x0005366C File Offset: 0x0005186C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
			defaultInterpolatedStringHandler.AppendLiteral("TextCursor ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06001365 RID: 4965 RVA: 0x000536A8 File Offset: 0x000518A8
		internal bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06001366 RID: 4966 RVA: 0x000536BA File Offset: 0x000518BA
		internal bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06001367 RID: 4967 RVA: 0x000536C5 File Offset: 0x000518C5
		internal IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06001368 RID: 4968 RVA: 0x000536D8 File Offset: 0x000518D8
		internal void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("TextCursor was null when calling " + n);
			}
		}

		// Token: 0x06001369 RID: 4969 RVA: 0x000536F3 File Offset: 0x000518F3
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x0600136A RID: 4970 RVA: 0x00053700 File Offset: 0x00051900
		internal static TextCursor CreateFromBlock(QTextBlock block)
		{
			method qtextC_CreateFromBlock = TextCursor.__N.QTextC_CreateFromBlock;
			return new TextCursor(calli(System.IntPtr(System.IntPtr), block.GetPointerAssertIfNull(), qtextC_CreateFromBlock));
		}

		// Token: 0x0600136B RID: 4971 RVA: 0x00053724 File Offset: 0x00051924
		void IDisposable.Dispose()
		{
			if (this.IsNull)
			{
				return;
			}
			this.NullCheck("Dispose");
			try
			{
				method qtextC_Dispose = TextCursor.__N.QTextC_Dispose;
				calli(System.Void(System.IntPtr), this.self, qtextC_Dispose);
			}
			finally
			{
				this.self = 0;
			}
		}

		// Token: 0x0600136C RID: 4972 RVA: 0x00053778 File Offset: 0x00051978
		internal int blockNumber()
		{
			this.NullCheck("blockNumber");
			method qtextC_blockNumber = TextCursor.__N.QTextC_blockNumber;
			return calli(System.Int32(System.IntPtr), this.self, qtextC_blockNumber);
		}

		// Token: 0x0600136D RID: 4973 RVA: 0x000537A4 File Offset: 0x000519A4
		internal int columnNumber()
		{
			this.NullCheck("columnNumber");
			method qtextC_columnNumber = TextCursor.__N.QTextC_columnNumber;
			return calli(System.Int32(System.IntPtr), this.self, qtextC_columnNumber);
		}

		// Token: 0x0600136E RID: 4974 RVA: 0x000537D0 File Offset: 0x000519D0
		internal string selectedText()
		{
			this.NullCheck("selectedText");
			method qtextC_selectedText = TextCursor.__N.QTextC_selectedText;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qtextC_selectedText));
		}

		// Token: 0x0600136F RID: 4975 RVA: 0x00053800 File Offset: 0x00051A00
		internal bool atBlockStart()
		{
			this.NullCheck("atBlockStart");
			method qtextC_atBlockStart = TextCursor.__N.QTextC_atBlockStart;
			return calli(System.Int32(System.IntPtr), this.self, qtextC_atBlockStart) > 0;
		}

		// Token: 0x06001370 RID: 4976 RVA: 0x00053830 File Offset: 0x00051A30
		internal bool atBlockEnd()
		{
			this.NullCheck("atBlockEnd");
			method qtextC_atBlockEnd = TextCursor.__N.QTextC_atBlockEnd;
			return calli(System.Int32(System.IntPtr), this.self, qtextC_atBlockEnd) > 0;
		}

		// Token: 0x06001371 RID: 4977 RVA: 0x00053860 File Offset: 0x00051A60
		internal bool atStart()
		{
			this.NullCheck("atStart");
			method qtextC_atStart = TextCursor.__N.QTextC_atStart;
			return calli(System.Int32(System.IntPtr), this.self, qtextC_atStart) > 0;
		}

		// Token: 0x06001372 RID: 4978 RVA: 0x00053890 File Offset: 0x00051A90
		internal bool atEnd()
		{
			this.NullCheck("atEnd");
			method qtextC_atEnd = TextCursor.__N.QTextC_atEnd;
			return calli(System.Int32(System.IntPtr), this.self, qtextC_atEnd) > 0;
		}

		// Token: 0x06001373 RID: 4979 RVA: 0x000538C0 File Offset: 0x00051AC0
		internal void insertHtml(string html)
		{
			this.NullCheck("insertHtml");
			method qtextC_insertHtml = TextCursor.__N.QTextC_insertHtml;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(html), qtextC_insertHtml);
		}

		// Token: 0x06001374 RID: 4980 RVA: 0x000538F0 File Offset: 0x00051AF0
		internal void insertText(string text)
		{
			this.NullCheck("insertText");
			method qtextC_insertText = TextCursor.__N.QTextC_insertText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qtextC_insertText);
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x00053920 File Offset: 0x00051B20
		internal bool hasSelection()
		{
			this.NullCheck("hasSelection");
			method qtextC_hasSelection = TextCursor.__N.QTextC_hasSelection;
			return calli(System.Int32(System.IntPtr), this.self, qtextC_hasSelection) > 0;
		}

		// Token: 0x06001376 RID: 4982 RVA: 0x00053950 File Offset: 0x00051B50
		internal bool hasComplexSelection()
		{
			this.NullCheck("hasComplexSelection");
			method qtextC_hasComplexSelection = TextCursor.__N.QTextC_hasComplexSelection;
			return calli(System.Int32(System.IntPtr), this.self, qtextC_hasComplexSelection) > 0;
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x00053980 File Offset: 0x00051B80
		internal void removeSelectedText()
		{
			this.NullCheck("removeSelectedText");
			method qtextC_removeSelectedText = TextCursor.__N.QTextC_removeSelectedText;
			calli(System.Void(System.IntPtr), this.self, qtextC_removeSelectedText);
		}

		// Token: 0x06001378 RID: 4984 RVA: 0x000539AC File Offset: 0x00051BAC
		internal void clearSelection()
		{
			this.NullCheck("clearSelection");
			method qtextC_clearSelection = TextCursor.__N.QTextC_clearSelection;
			calli(System.Void(System.IntPtr), this.self, qtextC_clearSelection);
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x000539D8 File Offset: 0x00051BD8
		internal int selectionStart()
		{
			this.NullCheck("selectionStart");
			method qtextC_selectionStart = TextCursor.__N.QTextC_selectionStart;
			return calli(System.Int32(System.IntPtr), this.self, qtextC_selectionStart);
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x00053A04 File Offset: 0x00051C04
		internal int selectionEnd()
		{
			this.NullCheck("selectionEnd");
			method qtextC_selectionEnd = TextCursor.__N.QTextC_selectionEnd;
			return calli(System.Int32(System.IntPtr), this.self, qtextC_selectionEnd);
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x00053A30 File Offset: 0x00051C30
		internal int position()
		{
			this.NullCheck("position");
			method qtextC_position = TextCursor.__N.QTextC_position;
			return calli(System.Int32(System.IntPtr), this.self, qtextC_position);
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x00053A5C File Offset: 0x00051C5C
		internal int positionInBlock()
		{
			this.NullCheck("positionInBlock");
			method qtextC_positionInBlock = TextCursor.__N.QTextC_positionInBlock;
			return calli(System.Int32(System.IntPtr), this.self, qtextC_positionInBlock);
		}

		// Token: 0x0600137D RID: 4989 RVA: 0x00053A88 File Offset: 0x00051C88
		internal void setPosition(int pos)
		{
			this.NullCheck("setPosition");
			method qtextC_setPosition = TextCursor.__N.QTextC_setPosition;
			calli(System.Void(System.IntPtr,System.Int32), this.self, pos, qtextC_setPosition);
		}

		// Token: 0x0600137E RID: 4990 RVA: 0x00053AB4 File Offset: 0x00051CB4
		internal void deleteChar()
		{
			this.NullCheck("deleteChar");
			method qtextC_deleteChar = TextCursor.__N.QTextC_deleteChar;
			calli(System.Void(System.IntPtr), this.self, qtextC_deleteChar);
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x00053AE0 File Offset: 0x00051CE0
		internal void deletePreviousChar()
		{
			this.NullCheck("deletePreviousChar");
			method qtextC_deletePreviousChar = TextCursor.__N.QTextC_deletePreviousChar;
			calli(System.Void(System.IntPtr), this.self, qtextC_deletePreviousChar);
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x00053B0C File Offset: 0x00051D0C
		internal void select(QTextCursorSelectionType selection)
		{
			this.NullCheck("select");
			method qtextC_select = TextCursor.__N.QTextC_select;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)selection, qtextC_select);
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06001381 RID: 4993 RVA: 0x00053B38 File Offset: 0x00051D38
		// (set) Token: 0x06001382 RID: 4994 RVA: 0x00053B40 File Offset: 0x00051D40
		public int Position
		{
			get
			{
				return this.position();
			}
			set
			{
				this.setPosition(value);
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06001383 RID: 4995 RVA: 0x00053B49 File Offset: 0x00051D49
		public int BlockNumber
		{
			get
			{
				return this.blockNumber();
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06001384 RID: 4996 RVA: 0x00053B51 File Offset: 0x00051D51
		public int ColumnNumber
		{
			get
			{
				return this.columnNumber();
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06001385 RID: 4997 RVA: 0x00053B59 File Offset: 0x00051D59
		public string SelectedText
		{
			get
			{
				return this.selectedText();
			}
		}

		// Token: 0x06001386 RID: 4998 RVA: 0x00053B61 File Offset: 0x00051D61
		public void InsertHtml(string str)
		{
			this.insertHtml(str);
		}

		// Token: 0x06001387 RID: 4999 RVA: 0x00053B6A File Offset: 0x00051D6A
		public void InsertText(string str)
		{
			this.insertText(str);
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06001388 RID: 5000 RVA: 0x00053B73 File Offset: 0x00051D73
		public bool HasSelection
		{
			get
			{
				return this.hasSelection();
			}
		}

		// Token: 0x06001389 RID: 5001 RVA: 0x00053B7B File Offset: 0x00051D7B
		public void RemoveSelectedText()
		{
			this.removeSelectedText();
		}

		// Token: 0x0600138A RID: 5002 RVA: 0x00053B83 File Offset: 0x00051D83
		public void ClearSelection()
		{
			this.clearSelection();
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600138B RID: 5003 RVA: 0x00053B8B File Offset: 0x00051D8B
		public int SelectionStart
		{
			get
			{
				return this.selectionStart();
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600138C RID: 5004 RVA: 0x00053B93 File Offset: 0x00051D93
		public int SelectionEnd
		{
			get
			{
				return this.selectionEnd();
			}
		}

		// Token: 0x0600138D RID: 5005 RVA: 0x00053B9B File Offset: 0x00051D9B
		public void SelectBlockUnderCursor()
		{
			this.select(QTextCursorSelectionType.BlockUnderCursor);
		}

		// Token: 0x040001BA RID: 442
		internal IntPtr self;

		// Token: 0x02000142 RID: 322
		internal static class __N
		{
			// Token: 0x0400126F RID: 4719
			internal static method QTextC_CreateFromBlock;

			// Token: 0x04001270 RID: 4720
			internal static method QTextC_Dispose;

			// Token: 0x04001271 RID: 4721
			internal static method QTextC_blockNumber;

			// Token: 0x04001272 RID: 4722
			internal static method QTextC_columnNumber;

			// Token: 0x04001273 RID: 4723
			internal static method QTextC_selectedText;

			// Token: 0x04001274 RID: 4724
			internal static method QTextC_atBlockStart;

			// Token: 0x04001275 RID: 4725
			internal static method QTextC_atBlockEnd;

			// Token: 0x04001276 RID: 4726
			internal static method QTextC_atStart;

			// Token: 0x04001277 RID: 4727
			internal static method QTextC_atEnd;

			// Token: 0x04001278 RID: 4728
			internal static method QTextC_insertHtml;

			// Token: 0x04001279 RID: 4729
			internal static method QTextC_insertText;

			// Token: 0x0400127A RID: 4730
			internal static method QTextC_hasSelection;

			// Token: 0x0400127B RID: 4731
			internal static method QTextC_hasComplexSelection;

			// Token: 0x0400127C RID: 4732
			internal static method QTextC_removeSelectedText;

			// Token: 0x0400127D RID: 4733
			internal static method QTextC_clearSelection;

			// Token: 0x0400127E RID: 4734
			internal static method QTextC_selectionStart;

			// Token: 0x0400127F RID: 4735
			internal static method QTextC_selectionEnd;

			// Token: 0x04001280 RID: 4736
			internal static method QTextC_position;

			// Token: 0x04001281 RID: 4737
			internal static method QTextC_positionInBlock;

			// Token: 0x04001282 RID: 4738
			internal static method QTextC_setPosition;

			// Token: 0x04001283 RID: 4739
			internal static method QTextC_deleteChar;

			// Token: 0x04001284 RID: 4740
			internal static method QTextC_deletePreviousChar;

			// Token: 0x04001285 RID: 4741
			internal static method QTextC_select;
		}
	}
}
