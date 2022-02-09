using System;
using System.Text.Json.Serialization;
using Sandbox.Internal.JsonConvert;

// Token: 0x02000017 RID: 23
[JsonConverter(typeof(Vector3Converter))]
public struct Capsule : IEquatable<Capsule>
{
	// Token: 0x060000EB RID: 235 RVA: 0x00006490 File Offset: 0x00004690
	public Capsule(Vector3 a, Vector3 b, float r)
	{
		this.CenterA = a;
		this.CenterB = b;
		this.Radius = r;
	}

	/// <summary>
	/// Creates a capule where Point A is radius units above the ground and Point B is height minus radius units above the ground.
	/// </summary>
	// Token: 0x060000EC RID: 236 RVA: 0x000064A7 File Offset: 0x000046A7
	public static Capsule FromHeightAndRadius(float height, float radius)
	{
		return new Capsule(Vector3.Up * radius, Vector3.Up * (height - radius), radius);
	}

	// Token: 0x060000ED RID: 237 RVA: 0x000064C7 File Offset: 0x000046C7
	public static bool operator ==(Capsule left, Capsule right)
	{
		return left.Equals(right);
	}

	// Token: 0x060000EE RID: 238 RVA: 0x000064D1 File Offset: 0x000046D1
	public static bool operator !=(Capsule left, Capsule right)
	{
		return !(left == right);
	}

	// Token: 0x060000EF RID: 239 RVA: 0x000064E0 File Offset: 0x000046E0
	public override bool Equals(object obj)
	{
		if (obj is Capsule)
		{
			Capsule o = (Capsule)obj;
			return this.Equals(o);
		}
		return false;
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x00006508 File Offset: 0x00004708
	public bool Equals(Capsule o)
	{
		Vector3 centerA = this.CenterA;
		Vector3 centerB = this.CenterB;
		float radius = this.Radius;
		Vector3 centerA2 = o.CenterA;
		Vector3 centerB2 = o.CenterB;
		float radius2 = o.Radius;
		return centerA == centerA2 && centerB == centerB2 && radius == radius2;
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x00006557 File Offset: 0x00004757
	public override int GetHashCode()
	{
		return HashCode.Combine<Vector3, Vector3, float>(this.CenterA, this.CenterB, this.Radius);
	}

	// Token: 0x04000039 RID: 57
	public Vector3 CenterA;

	// Token: 0x0400003A RID: 58
	public Vector3 CenterB;

	// Token: 0x0400003B RID: 59
	public float Radius;
}
