using System;
using Native;

namespace Tools
{
	// Token: 0x020000B9 RID: 185
	public class Label : Widget
	{
		// Token: 0x17000142 RID: 322
		// (get) Token: 0x0600156A RID: 5482 RVA: 0x000576FF File Offset: 0x000558FF
		// (set) Token: 0x0600156B RID: 5483 RVA: 0x0005770C File Offset: 0x0005590C
		public string Text
		{
			get
			{
				return this._label.text();
			}
			set
			{
				this._label.setText(value);
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x0600156C RID: 5484 RVA: 0x0005771A File Offset: 0x0005591A
		// (set) Token: 0x0600156D RID: 5485 RVA: 0x00057727 File Offset: 0x00055927
		public bool WordWrap
		{
			get
			{
				return this._label.wordWrap();
			}
			set
			{
				this._label.setWordWrap(value);
			}
		}

		// Token: 0x0600156E RID: 5486 RVA: 0x00057738 File Offset: 0x00055938
		public Label(Widget parent = null)
		{
			QLabel ptr = QLabel.Create((parent != null) ? parent._widget : default(QWidget));
			this.NativeInit(ptr);
		}

		// Token: 0x0600156F RID: 5487 RVA: 0x00057774 File Offset: 0x00055974
		public Label(string title, Widget parent = null, string name = null)
		{
			QLabel ptr = QLabel.Create(title, (parent != null) ? parent._widget : default(QWidget));
			this.NativeInit(ptr);
			if (name != null)
			{
				base.Name = name;
			}
		}

		// Token: 0x06001570 RID: 5488 RVA: 0x000577B8 File Offset: 0x000559B8
		internal override void NativeInit(IntPtr ptr)
		{
			this._label = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x06001571 RID: 5489 RVA: 0x000577CD File Offset: 0x000559CD
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._label = default(QLabel);
		}

		// Token: 0x06001572 RID: 5490 RVA: 0x000577E1 File Offset: 0x000559E1
		public override void PullFromBinding()
		{
			DataBind dataBinding = base.DataBinding;
			string text;
			if (dataBinding == null)
			{
				text = null;
			}
			else
			{
				object value = dataBinding.GetValue();
				text = ((value != null) ? value.ToString() : null);
			}
			this.Text = text ?? "null";
		}

		// Token: 0x0400046F RID: 1135
		internal QLabel _label;
	}
}
