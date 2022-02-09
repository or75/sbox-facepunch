using System;

// Token: 0x02000018 RID: 24
public struct Frustum : IEquatable<Frustum>
{
	/// <summary>
	/// Returns the corner point of one of the 8 corners.
	/// This may return null if i is &gt; 7 or the frustum is invalid.
	/// </summary>
	// Token: 0x060000F2 RID: 242 RVA: 0x00006570 File Offset: 0x00004770
	public Vector3? GetCorner(int i)
	{
		switch (i)
		{
		case 0:
			return Plane.GetIntersection(this.NearPlane, this.LeftPlane, this.TopPlane);
		case 1:
			return Plane.GetIntersection(this.NearPlane, this.TopPlane, this.RightPlane);
		case 2:
			return Plane.GetIntersection(this.NearPlane, this.RightPlane, this.BottomPlane);
		case 3:
			return Plane.GetIntersection(this.NearPlane, this.BottomPlane, this.LeftPlane);
		case 4:
			return Plane.GetIntersection(this.FarPlane, this.LeftPlane, this.TopPlane);
		case 5:
			return Plane.GetIntersection(this.FarPlane, this.TopPlane, this.RightPlane);
		case 6:
			return Plane.GetIntersection(this.FarPlane, this.RightPlane, this.BottomPlane);
		case 7:
			return Plane.GetIntersection(this.FarPlane, this.BottomPlane, this.LeftPlane);
		default:
			return null;
		}
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x00006674 File Offset: 0x00004874
	public BBox GetBBox()
	{
		BBox bbox = new BBox(this.GetCorner(0).Value);
		for (int i = 1; i < 7; i++)
		{
			bbox = bbox.AddPoint(this.GetCorner(i).Value);
		}
		return bbox;
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x000066BC File Offset: 0x000048BC
	public bool IsInside(Vector3 point)
	{
		return this.LeftPlane.IsInFront(point) && this.RightPlane.IsInFront(point) && this.TopPlane.IsInFront(point) && this.BottomPlane.IsInFront(point) && this.NearPlane.IsInFront(point) && this.FarPlane.IsInFront(point);
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x0000672C File Offset: 0x0000492C
	public bool IsInside(BBox box, bool partially = false)
	{
		return this.LeftPlane.IsInFront(box, partially) && this.RightPlane.IsInFront(box, partially) && this.TopPlane.IsInFront(box, partially) && this.BottomPlane.IsInFront(box, partially) && this.NearPlane.IsInFront(box, partially) && this.FarPlane.IsInFront(box, partially);
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x000067A0 File Offset: 0x000049A0
	public static bool operator ==(Frustum left, Frustum right)
	{
		return left.Equals(right);
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x000067AA File Offset: 0x000049AA
	public static bool operator !=(Frustum left, Frustum right)
	{
		return !(left == right);
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x000067B8 File Offset: 0x000049B8
	public override bool Equals(object obj)
	{
		if (obj is Frustum)
		{
			Frustum o = (Frustum)obj;
			return this.Equals(o);
		}
		return false;
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x000067E0 File Offset: 0x000049E0
	public bool Equals(Frustum o)
	{
		Plane leftPlane = this.LeftPlane;
		Plane rightPlane = this.RightPlane;
		Plane topPlane = this.TopPlane;
		Plane bottomPlane = this.BottomPlane;
		Plane nearPlane = this.NearPlane;
		Plane farPlane = this.FarPlane;
		Plane leftPlane2 = o.LeftPlane;
		Plane rightPlane2 = o.RightPlane;
		Plane topPlane2 = o.TopPlane;
		Plane bottomPlane2 = o.BottomPlane;
		Plane nearPlane2 = o.NearPlane;
		Plane farPlane2 = o.FarPlane;
		return leftPlane == leftPlane2 && rightPlane == rightPlane2 && topPlane == topPlane2 && bottomPlane == bottomPlane2 && nearPlane == nearPlane2 && farPlane == farPlane2;
	}

	// Token: 0x060000FA RID: 250 RVA: 0x00006883 File Offset: 0x00004A83
	public override int GetHashCode()
	{
		return HashCode.Combine<Plane, Plane, Plane, Plane, Plane, Plane>(this.LeftPlane, this.RightPlane, this.TopPlane, this.BottomPlane, this.NearPlane, this.FarPlane);
	}

	// Token: 0x0400003C RID: 60
	public Plane RightPlane;

	// Token: 0x0400003D RID: 61
	public Plane LeftPlane;

	// Token: 0x0400003E RID: 62
	public Plane TopPlane;

	// Token: 0x0400003F RID: 63
	public Plane BottomPlane;

	// Token: 0x04000040 RID: 64
	public Plane NearPlane;

	// Token: 0x04000041 RID: 65
	public Plane FarPlane;
}
