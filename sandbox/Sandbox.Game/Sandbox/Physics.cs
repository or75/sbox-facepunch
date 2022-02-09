using System;
using System.Collections.Generic;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000D9 RID: 217
	public static class Physics
	{
		/// <summary>
		/// Get what's at this point
		/// </summary>
		// Token: 0x060012DE RID: 4830 RVA: 0x0004E908 File Offset: 0x0004CB08
		public static CollisionLayer GetPointContents(Vector3 point, bool staticOnly = false)
		{
			return (CollisionLayer)PhysicsQuery.GetPointContents(point, ulong.MaxValue, staticOnly);
		}

		/// <summary>
		/// Is this at this point
		/// </summary>
		// Token: 0x060012DF RID: 4831 RVA: 0x0004E913 File Offset: 0x0004CB13
		public static bool TestPointContents(Vector3 point, CollisionLayer layer, bool staticOnly = false)
		{
			return PhysicsQuery.GetPointContents(point, (ulong)layer, staticOnly) == (ulong)layer;
		}

		// Token: 0x060012E0 RID: 4832 RVA: 0x0004E920 File Offset: 0x0004CB20
		public static IEnumerable<Entity> GetEntitiesInSphere(Vector3 position, float radius)
		{
			CUtlVectorOverlapResult results = CUtlVectorOverlapResult.Create(16, 16);
			GameGlue.PhysicsQueryEntitiesInSphere(position, radius, results);
			int numEntities = results.Count();
			int num;
			for (int i = 0; i < numEntities; i = num)
			{
				uint entPtr = results.Element(i).Entity;
				if (entPtr != 0U)
				{
					Entity entity = InteropSystem.Get<Entity>(entPtr);
					if (entity.IsValid())
					{
						yield return entity;
					}
				}
				num = i + 1;
			}
			results.DeleteThis();
			yield break;
		}

		// Token: 0x060012E1 RID: 4833 RVA: 0x0004E937 File Offset: 0x0004CB37
		public static IEnumerable<Entity> GetEntitiesInBox(BBox box)
		{
			CUtlVectorOverlapResult results = CUtlVectorOverlapResult.Create(16, 16);
			GameGlue.PhysicsQueryEntitiesInBox(box, results);
			int numEntities = results.Count();
			int num;
			for (int i = 0; i < numEntities; i = num)
			{
				uint entPtr = results.Element(i).Entity;
				if (entPtr != 0U)
				{
					Entity entity = InteropSystem.Get<Entity>(entPtr);
					if (entity.IsValid())
					{
						yield return entity;
					}
				}
				num = i + 1;
			}
			results.DeleteThis();
			yield break;
		}
	}
}
