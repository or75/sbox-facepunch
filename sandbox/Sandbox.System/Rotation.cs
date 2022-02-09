using System;
using System.IO;
using System.Numerics;
using System.Text.Json.Serialization;
using Sandbox;
using Sandbox.Internal.JsonConvert;

/// <summary>
/// Represents a Quaternion rotation.
/// </summary>
// Token: 0x02000022 RID: 34
[JsonConverter(typeof(RotationConverter))]
public struct Rotation : IEquatable<Rotation>
{
	// Token: 0x17000052 RID: 82
	// (get) Token: 0x0600017A RID: 378 RVA: 0x00008322 File Offset: 0x00006522
	// (set) Token: 0x0600017B RID: 379 RVA: 0x0000832F File Offset: 0x0000652F
	public float x
	{
		get
		{
			return this._quat.X;
		}
		set
		{
			this._quat.X = value;
		}
	}

	// Token: 0x17000053 RID: 83
	// (get) Token: 0x0600017C RID: 380 RVA: 0x0000833D File Offset: 0x0000653D
	// (set) Token: 0x0600017D RID: 381 RVA: 0x0000834A File Offset: 0x0000654A
	public float y
	{
		get
		{
			return this._quat.Y;
		}
		set
		{
			this._quat.Y = value;
		}
	}

	// Token: 0x17000054 RID: 84
	// (get) Token: 0x0600017E RID: 382 RVA: 0x00008358 File Offset: 0x00006558
	// (set) Token: 0x0600017F RID: 383 RVA: 0x00008365 File Offset: 0x00006565
	public float z
	{
		get
		{
			return this._quat.Z;
		}
		set
		{
			this._quat.Z = value;
		}
	}

	// Token: 0x17000055 RID: 85
	// (get) Token: 0x06000180 RID: 384 RVA: 0x00008373 File Offset: 0x00006573
	// (set) Token: 0x06000181 RID: 385 RVA: 0x00008380 File Offset: 0x00006580
	public float w
	{
		get
		{
			return this._quat.W;
		}
		set
		{
			this._quat.W = value;
		}
	}

	// Token: 0x06000182 RID: 386 RVA: 0x00008390 File Offset: 0x00006590
	public override string ToString()
	{
		return string.Format("{0:0.#####},{1:0.#####},{2:0.#####},{3:0.#####}", new object[] { this.x, this.y, this.z, this.w });
	}

	/// <summary>
	/// Returns the inverse of this rotation
	/// </summary>
	// Token: 0x17000056 RID: 86
	// (get) Token: 0x06000183 RID: 387 RVA: 0x000083E5 File Offset: 0x000065E5
	public Rotation Inverse
	{
		get
		{
			return Quaternion.Inverse(this._quat);
		}
	}

	// Token: 0x17000057 RID: 87
	// (get) Token: 0x06000184 RID: 388 RVA: 0x000083F7 File Offset: 0x000065F7
	public Rotation Normal
	{
		get
		{
			return Quaternion.Normalize(this._quat);
		}
	}

	// Token: 0x17000058 RID: 88
	// (get) Token: 0x06000185 RID: 389 RVA: 0x00008409 File Offset: 0x00006609
	public Rotation Conjugate
	{
		get
		{
			return Quaternion.Conjugate(this._quat);
		}
	}

	/// <summary>
	/// Create from angle and an axis
	/// </summary>
	// Token: 0x06000186 RID: 390 RVA: 0x0000841B File Offset: 0x0000661B
	public static Rotation FromAxis(Vector3 axis, float degrees)
	{
		return Quaternion.CreateFromAxisAngle(axis, degrees.DegreeToRadian());
	}

	/// <summary>
	/// Create a Rotation (quaternion) from Angles
	/// </summary>
	// Token: 0x06000187 RID: 391 RVA: 0x00008433 File Offset: 0x00006633
	public static Rotation From(Angles angles)
	{
		return Rotation.From(angles.pitch, angles.yaw, angles.roll);
	}

