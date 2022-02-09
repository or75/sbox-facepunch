using System;
using System.Collections.Generic;
using Native;
using Sandbox;
using Sandbox.Internal;

namespace Tools
{
	// Token: 0x0200008D RID: 141
	public class ComboBox : Widget
	{
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060013D4 RID: 5076 RVA: 0x000546C6 File Offset: 0x000528C6
		// (set) Token: 0x060013D5 RID: 5077 RVA: 0x000546CE File Offset: 0x000528CE
		public string StateCookie
		{
			get
			{
				return this._stateCookie;
			}
			set
			{
				if (this._stateCookie == value)
				{
					return;
				}
				this._stateCookie = value;
				this.RestoreFromStateCookie();
			}
		}

		// Token: 0x060013D6 RID: 5078 RVA: 0x000546EC File Offset: 0x000528EC
		public virtual void RestoreFromStateCookie()
		{
			if (string.IsNullOrWhiteSpace(this.StateCookie))
			{
				return;
			}
			string state = GlobalToolsNamespace.Cookie.GetString("ComboBox." + this.StateCookie + ".State", null);
			if (state == null)
			{
				return;
			}
			int index = this._combobox.findText(state);
			if (index < 0)
			{
				return;
			}
			this._combobox.setCurrentIndex(index);
		}

