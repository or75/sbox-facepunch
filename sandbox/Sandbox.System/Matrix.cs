using System;
using System.Numerics;
using Sandbox;

// Token: 0x0200001A RID: 26
public struct Matrix : IEquatable<Matrix>
{
	// Token: 0x06000105 RID: 261 RVA: 0x00006BC0 File Offset: 0x00004DC0
	public static implicit operator Matrix(Matrix4x4 value)
	{
		return new Matrix
		{
			Numerics = value
		};
	}

	// Token: 0x06000106 RID: 262 RVA: 0x00006BDE File Offset: 0x00004DDE
	public static implicit operator Matrix4x4(Matrix value)
	{
		return value.Numerics;
	}

	// Token: 0x17000040 RID: 64
	// (get) Token: 0x06000107 RID: 263 RVA: 0x00006BE6 File Offset: 0x00004DE6
	public static Matrix Identity
	{
		get
		{
			return Matrix4x4.Identity;
		}
	}

	// Token: 0x17000041 RID: 65
	// (get) Token: 0x06000108 RID: 264 RVA: 0x00006BF4 File Offset: 0x00004DF4
	public Matrix Inverted
	{
		get
		{
			Matrix4x4 inv;
			Matrix4x4.Invert(this.Numerics, out inv);
			return inv;
		}
	}

	// Token: 0x06000109 RID: 265 RVA: 0x00006C15 File Offset: 0x00004E15
	public static Matrix CreateWorld(Vector3 position, Vector3 forward, Vector3 up)
	{
		return Matrix4x4.CreateWorld(position, forward, up);
	}

	// Token: 0x0600010A RID: 266 RVA: 0x00006C33 File Offset: 0x00004E33
	public static Matrix CreateRotation(Rotation rot)
	{
		return Matrix4x4.CreateFromQuaternion(rot._quat);
	}

	// Token: 0x0600010B RID: 267 RVA: 0x00006C45 File Offset: 0x00004E45
	public static Matrix CreateRotation(Vector3 angles)
	{
		return Matrix.CreateRotationX(angles.x) * Matrix.CreateRotationY(angles.y) * Matrix.CreateRotationZ(angles.z);
	}

	// Token: 0x0600010C RID: 268 RVA: 0x00006C75 File Offset: 0x00004E75
	public static Matrix CreateRotationX(float degrees)
	{
		return Matrix4x4.CreateRotationX(degrees.DegreeToRadian());
	}

	// Token: 0x0600010D RID: 269 RVA: 0x00006C87 File Offset: 0x00004E87
	public static Matrix CreateRotationX(float degrees, Vector3 center)
	{
		return Matrix4x4.CreateRotationX(degrees.DegreeToRadian(), center);
	}

	// Token: 0x0600010E RID: 270 RVA: 0x00006C9F File Offset: 0x00004E9F
	public static Matrix CreateRotationY(float degrees)
	{
		return Matrix4x4.CreateRotationY(degrees.DegreeToRadian());
	}

	// Token: 0x0600010F RID: 271 RVA: 0x00006CB1 File Offset: 0x00004EB1
	public static Matrix CreateRotationY(float degrees, Vector3 center)
	{
		return Matrix4x4.CreateRotationY(degrees.DegreeToRadian(), center);
	}

	// Token: 0x06000110 RID: 272 RVA: 0x00006CC9 File Offset: 0x00004EC9
	public static Matrix CreateRotationZ(float degrees)
	{
		return Matrix4x4.CreateRotationZ(degrees.DegreeToRadian());
	}

	// Token: 0x06000111 RID: 273 RVA: 0x00006CDB File Offset: 0x00004EDB
	public static Matrix CreateRotationZ(float degrees, Vector3 center)
	{
		return Matrix4x4.CreateRotationZ(degrees.DegreeToRadian(), center);
	}

	// Token: 0x06000112 RID: 274 RVA: 0x00006CF3 File Offset: 0x00004EF3
	public static Matrix CreateTranslation(Vector3 vec)
	{
		return Matrix4x4.CreateTranslation(vec);
	}

	// Token: 0x06000113 RID: 275 RVA: 0x00006D05 File Offset: 0x00004F05
	public static Matrix CreateScale(Vector3 scales)
	{
		return Matrix4x4.CreateScale(scales);
	}

	// Token: 0x06000114 RID: 276 RVA: 0x00006D17 File Offset: 0x00004F17
	public static Matrix CreateScale(Vector3 scales, Vector3 centerPoint)
	{
		return Matrix4x4.CreateScale(scales, centerPoint);
	}

	// Token: 0x06000115 RID: 277 RVA: 0x00006D30 File Offset: 0x00004F30
	public static Matrix CreateSkew(Vector2 skew)
	{
		return new Matrix4x4(1f, MathF.Tan(skew.y.DegreeToRadian()), 0f, 0f, MathF.Tan(skew.x.DegreeToRadian()), 1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f);
	}

	// Token: 0x06000116 RID: 278 RVA: 0x00006DB0 File Offset: 0x00004FB0
	public static Matrix CreateSkewX(float degrees)
	{
		return new Matrix4x4(1f, 0f, 0f, 0f, MathF.Tan(degrees.DegreeToRadian()), 1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f);
	}