	/// <summary>
	/// Create a Rotation (quaternion) from pitch yaw roll (degrees)
	/// </summary>
	// Token: 0x06000188 RID: 392 RVA: 0x0000844C File Offset: 0x0000664C
	public static Rotation From(float pitch, float yaw, float roll)
	{
		Rotation rot = default(Rotation);
		pitch = pitch.DegreeToRadian() * 0.5f;
		yaw = yaw.DegreeToRadian() * 0.5f;
		roll = roll.DegreeToRadian() * 0.5f;
		float sp = MathF.Sin(pitch);
		float cp = MathF.Cos(pitch);
		float sy = MathF.Sin(yaw);
		float cy = MathF.Cos(yaw);
		float num = MathF.Sin(roll);
		float cr = MathF.Cos(roll);
		float srXcp = num * cp;
		float crXsp = cr * sp;
		rot.x = srXcp * cy - crXsp * sy;
		rot.y = crXsp * cy + srXcp * sy;
		float crXcp = cr * cp;
		float srXsp = num * sp;
		rot.z = crXcp * sy - srXsp * cy;
		rot.w = crXcp * cy + srXsp * sy;
		return rot;
	}

	/// <summary>
	/// Create a Rotation (quaternion) from pitch (degrees)
	/// </summary>
	// Token: 0x06000189 RID: 393 RVA: 0x00008510 File Offset: 0x00006710
	public static Rotation FromPitch(float pitch)
	{
		return Rotation.From(pitch, 0f, 0f);
	}

	/// <summary>
	/// Create a Rotation (quaternion) from yaw (degrees)
	/// </summary>
	// Token: 0x0600018A RID: 394 RVA: 0x00008522 File Offset: 0x00006722
	public static Rotation FromYaw(float yaw)
	{
		return Rotation.From(0f, yaw, 0f);
	}

	/// <summary>
	/// Create a Rotation (quaternion) from roll (degrees)
	/// </summary>
	// Token: 0x0600018B RID: 395 RVA: 0x00008534 File Offset: 0x00006734
	public static Rotation FromRoll(float roll)
	{
		return Rotation.From(0f, 0f, roll);
	}

	/// <summary>
	/// Create a Rotation (quaternion) from a forward and up vector
	/// </summary>
	// Token: 0x0600018C RID: 396 RVA: 0x00008548 File Offset: 0x00006748
	public static Rotation LookAt(Vector3 forward, Vector3 up)
	{
		forward = forward.Normal;
		up = up.Normal;
		float flRatio = forward.Dot(up);
		up = (up - forward * flRatio).Normal;
		Vector3 normal = forward.Cross(up).Normal;
		Vector3 vX = forward;
		Vector3 vY = -normal;
		Vector3 vZ = up;
		float flTrace = vX.x + vY.y + vZ.z;
		Quaternion q;
		if (flTrace >= 0f)
		{
			q.X = vY.z - vZ.y;
			q.Y = vZ.x - vX.z;
			q.Z = vX.y - vY.x;
			q.W = flTrace + 1f;
		}
		else if (vX.x > vY.y && vX.x > vZ.z)
		{
			q.X = vX.x - vY.y - vZ.z + 1f;
			q.Y = vY.x + vX.y;
			q.Z = vZ.x + vX.z;
			q.W = vY.z - vZ.y;
		}
		else if (vY.y > vZ.z)
		{
			q.X = vX.y + vY.x;
			q.Y = vY.y - vZ.z - vX.x + 1f;
			q.Z = vZ.y + vY.z;
			q.W = vZ.x - vX.z;
		}
		else
		{
			q.X = vX.z + vZ.x;
			q.Y = vY.z + vZ.y;
			q.Z = vZ.z - vX.x - vY.y + 1f;
			q.W = vX.y - vY.x;
		}
		return Quaternion.Normalize(q);
	}

