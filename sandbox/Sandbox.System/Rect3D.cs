using System;

/// <summary>
/// Generally used to describe the size of textures
/// </summary>
// Token: 0x02000021 RID: 33
public struct Rect3D
{
	// Token: 0x06000176 RID: 374 RVA: 0x0000821F File Offset: 0x0000641F
	public Rect3D(int x, int y, int z, int width, int height, int depth)
	{
		this.x = x;
		this.y = y;
		this.z = z;
		this.width = width;
		this.height = height;
		this.depth = depth;
	}

	// Token: 0x06000177 RID: 375 RVA: 0x0000824E File Offset: 0x0000644E
	private void Clear()
	{
		this.x = 0;
		this.y = 0;
		this.z = 0;
		this.width = 0;
		this.height = 0;
		this.depth = 0;
	}

	// Token: 0x06000178 RID: 376 RVA: 0x0000827A File Offset: 0x0000647A
	private int Size()
	{
		return this.width * this.height * this.depth;
	}

	// Token: 0x06000179 RID: 377 RVA: 0x00008290 File Offset: 0x00006490
	private bool Intersects(Rect3D other)
	{
		return this.x + this.width > other.x && other.x + other.width > this.x && this.y + this.height > other.y && other.y + other.height > this.y && this.z + this.depth > other.z && other.z + other.depth > this.z;
	}

	// Token: 0x04000058 RID: 88
	public int x;

	// Token: 0x04000059 RID: 89
	public int y;

	// Token: 0x0400005A RID: 90
	public int z;

	// Token: 0x0400005B RID: 91
	public int width;

	// Token: 0x0400005C RID: 92
	public int height;

	// Token: 0x0400005D RID: 93
	public int depth;
}
