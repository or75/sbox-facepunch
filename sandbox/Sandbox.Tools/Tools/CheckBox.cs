using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x0200008C RID: 140
	public class CheckBox : Widget
	{
		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060013BD RID: 5053 RVA: 0x000544DA File Offset: 0x000526DA
		// (set) Token: 0x060013BE RID: 5054 RVA: 0x000544E7 File Offset: 0x000526E7
		public string Text
		{
			get
			{
				return this._checkbox.text();
			}
			set
			{
				this._checkbox.setText(value);
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060013BF RID: 5055 RVA: 0x000544F5 File Offset: 0x000526F5
		// (set) Token: 0x060013C0 RID: 5056 RVA: 0x00054502 File Offset: 0x00052702
		public CheckState State
		{
			get
			{
				return this._checkbox.checkState();
			}
			set
			{
				this._checkbox.setCheckState(value);
			}
		}

		// Token: 0x060013C1 RID: 5057 RVA: 0x00054510 File Offset: 0x00052710
		internal CheckBox(QPushButton ptr)
		{
			this.NativeInit(ptr);
		}

		// Token: 0x060013C2 RID: 5058 RVA: 0x00054524 File Offset: 0x00052724
		public CheckBox(Widget parent = null)
		{
			InteropSystem.Alloc<CheckBox>(this);
			CCheckBox ptr = CCheckBox.CreateCheckBox((parent != null) ? parent._widget : default(QWidget), this);
			this.NativeInit(ptr);
		}

		// Token: 0x060013C3 RID: 5059 RVA: 0x00054564 File Offset: 0x00052764
		public CheckBox(string title, Widget parent = null)
			: this(parent)
		{
			if (title != null)
			{
				this.Text = title;
			}
		}

		// Token: 0x060013C4 RID: 5060 RVA: 0x00054577 File Offset: 0x00052777
		public CheckBox(string title, string icon, Widget parent = null)
			: this(title, parent)
		{
			if (icon != null)
			{
				this.Icon = icon;
			}
		}

		// Token: 0x060013C5 RID: 5061 RVA: 0x0005458B File Offset: 0x0005278B
		internal override void NativeInit(IntPtr ptr)
		{
			this._checkbox = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x060013C6 RID: 5062 RVA: 0x000545A0 File Offset: 0x000527A0
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._checkbox = default(QCheckBox);
		}

		// Token: 0x060013C7 RID: 5063 RVA: 0x000545B4 File Offset: 0x000527B4
		protected virtual void OnClicked()
		{
			Action clicked = this.Clicked;
			if (clicked == null)
			{
				return;
			}
			clicked();
		}

		// Token: 0x060013C8 RID: 5064 RVA: 0x000545C6 File Offset: 0x000527C6
		protected virtual void OnPressed()
		{
			Action pressed = this.Pressed;
			if (pressed == null)
			{
				return;
			}
			pressed();
		}

		// Token: 0x060013C9 RID: 5065 RVA: 0x000545D8 File Offset: 0x000527D8
		protected virtual void OnReleased()
		{
			Action released = this.Released;
			if (released == null)
			{
				return;
			}
			released();
		}

		// Token: 0x060013CA RID: 5066 RVA: 0x000545EA File Offset: 0x000527EA
		protected virtual void OnToggled()
		{
			Action toggled = this.Toggled;
			if (toggled != null)
			{
				toggled();
			}
			this.PushToBinding();
			base.MakeSignal("valuechanged");
		}

		// Token: 0x060013CB RID: 5067 RVA: 0x0005460E File Offset: 0x0005280E
		protected virtual void OnStateChanged(CheckState state)
		{
			Action<CheckState> stateChanged = this.StateChanged;
			if (stateChanged == null)
			{
				return;
			}
			stateChanged(state);
		}

		// Token: 0x170000DF RID: 223
		// (set) Token: 0x060013CC RID: 5068 RVA: 0x00054621 File Offset: 0x00052821
		public string Icon
		{
			set
			{
				this._checkbox.setIcon(value);
			}
		}

		// Token: 0x060013CD RID: 5069 RVA: 0x0005462F File Offset: 0x0005282F
		internal void InternalOnPressed()
		{
			this.OnClicked();
		}

		// Token: 0x060013CE RID: 5070 RVA: 0x00054637 File Offset: 0x00052837
		internal void InternalOnReleased()
		{
			this.OnReleased();
		}

		// Token: 0x060013CF RID: 5071 RVA: 0x0005463F File Offset: 0x0005283F
		internal void InternalOnClicked()
		{
			this.OnClicked();
		}

		// Token: 0x060013D0 RID: 5072 RVA: 0x00054647 File Offset: 0x00052847
		internal void InternalOnToggled()
		{
			this.OnToggled();
		}

		// Token: 0x060013D1 RID: 5073 RVA: 0x0005464F File Offset: 0x0005284F
		internal void InternalOnStateChanged()
		{
			this.OnStateChanged(this.State);
		}

		// Token: 0x060013D2 RID: 5074 RVA: 0x00054660 File Offset: 0x00052860
		protected override void DataValueChanged(object obj)
		{
			if (obj == null)
			{
				return;
			}
			bool val = false;
			string x = obj as string;
			if (x != null)
			{
				val = x.ToBool();
			}
			if (obj is bool)
			{
				bool b = (bool)obj;
				val = b;
			}
			this.State = (val ? CheckState.On : CheckState.Off);
		}

		// Token: 0x060013D3 RID: 5075 RVA: 0x000546A2 File Offset: 0x000528A2
		public override void PushToBinding()
		{
			if (base.DataBinding == null)
			{
				return;
			}
			base.DataBinding.SetValue(this.State == CheckState.On);
		}

		// Token: 0x040001C9 RID: 457
		private QCheckBox _checkbox;

		// Token: 0x040001CA RID: 458
		public Action Clicked;

		// Token: 0x040001CB RID: 459
		public Action Pressed;

		// Token: 0x040001CC RID: 460
		public Action Released;

		// Token: 0x040001CD RID: 461
		public Action Toggled;

		// Token: 0x040001CE RID: 462
		public Action<CheckState> StateChanged;
	}
}
