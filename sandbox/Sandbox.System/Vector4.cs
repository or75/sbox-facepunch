using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Sandbox;
using Sandbox.Internal.JsonConvert;

// Token: 0x02000027 RID: 39
[DataContract]
[JsonConverter(typeof(Vector4Converter))]
[StructLayout(LayoutKind.Explicit, Pack = 16, Size = 16)]
public struct Vector4 : IEquatable<Vector4>
{
	// Token: 0x17000074 RID: 116
	// (get) Token: 0x06000249 RID: 585 RVA: 0x0000A4C0 File Offset: 0x000086C0
	// (set) Token: 0x0600024A RID: 586 RVA: 0x0000A4C8 File Offset: 0x000086C8
	[DataMember]
	public float x
	{
		get
		{
			return this._x;
		}
		set
		{
			this._x = value;
		}
	}

	// Token: 0x17000075 RID: 117
	// (get) Token: 0x0600024B RID: 587 RVA: 0x0000A4D1 File Offset: 0x000086D1
	// (set) Token: 0x0600024C RID: 588 RVA: 0x0000A4D9 File Offset: 0x000086D9
	[DataMember]
	public float y
	{
		get
		{
			return this._y;
		}
		set
		{
			this._y = value;
		}
	}

	// Token: 0x17000076 RID: 118
	// (get) Token: 0x0600024D RID: 589 RVA: 0x0000A4E2 File Offset: 0x000086E2
	// (set) Token: 0x0600024E RID: 590 RVA: 0x0000A4EA File Offset: 0x000086EA
	[DataMember]
	public float z
	{
		get
		{
			return this._z;
		}
		set
		{
			this._z = value;
		}
	}

	// Token: 0x17000077 RID: 119
	// (get) Token: 0x0600024F RID: 591 RVA: 0x0000A4F3 File Offset: 0x000086F3
	// (set) Token: 0x06000250 RID: 592 RVA: 0x0000A4FB File Offset: 0x000086FB
	[DataMember]
	public float w
	{
		get
		{
			return this._w;
		}
		set
		{
			this._w = value;
		}
	}

	// Token: 0x06000251 RID: 593 RVA: 0x0000A504 File Offset: 0x00008704
	public Vector4(float x, float y, float z, float w)
	{
		this._x = x;
		this._y = y;
		this._z = z;
		this._w = w;
	}

	// Token: 0x06000252 RID: 594 RVA: 0x0000A523 File Offset: 0x00008723
	public Vector4(in Vector3 v, float w = 0f)
	{
		this._x = v.x;
		this._y = v.y;
		this._z = v.z;
		this._w = w;
	}

	// Token: 0x06000253 RID: 595 RVA: 0x0000A550 File Offset: 0x00008750
	public Vector4(float value)
	{
		this._x = value;
		this._y = value;
		this._z = value;
		this._w = value;
	}

	// Token: 0x06000254 RID: 596 RVA: 0x0000A56E File Offset: 0x0000876E
	public bool Equals(Vector4 other)
	{
		return other._x == this._x && other._y == this._y && other._z == this._z && other._w == this._w;
	}

	// Token: 0x06000255 RID: 597 RVA: 0x0000A5AA File Offset: 0x000087AA
	public static implicit operator Vector4(in Color value)
	{
		return new Vector4(value.r, value.g, value.b, value.a);
	}

	/// <summary>
	/// Formats the Vector into a string "x,y,z,w"
	/// </summary>
	/// <returns></returns>
	// Token: 0x06000256 RID: 598 RVA: 0x0000A5CC File Offset: 0x000087CC
	public override string ToString()
	{
		return string.Format("{0:0.###},{1:0.###},{2:0.###},{3:0.###}", new object[] { this.x, this.y, this.z, this.w });
	}

