using System;
using Sandbox;

namespace Tools
{
	// Token: 0x020000C9 RID: 201
	internal class WindowDragger : Widget
	{
		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060016B9 RID: 5817 RVA: 0x00059D57 File Offset: 0x00057F57
		// (set) Token: 0x060016BA RID: 5818 RVA: 0x00059D5F File Offset: 0x00057F5F
		public Window Window { get; set; }

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060016BB RID: 5819 RVA: 0x00059D68 File Offset: 0x00057F68
		// (set) Token: 0x060016BC RID: 5820 RVA: 0x00059D70 File Offset: 0x00057F70
		public Label Title { get; set; }

		// Token: 0x060016BD RID: 5821 RVA: 0x00059D7C File Offset: 0x00057F7C
		public WindowDragger(Widget parent, Window target)
			: base(parent)
		{
			this.Window = target;
			this.Title = new Label("Window Title", this, null);
			this.Title.Name = "WindowTitle";
			new BoxLayout(BoxLayout.Direction.LeftToRight, this).Add<Label>(this.Title, 1);
		}

		// Token: 0x060016BE RID: 5822 RVA: 0x00059DCD File Offset: 0x00057FCD
		protected override void OnMousePress(MouseEvent e)
		{
			base.OnMousePress(e);
			if (e.LeftMouseButton)
			{
				this.dragMode = 0;
				this.grab_position = e.ScreenPosition - this.Window.Position;
				e.Accepted = true;
			}
		}

		// Token: 0x060016BF RID: 5823 RVA: 0x00059E0C File Offset: 0x0005800C
		protected override void OnMouseMove(MouseEvent e)
		{
			base.OnMousePress(e);
			if (e.ButtonState.HasFlag(MouseButtons.Left) && this.dragMode == 0 && this.timeSinceMaximized > 0.5f)
			{
				Vector2 newPos = e.ScreenPosition - this.Window.Position;
				if (this.grab_position.Distance(newPos) > 6f)
				{
					this.dragMode = 1;
					this.Window.TitlebarPress();
				}
			}
		}

		// Token: 0x060016C0 RID: 5824 RVA: 0x00059E90 File Offset: 0x00058090
		protected override void OnDoubleClick(MouseEvent e)
		{
			this.Window.TitlebarDoubleClick();
			this.timeSinceMaximized = 0f;
		}

		// Token: 0x040004A8 RID: 1192
		private Vector2 grab_position;

		// Token: 0x040004A9 RID: 1193
		private int dragMode;

		// Token: 0x040004AA RID: 1194
		private RealTimeSince timeSinceMaximized;
	}
}
