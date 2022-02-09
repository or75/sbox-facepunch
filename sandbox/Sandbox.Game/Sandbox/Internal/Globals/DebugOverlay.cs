using System;
using System.Runtime.CompilerServices;
using NativeEngine;

namespace Sandbox.Internal.Globals
{
	// Token: 0x02000190 RID: 400
	public class DebugOverlay
	{
		// Token: 0x06001CA9 RID: 7337 RVA: 0x00071FC3 File Offset: 0x000701C3
		public void Line(Vector3 start, Vector3 end, Color color, float duration = 0f, bool depthTest = true)
		{
			DebugOverlay.Line(start, end, color.ToColor32(false), !depthTest, duration);
		}

		// Token: 0x06001CAA RID: 7338 RVA: 0x00071FDB File Offset: 0x000701DB
		public void Line(Vector3 start, Vector3 end, float duration = 0f, bool depthTest = true)
		{
			this.Line(start, end, DebugOverlay.defaultColor, duration, depthTest);
		}

		// Token: 0x06001CAB RID: 7339 RVA: 0x00071FED File Offset: 0x000701ED
		public void Text(Vector3 start, string text, Color color, float duration = 0f, float maxDistance = 500f)
		{
			DebugOverlay.Text(start, 0, text, maxDistance, color.ToColor32(false), duration);
		}

		// Token: 0x06001CAC RID: 7340 RVA: 0x00072003 File Offset: 0x00070203
		public void Text(Vector3 start, int offset, string text, Color color, float duration = 0f, float maxDistance = 500f)
		{
			DebugOverlay.Text(start, offset, text, maxDistance, color.ToColor32(false), duration);
		}

		// Token: 0x06001CAD RID: 7341 RVA: 0x00072019 File Offset: 0x00070219
		public void Text(Vector3 start, string text, float duration = 0f)
		{
			this.Text(start, text, DebugOverlay.defaultColor, duration, 500f);
		}

		// Token: 0x06001CAE RID: 7342 RVA: 0x0007202E File Offset: 0x0007022E
		public void Box(Vector3 mins, Vector3 maxs, Color color, float duration, bool depthTest = true)
		{
			DebugOverlay.Box(mins, maxs, color.ToColor32(false), !depthTest, duration);
		}

		// Token: 0x06001CAF RID: 7343 RVA: 0x00072046 File Offset: 0x00070246
		public void Box(Vector3 position, Vector3 mins, Vector3 maxs, Color color, float duration, bool depthTest = true)
		{
			this.Box(position, Rotation.Identity, mins, maxs, color, duration, depthTest);
		}

		// Token: 0x06001CB0 RID: 7344 RVA: 0x0007205C File Offset: 0x0007025C
		public void Box(Vector3 position, Rotation rotation, Vector3 mins, Vector3 maxs, Color color, float duration, bool depthTest = true)
		{
			Color32 c = color.ToColor32(false);
			DebugOverlay.BoxAngles(position, mins, maxs, rotation, (int)c.r, (int)c.g, (int)c.b, (int)c.a, !depthTest, duration);
		}

		// Token: 0x06001CB1 RID: 7345 RVA: 0x0007209F File Offset: 0x0007029F
		public void Box(float duration, Vector3 mins, Vector3 maxs, Color color, bool depthTest = true)
		{
			DebugOverlay.Box(mins, maxs, color.ToColor32(false), !depthTest, duration);
		}

		// Token: 0x06001CB2 RID: 7346 RVA: 0x000720B6 File Offset: 0x000702B6
		public void Box(float duration, Vector3 position, Vector3 mins, Vector3 maxs, Color color, bool depthTest = true)
		{
			this.Box(duration, position, Rotation.Identity, mins, maxs, color, depthTest);
		}

		// Token: 0x06001CB3 RID: 7347 RVA: 0x000720CC File Offset: 0x000702CC
		public void Box(float duration, Vector3 position, Rotation rotation, Vector3 mins, Vector3 maxs, Color color, bool depthTest = true)
		{
			Color32 c = color.ToColor32(false);
			DebugOverlay.BoxAngles(position, mins, maxs, rotation, (int)c.r, (int)c.g, (int)c.b, (int)c.a, !depthTest, duration);
		}

		// Token: 0x06001CB4 RID: 7348 RVA: 0x0007210F File Offset: 0x0007030F
		public void Box(Vector3 mins, Vector3 maxs, Color color)
		{
			this.Box(mins, maxs, color, 0f, true);
		}

		// Token: 0x06001CB5 RID: 7349 RVA: 0x00072120 File Offset: 0x00070320
		public void Box(Vector3 mins, Vector3 maxs)
		{
			this.Box(mins, maxs, DebugOverlay.defaultColor);
		}

		// Token: 0x06001CB6 RID: 7350 RVA: 0x0007212F File Offset: 0x0007032F
		public void Box(Vector3 position, Vector3 mins, Vector3 maxs, Color color, bool depthTest = true)
		{
			this.Box(position, Rotation.Identity, mins, maxs, color, 0f, depthTest);
		}

		// Token: 0x06001CB7 RID: 7351 RVA: 0x00072148 File Offset: 0x00070348
		public void ScreenText(Vector2 position, int line, Color color, string text, float duration = 0f)
		{
			Color32 c = color.ToColor32(false);
			DebugOverlay.ScreenTextOffset(position.x, position.y, line, text, (int)c.r, (int)c.g, (int)c.b, (int)c.a, duration);
		}

