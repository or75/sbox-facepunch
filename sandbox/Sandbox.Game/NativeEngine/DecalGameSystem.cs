using System;

namespace NativeEngine
{
	// Token: 0x0200003F RID: 63
	internal static class DecalGameSystem
	{
		// Token: 0x06000942 RID: 2370 RVA: 0x00036A20 File Offset: 0x00034C20
		internal static void ClearDecalsForSkeletonInstance(CSkeletonInstance pSkeletonInstance, uint nDecalFlagsToClear)
		{
			method gpDecl_ClearDecalsForSkeletonInstance = DecalGameSystem.__N.gpDecl_ClearDecalsForSkeletonInstance;
			calli(System.Void(System.IntPtr,System.UInt32), pSkeletonInstance, nDecalFlagsToClear, gpDecl_ClearDecalsForSkeletonInstance);
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x00036A40 File Offset: 0x00034C40
		internal static void ClearWorldDecals(uint nDecalFlagsToClear)
		{
			method gpDecl_ClearWorldDecals = DecalGameSystem.__N.gpDecl_ClearWorldDecals;
			calli(System.Void(System.UInt32), nDecalFlagsToClear, gpDecl_ClearWorldDecals);
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x00036A5C File Offset: 0x00034C5C
		internal static void ClearEntityDecals(uint nDecalFlagsToClear)
		{
			method gpDecl_ClearEntityDecals = DecalGameSystem.__N.gpDecl_ClearEntityDecals;
			calli(System.Void(System.UInt32), nDecalFlagsToClear, gpDecl_ClearEntityDecals);
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x00036A78 File Offset: 0x00034C78
		internal static void MoveDecals(IntPtr src, IntPtr dest)
		{
			method gpDecl_MoveDecals = DecalGameSystem.__N.gpDecl_MoveDecals;
			calli(System.Void(System.IntPtr,System.IntPtr), src, dest, gpDecl_MoveDecals);
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x00036A94 File Offset: 0x00034C94
		internal unsafe static void DecalShoot(IMaterial material, IntPtr entity, int bone, Vector3 pos, Rotation rot, Vector3 scale, Color32 color)
		{
			method gpDecl_DecalShoot = DecalGameSystem.__N.gpDecl_DecalShoot;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32,Vector3*,Rotation*,Vector3*,Color32), material, entity, bone, &pos, &rot, &scale, color, gpDecl_DecalShoot);
		}

		// Token: 0x020001C4 RID: 452
		internal static class __N
		{
			// Token: 0x04000E69 RID: 3689
			internal static method gpDecl_ClearDecalsForSkeletonInstance;

			// Token: 0x04000E6A RID: 3690
			internal static method gpDecl_ClearWorldDecals;

			// Token: 0x04000E6B RID: 3691
			internal static method gpDecl_ClearEntityDecals;

			// Token: 0x04000E6C RID: 3692
			internal static method gpDecl_MoveDecals;

			// Token: 0x04000E6D RID: 3693
			internal static method gpDecl_DecalShoot;
		}
	}
}