	/// <summary>
	/// Create a Rotation (quaternion) from a forward and up vector
	/// </summary>
	// Token: 0x0600018D RID: 397 RVA: 0x00008790 File Offset: 0x00006990
	public static Rotation LookAt(Vector3 forward)
	{
		if (forward.y == 0f && forward.z == 0f)
		{
			return Rotation.LookAt(forward, Vector3.Left);
		}
		return Rotation.LookAt(forward, Vector3.Up);
	}

	// Token: 0x0600018E RID: 398 RVA: 0x000087C8 File Offset: 0x000069C8
	public static implicit operator Rotation(Quaternion value)
	{
		return new Rotation
		{
			_quat = value
		};
	}

	/// <summary>
	/// Returns the difference between two rotations, as a rotation
	/// </summary>
	// Token: 0x0600018F RID: 399 RVA: 0x000087E8 File Offset: 0x000069E8
	public static Rotation Difference(Rotation from, Rotation to)
	{
		Quaternion fromInv = Quaternion.Conjugate(from._quat);
		return Quaternion.Normalize(Quaternion.Multiply(to._quat, fromInv));
	}

	/// <summary>
	/// The degree angular distance between this rotation and the target
	/// </summary>
	// Token: 0x06000190 RID: 400 RVA: 0x00008818 File Offset: 0x00006A18
	public float Distance(Rotation to)
	{
		return Rotation.Difference(this, to).Angle();
	}

	/// <summary>
	///  Returns the turn length of this rotation (from identity) in degrees
	/// </summary>
	// Token: 0x06000191 RID: 401 RVA: 0x0000883C File Offset: 0x00006A3C
	public float Angle()
	{
		float d = MathF.Acos(this.w.Clamp(-1f, 1f)).RadianToDegree() * 2f;
		if (d > 180f)
		{
			d -= 360f;
		}
		return MathF.Abs(d);
	}

	/// <summary>
	/// Return this Rotation as pitch, yaw, roll angles
	/// </summary>
	// Token: 0x06000192 RID: 402 RVA: 0x00008888 File Offset: 0x00006A88
	public Angles Angles()
	{
		float m11 = 2f * this.w * this.w + 2f * this.x * this.x - 1f;
		float m12 = 2f * this.x * this.y + 2f * this.w * this.z;
		float m13 = 2f * this.x * this.z - 2f * this.w * this.y;
		float m14 = 2f * this.y * this.z + 2f * this.w * this.x;
		float m15 = 2f * this.w * this.w + 2f * this.z * this.z - 1f;
		Angles a;
		a.yaw = MathF.Atan2(m12, m11).RadianToDegree();
		a.pitch = MathF.Asin(-m13).RadianToDegree();
		a.roll = MathF.Atan2(m14, m15).RadianToDegree();
		return a;
	}

	/// <summary>
	/// Return this Rotation pitch
	/// </summary>
	// Token: 0x06000193 RID: 403 RVA: 0x000089A6 File Offset: 0x00006BA6
	public float Pitch()
	{
		return MathF.Asin(-(2f * this.x * this.z - 2f * this.w * this.y)).RadianToDegree();
	}

	/// <summary>
	/// Return this Rotation yaw
	/// </summary>
	// Token: 0x06000194 RID: 404 RVA: 0x000089DC File Offset: 0x00006BDC
	public float Yaw()
	{
		float m11 = 2f * this.w * this.w + 2f * this.x * this.x - 1f;
		return MathF.Atan2(2f * this.x * this.y + 2f * this.w * this.z, m11).RadianToDegree();
	}

	/// <summary>
	/// Return this Rotation roll
	/// </summary>
	// Token: 0x06000195 RID: 405 RVA: 0x00008A4C File Offset: 0x00006C4C
	public float Roll()
	{
		float y = 2f * this.y * this.z + 2f * this.w * this.x;
		float m33 = 2f * this.w * this.w + 2f * this.z * this.z - 1f;
		return MathF.Atan2(y, m33).RadianToDegree();
	}

