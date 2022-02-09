using System;

namespace NativeEngine
{
	// Token: 0x02000042 RID: 66
	internal static class LightQueryGameSystem
	{
		// Token: 0x06000953 RID: 2387 RVA: 0x00036BDC File Offset: 0x00034DDC
		internal unsafe static Vector3 GetLightForPoint(Vector3 pos)
		{
			method gpLght_GetLightForPoint = LightQueryGameSystem.__N.gpLght_GetLightForPoint;
			return calli(Vector3(Vector3*), &pos, gpLght_GetLightForPoint);
		}

		// Token: 0x020001C7 RID: 455
		internal static class __N
		{
			// Token: 0x04000E7A RID: 3706
			internal static method gpLght_GetLightForPoint;
		}
	}
}
