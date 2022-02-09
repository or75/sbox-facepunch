using System;

// Token: 0x02000023 RID: 35
public struct Sphere
{
	// Token: 0x060001B1 RID: 433 RVA: 0x00008EBF File Offset: 0x000070BF
	public Sphere(Vector3 center, float radius)
	{
		this._center = center;
		this._radius = radius;
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x00008ECF File Offset: 0x000070CF
	public override string ToString()
	{
		return string.Format("Center({0}), Radius({1})", this._center, this._radius);
	}

	// Token: 0x17000060 RID: 96
	// (get) Token: 0x060001B3 RID: 435 RVA: 0x00008EF1 File Offset: 0x000070F1
	// (set) Token: 0x060001B4 RID: 436 RVA: 0x00008EF9 File Offset: 0x000070F9
	public Vector3 Center
	{
		get
		{
			return this._center;
		}
		set
		{
			this._center = value;
		}
	}

	// Token: 0x17000061 RID: 97
	// (get) Token: 0x060001B5 RID: 437 RVA: 0x00008F02 File Offset: 0x00007102
	// (set) Token: 0x060001B6 RID: 438 RVA: 0x00008F0A File Offset: 0x0000710A
	public float Radius
	{
		get
		{
			return this._radius;
		}
		set
		{
			this._radius = value;
		}
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00008F14 File Offset: 0x00007114
	public bool Trace(Ray ray, double maxDistance = 1.7976931348623157E+308)
	{
		Vector3 dirToCenter = ray.Origin - this._center;
		float v = ray.Direction.Dot(this._center - ray.Origin);
		float disc = this.Radius * this.Radius - (dirToCenter.Dot(dirToCenter) - v * v);
		if (disc >= 0f)
		{
			double time = (double)(v - MathF.Sqrt(disc)) / maxDistance;
			return time >= 0.0 && time <= 1.0;
		}
		return false;
	}

	// Token: 0x04000060 RID: 96
	internal Vector3 _center;

	// Token: 0x04000061 RID: 97
	internal float _radius;
}
