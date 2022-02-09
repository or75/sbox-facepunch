using System;

namespace NativeGlue
{
	// Token: 0x0200000C RID: 12
	internal static class NavMesh
	{
		// Token: 0x06000026 RID: 38 RVA: 0x00002AB4 File Offset: 0x00000CB4
		internal static bool IsLoaded()
		{
			return calli(System.Int32(), NavMesh.__N.Glue_NvMesh_IsLoaded) > 0;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002AC4 File Offset: 0x00000CC4
		internal unsafe static Vector3 GetPointOnMesh(Vector3 pos)
		{
			method glue_NvMesh_GetPointOnMesh = NavMesh.__N.Glue_NvMesh_GetPointOnMesh;
			return calli(Vector3(Vector3*), &pos, glue_NvMesh_GetPointOnMesh);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002AE0 File Offset: 0x00000CE0
		internal unsafe static int BuildPath(Vector3 pos, Vector3 end, IntPtr buffer, int maxNum)
		{
			method glue_NvMesh_BuildPath = NavMesh.__N.Glue_NvMesh_BuildPath;
			return calli(System.Int32(Vector3*,Vector3*,System.IntPtr,System.Int32), &pos, &end, buffer, maxNum, glue_NvMesh_BuildPath);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002B04 File Offset: 0x00000D04
		internal unsafe static int BuildPathEx(Vector3 pos, Vector3 end, IntPtr buffer, int maxNum, float stepHeight, float duckHeight)
		{
			method glue_NvMesh_BuildPathEx = NavMesh.__N.Glue_NvMesh_BuildPathEx;
			return calli(System.Int32(Vector3*,Vector3*,System.IntPtr,System.Int32,System.Single,System.Single), &pos, &end, buffer, maxNum, stepHeight, duckHeight, glue_NvMesh_BuildPathEx);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002B2C File Offset: 0x00000D2C
		internal unsafe static ulong GetNavAreaAttributes(Vector3 pos)
		{
			method glue_NvMesh_GetNavAreaAttributes = NavMesh.__N.Glue_NvMesh_GetNavAreaAttributes;
			return calli(System.UInt64(Vector3*), &pos, glue_NvMesh_GetNavAreaAttributes);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002B48 File Offset: 0x00000D48
		internal unsafe static Vector3 GetPointWithinRadius(Vector3 point, float minRadius, float maxRadius)
		{
			method glue_NvMesh_GetPointWithinRadius = NavMesh.__N.Glue_NvMesh_GetPointWithinRadius;
			return calli(Vector3(Vector3*,System.Single,System.Single), &point, minRadius, maxRadius, glue_NvMesh_GetPointWithinRadius);
		}

		// Token: 0x02000197 RID: 407
		internal static class __N
		{
			// Token: 0x040007CC RID: 1996
			internal static method Glue_NvMesh_IsLoaded;

			// Token: 0x040007CD RID: 1997
			internal static method Glue_NvMesh_GetPointOnMesh;

			// Token: 0x040007CE RID: 1998
			internal static method Glue_NvMesh_BuildPath;

			// Token: 0x040007CF RID: 1999
			internal static method Glue_NvMesh_BuildPathEx;

			// Token: 0x040007D0 RID: 2000
			internal static method Glue_NvMesh_GetNavAreaAttributes;

			// Token: 0x040007D1 RID: 2001
			internal static method Glue_NvMesh_GetPointWithinRadius;
		}
	}
}
