using System;

namespace Sandbox
{
	// Token: 0x020000AE RID: 174
	internal static class InputGlyphSizeExtension
	{
		// Token: 0x0600115B RID: 4443 RVA: 0x00049F2C File Offset: 0x0004812C
		public static int ToPixels(this InputGlyphSize size)
		{
			int result;
			switch (size)
			{
			case InputGlyphSize.Small:
				result = 32;
				break;
			case InputGlyphSize.Medium:
				result = 64;
				break;
			case InputGlyphSize.Large:
				result = 128;
				break;
			default:
				result = 32;
				break;
			}
			return result;
		}
	}
}
