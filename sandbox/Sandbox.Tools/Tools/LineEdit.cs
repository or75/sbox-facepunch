using System;
using System.Collections.Generic;
using Native;
using Sandbox;
using Sandbox.Internal;

namespace Tools
{
	// Token: 0x020000BC RID: 188
	public class LineEdit : Widget
	{
		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06001589 RID: 5513 RVA: 0x00057A4C File Offset: 0x00055C4C
		// (set) Token: 0x0600158A RID: 5514 RVA: 0x00057A54 File Offset: 0x00055C54
		public string HistoryCookie
		{
			get
			{
				return this._historyCookie;
			}
			set
			{
				if (this._historyCookie == value)
				{
					return;
				}
				this._historyCookie = value;
				this.RestoreHistoryFromCookie();
			}
		}

		// Token: 0x0600158B RID: 5515 RVA: 0x00057A74 File Offset: 0x00055C74
		public virtual void RestoreHistoryFromCookie()
		{
			if (string.IsNullOrWhiteSpace(this.HistoryCookie))
			{
				return;
			}
			this.historyEntries = GlobalToolsNamespace.Cookie.Get<List<string>>("LineEdit." + this.HistoryCookie + ".History", this.historyEntries);
			if (this.historyEntries == null)
			{
				this.historyEntries = new List<string>();
			}
		}

