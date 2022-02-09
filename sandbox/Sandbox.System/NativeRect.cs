using System;

// Token: 0x0200001F RID: 31
internal struct NativeRect
{
	// Token: 0x06000172 RID: 370 RVA: 0x00008134 File Offset: 0x00006334
	public static implicit operator NativeRect(Rect value)
	{
		return new NativeRect
		{
			x = (int)value.left,
			y = (int)value.top,
			w = (int)value.width,
			h = (int)value.height
		};
	}

	// Token: 0x17000050 RID: 80
	// (get) Token: 0x06000173 RID: 371 RVA: 0x00008184 File Offset: 0x00006384
	public readonly Rect Rect
	{
		get
		{
			return new Rect((float)this.x, (float)this.y, (float)this.w, (float)this.h);
		}
	}

	// Token: 0x04000050 RID: 80
	public int x;

	// Token: 0x04000051 RID: 81
	public int y;

	// Token: 0x04000052 RID: 82
	public int w;

	// Token: 0x04000053 RID: 83
	public int h;
}