	// Token: 0x06000117 RID: 279 RVA: 0x00006E20 File Offset: 0x00005020
	public static Matrix CreateSkewY(float degrees)
	{
		return new Matrix4x4(1f, MathF.Tan(degrees.DegreeToRadian()), 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 1f);
	}

	// Token: 0x06000118 RID: 280 RVA: 0x00006E90 File Offset: 0x00005090
	public static Matrix CreateMatrix3D(float[] matrix)
	{
		return new Matrix4x4(matrix[0], matrix[1], matrix[2], matrix[3], matrix[4], matrix[5], matrix[6], matrix[7], matrix[8], matrix[9], matrix[10], matrix[11], matrix[12], matrix[13], matrix[14], matrix[15]);
	}

	// Token: 0x06000119 RID: 281 RVA: 0x00006EDE File Offset: 0x000050DE
	public static Matrix operator *(Matrix value1, Matrix value2)
	{
		return value1.Numerics * value2.Numerics;
	}

	// Token: 0x0600011A RID: 282 RVA: 0x00006EF6 File Offset: 0x000050F6
	public static Matrix Lerp(Matrix ma, Matrix mb, float delta)
	{
		return Matrix4x4.Lerp(ma.Numerics, mb.Numerics, delta);
	}

	// Token: 0x0600011B RID: 283 RVA: 0x00006F10 File Offset: 0x00005110
	public static Matrix Slerp(Matrix ma, Matrix mb, float delta)
	{
		Vector3 sa;
		Quaternion ra;
		Vector3 ta;
		Matrix4x4.Decompose(ma, out sa, out ra, out ta);
		Vector3 sb;
		Quaternion rb;
		Vector3 tb;
		Matrix4x4.Decompose(mb, out sb, out rb, out tb);
		return Matrix.Identity * Matrix4x4.CreateFromQuaternion(Quaternion.Slerp(ra, rb, delta));
	}

	/// <summary>
	/// Formats the matrix and returns it as a string.
	/// </summary>
	/// <returns></returns>
	// Token: 0x0600011C RID: 284 RVA: 0x00006F60 File Offset: 0x00005160
	public override string ToString()
	{
		return string.Format("M11: {0:0.####}, M12: {1:0.####}, M13: {2:0.####}, M14: {3:0.####} \n", new object[]
		{
			this.Numerics.M11,
			this.Numerics.M12,
			this.Numerics.M13,
			this.Numerics.M14
		}) + string.Format("M21: {0:0.####}, M22: {1:0.####}, M23: {2:0.####}, M24: {3:0.####} \n", new object[]
		{
			this.Numerics.M21,
			this.Numerics.M22,
			this.Numerics.M23,
			this.Numerics.M24
		}) + string.Format("M31: {0:0.####}, M32: {1:0.####}, M33: {2:0.####}, M34: {3:0.####} \n", new object[]
		{
			this.Numerics.M31,
			this.Numerics.M32,
			this.Numerics.M33,
			this.Numerics.M34
		}) + string.Format("M41: {0:0.####}, M42: {1:0.####}, M43: {2:0.####}, M44: {3:0.####} ", new object[]
		{
			this.Numerics.M41,
			this.Numerics.M42,
			this.Numerics.M43,
			this.Numerics.M44
		});
	}

	// Token: 0x0600011D RID: 285 RVA: 0x000070E2 File Offset: 0x000052E2
	public Matrix Transpose()
	{
		return Matrix4x4.Transpose(this.Numerics);
	}

	/// <summary>
	/// Transforms a vector by a 4x4 matrix
	/// </summary>
	// Token: 0x0600011E RID: 286 RVA: 0x000070F4 File Offset: 0x000052F4
	public Vector3 Transform(Vector3 v)
	{
		return Vector3.Transform(v._vec, this.Numerics);
	}

	/// <summary>
	/// Transforms a normal vector by a specified 4x4 matrix
	/// </summary>
	// Token: 0x0600011F RID: 287 RVA: 0x0000710C File Offset: 0x0000530C
	public Vector3 TransformNormal(Vector3 v)
	{
		return Vector3.TransformNormal(v._vec, this.Numerics);
	}

	// Token: 0x06000120 RID: 288 RVA: 0x00007124 File Offset: 0x00005324
	public static bool operator ==(Matrix left, Matrix right)
	{
		return left.Equals(right);
	}

	// Token: 0x06000121 RID: 289 RVA: 0x0000712E File Offset: 0x0000532E
	public static bool operator !=(Matrix left, Matrix right)
	{
		return !(left == right);
	}

	// Token: 0x06000122 RID: 290 RVA: 0x0000713C File Offset: 0x0000533C
	public override bool Equals(object obj)
	{
		if (obj is Matrix)
		{
			Matrix o = (Matrix)obj;
			return this.Equals(o);
		}
		return false;
	}

	// Token: 0x06000123 RID: 291 RVA: 0x00007161 File Offset: 0x00005361
	public bool Equals(Matrix o)
	{
		return this.Numerics == o.Numerics;
	}

	// Token: 0x06000124 RID: 292 RVA: 0x00007174 File Offset: 0x00005374
	public override int GetHashCode()
	{
		return HashCode.Combine<Matrix4x4>(this.Numerics);
	}

	// Token: 0x04000044 RID: 68
	public Matrix4x4 Numerics;
}
