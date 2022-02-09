using System;

namespace Tools
{
	// Token: 0x020000C8 RID: 200
	public class TitleBar : Widget
	{
		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060016A6 RID: 5798 RVA: 0x00059AFA File Offset: 0x00057CFA
		// (set) Token: 0x060016A7 RID: 5799 RVA: 0x00059B02 File Offset: 0x00057D02
		public Window Window { get; set; }

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x060016A8 RID: 5800 RVA: 0x00059B0B File Offset: 0x00057D0B
		// (set) Token: 0x060016A9 RID: 5801 RVA: 0x00059B13 File Offset: 0x00057D13
		public MenuBar MenuBar { get; set; }

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060016AA RID: 5802 RVA: 0x00059B1C File Offset: 0x00057D1C
		// (set) Token: 0x060016AB RID: 5803 RVA: 0x00059B24 File Offset: 0x00057D24
		public Button IconButton { get; set; }

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060016AC RID: 5804 RVA: 0x00059B2D File Offset: 0x00057D2D
		// (set) Token: 0x060016AD RID: 5805 RVA: 0x00059B35 File Offset: 0x00057D35
		public Button MinimizeButton { get; set; }

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060016AE RID: 5806 RVA: 0x00059B3E File Offset: 0x00057D3E
		// (set) Token: 0x060016AF RID: 5807 RVA: 0x00059B46 File Offset: 0x00057D46
		public Button MaximizeButton { get; set; }

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060016B0 RID: 5808 RVA: 0x00059B4F File Offset: 0x00057D4F
		// (set) Token: 0x060016B1 RID: 5809 RVA: 0x00059B57 File Offset: 0x00057D57
		public Button CloseButton { get; set; }

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060016B2 RID: 5810 RVA: 0x00059B60 File Offset: 0x00057D60
		// (set) Token: 0x060016B3 RID: 5811 RVA: 0x00059B68 File Offset: 0x00057D68
		public Label TitleLabel { get; set; }

		// Token: 0x1700018F RID: 399
		// (set) Token: 0x060016B4 RID: 5812 RVA: 0x00059B71 File Offset: 0x00057D71
		public string Icon
		{
			set
			{
				this.IconButton.Icon = value;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060016B5 RID: 5813 RVA: 0x00059B7F File Offset: 0x00057D7F
		// (set) Token: 0x060016B6 RID: 5814 RVA: 0x00059B8C File Offset: 0x00057D8C
		public string Title
		{
			get
			{
				return this.TitleLabel.Text;
			}
			set
			{
				this.TitleLabel.Text = value;
			}
		}

		// Token: 0x060016B7 RID: 5815 RVA: 0x00059B9C File Offset: 0x00057D9C
		public TitleBar(Window window)
			: base(window)
		{
			base.Name = "TitleBar";
			this.Window = window;
			this.MenuBar = new MenuBar(this);
			window.MenuBar = this.MenuBar;
			WindowDragger dragger = new WindowDragger(this, this.Window);
			this.TitleLabel = dragger.Title;
			this.IconButton = new Button(this);
			this.IconButton.Name = "Icon";
			BoxLayout boxLayout = new BoxLayout(BoxLayout.Direction.LeftToRight, this);
			boxLayout.Add<Button>(this.IconButton, 0);
			boxLayout.Add<MenuBar>(this.MenuBar, 0);
			boxLayout.Add<WindowDragger>(dragger, 1);
			this.MinimizeButton = new Button("", this)
			{
				Icon = "window/minimize.png",
				Name = "Minimize",
				Clicked = delegate()
				{
					window.MakeMinimized();
				}
			};
			boxLayout.Add<Button>(this.MinimizeButton, 0);
			this.MaximizeButton = new Button("", this)
			{
				Icon = "window/restore.png",
				Name = "Restore",
				Clicked = delegate()
				{
					window.TitlebarDoubleClick();
				}
			};
			boxLayout.Add<Button>(this.MaximizeButton, 0);
			this.CloseButton = new Button("", this)
			{
				Icon = "window/close.png",
				Name = "Close",
				Clicked = delegate()
				{
					window.Close();
				}
			};
			boxLayout.Add<Button>(this.CloseButton, 0);
		}

		// Token: 0x060016B8 RID: 5816 RVA: 0x00059D2B File Offset: 0x00057F2B
		internal void SetDialogMode(bool b)
		{
			this.MinimizeButton.Visible = !b;
			this.MaximizeButton.Visible = !b;
			base.SetProperty("is-dialog", b);
		}
	}
}
