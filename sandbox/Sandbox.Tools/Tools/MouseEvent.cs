using System;

namespace Tools
{
	// Token: 0x020000A5 RID: 165
	public ref struct MouseEvent
	{
		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06001491 RID: 5265 RVA: 0x00056217 File Offset: 0x00054417
		public readonly bool LeftMouseButton
		{
			get
			{
				return this.Button == MouseButtons.Left;
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06001492 RID: 5266 RVA: 0x00056222 File Offset: 0x00054422
		public readonly bool RightMouseButton
		{
			get
			{
				return this.Button == MouseButtons.Right;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06001493 RID: 5267 RVA: 0x0005622D File Offset: 0x0005442D
		public readonly bool MiddleMouseButton
		{
			get
			{
				return this.Button == MouseButtons.Middle;
			}
		}

		/// <summary>
		/// The current mouse button states
		/// </summary>
		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06001494 RID: 5268 RVA: 0x00056238 File Offset: 0x00054438
		public readonly MouseButtons ButtonState
		{
			get
			{
				return this.ptr.buttons();
			}
		}

		/// <summary>
		/// The mouse button we're sending the event for
		/// </summary>
		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06001495 RID: 5269 RVA: 0x00056245 File Offset: 0x00054445
		public readonly MouseButtons Button
		{
			get
			{
				return this.ptr.button();
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06001496 RID: 5270 RVA: 0x00056252 File Offset: 0x00054452
		public readonly Vector2 LocalPosition
		{
			get
			{
				return this.ptr.localPos();
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06001497 RID: 5271 RVA: 0x00056264 File Offset: 0x00054464
		public readonly Vector2 WindowPosition
		{
			get
			{
				return this.ptr.windowPos();
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06001498 RID: 5272 RVA: 0x00056276 File Offset: 0x00054476
		public readonly Vector2 ScreenPosition
		{
			get
			{
				return this.ptr.screenPos();
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06001499 RID: 5273 RVA: 0x00056288 File Offset: 0x00054488
		// (set) Token: 0x0600149A RID: 5274 RVA: 0x00056295 File Offset: 0x00054495
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

		// Token: 0x04000413 RID: 1043
		internal QMouseEvent ptr;
	}
}
