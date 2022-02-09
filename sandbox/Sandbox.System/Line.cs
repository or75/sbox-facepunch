using System;
using System.Text.Json.Serialization;
using Sandbox;

// Token: 0x02000019 RID: 25
public struct Line : IEquatable<Line>
{
	/// <summary>
	/// Returns the result of b - a
	/// </summary>
	// Token: 0x1700003E RID: 62
	// (get) Token: 0x060000FB RID: 251 RVA: 0x000068AE File Offset: 0x00004AAE
	[JsonIgnore]
	public readonly Vector3 Delta
	{
		get
		{
			return this.b - this.a;
		}
	}

	/// <summary>
	/// Returns the midpoint between a and b
	/// </summary>
	// Token: 0x1700003F RID: 63
	// (get) Token: 0x060000FC RID: 252 RVA: 0x000068C1 File Offset: 0x00004AC1
	[JsonIgnore]
	public readonly Vector3 Center
	{
		get
		{
			return (this.a + this.b) * 0.5f;
		}
	}

	// Token: 0x060000FD RID: 253 RVA: 0x000068DE File Offset: 0x00004ADE
	public Line(Vector3 a, Vector3 b)
	{
		this.a = a;
		this.b = b;
	}

	// Token: 0x060000FE RID: 254 RVA: 0x000068EE File Offset: 0x00004AEE
	public Line(Vector3 origin, Vector3 direction, float length)
	{
		this.a = origin;
		this.b = origin + direction * length;
	}

	// Token: 0x060000FF RID: 255 RVA: 0x0000690C File Offset: 0x00004B0C
	public readonly bool Trace(Ray ray, float radius, float maxDistance = 3.4028235E+38f)
	{
		if (radius <= 0f)
		{
			return false;
		}
		Vector3 u = this.b - this.a;
		Vector3 v = ray.Direction;
		Vector3 w = this.a - ray.Origin;
		float UdotU = Vector3.Dot(u, u);
		float UdotV = Vector3.Dot(u, v);
		float VdotW = Vector3.Dot(v, w);
		float det = UdotU - UdotV * UdotV;
		float s = 0f;
		float t = VdotW;
		if (det >= 0.0001f)
		{
			float UdotW = Vector3.Dot(u, w);
			float num = 1f / det;
			s = num * (UdotV * VdotW - UdotW);
			t = num * (UdotU * VdotW - UdotV * UdotW);
			s = s.Clamp(0f, 1f);
		}
		if (t < 0f || t > maxDistance)
		{
			return false;
		}
		Vector3 p = this.a + s * u;
		return (double)(ray.Origin + t * v - p).Length <= (double)radius;
	}

	// Token: 0x06000100 RID: 256 RVA: 0x00006A18 File Offset: 0x00004C18
	public readonly Vector3 ClosestPoint(Vector3 pos)
	{
		Vector3 delta = this.b - this.a;
		float length = delta.Length;
		Vector3 direction = delta / length;
		return this.a + Vector3.Dot(pos - this.a, direction).Clamp(0f, length) * direction;
	}

	// Token: 0x06000101 RID: 257 RVA: 0x00006A78 File Offset: 0x00004C78
	public readonly Vector3 ClosestPoint(Ray ray)
	{
		Vector3 u = this.a - this.b;
		Vector3 v = ray.Direction;
		Vector3 w = this.b - ray.Origin;
		float UdotU = Vector3.Dot(u, u);
		float UdotV = Vector3.Dot(u, v);
		float VdotW = Vector3.Dot(v, w);
		float det = UdotU - UdotV * UdotV;
		float s = 0f;
		float t = VdotW;
		if ((double)det >= 0.0001)
		{
			float UdotW = Vector3.Dot(u, w);
			float num = 1f / det;
			s = num * (UdotV * VdotW - UdotW);
			t = num * (UdotU * VdotW - UdotV * UdotW);
			s = s.Clamp(0f, 1f);
		}
		if (t < 0f)
		{
			return this.Center;
		}
		return this.b + s * u;
	}

	// Token: 0x06000102 RID: 258 RVA: 0x00006B50 File Offset: 0x00004D50
	public readonly double Distance(Vector3 pos)
	{
		return (double)(pos - this.ClosestPoint(pos)).Length;
	}

	// Token: 0x06000103 RID: 259 RVA: 0x00006B74 File Offset: 0x00004D74
	public readonly double SqrDistance(Vector3 pos)
	{
		return (double)(pos - this.ClosestPoint(pos)).LengthSquared;
	}

	// Token: 0x06000104 RID: 260 RVA: 0x00006B97 File Offset: 0x00004D97
	public readonly bool Equals(Line other)
	{
		return other.a == this.a && other.b == this.b;
	}

	// Token: 0x04000042 RID: 66
	public Vector3 a;

	// Token: 0x04000043 RID: 67
	public Vector3 b;
}
