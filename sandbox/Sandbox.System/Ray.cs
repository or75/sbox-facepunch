using System;

/// <summary>
/// A struct describing an origin and direction
/// </summary>
// Token: 0x0200001D RID: 29
public struct Ray : IEquatable<Ray>
{
	// Token: 0x17000043 RID: 67
	// (get) Token: 0x0600013A RID: 314 RVA: 0x000076A8 File Offset: 0x000058A8
	// (set) Token: 0x0600013B RID: 315 RVA: 0x000076B0 File Offset: 0x000058B0
	public Vector3 Origin
	{
		get
		{
			return this._origin;
		}
		set
		{
			this._origin = value;
		}
	}

	// Token: 0x17000044 RID: 68
	// (get) Token: 0x0600013C RID: 316 RVA: 0x000076B9 File Offset: 0x000058B9
	// (set) Token: 0x0600013D RID: 317 RVA: 0x000076C1 File Offset: 0x000058C1
	public Vector3 Direction
	{
		get
		{
			return this._direction;
		}
		set
		{
			this._direction = value;
		}
	}

	// Token: 0x0600013E RID: 318 RVA: 0x000076CA File Offset: 0x000058CA
	public Ray(Vector3 origin, Vector3 direction)
	{
		this._origin = origin;
		this._direction = direction;
	}

	// Token: 0x0600013F RID: 319 RVA: 0x000076DA File Offset: 0x000058DA
	public Vector3 Project(float distance)
	{
		return this.Origin + this.Direction * distance;
	}

	// Token: 0x06000140 RID: 320 RVA: 0x000076F3 File Offset: 0x000058F3
	public static bool operator ==(Ray left, Ray right)
	{
		return left.Equals(right);
	}

	// Token: 0x06000141 RID: 321 RVA: 0x000076FD File Offset: 0x000058FD
	public static bool operator !=(Ray left, Ray right)
	{
		return !(left == right);
	}

	// Token: 0x06000142 RID: 322 RVA: 0x0000770C File Offset: 0x0000590C
	public override bool Equals(object obj)
	{
		if (obj is Ray)
		{
			Ray o = (Ray)obj;
			return this.Equals(o);
		}
		return false;
	}

	// Token: 0x06000143 RID: 323 RVA: 0x00007734 File Offset: 0x00005934
	public bool Equals(Ray o)
	{
		Vector3 origin = this._origin;
		Vector3 direction = this._direction;
		Vector3 origin2 = o._origin;
		Vector3 direction2 = o._direction;
		return origin == origin2 && direction == direction2;
	}

	// Token: 0x06000144 RID: 324 RVA: 0x0000776D File Offset: 0x0000596D
	public override int GetHashCode()
	{
		return HashCode.Combine<Vector3, Vector3>(this._origin, this._direction);
	}

	// Token: 0x0400004A RID: 74
	private Vector3 _origin;

	// Token: 0x0400004B RID: 75
	private Vector3 _direction;
}