	/// <summary>
	/// Lerp from a to b by amount
	/// </summary>
	// Token: 0x06000196 RID: 406 RVA: 0x00008AB9 File Offset: 0x00006CB9
	public static Rotation Lerp(Rotation a, Rotation b, float amount, bool clamp = true)
	{
		if (clamp)
		{
			amount = amount.Clamp(0f, 1f);
		}
		return Quaternion.Lerp(a._quat, b._quat, amount);
	}

	/// <summary>
	/// Slerp from a to b by amount
	/// </summary>
	// Token: 0x06000197 RID: 407 RVA: 0x00008AE7 File Offset: 0x00006CE7
	public static Rotation Slerp(Rotation a, Rotation b, float amount, bool clamp = true)
	{
		if (clamp)
		{
			amount = amount.Clamp(0f, 1f);
		}
		return Quaternion.Slerp(a._quat, b._quat, amount);
	}

	/// <summary>
	/// Clamp to within degrees of passed rotation
	/// </summary>
	// Token: 0x06000198 RID: 408 RVA: 0x00008B18 File Offset: 0x00006D18
	public Rotation Clamp(Rotation to, float degrees)
	{
		float num;
		return this.Clamp(to, degrees, out num);
	}

	/// <summary>
	/// Clamp to within degrees of passed rotation. Also pases out the change in degrees, if any.
	/// </summary>
	// Token: 0x06000199 RID: 409 RVA: 0x00008B30 File Offset: 0x00006D30
	public Rotation Clamp(Rotation to, float degrees, out float change)
	{
		change = 0f;
		if (degrees <= 0f)
		{
			return to;
		}
		float d = Rotation.Difference(this, to).Angle();
		if (d <= degrees)
		{
			return this;
		}
		change = d - degrees;
		float amount = degrees / d;
		return Rotation.Slerp(this, to, 1f - amount, true);
	}

	// Token: 0x17000059 RID: 89
	// (get) Token: 0x0600019A RID: 410 RVA: 0x00008B8B File Offset: 0x00006D8B
	public Vector3 Forward
	{
		get
		{
			return Vector3.Forward * this;
		}
	}

	// Token: 0x1700005A RID: 90
	// (get) Token: 0x0600019B RID: 411 RVA: 0x00008B9D File Offset: 0x00006D9D
	public Vector3 Backward
	{
		get
		{
			return Vector3.Backward * this;
		}
	}

	// Token: 0x1700005B RID: 91
	// (get) Token: 0x0600019C RID: 412 RVA: 0x00008BAF File Offset: 0x00006DAF
	public Vector3 Right
	{
		get
		{
			return Vector3.Right * this;
		}
	}

	// Token: 0x1700005C RID: 92
	// (get) Token: 0x0600019D RID: 413 RVA: 0x00008BC1 File Offset: 0x00006DC1
	public Vector3 Left
	{
		get
		{
			return Vector3.Left * this;
		}
	}

	// Token: 0x1700005D RID: 93
	// (get) Token: 0x0600019E RID: 414 RVA: 0x00008BD3 File Offset: 0x00006DD3
	public Vector3 Up
	{
		get
		{
			return Vector3.Up * this;
		}
	}

