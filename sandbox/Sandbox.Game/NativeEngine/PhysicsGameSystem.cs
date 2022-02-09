using System;

namespace NativeEngine
{
	// Token: 0x02000045 RID: 69
	internal static class PhysicsGameSystem
	{
		// Token: 0x0600095B RID: 2395 RVA: 0x00036CD4 File Offset: 0x00034ED4
		internal static void InitSubSteps(int count, float interval)
		{
			method gpPhys_InitSubSteps = PhysicsGameSystem.__N.gpPhys_InitSubSteps;
			calli(System.Void(System.Int32,System.Single), count, interval, gpPhys_InitSubSteps);
		}

		// Token: 0x020001CA RID: 458
		internal static class __N
		{
			// Token: 0x04000E82 RID: 3714
			internal static method gpPhys_InitSubSteps;
		}
	}
}
