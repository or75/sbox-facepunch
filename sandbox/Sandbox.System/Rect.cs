using System;
using System.Text.Json.Serialization;
using Sandbox.UI;

// Token: 0x0200001E RID: 30
public struct Rect : IEquatable<Rect>
{
	// Token: 0x06000145 RID: 325 RVA: 0x00007780 File Offset: 0x00005980
	public Rect(float x, float y, float width, float height)
	{
		this.left = x;
		this.top = y;
		this.right = x + width;
		this.bottom = y + height;
	}

	// Token: 0x06000146 RID: 326 RVA: 0x000077A4 File Offset: 0x000059A4
	public Rect(Vector2 point, Vector2 size = default(Vector2))
	{
		this.left = point.x;
		this.top = point.y;
		this.right = point.x + size.x;
		this.bottom = point.y + size.y;
	}

	// Token: 0x17000045 RID: 69
	// (get) Token: 0x06000147 RID: 327 RVA: 0x000077F5 File Offset: 0x000059F5
	// (set) Token: 0x06000148 RID: 328 RVA: 0x00007804 File Offset: 0x00005A04
	public float width
	{
		get
		{
			return this.right - this.left;
		}
		set
		{
			this.right = this.left + value;
		}
	}

	// Token: 0x17000046 RID: 70
	// (get) Token: 0x06000149 RID: 329 RVA: 0x00007814 File Offset: 0x00005A14
	// (set) Token: 0x0600014A RID: 330 RVA: 0x00007823 File Offset: 0x00005A23
	public float height
	{
		get
		{
			return this.bottom - this.top;
		}
		set
		{
			this.bottom = this.top + value;
		}
	}

	// Token: 0x17000047 RID: 71
	// (get) Token: 0x0600014B RID: 331 RVA: 0x00007833 File Offset: 0x00005A33
	// (set) Token: 0x0600014C RID: 332 RVA: 0x00007848 File Offset: 0x00005A48
	public Vector2 Position
	{
		get
		{
			return new Vector2(this.left, this.top);
		}
		set
		{
			Vector2 s = this.Size;
			this.left = value.x;
			this.top = value.y;
			this.Size = s;
		}
	}

	// Token: 0x17000048 RID: 72
	// (get) Token: 0x0600014D RID: 333 RVA: 0x0000787D File Offset: 0x00005A7D
	public Vector2 Center
	{
		get
		{
			return this.Position + this.Size * 0.5f;
		}
	}

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x0600014E RID: 334 RVA: 0x0000789A File Offset: 0x00005A9A
	// (set) Token: 0x0600014F RID: 335 RVA: 0x000078AD File Offset: 0x00005AAD
	public Vector2 Size
	{
		get
		{
			return new Vector2(this.width, this.height);
		}
		set
		{
			this.right = this.left + value.x;
			this.bottom = this.top + value.y;
		}
	}

	// Token: 0x1700004A RID: 74
	// (get) Token: 0x06000150 RID: 336 RVA: 0x000078D7 File Offset: 0x00005AD7
	public Rect WithoutPosition
	{
		get
		{
			return new Rect(0f, 0f, this.width, this.height);
		}
	}

	// Token: 0x06000151 RID: 337 RVA: 0x000078F4 File Offset: 0x00005AF4
	public static Rect operator +(Rect r, Vector2 p)
	{
		r.Position += p;
		return r;
	}

	/// <summary>
	/// Returns a Rect where left right top bottom describe the size of an edge.
	/// This is used for things like margin, padding, border size
	/// </summary>
	// Token: 0x06000152 RID: 338 RVA: 0x0000790C File Offset: 0x00005B0C
	internal static Rect GetEdges(Vector2 size, Length? l, Length? t, Length? r, Length? b)
	{
		return new Rect
		{
			left = ((l != null) ? l.GetValueOrDefault().GetPixels(size.x) : 0f),
			top = ((t != null) ? t.GetValueOrDefault().GetPixels(size.y) : 0f),
			right = ((r != null) ? r.GetValueOrDefault().GetPixels(size.x) : 0f),
			bottom = ((b != null) ? b.GetValueOrDefault().GetPixels(size.y) : 0f)
		};
	}

	/// <summary>
	/// Return true if the passed rect is partially or fully inside 
	/// </summary>
	// Token: 0x06000153 RID: 339 RVA: 0x000079D8 File Offset: 0x00005BD8
	public bool IsInside(in Rect rect, bool fullyInside = false)
	{
		if (fullyInside)
		{
			return this.left < rect.left && this.right > rect.right && this.top < rect.top && this.bottom > rect.bottom;
		}
		return rect.right >= this.left && rect.left <= this.right && rect.top <= this.bottom && rect.bottom >= this.top;
	}

	/// <summary>
	/// Return true if the passed point is inside
	/// </summary>
	// Token: 0x06000154 RID: 340 RVA: 0x00007A64 File Offset: 0x00005C64
	public bool IsInside(in Vector2 pos)
	{
		return pos.x >= this.left && pos.x <= this.right && pos.y <= this.bottom && pos.y >= this.top;
	}

