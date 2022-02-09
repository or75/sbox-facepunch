using System;
using SkiaSharp;

namespace Sandbox.UI
{
	// Token: 0x02000116 RID: 278
	internal static class SkiaCompat
	{
		// Token: 0x060015BF RID: 5567 RVA: 0x00057580 File Offset: 0x00055780
		public static SKColor ToSk(this Color c)
		{
			Color32 c2 = c.ToColor32(false);
			return new SKColor(c2.r, c2.g, c2.b, c2.a);
		}
	}
}
