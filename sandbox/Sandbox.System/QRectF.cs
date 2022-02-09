using System;

/// <summary>
/// You're not seeing things, QT uses fucking doubles
/// </summary>
// Token: 0x02000020 RID: 32
internal struct QRectF
{
	// Token: 0x06000174 RID: 372 RVA: 0x000081A8 File Offset: 0x000063A8
	public static implicit operator QRectF(Rect value)
	{
		return new QRectF
		{
			x = (double)((int)value.left),
			y = (double)((int)value.top),
			w = (double)((int)value.width),
			h = (double)((int)value.height)
		};
	}

	// Token: 0x17000051 RID: 81
	// (get) Token: 0x06000175 RID: 373 RVA: 0x000081FC File Offset: 0x000063FC
	public readonly Rect Rect
	{
		get
		{
			return new Rect((float)this.x, (float)this.y, (float)this.w, (float)this.h);
		}
	}

	// Token: 0x04000054 RID: 84
	public double x;

	// Token: 0x04000055 RID: 85
	public double y;

	// Token: 0x04000056 RID: 86
	public double w;

	// Token: 0x04000057 RID: 87
	public double h;
}