	/// <summary>
	/// When the Rect describes edges, this returns the total size of the edges in each direction
	/// </summary>
	// Token: 0x1700004B RID: 75
	// (get) Token: 0x06000155 RID: 341 RVA: 0x00007AB2 File Offset: 0x00005CB2
	public Vector2 EdgeSize
	{
		get
		{
			return new Vector2(this.left + this.right, this.top + this.bottom);
		}
	}

	/// <summary>
	/// Where padding is an edge type rect, will return this rect contracted with those edges.
	/// </summary>
	// Token: 0x06000156 RID: 342 RVA: 0x00007AD3 File Offset: 0x00005CD3
	public Rect Contract(Margin m)
	{
		return this.Shrink(m.left, m.top, m.left, m.bottom);
	}

	/// <summary>
	/// Where padding is an edge type rect, will return this rect contracted with those edges.
	/// </summary>
	// Token: 0x06000157 RID: 343 RVA: 0x00007AF4 File Offset: 0x00005CF4
	public Rect Shrink(float left, float top, float right, float bottom)
	{
		Rect r = this;
		r.left += left;
		r.top += top;
		r.right -= right;
		r.bottom -= bottom;
		return r;
	}

	// Token: 0x06000158 RID: 344 RVA: 0x00007B3C File Offset: 0x00005D3C
	public Rect Grow(float left, float top, float right, float bottom)
	{
		Rect r = this;
		r.left -= left;
		r.top -= top;
		r.right += right;
		r.bottom += bottom;
		return r;
	}

	/// <summary>
	/// Where padding is an edge type rect, will return this rect expanded with those edges.
	/// </summary>
	// Token: 0x06000159 RID: 345 RVA: 0x00007B84 File Offset: 0x00005D84
	public Rect Expand(Margin m)
	{
		Rect r = this;
		r.left += m.left;
		r.top += m.top;
		r.right -= m.right;
		r.bottom -= m.bottom;
		return r;
	}

	// Token: 0x0600015A RID: 346 RVA: 0x00007BE0 File Offset: 0x00005DE0
	public readonly Rect Expand(float f)
	{
		Rect r = this;
		r.left -= f;
		r.top -= f;
		r.right += f;
		r.bottom += f;
		return r;
	}

	// Token: 0x0600015B RID: 347 RVA: 0x00007C25 File Offset: 0x00005E25
	public readonly Rect Contract(float f)
	{
		return this.Expand(f * -1f);
	}

	// Token: 0x0600015C RID: 348 RVA: 0x00007C34 File Offset: 0x00005E34
	public readonly Rect Expand(float x, float y)
	{
		Rect r = this;
		r.left -= x;
		r.top -= y;
		r.right += x;
		r.bottom += y;
		return r;
	}

	// Token: 0x0600015D RID: 349 RVA: 0x00007C79 File Offset: 0x00005E79
	public readonly Rect Contract(float x, float y)
	{
		return this.Expand(x * -1f, y * -1f);
	}

	// Token: 0x0600015E RID: 350 RVA: 0x00007C90 File Offset: 0x00005E90
	public Rect Floor()
	{
		Rect r = this;
		r.left = MathF.Floor(r.left);
		r.top = MathF.Floor(r.top);
		r.right = MathF.Floor(r.right);
		r.bottom = MathF.Floor(r.bottom);
		return r;
	}

	// Token: 0x0600015F RID: 351 RVA: 0x00007CF0 File Offset: 0x00005EF0
	public Rect Round()
	{
		Rect r = this;
		r.left = MathF.Round(r.left);
		r.top = MathF.Round(r.top);
		r.right = MathF.Round(r.right);
		r.bottom = MathF.Round(r.bottom);
		return r;
	}

	// Token: 0x06000160 RID: 352 RVA: 0x00007D50 File Offset: 0x00005F50
	public Rect Ceiling()
	{
		Rect r = this;
		r.left = MathF.Ceiling(r.left);
		r.top = MathF.Ceiling(r.top);
		r.right = MathF.Ceiling(r.right);
		r.bottom = MathF.Ceiling(r.bottom);
		return r;
	}

	// Token: 0x06000161 RID: 353 RVA: 0x00007DAD File Offset: 0x00005FAD
	public static Rect operator +(Rect a, Rect b)
	{
		return new Rect(a.left + b.left, a.top + b.top, a.width + b.width, a.height + b.height);
	}

	// Token: 0x06000162 RID: 354 RVA: 0x00007DEC File Offset: 0x00005FEC
	public static Rect operator *(Rect a, float b)
	{
		return new Rect(a.left * b, a.top * b, a.width * b, a.height * b);
	}

	// Token: 0x06000163 RID: 355 RVA: 0x00007E18 File Offset: 0x00006018
	public static Rect operator *(Rect a, Vector2 b)
	{
		return new Rect(a.left * b.x, a.top * b.y, a.width * b.x, a.height * b.y);
	}

