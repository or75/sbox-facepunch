using System;
using System.Runtime.Serialization;

// Token: 0x0200001B RID: 27
[DataContract]
public struct Plane : IEquatable<Plane>
{
	// Token: 0x06000125 RID: 293 RVA: 0x00007181 File Offset: 0x00005381
	public Plane(Vector3 normal, double w)
	{
		this.Normal = normal.Normal;
		this.Distance = (float)w;
	}

	// Token: 0x06000126 RID: 294 RVA: 0x00007198 File Offset: 0x00005398
	public Plane(Vector3 origin, Vector3 normal)
	{
		this.Normal = normal.Normal;
		this.Distance = Vector3.Dot(origin, this.Normal);
	}

	// Token: 0x06000127 RID: 295 RVA: 0x000071BC File Offset: 0x000053BC
	public Plane(Vector3 a, Vector3 b, Vector3 c)
	{
		this.Normal = Vector3.Cross(b - a, c - a).Normal;
		this.Distance = a.Dot(this.Normal);
	}

	// Token: 0x17000042 RID: 66
	// (get) Token: 0x06000128 RID: 296 RVA: 0x000071FD File Offset: 0x000053FD
	public Vector3 Origin
	{
		get
		{
			return this.Normal * this.Distance;
		}
	}

	// Token: 0x06000129 RID: 297 RVA: 0x00007210 File Offset: 0x00005410
	public float GetDistance(Vector3 point)
	{
		return point.Dot(this.Normal) - this.Distance;
	}

	// Token: 0x0600012A RID: 298 RVA: 0x00007226 File Offset: 0x00005426
	public bool IsInFront(Vector3 point)
	{
		return this.GetDistance(point) > 0f;
	}

	// Token: 0x0600012B RID: 299 RVA: 0x00007238 File Offset: 0x00005438
	public bool IsInFront(BBox box, bool partially = false)
	{
		Vector3 s = default(Vector3);
		if (partially)
		{
			s.x = ((this.Normal.x < 0f) ? box.Mins.x : box.Maxs.x);
			s.y = ((this.Normal.y < 0f) ? box.Mins.y : box.Maxs.y);
			s.z = ((this.Normal.z < 0f) ? box.Mins.z : box.Maxs.z);
		}
		else
		{
			s.x = ((this.Normal.x > 0f) ? box.Mins.x : box.Maxs.x);
			s.y = ((this.Normal.y > 0f) ? box.Mins.y : box.Maxs.y);
			s.z = ((this.Normal.z > 0f) ? box.Mins.z : box.Maxs.z);
		}
		return this.IsInFront(s);
	}

	// Token: 0x0600012C RID: 300 RVA: 0x00007391 File Offset: 0x00005591
	public Vector3 SnapToPlane(Vector3 point)
	{
		return point - this.Normal * this.GetDistance(point);
	}

	/// <summary>
	/// Trace a Ray against this plane
	/// </summary>
	/// <param name="ray">The origin and direction to trace from</param>
	/// <param name="twosided">If true we'll trace against the underside of the plane too.</param>
	/// <param name="maxDistance">The maximum distance from the ray origin to trace</param>
	/// <returns>The hit position on the ray. Or null if we didn't hit.</returns>
	// Token: 0x0600012D RID: 301 RVA: 0x000073AC File Offset: 0x000055AC
	public Vector3? Trace(Ray ray, bool twosided = false, double maxDistance = 1.7976931348623157E+308)
	{
		Vector3 i = this.Normal;
		float denominator = ray.Direction.Dot(i);
		if (twosided && denominator >= -1E-05f)
		{
			i *= -1f;
			denominator = ray.Direction.Dot(i);
		}
		if (denominator >= -1E-05f)
		{
			return null;
		}
		float t = (this.Origin - ray.Origin).Dot(i) / denominator;
		if ((double)t > maxDistance)
		{
			return null;
		}
		return new Vector3?(ray.Origin + ray.Direction * t);
	}

	/// <summary>
	/// Gets the intersecting point of the three planes if it exists.
	/// If the planes don't all intersect will return null.
	/// </summary>
	// Token: 0x0600012E RID: 302 RVA: 0x00007458 File Offset: 0x00005658
	public static Vector3? GetIntersection(Plane vp1, Plane vp2, Plane vp3)
	{
		Vector3 v2Cross3 = Vector3.Cross(vp2.Normal, vp3.Normal);
		float flDenom = Vector3.Dot(vp1.Normal, v2Cross3);
		if (MathF.Abs(flDenom) < 1.1920929E-07f)
		{
			return null;
		}
		return new Vector3?((vp1.Distance * v2Cross3 + vp2.Distance * Vector3.Cross(vp3.Normal, vp1.Normal) + vp3.Distance * Vector3.Cross(vp1.Normal, vp2.Normal)) * (1f / flDenom));
	}

	// Token: 0x0600012F RID: 303 RVA: 0x000074FA File Offset: 0x000056FA
	public static bool operator ==(Plane left, Plane right)
	{
		return left.Equals(right);
	}

	// Token: 0x06000130 RID: 304 RVA: 0x00007504 File Offset: 0x00005704
	public static bool operator !=(Plane left, Plane right)
	{
		return !(left == right);
	}

	// Token: 0x06000131 RID: 305 RVA: 0x00007510 File Offset: 0x00005710
	public override bool Equals(object obj)
	{
		if (obj is Plane)
		{
			Plane o = (Plane)obj;
			return this.Equals(o);
		}
		return false;
	}

	// Token: 0x06000132 RID: 306 RVA: 0x00007538 File Offset: 0x00005738
	public bool Equals(Plane o)
	{
		Vector3 normal = this.Normal;
		float distance = this.Distance;
		Vector3 normal2 = this.Normal;
		float distance2 = this.Distance;
		return normal == normal2 && distance == distance2;
	}

	// Token: 0x06000133 RID: 307 RVA: 0x0000756E File Offset: 0x0000576E
	public override int GetHashCode()
	{
		return HashCode.Combine<Vector3, float>(this.Normal, this.Distance);
	}

	// Token: 0x04000045 RID: 69
	public Vector3 Normal;

	// Token: 0x04000046 RID: 70
	public float Distance;
}
