using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000C1 RID: 193
	public class Option : QObject
	{
		// Token: 0x17000166 RID: 358
		// (get) Token: 0x0600162C RID: 5676 RVA: 0x00058F91 File Offset: 0x00057191
		// (set) Token: 0x0600162D RID: 5677 RVA: 0x00058F9E File Offset: 0x0005719E
		public string Text
		{
			get
			{
				return this._action.text();
			}
			set
			{
				this._action.setText(value);
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x0600162E RID: 5678 RVA: 0x00058FAC File Offset: 0x000571AC
		// (set) Token: 0x0600162F RID: 5679 RVA: 0x00058FB9 File Offset: 0x000571B9
		public bool Checkable
		{
			get
			{
				return this._action.isCheckable();
			}
			set
			{
				this._action.setCheckable(value);
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06001630 RID: 5680 RVA: 0x00058FC7 File Offset: 0x000571C7
		// (set) Token: 0x06001631 RID: 5681 RVA: 0x00058FD4 File Offset: 0x000571D4
		public bool Checked
		{
			get
			{
				return this._action.isChecked();
			}
			set
			{
				this._action.setChecked(value);
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06001632 RID: 5682 RVA: 0x00058FE2 File Offset: 0x000571E2
		// (set) Token: 0x06001633 RID: 5683 RVA: 0x00058FEF File Offset: 0x000571EF
		public string Tooltip
		{
			get
			{
				return this._action.toolTip();
			}
			set
			{
				this._action.setToolTip(value);
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06001634 RID: 5684 RVA: 0x00058FFD File Offset: 0x000571FD
		// (set) Token: 0x06001635 RID: 5685 RVA: 0x0005900A File Offset: 0x0005720A
		public string StatusText
		{
			get
			{
				return this._action.statusTip();
			}
			set
			{
				this._action.setStatusTip(value);
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06001636 RID: 5686 RVA: 0x00059018 File Offset: 0x00057218
		// (set) Token: 0x06001637 RID: 5687 RVA: 0x00059025 File Offset: 0x00057225
		public bool Enabled
		{
			get
			{
				return this._action.isEnabled();
			}
			set
			{
				this._action.setEnabled(value);
			}
		}

		/// <summary>
		/// "Ctrl+S", "Shift+Ctrl+Z", "Ctrl+Shift+G"
		/// </summary>
		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06001638 RID: 5688 RVA: 0x00059033 File Offset: 0x00057233
		// (set) Token: 0x06001639 RID: 5689 RVA: 0x0005903B File Offset: 0x0005723B
		public string Shortcut
		{
			get
			{
				return this._shortcut;
			}
			set
			{
				this._shortcut = value;
				this._action.setShortcut(this._shortcut);
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x0600163A RID: 5690 RVA: 0x00059055 File Offset: 0x00057255
		// (set) Token: 0x0600163B RID: 5691 RVA: 0x0005905D File Offset: 0x0005725D
		public string Icon
		{
			get
			{
				return this._icon;
			}
			set
			{
				if (this._icon == value)
				{
					return;
				}
				this._icon = value;
				this._action.setIcon(this._icon);
			}
		}

		// Token: 0x0600163C RID: 5692 RVA: 0x00059086 File Offset: 0x00057286
		internal Option(IntPtr ptr)
		{
			this.NativeInit(ptr);
		}

		// Token: 0x0600163D RID: 5693 RVA: 0x00059098 File Offset: 0x00057298
		public Option(QObject parent, string title = null, string icon = null, Action action = null)
		{
			InteropSystem.Alloc<Option>(this);
			this.NativeInit(CAction.Create((parent != null) ? parent._object : default(QObject), this));
			if (title != null)
			{
				this.Text = title;
			}
			if (icon != null)
			{
				this.Icon = icon;
			}
			if (action != null)
			{
				this.Triggered = action;
			}
		}

		// Token: 0x0600163E RID: 5694 RVA: 0x000590F6 File Offset: 0x000572F6
		public Option(string title = null, string icon = null, Action action = null)
			: this(null, title, icon, action)
		{
		}

		// Token: 0x0600163F RID: 5695 RVA: 0x00059102 File Offset: 0x00057302
		internal override void NativeInit(IntPtr ptr)
		{
			this._action = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x06001640 RID: 5696 RVA: 0x00059117 File Offset: 0x00057317
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._action = default(QAction);
		}

		// Token: 0x06001641 RID: 5697 RVA: 0x0005912B File Offset: 0x0005732B
		protected virtual void OnTriggered()
		{
			Action triggered = this.Triggered;
			if (triggered == null)
			{
				return;
			}
			triggered();
		}

		// Token: 0x06001642 RID: 5698 RVA: 0x0005913D File Offset: 0x0005733D
		internal void InternalTriggered()
		{
			this.OnTriggered();
		}

		// Token: 0x06001643 RID: 5699 RVA: 0x00059145 File Offset: 0x00057345
		protected virtual void OnToggled(bool b)
		{
			Action<bool> toggled = this.Toggled;
			if (toggled == null)
			{
				return;
			}
			toggled(b);
		}

		// Token: 0x06001644 RID: 5700 RVA: 0x00059158 File Offset: 0x00057358
		internal void InternalToggled(bool b)
		{
			this.OnToggled(b);
		}

		// Token: 0x0400048C RID: 1164
		internal QAction _action;

		// Token: 0x0400048D RID: 1165
		public Action Triggered;

		// Token: 0x0400048E RID: 1166
		public Action<bool> Toggled;

		// Token: 0x0400048F RID: 1167
		private string _shortcut;

		// Token: 0x04000490 RID: 1168
		private string _icon;
	}
}
