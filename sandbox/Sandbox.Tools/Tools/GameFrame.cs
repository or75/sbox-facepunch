using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace Tools
{
	// Token: 0x0200007D RID: 125
	public class GameFrame : Frame
	{
		// Token: 0x060012FB RID: 4859 RVA: 0x000523D8 File Offset: 0x000505D8
		internal GameFrame(Widget parent)
			: base(parent)
		{
			GameFrame.Singleton = this;
			base.SetSizeMode(SizeMode.CanGrow, SizeMode.CanGrow);
			this.EngineCanvas = new Frame(this);
			this.EngineCanvas.SetStyles("QFrame { background-color: #111; }");
			this.EngineView = new EngineView(this.EngineCanvas);
			base.MinimumSize = new Vector2(512f, 512f);
			this.EngineOverlay = new EngineOverlay(this.EngineCanvas);
			BoxLayout boxLayout = base.MakeTopToBottom();
			boxLayout.Add<Frame>(this.EngineCanvas, 1);
			StatusBar statusBar = new StatusBar(this);
			boxLayout.Add<StatusBar>(statusBar, 0);
			this.FullScreen = new Button("", "crop_free", this);
			this.FullScreen.Name = "ToggleFullscreen";
			this.FullScreen.IsToggle = true;
			statusBar.AddWidgetLeft(this.FullScreen, 0);
			ComboBox combo = new ComboBox(this);
			combo.AddItem("Free Size", "fit_screen", delegate
			{
				this.SetFreeSize();
			});
			combo.AddItem("16:9 Aspect", "aspect_ratio", delegate
			{
				this.SetForceAspect(1.7777778f);
			});
			combo.AddItem("4:3 Aspect", "aspect_ratio", delegate
			{
				this.SetForceAspect(1.3333334f);
			});
			combo.AddItem("1280x720", "desktop_windows", delegate
			{
				this.SetForceResolution(new Vector2(1280f, 720f));
			});
			combo.AddItem("1920x1080", "desktop_windows", delegate
			{
				this.SetForceResolution(new Vector2(1920f, 1080f));
			});
			statusBar.AddWidgetLeft(combo, 0);
			combo.StateCookie = "EditorDisplayMode";
			statusBar.AddWidgetLeft(new EnumBox(this, typeof(EngineViewRenderMode))
			{
				DataBinding = new ConVarBind("mat_fullbright")
			}, 0);
			this.FrameRate = new Label("60fps", this, null);
			this.Resolution = new Label("100x100", this, null);
			this.Milliseconds = new Label("2.34ms", this, null);
			statusBar.AddWidgetRight(this.Resolution, 0);
			statusBar.AddWidgetRight(this.FrameRate, 0);
			statusBar.AddWidgetRight(this.Milliseconds, 0);
			this.FrameRate.MinimumSize = new Vector2(60f, 10f);
			this.Milliseconds.MinimumSize = new Vector2(60f, 10f);
		}

		// Token: 0x060012FC RID: 4860 RVA: 0x0005262F File Offset: 0x0005082F
		[Event("command editor.fulltoggle")]
		internal void ToggleFullScreen()
		{
			this.FullScreen.IsChecked = !this.FullScreen.IsChecked;
		}

		// Token: 0x060012FD RID: 4861 RVA: 0x0005264A File Offset: 0x0005084A
		[Event("command editor.fulloff")]
		internal void ToggleFullOff()
		{
			this.FullScreen.IsChecked = false;
		}

		// Token: 0x060012FE RID: 4862 RVA: 0x00052658 File Offset: 0x00050858
		[Event("command editor.fullon")]
		internal void ToggleFullOn()
		{
			this.FullScreen.IsChecked = true;
		}

		// Token: 0x060012FF RID: 4863 RVA: 0x00052666 File Offset: 0x00050866
		internal void ResizeNextFrame()
		{
			this.timeSinceResize = 100f;
		}

		// Token: 0x06001300 RID: 4864 RVA: 0x00052678 File Offset: 0x00050878
		[Event.FrameAttribute]
		public void OnGameFrame()
		{
			if (this.timeSinceResize > 0.2f)
			{
				this.timeSinceResize = 0f;
				this.SizeEngineWindow(true);
			}
			else
			{
				this.SizeEngineWindow(false);
			}
			if (this.timeSinceUpdateStats < 0.05f)
			{
				return;
			}
			this.timeSinceUpdateStats = 0f;
			float ms = PerformanceStats.LastSecond.FrameAvg;
			float fps = 1000f / ms;
			Vector2 size = this.EngineView.Size * this.EngineView.DpiScale;
			Label resolution = this.Resolution;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<float>(size.x, "0");
			defaultInterpolatedStringHandler.AppendLiteral("x");
			defaultInterpolatedStringHandler.AppendFormatted<float>(size.y, "0");
			resolution.Text = defaultInterpolatedStringHandler.ToStringAndClear();
			Label frameRate = this.FrameRate;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
			defaultInterpolatedStringHandler.AppendFormatted<float>(fps, "0.");
			defaultInterpolatedStringHandler.AppendLiteral("fps");
			frameRate.Text = defaultInterpolatedStringHandler.ToStringAndClear();
			Label milliseconds = this.Milliseconds;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
			defaultInterpolatedStringHandler.AppendFormatted<float>(ms, "0.00");
			defaultInterpolatedStringHandler.AppendLiteral("ms");
			milliseconds.Text = defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06001301 RID: 4865 RVA: 0x000527BE File Offset: 0x000509BE
		protected override void DoLayout()
		{
			this.OnGameFrame();
			base.DoLayout();
		}

		// Token: 0x06001302 RID: 4866 RVA: 0x000527CC File Offset: 0x000509CC
		private void SetForceAspect(float aspect)
		{
			this.SetFreeSize();
			this.forceAspect = new float?(aspect);
		}

		// Token: 0x06001303 RID: 4867 RVA: 0x000527E0 File Offset: 0x000509E0
		private void SetFreeSize()
		{
			this.forceAspect = null;
			this.forceResolution = null;
			this.timeSinceResize = 100f;
		}

		// Token: 0x06001304 RID: 4868 RVA: 0x0005280A File Offset: 0x00050A0A
		private void SetForceResolution(Vector2 res)
		{
			this.SetFreeSize();
			this.forceResolution = new Vector2?(res);
		}

		// Token: 0x06001305 RID: 4869 RVA: 0x00052820 File Offset: 0x00050A20
		internal void SizeEngineWindow(bool resize = true)
		{
			Vector2 canvasSize = this.EngineCanvas.Size;
			Vector2 size = canvasSize;
			if (this.forceAspect != null)
			{
				size = new Vector2(canvasSize.y * this.forceAspect.Value, canvasSize.y);
				if (size.x > canvasSize.x)
				{
					size = new Vector2(canvasSize.x, canvasSize.x * (1f / this.forceAspect.Value));
				}
			}
			if (this.forceResolution != null)
			{
				size = this.forceResolution.Value;
			}
			if (resize)
			{
				this.EngineView.Size = size;
			}
			this.EngineView.Position = (canvasSize - size) * 0.5f;
			this.EngineOverlay.Position = this.EngineView.ScreenPosition;
			this.EngineOverlay.Size = size;
			this.EngineOverlay.Visible = true;
		}

		// Token: 0x04000191 RID: 401
		internal static GameFrame Singleton;

		// Token: 0x04000192 RID: 402
		internal Frame EngineCanvas;

		// Token: 0x04000193 RID: 403
		internal EngineView EngineView;

		// Token: 0x04000194 RID: 404
		internal EngineOverlay EngineOverlay;

		// Token: 0x04000195 RID: 405
		private Label FrameRate;

		// Token: 0x04000196 RID: 406
		private Label Milliseconds;

		// Token: 0x04000197 RID: 407
		private Label Resolution;

		// Token: 0x04000198 RID: 408
		internal Button FullScreen;

		// Token: 0x04000199 RID: 409
		private RealTimeSince timeSinceResize = 1f;

		// Token: 0x0400019A RID: 410
		private RealTimeSince timeSinceUpdateStats = 1f;

		// Token: 0x0400019B RID: 411
		private float? forceAspect;

		// Token: 0x0400019C RID: 412
		private Vector2? forceResolution;
	}
}
