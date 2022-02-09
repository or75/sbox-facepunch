using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000C7 RID: 199
	public class TextEdit : Widget
	{
		// Token: 0x06001678 RID: 5752 RVA: 0x00059713 File Offset: 0x00057913
		internal TextEdit(QPlainTextEdit widget)
		{
			this.NativeInit(widget);
		}

		// Token: 0x06001679 RID: 5753 RVA: 0x00059728 File Offset: 0x00057928
		public TextEdit(Widget parent = null)
		{
			InteropSystem.Alloc<TextEdit>(this);
			this.NativeInit(CPlainTextEdit.Create((parent != null) ? parent._widget : default(QWidget), this));
			this.VerticalScrollbar = new ScrollBar(this._pte.verticalScrollBar());
			this.HorizontalScrollbar = new ScrollBar(this._pte.horizontalScrollBar());
		}

		// Token: 0x0600167A RID: 5754 RVA: 0x0005979C File Offset: 0x0005799C
		internal override void NativeInit(IntPtr ptr)
		{
			this._pte = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x0600167B RID: 5755 RVA: 0x000597B1 File Offset: 0x000579B1
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._pte = default(QPlainTextEdit);
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600167C RID: 5756 RVA: 0x000597C5 File Offset: 0x000579C5
		// (set) Token: 0x0600167D RID: 5757 RVA: 0x000597D8 File Offset: 0x000579D8
		public bool TextSelectable
		{
			get
			{
				return (this._pte.textInteractionFlags() & TextInteractionFlags.TextSelectableByMouse) > TextInteractionFlags.NoTextInteraction;
			}
			set
			{
				TextInteractionFlags flags = this._pte.textInteractionFlags();
				if (value)
				{
					flags |= TextInteractionFlags.TextSelectableByMouse;
					flags |= TextInteractionFlags.TextSelectableByKeyboard;
				}
				else
				{
					flags &= (TextInteractionFlags)(-2);
					flags &= (TextInteractionFlags)(-3);
				}
				this._pte.setTextInteractionFlags(flags);
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x0600167E RID: 5758 RVA: 0x00059814 File Offset: 0x00057A14
		// (set) Token: 0x0600167F RID: 5759 RVA: 0x00059828 File Offset: 0x00057A28
		public bool LinksClickable
		{
			get
			{
				return (this._pte.textInteractionFlags() & TextInteractionFlags.LinksAccessibleByMouse) > TextInteractionFlags.NoTextInteraction;
			}
			set
			{
				TextInteractionFlags flags = this._pte.textInteractionFlags();
				if (value)
				{
					flags |= TextInteractionFlags.LinksAccessibleByMouse;
					flags |= TextInteractionFlags.LinksAccessibleByKeyboard;
				}
				else
				{
					flags &= (TextInteractionFlags)(-5);
					flags &= (TextInteractionFlags)(-9);
				}
				this._pte.setTextInteractionFlags(flags);
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06001680 RID: 5760 RVA: 0x00059864 File Offset: 0x00057A64
		// (set) Token: 0x06001681 RID: 5761 RVA: 0x00059878 File Offset: 0x00057A78
		public bool Editable
		{
			get
			{
				return (this._pte.textInteractionFlags() & TextInteractionFlags.TextEditable) > TextInteractionFlags.NoTextInteraction;
			}
			set
			{
				TextInteractionFlags flags = this._pte.textInteractionFlags();
				if (value)
				{
					flags |= TextInteractionFlags.TextEditable;
				}
				else
				{
					flags &= (TextInteractionFlags)(-17);
				}
				this._pte.setTextInteractionFlags(flags);
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06001682 RID: 5762 RVA: 0x000598AC File Offset: 0x00057AAC
		// (set) Token: 0x06001683 RID: 5763 RVA: 0x000598B4 File Offset: 0x00057AB4
		public ScrollBar VerticalScrollbar { get; set; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06001684 RID: 5764 RVA: 0x000598BD File Offset: 0x00057ABD
		// (set) Token: 0x06001685 RID: 5765 RVA: 0x000598C5 File Offset: 0x00057AC5
		public ScrollBar HorizontalScrollbar { get; set; }

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06001686 RID: 5766 RVA: 0x000598CE File Offset: 0x00057ACE
		// (set) Token: 0x06001687 RID: 5767 RVA: 0x000598DB File Offset: 0x00057ADB
		public ScrollbarMode HorizontalScrollbarMode
		{
			get
			{
				return this._pte.horizontalScrollBarPolicy();
			}
			set
			{
				this._pte.setHorizontalScrollBarPolicy(value);
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06001688 RID: 5768 RVA: 0x000598E9 File Offset: 0x00057AE9
		// (set) Token: 0x06001689 RID: 5769 RVA: 0x000598F6 File Offset: 0x00057AF6
		public ScrollbarMode VerticalScrollbarMode
		{
			get
			{
				return this._pte.verticalScrollBarPolicy();
			}
			set
			{
				this._pte.setVerticalScrollBarPolicy(value);
			}
		}

		// Token: 0x0600168A RID: 5770 RVA: 0x00059904 File Offset: 0x00057B04
		public void ScrollToBottom()
		{
			this.VerticalScrollbar.SliderPosition = this.VerticalScrollbar.Maximum;
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x0600168B RID: 5771 RVA: 0x0005991C File Offset: 0x00057B1C
		// (set) Token: 0x0600168C RID: 5772 RVA: 0x00059929 File Offset: 0x00057B29
		public string PlainText
		{
			get
			{
				return this._pte.toPlainText();
			}
			set
			{
				this._pte.setPlainText(value);
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x0600168D RID: 5773 RVA: 0x00059937 File Offset: 0x00057B37
		// (set) Token: 0x0600168E RID: 5774 RVA: 0x00059944 File Offset: 0x00057B44
		public string PlaceholderText
		{
			get
			{
				return this._pte.placeholderText();
			}
			set
			{
				this._pte.setPlaceholderText(value);
			}
		}

		// Token: 0x0600168F RID: 5775 RVA: 0x00059952 File Offset: 0x00057B52
		public void AppendHtml(string html)
		{
			this._pte.appendHtml(html);
		}

		// Token: 0x06001690 RID: 5776 RVA: 0x00059960 File Offset: 0x00057B60
		public void AppendPlainText(string text)
		{
			this._pte.appendPlainText(text);
		}

		// Token: 0x06001691 RID: 5777 RVA: 0x0005996E File Offset: 0x00057B6E
		public virtual void Clear()
		{
			this._pte.clear();
		}

		// Token: 0x06001692 RID: 5778 RVA: 0x0005997B File Offset: 0x00057B7B
		public void SelectAll()
		{
			this._pte.selectAll();
		}

		// Token: 0x06001693 RID: 5779 RVA: 0x00059988 File Offset: 0x00057B88
		public void CenterOnCursor()
		{
			this._pte.centerCursor();
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06001694 RID: 5780 RVA: 0x00059995 File Offset: 0x00057B95
		// (set) Token: 0x06001695 RID: 5781 RVA: 0x000599A2 File Offset: 0x00057BA2
		public bool CenterOnScroll
		{
			get
			{
				return this._pte.centerOnScroll();
			}
			set
			{
				this._pte.setCenterOnScroll(value);
			}
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06001696 RID: 5782 RVA: 0x000599B0 File Offset: 0x00057BB0
		// (set) Token: 0x06001697 RID: 5783 RVA: 0x000599BD File Offset: 0x00057BBD
		public bool BackgroundVisible
		{
			get
			{
				return this._pte.backgroundVisible();
			}
			set
			{
				this._pte.setBackgroundVisible(value);
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06001698 RID: 5784 RVA: 0x000599CB File Offset: 0x00057BCB
		// (set) Token: 0x06001699 RID: 5785 RVA: 0x000599D8 File Offset: 0x00057BD8
		public int MaximumBlockCount
		{
			get
			{
				return this._pte.maximumBlockCount();
			}
			set
			{
				this._pte.setMaximumBlockCount(value);
			}
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x0600169A RID: 5786 RVA: 0x000599E6 File Offset: 0x00057BE6
		// (set) Token: 0x0600169B RID: 5787 RVA: 0x000599F3 File Offset: 0x00057BF3
		public float TabSize
		{
			get
			{
				return this._pte.tabStopDistance();
			}
			set
			{
				this._pte.setTabStopDistance(value);
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600169C RID: 5788 RVA: 0x00059A01 File Offset: 0x00057C01
		// (set) Token: 0x0600169D RID: 5789 RVA: 0x00059A0E File Offset: 0x00057C0E
		public bool ReadOnly
		{
			get
			{
				return this._pte.isReadOnly();
			}
			set
			{
				this._pte.setReadOnly(value);
			}
		}

		// Token: 0x0600169E RID: 5790 RVA: 0x00059A1C File Offset: 0x00057C1C
		public void SetTextCursor(TextCursor cursor)
		{
			this._pte.setTextCursor(cursor);
		}

		// Token: 0x0600169F RID: 5791 RVA: 0x00059A2A File Offset: 0x00057C2A
		public TextCursor GetCursorAtPosition(Vector2 position)
		{
			return this._pte.cursorForPosition(position);
		}

		// Token: 0x060016A0 RID: 5792 RVA: 0x00059A3D File Offset: 0x00057C3D
		public TextCursor GetTextCursor()
		{
			return this._pte.textCursor();
		}

		// Token: 0x060016A1 RID: 5793 RVA: 0x00059A4C File Offset: 0x00057C4C
		public Rect GetCursorRect(TextCursor cursor)
		{
			return this._pte.cursorRect(cursor).Rect;
		}

		// Token: 0x060016A2 RID: 5794 RVA: 0x00059A6D File Offset: 0x00057C6D
		public string GetAnchorAt(Vector2 point)
		{
			return this._pte.anchorAt(point);
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060016A3 RID: 5795 RVA: 0x00059A80 File Offset: 0x00057C80
		// (set) Token: 0x060016A4 RID: 5796 RVA: 0x00059A88 File Offset: 0x00057C88
		public override CursorShape Cursor
		{
			get
			{
				return base.Cursor;
			}
			set
			{
				if (base.Cursor == value)
				{
					return;
				}
				base.Cursor = value;
				QWidget w = this._pte.viewport();
				if (this.Cursor == CursorShape.None)
				{
					w.unsetCursor();
					return;
				}
				w.setCursor(this.Cursor);
			}
		}

		// Token: 0x060016A5 RID: 5797 RVA: 0x00059AD4 File Offset: 0x00057CD4
		public TextCursor GetCursorAtBlock(int block)
		{
			return TextCursor.CreateFromBlock(this._pte.document().findBlockByNumber(block));
		}

		// Token: 0x0400049C RID: 1180
		private QPlainTextEdit _pte;
	}
}
