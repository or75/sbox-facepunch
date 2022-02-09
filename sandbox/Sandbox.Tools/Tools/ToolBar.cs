using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000CA RID: 202
	public class ToolBar : Widget
	{
		// Token: 0x060016C1 RID: 5825 RVA: 0x00059EAD File Offset: 0x000580AD
		internal ToolBar(QToolBar widget)
		{
			this.NativeInit(widget);
		}

		// Token: 0x060016C2 RID: 5826 RVA: 0x00059EC4 File Offset: 0x000580C4
		public ToolBar(Widget parent, string name = null)
		{
			InteropSystem.Alloc<ToolBar>(this);
			this.NativeInit(CToolBar.Create((parent != null) ? parent._widget : default(QWidget), this));
			if (name != null)
			{
				base.Name = name;
			}
		}

		// Token: 0x060016C3 RID: 5827 RVA: 0x00059F0C File Offset: 0x0005810C
		internal override void NativeInit(IntPtr ptr)
		{
			this._toolbar = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x060016C4 RID: 5828 RVA: 0x00059F21 File Offset: 0x00058121
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._toolbar = default(QToolBar);
		}

		// Token: 0x060016C5 RID: 5829 RVA: 0x00059F35 File Offset: 0x00058135
		public Option AddOption(string text, string icon = null, Action action = null)
		{
			return this.AddOption(new Option(this, text, icon, action));
		}

		// Token: 0x060016C6 RID: 5830 RVA: 0x00059F48 File Offset: 0x00058148
		public Option AddOption(Option option)
		{
			this._toolbar.insertAction(default(QAction), option._action);
			return option;
		}

		// Token: 0x060016C7 RID: 5831 RVA: 0x00059F70 File Offset: 0x00058170
		public void Clear()
		{
			this._toolbar.clear();
		}

		// Token: 0x060016C8 RID: 5832 RVA: 0x00059F7D File Offset: 0x0005817D
		public Option AddSeparator()
		{
			return new Option(this._toolbar.addSeparator());
		}

		// Token: 0x060016C9 RID: 5833 RVA: 0x00059F94 File Offset: 0x00058194
		public Widget AddWidget(Widget widget)
		{
			this._toolbar.addWidget(widget._widget);
			return widget;
		}

		// Token: 0x060016CA RID: 5834 RVA: 0x00059FA9 File Offset: 0x000581A9
		public void SetIconSize(Vector2 size)
		{
			this._toolbar.setIconSize(size);
		}

		// Token: 0x040004AB RID: 1195
		internal QToolBar _toolbar;
	}
}
