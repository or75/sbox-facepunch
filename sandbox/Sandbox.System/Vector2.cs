using System;
using System.IO;
using System.Numerics;
using System.Text.Json.Serialization;
using Sandbox;
using Sandbox.Internal.JsonConvert;

// Token: 0x02000025 RID: 37
[JsonConverter(typeof(Vector2Converter))]
public struct Vector2 : IEquatable<Vector2>
{
	// Token: 0x17000062 RID: 98
	// (get) Token: 0x060001CE RID: 462 RVA: 0x0000932B File Offset: 0x0000752B
	// (set) Token: 0x060001CF RID: 463 RVA: 0x00009338 File Offset: 0x00007538
	public float x
	{
		readonly get
		{
			return this.vec.X;
		}
		set
		{
			this.vec.X = value;
		}
	}

	// Token: 0x17000063 RID: 99
	// (get) Token: 0x060001D0 RID: 464 RVA: 0x00009346 File Offset: 0x00007546
	// (set) Token: 0x060001D1 RID: 465 RVA: 0x00009353 File Offset: 0x00007553
	public float y
	{
		readonly get
		{
			return this.vec.Y;
		}
		set
		{
			this.vec.Y = value;
		}
	}

	/// <summary>
	/// Returns the magnitude of the vector
	/// </summary>
	// Token: 0x17000064 RID: 100
	// (get) Token: 0x060001D2 RID: 466 RVA: 0x00009361 File Offset: 0x00007561
	public readonly float Length
	{
		get
		{
			return this.vec.Length();
		}
	}

	/// <summary>
	/// This is faster than Length, so is better to use in certain circumstances
	/// </summary>
	// Token: 0x17000065 RID: 101
	// (get) Token: 0x060001D3 RID: 467 RVA: 0x0000936E File Offset: 0x0000756E
	public readonly float LengthSquared
	{
		get
		{
			return this.vec.LengthSquared();
		}
	}

	/// <summary>
	/// returns true if the squared length is less than 1e-8 (which is really near zero)
	/// </summary>
	// Token: 0x17000066 RID: 102
	// (get) Token: 0x060001D4 RID: 468 RVA: 0x0000937B File Offset: 0x0000757B
	public readonly bool IsNearZeroLength
	{
		get
		{
			return (double)this.LengthSquared <= 1E-08;
		}
	}

