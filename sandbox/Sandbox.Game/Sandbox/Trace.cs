using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000FB RID: 251
	public struct Trace
	{
		/// <summary>
		/// Casts a sphere from point A to point B.
		/// </summary>
		// Token: 0x060014AB RID: 5291 RVA: 0x00052814 File Offset: 0x00050A14
		public static Trace Sphere(float radius, in Vector3 from, in Vector3 to)
		{
			return Trace.Ray(from, to).Radius(radius);
		}

		/// <summary>
		/// Casts a sphere from a given position and direction, up to a given distance.
		/// </summary>
		// Token: 0x060014AC RID: 5292 RVA: 0x00052834 File Offset: 0x00050A34
		public static Trace Sphere(float radius, in Ray ray, in float distance)
		{
			return Trace.Ray(ray, distance).Radius(radius);
		}

		/// <summary>
		/// Casts a box from point A to point B.
		/// </summary>
		// Token: 0x060014AD RID: 5293 RVA: 0x00052854 File Offset: 0x00050A54
		public static Trace Box(Vector3 extents, in Vector3 from, in Vector3 to)
		{
			return Trace.Ray(from, to).Size(extents);
		}

		/// <summary>
		/// Casts a box from a given position and direction, up to a given distance.
		/// </summary>
		// Token: 0x060014AE RID: 5294 RVA: 0x00052874 File Offset: 0x00050A74
		public static Trace Box(Vector3 extents, in Ray ray, in float distance)
		{
			return Trace.Ray(ray, distance).Size(extents);
		}

		/// <summary>
		/// Casts a box from point A to point B.
		/// </summary>
		// Token: 0x060014AF RID: 5295 RVA: 0x00052894 File Offset: 0x00050A94
		public static Trace Box(BBox bbox, in Vector3 from, in Vector3 to)
		{
			return Trace.Ray(from, to).Size(bbox);
		}

		/// <summary>
		/// Casts a box from a given position and direction, up to a given distance.
		/// </summary>
		// Token: 0x060014B0 RID: 5296 RVA: 0x000528B4 File Offset: 0x00050AB4
		public static Trace Box(BBox bbox, in Ray ray, in float distance)
		{
			return Trace.Ray(ray, distance).Size(bbox);
		}

		/// <summary>
		/// Casts a capsule from point A to point B.
		/// </summary>
		// Token: 0x060014B1 RID: 5297 RVA: 0x000528D4 File Offset: 0x00050AD4
		public static Trace Capsule(Capsule capsule, in Vector3 from, in Vector3 to)
		{
			return new Trace
			{
				request = new TraceRequest
				{
					StartPos = from,
					EndPos = to,
					Capsule = capsule,
					Entities = 1,
					World = 1,
					Mask = CollisionLayer.Solid
				}
			};
		}

		/// <summary>
		/// Casts a capsule from a given position and direction, up to a given distance.
		/// </summary>
		// Token: 0x060014B2 RID: 5298 RVA: 0x00052938 File Offset: 0x00050B38
		public static Trace Capsule(Capsule capsule, in Ray ray, in float distance)
		{
			Trace result = default(Trace);
			TraceRequest traceRequest = default(TraceRequest);
			Ray ray2 = ray;
			traceRequest.StartPos = ray2.Origin;
			ray2 = ray;
			traceRequest.EndPos = ray2.Project(distance);
			traceRequest.Capsule = capsule;
			traceRequest.Entities = 1;
			traceRequest.World = 1;
			traceRequest.Mask = CollisionLayer.Solid;
			result.request = traceRequest;
			return result;
		}

		/// <summary>
		/// Casts a ray from point A to point B.
		/// </summary>
		// Token: 0x060014B3 RID: 5299 RVA: 0x000529AC File Offset: 0x00050BAC
		public static Trace Ray(in Vector3 from, in Vector3 to)
		{
			return new Trace
			{
				request = new TraceRequest
				{
					StartPos = from,
					EndPos = to,
					Entities = 1,
					World = 1,
					Mask = CollisionLayer.Solid
				}
			};
		}

		/// <summary>
		/// Casts a ray from a given position and direction, up to a given distance.
		/// </summary>
		// Token: 0x060014B4 RID: 5300 RVA: 0x00052A08 File Offset: 0x00050C08
		public static Trace Ray(in Ray ray, in float distance)
		{
			Trace result = default(Trace);
			TraceRequest traceRequest = default(TraceRequest);
			Ray ray2 = ray;
			traceRequest.StartPos = ray2.Origin;
			ray2 = ray;
			traceRequest.EndPos = ray2.Project(distance);
			traceRequest.Entities = 1;
			traceRequest.World = 1;
			traceRequest.Mask = CollisionLayer.Solid;
			result.request = traceRequest;
			return result;
		}

		/// <summary>
		/// Sweeps each <see cref="T:Sandbox.PhysicsShape">PhysicsShape</see> of given PhysicsBody and returns the closest collision. Does not support Mesh PhysicsShapes.
		/// Basically 'hull traces' but with physics shapes.
		/// </summary>
		// Token: 0x060014B5 RID: 5301 RVA: 0x00052A74 File Offset: 0x00050C74
		public static Trace Sweep(in PhysicsBody body, in Transform from, in Transform to)
		{
			return new Trace
			{
				request = new TraceRequest
				{
					PhysicsBody = body.native,
					StartPos = from.Position,
					StartRot = from.Rotation,
					EndPos = to.Position,
					EndRot = to.Rotation,
					Entities = 1,
					World = 1,
					Mask = CollisionLayer.Solid
				}
			};
		}

		/// <summary>
		/// Creates a Trace.Sweep using the <see cref="T:Sandbox.PhysicsBody">PhysicsBody</see>'s position as the starting position.
		/// </summary>
		// Token: 0x060014B6 RID: 5302 RVA: 0x00052AF8 File Offset: 0x00050CF8
		public static Trace Sweep(in PhysicsBody body, in Transform to)
		{
			Transform transform = body.Transform;
			return Trace.Sweep(body, transform, to);
		}

		/// <summary>
		/// Sets the start and end positions of the trace request
		/// </summary>
		// Token: 0x060014B7 RID: 5303 RVA: 0x00052B18 File Offset: 0x00050D18
		public readonly Trace FromTo(in Vector3 from, in Vector3 to)
		{
			Trace t = this;
			t.request.StartPos = from;
			t.request.EndPos = to;
			return t;
		}

		/// <summary>
		/// Marks given entity to be ignored by the trace (the trace will go through it). Has a limit of 2 entities at this time.
		/// </summary>
		// Token: 0x060014B8 RID: 5304 RVA: 0x00052B54 File Offset: 0x00050D54
		public readonly Trace Ignore(in Entity ent, in bool hierarchy = true)
		{
			if (ent == null)
			{
				return this;
			}
			Trace t = this;
			if (t.request.ignoreEntityOne == IntPtr.Zero)
			{
				t.request.ignoreEntityOne = ent.GetEntityIntPtr();
				t.request.ignoreHierarchyOne = hierarchy;
				return t;
			}
			if (t.request.ignoreEntityTwo == IntPtr.Zero)
			{
				t.request.ignoreEntityTwo = ent.GetEntityIntPtr();
				t.request.ignoreHierarchyTwo = hierarchy;
				return t;
			}
			throw new Exception("Traces can only ignore two entities right now - need more? Tell me.");
		}

		/// <summary>
		/// This trace should only hit the world, ignoring all entities.
		/// </summary>
		// Token: 0x060014B9 RID: 5305 RVA: 0x00052BF1 File Offset: 0x00050DF1
		public Trace WorldOnly()
		{
			this.request.Entities = 0;
			this.request.World = 1;
			return this;
		}

		/// <summary>
		/// This trace should only hit entities, ignoring the world geometry.
		/// </summary>
		// Token: 0x060014BA RID: 5306 RVA: 0x00052C11 File Offset: 0x00050E11
		public Trace EntitiesOnly()
		{
			this.request.Entities = 1;
			this.request.World = 0;
			return this;
		}

		/// <summary>
		/// The trace should hit all entities and the world geometry.
		/// </summary>
		/// <returns></returns>
		// Token: 0x060014BB RID: 5307 RVA: 0x00052C31 File Offset: 0x00050E31
		public Trace WorldAndEntities()
		{
			this.request.Entities = 1;
			this.request.World = 1;
			return this;
		}

		/// <summary>
		/// Makes this trace an axis aligned box of given size. Extracts mins and maxs from the Bounding Box.
		/// </summary>
		// Token: 0x060014BC RID: 5308 RVA: 0x00052C51 File Offset: 0x00050E51
		public readonly Trace Size(in BBox hull)
		{
			return this.Size(hull.Mins, hull.Maxs);
		}

		/// <summary>
		/// Makes this trace an axis aligned box of given size. Calculates mins and maxs by assuming given size is (maxs-mins) and the center is in the middle.
		/// </summary>
		// Token: 0x060014BD RID: 5309 RVA: 0x00052C68 File Offset: 0x00050E68
		public readonly Trace Size(in Vector3 size)
		{
			Vector3 vector = size * -0.5f;
			Vector3 vector2 = size * 0.5f;
			return this.Size(vector, vector2);
		}

		/// <summary>
		/// Makes this trace an axis aligned box of given size.
		/// </summary>
		// Token: 0x060014BE RID: 5310 RVA: 0x00052CA4 File Offset: 0x00050EA4
		public readonly Trace Size(in Vector3 mins, in Vector3 maxs)
		{
			Trace c = this;
			c.request.Mins = mins;
			c.request.Maxs = maxs;
			return c;
		}

		/// <summary>
		/// Makes this trace a sphere of given radius.
		/// </summary>
		// Token: 0x060014BF RID: 5311 RVA: 0x00052CE0 File Offset: 0x00050EE0
		public readonly Trace Radius(float radius)
		{
			Trace c = this;
			c.request.Radius = radius;
			return c;
		}

		/// <summary>
		/// Adds or removes <see cref="F:Sandbox.CollisionLayer.Hitbox">CollisionLayer.Hitbox</see> to the trace's mask
		/// </summary>
		// Token: 0x060014C0 RID: 5312 RVA: 0x00052D02 File Offset: 0x00050F02
		public readonly Trace UseHitboxes(bool hit = true)
		{
			return this.HitLayer(CollisionLayer.Hitbox, hit);
		}

		/// <summary>
		/// Adds or removes given <see cref="T:Sandbox.CollisionLayer">CollisionLayer</see> to the trace's mask
		/// </summary>
		// Token: 0x060014C1 RID: 5313 RVA: 0x00052D10 File Offset: 0x00050F10
		public readonly Trace HitLayer(CollisionLayer layer, bool hit = true)
		{
			Trace c = this;
			if (hit)
			{
				c.request.Mask = c.request.Mask | layer;
			}
			else
			{
				c.request.Mask = c.request.Mask & ~layer;
			}
			return c;
		}

		// Token: 0x060014C2 RID: 5314 RVA: 0x00052D50 File Offset: 0x00050F50
		private readonly TraceResult GetResult()
		{
			if (this.request.PhysicsBody.IsValid)
			{
				return Trace.SweepPhysicsBody(this.request);
			}
			if (this.request.Capsule.Radius > 0f)
			{
				return Trace.Capsule(this.request);
			}
			return Trace.Ray(this.request);
		}

		// Token: 0x060014C3 RID: 5315 RVA: 0x00052DA9 File Offset: 0x00050FA9
		public readonly bool Test()
		{
			return this.GetResult().Fraction < 1f;
		}

		/// <summary>
		/// Run the trace and return the result. The result will return the first hit.
		/// If the trace didn't hit then <see cref="F:Sandbox.TraceResult.Hit">TraceResult.Hit</see> will be false.
		/// </summary>
		// Token: 0x060014C4 RID: 5316 RVA: 0x00052DC0 File Offset: 0x00050FC0
		public readonly TraceResult Run()
		{
			TraceResult result2;
			using (Performance.Scope("Trace.Run"))
			{
				TraceResult result = this.GetResult();
				result2 = TraceResult.From(result);
			}
			return result2;
		}

		/// <summary>
		/// Run the trace and return the results. This will return every entity hit in the
		/// order that they were hit. It will only hit each entity once.
		/// </summary>
		// Token: 0x060014C5 RID: 5317 RVA: 0x00052E04 File Offset: 0x00051004
		public unsafe TraceResult[] RunAll()
		{
			TraceResult[] result2;
			using (Performance.Scope("Trace.RunAll"))
			{
				TraceResult* tr;
				int c;
				checked
				{
					tr = stackalloc TraceResult[unchecked((UIntPtr)32) * (UIntPtr)sizeof(TraceResult)];
					if (this.request.PhysicsBody.IsValid)
					{
						c = Trace.SweepPhysicsBodyAll(this.request, (IntPtr)((void*)tr), 32);
					}
					else if (this.request.Capsule.Radius > 0f)
					{
						c = Trace.CapsuleAll(this.request, (IntPtr)((void*)tr), 32);
					}
					else
					{
						c = Trace.RayAll(this.request, (IntPtr)((void*)tr), 32);
					}
				}
				if (c == 0)
				{
					result2 = null;
				}
				else
				{
					TraceResult[] result = new TraceResult[c];
					for (int i = 0; i < c; i++)
					{
						result[i] = TraceResult.From(tr[i]);
					}
					result2 = result;
				}
			}
			return result2;
		}

		// Token: 0x060014C6 RID: 5318 RVA: 0x00052EF0 File Offset: 0x000510F0
		internal unsafe Trace WithOptionalTag(string tag)
		{
			int ident = (int)StringToken.FindOrCreate(tag);
			this.request.ResolveEntities = 1;
			for (int i = 0; i < 8; i++)
			{
				if (*((ref this.request.TagAny.FixedElementField) + (IntPtr)i * 4) == ident)
				{
					return this;
				}
				if (*((ref this.request.TagAny.FixedElementField) + (IntPtr)i * 4) == 0)
				{
					*((ref this.request.TagAny.FixedElementField) + (IntPtr)i * 4) = ident;
					return this;
				}
			}
			return this;
		}

		/// <summary>
		/// Only return entities with this tag. Subsequent calls to this will add multiple requirements
		/// and they'll all have to be met (ie, the entity will need all tags).
		/// </summary>
		// Token: 0x060014C7 RID: 5319 RVA: 0x00052F78 File Offset: 0x00051178
		public unsafe Trace WithTag(string tag)
		{
			int ident = (int)StringToken.FindOrCreate(tag);
			this.request.ResolveEntities = 1;
			for (int i = 0; i < 8; i++)
			{
				if (*((ref this.request.TagRequire.FixedElementField) + (IntPtr)i * 4) == ident)
				{
					return this;
				}
				if (*((ref this.request.TagRequire.FixedElementField) + (IntPtr)i * 4) == 0)
				{
					*((ref this.request.TagRequire.FixedElementField) + (IntPtr)i * 4) = ident;
					return this;
				}
			}
			return this;
		}

		/// <summary>
		/// Only return entities with all of these tags
		/// </summary>
		// Token: 0x060014C8 RID: 5320 RVA: 0x00053000 File Offset: 0x00051200
		public Trace WithAllTags(params string[] tags)
		{
			Trace t = this;
			foreach (string tag in tags)
			{
				t = t.WithTag(tag);
			}
			return t;
		}

		/// <summary>
		/// Only return entities with any of these tags
		/// </summary>
		// Token: 0x060014C9 RID: 5321 RVA: 0x00053034 File Offset: 0x00051234
		public Trace WithAnyTags(params string[] tags)
		{
			Trace t = this;
			foreach (string tag in tags)
			{
				t = t.WithOptionalTag(tag);
			}
			return t;
		}

		// Token: 0x060014CA RID: 5322 RVA: 0x00053068 File Offset: 0x00051268
		internal unsafe Trace WithoutTag(string tag)
		{
			int ident = (int)StringToken.FindOrCreate(tag);
			this.request.ResolveEntities = 1;
			for (int i = 0; i < 8; i++)
			{
				if (*((ref this.request.TagExclude.FixedElementField) + (IntPtr)i * 4) == ident)
				{
					return this;
				}
				if (*((ref this.request.TagExclude.FixedElementField) + (IntPtr)i * 4) == 0)
				{
					*((ref this.request.TagExclude.FixedElementField) + (IntPtr)i * 4) = ident;
					return this;
				}
			}
			return this;
		}

		/// <summary>
		/// Only return entities without any of these tags
		/// </summary>
		// Token: 0x060014CB RID: 5323 RVA: 0x000530F0 File Offset: 0x000512F0
		public Trace WithoutTags(params string[] tags)
		{
			Trace t = this;
			foreach (string tag in tags)
			{
				t = t.WithoutTag(tag);
			}
			return t;
		}

		// Token: 0x040004CC RID: 1228
		private TraceRequest request;
	}
}
