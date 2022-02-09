using System;

namespace NativeEngine
{
	// Token: 0x02000056 RID: 86
	internal static class PhysicsQuery
	{
		// Token: 0x06000B8B RID: 2955 RVA: 0x0003C528 File Offset: 0x0003A728
		internal unsafe static ulong GetPointContents(Vector3 point, ulong mask, bool staticOnly)
		{
			method physcs_GetPointContents = PhysicsQuery.__N.Physcs_GetPointContents;
			return calli(System.UInt64(Vector3*,System.UInt64,System.Int32), &point, mask, staticOnly ? 1 : 0, physcs_GetPointContents);
		}

		// Token: 0x020001DB RID: 475
		internal static class __N
		{
			// Token: 0x0400102E RID: 4142
			internal static method Physcs_GetPointContents;
		}
	}
}