	/// <summary>
	/// Return the same vector but with a length of one
	/// </summary>
	// Token: 0x17000067 RID: 103
	// (get) Token: 0x060001D5 RID: 469 RVA: 0x00009392 File Offset: 0x00007592
	public readonly Vector2 Normal
	{
		get
		{
			return Vector2.Normalize(this.vec);
		}
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x000093A4 File Offset: 0x000075A4
	public Vector2(float x)
	{
		this = new Vector2(x, x);
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x000093AE File Offset: 0x000075AE
	public Vector2(float x, float y)
	{
		this = new Vector2(new Vector2(x, y));
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x000093BD File Offset: 0x000075BD
	public Vector2(Vector3 v)
	{
		this = new Vector2(new Vector2(v.x, v.y));
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x000093DA File Offset: 0x000075DA
	internal static float Distance(in Vector2 a, in Vector2 b)
	{
		return Vector2.Distance(a.vec, b.vec);
	}

	// Token: 0x060001DA RID: 474 RVA: 0x000093ED File Offset: 0x000075ED
	public Vector2(Vector2 v)
	{
		this.vec = v;
	}

	// Token: 0x060001DB RID: 475 RVA: 0x000093F6 File Offset: 0x000075F6
	public static implicit operator Vector2(Vector2 value)
	{
		return new Vector2(value);
	}

	// Token: 0x060001DC RID: 476 RVA: 0x000093FE File Offset: 0x000075FE
	public static implicit operator Vector2(Vector3 value)
	{
		return new Vector2(value);
	}

	// Token: 0x060001DD RID: 477 RVA: 0x00009406 File Offset: 0x00007606
	public static implicit operator Vector4(Vector2 value)
	{
		return new Vector4(value.x, value.y, 0f, 0f);
	}

	// Token: 0x060001DE RID: 478 RVA: 0x00009425 File Offset: 0x00007625
	public static implicit operator Vector2(double value)
	{
		return new Vector2((float)value, (float)value);
	}

	// Token: 0x060001DF RID: 479 RVA: 0x00009430 File Offset: 0x00007630
	public static Vector2 operator +(Vector2 c1, Vector2 c2)
	{
		return c1.vec + c2.vec;
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x00009448 File Offset: 0x00007648
	public static Vector2 operator -(Vector2 c1, Vector2 c2)
	{
		return c1.vec - c2.vec;
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x00009460 File Offset: 0x00007660
	public static Vector2 operator -(Vector2 c1)
	{
		return Vector2.Negate(c1.vec);
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x00009472 File Offset: 0x00007672
	public static Vector2 operator *(Vector2 c1, float f)
	{
		return c1.vec * f;
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x00009485 File Offset: 0x00007685
	public static Vector2 operator *(float f, Vector2 c1)
	{
		return c1.vec * f;
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x00009498 File Offset: 0x00007698
	public static Vector2 operator *(Vector2 c1, Vector2 c2)
	{
		return c1.vec * c2.vec;
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x000094B0 File Offset: 0x000076B0
	public static Vector2 operator /(Vector2 c1, Vector2 c2)
	{
		return c1.vec / c2.vec;
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x000094C8 File Offset: 0x000076C8
	public static Vector2 operator /(Vector2 c1, float c2)
	{
		return c1.vec / c2;
	}

	/// <summary>
	/// TODO: Is this useful?
	/// </summary>
	// Token: 0x060001E7 RID: 487 RVA: 0x000094DB File Offset: 0x000076DB
	public static Vector2 FromRadian(float radian)
	{
		return new Vector2(MathF.Cos(radian), MathF.Sin(radian));
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x000094EE File Offset: 0x000076EE
	public readonly float Distance(Vector2 target)
	{
		return Vector2.DistanceBetween(this, target);
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x000094FC File Offset: 0x000076FC
	public static float GetDistance(Vector2 a, Vector2 b)
	{
		return (b - a).Length;
	}

	// Token: 0x060001EA RID: 490 RVA: 0x00009518 File Offset: 0x00007718
	public static float DistanceBetween(Vector2 a, Vector2 b)
	{
		return (b - a).Length;
	}

	// Token: 0x060001EB RID: 491 RVA: 0x00009534 File Offset: 0x00007734
	public static double GetDot(Vector2 a, Vector2 b)
	{
		return (double)(a.x * b.x + a.y * b.y);
	}

	// Token: 0x060001EC RID: 492 RVA: 0x00009556 File Offset: 0x00007756
	public override string ToString()
	{
		return string.Format("{0:0.###},{1:0.###}", this.x, this.y);
	}

	/// <summary>
	/// Given a string, try to convert this into a vector4. The format is "x,y,z,w".
	/// </summary>
	// Token: 0x060001ED RID: 493 RVA: 0x00009578 File Offset: 0x00007778
	public static Vector2 Parse(string str)
	{
		str = str.Trim(new char[] { '[', ']', ' ', '\n', '\r', '\t', '"' });
		string[] p = str.Split(new char[] { ' ', ',', ';', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
		if (p.Length != 2)
		{
			return default(Vector2);
		}
		return new Vector2(p[0].ToFloat(0f), p[1].ToFloat(0f));
	}

	/// <summary>
	/// Snap To Grid along all 3 axes
	/// </summary>
	// Token: 0x060001EE RID: 494 RVA: 0x000095E6 File Offset: 0x000077E6
	public readonly Vector2 SnapToGrid(float gridSize, bool sx = true, bool sy = true)
	{
		return new Vector2(sx ? this.x.SnapToGrid(gridSize) : this.x, sy ? this.y.SnapToGrid(gridSize) : this.y);
	}

	/// <summary>
	/// Return this vector with x
	/// </summary>
	// Token: 0x060001EF RID: 495 RVA: 0x0000961B File Offset: 0x0000781B
	public readonly Vector2 WithX(float x)
	{
		return new Vector2(x, this.y);
	}

	/// <summary>
	/// Return this vector with y
	/// </summary>
	// Token: 0x060001F0 RID: 496 RVA: 0x00009629 File Offset: 0x00007829
	public readonly Vector2 WithY(float y)
	{
		return new Vector2(this.x, y);
	}

	/// <summary>
	/// Linearly interpolate from point a to point b
	/// </summary>
	// Token: 0x060001F1 RID: 497 RVA: 0x00009637 File Offset: 0x00007837
	public static Vector2 Lerp(Vector2 a, Vector2 b, float t, bool clamp = true)
	{
		if (clamp)
		{
			t = t.Clamp(0f, 1f);
		}
		return Vector2.Lerp(a.vec, b.vec, t);
	}

	// Token: 0x17000068 RID: 104
	// (get) Token: 0x060001F2 RID: 498 RVA: 0x00009668 File Offset: 0x00007868
	public static Vector2 Random
	{
		get
		{
			return new Vector2(Rand.Float(-1f, 1f), Rand.Float(-1f, 1f)).Normal * Rand.Float(0f, 1f);
		}
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x000096B4 File Offset: 0x000078B4
	public void Write(BinaryWriter writer)
	{
		writer.Write(this.x);
		writer.Write(this.y);
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x000096D0 File Offset: 0x000078D0
	public static Vector2 Read(BinaryReader reader)
	{
		return new Vector2(reader.ReadSingle(), reader.ReadSingle());
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x000096E3 File Offset: 0x000078E3
	public static bool operator ==(Vector2 left, Vector2 right)
	{
		return left.Equals(right);
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x000096ED File Offset: 0x000078ED
	public static bool operator !=(Vector2 left, Vector2 right)
	{
		return !(left == right);
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x000096FC File Offset: 0x000078FC
	public override bool Equals(object obj)
	{
		if (obj is Vector2)
		{
			Vector2 o = (Vector2)obj;
			return this.Equals(o);
		}
		return false;
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x00009721 File Offset: 0x00007921
	public bool Equals(Vector2 o)
	{
		return this.vec == o.vec;
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x00009734 File Offset: 0x00007934
	public override int GetHashCode()
	{
		return HashCode.Combine<Vector2>(this.vec);
	}

	// Token: 0x04000066 RID: 102
	internal Vector2 vec;

	/// <summary>
	/// Returns a Vector with every component set to 1
	/// </summary>
	// Token: 0x04000067 RID: 103
	public static readonly Vector2 One = new Vector2(1f, 1f);

	/// <summary>
	/// Returns a Vector with every component set to 0
	/// </summary>
	// Token: 0x04000068 RID: 104
	public static readonly Vector2 Zero = new Vector2(0f, 0f);

	// Token: 0x04000069 RID: 105
	public static readonly Vector2 Up = new Vector2(0f, 1f);

	// Token: 0x0400006A RID: 106
	public static readonly Vector2 Down = new Vector2(0f, -1f);

	// Token: 0x0400006B RID: 107
	public static readonly Vector2 Left = new Vector2(1f, 0f);

	// Token: 0x0400006C RID: 108
	public static readonly Vector2 Right = new Vector2(-1f, 0f);
}
