using System;

namespace NativeEngine
{
	// Token: 0x02000236 RID: 566
	internal static class RenderService
	{
		// Token: 0x06000E75 RID: 3701 RVA: 0x00019934 File Offset: 0x00017B34
		internal static RenderMultisampleType GetMultisampleType()
		{
			return calli(System.Int64(), RenderService.__N.gpRend_GetMultisampleType);
		}

		// Token: 0x0200039B RID: 923
		internal static class __N
		{
			// Token: 0x04001862 RID: 6242
			internal static method gpRend_GetMultisampleType;
		}
	}
}
