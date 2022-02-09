using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200023E RID: 574
	internal static class ImageLoader
	{
		// Token: 0x06000EA2 RID: 3746 RVA: 0x00019E20 File Offset: 0x00018020
		internal static int GetMemRequired(int width, int height, int depth, ImageFormat imageFormat, bool mipmap)
		{
			method imgeLd_GetMemRequired = ImageLoader.__N.ImgeLd_GetMemRequired;
			return calli(System.Int32(System.Int32,System.Int32,System.Int32,System.Int64,System.Int32), width, height, depth, (long)imageFormat, mipmap ? 1 : 0, imgeLd_GetMemRequired);
		}

		// Token: 0x020003A3 RID: 931
		internal static class __N
		{
			// Token: 0x04001883 RID: 6275
			internal static method ImgeLd_GetMemRequired;
		}
	}
}
