using System;

namespace Tools
{
	// Token: 0x020000A9 RID: 169
	public ref struct WheelEvent
	{
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060014AF RID: 5295 RVA: 0x000563C8 File Offset: 0x000545C8
		public readonly float Delta
		{
			get
			{
				return this.ptr.angleDelta().y;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060014B0 RID: 5296 RVA: 0x000563E8 File Offset: 0x000545E8
		public readonly Vector2 Position
		{
			get
			{
				return this.ptr.position();
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060014B1 RID: 5297 RVA: 0x000563FA File Offset: 0x000545FA
		public readonly Vector2 GlobalPosition
		{
			get
			{
				return this.ptr.globalPosition();
			}
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x0005640C File Offset: 0x0005460C
		public readonly void Accept()
		{
			this.ptr.accept();
		}

		// Token: 0x060014B3 RID: 5299 RVA: 0x00056419 File Offset: 0x00054619
		public readonly void Ignore()
		{
			this.ptr.ignore();
		}

		// Token: 0x04000419 RID: 1049
		internal QWheelEvent ptr;
	}
}
