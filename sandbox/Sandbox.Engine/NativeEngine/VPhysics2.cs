using System;

namespace NativeEngine
{
	// Token: 0x02000239 RID: 569
	internal static class VPhysics2
	{
		// Token: 0x06000E7D RID: 3709 RVA: 0x00019A1C File Offset: 0x00017C1C
		internal static int NumWorlds()
		{
			return calli(System.Int32(), VPhysics2.__N.gpVPhy_NumWorlds);
		}

		// Token: 0x06000E7E RID: 3710 RVA: 0x00019A28 File Offset: 0x00017C28
		internal static bool IsMultiThreaded()
		{
			return calli(System.Int32(), VPhysics2.__N.gpVPhy_IsMultiThreaded) > 0;
		}

		// Token: 0x06000E7F RID: 3711 RVA: 0x00019A38 File Offset: 0x00017C38
		internal static void SetMultiThreaded(bool bMT)
		{
			method gpVPhy_SetMultiThreaded = VPhysics2.__N.gpVPhy_SetMultiThreaded;
			calli(System.Void(System.Int32), bMT ? 1 : 0, gpVPhy_SetMultiThreaded);
		}

		// Token: 0x06000E80 RID: 3712 RVA: 0x00019A58 File Offset: 0x00017C58
		internal static IPhysSurfacePropertyController GetSurfacePropertyController()
		{
			return calli(System.IntPtr(), VPhysics2.__N.gpVPhy_GetSurfacePropertyController);
		}

		// Token: 0x0200039E RID: 926
		internal static class __N
		{
			// Token: 0x0400186A RID: 6250
			internal static method gpVPhy_NumWorlds;

			// Token: 0x0400186B RID: 6251
			internal static method gpVPhy_IsMultiThreaded;

			// Token: 0x0400186C RID: 6252
			internal static method gpVPhy_SetMultiThreaded;

			// Token: 0x0400186D RID: 6253
			internal static method gpVPhy_GetSurfacePropertyController;
		}
	}
}