		// Token: 0x0600158C RID: 5516 RVA: 0x00057ACD File Offset: 0x00055CCD
		public virtual void SaveHistoryCookie()
		{
			if (string.IsNullOrWhiteSpace(this.HistoryCookie))
			{
				return;
			}
			GlobalToolsNamespace.Cookie.Set<List<string>>("LineEdit." + this.HistoryCookie + ".History", this.historyEntries);
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600158D RID: 5517 RVA: 0x00057B04 File Offset: 0x00055D04
		// (remove) Token: 0x0600158E RID: 5518 RVA: 0x00057B3C File Offset: 0x00055D3C
		public event Action<string> TextChanged;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600158F RID: 5519 RVA: 0x00057B74 File Offset: 0x00055D74
		// (remove) Token: 0x06001590 RID: 5520 RVA: 0x00057BAC File Offset: 0x00055DAC
		public event Action<string> TextEdited;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06001591 RID: 5521 RVA: 0x00057BE4 File Offset: 0x00055DE4
		// (remove) Token: 0x06001592 RID: 5522 RVA: 0x00057C1C File Offset: 0x00055E1C
		public event Action ReturnPressed;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06001593 RID: 5523 RVA: 0x00057C54 File Offset: 0x00055E54
		// (remove) Token: 0x06001594 RID: 5524 RVA: 0x00057C8C File Offset: 0x00055E8C
		public event Action EditingFinished;

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06001595 RID: 5525 RVA: 0x00057CC1 File Offset: 0x00055EC1
		// (set) Token: 0x06001596 RID: 5526 RVA: 0x00057CCE File Offset: 0x00055ECE
		public string Text
		{
			get
			{
				return this._lineedit.text();
			}
			set
			{
				this._lineedit.setText(value);
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06001597 RID: 5527 RVA: 0x00057CDC File Offset: 0x00055EDC
		public string DisplayText
		{
			get
			{
				return this._lineedit.displayText();
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06001598 RID: 5528 RVA: 0x00057CE9 File Offset: 0x00055EE9
		// (set) Token: 0x06001599 RID: 5529 RVA: 0x00057CF6 File Offset: 0x00055EF6
		public string PlaceholderText
		{
			get
			{
				return this._lineedit.placeholderText();
			}
			set
			{
				this._lineedit.setPlaceholderText(value);
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x0600159A RID: 5530 RVA: 0x00057D04 File Offset: 0x00055F04
		// (set) Token: 0x0600159B RID: 5531 RVA: 0x00057D11 File Offset: 0x00055F11
		public int MaxLength
		{
			get
			{
				return this._lineedit.maxLength();
			}
			set
			{
				this._lineedit.setMaxLength(value);
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x0600159C RID: 5532 RVA: 0x00057D1F File Offset: 0x00055F1F
		// (set) Token: 0x0600159D RID: 5533 RVA: 0x00057D2C File Offset: 0x00055F2C
		public bool ClearButtonEnabled
		{
			get
			{
				return this._lineedit.isClearButtonEnabled();
			}
			set
			{
				this._lineedit.setClearButtonEnabled(value);
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x0600159E RID: 5534 RVA: 0x00057D3A File Offset: 0x00055F3A
		// (set) Token: 0x0600159F RID: 5535 RVA: 0x00057D47 File Offset: 0x00055F47
		public bool ReadOnly
		{
			get
			{
				return this._lineedit.isReadOnly();
			}
			set
			{
				this._lineedit.setReadOnly(value);
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060015A0 RID: 5536 RVA: 0x00057D55 File Offset: 0x00055F55
		public bool HasSelectedText
		{
			get
			{
				return this._lineedit.hasSelectedText();
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060015A1 RID: 5537 RVA: 0x00057D62 File Offset: 0x00055F62
		public string SelectedText
		{
			get
			{
				return this._lineedit.selectedText();
			}
		}

		// Token: 0x060015A2 RID: 5538 RVA: 0x00057D6F File Offset: 0x00055F6F
		public void Clear()
		{
			this._lineedit.clear();
		}

		// Token: 0x060015A3 RID: 5539 RVA: 0x00057D7C File Offset: 0x00055F7C
		public void SelectAll()
		{
			this._lineedit.selectAll();
		}

		// Token: 0x060015A4 RID: 5540 RVA: 0x00057D89 File Offset: 0x00055F89
		public void Undo()
		{
			this._lineedit.undo();
		}

		// Token: 0x060015A5 RID: 5541 RVA: 0x00057D96 File Offset: 0x00055F96
		public void Redo()
		{
			this._lineedit.redo();
		}

		// Token: 0x060015A6 RID: 5542 RVA: 0x00057DA3 File Offset: 0x00055FA3
		public void Cut()
		{
			this._lineedit.cut();
		}

		// Token: 0x060015A7 RID: 5543 RVA: 0x00057DB0 File Offset: 0x00055FB0
		public void Copy()
		{
			this._lineedit.copy();
		}

		// Token: 0x060015A8 RID: 5544 RVA: 0x00057DBD File Offset: 0x00055FBD
		public void Paste()
		{
			this._lineedit.paste();
		}

		// Token: 0x060015A9 RID: 5545 RVA: 0x00057DCA File Offset: 0x00055FCA
		public void Deselect()
		{
			this._lineedit.deselect();
		}

		// Token: 0x060015AA RID: 5546 RVA: 0x00057DD7 File Offset: 0x00055FD7
		public void Insert(string val)
		{
			this._lineedit.insert(val);
		}

		// Token: 0x060015AB RID: 5547 RVA: 0x00057DE5 File Offset: 0x00055FE5
		public void SetValidator(string str)
		{
			if (this._clineedit.IsNull)
			{
				return;
			}
			this._clineedit.SetValidation(str);
		}

		// Token: 0x060015AC RID: 5548 RVA: 0x00057E01 File Offset: 0x00056001
		internal LineEdit(IntPtr ptr)
		{
			this.NativeInit(ptr);
		}

		// Token: 0x060015AD RID: 5549 RVA: 0x00057E1C File Offset: 0x0005601C
		public LineEdit(Widget parent = null)
		{
			InteropSystem.Alloc<LineEdit>(this);
			this._clineedit = CLineEdit.Create((parent != null) ? parent._widget : default(QWidget), this);
			this.NativeInit(this._clineedit);
		}

		// Token: 0x060015AE RID: 5550 RVA: 0x00057E71 File Offset: 0x00056071
		public LineEdit(string title, Widget parent = null)
			: this(parent)
		{
			this.Text = title;
		}

		// Token: 0x060015AF RID: 5551 RVA: 0x00057E81 File Offset: 0x00056081
		internal override void NativeInit(IntPtr ptr)
		{
			this._lineedit = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x060015B0 RID: 5552 RVA: 0x00057E96 File Offset: 0x00056096
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._lineedit = default(QLineEdit);
		}

		// Token: 0x060015B1 RID: 5553 RVA: 0x00057EAA File Offset: 0x000560AA
		protected virtual void OnTextChanged(string value)
		{
			AutoComplete autoComplete = this.AutoComplete;
			if (autoComplete != null)
			{
				autoComplete.OnAutoComplete(value, base.ScreenPosition);
			}
			Action<string> textChanged = this.TextChanged;
			if (textChanged == null)
			{
				return;
			}
			textChanged(value);
		}

		// Token: 0x060015B2 RID: 5554 RVA: 0x00057ED5 File Offset: 0x000560D5
		protected virtual void OnTextEdited(string value)
		{
			Action<string> textEdited = this.TextEdited;
			if (textEdited != null)
			{
				textEdited(value);
			}
			DataBind dataBinding = base.DataBinding;
			if (dataBinding != null)
			{
				dataBinding.SetValue(value);
			}
			base.MakeSignal("valuechanged");
		}

		// Token: 0x060015B3 RID: 5555 RVA: 0x00057F06 File Offset: 0x00056106
		protected virtual void OnReturnPressed()
		{
			Action returnPressed = this.ReturnPressed;
			if (returnPressed == null)
			{
				return;
			}
			returnPressed();
		}

		// Token: 0x060015B4 RID: 5556 RVA: 0x00057F18 File Offset: 0x00056118
		protected virtual void OnEditingFinished()
		{
			Action editingFinished = this.EditingFinished;
			if (editingFinished == null)
			{
				return;
			}
			editingFinished();
		}

		// Token: 0x060015B5 RID: 5557 RVA: 0x00057F2A File Offset: 0x0005612A
		internal void InternalTextChanged(string value)
		{
			this.OnTextChanged(value);
		}

		// Token: 0x060015B6 RID: 5558 RVA: 0x00057F33 File Offset: 0x00056133
		internal void InternalTextEdited(string value)
		{
			this.OnTextEdited(value);
		}

		// Token: 0x060015B7 RID: 5559 RVA: 0x00057F3C File Offset: 0x0005613C
		internal void InternalReturnPressed()
		{
			this.OnReturnPressed();
		}

		// Token: 0x060015B8 RID: 5560 RVA: 0x00057F44 File Offset: 0x00056144
		internal void InternalEditingFinished()
		{
			this.OnEditingFinished();
		}

		// Token: 0x060015B9 RID: 5561 RVA: 0x00057F4C File Offset: 0x0005614C
		public void SetAutoComplete(Action<Menu, string> func)
		{
			this.AutoComplete = new AutoComplete(this);
			this.AutoComplete.OnOptionSelected = delegate(string o)
			{
				this.Text = o;
			};
			this.AutoComplete.OnBuildOptions = func;
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060015BA RID: 5562 RVA: 0x00057F7D File Offset: 0x0005617D
		// (set) Token: 0x060015BB RID: 5563 RVA: 0x00057F85 File Offset: 0x00056185
		public AutoComplete AutoComplete { get; set; }

		// Token: 0x060015BC RID: 5564 RVA: 0x00057F8E File Offset: 0x0005618E
		protected override void OnBlur(FocusChangeReason reason)
		{
			AutoComplete autoComplete = this.AutoComplete;
			if (autoComplete != null)
			{
				autoComplete.OnParentBlur();
			}
			base.OnBlur(reason);
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060015BD RID: 5565 RVA: 0x00057FA8 File Offset: 0x000561A8
		public bool AutoCompleteVisible
		{
			get
			{
				AutoComplete autoComplete = this.AutoComplete;
				return autoComplete != null && autoComplete.Visible;
			}
		}

		/// <summary>
		/// If we have our menus open, let use tab/shift tab to navigate instead of switching to next control
		/// </summary>
		// Token: 0x060015BE RID: 5566 RVA: 0x00057FBB File Offset: 0x000561BB
		protected override bool FocusNext()
		{
			return this.HistoryVisible || this.AutoCompleteVisible;
		}

		/// <summary>
		/// If we have our menus open, let use tab/shift tab to navigate instead of switching to next control
		/// </summary>
		// Token: 0x060015BF RID: 5567 RVA: 0x00057FCD File Offset: 0x000561CD
		protected override bool FocusPrevious()
		{
			return this.HistoryVisible || this.AutoCompleteVisible;
		}

		// Token: 0x060015C0 RID: 5568 RVA: 0x00057FE0 File Offset: 0x000561E0
		protected override void OnKeyPress(KeyEvent e)
		{
			if (!this.AutoCompleteVisible && !this.HistoryVisible && this.MaxHistoryItems > 0 && (e.Key == KeyCode.Up || e.Key == KeyCode.Down))
			{
				this.OpenHistory();
			}
			if (this.HistoryVisible || this.AutoCompleteVisible)
			{
				if (e.Key == KeyCode.Tab)
				{
					e.Key = KeyCode.Down;
				}
				if (e.Key == KeyCode.Backtab)
				{
					e.Key = KeyCode.Up;
				}
			}
			if (this.HistoryVisible)
			{
				AutoComplete historyMenu = this.historyMenu;
				if (historyMenu != null)
				{
					historyMenu.OnParentKeyPress(e);
				}
			}
			else
			{
				AutoComplete autoComplete = this.AutoComplete;
				if (autoComplete != null)
				{
					autoComplete.OnParentKeyPress(e);
				}
			}
			if (this.HistoryVisible && !e.Accepted)
			{
				this.historyMenu.Visible = false;
			}
			base.OnKeyPress(e);
		}

		// Token: 0x060015C1 RID: 5569 RVA: 0x000580BE File Offset: 0x000562BE
		protected override void DataValueChanged(object obj)
		{
			this.Text = ((obj != null) ? obj.ToString() : null) ?? "";
		}

		// Token: 0x060015C2 RID: 5570 RVA: 0x000580DB File Offset: 0x000562DB
		public Option AddOptionToFront(Option option)
		{
			Assert.NotNull<Option>(option);
			this._lineedit.addAction(option._action, 0);
			return option;
		}

		// Token: 0x060015C3 RID: 5571 RVA: 0x000580F6 File Offset: 0x000562F6
		public Option AddOptionToEnd(Option option)
		{
			Assert.NotNull<Option>(option);
			this._lineedit.addAction(option._action, 1);
			return option;
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060015C4 RID: 5572 RVA: 0x00058111 File Offset: 0x00056311
		// (set) Token: 0x060015C5 RID: 5573 RVA: 0x00058119 File Offset: 0x00056319
		private AutoComplete historyMenu { get; set; }

		/// <summary>
		/// True if history menu is visible
		/// </summary>
		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060015C6 RID: 5574 RVA: 0x00058122 File Offset: 0x00056322
		public bool HistoryVisible
		{
			get
			{
				AutoComplete historyMenu = this.historyMenu;
				return historyMenu != null && historyMenu.Visible;
			}
		}

		/// <summary>
		/// if set &gt; 1 we will support history items (which you need to add using AddHistory)
		/// </summary>
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060015C7 RID: 5575 RVA: 0x00058135 File Offset: 0x00056335
		// (set) Token: 0x060015C8 RID: 5576 RVA: 0x0005813D File Offset: 0x0005633D
		public int MaxHistoryItems { get; set; }

		// Token: 0x060015C9 RID: 5577 RVA: 0x00058148 File Offset: 0x00056348
		public void AddHistory(string text)
		{
			if (this.MaxHistoryItems <= 0)
			{
				return;
			}
			this.historyEntries.RemoveAll((string x) => x == text);
			this.historyEntries.Add(text);
			while (this.historyEntries.Count > this.MaxHistoryItems)
			{
				this.historyEntries.RemoveAt(0);
			}
			this.SaveHistoryCookie();
		}

		// Token: 0x060015CA RID: 5578 RVA: 0x000581BC File Offset: 0x000563BC
		private void OpenHistory()
		{
			if (this.historyMenu == null)
			{
				this.historyMenu = new AutoComplete(this);
				this.historyMenu.OnOptionSelected = delegate(string o)
				{
					this.historyMenu.Visible = false;
					this.Text = o;
				};
				this.historyMenu.OnBuildOptions = new Action<Menu, string>(this.BuildHistoryOptions);
			}
			AutoComplete historyMenu = this.historyMenu;
			if (historyMenu == null)
			{
				return;
			}
			historyMenu.OnAutoComplete(null, base.ScreenPosition);
		}

		// Token: 0x060015CB RID: 5579 RVA: 0x00058224 File Offset: 0x00056424
		private void BuildHistoryOptions(Menu menu, string partial)
		{
			foreach (string item in this.historyEntries)
			{
				menu.AddOption(item, null, null, null);
			}
		}

		// Token: 0x04000472 RID: 1138
		private string _historyCookie;

		// Token: 0x04000473 RID: 1139
		internal QLineEdit _lineedit;

		// Token: 0x04000474 RID: 1140
		internal CLineEdit _clineedit;

		// Token: 0x0400047A RID: 1146
		private List<string> historyEntries = new List<string>();
	}
}