	// Token: 0x1700005E RID: 94
	// (get) Token: 0x0600019F RID: 415 RVA: 0x00008BE5 File Offset: 0x00006DE5
	public Vector3 Down
	{
		get
		{
			return Vector3.Down * this;
		}
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x00008BF7 File Offset: 0x00006DF7
	public static Vector3 operator *(Rotation f, Vector3 c1)
	{
		return Vector3.Transform(c1._vec, f._quat);
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x00008C0F File Offset: 0x00006E0F
	public static Rotation operator *(Rotation a, Rotation b)
	{
		return Quaternion.Multiply(a._quat, b._quat);
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x00008C27 File Offset: 0x00006E27
	public static Rotation operator *(Rotation a, float f)
	{
		return Quaternion.Slerp(Quaternion.Identity, a._quat, f);
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x00008C3F File Offset: 0x00006E3F
	public static Rotation operator /(Rotation a, float f)
	{
		return Quaternion.Slerp(Quaternion.Identity, a._quat, 1f / f);
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x00008C5D File Offset: 0x00006E5D
	public static Rotation operator +(Rotation a, Rotation b)
	{
		return Quaternion.Add(a._quat, b._quat);
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x00008C75 File Offset: 0x00006E75
	public static Rotation operator -(Rotation a, Rotation b)
	{
		return Quaternion.Subtract(a._quat, b._quat);
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x00008C8D File Offset: 0x00006E8D
	public static Rotation Read(BinaryReader reader)
	{
		return new Quaternion(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x00008CB1 File Offset: 0x00006EB1
	public void Write(BinaryWriter writer)
	{
		writer.Write(this.x);
		writer.Write(this.y);
		writer.Write(this.z);
		writer.Write(this.w);
	}

	/// <summary>
	/// Given a string, try to convert this into a quaternion rotation. The format is "x,y,z,w"
	/// </summary>
	// Token: 0x060001A8 RID: 424 RVA: 0x00008CE4 File Offset: 0x00006EE4
	public static Rotation Parse(string str)
	{
		str = str.Trim(new char[] { '[', ']', ' ', '\n', '\r', '\t', '"' });
		string[] p = str.Split(new char[] { ' ', ',', ';', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
		if (p.Length != 4)
		{
			return Rotation.Identity;
		}
		return new Quaternion(p[0].ToFloat(0f), p[1].ToFloat(0f), p[2].ToFloat(0f), p[3].ToFloat(0f));
	}

	/// <summary>
	/// A convenience function that rotates this rotation around a given axis given amount of degrees
	/// </summary>
	// Token: 0x060001A9 RID: 425 RVA: 0x00008D6D File Offset: 0x00006F6D
	public Rotation RotateAroundAxis(Vector3 axis, float degrees)
	{
		return this * Rotation.FromAxis(axis, degrees);
	}

	/// <summary>
	/// Returns a rotation pointing in a random direction.
	/// </summary>
	// Token: 0x1700005F RID: 95
	// (get) Token: 0x060001AA RID: 426 RVA: 0x00008D81 File Offset: 0x00006F81
	public static Rotation Random
	{
		get
		{
			return Rotation.From(Rand.Float(-359f, 359f), Rand.Float(-359f, 359f), Rand.Float(-359f, 359f));
		}
	}

	// Token: 0x060001AB RID: 427 RVA: 0x00008DB5 File Offset: 0x00006FB5
	public static bool operator ==(Rotation left, Rotation right)
	{
		return left.Equals(right);
	}

	// Token: 0x060001AC RID: 428 RVA: 0x00008DBF File Offset: 0x00006FBF
	public static bool operator !=(Rotation left, Rotation right)
	{
		return !(left == right);
	}

	// Token: 0x060001AD RID: 429 RVA: 0x00008DCC File Offset: 0x00006FCC
	public override bool Equals(object obj)
	{
		if (obj is Rotation)
		{
			Rotation o = (Rotation)obj;
			return this.Equals(o);
		}
		return false;
	}

	// Token: 0x060001AE RID: 430 RVA: 0x00008DF4 File Offset: 0x00006FF4
	public bool Equals(Rotation o)
	{
		return this._quat.X.AlmostEqual(o._quat.X, 0.0001f) && this._quat.Y.AlmostEqual(o._quat.Y, 0.0001f) && this._quat.Z.AlmostEqual(o._quat.Z, 0.0001f) && this._quat.W.AlmostEqual(o._quat.W, 0.0001f);
	}

	// Token: 0x060001AF RID: 431 RVA: 0x00008E89 File Offset: 0x00007089
	public override int GetHashCode()
	{
		return HashCode.Combine<Quaternion>(this._quat);
	}

	// Token: 0x0400005E RID: 94
	internal Quaternion _quat;

	// Token: 0x0400005F RID: 95
	public static readonly Rotation Identity = new Rotation
	{
		_quat = Quaternion.Identity
	};
}
