using System;
using System.IO;
using System.Numerics;
using System.Text.Json.Serialization;
using Sandbox;
using Sandbox.Internal.JsonConvert;

// Token: 0x02000026 RID: 38
[JsonConverter(typeof(Vector3Converter))]
public struct Vector3 : IEquatable<Vector3>
{
	// Token: 0x17000069 RID: 105
	// (get) Token: 0x060001FB RID: 507 RVA: 0x000097C9 File Offset: 0x000079C9
	// (set) Token: 0x060001FC RID: 508 RVA: 0x000097D6 File Offset: 0x000079D6
	public float x
	{
		readonly get
		{
			return this._vec.X;
		}
		set
		{
			this._vec.X = value;
		}
	}

	// Token: 0x1700006A RID: 106
	// (get) Token: 0x060001FD RID: 509 RVA: 0x000097E4 File Offset: 0x000079E4
	// (set) Token: 0x060001FE RID: 510 RVA: 0x000097F1 File Offset: 0x000079F1
	public float y
	{
		readonly get
		{
			return this._vec.Y;
		}
		set
		{
			this._vec.Y = value;
		}
	}

	// Token: 0x1700006B RID: 107
	// (get) Token: 0x060001FF RID: 511 RVA: 0x000097FF File Offset: 0x000079FF
	// (set) Token: 0x06000200 RID: 512 RVA: 0x0000980C File Offset: 0x00007A0C
	public float z
	{
		readonly get
		{
			return this._vec.Z;
		}
		set
		{
			this._vec.Z = value;
		}
	}

	/// <summary>
	/// Returns true if x, y or z are NaN
	/// </summary>
	// Token: 0x1700006C RID: 108
	// (get) Token: 0x06000201 RID: 513 RVA: 0x0000981A File Offset: 0x00007A1A
	public readonly bool IsNaN
	{
		get
		{
			return float.IsNaN(this.x) || float.IsNaN(this.y) || float.IsNaN(this.z);
		}
	}

	// Token: 0x06000202 RID: 514 RVA: 0x00009843 File Offset: 0x00007A43
	public Vector3(float x, float y, float z)
	{
		this._vec = new Vector3(x, y, z);
	}

	// Token: 0x06000203 RID: 515 RVA: 0x00009853 File Offset: 0x00007A53
	public Vector3(float x, float y)
	{
		this = new Vector3(x, y, 0f);
	}

	// Token: 0x06000204 RID: 516 RVA: 0x00009862 File Offset: 0x00007A62
	public Vector3(Vector3 other)
	{
		this = new Vector3(other.x, other.y, other.z);
	}

	// Token: 0x06000205 RID: 517 RVA: 0x0000987F File Offset: 0x00007A7F
	public Vector3(Vector2 other, float z)
	{
		this = new Vector3(other.x, other.y, z);
	}

	// Token: 0x06000206 RID: 518 RVA: 0x00009896 File Offset: 0x00007A96
	public Vector3(float all = 0f)
	{
		this = new Vector3(all, all, all);
	}

	/// <summary>
	/// Sort these two vectors into min and max. This doesn't just swap the vectors, it sorts each component.
	/// So that min will come out containing the minimum x, y and z values.
	/// </summary>
	// Token: 0x06000207 RID: 519 RVA: 0x000098A4 File Offset: 0x00007AA4
	public static void Sort(ref Vector3 min, ref Vector3 max)
	{
		Vector3 a = new Vector3(Math.Min(min.x, max.x), Math.Min(min.y, max.y), Math.Min(min.z, max.z));
		Vector3 b = new Vector3(Math.Max(min.x, max.x), Math.Max(min.y, max.y), Math.Max(min.z, max.z));
		min = a;
		max = b;
	}

	/// <summary>
	/// Formats the Vector into a string "x,y,z"
	/// </summary>
	/// <returns></returns>
	// Token: 0x06000208 RID: 520 RVA: 0x00009933 File Offset: 0x00007B33
	public override string ToString()
	{
		return string.Format("{0:0.####},{1:0.####},{2:0.####}", this.x, this.y, this.z);
	}

