using System;

namespace Sandbox.UI
{
	// Token: 0x0200005E RID: 94
	public struct Margin
	{
		// Token: 0x06000410 RID: 1040 RVA: 0x0001EF78 File Offset: 0x0001D178
		public Margin(float uniform)
		{
			this.left = uniform;
			this.top = uniform;
			this.right = uniform;
			this.bottom = uniform;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x0001EF96 File Offset: 0x0001D196
		public Margin(float left, float top, float right, float bottom)
		{
			this.left = left;
			this.top = top;
			this.right = right;
			this.bottom = bottom;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0001EFB5 File Offset: 0x0001D1B5
		public Margin(float? left, float? top, float? right, float? bottom)
		{
			this.left = left.GetValueOrDefault();
			this.top = top.GetValueOrDefault();
			this.right = right.GetValueOrDefault();
			this.bottom = bottom.GetValueOrDefault();
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x0001EFEB File Offset: 0x0001D1EB
		// (set) Token: 0x06000414 RID: 1044 RVA: 0x0001EFFA File Offset: 0x0001D1FA
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

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x0001F00A File Offset: 0x0001D20A
		// (set) Token: 0x06000416 RID: 1046 RVA: 0x0001F019 File Offset: 0x0001D219
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

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x0001F029 File Offset: 0x0001D229
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x0001F03C File Offset: 0x0001D23C
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

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x0001F071 File Offset: 0x0001D271
		// (set) Token: 0x0600041A RID: 1050 RVA: 0x0001F084 File Offset: 0x0001D284
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

		/// <summary>
		/// Returns a Rect where left right top bottom describe the size of an edge.
		/// This is used for things like margin, padding, border size
		/// </summary>
		// Token: 0x0600041B RID: 1051 RVA: 0x0001F0B0 File Offset: 0x0001D2B0
		internal static Margin GetEdges(Vector2 size, Length? l, Length? t, Length? r, Length? b)
		{
			return new Margin((l != null) ? new float?(l.GetValueOrDefault().GetPixels(size.x)) : null, (t != null) ? new float?(t.GetValueOrDefault().GetPixels(size.y)) : null, (r != null) ? new float?(r.GetValueOrDefault().GetPixels(size.x)) : null, (b != null) ? new float?(b.GetValueOrDefault().GetPixels(size.y)) : null);
		}

		/// <summary>
		/// When the Rect describes edges, this returns the total size of the edges in each direction
		/// </summary>
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x0001F17E File Offset: 0x0001D37E
		public Vector2 EdgeSize
		{
			get
			{
				return new Vector2(this.left + this.right, this.top + this.bottom);
			}
		}

		/// <summary>
		/// Where padding is an edge type rect, will return this rect expanded with those edges.
		/// </summary>
		// Token: 0x0600041D RID: 1053 RVA: 0x0001F1A0 File Offset: 0x0001D3A0
		public Margin EdgeAdd(Margin edges)
		{
			Margin r = this;
			r.left += edges.left;
			r.top += edges.top;
			r.right -= edges.right;
			r.bottom -= edges.bottom;
			return r;
		}

		/// <summary>
		/// Where padding is an edge type rect, will return this rect expanded with those edges.
		/// </summary>
		// Token: 0x0600041E RID: 1054 RVA: 0x0001F1FC File Offset: 0x0001D3FC
		public Margin EdgeSubtract(Margin edges)
		{
			Margin r = this;
			r.left += edges.left;
			r.top += edges.top;
			r.right -= edges.right;
			r.bottom -= edges.bottom;
			return r;
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0001F255 File Offset: 0x0001D455
		public static Margin operator +(Margin a, Margin b)
		{
			return new Margin(a.left + b.left, a.top + b.top, a.right + b.right, a.bottom + b.bottom);
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0001F290 File Offset: 0x0001D490
		public static Margin operator *(Margin a, float b)
		{
			return new Margin(a.left * b, a.top * b, a.right * b, a.bottom * b);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0001F2B7 File Offset: 0x0001D4B7
		public static Margin operator *(Margin a, Vector2 b)
		{
			return new Margin(a.left * b.x, a.top * b.y, a.right * b.x, a.bottom * b.y);
		}

		// Token: 0x040008DE RID: 2270
		public float left;

		// Token: 0x040008DF RID: 2271
		public float top;

		// Token: 0x040008E0 RID: 2272
		public float right;

		// Token: 0x040008E1 RID: 2273
		public float bottom;
	}
}
