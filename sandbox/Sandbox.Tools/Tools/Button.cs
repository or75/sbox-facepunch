using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x0200008A RID: 138
	public class Button : Widget
	{
		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060013A8 RID: 5032 RVA: 0x0005436D File Offset: 0x0005256D
		// (set) Token: 0x060013A9 RID: 5033 RVA: 0x0005437A File Offset: 0x0005257A
		public string Text
		{
			get
			{
				return this._button.text();
			}
			set
			{
				this._button.setText(value);
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060013AA RID: 5034 RVA: 0x00054388 File Offset: 0x00052588
		// (set) Token: 0x060013AB RID: 5035 RVA: 0x00054395 File Offset: 0x00052595
		public bool IsChecked
		{
			get
			{
				return this._button.isChecked();
			}
			set
			{
				this._button.setChecked(value);
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060013AC RID: 5036 RVA: 0x000543A3 File Offset: 0x000525A3
		// (set) Token: 0x060013AD RID: 5037 RVA: 0x000543B0 File Offset: 0x000525B0
		public bool IsToggle
		{
			get
			{
				return this._button.isCheckable();
			}
			set
			{
				this._button.setCheckable(value);
			}
		}

		// Token: 0x060013AE RID: 5038 RVA: 0x000543BE File Offset: 0x000525BE
		internal Button(QPushButton ptr)
		{
			this.NativeInit(ptr);
		}

		// Token: 0x060013AF RID: 5039 RVA: 0x000543D4 File Offset: 0x000525D4
		public Button(Widget parent = null)
		{
			InteropSystem.Alloc<Button>(this);
			CPushButton ptr = CPushButton.CreatePushButton((parent != null) ? parent._widget : default(QWidget), this);
			this.NativeInit(ptr);
		}

		// Token: 0x060013B0 RID: 5040 RVA: 0x00054414 File Offset: 0x00052614
		public Button(string title, Widget parent = null)
			: this(parent)
		{
			if (title != null)
			{
				this.Text = title;
			}
		}

		// Token: 0x060013B1 RID: 5041 RVA: 0x00054427 File Offset: 0x00052627
		public Button(string title, string icon, Widget parent = null)
			: this(title, parent)
		{
			if (icon != null)
			{
				this.Icon = icon;
			}
		}

		// Token: 0x060013B2 RID: 5042 RVA: 0x0005443B File Offset: 0x0005263B
		internal override void NativeInit(IntPtr ptr)
		{
			this._button = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x060013B3 RID: 5043 RVA: 0x00054450 File Offset: 0x00052650
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._button = default(QPushButton);
		}

		// Token: 0x060013B4 RID: 5044 RVA: 0x00054464 File Offset: 0x00052664
		protected virtual void OnClicked()
		{
			Action clicked = this.Clicked;
			if (clicked == null)
			{
				return;
			}
			clicked();
		}

		// Token: 0x060013B5 RID: 5045 RVA: 0x00054476 File Offset: 0x00052676
		protected virtual void OnPressed()
		{
			Action pressed = this.Pressed;
			if (pressed == null)
			{
				return;
			}
			pressed();
		}

		// Token: 0x060013B6 RID: 5046 RVA: 0x00054488 File Offset: 0x00052688
		protected virtual void OnReleased()
		{
			Action released = this.Released;
			if (released == null)
			{
				return;
			}
			released();
		}

		// Token: 0x060013B7 RID: 5047 RVA: 0x0005449A File Offset: 0x0005269A
		protected virtual void OnToggled()
		{
			Action toggled = this.Toggled;
			if (toggled == null)
			{
				return;
			}
			toggled();
		}

		// Token: 0x170000DC RID: 220
		// (set) Token: 0x060013B8 RID: 5048 RVA: 0x000544AC File Offset: 0x000526AC
		public string Icon
		{
			set
			{
				this._button.setIcon(value);
			}
		}

		// Token: 0x060013B9 RID: 5049 RVA: 0x000544BA File Offset: 0x000526BA
		internal void InternalOnPressed()
		{
			this.OnPressed();
		}

		// Token: 0x060013BA RID: 5050 RVA: 0x000544C2 File Offset: 0x000526C2
		internal void InternalOnReleased()
		{
			this.OnReleased();
		}

		// Token: 0x060013BB RID: 5051 RVA: 0x000544CA File Offset: 0x000526CA
		internal void InternalOnClicked()
		{
			this.OnClicked();
		}

		// Token: 0x060013BC RID: 5052 RVA: 0x000544D2 File Offset: 0x000526D2
		internal void InternalOnToggled()
		{
			this.OnToggled();
		}

		// Token: 0x040001C0 RID: 448
		internal QPushButton _button;

		// Token: 0x040001C1 RID: 449
		public Action Clicked;

		// Token: 0x040001C2 RID: 450
		public Action Pressed;

		// Token: 0x040001C3 RID: 451
		public Action Released;

		// Token: 0x040001C4 RID: 452
		public Action Toggled;
	}
}
