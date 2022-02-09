using System;
using Sandbox;

namespace Tools
{
	// Token: 0x0200007B RID: 123
	public class EngineOverlay : Widget
	{
		// Token: 0x060012F6 RID: 4854 RVA: 0x00052341 File Offset: 0x00050541
		internal EngineOverlay(Widget parent)
			: base(parent)
		{
			base.TranslucentBackground = true;
			base.NoSystemBackground = true;
			base.IsFramelessWindow = true;
			EngineOverlay.Singleton = this;
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x00052375 File Offset: 0x00050575
		protected override void OnPaint()
		{
			Event.Run("paintoverlay");
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x00052381 File Offset: 0x00050581
		[Event.FrameAttribute]
		public void Frame()
		{
			if (this.timeSinceNeededRedraw < 0.25f)
			{
				this.Update();
			}
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x0005239B File Offset: 0x0005059B
		public static void Redraw()
		{
			if (EngineOverlay.Singleton == null)
			{
				return;
			}
			EngineOverlay.Singleton.timeSinceNeededRedraw = 0f;
		}

		// Token: 0x0400018F RID: 399
		private static EngineOverlay Singleton;

		// Token: 0x04000190 RID: 400
		internal RealTimeSince timeSinceNeededRedraw = 0f;
	}
}