	// Token: 0x06000164 RID: 356 RVA: 0x00007E64 File Offset: 0x00006064
	public override string ToString()
	{
		return string.Format("{0},{1},{2},{3}", new object[] { this.left, this.top, this.width, this.height });
	}

	// Token: 0x06000165 RID: 357 RVA: 0x00007EB9 File Offset: 0x000060B9
	public Vector4 ToVector4()
	{
		return new Vector4(this.left, this.top, this.right, this.bottom);
	}

	/// <summary>
	/// Expand this Rect to contain the other rect
	/// </summary>
	// Token: 0x06000166 RID: 358 RVA: 0x00007ED8 File Offset: 0x000060D8
	public void Add(Rect r)
	{
		this.left = MathF.Min(this.left, r.left);
		this.right = MathF.Max(this.right, r.right);
		this.top = MathF.Min(this.top, r.top);
		this.bottom = MathF.Max(this.bottom, r.bottom);
	}

	/// <summary>
	/// Expand this Rect to contain the point
	/// </summary>
	// Token: 0x06000167 RID: 359 RVA: 0x00007F44 File Offset: 0x00006144
	public void Add(Vector3 point)
	{
		this.left = MathF.Min(this.left, point.x);
		this.right = MathF.Max(this.right, point.x);
		this.top = MathF.Min(this.top, point.y);
		this.bottom = MathF.Max(this.bottom, point.y);
	}

	// Token: 0x06000168 RID: 360 RVA: 0x00007FB1 File Offset: 0x000061B1
	public static bool operator ==(Rect left, Rect right)
	{
		return left.Equals(right);
	}

	// Token: 0x06000169 RID: 361 RVA: 0x00007FBB File Offset: 0x000061BB
	public static bool operator !=(Rect left, Rect right)
	{
		return !(left == right);
	}

	// Token: 0x0600016A RID: 362 RVA: 0x00007FC8 File Offset: 0x000061C8
	public override bool Equals(object obj)
	{
		if (obj is Rect)
		{
			Rect o = (Rect)obj;
			return this.Equals(o);
		}
		return false;
	}

	// Token: 0x0600016B RID: 363 RVA: 0x00007FF0 File Offset: 0x000061F0
	public bool Equals(Rect o)
	{
		float num = this.left;
		float num2 = this.right;
		float num3 = this.top;
		float num4 = this.bottom;
		float num5 = o.left;
		float num6 = o.right;
		float num7 = o.top;
		float num8 = o.bottom;
		return num == num5 && num2 == num6 && num3 == num7 && num4 == num8;
	}

	// Token: 0x0600016C RID: 364 RVA: 0x0000804B File Offset: 0x0000624B
	public override int GetHashCode()
	{
		return HashCode.Combine<float, float, float, float>(this.left, this.right, this.top, this.bottom);
	}

	/// <summary>
	/// Return this rect expanded to include this point
	/// </summary>
	// Token: 0x0600016D RID: 365 RVA: 0x0000806C File Offset: 0x0000626C
	public Rect AddPoint(Vector2 pos)
	{
		Rect r = this;
		r.left = MathF.Min(r.left, pos.x);
		r.right = MathF.Max(r.right, pos.x);
		r.top = MathF.Min(r.top, pos.y);
		r.bottom = MathF.Max(r.bottom, pos.y);
		return r;
	}

	// Token: 0x1700004C RID: 76
	// (get) Token: 0x0600016E RID: 366 RVA: 0x000080E5 File Offset: 0x000062E5
	[JsonIgnore]
	public readonly Vector2 BottomLeft
	{
		get
		{
			return new Vector2(this.left, this.bottom);
		}
	}

	// Token: 0x1700004D RID: 77
	// (get) Token: 0x0600016F RID: 367 RVA: 0x000080F8 File Offset: 0x000062F8
	[JsonIgnore]
	public readonly Vector2 BottomRight
	{
		get
		{
			return new Vector2(this.right, this.bottom);
		}
	}

	// Token: 0x1700004E RID: 78
	// (get) Token: 0x06000170 RID: 368 RVA: 0x0000810B File Offset: 0x0000630B
	[JsonIgnore]
	public readonly Vector2 TopRight
	{
		get
		{
			return new Vector2(this.right, this.top);
		}
	}

	// Token: 0x1700004F RID: 79
	// (get) Token: 0x06000171 RID: 369 RVA: 0x0000811E File Offset: 0x0000631E
	[JsonIgnore]
	public readonly Vector2 TopLeft
	{
		get
		{
			return new Vector2(this.left, this.top);
		}
	}

	// Token: 0x0400004C RID: 76
	public float left;

	// Token: 0x0400004D RID: 77
	public float top;

	// Token: 0x0400004E RID: 78
	public float right;

	// Token: 0x0400004F RID: 79
	public float bottom;
}