	/// <summary>
	/// Given a string, try to convert this into a vector. Example input formats that work would be "1,1,1", "1;1;1", "[1 1 1]".
	///
	/// This handles a bunch of different seperators ( ' ', ',', ';', '\n', '\r' ).
	///
	/// It also trims surrounding characters ('[', ']', ' ', '\n', '\r', '\t', '"').
	/// </summary>
	// Token: 0x06000209 RID: 521 RVA: 0x00009960 File Offset: 0x00007B60
	public static Vector3 Parse(string str)
	{
		str = str.Trim(new char[] { '[', ']', ' ', '\n', '\r', '\t', '"' });
		string[] p = str.Split(new char[] { ' ', ',', ';', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
		if (p.Length != 3)
		{
			return Vector3.Zero;
		}
		return new Vector3(p[0].ToFloat(0f), p[1].ToFloat(0f), p[2].ToFloat(0f));
	}

	/// <summary>
	/// Returns true if we're nearly equal to the passed vector.
	/// </summary>
	/// <param name="v">The value to compare with</param>
	/// <param name="delta">The max difference between component values</param>
	/// <returns>True if nearly equal</returns>
	// Token: 0x0600020A RID: 522 RVA: 0x000099D8 File Offset: 0x00007BD8
	public bool IsNearlyEqual(Vector3 v, float delta = 0.0001f)
	{
		return Math.Abs(this.x - v.x) <= delta && Math.Abs(this.y - v.y) <= delta && Math.Abs(this.z - v.z) <= delta;
	}

	// Token: 0x0600020B RID: 523 RVA: 0x00009A2E File Offset: 0x00007C2E
	public static Vector3 operator +(Vector3 c1, Vector3 c2)
	{
		return new Vector3(c1.x + c2.x, c1.y + c2.y, c1.z + c2.z);
	}

	// Token: 0x0600020C RID: 524 RVA: 0x00009A62 File Offset: 0x00007C62
	public static Vector3 operator -(Vector3 c1, Vector3 c2)
	{
		return new Vector3(c1.x - c2.x, c1.y - c2.y, c1.z - c2.z);
	}

	// Token: 0x0600020D RID: 525 RVA: 0x00009A96 File Offset: 0x00007C96
	public static Vector3 operator *(Vector3 c1, float f)
	{
		return new Vector3(c1.x * f, c1.y * f, c1.z * f);
	}

	// Token: 0x0600020E RID: 526 RVA: 0x00009AB8 File Offset: 0x00007CB8
	public static Vector3 operator *(Vector3 c1, Rotation f)
	{
		return Vector3.Transform(c1._vec, f._quat);
	}

	// Token: 0x0600020F RID: 527 RVA: 0x00009AD0 File Offset: 0x00007CD0
	public static Vector3 operator *(Vector3 c1, Vector3 c2)
	{
		return new Vector3(c1.x * c2.x, c1.y * c2.y, c1.z * c2.z);
	}

	// Token: 0x06000210 RID: 528 RVA: 0x00009B04 File Offset: 0x00007D04
	public static Vector3 operator *(float f, Vector3 c1)
	{
		return new Vector3(c1.x * f, c1.y * f, c1.z * f);
	}

	// Token: 0x06000211 RID: 529 RVA: 0x00009B26 File Offset: 0x00007D26
	public static Vector3 operator /(Vector3 c1, float f)
	{
		return new Vector3(c1.x / f, c1.y / f, c1.z / f);
	}

	// Token: 0x06000212 RID: 530 RVA: 0x00009B48 File Offset: 0x00007D48
	public static Vector3 operator -(Vector3 value)
	{
		return new Vector3(-value.x, -value.y, -value.z);
	}

	// Token: 0x06000213 RID: 531 RVA: 0x00009B67 File Offset: 0x00007D67
	public static implicit operator Vector3(Color value)
	{
		return new Vector3(value.r, value.g, value.b);
	}

	// Token: 0x06000214 RID: 532 RVA: 0x00009B80 File Offset: 0x00007D80
	public static implicit operator Vector3(float value)
	{
		return Vector3.One * value;
	}

	// Token: 0x06000215 RID: 533 RVA: 0x00009B8D File Offset: 0x00007D8D
	public static implicit operator Vector3(Vector2 value)
	{
		return new Vector3(value.x, value.y, 0f);
	}

	// Token: 0x06000216 RID: 534 RVA: 0x00009BA8 File Offset: 0x00007DA8
	public static implicit operator Vector3(Vector3 value)
	{
		return new Vector3
		{
			_vec = value
		};
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00009BC6 File Offset: 0x00007DC6
	public static implicit operator Vector3(Vector3 value)
	{
		return new Vector3(value.x, value.y, value.z);
	}

	// Token: 0x06000218 RID: 536 RVA: 0x00009BE2 File Offset: 0x00007DE2
	public readonly float Distance(Vector3 target)
	{
		return Vector3.DistanceBetween(this, target);
	}

	// Token: 0x1700006D RID: 109
	// (get) Token: 0x06000219 RID: 537 RVA: 0x00009BF0 File Offset: 0x00007DF0
	public readonly float Length
	{
		get
		{
			return MathF.Sqrt(this.LengthSquared);
		}
	}

	// Token: 0x1700006E RID: 110
	// (get) Token: 0x0600021A RID: 538 RVA: 0x00009BFD File Offset: 0x00007DFD
	public readonly float LengthSquared
	{
		get
		{
			return this._vec.LengthSquared();
		}
	}

	// Token: 0x1700006F RID: 111
	// (get) Token: 0x0600021B RID: 539 RVA: 0x00009C0A File Offset: 0x00007E0A
	public readonly bool IsNearZeroLength
	{
		get
		{
			return (double)this.LengthSquared <= 1E-08;
		}
	}

	// Token: 0x0600021C RID: 540 RVA: 0x00009C21 File Offset: 0x00007E21
	public Vector3 ClampLength(float maxLength)
	{
		if ((double)this.LengthSquared <= 0.0)
		{
			return Vector3.Zero;
		}
		if (this.LengthSquared < maxLength * maxLength)
		{
			return this;
		}
		return this.Normal * maxLength;
	}

	// Token: 0x0600021D RID: 541 RVA: 0x00009C5C File Offset: 0x00007E5C
	public Vector3 ClampLength(float minLength, float maxLength)
	{
		float minSqr = minLength * minLength;
		float maxSqr = maxLength * maxLength;
		float lenSqr = this.LengthSquared;
		if (lenSqr <= 0f)
		{
			return Vector3.Zero;
		}
		if (lenSqr <= minSqr)
		{
			return this.Normal * minLength;
		}
		if (lenSqr >= maxSqr)
		{
			return this.Normal * maxLength;
		}
		return this;
	}

	// Token: 0x0600021E RID: 542 RVA: 0x00009CAE File Offset: 0x00007EAE
	public readonly Vector3 ComponentMin(Vector3 other)
	{
		return new Vector3(Math.Min(this.x, other.x), Math.Min(this.y, other.y), Math.Min(this.z, other.z));
	}

	// Token: 0x0600021F RID: 543 RVA: 0x00009CEB File Offset: 0x00007EEB
	public readonly Vector3 ComponentMax(Vector3 other)
	{
		return new Vector3(Math.Max(this.x, other.x), Math.Max(this.y, other.y), Math.Max(this.z, other.z));
	}

	// Token: 0x06000220 RID: 544 RVA: 0x00009D28 File Offset: 0x00007F28
	public readonly Vector3 Clamp(Vector3 otherMin, Vector3 otherMax)
	{
		return new Vector3(Math.Clamp(this.x, otherMin.x, otherMax.x), Math.Clamp(this.y, otherMin.y, otherMax.y), Math.Clamp(this.z, otherMin.z, otherMax.z));
	}

	// Token: 0x06000221 RID: 545 RVA: 0x00009D85 File Offset: 0x00007F85
	public readonly Vector3 Clamp(float min, float max)
	{
		return this.Clamp(new Vector3(min), new Vector3(max));
	}

	// Token: 0x06000222 RID: 546 RVA: 0x00009D99 File Offset: 0x00007F99
	public static Vector3 Min(Vector3 a, Vector3 b)
	{
		return a.ComponentMin(b);
	}

	// Token: 0x06000223 RID: 547 RVA: 0x00009DA3 File Offset: 0x00007FA3
	public static Vector3 Max(Vector3 a, Vector3 b)
	{
		return a.ComponentMax(b);
	}

	// Token: 0x17000070 RID: 112
	// (get) Token: 0x06000224 RID: 548 RVA: 0x00009DAD File Offset: 0x00007FAD
	public readonly Vector3 Normal
	{
		get
		{
			if (this.IsNearZeroLength)
			{
				return this;
			}
			return Vector3.Normalize(this._vec);
		}
	}

	// Token: 0x06000225 RID: 549 RVA: 0x00009DCE File Offset: 0x00007FCE
	public readonly Vector3 LerpTo(Vector3 target, float t)
	{
		return Vector3.Lerp(this, target, t, true);
	}

	// Token: 0x06000226 RID: 550 RVA: 0x00009DDE File Offset: 0x00007FDE
	public readonly Vector3 Approach(float length, float amount)
	{
		return this.Normal * this.Length.Approach(length, amount);
	}

	// Token: 0x06000227 RID: 551 RVA: 0x00009DF8 File Offset: 0x00007FF8
	public readonly Vector3 WithX(float x)
	{
		return new Vector3(x, this.y, this.z);
	}

	// Token: 0x06000228 RID: 552 RVA: 0x00009E0C File Offset: 0x0000800C
	public readonly Vector3 WithY(float y)
	{
		return new Vector3(this.x, y, this.z);
	}

	// Token: 0x06000229 RID: 553 RVA: 0x00009E20 File Offset: 0x00008020
	public readonly Vector3 WithZ(float z)
	{
		return new Vector3(this.x, this.y, z);
	}

	// Token: 0x0600022A RID: 554 RVA: 0x00009E34 File Offset: 0x00008034
	public static Vector3 Cross(Vector3 a, Vector3 b)
	{
		return new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
	}

	// Token: 0x0600022B RID: 555 RVA: 0x00009EA4 File Offset: 0x000080A4
	public readonly Vector3 Cross(Vector3 b)
	{
		return new Vector3(this.y * b.z - this.z * b.y, this.z * b.x - this.x * b.z, this.x * b.y - this.y * b.x);
	}

	// Token: 0x0600022C RID: 556 RVA: 0x00009F0D File Offset: 0x0000810D
	public static float Dot(Vector3 a, Vector3 b)
	{
		return Vector3.Dot(a._vec, b._vec);
	}

	// Token: 0x0600022D RID: 557 RVA: 0x00009F20 File Offset: 0x00008120
	public readonly float Dot(Vector3 b)
	{
		return Vector3.Dot(this, b);
	}

	// Token: 0x0600022E RID: 558 RVA: 0x00009F2E File Offset: 0x0000812E
	public readonly Vector3 Abs()
	{
		return new Vector3(Math.Abs(this.x), Math.Abs(this.y), Math.Abs(this.z));
	}

	// Token: 0x0600022F RID: 559 RVA: 0x00009F56 File Offset: 0x00008156
	public static Vector3 Lerp(Vector3 a, Vector3 b, float t, bool clamp = true)
	{
		if (clamp)
		{
			t = t.Clamp(0f, 1f);
		}
		return Vector3.Lerp(a._vec, b._vec, t);
	}

	// Token: 0x06000230 RID: 560 RVA: 0x00009F84 File Offset: 0x00008184
	public static float DistanceBetween(Vector3 a, Vector3 b)
	{
		return (b - a).Length;
	}

	// Token: 0x06000231 RID: 561 RVA: 0x00009FA0 File Offset: 0x000081A0
	public static Vector3 Reflect(Vector3 direction, Vector3 normal)
	{
		return direction - 2f * Vector3.Dot(direction, normal) * normal;
	}

	// Token: 0x06000232 RID: 562 RVA: 0x00009FBB File Offset: 0x000081BB
	public static Vector3 VectorPlaneProject(Vector3 v, Vector3 planeNormal)
	{
		return v - v.ProjectOnNormal(planeNormal);
	}

	// Token: 0x06000233 RID: 563 RVA: 0x00009FCB File Offset: 0x000081CB
	public readonly Vector3 ProjectOnNormal(Vector3 normal)
	{
		return normal * Vector3.Dot(this, normal);
	}

	/// <summary>
	/// Given a vector like 1,1,1 and direction 1,0,0, will return 0,1,1.
	/// This is useful for velocity collision type events, where you want to
	/// cancel out velocity based on a normal.
	/// For this to work properly, direction should be a normal, but you can scale
	/// how much you want to sutract by scaling the direction. Ie, passing in a direction
	/// with a length of 0.5 will remove half the direction.
	/// </summary>
	// Token: 0x06000234 RID: 564 RVA: 0x00009FDF File Offset: 0x000081DF
	public Vector3 SubtractDirection(Vector3 direction, float strength = 1f)
	{
		return this - direction * this.Dot(direction) * strength;
	}

	/// <summary>
	/// Returns a new vector with each component randomized between -1 and 1.
	/// </summary>
	// Token: 0x17000071 RID: 113
	// (get) Token: 0x06000235 RID: 565 RVA: 0x0000A000 File Offset: 0x00008200
	public static Vector3 Random
	{
		get
		{
			return new Vector3(Rand.Float(-1f, 1f), Rand.Float(-1f, 1f), Rand.Float(-1f, 1f)).Normal * Rand.Float(0f, 1f);
		}
	}

	// Token: 0x06000236 RID: 566 RVA: 0x0000A05B File Offset: 0x0000825B
	public static implicit operator Vector3(Vector4 vec)
	{
		return new Vector3(vec.x, vec.y, vec.z);
	}

	/// <summary>
	/// Return true if less than tolerance away from zero
	/// </summary>
	// Token: 0x06000237 RID: 567 RVA: 0x0000A07A File Offset: 0x0000827A
	public readonly bool IsNearlyZero(float tolerance = 1E-45f)
	{
		return MathF.Abs(this.x) <= tolerance && MathF.Abs(this.y) <= tolerance && MathF.Abs(this.z) <= tolerance;
	}

	/// <summary>
	/// Snap To Grid along all 3 axes
	/// </summary>
	// Token: 0x06000238 RID: 568 RVA: 0x0000A0AC File Offset: 0x000082AC
	public readonly Vector3 SnapToGrid(float gridSize, bool sx = true, bool sy = true, bool sz = true)
	{
		return new Vector3(sx ? this.x.SnapToGrid(gridSize) : this.x, sy ? this.y.SnapToGrid(gridSize) : this.y, sz ? this.z.SnapToGrid(gridSize) : this.z);
	}

	/// <summary>
	/// Return the distance between the two direction vectors in degrees
	/// </summary>
	// Token: 0x06000239 RID: 569 RVA: 0x0000A104 File Offset: 0x00008304
	public static float GetAngle(Vector3 v1, Vector3 v2)
	{
		return MathF.Acos(Vector3.Dot(v1.Normal, v2.Normal).Clamp(-1f, 1f)).RadianToDegree();
	}

	/// <summary>
	/// Return the distance between the two direction vectors in degrees
	/// </summary>
	// Token: 0x0600023A RID: 570 RVA: 0x0000A132 File Offset: 0x00008332
	public readonly float Angle(Vector3 v2)
	{
		return Vector3.GetAngle(this, v2);
	}

	// Token: 0x0600023B RID: 571 RVA: 0x0000A140 File Offset: 0x00008340
	public void Write(BinaryWriter writer)
	{
		writer.Write(this.x);
		writer.Write(this.y);
		writer.Write(this.z);
	}

	// Token: 0x0600023C RID: 572 RVA: 0x0000A169 File Offset: 0x00008369
	public static Vector3 Read(BinaryReader reader)
	{
		return new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
	}

	/// <summary>
	/// The euler angle of this vector
	/// </summary>
	// Token: 0x17000072 RID: 114
	// (get) Token: 0x0600023D RID: 573 RVA: 0x0000A182 File Offset: 0x00008382
	// (set) Token: 0x0600023E RID: 574 RVA: 0x0000A18F File Offset: 0x0000838F
	public Angles EulerAngles
	{
		readonly get
		{
			return Vector3.VectorAngle(this);
		}
		set
		{
			this = Angles.AngleVector(value);
		}
	}

	/// <summary>
	/// Converts a vector to an angle
	/// </summary>
	// Token: 0x0600023F RID: 575 RVA: 0x0000A1A0 File Offset: 0x000083A0
	public static Angles VectorAngle(Vector3 vec)
	{
		float yaw;
		float pitch;
		if (vec.y == 0f && vec.x == 0f)
		{
			yaw = 0f;
			pitch = ((vec.z > 0f) ? 270f : 90f);
		}
		else
		{
			yaw = (float)(Math.Atan2((double)vec.y, (double)vec.x) * 180.0 / 3.141592653589793);
			if (yaw < 0f)
			{
				yaw += 360f;
			}
			float tmp = (float)Math.Sqrt((double)(vec.x * vec.x + vec.y * vec.y));
			pitch = (float)(Math.Atan2((double)(-(double)vec.z), (double)tmp) * 180.0 / 3.141592653589793);
			if (pitch < 0f)
			{
				pitch += 360f;
			}
		}
		return new Angles(pitch, yaw, 0f);
	}

	/// <summary>
	/// Try to add to this vector. If we're already over max then don't add.
	/// If we're over max when we add, clamp in that direction so we're not.
	/// </summary>
	// Token: 0x06000240 RID: 576 RVA: 0x0000A294 File Offset: 0x00008494
	public readonly Vector3 AddClamped(Vector3 toAdd, float maxLength)
	{
		Vector3 dir = toAdd.Normal;
		float dot = this.Dot(dir);
		if (dot > maxLength)
		{
			return this;
		}
		Vector3 vec = this + toAdd;
		dot = vec.Dot(dir);
		if (dot < maxLength)
		{
			return vec;
		}
		return vec - dir * (dot - maxLength);
	}

	// Token: 0x17000073 RID: 115
	public float this[int index]
	{
		get
		{
			float result;
			switch (index)
			{
			case 0:
				result = this.x;
				break;
			case 1:
				result = this.y;
				break;
			case 2:
				result = this.z;
				break;
			default:
				throw new IndexOutOfRangeException();
			}
			return result;
		}
		set
		{
			switch (index)
			{
			case 0:
				this.x = value;
				return;
			case 1:
				this.y = value;
				return;
			case 2:
				this.z = value;
				return;
			default:
				return;
			}
		}
	}

	// Token: 0x06000243 RID: 579 RVA: 0x0000A35B File Offset: 0x0000855B
	public static bool operator ==(Vector3 left, Vector3 right)
	{
		return left.Equals(right);
	}

	// Token: 0x06000244 RID: 580 RVA: 0x0000A365 File Offset: 0x00008565
	public static bool operator !=(Vector3 left, Vector3 right)
	{
		return !(left == right);
	}

	// Token: 0x06000245 RID: 581 RVA: 0x0000A374 File Offset: 0x00008574
	public override bool Equals(object obj)
	{
		if (obj is Vector3)
		{
			Vector3 o = (Vector3)obj;
			return this.Equals(o);
		}
		return false;
	}

	// Token: 0x06000246 RID: 582 RVA: 0x0000A399 File Offset: 0x00008599
	public bool Equals(Vector3 o)
	{
		return this.IsNearlyEqual(o, 0.0001f);
	}

	// Token: 0x06000247 RID: 583 RVA: 0x0000A3A7 File Offset: 0x000085A7
	public override int GetHashCode()
	{
		return HashCode.Combine<Vector3>(this._vec);
	}

	// Token: 0x0400006D RID: 109
	internal Vector3 _vec;

	// Token: 0x0400006E RID: 110
	public static readonly Vector3 One = new Vector3(1f);

	// Token: 0x0400006F RID: 111
	public static readonly Vector3 Zero = new Vector3(0f);

	// Token: 0x04000070 RID: 112
	public static readonly Vector3 Forward = new Vector3(1f, 0f, 0f);

	// Token: 0x04000071 RID: 113
	public static readonly Vector3 Backward = new Vector3(-1f, 0f, 0f);

	// Token: 0x04000072 RID: 114
	public static readonly Vector3 Up = new Vector3(0f, 0f, 1f);

	// Token: 0x04000073 RID: 115
	public static readonly Vector3 Down = new Vector3(0f, 0f, -1f);

	// Token: 0x04000074 RID: 116
	public static readonly Vector3 Right = new Vector3(0f, -1f, 0f);

	// Token: 0x04000075 RID: 117
	public static readonly Vector3 Left = new Vector3(0f, 1f, 0f);

	// Token: 0x04000076 RID: 118
	public static readonly Vector3 OneX = new Vector3(1f, 0f, 0f);

	// Token: 0x04000077 RID: 119
	public static readonly Vector3 OneY = new Vector3(0f, 1f, 0f);

	// Token: 0x04000078 RID: 120
	public static readonly Vector3 OneZ = new Vector3(0f, 0f, 1f);
}
