using System;

/// <summary>
/// A struct containing a position, rotation and scale. This is commonly used in engine to describe
/// entity position, bone position and scene object position.
/// </summary>
// Token: 0x02000024 RID: 36
public struct Transform : IEquatable<Transform>
{
	// Token: 0x060001B8 RID: 440 RVA: 0x00008FA7 File Offset: 0x000071A7
	public Transform(Vector3 pos = default(Vector3))
	{
		this.Position = pos;
		this.Rotation = Rotation.Identity;
		this.Scale = 1f;
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x00008FC6 File Offset: 0x000071C6
	public Transform(Vector3 position, Rotation rotation, float scale = 1f)
	{
		this.Position = position;
		this.Rotation = rotation;
		this.Scale = scale;
	}

	/// <summary>
	/// Convert child transform from the world to a local transform
	/// </summary>
	// Token: 0x060001BA RID: 442 RVA: 0x00008FE0 File Offset: 0x000071E0
	public Transform ToLocal(Transform child)
	{
		Rotation rotInv = this.Rotation.Inverse;
		return new Transform
		{
			Position = (child.Position - this.Position) * rotInv,
			Rotation = rotInv * child.Rotation,
			Scale = this.Scale
		};
	}

	/// <summary>
	/// Convert a point in world space to a point in this transform's local space
	/// </summary>
	// Token: 0x060001BB RID: 443 RVA: 0x00009040 File Offset: 0x00007240
	public readonly Vector3 PointToLocal(Vector3 worldPoint)
	{
		Vector3 c = worldPoint - this.Position;
		Rotation rotation = this.Rotation;
		return c * rotation.Inverse;
	}

	/// <summary>
	/// Convert a world normal to a local normal
	/// </summary>
	// Token: 0x060001BC RID: 444 RVA: 0x0000906C File Offset: 0x0000726C
	public readonly Vector3 NormalToLocal(Vector3 worldNormal)
	{
		Rotation rotation = this.Rotation;
		return worldNormal * rotation.Inverse;
	}

	/// <summary>
	/// Convert a world rotation to a local rotation
	/// </summary>
	// Token: 0x060001BD RID: 445 RVA: 0x00009090 File Offset: 0x00007290
	public readonly Rotation RotationToLocal(Rotation worldRot)
	{
		Rotation rotation = this.Rotation;
		return rotation.Inverse * worldRot;
	}

	/// <summary>
	/// Convert a point in this transform's local space to a point in world space
	/// </summary>
	// Token: 0x060001BE RID: 446 RVA: 0x000090B1 File Offset: 0x000072B1
	public readonly Vector3 PointToWorld(Vector3 localPoint)
	{
		return this.Position + localPoint * this.Rotation;
	}

	/// <summary>
	/// Convert a local normal to a world normal
	/// </summary>
	// Token: 0x060001BF RID: 447 RVA: 0x000090CA File Offset: 0x000072CA
	public readonly Vector3 NormalToWorld(Vector3 localNormal)
	{
		return localNormal * this.Rotation;
	}

	/// <summary>
	/// Convert a local rotation to a world rotation
	/// </summary>
	// Token: 0x060001C0 RID: 448 RVA: 0x000090D8 File Offset: 0x000072D8
	public readonly Rotation RotationToWorld(Rotation localRotation)
	{
		return this.Rotation * localRotation;
	}

	/// <summary>
	/// Convert child transform from local to the world
	/// </summary>
	// Token: 0x060001C1 RID: 449 RVA: 0x000090E8 File Offset: 0x000072E8
	public readonly Transform ToWorld(Transform child)
	{
		return new Transform
		{
			Position = child.Position * this.Rotation + this.Position,
			Rotation = this.Rotation * child.Rotation,
			Scale = this.Scale
		};
	}

	/// <summary>
	/// Transform a Vector as if it were a child of this transform
	/// </summary>
	// Token: 0x060001C2 RID: 450 RVA: 0x00009146 File Offset: 0x00007346
	public readonly Vector3 TransformVector(Vector3 local)
	{
		local *= this.Rotation;
		local += this.Position;
		return local;
	}

	/// <summary>
	/// Lerp from one transform to another
	/// </summary>
	// Token: 0x060001C3 RID: 451 RVA: 0x00009168 File Offset: 0x00007368
	public static Transform Lerp(Transform a, Transform b, float t, bool clamp)
	{
		return new Transform
		{
			Position = Vector3.Lerp(a.Position, b.Position, t, clamp),
			Rotation = Rotation.Slerp(a.Rotation, b.Rotation, t, clamp),
			Scale = a.Scale
		};
	}

	/// <summary>
	/// Add a position to this transform and return the result.
	/// </summary>
	// Token: 0x060001C4 RID: 452 RVA: 0x000091C0 File Offset: 0x000073C0
	public readonly Transform Add(Vector3 position, bool worldSpace)
	{
		Transform t = this;
		if (worldSpace)
		{
			t.Position += position;
		}
		else
		{
			t.Position += t.Rotation * position;
		}
		return t;
	}

	/// <summary>
	/// Return this transform with a new position
	/// </summary>
	// Token: 0x060001C5 RID: 453 RVA: 0x00009218 File Offset: 0x00007418
	public readonly Transform WithPosition(Vector3 position)
	{
		Transform t = this;
		t.Position = position;
		return t;
	}

	/// <summary>
	/// Return this transform with a new rotation
	/// </summary>
	// Token: 0x060001C6 RID: 454 RVA: 0x00009238 File Offset: 0x00007438
	public readonly Transform WithRotation(Rotation rotation)
	{
		Transform t = this;
		t.Rotation = rotation;
		return t;
	}

	/// <summary>
	/// Return this transform with a new scale
	/// </summary>
	// Token: 0x060001C7 RID: 455 RVA: 0x00009258 File Offset: 0x00007458
	public readonly Transform WithScale(float scale)
	{
		Transform t = this;
		t.Scale = scale;
		return t;
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x00009275 File Offset: 0x00007475
	public static bool operator ==(Transform left, Transform right)
	{
		return left.Equals(right);
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x0000927F File Offset: 0x0000747F
	public static bool operator !=(Transform left, Transform right)
	{
		return !(left == right);
	}

	// Token: 0x060001CA RID: 458 RVA: 0x0000928C File Offset: 0x0000748C
	public override bool Equals(object obj)
	{
		if (obj is Transform)
		{
			Transform o = (Transform)obj;
			return this.Equals(o);
		}
		return false;
	}

	// Token: 0x060001CB RID: 459 RVA: 0x000092B4 File Offset: 0x000074B4
	public bool Equals(Transform o)
	{
		Vector3 position = this.Position;
		float scale = this.Scale;
		Rotation rotation = this.Rotation;
		Vector3 position2 = o.Position;
		float scale2 = o.Scale;
		Rotation rotation2 = o.Rotation;
		return position == position2 && scale == scale2 && rotation == rotation2;
	}

	// Token: 0x060001CC RID: 460 RVA: 0x00009301 File Offset: 0x00007501
	public override int GetHashCode()
	{
		return HashCode.Combine<Vector3, float, Rotation>(this.Position, this.Scale, this.Rotation);
	}

	// Token: 0x04000062 RID: 98
	public static readonly Transform Zero = new Transform(Vector3.Zero);

	// Token: 0x04000063 RID: 99
	public Vector3 Position;

	// Token: 0x04000064 RID: 100
	public float Scale;

	// Token: 0x04000065 RID: 101
	public Rotation Rotation;
}
