using System;

namespace NativeEngine
{
	// Token: 0x02000047 RID: 71
	internal static class ResourceSystem
	{
		// Token: 0x0600095D RID: 2397 RVA: 0x00036D14 File Offset: 0x00034F14
		internal static ulong ResourceHandleToResourceId(IMaterial material)
		{
			method gpResr_ResourceHandleToResourceId = ResourceSystem.__N.gpResr_ResourceHandleToResourceId;
			return calli(System.UInt64(System.IntPtr), material, gpResr_ResourceHandleToResourceId);
		}

		// Token: 0x020001CC RID: 460
		internal static class __N
		{
			// Token: 0x04000E84 RID: 3716
			internal static method gpResr_ResourceHandleToResourceId;
		}
	}
}
