using System;
using NativeEngine;

namespace Sandbox.Internal
{
	// Token: 0x0200016F RID: 367
	[Hotload.SkipAttribute]
	public static class Decals
	{
		// Token: 0x06001B6F RID: 7023 RVA: 0x0006E760 File Offset: 0x0006C960
		public static void Place(Material material, Entity entity, int bone, Vector3 position, Vector3 scale, Rotation rotation)
		{
			Host.AssertClientOrMenu("Place");
			if (material == null)
			{
				return;
			}
			if (!entity.IsValid())
			{
				return;
			}
			DecalGameSystem.DecalShoot(material.native, entity.GetEntityIntPtr(), bone, position, rotation, scale, Color.White.ToColor32(false));
		}

		// Token: 0x06001B70 RID: 7024 RVA: 0x0006E7AC File Offset: 0x0006C9AC
		public static void Place(Material material, Vector3 position, Vector3 scale, Rotation rotation)
		{
			Host.AssertClientOrMenu("Place");
			if (material == null)
			{
				return;
			}
			DecalGameSystem.DecalShoot(material.native, IntPtr.Zero, 0, position, rotation, scale, Color.White.ToColor32(false));
		}

		/// <summary>
		/// Remove all decals from the world
		/// </summary>
		// Token: 0x06001B71 RID: 7025 RVA: 0x0006E7E9 File Offset: 0x0006C9E9
		public static void RemoveFromWorld()
		{
			DecalGameSystem.ClearWorldDecals(1U);
		}

		/// <summary>
		/// Remove all decals from entities
		/// </summary>
		// Token: 0x06001B72 RID: 7026 RVA: 0x0006E7F1 File Offset: 0x0006C9F1
		public static void RemoveFromEntities()
		{
			DecalGameSystem.ClearEntityDecals(1U);
		}
	}
}
