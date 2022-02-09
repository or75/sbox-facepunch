using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000FC RID: 252
	public struct TraceResult
	{
		// Token: 0x17000319 RID: 793
		// (get) Token: 0x060014CC RID: 5324 RVA: 0x00053122 File Offset: 0x00051322
		public float Distance
		{
			get
			{
				return Vector3.DistanceBetween(this.StartPos, this.EndPos);
			}
		}

		// Token: 0x060014CD RID: 5325 RVA: 0x00053138 File Offset: 0x00051338
		internal static TraceResult From(in TraceResult result)
		{
			TraceResult result2 = default(TraceResult);
			result2.Hit = result.Fraction < 1f;
			result2.StartedSolid = result.StartedInSolid > 0;
			result2.StartPos = result.StartPos;
			result2.EndPos = result.EndPos;
			result2.Normal = result.Normal;
			result2.Fraction = result.Fraction;
			result2.Bone = result.Bone;
			result2.Direction = (result.EndPos - result.StartPos).Normal;
			result2.Triangle = result.TriangleIndex;
			result2.Entity = InteropSystem.Get<Entity>(result.Entity);
			result2.Surface = Surface.FindByIndex(result.SurfaceProperty);
			PhysicsBody physicsBody = HandleIndex.Get<PhysicsBody>(result.PhysicsBodyHandle);
			result2.Body = ((physicsBody != null) ? physicsBody.SelfOrParent : null);
			result2.Shape = HandleIndex.Get<PhysicsShape>(result.PhysicsShapeHandle);
			result2.HitboxIndex = result.Hitbox;
			return result2;
		}

		/// <summary>
		/// Whether the trace hit something or not
		/// </summary>
		// Token: 0x040004CD RID: 1229
		public bool Hit;

		/// <summary>
		/// Whether the trace started in a solid
		/// </summary>
		// Token: 0x040004CE RID: 1230
		public bool StartedSolid;

		/// <summary>
		/// The start position of the trace
		/// </summary>
		// Token: 0x040004CF RID: 1231
		public Vector3 StartPos;

		/// <summary>
		/// The end or hit position of the trace
		/// </summary>
		// Token: 0x040004D0 RID: 1232
		public Vector3 EndPos;

		/// <summary>
		/// The hit surface normal (direction vector)
		/// </summary>
		// Token: 0x040004D1 RID: 1233
		public Vector3 Normal;

		/// <summary>
		/// A fraction [0..1] of where the trace hit between the start and the original end positions
		/// </summary>
		// Token: 0x040004D2 RID: 1234
		public float Fraction;

		/// <summary>
		/// The entity that was hit, if any
		/// </summary>
		// Token: 0x040004D3 RID: 1235
		public Entity Entity;

		/// <summary>
		/// The physics object that was hit, if any
		/// </summary>
		// Token: 0x040004D4 RID: 1236
		public PhysicsBody Body;

		/// <summary>
		/// The physics shape that was hit, if any
		/// </summary>
		// Token: 0x040004D5 RID: 1237
		public PhysicsShape Shape;

		/// <summary>
		/// The hitbox in current hitbox set that was hit, or -1. Requires <see cref="M:Sandbox.Trace.UseHitboxes(System.Boolean)">Trace.UseHitboxes</see> to work.
		/// </summary>
		// Token: 0x040004D6 RID: 1238
		public int HitboxIndex;

		/// <summary>
		/// The physical properties of the hit surface
		/// </summary>
		// Token: 0x040004D7 RID: 1239
		public Surface Surface;

		/// <summary>
		/// The id of the hit bone (either from hitbox or physics shape)
		/// </summary>
		// Token: 0x040004D8 RID: 1240
		public int Bone;

		/// <summary>
		/// The direction of the trace ray
		/// </summary>
		// Token: 0x040004D9 RID: 1241
		public Vector3 Direction;

		/// <summary>
		/// The triangle index hit, if we hit a mesh shape
		/// </summary>
		// Token: 0x040004DA RID: 1242
		public int Triangle;
	}
}
