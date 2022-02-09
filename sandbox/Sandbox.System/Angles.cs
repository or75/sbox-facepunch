using System;
using System.IO;
using System.Text.Json.Serialization;
using Sandbox;
using Sandbox.Internal.JsonConvert;

// Token: 0x02000015 RID: 21
[JsonConverter(typeof(AnglesConverter))]
public struct Angles : IEquatable<Angles>
{
	// Token: 0x060000B4 RID: 180 RVA: 0x00005A1E File Offset: 0x00003C1E
	public Angles(float pitch, float yaw, float roll)
	{
		this.pitch = pitch;
		this.yaw = yaw;
		this.roll = roll;
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x00005A35 File Offset: 0x00003C35
	public Angles(Angles other)
	{
		this.pitch = other.pitch;
		this.yaw = other.yaw;
		this.roll = other.roll;
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x00005A5B File Offset: 0x00003C5B
	public Angles(float all = 0f)
	{
		this = new Angles(all, all, all);
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x00005A66 File Offset: 0x00003C66
	public readonly Rotation ToRotation()
	{
		return Rotation.From(this);
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00005A73 File Offset: 0x00003C73
	public override readonly string ToString()
	{
		return string.Format("Pitch = {0:0.00}, Yaw = {1:0.00}, Roll = {2:0.00}", this.pitch, this.yaw, this.roll);
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x00005AA0 File Offset: 0x00003CA0
	public static Angles Parse(string str)
	{
		string[] p = str.Split(new char[] { ' ', ',', ';' });
		if (p.Length != 3)
		{
			return Angles.Zero;
		}
		return new Angles(p[0].ToFloat(0f), p[1].ToFloat(0f), p[2].ToFloat(0f));
	}

	// Token: 0x060000BA RID: 186 RVA: 0x00005AFD File Offset: 0x00003CFD
	public static Angles operator +(Angles c1, Angles c2)
	{
		return new Angles(c1.pitch + c2.pitch, c1.yaw + c2.yaw, c1.roll + c2.roll);
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00005B2B File Offset: 0x00003D2B
	public static Angles operator +(Angles c1, Vector3 c2)
	{
		return new Angles(c1.pitch + c2.x, c1.yaw + c2.y, c1.roll + c2.z);
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00005B5C File Offset: 0x00003D5C
	public static Angles operator -(Angles c1, Angles c2)
	{
		return new Angles(c1.pitch - c2.pitch, c1.yaw - c2.yaw, c1.roll - c2.roll);
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00005B8A File Offset: 0x00003D8A
	public static Angles operator *(Angles c1, float c2)
	{
		return new Angles(c1.pitch * c2, c1.yaw * c2, c1.roll * c2);
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00005BA9 File Offset: 0x00003DA9
	public static Angles operator /(Angles c1, float c2)
	{
		return new Angles(c1.pitch / c2, c1.yaw / c2, c1.roll / c2);
	}

	/// <summary>
	/// Returns a new angle object with each component randomized between -1 and 1.
	/// </summary>
	// Token: 0x17000034 RID: 52
	// (get) Token: 0x060000BF RID: 191 RVA: 0x00005BC8 File Offset: 0x00003DC8
	public static Angles Random
	{
		get
		{
			return new Angles(Rand.Float(-1f, 1f), Rand.Float(-1f, 1f), Rand.Float(-1f, 1f));
		}
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x00005BFC File Offset: 0x00003DFC
	public readonly bool IsNearlyZero(double tolerance = 5E-324)
	{
		return (double)MathF.Abs(this.pitch) <= tolerance && (double)MathF.Abs(this.yaw) <= tolerance && (double)MathF.Abs(this.roll) <= tolerance;
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x00005C30 File Offset: 0x00003E30
	public readonly Angles WithPitch(float pitch)
	{
		return new Angles(pitch, this.yaw, this.roll);
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x00005C44 File Offset: 0x00003E44
	public readonly Angles WithYaw(float yaw)
	{
		return new Angles(this.pitch, yaw, this.roll);
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x00005C58 File Offset: 0x00003E58
	public readonly Angles WithRoll(float roll)
	{
		return new Angles(this.pitch, this.yaw, roll);
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x00005C6C File Offset: 0x00003E6C
	public void Write(BinaryWriter writer)
	{
		writer.Write(this.pitch);
		writer.Write(this.yaw);
		writer.Write(this.roll);
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00005C95 File Offset: 0x00003E95
	public static Angles Read(BinaryReader reader)
	{
		return new Angles(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x00005CAE File Offset: 0x00003EAE
	public readonly Angles Clamped()
	{
		return new Angles(Angles.ClampAngle(this.pitch), Angles.ClampAngle(this.yaw), Angles.ClampAngle(this.roll));
	}

	// Token: 0x17000035 RID: 53
	// (get) Token: 0x060000C7 RID: 199 RVA: 0x00005CD6 File Offset: 0x00003ED6
	public readonly Angles Normal
	{
		get
		{
			return new Angles(Angles.NormalizeAngle(this.pitch), Angles.NormalizeAngle(this.yaw), Angles.NormalizeAngle(this.roll));
		}
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x00005CFE File Offset: 0x00003EFE
	public static float ClampAngle(float v)
	{
		v %= 360f;
		if (v >= 0f)
		{
			return v;
		}
		return v + 360f;
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00005D1A File Offset: 0x00003F1A
	public static float NormalizeAngle(float v)
	{
		v = Angles.ClampAngle(v);
		if (v <= 180f)
		{
			return v;
		}
		return v - 360f;
	}

	// Token: 0x060000CA RID: 202 RVA: 0x00005D38 File Offset: 0x00003F38
	public static Angles Lerp(Angles a, Angles b, float t)
	{
		return a + (b - a).Normal * t;
	}

	/// <summary>
	/// The direction vector for this angle
	/// </summary>
	// Token: 0x17000036 RID: 54
	// (get) Token: 0x060000CB RID: 203 RVA: 0x00005D60 File Offset: 0x00003F60
	// (set) Token: 0x060000CC RID: 204 RVA: 0x00005D6D File Offset: 0x00003F6D
	public Vector3 Direction
	{
		readonly get
		{
			return Angles.AngleVector(this);
		}
		set
		{
			this = Vector3.VectorAngle(value);
		}
	}

	/// <summary>
	/// Converts an angle to a forward vector
	/// </summary>
	// Token: 0x060000CD RID: 205 RVA: 0x00005D7C File Offset: 0x00003F7C
	public static Vector3 AngleVector(Angles ang)
	{
		float[] vAngles = new float[] { ang.yaw, ang.pitch };
		float[] vSines = new float[2];
		float[] vCosines = new float[2];
		vSines[0] = (float)Math.Sin((double)(vAngles[0] * 0.017453292f));
		vSines[1] = (float)Math.Sin((double)(vAngles[1] * 0.017453292f));
		vCosines[0] = (float)Math.Cos((double)(vAngles[0] * 0.017453292f));
		vCosines[1] = (float)Math.Cos((double)(vAngles[1] * 0.017453292f));
		return new Vector3(vCosines[1] * vCosines[0], vCosines[1] * vSines[0], -vSines[1]);
	}

	// Token: 0x17000037 RID: 55
	// (get) Token: 0x060000CE RID: 206 RVA: 0x00005E13 File Offset: 0x00004013
	public readonly float Length
	{
		get
		{
			return MathF.Sqrt(this.LengthSqr);
		}
	}

	// Token: 0x17000038 RID: 56
	// (get) Token: 0x060000CF RID: 207 RVA: 0x00005E20 File Offset: 0x00004020
	public readonly float LengthSqr
	{
		get
		{
			return this.pitch * this.pitch + this.roll * this.roll + this.yaw * this.yaw;
		}
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x00005E4B File Offset: 0x0000404B
	public static bool operator ==(Angles left, Angles right)
	{
		return left.Equals(right);
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00005E55 File Offset: 0x00004055
	public static bool operator !=(Angles left, Angles right)
	{
		return !(left == right);
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x00005E64 File Offset: 0x00004064
	public override bool Equals(object obj)
	{
		if (obj is Angles)
		{
			Angles o = (Angles)obj;
			return this.Equals(o);
		}
		return false;
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x00005E8C File Offset: 0x0000408C
	public bool Equals(Angles o)
	{
		float num = this.pitch;
		float num2 = this.yaw;
		float num3 = this.roll;
		float num4 = o.pitch;
		float num5 = o.yaw;
		float num6 = o.roll;
		return num == num4 && num2 == num5 && num3 == num6;
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x00005ED1 File Offset: 0x000040D1
	public override int GetHashCode()
	{
		return HashCode.Combine<float, float, float>(this.pitch, this.yaw, this.roll);
	}

	// Token: 0x04000033 RID: 51
	public float pitch;

	// Token: 0x04000034 RID: 52
	public float yaw;

	// Token: 0x04000035 RID: 53
	public float roll;

	// Token: 0x04000036 RID: 54
	public static readonly Angles Zero = new Angles(0f);
}
