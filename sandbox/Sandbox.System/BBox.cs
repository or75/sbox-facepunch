using System;
using System.Collections.Generic;
using Sandbox;

// Token: 0x02000016 RID: 22
public struct BBox : IEquatable<BBox>
{
	// Token: 0x060000D6 RID: 214 RVA: 0x00005EFB File Offset: 0x000040FB
	public BBox(Vector3 mins, Vector3 maxs)
	{
		this.Mins = mins;
		this.Maxs = maxs;
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00005F0B File Offset: 0x0000410B
	public BBox(Vector3 center)
	{
		this.Mins = center;
		this.Maxs = center;
	}

	// Token: 0x17000039 RID: 57
	// (get) Token: 0x060000D8 RID: 216 RVA: 0x00005F1B File Offset: 0x0000411B
	public IEnumerable<Vector3> Corners
	{
		get
		{
			yield return new Vector3(this.Mins.x, this.Mins.y, this.Mins.z);
			yield return new Vector3(this.Maxs.x, this.Mins.y, this.Mins.z);
			yield return new Vector3(this.Maxs.x, this.Maxs.y, this.Mins.z);
			yield return new Vector3(this.Mins.x, this.Maxs.y, this.Mins.z);
			yield return new Vector3(this.Mins.x, this.Mins.y, this.Maxs.z);
			yield return new Vector3(this.Maxs.x, this.Mins.y, this.Maxs.z);
			yield return new Vector3(this.Maxs.x, this.Maxs.y, this.Maxs.z);
			yield return new Vector3(this.Mins.x, this.Maxs.y, this.Maxs.z);
			yield break;
		}
	}

	// Token: 0x1700003A RID: 58
	// (get) Token: 0x060000D9 RID: 217 RVA: 0x00005F30 File Offset: 0x00004130
	public Vector3 Center
	{
		get
		{
			return this.Mins + this.Size * 0.5f;
		}
	}

	// Token: 0x1700003B RID: 59
	// (get) Token: 0x060000DA RID: 218 RVA: 0x00005F4D File Offset: 0x0000414D
	public Vector3 Size
	{
		get
		{
			return this.Maxs - this.Mins;
		}
	}

	// Token: 0x1700003C RID: 60
	// (get) Token: 0x060000DB RID: 219 RVA: 0x00005F60 File Offset: 0x00004160
	public Vector3 RandomPointInside
	{
		get
		{
			Vector3 size = this.Size;
			size.x *= Rand.Float(0f, 1f);
			size.y *= Rand.Float(0f, 1f);
			size.z *= Rand.Float(0f, 1f);
			return this.Mins + size;
		}
	}

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x060000DC RID: 220 RVA: 0x00005FD8 File Offset: 0x000041D8
	public float Volume
	{
		get
		{
			return MathF.Abs(this.Mins.x - this.Maxs.x) * MathF.Abs(this.Mins.y - this.Maxs.y) * MathF.Abs(this.Mins.z - this.Maxs.z);
		}
	}

	/// <summary>
	/// Returns true if this bbox completely contains bbox
	/// </summary>
	// Token: 0x060000DD RID: 221 RVA: 0x0000603C File Offset: 0x0000423C
	public readonly bool Contains(BBox b)
	{
		return b.Mins.x >= this.Mins.x && b.Maxs.x < this.Maxs.x && b.Mins.y >= this.Mins.y && b.Maxs.y < this.Maxs.y && b.Mins.z >= this.Mins.z && b.Maxs.z < this.Maxs.z;
	}

	/// <summary>
	/// Returns true if this bbox somewat overlaps bbox
	/// </summary>
	// Token: 0x060000DE RID: 222 RVA: 0x000060E4 File Offset: 0x000042E4
	public readonly bool Overlaps(BBox b)
	{
		return this.Mins.x < b.Maxs.x && b.Mins.x < this.Maxs.x && this.Mins.y < b.Maxs.y && b.Mins.y < this.Maxs.y && this.Mins.z < b.Maxs.z && b.Mins.z < this.Maxs.z;
	}

	/// <summary>
	/// Returns this bbox but stretched to include this point
	/// </summary>
	// Token: 0x060000DF RID: 223 RVA: 0x0000618C File Offset: 0x0000438C
	public BBox AddPoint(Vector3 point)
	{
		BBox b = this;
		b.Mins.x = MathF.Min(b.Mins.x, point.x);
		b.Mins.y = MathF.Min(b.Mins.y, point.y);
		b.Mins.z = MathF.Min(b.Mins.z, point.z);
		b.Maxs.x = MathF.Max(b.Maxs.x, point.x);
		b.Maxs.y = MathF.Max(b.Maxs.y, point.y);
		b.Maxs.z = MathF.Max(b.Maxs.z, point.z);
		return b;
	}

	/// <summary>
	/// Returns the closest point on this bbox to another point
	/// </summary>
	// Token: 0x060000E0 RID: 224 RVA: 0x0000627C File Offset: 0x0000447C
	public Vector3 ClosestPoint(Vector3 point)
	{
		return new Vector3(Math.Clamp(point.x, this.Mins.x, this.Maxs.x), Math.Clamp(point.y, this.Mins.y, this.Maxs.y), Math.Clamp(point.z, this.Mins.z, this.Maxs.z));
	}

	/// <summary>
	/// Creates a bbox of radius length and depth, and height height
	/// </summary>
	// Token: 0x060000E1 RID: 225 RVA: 0x000062F4 File Offset: 0x000044F4
	public static BBox FromHeightAndRadius(float height, float radius)
	{
		return new BBox((Vector3.One * -radius).WithZ(0f), (Vector3.One * radius).WithZ(height));
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x00006334 File Offset: 0x00004534
	public static BBox FromPositionAndSize(Vector3 center, float size)
	{
		return new BBox
		{
			Mins = center - size * 0.5f,
			Maxs = center + size * 0.5f
		};
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x0000637C File Offset: 0x0000457C
	public static BBox operator *(BBox c1, float c2)
	{
		c1.Mins *= c2;
		c1.Maxs *= c2;
		return c1;
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x000063AF File Offset: 0x000045AF
	public static BBox operator +(BBox c1, Vector3 c2)
	{
		c1.Mins += c2;
		c1.Maxs += c2;
		return c1;
	}

	/// <summary>
	/// Formats the bbox into a string "mins, maxs"
	/// </summary>
	/// <returns></returns>
	// Token: 0x060000E5 RID: 229 RVA: 0x000063E2 File Offset: 0x000045E2
	public override string ToString()
	{
		return string.Format("mins {0:0.###}, maxs {1:0.###}", this.Mins, this.Maxs);
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x00006404 File Offset: 0x00004604
	public static bool operator ==(BBox left, BBox right)
	{
		return left.Equals(right);
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x0000640E File Offset: 0x0000460E
	public static bool operator !=(BBox left, BBox right)
	{
		return !(left == right);
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x0000641C File Offset: 0x0000461C
	public override bool Equals(object obj)
	{
		if (obj is BBox)
		{
			BBox o = (BBox)obj;
			return this.Equals(o);
		}
		return false;
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x00006444 File Offset: 0x00004644
	public bool Equals(BBox o)
	{
		Vector3 mins = this.Mins;
		Vector3 maxs = this.Maxs;
		Vector3 mins2 = o.Mins;
		Vector3 maxs2 = o.Maxs;
		return mins == mins2 && maxs == maxs2;
	}

	// Token: 0x060000EA RID: 234 RVA: 0x0000647D File Offset: 0x0000467D
	public override int GetHashCode()
	{
		return HashCode.Combine<Vector3, Vector3>(this.Mins, this.Maxs);
	}

	// Token: 0x04000037 RID: 55
	public Vector3 Mins;

	// Token: 0x04000038 RID: 56
	public Vector3 Maxs;
}