	/// <summary>
	/// Given a string, try to convert this into a vector4. The format is "x,y,z,w".
	/// </summary>
	// Token: 0x06000257 RID: 599 RVA: 0x0000A624 File Offset: 0x00008824
	public static Vector4 Parse(string str)
	{
		str = str.Trim(new char[] { '[', ']', ' ', '\n', '\r', '\t', '"' });
		string[] p = str.Split(new char[] { ' ', ',', ';', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
		if (p.Length != 4)
		{
			return default(Vector4);
		}
		return new Vector4(p[0].ToFloat(0f), p[1].ToFloat(0f), p[2].ToFloat(0f), p[3].ToFloat(0f));
	}

	// Token: 0x06000258 RID: 600 RVA: 0x0000A6AC File Offset: 0x000088AC
	public static Vector4 Lerp(Vector4 a, Vector4 b, float t, bool clamp = true)
	{
		if (clamp)
		{
			t = t.Clamp(0f, 1f);
		}
		return new Vector4(a.x.LerpTo(b.x, t, true), a.y.LerpTo(b.y, t, true), a.z.LerpTo(b.z, t, true), a.w.LerpTo(b.w, t, true));
	}

	// Token: 0x06000259 RID: 601 RVA: 0x0000A727 File Offset: 0x00008927
	public readonly Vector4 LerpTo(Vector4 target, float t)
	{
		return Vector4.Lerp(this, target, t, true);
	}

	// Token: 0x0600025A RID: 602 RVA: 0x0000A738 File Offset: 0x00008938
	public static Vector4 operator +(in Vector4 c1, in Vector4 c2)
	{
		Vector4 vector = c1;
		float x = vector.x;
		vector = c2;
		float x2 = x + vector.x;
		vector = c1;
		float y = vector.y;
		vector = c2;
		float y2 = y + vector.y;
		vector = c1;
		float z = vector.z;
		vector = c2;
		float z2 = z + vector.z;
		vector = c1;
		float w = vector.w;
		vector = c2;
		return new Vector4(x2, y2, z2, w + vector.w);
	}

	// Token: 0x0600025B RID: 603 RVA: 0x0000A7C0 File Offset: 0x000089C0
	public static Vector4 operator -(in Vector4 c1, in Vector4 c2)
	{
		Vector4 vector = c1;
		float x = vector.x;
		vector = c2;
		float x2 = x - vector.x;
		vector = c1;
		float y = vector.y;
		vector = c2;
		float y2 = y - vector.y;
		vector = c1;
		float z = vector.z;
		vector = c2;
		float z2 = z - vector.z;
		vector = c1;
		float w = vector.w;
		vector = c2;
		return new Vector4(x2, y2, z2, w - vector.w);
	}

	// Token: 0x0600025C RID: 604 RVA: 0x0000A848 File Offset: 0x00008A48
	public static Vector4 operator *(in Vector4 c1, float f)
	{
		Vector4 vector = c1;
		float x = vector.x * f;
		vector = c1;
		float y = vector.y * f;
		vector = c1;
		float z = vector.z * f;
		vector = c1;
		return new Vector4(x, y, z, vector.w * f);
	}

	// Token: 0x0600025D RID: 605 RVA: 0x0000A89C File Offset: 0x00008A9C
	public static Vector4 operator *(in Vector4 c1, in Vector4 c2)
	{
		Vector4 vector = c1;
		float x = vector.x;
		vector = c2;
		float x2 = x * vector.x;
		vector = c1;
		float y = vector.y;
		vector = c2;
		float y2 = y * vector.y;
		vector = c1;
		float z = vector.z;
		vector = c2;
		float z2 = z * vector.z;
		vector = c1;
		float w = vector.w;
		vector = c2;
		return new Vector4(x2, y2, z2, w * vector.w);
	}

	// Token: 0x0600025E RID: 606 RVA: 0x0000A924 File Offset: 0x00008B24
	public static Vector4 operator *(float f, in Vector4 c1)
	{
		Vector4 vector = c1;
		float x = vector.x * f;
		vector = c1;
		float y = vector.y * f;
		vector = c1;
		float z = vector.z * f;
		vector = c1;
		return new Vector4(x, y, z, vector.w * f);
	}

	// Token: 0x0600025F RID: 607 RVA: 0x0000A978 File Offset: 0x00008B78
	public static Vector4 operator /(in Vector4 c1, float f)
	{
		Vector4 vector = c1;
		float x = vector.x / f;
		vector = c1;
		float y = vector.y / f;
		vector = c1;
		float z = vector.z / f;
		vector = c1;
		return new Vector4(x, y, z, vector.w / f);
	}

	// Token: 0x06000260 RID: 608 RVA: 0x0000A9CC File Offset: 0x00008BCC
	public static Vector4 operator -(in Vector4 value)
	{
		Vector4 vector = value;
		float x = -vector.x;
		vector = value;
		float y = -vector.y;
		vector = value;
		float z = -vector.z;
		vector = value;
		return new Vector4(x, y, z, -vector.w);
	}

	// Token: 0x06000261 RID: 609 RVA: 0x0000AA1A File Offset: 0x00008C1A
	public static implicit operator Vector4(Vector4 value)
	{
		return new Vector4(value.X, value.Y, value.Z, value.W);
	}

	// Token: 0x06000262 RID: 610 RVA: 0x0000AA39 File Offset: 0x00008C39
	public static implicit operator Vector4(Vector4 value)
	{
		return new Vector4(value.x, value.y, value.z, value.w);
	}

	// Token: 0x04000079 RID: 121
	public static readonly Vector4 Zero = new Vector4(0f);

	// Token: 0x0400007A RID: 122
	public static readonly Vector4 One = new Vector4(1f);

	// Token: 0x0400007B RID: 123
	[FieldOffset(0)]
	internal float _x;

	// Token: 0x0400007C RID: 124
	[FieldOffset(4)]
	internal float _y;

	// Token: 0x0400007D RID: 125
	[FieldOffset(8)]
	internal float _z;

	// Token: 0x0400007E RID: 126
	[FieldOffset(12)]
	internal float _w;
}