		// Token: 0x06001CB8 RID: 7352 RVA: 0x00072192 File Offset: 0x00070392
		public void ScreenText(Vector2 position, string text, float duration = 0f)
		{
			this.ScreenText(position, 0, DebugOverlay.defaultColor, text, duration);
		}

		// Token: 0x06001CB9 RID: 7353 RVA: 0x000721A3 File Offset: 0x000703A3
		public void ScreenText(string text, float duration = 0f)
		{
			this.ScreenText(new Vector2(100f, 100f), 0, DebugOverlay.defaultColor, text, duration);
		}

		// Token: 0x06001CBA RID: 7354 RVA: 0x000721C2 File Offset: 0x000703C2
		public void ScreenText(int line, string text, float duration = 0f)
		{
			this.ScreenText(new Vector2(100f, 100f), line, DebugOverlay.defaultColor, text, duration);
		}

		// Token: 0x06001CBB RID: 7355 RVA: 0x000721E1 File Offset: 0x000703E1
		public void Axis(Vector3 position, Rotation rotation, float length = 10f, float duration = 0f, bool depthTest = true)
		{
			DebugOverlay.Axis(position, rotation, length, !depthTest, duration);
		}

		// Token: 0x06001CBC RID: 7356 RVA: 0x000721F4 File Offset: 0x000703F4
		public void Sphere(Vector3 position, float radius, Color color, bool depthTest = true, float duration = 0f)
		{
			Color32 c = color.ToColor32(false);
			DebugOverlay.Sphere(position, radius, c, !depthTest, duration);
		}

		// Token: 0x06001CBD RID: 7357 RVA: 0x0007221C File Offset: 0x0007041C
		public void Circle(Vector3 position, Rotation rotation, float radius, Color color, bool depthTest = true, float duration = 0f)
		{
			Color32 c = color.ToColor32(false);
			DebugOverlay.Circle(position, rotation, radius, (int)c.r, (int)c.g, (int)c.b, (int)c.a, !depthTest, duration);
		}

		/// <summary>
		/// Draw this entity's skeleton ( if it has one)
		/// Will return false if it didn't manage to draw a skeleton.
		/// </summary>
		// Token: 0x06001CBE RID: 7358 RVA: 0x00072260 File Offset: 0x00070460
		public bool Skeleton(Entity ent, Color color, float duration = 0f, bool depthTest = true)
		{
			ModelEntity me = ent as ModelEntity;
			if (me == null)
			{
				return false;
			}
			int boneCount = me.BoneCount;
			if (boneCount <= 1)
			{
				return false;
			}
			for (int i = 0; i < boneCount; i++)
			{
				int p = me.GetBoneParent(i);
				if (i >= 0)
				{
					Transform a = me.GetBoneTransform(i, true);
					Transform b = me.GetBoneTransform(p, true);
					this.Line(a.Position, b.Position, color, duration, depthTest);
				}
			}
			return true;
		}

		/// <summary>
		/// Draw an entity bounds
		/// </summary>
		// Token: 0x06001CBF RID: 7359 RVA: 0x000722CC File Offset: 0x000704CC
		public void Box(Entity ent, Color color, float duration = 0f)
		{
			ModelEntity modelEnt = ent as ModelEntity;
			if (modelEnt != null)
			{
				BBox bbox = modelEnt.CollisionBounds;
				this.Box(duration, modelEnt.Position, modelEnt.Rotation, bbox.Mins, bbox.Maxs, color, true);
				return;
			}
			this.Box(duration, ent.Position, ent.Rotation, -1f, 1f, color, true);
		}

		/// <summary>
		/// Draw a physics object bounds
		/// </summary>
		// Token: 0x06001CC0 RID: 7360 RVA: 0x00072338 File Offset: 0x00070538
		public void Box(PhysicsBody body, Color color, float duration = 0f)
		{
			BBox bounds = body.GetBounds();
			this.Box(duration, Vector3.Zero, Rotation.Identity, bounds.Mins, bounds.Maxs, color, true);
		}

		/// <summary>
		/// Visulalize a trace
		/// </summary>
		// Token: 0x06001CC1 RID: 7361 RVA: 0x0007236C File Offset: 0x0007056C
		public void TraceResult(TraceResult tr, float duration = 0f)
		{
			if (tr.Hit)
			{
				this.Sphere(tr.EndPos, 10f, Color.Blue, true, duration);
				this.Line(tr.EndPos, tr.EndPos + tr.Normal, Color.Green, duration, true);
				if (tr.Entity != null)
				{
					Vector3 endPos = tr.EndPos;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Hit Entity: ");
					defaultInterpolatedStringHandler.AppendFormatted<Entity>(tr.Entity);
					this.Text(endPos, defaultInterpolatedStringHandler.ToStringAndClear(), duration);
				}
				this.Line(tr.StartPos, tr.EndPos, Color.White, duration, true);
				return;
			}
			this.Line(tr.StartPos, tr.StartPos + tr.Direction * tr.Distance, Color.White, duration, true);
		}

		// Token: 0x040007C5 RID: 1989
		private static Color defaultColor = Color.Yellow;
	}
}
