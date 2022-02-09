using System;

namespace Tools
{
	// Token: 0x020000A8 RID: 168
	public ref struct GraphicsMouseEvent
	{
		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060014A6 RID: 5286 RVA: 0x00056342 File Offset: 0x00054542
		public readonly bool LeftMouseButton
		{
			get
			{
				return (this.Buttons & MouseButtons.Left) > MouseButtons.None;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060014A7 RID: 5287 RVA: 0x0005634F File Offset: 0x0005454F
		public readonly bool RightMouseButton
		{
			get
			{
				return (this.Buttons & MouseButtons.Right) > MouseButtons.None;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060014A8 RID: 5288 RVA: 0x0005635C File Offset: 0x0005455C
		public readonly bool MiddleMouseButton
		{
			get
			{
				return (this.Buttons & MouseButtons.Middle) > MouseButtons.None;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060014A9 RID: 5289 RVA: 0x00056369 File Offset: 0x00054569
		public readonly MouseButtons Buttons
		{
			get
			{
				return this.ptr.buttons();
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060014AA RID: 5290 RVA: 0x00056376 File Offset: 0x00054576
		public readonly Vector2 LocalPosition
		{
			get
			{
				return this.ptr.pos();
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060014AB RID: 5291 RVA: 0x00056388 File Offset: 0x00054588
		public readonly Vector2 ScenePosition
		{
			get
			{
				return this.ptr.scenePos();
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060014AC RID: 5292 RVA: 0x0005639A File Offset: 0x0005459A
		public readonly Vector2 ScreenPosition
		{
			get
			{
				return this.ptr.screenPos();
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060014AD RID: 5293 RVA: 0x000563AC File Offset: 0x000545AC
		// (set) Token: 0x060014AE RID: 5294 RVA: 0x000563B9 File Offset: 0x000545B9
		public readonly bool Accepted
		{
			get
			{
				return this.ptr.isAccepted();
			}
			set
			{
				this.ptr.setAccepted(value);
			}
		}

		// Token: 0x04000418 RID: 1048
		internal QGraphicsSceneMouseEvent ptr;
	}
}
