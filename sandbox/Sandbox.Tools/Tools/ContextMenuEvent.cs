using System;

namespace Tools
{
	// Token: 0x020000A7 RID: 167
	public ref struct ContextMenuEvent
	{
		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060014A2 RID: 5282 RVA: 0x00056303 File Offset: 0x00054503
		public readonly Vector2 LocalPosition
		{
			get
			{
				return this.ptr.pos();
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060014A3 RID: 5283 RVA: 0x00056315 File Offset: 0x00054515
		public readonly Vector2 ScreenPosition
		{
			get
			{
				return this.ptr.globalPos();
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060014A4 RID: 5284 RVA: 0x00056327 File Offset: 0x00054527
		// (set) Token: 0x060014A5 RID: 5285 RVA: 0x00056334 File Offset: 0x00054534
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

		// Token: 0x04000417 RID: 1047
		internal QContextMenuEvent ptr;
	}
}