		// Token: 0x060013D7 RID: 5079 RVA: 0x0005474A File Offset: 0x0005294A
		public virtual void SaveToStateCookie()
		{
			if (string.IsNullOrWhiteSpace(this.StateCookie))
			{
				return;
			}
			GlobalToolsNamespace.Cookie.SetString("ComboBox." + this.StateCookie + ".State", this.CurrentText);
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060013D8 RID: 5080 RVA: 0x0005477F File Offset: 0x0005297F
		// (set) Token: 0x060013D9 RID: 5081 RVA: 0x00054787 File Offset: 0x00052987
		public LineEdit LineEdit { get; set; }

		// Token: 0x060013DA RID: 5082 RVA: 0x00054790 File Offset: 0x00052990
		internal ComboBox(QPlainTextEdit widget)
		{
			this.NativeInit(widget);
			this.LineEdit = new LineEdit(this._combobox.lineEdit());
		}

		// Token: 0x060013DB RID: 5083 RVA: 0x000547CC File Offset: 0x000529CC
		public ComboBox(Widget parent = null)
		{
			InteropSystem.Alloc<ComboBox>(this);
			this.NativeInit(CComboBox.Create((parent != null) ? parent._widget : default(QWidget), this));
			this.LineEdit = new LineEdit(this);
			this._combobox.setLineEdit(this.LineEdit._lineedit);
			this.Editable = false;
		}

		// Token: 0x060013DC RID: 5084 RVA: 0x0005483E File Offset: 0x00052A3E
		internal override void NativeInit(IntPtr ptr)
		{
			this._combobox = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x060013DD RID: 5085 RVA: 0x00054853 File Offset: 0x00052A53
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._combobox = default(QComboBox);
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060013DE RID: 5086 RVA: 0x00054867 File Offset: 0x00052A67
		// (set) Token: 0x060013DF RID: 5087 RVA: 0x00054874 File Offset: 0x00052A74
		public string CurrentText
		{
			get
			{
				return this._combobox.currentText();
			}
			set
			{
				this._combobox.setEditText(value);
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060013E0 RID: 5088 RVA: 0x00054882 File Offset: 0x00052A82
		// (set) Token: 0x060013E1 RID: 5089 RVA: 0x0005488F File Offset: 0x00052A8F
		public int CurrentIndex
		{
			get
			{
				return this._combobox.currentIndex();
			}
			set
			{
				this._combobox.setCurrentIndex(value);
			}
		}

		// Token: 0x060013E2 RID: 5090 RVA: 0x000548A0 File Offset: 0x00052AA0
		public int? FindIndex(string text)
		{
			int index = this._combobox.findText(text);
			if (index < 0)
			{
				return null;
			}
			return new int?(index);
		}

		// Token: 0x060013E3 RID: 5091 RVA: 0x000548D0 File Offset: 0x00052AD0
		public bool TrySelectNamed(string name)
		{
			int? i = this.FindIndex(name);
			if (i == null)
			{
				return false;
			}
			this.CurrentIndex = i.Value;
			return true;
		}

		// Token: 0x060013E4 RID: 5092 RVA: 0x000548FE File Offset: 0x00052AFE
		public void ClearText()
		{
			this._combobox.clearEditText();
		}

		// Token: 0x060013E5 RID: 5093 RVA: 0x0005490B File Offset: 0x00052B0B
		public void Clear()
		{
			this._combobox.clear();
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060013E6 RID: 5094 RVA: 0x00054918 File Offset: 0x00052B18
		// (set) Token: 0x060013E7 RID: 5095 RVA: 0x00054925 File Offset: 0x00052B25
		public bool AllowDuplicates
		{
			get
			{
				return this._combobox.duplicatesEnabled();
			}
			set
			{
				this._combobox.setDuplicatesEnabled(value);
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060013E8 RID: 5096 RVA: 0x00054933 File Offset: 0x00052B33
		// (set) Token: 0x060013E9 RID: 5097 RVA: 0x00054940 File Offset: 0x00052B40
		public int MaxVisibleItems
		{
			get
			{
				return this._combobox.maxVisibleItems();
			}
			set
			{
				this._combobox.setMaxVisibleItems(value);
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060013EA RID: 5098 RVA: 0x0005494E File Offset: 0x00052B4E
		// (set) Token: 0x060013EB RID: 5099 RVA: 0x0005495B File Offset: 0x00052B5B
		public bool Editable
		{
			get
			{
				return this._combobox.isEditable();
			}
			set
			{
				this._combobox.setEditable(value);
				this._widget.Polish();
				LineEdit lineEdit = this.LineEdit;
				if (lineEdit == null)
				{
					return;
				}
				lineEdit._widget.Polish();
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060013EC RID: 5100 RVA: 0x00054989 File Offset: 0x00052B89
		// (set) Token: 0x060013ED RID: 5101 RVA: 0x00054996 File Offset: 0x00052B96
		public ComboBox.InsertMode Insertion
		{
			get
			{
				return this._combobox.insertPolicy();
			}
			set
			{
				this._combobox.setInsertPolicy(value);
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060013EE RID: 5102 RVA: 0x000549A4 File Offset: 0x00052BA4
		// (set) Token: 0x060013EF RID: 5103 RVA: 0x000549AC File Offset: 0x00052BAC
		public Action OnReturn { get; internal set; }

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060013F0 RID: 5104 RVA: 0x000549B8 File Offset: 0x00052BB8
		// (remove) Token: 0x060013F1 RID: 5105 RVA: 0x000549F0 File Offset: 0x00052BF0
		public event Action TextChanged;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060013F2 RID: 5106 RVA: 0x00054A28 File Offset: 0x00052C28
		// (remove) Token: 0x060013F3 RID: 5107 RVA: 0x00054A60 File Offset: 0x00052C60
		public event Action ItemChanged;

		// Token: 0x060013F4 RID: 5108 RVA: 0x00054A98 File Offset: 0x00052C98
		protected virtual void OnTextChanged()
		{
			string txt = this.CurrentText;
			AutoComplete autoComplete = this.AutoComplete;
			if (autoComplete != null)
			{
				autoComplete.OnAutoComplete(txt, base.ScreenPosition);
			}
			Action textChanged = this.TextChanged;
			if (textChanged != null)
			{
				textChanged();
			}
			Action action;
			if (this.ItemActions.TryGetValue(txt, out action))
			{
				action();
			}
		}

		// Token: 0x060013F5 RID: 5109 RVA: 0x00054AEB File Offset: 0x00052CEB
		internal void InternalTextChanged()
		{
			this.OnTextChanged();
		}

		// Token: 0x060013F6 RID: 5110 RVA: 0x00054AF3 File Offset: 0x00052CF3
		public void AddItem(string text, string icon = null, Action onSelected = null)
		{
			this._combobox.addItem(icon, text);
			if (onSelected != null)
			{
				this.ItemActions[text] = onSelected;
			}
		}

		// Token: 0x060013F7 RID: 5111 RVA: 0x00054B12 File Offset: 0x00052D12
		internal void InternalIndexChanged()
		{
			this.OnItemChanged();
		}

		// Token: 0x060013F8 RID: 5112 RVA: 0x00054B1C File Offset: 0x00052D1C
		protected virtual void OnItemChanged()
		{
			this.SaveToStateCookie();
			string txt = this.CurrentText;
			Action itemChanged = this.ItemChanged;
			if (itemChanged != null)
			{
				itemChanged();
			}
			Action action;
			if (this.ItemActions.TryGetValue(txt, out action))
			{
				action();
			}
			this.PushToBinding();
			base.MakeSignal("valuechanged");
		}

		// Token: 0x060013F9 RID: 5113 RVA: 0x00054B6E File Offset: 0x00052D6E
		public void SetAutoComplete(Action<Menu, string> func)
		{
			this.AutoComplete = new AutoComplete(this);
			this.AutoComplete.OnOptionSelected = delegate(string o)
			{
				this.CurrentText = o;
			};
			this.AutoComplete.OnBuildOptions = func;
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060013FA RID: 5114 RVA: 0x00054B9F File Offset: 0x00052D9F
		// (set) Token: 0x060013FB RID: 5115 RVA: 0x00054BA7 File Offset: 0x00052DA7
		public AutoComplete AutoComplete { get; set; }

		// Token: 0x060013FC RID: 5116 RVA: 0x00054BB0 File Offset: 0x00052DB0
		protected override void OnBlur(FocusChangeReason reason)
		{
			AutoComplete autoComplete = this.AutoComplete;
			if (autoComplete != null)
			{
				autoComplete.OnParentBlur();
			}
			base.OnBlur(reason);
		}

		// Token: 0x060013FD RID: 5117 RVA: 0x00054BCA File Offset: 0x00052DCA
		protected override void OnKeyPress(KeyEvent e)
		{
			AutoComplete autoComplete = this.AutoComplete;
			if (autoComplete != null)
			{
				autoComplete.OnParentKeyPress(e);
			}
			base.OnKeyPress(e);
		}

		// Token: 0x060013FE RID: 5118 RVA: 0x00054BE5 File Offset: 0x00052DE5
		protected override void DataValueChanged(object obj)
		{
			if (obj == null)
			{
				return;
			}
			this.CurrentText = (string)base.DataBinding.GetValue();
			this.TrySelectNamed(this.CurrentText);
		}

		// Token: 0x060013FF RID: 5119 RVA: 0x00054C0E File Offset: 0x00052E0E
		public override void PushToBinding()
		{
			if (base.DataBinding == null)
			{
				return;
			}
			base.DataBinding.SetValue(this.CurrentText);
		}

		// Token: 0x040001CF RID: 463
		private string _stateCookie;

		// Token: 0x040001D0 RID: 464
		private QComboBox _combobox;

		// Token: 0x040001D5 RID: 469
		private Dictionary<string, Action> ItemActions = new Dictionary<string, Action>();

		// Token: 0x02000145 RID: 325
		public enum InsertMode
		{
			// Token: 0x0400128E RID: 4750
			Skip,
			// Token: 0x0400128F RID: 4751
			AtTop,
			// Token: 0x04001290 RID: 4752
			AtCurrent,
			// Token: 0x04001291 RID: 4753
			AtBottom,
			// Token: 0x04001292 RID: 4754
			AfterCurrent,
			// Token: 0x04001293 RID: 4755
			BeforeCurrent,
			// Token: 0x04001294 RID: 4756
			Alphabetically
		}
	}
}
