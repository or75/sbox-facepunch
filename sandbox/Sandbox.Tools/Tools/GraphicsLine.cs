using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000B2 RID: 178
	public class GraphicsLine : GraphicsItem
	{
		// Token: 0x06001527 RID: 5415 RVA: 0x00057008 File Offset: 0x00055208
		public GraphicsLine(GraphicsItem parent = null)
			: base(null)
		{
			InteropSystem.Alloc<GraphicsLine>(this);
			this.NativeInit(CManagedLineGraphicsItem.CreateLine(parent.IsValid() ? parent._graphicsitem : IntPtr.Zero, this));
			base.Parent = parent;
		}

		// Token: 0x06001528 RID: 5416 RVA: 0x00057054 File Offset: 0x00055254
		internal override void NativeInit(QGraphicsItem ptr)
		{
			this._line = (CManagedLineGraphicsItem)ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x06001529 RID: 5417 RVA: 0x00057069 File Offset: 0x00055269
		internal override void NativeShutdown()
		{
			this._line = default(CManagedLineGraphicsItem);
			base.NativeShutdown();
		}

		// Token: 0x0600152A RID: 5418 RVA: 0x0005707D File Offset: 0x0005527D
		public void Clear()
		{
			this._line.Clear();
		}

		// Token: 0x0600152B RID: 5419 RVA: 0x0005708A File Offset: 0x0005528A
		public void MoveTo(Vector2 point)
		{
			this._line.MoveTo(point);
		}

		// Token: 0x0600152C RID: 5420 RVA: 0x0005709D File Offset: 0x0005529D
		public void LineTo(Vector2 point)
		{
			this._line.LineTo(point);
		}

		// Token: 0x0600152D RID: 5421 RVA: 0x000570B0 File Offset: 0x000552B0
		public void CubicLineTo(Vector2 c1, Vector2 c2, Vector2 point)
		{
			this._line.CubicTo(c1, c2, point);
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600152E RID: 5422 RVA: 0x000570CF File Offset: 0x000552CF
		// (set) Token: 0x0600152F RID: 5423 RVA: 0x000570DC File Offset: 0x000552DC
		public float HitWidth
		{
			get
			{
				return this._line.HitWidth;
			}
			set
			{
				this._line.HitWidth = value;
			}
		}

		// Token: 0x06001530 RID: 5424 RVA: 0x000570EA File Offset: 0x000552EA
		protected override void OnPaint()
		{
			Paint.SetPen(Color.Red, 5f);
			this.PaintLine();
		}

		// Token: 0x06001531 RID: 5425 RVA: 0x00057101 File Offset: 0x00055301
		protected void PaintLine()
		{
			this._line.paint(Paint.ptr);
		}

		// Token: 0x04000435 RID: 1077
		private CManagedLineGraphicsItem _line;
	}
}
